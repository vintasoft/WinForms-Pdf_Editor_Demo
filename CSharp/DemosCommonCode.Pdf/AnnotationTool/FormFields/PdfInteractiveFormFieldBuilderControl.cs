using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms.AppearanceGenerators;
using Vintasoft.Imaging.Pdf.UI.Annotations;
using Vintasoft.Imaging.UI;

using DemosCommonCode.CustomControls;
using DemosCommonCode.Imaging;
using DemosCommonCode.Pdf.Security;
using Vintasoft.Imaging;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A panel that allows to build new PDF interactive form field and
    /// add the field to a PDF page.
    /// </summary>
    public partial class PdfInteractiveFormFieldBuilderControl : UserControl
    {

        #region Fields

        /// <summary>
        /// Dictionary: the tool strip item => interaction form field type, which must be built.
        /// </summary>
        Dictionary<ToolStripItem, InteractiveFormFieldType> _toolStripItemToInteractiveFormFieldType =
            new Dictionary<ToolStripItem, InteractiveFormFieldType>();

        /// <summary>
        /// Dictionary: the interactive form field type =>  the tool strip item.
        /// </summary>
        Dictionary<InteractiveFormFieldType, ToolStripItem> _interactiveFormFieldTypeToToolStripItem =
            new Dictionary<InteractiveFormFieldType, ToolStripItem>();

        /// <summary>
        /// The interactive form field button, which is currently selected in the control.
        /// </summary>
        CheckedToolStripSplitButton _selectedInteractiveFormFieldButton;

        /// <summary>
        /// The type of the last built interaction form field.
        /// </summary>
        InteractiveFormFieldType _lastBuiltInteractiveFormFieldType = InteractiveFormFieldType.Unknown;

        /// <summary>
        /// The parent interactive field of the last built interactive form field.
        /// </summary>
        PdfInteractiveFormField _lastBuiltInteractiveFormFieldParent = null;

        /// <summary>
        /// A value indicating whether the focused index of image viewer is changing.
        /// </summary>
        bool _isFocusedIndexChanging = false;

        /// <summary>
        /// A value indicating whether the interaction mode is changing.
        /// </summary>
        bool _isInteractionModeChanging = false;

        /// <summary>
        /// A value indicating whether the interaction form field building must be continued after changing focus in viewer.
        /// </summary>
        bool _needContinueBuildFieldsAfterFocusedIndexChanged = false;

        /// <summary>
        /// The previous value of
        /// <see cref="Vintasoft.Imaging.Pdf.UI.Annotations.PdfAnnotationTool.AllowMultipleSelection"/> property.
        /// </summary>
        bool _allowMultipleSelectionPreviousValue = false;

        /// <summary>
        /// The mouse observer of visual tool.
        /// </summary>
        VisualToolMouseObserver _visualToolMouseObserver = new VisualToolMouseObserver();

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfInteractiveFormFieldBuilderControl"/> class.
        /// </summary>
        public PdfInteractiveFormFieldBuilderControl()
        {
            InitializeComponent();

            InitializeInteractiveFormFieldButtons();

            if (DesignMode || ImagingEnvironment.IsInDesignMode)
                return;

            AnnotationAppearanceGeneratorController = new PdfAnnotationAppearanceGeneratorController();

            textFieldNoBorderToolStripMenuItem.Checked = true;
            checkBoxStandardToolStripMenuItem.Checked = true;
            buttonBorder3DToolStripMenuItem.Checked = true;
            listBoxNoBorderToolStripMenuItem.Checked = true;
            comboBoxNoBorderToolStripMenuItem.Checked = true;
            radioButtonStandardToolStripMenuItem.Checked = true;
            barcodePdf417ToolStripMenuItem.Checked = true;
            signatureDefaultToolStripMenuItem.Checked = true;
        }

        #endregion



        #region Properties

        PdfAnnotationTool _annotationTool;
        /// <summary>
        /// Gets or sets the PDF annotation tool.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if new annotation tool is activated already.</exception>
        [DefaultValue((object)null)]
        public PdfAnnotationTool AnnotationTool
        {
            get
            {
                return _annotationTool;
            }
            set
            {
                if (_annotationTool != value)
                {
                    if (value != null && value.ImageViewer != null)
                        throw new InvalidOperationException("Annotation tool should be deactivated.");

                    if (_annotationTool != null)
                        UnsubscribeFromPdfAnnotationToolEvents(_annotationTool);
                    _annotationTool = value;
                    _visualToolMouseObserver.VisualTool = value;
                    if (_annotationTool != null)
                        SubscribeToPdfAnnotationToolEvents(_annotationTool);

                    UpdateUI();
                }
            }
        }

        /// <summary>
        /// Gets the current PDF document.
        /// </summary>
        public PdfDocument CurrentDocument
        {
            get
            {
                if (AnnotationTool == null)
                    return null;
                if (AnnotationTool.FocusedPage == null)
                    return null;
                return AnnotationTool.FocusedPage.Document;
            }
        }

        /// <summary>
        /// Gets or sets the graphics figure of signature appearance.
        /// </summary>
        [DefaultValue((object)null)]
        [Browsable(false)]
        public SignatureAppearanceGraphicsFigure SignatureAppearance
        {
            get
            {
                if (DesignMode)
                    return null;
                SignatureAppearanceGraphicsFigure figure =
                    ((SignatureAppearanceGenerator)_annotationAppearanceGeneratorController[signatureDefaultToolStripMenuItem]).SignatureAppearance;
                return figure;
            }
            set
            {
                ((SignatureAppearanceGenerator)_annotationAppearanceGeneratorController[signatureDefaultToolStripMenuItem]).SignatureAppearance = value;
            }
        }

        PdfAnnotationAppearanceGeneratorController _annotationAppearanceGeneratorController = null;
        /// <summary>
        /// Gets or sets the annotation appearance generator controller.
        /// </summary>
        [Browsable(false)]
        [ReadOnly(true)]
        public PdfAnnotationAppearanceGeneratorController AnnotationAppearanceGeneratorController
        {
            get
            {
                return _annotationAppearanceGeneratorController;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                if (_annotationAppearanceGeneratorController == value)
                    return;

                _annotationAppearanceGeneratorController = value;
                InitAnnotationAppearanceGeneratorController(_annotationAppearanceGeneratorController);
            }
        }

        bool _addRadioButtonToFocusedGroup = true;
        /// <summary>
        /// Gets or sets a value indicating whether a radio button must be added to
        /// the focused radio buttons group.
        /// </summary>
        /// <value>
        /// Default value is <b>true</b>.
        /// </value>
        public bool AddRadioButtonToFocusedGroup
        {
            get
            {
                return _addRadioButtonToFocusedGroup;
            }
            set
            {
                _addRadioButtonToFocusedGroup = value;
            }
        }

        bool _needBuildFormFieldsContinuously = false;
        /// <summary>
        /// Gets or sets a value indicating whether the interaction form fields must be built continuously.
        /// </summary>
        /// <value>
        /// Default value is <b>false</b>.
        /// </value>
        public bool NeedBuildFormFieldsContinuously
        {
            get
            {
                return _needBuildFormFieldsContinuously;
            }
            set
            {
                _needBuildFormFieldsContinuously = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates the user interface of this control.
        /// </summary>
        public void UpdateUI()
        {
            mainToolStrip.Enabled =
                _annotationTool != null &&
                _annotationTool.ImageViewer != null &&
                _annotationTool.ImageViewer.Image != null &&
                PdfDocumentController.GetPageAssociatedWithImage(_annotationTool.ImageViewer.Image) != null;
        }

        /// <summary>
        /// Shows a dialog that allows to verify a signature OR sign the PDF document.
        /// </summary>
        /// <param name="signatureView">The signature view.</param>
        public void ShowSignatureDialog(PdfSignatureWidgetAnnotationView signatureView)
        {
            // if signature is empty
            if (signatureView.Field.SignatureInfo == null)
            {
                // sign document

                SignatureAppearanceGenerator generator = signatureView.Annotation.AppearanceGenerator as SignatureAppearanceGenerator;
                SignatureAppearanceGraphicsFigure signatureAppearanceGraphicsFigure;
                if (generator == null)
                    signatureAppearanceGraphicsFigure = SignatureAppearance;
                else
                    signatureAppearanceGraphicsFigure = generator.SignatureAppearance;

                // check pages of PDF document
                if (PdfDemosTools.CheckAllPagesFromDocument(this.AnnotationTool.ImageViewer.Images, signatureView.Field.Document))
                {
                    using (CreateSignatureFieldForm createSignature = new CreateSignatureFieldForm(
                        signatureView.Field, signatureAppearanceGraphicsFigure))
                    {
                        if (createSignature.ShowDialog() == DialogResult.OK)
                        {
                            signatureView.Invalidate();
                        }
                    }
                }
            }
            // if signature is NOT empty
            else
            {
                // verify signature

                using (DocumentSignaturesForm dialog = new DocumentSignaturesForm(signatureView.Field.Document))
                {
                    dialog.SelectedSignatureField = (PdfInteractiveFormSignatureField)signatureView.Field;
                    dialog.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Adds and builds the interactive form field.
        /// </summary>
        /// <param name="interactiveFormFieldType">The type of interactive form field.</param>
        public void AddAndBuildInteractiveFormField(InteractiveFormFieldType interactiveFormFieldType)
        {
            AddAndBuildInteractiveFormField(interactiveFormFieldType, null);
        }

        /// <summary>
        /// Adds and builds the interactive form field.
        /// </summary>
        /// <param name="interactiveFormFieldType">The type of interactive form field.</param>
        /// <param name="parentInteractiveFormField">The parent interactive form field.</param>
        public void AddAndBuildInteractiveFormField(
            InteractiveFormFieldType interactiveFormFieldType,
            PdfInteractiveFormField parentInteractiveFormField)
        {
            try
            {
                SetSelectedInteractiveFormFieldButton(interactiveFormFieldType);

                _lastBuiltInteractiveFormFieldType = interactiveFormFieldType;
                _lastBuiltInteractiveFormFieldParent = parentInteractiveFormField;

                if (interactiveFormFieldType != InteractiveFormFieldType.Unknown)
                {
                    if (AnnotationTool.InteractionMode != PdfAnnotationInteractionMode.Edit)
                    {
                        _isInteractionModeChanging = true;
                        AnnotationTool.InteractionMode = PdfAnnotationInteractionMode.Edit;
                        _isInteractionModeChanging = false;
                    }

                    switch (interactiveFormFieldType)
                    {
                        case InteractiveFormFieldType.TextField:
                            AddAndBuildTextField(parentInteractiveFormField);
                            break;

                        case InteractiveFormFieldType.CheckBox:
                            AddAndBuildCheckBoxField(parentInteractiveFormField);
                            break;

                        case InteractiveFormFieldType.PushButton:
                            AddAndBuildButtonField(parentInteractiveFormField);
                            break;

                        case InteractiveFormFieldType.ListBox:
                            AddAndBuildListBoxField(parentInteractiveFormField);
                            break;

                        case InteractiveFormFieldType.ComboBox:
                            AddAndBuildComboBoxField(parentInteractiveFormField);
                            break;

                        case InteractiveFormFieldType.RadioButton:
                            AddAndBuildRadioButtonField(parentInteractiveFormField);
                            break;

                        case InteractiveFormFieldType.BarcodeField:
                            AddAndBuildBarcodeField(parentInteractiveFormField);
                            break;

                        case InteractiveFormFieldType.VintasoftBarcodeField:
                            AddAndBuildVintasoftBarcodeField(parentInteractiveFormField);
                            break;

                        case InteractiveFormFieldType.SignatureField:
                            AddAndBuildSignatureField(parentInteractiveFormField);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e.Message);
            }
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of AddAndBuildInteractiveFormFieldToolStripButton object.
        /// </summary>
        private void addAndBuildInteractiveFormFieldToolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripItem toolStripItem = (ToolStripItem)sender;

            // get new building interactive form field type
            InteractiveFormFieldType interactiveFormFieldType =
                _toolStripItemToInteractiveFormFieldType[toolStripItem];

            // if clicked on checked tool strip
            if (sender is CheckedToolStripSplitButton)
            {
                CheckedToolStripSplitButton checkedButton =
                    (CheckedToolStripSplitButton)sender;

                // if button is checked
                if (checkedButton.Checked)
                {
                    interactiveFormFieldType = InteractiveFormFieldType.Unknown;
                }
            }
            else
            {
                ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;

                if (toolStripMenuItem != null)
                    toolStripMenuItem.Checked = true;
            }

            // cancel current building
            _annotationTool.CancelBuilding();

            // add and build annotation
            AddAndBuildInteractiveFormField(interactiveFormFieldType);
        }
        
        /// <summary>
        /// Handles the CheckedChanged event of AppearanceToolStripMenuItem object.
        /// </summary>
        private void appearanceToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            // if item is checked
            if (item.Checked)
            {
                // update appearance generator controller
                _annotationAppearanceGeneratorController[item.OwnerItem] = _annotationAppearanceGeneratorController[item];
                // for each tool stip item in items
                foreach (ToolStripItem ownerItem in ((ToolStripSplitButton)item.OwnerItem).DropDownItems)
                {
                    if (ownerItem is ToolStripMenuItem && ownerItem != item)
                        // uncheck tool strip item
                        ((ToolStripMenuItem)ownerItem).Checked = false;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of FieldAppearanceGeneratorPropertiesToolStripMenuItem object.
        /// </summary>
        private void fieldAppearanceGeneratorPropertiesToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            PdfAnnotationAppearanceGenerator appearanceGenerator = _annotationAppearanceGeneratorController[item.OwnerItem];
            // create property grid form
            using (PropertyGridForm properties = new PropertyGridForm(appearanceGenerator, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_APPERANACE_GENERATOR_PROPERTIES))
            {
                // show dialog
                properties.ShowDialog();

                // if interactive form field must be build
                if (_lastBuiltInteractiveFormFieldType != InteractiveFormFieldType.Unknown)
                {
                    InteractiveFormFieldType interactiveFormFieldType = _lastBuiltInteractiveFormFieldType;
                    PdfInteractiveFormField interactiveFormFieldParent = _lastBuiltInteractiveFormFieldParent;

                    // cancel building
                    AnnotationTool.CancelBuilding();
                    // build current interactive form field
                    AddAndBuildInteractiveFormField(interactiveFormFieldType, interactiveFormFieldParent);
                }
            }
        }

        #endregion


        #region Interactive form field buttons

        /// <summary>
        /// Initializes the interactive form field buttons.
        /// </summary>
        private void InitializeInteractiveFormFieldButtons()
        {
            InitializeInteractiveFormFieldButton(textFieldToolStripSplitButton, "TextField", InteractiveFormFieldType.TextField);
            InitializeInteractiveFormFieldButton(textFieldNoBorderToolStripMenuItem, null, InteractiveFormFieldType.TextField);
            InitializeInteractiveFormFieldButton(textFieldSingleBorderToolStripMenuItem, null, InteractiveFormFieldType.TextField);
            InitializeInteractiveFormFieldButton(textField3DBorderToolStripMenuItem, null, InteractiveFormFieldType.TextField);


            InitializeInteractiveFormFieldButton(checkBoxToolStripSplitButton, "CheckBoxField", InteractiveFormFieldType.CheckBox);
            InitializeInteractiveFormFieldButton(checkBoxStandardToolStripMenuItem, null, InteractiveFormFieldType.CheckBox);
            InitializeInteractiveFormFieldButton(checkBoxSimpleToolStripMenuItem, null, InteractiveFormFieldType.CheckBox);
            InitializeInteractiveFormFieldButton(checkBoxSymbolVToolStripMenuItem, null, InteractiveFormFieldType.CheckBox);
            InitializeInteractiveFormFieldButton(checkBoxSymbolXToolStripMenuItem, null, InteractiveFormFieldType.CheckBox);


            InitializeInteractiveFormFieldButton(buttonToolStripSplitButton, "ButtonField", InteractiveFormFieldType.PushButton);
            InitializeInteractiveFormFieldButton(buttonFlatBorderToolStripMenuItem, null, InteractiveFormFieldType.PushButton);
            InitializeInteractiveFormFieldButton(buttonBorder3DToolStripMenuItem, null, InteractiveFormFieldType.PushButton);


            InitializeInteractiveFormFieldButton(listBoxToolStripSplitButton, "ListBoxField", InteractiveFormFieldType.ListBox);
            InitializeInteractiveFormFieldButton(listBoxNoBorderToolStripMenuItem, null, InteractiveFormFieldType.ListBox);


            InitializeInteractiveFormFieldButton(comboBoxToolStripSplitButton, "ComboBoxField", InteractiveFormFieldType.ComboBox);
            InitializeInteractiveFormFieldButton(comboBoxNoBorderToolStripMenuItem, null, InteractiveFormFieldType.ComboBox);
            InitializeInteractiveFormFieldButton(comboBoxSingleBorderToolStripMenuItem, null, InteractiveFormFieldType.ComboBox);
            InitializeInteractiveFormFieldButton(comboBox3dBorderToolStripMenuItem, null, InteractiveFormFieldType.ComboBox);


            InitializeInteractiveFormFieldButton(radioButtonToolStripSplitButton, "RadioButtonField", InteractiveFormFieldType.RadioButton);
            InitializeInteractiveFormFieldButton(radioButtonStandardToolStripMenuItem, null, InteractiveFormFieldType.RadioButton);
            InitializeInteractiveFormFieldButton(radioButtonSymbolToolStripMenuItem, null, InteractiveFormFieldType.RadioButton);


            InitializeInteractiveFormFieldButton(barcodeToolStripSplitButton, "BarcodeField", InteractiveFormFieldType.BarcodeField);
            InitializeInteractiveFormFieldButton(barcodePdf417ToolStripMenuItem, null, InteractiveFormFieldType.BarcodeField);
            InitializeInteractiveFormFieldButton(barcodeDataMatrixToolStripMenuItem, null, InteractiveFormFieldType.BarcodeField);
            InitializeInteractiveFormFieldButton(barcodeQrCodeToolStripMenuItem, null, InteractiveFormFieldType.BarcodeField);
            InitializeInteractiveFormFieldButton(vintasoftBarcodeToolStripMenuItem, null, InteractiveFormFieldType.BarcodeField);


            InitializeInteractiveFormFieldButton(signatureToolStripSplitButton, "SignatureField", InteractiveFormFieldType.SignatureField);
            InitializeInteractiveFormFieldButton(signatureDefaultToolStripMenuItem, null, InteractiveFormFieldType.SignatureField);
        }

        /// <summary>
        /// Initializes the interactive form field button.
        /// </summary>
        /// <param name="interactiveFormFieldButton">A button,
        /// which must be clicked for starting of interactive form field building.</param>
        /// <param name="interactiveFormFieldImageResourceName">Name of the resource,
        /// which stores image for interactive form field button.</param>
        /// <param name="interactiveFormFieldType">The interactive form field type,
        /// which must be built when button is clicked.</param>
        private void InitializeInteractiveFormFieldButton(
            ToolStripItem interactiveFormFieldButton,
            string interactiveFormFieldImageResourceName,
            InteractiveFormFieldType interactiveFormFieldType)
        {
            if (!string.IsNullOrEmpty(interactiveFormFieldImageResourceName))
            {
                string resourceNameFormatString = "DemosCommonCode.Pdf.AnnotationTool.FormFields.Resources.{0}.png";
                interactiveFormFieldButton.Image = DemosResourcesManager.GetResourceAsBitmap(
                    string.Format(resourceNameFormatString, interactiveFormFieldImageResourceName));
            }

            _toolStripItemToInteractiveFormFieldType[interactiveFormFieldButton] = interactiveFormFieldType;
            _interactiveFormFieldTypeToToolStripItem[interactiveFormFieldType] = interactiveFormFieldButton;
        }

        /// <summary>
        /// Sets the selected button of interactive form field.
        /// </summary>
        /// <param name="interactiveFormFieldType">The type of interactive form field.</param>
        private void SetSelectedInteractiveFormFieldButton(InteractiveFormFieldType interactiveFormFieldType)
        {
            CheckedToolStripSplitButton checkedButton = null;

            if (interactiveFormFieldType != InteractiveFormFieldType.Unknown)
            {
                // get the button
                ToolStripItem button =
                    _interactiveFormFieldTypeToToolStripItem[interactiveFormFieldType];
                // get button
                checkedButton = GetCheckedToolStripSplitButton(button);
            }

            // if button is selected
            if (checkedButton == _selectedInteractiveFormFieldButton)
                return;

            // uncheck current button
            if (_selectedInteractiveFormFieldButton != null)
            {
                _selectedInteractiveFormFieldButton.Checked = false;

                AnnotationTool.AllowMultipleSelection = _allowMultipleSelectionPreviousValue;
            }

            // save reference to current button
            _selectedInteractiveFormFieldButton = checkedButton;

            // check specified button
            if (checkedButton != null)
            {
                checkedButton.Checked = true;

                _allowMultipleSelectionPreviousValue = AnnotationTool.AllowMultipleSelection;
                AnnotationTool.AllowMultipleSelection = false;
            }
        }

        /// <summary>
        /// Returns the <see cref="CheckedToolStripSplitButton"/>.
        /// </summary>
        /// <param name="item">The item.</param>
        private CheckedToolStripSplitButton GetCheckedToolStripSplitButton(
            ToolStripItem item)
        {
            if (item == null)
                return null;

            CheckedToolStripSplitButton result = item as CheckedToolStripSplitButton;

            if (result != null)
                return result;

            return GetCheckedToolStripSplitButton(item.OwnerItem);
        }

        /// <summary>
        /// Ends the annotation building.
        /// </summary>
        private void EndBuilding()
        {
            _lastBuiltInteractiveFormFieldType = InteractiveFormFieldType.Unknown;
            _lastBuiltInteractiveFormFieldParent = null;
            SetSelectedInteractiveFormFieldButton(InteractiveFormFieldType.Unknown);

            int count = AnnotationTool.AnnotationViewCollection.Count;
            if (NeedBuildFormFieldsContinuously && count > 0)
            {
                PdfAnnotationView view = AnnotationTool.AnnotationViewCollection[count - 1];

                AnnotationTool.FocusedAnnotationView = view;
            }
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Subscribes to the image viewer events.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void SubscribeToViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged +=
                new EventHandler<FocusedIndexChangedEventArgs>(imageViewer_FocusedIndexChanged);
            imageViewer.VisualToolChanging +=
                new EventHandler<VisualToolChangedEventArgs>(imageViewer_VisualToolChanging);
        }

        /// <summary>
        /// Unsubscribes from the image viewer events.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void UnsubscribeFromViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged -= imageViewer_FocusedIndexChanged;
            imageViewer.VisualToolChanging -= imageViewer_VisualToolChanging;
        }

        /// <summary>
        /// Index, of focused image in viewer, is changing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void imageViewer_FocusedIndexChanging(object sender, FocusedIndexChangedEventArgs e)
        {
            _isFocusedIndexChanging = true;

            if (AnnotationTool != null && NeedBuildFormFieldsContinuously)
            {
                // if focused annotation view is not empty
                if (AnnotationTool.FocusedAnnotationView != null &&
                    IsPdfWidgetAnnotation(AnnotationTool.FocusedAnnotationView))
                {
                    _needContinueBuildFieldsAfterFocusedIndexChanged = true;

                    // cancel building annotation
                    AnnotationTool.CancelBuilding();
                }
            }
        }

        /// <summary>
        /// Index, of focused image in viewer, is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FocusedIndexChangedEventArgs"/> instance containing the event data.</param>
        private void imageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            _isFocusedIndexChanging = false;

            UpdateUI();

            if (_needContinueBuildFieldsAfterFocusedIndexChanged &&
                AnnotationTool.ImageViewer.FocusedIndex != -1)
            {
                AddAndBuildInteractiveFormField(
                    _lastBuiltInteractiveFormFieldType,
                    _lastBuiltInteractiveFormFieldParent);
            }

            _needContinueBuildFieldsAfterFocusedIndexChanged = false;
        }

        /// <summary>
        /// Visual tool of image viewer is changing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisualToolChangedEventArgs"/> instance containing the event data.</param>
        private void imageViewer_VisualToolChanging(object sender, VisualToolChangedEventArgs e)
        {
            if (AnnotationTool != null)
                AnnotationTool.CancelBuilding();
        }

        #endregion


        #region PDF annotation tool

        /// <summary>
        /// Subscribes to the PDF annotation tool events.
        /// </summary>
        /// <param name="annotationTool">The annotation tool.</param>
        private void SubscribeToPdfAnnotationToolEvents(PdfAnnotationTool annotationTool)
        {
            annotationTool.Activating += new EventHandler(pdfAnnotationTool_Activating);
            annotationTool.Activated += new EventHandler(pdfAnnotationTool_Activated);
            annotationTool.Deactivating += new EventHandler(pdfAnnotationTool_Deactivating);
            annotationTool.Deactivated += new EventHandler(pdfAnnotationTool_Deactivated);
            annotationTool.BuildingFinished += new EventHandler<PdfAnnotationViewEventArgs>(pdfAnnotationTool_BuildingFinished);
            annotationTool.BuildingCanceled += new EventHandler<PdfAnnotationViewEventArgs>(pdfAnnotationTool_BuildingCanceled);
        }

        /// <summary>
        /// Unsubscribes from the PDF annotation tool events.
        /// </summary>
        /// <param name="annotationTool">The annotation tool.</param>
        private void UnsubscribeFromPdfAnnotationToolEvents(PdfAnnotationTool annotationTool)
        {
            annotationTool.Activating -= new EventHandler(pdfAnnotationTool_Activating);
            annotationTool.Activated -= new EventHandler(pdfAnnotationTool_Activated);
            annotationTool.Deactivating -= new EventHandler(pdfAnnotationTool_Deactivating);
            annotationTool.Deactivated -= new EventHandler(pdfAnnotationTool_Deactivated);
            annotationTool.BuildingFinished -= new EventHandler<PdfAnnotationViewEventArgs>(pdfAnnotationTool_BuildingFinished);
            annotationTool.BuildingCanceled -= new EventHandler<PdfAnnotationViewEventArgs>(pdfAnnotationTool_BuildingCanceled);
        }

        /// <summary>
        /// PDF annotation tool is activating.
        /// </summary>
        private void pdfAnnotationTool_Activating(object sender, EventArgs e)
        {
            AnnotationTool.ImageViewer.FocusedIndexChanging +=
                new EventHandler<FocusedIndexChangedEventArgs>(imageViewer_FocusedIndexChanging);
        }

        /// <summary>
        /// PDF annotation tool is activated.
        /// </summary>
        private void pdfAnnotationTool_Activated(object sender, EventArgs e)
        {
            SubscribeToViewerEvents(AnnotationTool.ImageViewer);
            UpdateUI();
        }

        /// <summary>
        /// PDF annotation tool is deactivating.
        /// </summary>
        private void pdfAnnotationTool_Deactivating(object sender, EventArgs e)
        {
            AnnotationTool.ImageViewer.FocusedIndexChanging -= imageViewer_FocusedIndexChanging;
        }

        /// <summary>
        /// PDF annotation tool is deactivated.
        /// </summary>
        private void pdfAnnotationTool_Deactivated(object sender, EventArgs e)
        {
            UnsubscribeFromViewerEvents(AnnotationTool.ImageViewer);

            mainToolStrip.Enabled = false;
        }

        /// <summary>
        /// The interactive form field building is finished.
        /// </summary>
        private void pdfAnnotationTool_BuildingFinished(object sender, PdfAnnotationViewEventArgs e)
        {
            if (!AnnotationTool.AnnotationCollection.Contains(e.AnnotationView.Annotation))
                return;

            if (e.AnnotationView is PdfSignatureWidgetAnnotationView)
            {
                ShowSignatureDialog((PdfSignatureWidgetAnnotationView)e.AnnotationView);
            }
            else if (e.AnnotationView is PdfPushButtonWidgetAnnotationView)
            {
                PdfAction activateAction = CreatePdfActionForm.CreateAction(e.AnnotationView.Annotation.Document, null);
                if (activateAction != null)
                {
                    if (PdfActionsEditorTool.EditAction(activateAction, AnnotationTool.ImageViewer.Images, null))
                        e.AnnotationView.Annotation.ActivateAction = activateAction;
                }
            }

            if (IsPdfWidgetAnnotation(e.AnnotationView))
            {
                if (NeedBuildFormFieldsContinuously)
                {
                    AddAndBuildInteractiveFormField(
                        _lastBuiltInteractiveFormFieldType,
                        _lastBuiltInteractiveFormFieldParent);
                }
                else
                {
                    EndBuilding();
                }
            }
        }

        /// <summary>
        /// The annotation building is canceled.
        /// </summary>
        private void pdfAnnotationTool_BuildingCanceled(object sender, PdfAnnotationViewEventArgs e)
        {
            if (!_isFocusedIndexChanging &&
                !_isInteractionModeChanging)
                EndBuilding();
        }

        #endregion


        #region Add And Build...

        /// <summary>
        /// Adds and builds a text field.
        /// </summary>
        /// <param name="parentField">The parent field.</param>
        private void AddAndBuildTextField(PdfInteractiveFormField parentField)
        {
            PdfInteractiveFormTextField field = new PdfInteractiveFormTextField(
                CurrentDocument,
                GetFieldName(parentField, "TextField{0}"),
                GetNewFieldRectangle(textFieldToolStripSplitButton));

            AddAndBuildTerminalField(field, GetAppearanceGenerator(textFieldToolStripSplitButton), parentField);
        }

        /// <summary>
        /// Adds and builds a check box field.
        /// </summary>
        /// <param name="parentField">The parent field.</param>
        private void AddAndBuildCheckBoxField(PdfInteractiveFormField parentField)
        {
            PdfInteractiveFormCheckBoxField field = new PdfInteractiveFormCheckBoxField(
                CurrentDocument,
                GetFieldName(parentField, "CheckBox{0}"),
                GetNewFieldRectangle(checkBoxToolStripSplitButton));

            // set value and default value
            field.Value = "Off";
            field.DefaultValue = field.Value;

            AddAndBuildTerminalField(field, GetAppearanceGenerator(checkBoxToolStripSplitButton), parentField);
        }

        /// <summary>
        /// Adds and builds a button field.
        /// </summary>
        /// <param name="parentField">The parent field.</param>
        private void AddAndBuildButtonField(PdfInteractiveFormField parentField)
        {
            PdfInteractiveFormPushButtonField field = new PdfInteractiveFormPushButtonField(
                CurrentDocument,
                GetFieldName(parentField, "Button{0}"),
                GetNewFieldRectangle(buttonToolStripSplitButton));

            AddAndBuildTerminalField(field, GetAppearanceGenerator(buttonToolStripSplitButton), parentField);
        }

        /// <summary>
        /// Adds and builds a list box field.
        /// </summary>
        /// <param name="parentField">The parent field.</param>
        private void AddAndBuildListBoxField(PdfInteractiveFormField parentField)
        {
            PdfInteractiveFormListBoxField field = new PdfInteractiveFormListBoxField(
                CurrentDocument,
                GetFieldName(parentField, "ListBox{0}"),
                GetNewFieldRectangle(listBoxToolStripSplitButton));

            AddAndBuildTerminalField(field, GetAppearanceGenerator(listBoxToolStripSplitButton), parentField);
        }

        /// <summary>
        /// Adds and builds a combo box field.
        /// </summary>
        /// <param name="parentField">The parent field.</param>
        private void AddAndBuildComboBoxField(PdfInteractiveFormField parentField)
        {
            PdfInteractiveFormComboBoxField field = new PdfInteractiveFormComboBoxField(
                CurrentDocument,
                GetFieldName(parentField, "ComboBox{0}"),
                GetNewFieldRectangle(comboBoxToolStripSplitButton));
            field.IsEdit = true;

            AddAndBuildTerminalField(field, GetAppearanceGenerator(comboBoxToolStripSplitButton), parentField);
        }

        /// <summary>
        /// Adds and builds a radio button field.
        /// </summary>
        /// <param name="parentField">The parent field.</param>
        private void AddAndBuildRadioButtonField(PdfInteractiveFormField parentField)
        {
            PdfDocument document = CurrentDocument;
            PdfInteractiveFormRadioButtonGroupField parentRadioGroup = null;
            if (AddRadioButtonToFocusedGroup)
                parentRadioGroup = parentField as PdfInteractiveFormRadioButtonGroupField;

            if (parentRadioGroup == null)
            {
                PdfAnnotationView view = AnnotationTool.FocusedAnnotationView;
                if (AddRadioButtonToFocusedGroup && view != null && view.Figure is PdfWidgetAnnotationGraphicsFigure)
                {
                    PdfInteractiveFormRadioButtonField radioButtonField =
                        ((PdfWidgetAnnotationGraphicsFigure)view.Figure).Field as PdfInteractiveFormRadioButtonField;
                    if (radioButtonField != null)
                    {
                        parentRadioGroup = radioButtonField.Parent as PdfInteractiveFormRadioButtonGroupField;
                        parentField = parentRadioGroup;
                    }
                }

                if (parentRadioGroup == null)
                {
                    parentRadioGroup = new PdfInteractiveFormRadioButtonGroupField(
                       CurrentDocument, GetFieldName(parentField, "RadioGroup{0}"));
                    if (parentField != null)
                    {
                        parentField.Kids.Add(parentRadioGroup);
                    }
                    else
                    {
                        if (document.InteractiveForm == null)
                            document.InteractiveForm = new PdfDocumentInteractiveForm(document);
                        document.InteractiveForm.Fields.Add(parentRadioGroup);
                    }
                    parentField = parentRadioGroup;
                }
            }

            PdfInteractiveFormRadioButtonField field = new PdfInteractiveFormRadioButtonField(
                document,
                GetNewFieldRectangle(radioButtonToolStripSplitButton));

            field.ButtonValue = GetFreeName(parentRadioGroup.GetButtonValues(), "Value{0}");

            AddAndBuildTerminalField(field, GetAppearanceGenerator(radioButtonToolStripSplitButton), parentField);
        }

        /// <summary>
        /// Adds and builds a barcode field.
        /// </summary>
        /// <param name="parentField">The parent field.</param>
        private void AddAndBuildBarcodeField(PdfInteractiveFormField parentField)
        {
            if (GetAppearanceGenerator(barcodeToolStripSplitButton) is PdfVintasoftBarcodeFieldAppearanceGenerator)
            {
                AddAndBuildVintasoftBarcodeField(parentField);
                return;
            }

            PdfBarcodeFieldAppearanceGenerator generator = (PdfBarcodeFieldAppearanceGenerator)GetAppearanceGenerator(barcodeToolStripSplitButton);

            PdfInteractiveFormBarcodeField field = new PdfInteractiveFormBarcodeField(
                CurrentDocument,
                GetFieldName(parentField, "Barcode{0}"),
                generator.BarcodeSymbology,
                GetNewFieldRectangle(barcodeToolStripSplitButton));
            field.TextValue = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_BARCODE_VALUE;

            AddAndBuildTerminalField(field, generator, parentField);
        }

        /// <summary>
        /// Adds and builds a Vintasoft barcode field.
        /// </summary>
        /// <param name="parentField">The parent field.</param>
        private void AddAndBuildVintasoftBarcodeField(PdfInteractiveFormField parentField)
        {
            PdfVintasoftBarcodeFieldAppearanceGenerator generator = (PdfVintasoftBarcodeFieldAppearanceGenerator)GetAppearanceGenerator(vintasoftBarcodeToolStripMenuItem);

            PdfInteractiveFormVintasoftBarcodeField field = new PdfInteractiveFormVintasoftBarcodeField(
                CurrentDocument,
                GetFieldName(parentField, "Barcode{0}"),
                generator.BarcodeSymbology,
                GetNewFieldRectangle(barcodeToolStripSplitButton));
            field.TextValue = "123456789";

            AddAndBuildTerminalField(field, generator, parentField);
        }

        /// <summary>
        /// Adds and builds a signature field.
        /// </summary>
        /// <param name="parentField">The parent field.</param>
        private void AddAndBuildSignatureField(PdfInteractiveFormField parentField)
        {
            SignatureAppearanceGenerator generator = (SignatureAppearanceGenerator)GetAppearanceGenerator(signatureToolStripSplitButton);
            generator.SignatureAppearance.Text = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_EMPTY_SIGNATRUE_FIELD;

            PdfInteractiveFormSignatureField field = new PdfInteractiveFormSignatureField(
                CurrentDocument,
                GetFieldName(parentField, "Signature{0}"),
                GetNewFieldRectangle(signatureToolStripSplitButton));

            AddAndBuildTerminalField(field, generator, parentField);
        }


        /// <summary>
        /// Adds and builds a terminal field.
        /// </summary>
        /// <param name="field">The PDF interactive form field.</param>
        /// <param name="appearanceGenerator">The PDF annotation appearance generator.</param>
        /// <param name="parentField">The parent PDF interactive form field.</param>
        private void AddAndBuildTerminalField(
            PdfInteractiveFormField field,
            PdfAnnotationAppearanceGenerator appearanceGenerator,
            PdfInteractiveFormField parentField)
        {
            if (!AnnotationTool.ImageViewer.Focused)
                AnnotationTool.ImageViewer.Focus();

            // update field appearance
            if (appearanceGenerator != null)
                field.Annotation.AppearanceGenerator = appearanceGenerator.Clone();
            field.Annotation.UpdateAppearance();

            // add and build the widget annotation of form field
            AnnotationTool.AddAndBuildFormField(field, parentField);
        }

        #endregion


        /// <summary>
        /// Initializes the controller of PDF annotation appearance generators.
        /// </summary>
        /// <param name="controller">The controller.</param>
        private void InitAnnotationAppearanceGeneratorController(
            PdfAnnotationAppearanceGeneratorController controller)
        {
            textFieldNoBorderToolStripMenuItem.Checked = false;
            checkBoxStandardToolStripMenuItem.Checked = false;
            buttonBorder3DToolStripMenuItem.Checked = false;
            listBoxNoBorderToolStripMenuItem.Checked = false;
            comboBoxNoBorderToolStripMenuItem.Checked = false;
            radioButtonStandardToolStripMenuItem.Checked = false;
            barcodePdf417ToolStripMenuItem.Checked = false;
            signatureDefaultToolStripMenuItem.Checked = false;

            // Text Field -> No Border
            controller.SetAppearanceGenerator(textFieldNoBorderToolStripMenuItem,
                new PdfTextBoxFieldAppearanceGenerator());

            // Text Field -> Single Border
            controller.SetAppearanceGenerator(textFieldSingleBorderToolStripMenuItem,
                new PdfTextBoxSingleBorderFieldAppearanceGenerator());

            // Text Field -> 3D Border
            controller.SetAppearanceGenerator(textField3DBorderToolStripMenuItem,
                new PdfTextBoxBorder3DFieldAppearanceGenerator());

            // Check Box -> Satandard
            controller.SetAppearanceGenerator(checkBoxStandardToolStripMenuItem,
                new PdfCheckBoxFieldDynamicAppearanceGenerator(13));

            // Check Box -> Simple
            controller.SetAppearanceGenerator(checkBoxSimpleToolStripMenuItem,
                new PdfCheckBoxSimpleFieldAppearanceGenerator(13, 13));

            // Check Box -> Symbol "V"
            controller.SetAppearanceGenerator(checkBoxSymbolVToolStripMenuItem,
                new PdfCheckBoxSymbolFieldAppearanceGenerator(13, "4", ""));

            // Check Box -> Symbol "X"
            controller.SetAppearanceGenerator(checkBoxSymbolXToolStripMenuItem,
                new PdfCheckBoxSymbolFieldAppearanceGenerator(13, "8", ""));

            // Button -> Flat Border
            controller.SetAppearanceGenerator(buttonFlatBorderToolStripMenuItem,
                new PdfButtonFlatBorderFieldAppearanceGenerator());

            // Button -> 3D Border
            controller.SetAppearanceGenerator(buttonBorder3DToolStripMenuItem,
                new PdfButton3DBorderFieldAppearanceGenerator());

            // List Box -> No Border
            controller.SetAppearanceGenerator(listBoxNoBorderToolStripMenuItem,
                new PdfListBoxFieldAppearanceGenerator());

            // Combo Box -> No Border
            controller.SetAppearanceGenerator(comboBoxNoBorderToolStripMenuItem,
                new PdfComboBoxFieldAppearanceGenerator());

            // Combo Box  -> Single Border
            controller.SetAppearanceGenerator(comboBoxSingleBorderToolStripMenuItem,
                new PdfComboBoxSingleBorderFieldAppearanceGenerator());

            // Combo Box  -> 3D Border
            controller.SetAppearanceGenerator(comboBox3dBorderToolStripMenuItem,
                new PdfComboBox3DFieldAppearanceGenerator());

            // Radio Button -> Standard
            controller.SetAppearanceGenerator(radioButtonStandardToolStripMenuItem,
                new PdfRadioButtonFieldDynamicAppearanceGenerator(13));

            // Radio Button -> Symbol
            controller.SetAppearanceGenerator(radioButtonSymbolToolStripMenuItem,
                new PdfRadioButtonSymbolFieldAppearanceGenerator(13, "l", "m"));

            // Barcode -> PDF417
            controller.SetAppearanceGenerator(barcodePdf417ToolStripMenuItem,
                new PdfPDF417BarcodeFieldAppearanceGenerator());

            // Barcode -> DataMatrix
            controller.SetAppearanceGenerator(barcodeDataMatrixToolStripMenuItem,
                new PdfDataMatrixBarcodeFieldAppearanceGenerator());

            // Barcode -> QR Code
            controller.SetAppearanceGenerator(barcodeQrCodeToolStripMenuItem,
                new PdfQrBarcodeFieldAppearanceGenerator());

            // Barcode -> Vintasoft Barcode
            controller.SetAppearanceGenerator(vintasoftBarcodeToolStripMenuItem,
                new PdfVintasoftBarcodeFieldAppearanceGenerator());

            // Digital Signature -> Default
            SignatureAppearanceGenerator signatureAppearanceGenerator = new SignatureAppearanceGenerator();
            controller.SetAppearanceGenerator(signatureDefaultToolStripMenuItem,
                signatureAppearanceGenerator);
            SignatureAppearance = new SignatureAppearanceGraphicsFigure();

            textFieldNoBorderToolStripMenuItem.Checked = true;
            checkBoxStandardToolStripMenuItem.Checked = true;
            buttonBorder3DToolStripMenuItem.Checked = true;
            listBoxNoBorderToolStripMenuItem.Checked = true;
            comboBoxNoBorderToolStripMenuItem.Checked = true;
            radioButtonStandardToolStripMenuItem.Checked = true;
            barcodePdf417ToolStripMenuItem.Checked = true;
            signatureDefaultToolStripMenuItem.Checked = true;
        }

        /// <summary>
        /// Determines whether the specified view is widget annotation.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns>
        /// <b>true</b> if the annotation view is widget annotation; otherwise, <b>false</b>.
        /// </returns>
        private bool IsPdfWidgetAnnotation(PdfAnnotationView view)
        {
            if (view is PdfWidgetAnnotationView)
                return true;

            return false;
        }

        /// <summary>
        /// Returns the name of new field.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="nameFormat">The name format.</param>
        /// <returns>The name of new field.</returns>
        private string GetFieldName(PdfInteractiveFormField parent, string nameFormat)
        {
            string format = nameFormat;
            if (parent != null)
                format = string.Format("{0}.{1}", parent.FullyQualifiedName, nameFormat);
            PdfDocument document = CurrentDocument;
            if (document.InteractiveForm == null)
                return string.Format(nameFormat, 1);
            int i = 1;
            while (document.InteractiveForm.FindField(string.Format(format, i)) != null)
                i++;
            return string.Format(nameFormat, i);
        }

        /// <summary>
        /// Returns a rectangle for new field.
        /// </summary>
        /// <param name="appearanceGeneratorKey">The appearance generator key (button).</param>
        /// <returns>A rectangle for new field.</returns>
        private RectangleF GetNewFieldRectangle(object appearanceGeneratorKey)
        {
            if (_annotationAppearanceGeneratorController.ContainsKey(appearanceGeneratorKey))
            {
                RectangleF rect = _annotationAppearanceGeneratorController[appearanceGeneratorKey].GetDefaultAnnotationRectangle();
                return PdfAnnotationsTools.GetNewAnnotationRectangle(AnnotationTool, _visualToolMouseObserver, rect.Width, rect.Height);
            }
            return PdfAnnotationsTools.GetNewAnnotationRectangle(AnnotationTool, _visualToolMouseObserver, 20, 20);
        }

        /// <summary>
        /// Returns the PDF annotation appearance generator for
        /// the specified appearance generator key (button).
        /// </summary>
        /// <param name="appearanceGeneratorKey">The appearance generator key (button).</param>
        /// <returns>The PDF annotation appearance generator.</returns>
        private PdfAnnotationAppearanceGenerator GetAppearanceGenerator(
            object appearanceGeneratorKey)
        {
            PdfAnnotationAppearanceGenerator result = null;
            if (_annotationAppearanceGeneratorController.TryGetValue(appearanceGeneratorKey, out result))
                return result;
            return null;
        }

        /// <summary>
        /// Returns the free field name.
        /// </summary>
        /// <param name="names">An array with existing name.</param>
        /// <param name="nameFormat">The name format.</param>
        /// <returns>The free field name.</returns>
        private string GetFreeName(string[] names, string nameFormat)
        {
            int i = 1;
            if (names != null && names.Length > 0)
            {
                while (Array.IndexOf(names, string.Format(nameFormat, i)) >= 0)
                    i++;
            }
            return string.Format(nameFormat, i);
        }

        #endregion

        #endregion

    }
}
