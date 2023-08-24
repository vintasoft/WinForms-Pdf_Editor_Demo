using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of the <see cref="PdfInteractiveFormPushButtonField"/>.
    /// </summary>
    public partial class PdfPushButtonPropertiesEditorControl : UserControl, IPdfInteractiveFormPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfPushButtonPropertiesEditorControl"/> class.
        /// </summary>
        public PdfPushButtonPropertiesEditorControl()
        {
            InitializeComponent();

            foreach (PdfAnnotationHighlightingMode item in Enum.GetValues(typeof(PdfAnnotationHighlightingMode)))
                highlightingModeComboBox.Items.Add(item);

            foreach (PdfAnnotationCaptionIconRelation item in Enum.GetValues(typeof(PdfAnnotationCaptionIconRelation)))
                captionIconRelationComboBox.Items.Add(item);
        }

        #endregion



        #region Properties

        PdfInteractiveFormPushButtonField _field = null;
        /// <summary>
        /// Gets or sets the <see cref="PdfInteractiveFormPushButtonField"/>.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public PdfInteractiveFormPushButtonField Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;

                mainTabControl.Enabled = Field != null && Field.Annotation != null;
                if (mainTabControl.Enabled && AppearanceCharacteristics == null)
                    Field.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(Field.Document);

                UpdateFieldInfo();
            }
        }

        /// <summary>
        /// Gets or sets the PDF interactive form field.
        /// </summary>
        PdfInteractiveFormField IPdfInteractiveFormPropertiesEditor.Field
        {
            get
            {
                return Field;
            }
            set
            {
                Field = value as PdfInteractiveFormPushButtonField;
            }
        }

        /// <summary>
        /// Gets the appearance characteristics of annotation.
        /// </summary>
        private PdfAnnotationAppearanceCharacteristics AppearanceCharacteristics
        {
            get
            {
                return _field.Annotation.AppearanceCharacteristics;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates the field information.
        /// </summary>
        public void UpdateFieldInfo()
        {
            if (Field != null)
                UpdateMainTabContol();
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the SelectedIndexChanged event of MainTabControl object.
        /// </summary>
        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update main tab control
            UpdateMainTabContol();
        }


        /// <summary>
        /// Handles the ActionChanged event of PdfActionEditorControl object.
        /// </summary>
        private void pdfActionEditorControl_ActionChanged(object sender, EventArgs e)
        {
            // update activate action
            Field.Annotation.ActivateAction = pdfActionEditorControl.Action;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of HighlightingModeComboBox object.
        /// </summary>
        private void highlightingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PdfAnnotationHighlightingMode highlightingMode =
                (PdfAnnotationHighlightingMode)highlightingModeComboBox.SelectedItem;
            // if highlight mode is changed
            if (Field.Annotation.HighlightingMode != highlightingMode)
            {
                // update highlight mode
                Field.Annotation.HighlightingMode = highlightingMode;

                // if highlight mide is push
                if (highlightingMode == PdfAnnotationHighlightingMode.Push)
                {
                    // if rollover state tab page must be added
                    if (!buttonStateTabControl.TabPages.Contains(rolloverStateTabPage))
                        // add rollover state tab page
                        buttonStateTabControl.TabPages.Add(rolloverStateTabPage);

                    // if down state tab page must be added
                    if (!buttonStateTabControl.TabPages.Contains(downStateTabPage))
                        // add down state tab page
                        buttonStateTabControl.TabPages.Add(downStateTabPage);
                }
                else
                {
                    // remove rollover state tab page
                    buttonStateTabControl.TabPages.Remove(rolloverStateTabPage);
                    // remove down state tab page
                    buttonStateTabControl.TabPages.Remove(downStateTabPage);
                }

                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of CaptionIconRelationComboBox object.
        /// </summary>
        private void captionIconRelationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PdfAnnotationCaptionIconRelation captionIconRelation =
                (PdfAnnotationCaptionIconRelation)captionIconRelationComboBox.SelectedItem;
            PdfAnnotationAppearanceCharacteristics appearanceCharacteristics =
                Field.Annotation.AppearanceCharacteristics;
            // if button caption icon relation is changed
            if (appearanceCharacteristics.ButtonCaptionIconRelation != captionIconRelation)
            {
                // update button caption icon relation is changed
                appearanceCharacteristics.ButtonCaptionIconRelation = captionIconRelation;


                // update user interface

                normalCaptionTextBox.Enabled = true;
                normalIconChangeButton.Enabled = true;

                bool isIconEnabled = true;
                bool isCaptionEnabled = true;

                if (captionIconRelation == PdfAnnotationCaptionIconRelation.NoCaption)
                    isCaptionEnabled = false;
                else if (captionIconRelation == PdfAnnotationCaptionIconRelation.NoIcon)
                    isIconEnabled = false;

                normalCaptionTextBox.Enabled = isCaptionEnabled;
                rolloverCaptionTextBox.Enabled = isCaptionEnabled;
                downCaptionTextBox.Enabled = isCaptionEnabled;

                normalIconChangeButton.Enabled = isIconEnabled;
                rolloverIconChangeButton.Enabled = isIconEnabled;
                downIconChangeButton.Enabled = isIconEnabled;

                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of ButtonStateTabControl object.
        /// </summary>
        private void buttonStateTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update button state tab control
            UpdateButtonStateTabControl();
        }


        #region Normal State

        /// <summary>
        /// Handles the TextChanged event of NormalCaptionTextBox object.
        /// </summary>
        private void normalCaptionTextBox_TextChanged(object sender, EventArgs e)
        {
            // if button normal caption is changed
            if (AppearanceCharacteristics.ButtonNormalCaption != normalCaptionTextBox.Text)
            {
                // update button normal caption is changed
                AppearanceCharacteristics.ButtonNormalCaption = normalCaptionTextBox.Text;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the Click event of NormalIconChangeButton object.
        /// </summary>
        private void normalIconChangeButton_Click(object sender, EventArgs e)
        {
            PdfFormXObjectResource resource = null;
            // if form XObject resource is received
            if (GetFormXObjectResource(out resource))
            {
                // update button normal icon resource
                AppearanceCharacteristics.ButtonNormalIcon = resource;
                normalIconPdfResourceViewerControl.Resource = resource;
                OnPropertyValueChanged();
            }
        }

        #endregion


        #region Rollover State

        /// <summary>
        /// Handles the TextChanged event of RolloverCaptionTextBox object.
        /// </summary>
        private void rolloverCaptionTextBox_TextChanged(object sender, EventArgs e)
        {
            // update rollover button caption
            AppearanceCharacteristics.ButtonRolloverCaption = rolloverCaptionTextBox.Text;
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the Click event of RolloverIconChangeButton object.
        /// </summary>
        private void rolloverIconChangeButton_Click(object sender, EventArgs e)
        {
            PdfFormXObjectResource resource = null;
            // if form XObject resource is received
            if (GetFormXObjectResource(out resource))
            {
                // update button rollover icon resource
                AppearanceCharacteristics.ButtonRolloverIcon = resource;
                rolloverIconPdfResourceViewerControl.Resource = resource;
                OnPropertyValueChanged();
            }
        }

        #endregion


        #region Down State

        /// <summary>
        /// Handles the TextChanged event of DownCaptionTextBox object.
        /// </summary>
        private void downCaptionTextBox_TextChanged(object sender, EventArgs e)
        {
            // update down button caption
            AppearanceCharacteristics.ButtonDownCaption = downCaptionTextBox.Text;
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the Click event of DownIconChangeButton object.
        /// </summary>
        private void downIconChangeButton_Click(object sender, EventArgs e)
        {
            PdfFormXObjectResource resource = null;
            // if form XObject resource is received
            if (GetFormXObjectResource(out resource))
            {
                // update button down icon resource
                AppearanceCharacteristics.ButtonDownIcon = resource;
                downIconPdfResourceViewerControl.Resource = resource;
                OnPropertyValueChanged();
            }
        }

        #endregion

        #endregion


        /// <summary>
        /// Updates the main tab contol.
        /// </summary>
        private void UpdateMainTabContol()
        {
            if (mainTabControl.SelectedTab == valueTabPage)
            {
                highlightingModeComboBox.SelectedItem = Field.Annotation.HighlightingMode;
                captionIconRelationComboBox.SelectedItem = AppearanceCharacteristics.ButtonCaptionIconRelation;

                UpdateButtonStateTabControl();
            }
            else if (mainTabControl.SelectedTab == activateActionTabPage)
            {
                if (pdfActionEditorControl.Document == null)
                    pdfActionEditorControl.Document = Field.Document;
                pdfActionEditorControl.Action = Field.Annotation.ActivateAction;
            }
        }

        /// <summary>
        /// Updates the button state tab control.
        /// </summary>
        private void UpdateButtonStateTabControl()
        {
            TabPage selectedTab = buttonStateTabControl.SelectedTab;

            if (selectedTab == normalStateTabPage)
            {
                normalIconPdfResourceViewerControl.Resource = AppearanceCharacteristics.ButtonNormalIcon;
                normalCaptionTextBox.Text = AppearanceCharacteristics.ButtonNormalCaption;
            }
            else if (selectedTab == rolloverStateTabPage)
            {
                rolloverIconPdfResourceViewerControl.Resource = AppearanceCharacteristics.ButtonRolloverIcon;
                rolloverCaptionTextBox.Text = AppearanceCharacteristics.ButtonRolloverCaption;
            }
            else if (selectedTab == downStateTabPage)
            {
                downIconPdfResourceViewerControl.Resource = AppearanceCharacteristics.ButtonDownIcon;
                downCaptionTextBox.Text = AppearanceCharacteristics.ButtonDownCaption;
            }
        }

        /// <summary>
        /// Creates PdfFormXObjectResource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        private bool GetFormXObjectResource(out PdfFormXObjectResource resource)
        {
            resource = null;

            using (PdfResourcesViewerForm dialog = new PdfResourcesViewerForm(Field.Document, true))
            {
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Owner = this.ParentForm;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (dialog.SelectedResource is PdfFormXObjectResource)
                        resource = (PdfFormXObjectResource)dialog.SelectedResource;
                    else if (dialog.SelectedResource is PdfImageResource)
                    {
                        PdfImageResource imageResource = (PdfImageResource)dialog.SelectedResource;
                        resource = new PdfFormXObjectResource(Field.Document, imageResource);
                    }
                }
            }

            return resource != null;
        }

        /// <summary>
        /// Raises the PropertyValueChanged event.
        /// </summary>
        private void OnPropertyValueChanged()
        {
            if (PropertyValueChanged != null)
                PropertyValueChanged(this, EventArgs.Empty);
        }

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when value of property is changed.
        /// </summary>
        public event EventHandler PropertyValueChanged;

        #endregion

    }
}
