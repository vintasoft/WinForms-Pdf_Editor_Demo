using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms.AppearanceGenerators;
using Vintasoft.Imaging.Pdf.UI.Annotations;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A form that allows to edit properties of annotations.
    /// </summary>
    public partial class PdfAnnotationPropertiesForm : Form
    {

        #region Fields

        /// <summary>
        /// The PDF interactive form field.
        /// </summary>
        PdfInteractiveFormField _field;

        /// <summary>
        /// The PDF annotation.
        /// </summary>
        PdfAnnotation _annotation;

        /// <summary>
        /// The view of PDF annotation.
        /// </summary>
        PdfAnnotationView _annotationView;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAnnotationPropertiesForm"/> class.
        /// </summary>
        public PdfAnnotationPropertiesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAnnotationPropertiesForm"/> class.
        /// </summary>
        /// <param name="field">The PDF interactive form field.</param>
        public PdfAnnotationPropertiesForm(PdfInteractiveFormField field)
            : this()
        {
            _field = field;
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAnnotationPropertiesForm"/> class.
        /// </summary>
        /// <param name="annotationView">The PDF annotation view.</param>
        public PdfAnnotationPropertiesForm(PdfAnnotationView annotationView)
            : this()
        {
            _annotationView = annotationView;
            _annotation = annotationView.Annotation;
            if (_annotationView.Figure is PdfWidgetAnnotationGraphicsFigure)
                _field = ((PdfWidgetAnnotationGraphicsFigure)_annotationView.Figure).Field;

            Init();
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAnnotationPropertiesForm"/> class.
        /// </summary>
        /// <param name="annotation">The PDF annotation.</param>
        public PdfAnnotationPropertiesForm(PdfAnnotation annotation)
            : this()
        {
            _annotation = annotation;

            Init();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the appearance generator of PDF annotation.
        /// </summary>
        private PdfAnnotationAppearanceGenerator AppearanceGenerator
        {
            get
            {
                if (_annotationView != null && _field != null)
                    return _annotation.AppearanceGenerator;

                return null;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates the appearance of PDF annotation view.
        /// </summary>
        /// <param name="annotationView">The PDF annotation view.</param>
        /// <param name="loadAppearancePropertiesFromAnnotation">
        /// Determines that the appearance generator must load the appearance properties
        /// from annotation.</param>
        public void UpdateAppearance(
            PdfAnnotationView annotationView,
            bool loadAppearancePropertiesFromAnnotation)
        {
            // if annotation view is NOT empty
            if (annotationView != null)
            {
                // get annotation
                PdfAnnotation annotation = annotationView.Annotation;


                // if annotation has appearance generator
                if (AppearanceGenerator != null)
                {
                    // if need load appearance properties to appearance generator
                    if (loadAppearancePropertiesFromAnnotation)
                        AppearanceGenerator.LoadPropertiesFromAnnotation(annotation);

                    // update the annotation appearance
                    AppearanceGenerator.SetAppearance(annotation);
                }

                // if annotation view must be refreshed
                if (refreshAnnotationCheckBox.Checked)
                {
                    if (annotationView.PointsEditor != null)
                        annotationView.PointsEditor.RefreshFigure();
                }

                // if annotation appearance must be updated
                if (updateAnnotationAppearanceCheckBox.Checked)
                    ((PdfAnnotationGraphicsFigure)annotationView.Figure).Update();

                annotationView.Invalidate();
            }
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the PropertyValueChanged event of annotationPropertiesEditorControl object.
        /// </summary>
        private void annotationPropertiesEditorControl_PropertyValueChanged(
            object sender,
            EventArgs e)
        {
            PdfRectangularAnnotation rectangularAnnotation = _annotationView.Annotation as PdfRectangularAnnotation;
            // if rectangular annotation is selected
            if (rectangularAnnotation != null && customPropertiesGroupBox.Controls.Count > 0)
            {
                PdfRectangularAnnotationPropertiesEditorControl rectangularAnnotationControl =
                    customPropertiesGroupBox.Controls[0] as PdfRectangularAnnotationPropertiesEditorControl;
                // if padding must be updated automatically
                if (rectangularAnnotationControl != null &&
                    rectangularAnnotationControl.AutoUpdatePadding)
                {
                    // get appearance generator
                    PdfRectangularAnnotationAppearanceGenerator appearanceGenerator =
                    rectangularAnnotation.AppearanceGenerator as PdfRectangularAnnotationAppearanceGenerator;

                    // get annotation padding
                    Vintasoft.Imaging.PaddingF padding = appearanceGenerator.GetRequiredPadding(rectangularAnnotation);
                    // update padding
                    rectangularAnnotation.Padding = padding;

                    // update user interface with annotation information
                    rectangularAnnotationControl.UpdateAnnotationInfo();
                }
            }

            UpdateAppearance(_annotationView, true);
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of fieldPropertiesEditorControl object.
        /// </summary>
        private void fieldPropertiesEditorControl_PropertyValueChanged(object sender, EventArgs e)
        {
            // update annotation appearance
            UpdateAppearance(_annotationView, true);

            // if field information must be updated
            if (sender is PdfTextFieldPropertiesEditorControl)
            {
                PdfInteractiveFormCommonPropertiesEditorControl interactiveFormCommonPropertiesEditorControl =
                            commonPropertiesGroupBox.Controls[0] as PdfInteractiveFormCommonPropertiesEditorControl;
                if (interactiveFormCommonPropertiesEditorControl != null)
                    interactiveFormCommonPropertiesEditorControl.UpdateFieldInfo();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of mainTabControl object.
        /// </summary>
        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if properties tab page is selected
            if (mainTabControl.SelectedTab == propertiesTabPage)
            {
                // if common properties group box must be updated
                if (commonPropertiesGroupBox.Controls.Count == 1)
                {
                    PdfInteractiveFormCommonPropertiesEditorControl interactiveFormCommonPropertiesEditorControl =
                        commonPropertiesGroupBox.Controls[0] as PdfInteractiveFormCommonPropertiesEditorControl;
                    if (interactiveFormCommonPropertiesEditorControl != null)
                        interactiveFormCommonPropertiesEditorControl.UpdateFieldInfo();

                    PdfAnnotationCommonPropertiesEditorControl annotationCommonPropertiesEditorControl =
                        commonPropertiesGroupBox.Controls[0] as PdfAnnotationCommonPropertiesEditorControl;
                    if (annotationCommonPropertiesEditorControl != null)
                        annotationCommonPropertiesEditorControl.UpdateAnnotationInfo();
                }

                // if custom properties group box must be updated
                if (customPropertiesGroupBox.Controls.Count == 1)
                {
                    Control control = customPropertiesGroupBox.Controls[0];

                    if (control is IPdfInteractiveFormPropertiesEditor)
                        ((IPdfInteractiveFormPropertiesEditor)control).UpdateFieldInfo();
                    else if (control is IPdfAnnotationPropertiesEditor)
                        ((IPdfAnnotationPropertiesEditor)control).UpdateAnnotationInfo();
                }
            }
            else
            {
                UpdateAdvancedTabPage();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of advancedTabControl object.
        /// </summary>
        private void advancedTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAdvancedTabPage();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of fieldTabControl object.
        /// </summary>
        private void fieldTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFieldTabPage();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of annotationTabControl object.
        /// </summary>
        private void annotationTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAnnotationTabPage();
        }

        /// <summary>
        /// Handles the Click event of closeButton object.
        /// </summary>
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of appearanceGeneratorPropertyGrid object.
        /// </summary>
        private void appearanceGeneratorPropertyGrid_PropertyValueChanged(
            object s,
            PropertyValueChangedEventArgs e)
        {
            UpdateAppearance(_annotationView, false);
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of fieldPropertyGrid object.
        /// </summary>
        private void fieldPropertyGrid_PropertyValueChanged(
            object s,
            PropertyValueChangedEventArgs e)
        {
            UpdateAppearance(_annotationView, true);
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of annotationPropertyGrid object.
        /// </summary>
        private void annotationPropertyGrid_PropertyValueChanged(
            object s,
            PropertyValueChangedEventArgs e)
        {
            UpdateAppearance(_annotationView, true);
        }

        /// <summary>
        /// Handles the Click event of setFontButton object.
        /// </summary>
        private void setFontButton_Click(object sender, EventArgs e)
        {
            if (AppearanceGenerator is PdfWidgetAnnotationAppearanceGenerator)
            {
                // get appearance generator
                PdfWidgetAnnotationAppearanceGenerator appearanceGenerator = AppearanceGenerator as PdfWidgetAnnotationAppearanceGenerator;
                // if appearance generator has font
                if (appearanceGenerator.Font != null)
                {
                    // create a font form
                    using (CreateFontForm createFont = new CreateFontForm(_annotation.Document, appearanceGenerator.Font))
                    {
                        if (createFont.ShowDialog() == DialogResult.OK)
                        {
                            // update font of appearance generator
                            appearanceGenerator.Font = createFont.SelectedFont;
                            appearanceGeneratorPropertyGrid.Refresh();
                            UpdateAppearance(_annotationView, false);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of fieldFontButton object.
        /// </summary>
        private void fieldFontButton_Click(object sender, EventArgs e)
        {
            PdfFont font = null;
            Color textColor;
            float fontSize;
            _field.GetTextDefaultAppearance("", out font, out fontSize, out textColor);
            // create a font form
            using (CreateFontForm createFont = new CreateFontForm(_field.Document, font))
            {
                if (createFont.ShowDialog() == DialogResult.OK)
                {
                    // update font of appearance generator
                    font = createFont.SelectedFont;
                    _field.SetTextDefaultAppearance(font, fontSize, textColor);
                    UpdateAppearance(_annotationView, true);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of annotationFontButton object.
        /// </summary>
        private void annotationFontButton_Click(object sender, EventArgs e)
        {
            PdfFreeTextAnnotation freeText = _annotation as PdfFreeTextAnnotation;
            // if annotation is FreeTextAnnotation
            if (freeText != null)
            {
                // create a font form
                using (CreateFontForm createFont = new CreateFontForm(freeText.Document, freeText.Font))
                {
                    if (createFont.ShowDialog() == DialogResult.OK)
                    {
                        // update font of appearance generator
                        freeText.Font = createFont.SelectedFont;
                        UpdateAppearance(_annotationView, true);
                    }
                }
            }
        }

        #endregion


        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            // if annnotation exists
            if (_annotation != null)
            {
                // set object of property grid
                annotationPropertyGrid.SelectedObject = _annotation;
                // set tree node of triggers editor
                annotationTriggersEditorControl.TreeNode = _annotation;
                // update text of group box
                annotationPropertiesGroupBox.Text = string.Format("{0} (object {1})", _annotation.GetType().Name, _annotation.ObjectNumber);
                annotationFontButton.Enabled = _annotation is PdfFreeTextAnnotation;

                if (_annotation is PdfMarkupAnnotation)
                {
                    // markup annotations is not supports tigger events
                    annotationTabControl.TabPages.Remove(annotationsTriggersTabPage);
                }

                if (!(_annotation is PdfWidgetAnnotation))
                {
                    commonPropertiesGroupBox.Controls.Clear();
                    commonPropertiesGroupBox.Text = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_ANNOTATION_COMMON_PROPERTIES;
                    PdfAnnotationCommonPropertiesEditorControl commonPropertiesEditorControl =
                        new PdfAnnotationCommonPropertiesEditorControl();
                    commonPropertiesEditorControl.Dock = DockStyle.Fill;
                    commonPropertiesEditorControl.Annotation = _annotation;
                    commonPropertiesEditorControl.PropertyValueChanged +=
                        new EventHandler(annotationPropertiesEditorControl_PropertyValueChanged);
                    commonPropertiesGroupBox.Controls.Add(commonPropertiesEditorControl);

                    customPropertiesGroupBox.Controls.Clear();
                    customPropertiesGroupBox.Text = string.Empty;
                    Control annotationPropertiesEditorControl = null;

                    if (_annotation is PdfLineAnnotation)
                    {
                        PdfLineAnnotationPropertiesEditorControl pdfLineAnnotationPropertiesEditorControl =
                            new PdfLineAnnotationPropertiesEditorControl();
                        pdfLineAnnotationPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(annotationPropertiesEditorControl_PropertyValueChanged);
                        annotationPropertiesEditorControl = pdfLineAnnotationPropertiesEditorControl;
                    }
                    else if (_annotation is PdfRectangularAnnotation)
                    {
                        PdfRectangularAnnotationPropertiesEditorControl pdfRectangularAnnotationPropertiesEditorControl =
                            new PdfRectangularAnnotationPropertiesEditorControl();
                        pdfRectangularAnnotationPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(annotationPropertiesEditorControl_PropertyValueChanged);
                        annotationPropertiesEditorControl = pdfRectangularAnnotationPropertiesEditorControl;
                    }
                    else if (_annotation is PdfPolylineAnnotation)
                    {
                        PdfPolylineAnnotationPropertiesEditorControl pdfPolylineAnnotationPropertiesEditorControl =
                            new PdfPolylineAnnotationPropertiesEditorControl();
                        pdfPolylineAnnotationPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(annotationPropertiesEditorControl_PropertyValueChanged);
                        annotationPropertiesEditorControl = pdfPolylineAnnotationPropertiesEditorControl;
                    }
                    else if (_annotation is PdfPolygonalAnnotation)
                    {
                        PdfPolygonalAnnotationPropertiesEditorControl pdfPolygonalAnnotationPropertiesEditorControl =
                            new PdfPolygonalAnnotationPropertiesEditorControl();
                        pdfPolygonalAnnotationPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(annotationPropertiesEditorControl_PropertyValueChanged);
                        annotationPropertiesEditorControl = pdfPolygonalAnnotationPropertiesEditorControl;
                    }
                    else if (_annotation is PdfLinkAnnotation)
                    {
                        PdfLinkAnnotationPropertiesEditorControl pdfLinkAnnotationPropertiesEditorControl =
                            new PdfLinkAnnotationPropertiesEditorControl();
                        pdfLinkAnnotationPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(annotationPropertiesEditorControl_PropertyValueChanged);
                        annotationPropertiesEditorControl = pdfLinkAnnotationPropertiesEditorControl;
                    }
                    else if (_annotation is PdfFreeTextAnnotation)
                    {
                        PdfFreeTextAnnotationPropertiesEditorControl pdfFreeTextAnnotationPropertiesEditorControl =
                            new PdfFreeTextAnnotationPropertiesEditorControl();
                        pdfFreeTextAnnotationPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(annotationPropertiesEditorControl_PropertyValueChanged);
                        annotationPropertiesEditorControl = pdfFreeTextAnnotationPropertiesEditorControl;
                    }
                    else if (_annotation is PdfFileAttachmentAnnotation)
                    {
                        PdfFileAttachmentAnnotationPropertiesEditorControl pdfFileAttachmentAnnotationPropertiesEditorControl =
                            new PdfFileAttachmentAnnotationPropertiesEditorControl();
                        pdfFileAttachmentAnnotationPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(annotationPropertiesEditorControl_PropertyValueChanged);
                        annotationPropertiesEditorControl = pdfFileAttachmentAnnotationPropertiesEditorControl;
                    }

                    if (annotationPropertiesEditorControl != null)
                    {
                        string name = _annotation.GetType().Name;
                        if (name.StartsWith("Pdf") && name.Length > 3)
                            name = name.Substring(3);
                        if (name.EndsWith(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_ANNOTATION) && name.Length > 10)
                            name = name.Substring(0, name.Length - 10);

                        annotationPropertiesEditorControl.Dock = DockStyle.Fill;
                        customPropertiesGroupBox.Controls.Add(annotationPropertiesEditorControl);
                        customPropertiesGroupBox.Text = name;

                        if (annotationPropertiesEditorControl is IPdfAnnotationPropertiesEditor)
                        {
                            IPdfAnnotationPropertiesEditor propertiesEditor =
                                (IPdfAnnotationPropertiesEditor)annotationPropertiesEditorControl;
                            propertiesEditor.Annotation = _annotation;
                        }
                    }
                }
            }
            else
            {
                // remove annotation tab page
                advancedTabControl.TabPages.Remove(annotationTabPage);
            }

            // if field exists
            if (_field != null)
            {
                // set object of property grid
                fieldPropertyGrid.SelectedObject = _field;
                // set tree node of triggers editor
                fieldTriggersEditorControl.TreeNode = _field;
                // update text of group box
                fieldPropertiesGroupBox.Text = string.Format("{0} (object {1})", _field.GetType().Name, _field.ObjectNumber);

                if (_annotation == null || _annotation is PdfWidgetAnnotation)
                {
                    commonPropertiesGroupBox.Controls.Clear();
                    commonPropertiesGroupBox.Text = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_FIELD_COMMON_PROPERTIES;
                    PdfInteractiveFormCommonPropertiesEditorControl commonPropertiesEditorControl =
                        new PdfInteractiveFormCommonPropertiesEditorControl();
                    commonPropertiesEditorControl.Dock = DockStyle.Fill;
                    commonPropertiesEditorControl.Field = _field;
                    commonPropertiesEditorControl.PropertyValueChanged +=
                        new EventHandler(fieldPropertiesEditorControl_PropertyValueChanged);
                    commonPropertiesGroupBox.Controls.Add(commonPropertiesEditorControl);

                    customPropertiesGroupBox.Controls.Clear();
                    customPropertiesGroupBox.Text = string.Empty;
                    Control interactiveFormPropertiesEditorControl = null;

                    if (_field is PdfInteractiveFormComboBoxField)
                    {
                        PdfComboBoxPropertiesEditorControl pdfComboBoxPropertiesEditorControl =
                            new PdfComboBoxPropertiesEditorControl();
                        pdfComboBoxPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(fieldPropertiesEditorControl_PropertyValueChanged);
                        interactiveFormPropertiesEditorControl = pdfComboBoxPropertiesEditorControl;
                    }
                    else if (_field is PdfInteractiveFormListBoxField)
                    {
                        PdfListBoxPropertiesEditorControl pdfListBoxPropertiesEditorControl =
                            new PdfListBoxPropertiesEditorControl();
                        pdfListBoxPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(fieldPropertiesEditorControl_PropertyValueChanged);
                        interactiveFormPropertiesEditorControl = pdfListBoxPropertiesEditorControl;
                    }
                    else if (_field is PdfInteractiveFormVintasoftBarcodeField)
                    {
                        PdfVintasoftBarcodeFieldPropertiesEditorControl pdfVintasoftBarcodeFieldPropertiesEditorControl =
                            new PdfVintasoftBarcodeFieldPropertiesEditorControl();
                        pdfVintasoftBarcodeFieldPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(fieldPropertiesEditorControl_PropertyValueChanged);
                        interactiveFormPropertiesEditorControl = pdfVintasoftBarcodeFieldPropertiesEditorControl;
                    }
                    else if (_field is PdfInteractiveFormBarcodeField)
                    {
                        PdfBarcodeFieldPropertiesEditorControl pdfBarcodeFieldPropertiesEditorControl =
                            new PdfBarcodeFieldPropertiesEditorControl();
                        pdfBarcodeFieldPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(fieldPropertiesEditorControl_PropertyValueChanged);
                        interactiveFormPropertiesEditorControl = pdfBarcodeFieldPropertiesEditorControl;
                    }
                    else if (_field is PdfInteractiveFormTextField)
                    {
                        PdfTextFieldPropertiesEditorControl pdfTextFieldPropertiesEditorControl =
                            new PdfTextFieldPropertiesEditorControl();
                        pdfTextFieldPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(fieldPropertiesEditorControl_PropertyValueChanged);
                        interactiveFormPropertiesEditorControl = pdfTextFieldPropertiesEditorControl;
                    }
                    else if (_field is PdfInteractiveFormCheckBoxField)
                    {
                        PdfCheckBoxPropertiesEditorControl pdfCheckBoxPropertiesEditorControl =
                            new PdfCheckBoxPropertiesEditorControl();
                        pdfCheckBoxPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(fieldPropertiesEditorControl_PropertyValueChanged);
                        interactiveFormPropertiesEditorControl = pdfCheckBoxPropertiesEditorControl;
                    }
                    else if (_field is PdfInteractiveFormRadioButtonField)
                    {
                        PdfRadioButtonPropertiesEditorControl pdfRadioButtonPropertiesEditorControl =
                            new PdfRadioButtonPropertiesEditorControl();
                        pdfRadioButtonPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(fieldPropertiesEditorControl_PropertyValueChanged);
                        interactiveFormPropertiesEditorControl = pdfRadioButtonPropertiesEditorControl;
                    }
                    else if (_field is PdfInteractiveFormButtonField)
                    {
                        PdfPushButtonPropertiesEditorControl pdfPushButtonPropertiesEditorControl =
                            new PdfPushButtonPropertiesEditorControl();
                        pdfPushButtonPropertiesEditorControl.PropertyValueChanged +=
                                new EventHandler(fieldPropertiesEditorControl_PropertyValueChanged);
                        interactiveFormPropertiesEditorControl = pdfPushButtonPropertiesEditorControl;
                    }

                    if (interactiveFormPropertiesEditorControl != null)
                    {
                        if (interactiveFormPropertiesEditorControl is IPdfInteractiveFormPropertiesEditor)
                        {
                            IPdfInteractiveFormPropertiesEditor propertiesEditor =
                                (IPdfInteractiveFormPropertiesEditor)interactiveFormPropertiesEditorControl;
                            propertiesEditor.Field = _field;
                        }

                        string name = _field.GetType().Name;
                        name = name.Replace("PdfInteractiveForm", "");
                        if (name.EndsWith(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_FIELD) && name.Length > 5)
                            name = name.Substring(0, name.Length - 5);

                        customPropertiesGroupBox.Text = name;
                        interactiveFormPropertiesEditorControl.Dock = DockStyle.Fill;
                        customPropertiesGroupBox.Controls.Add(interactiveFormPropertiesEditorControl);
                    }
                }
            }
            else
            {
                // remove field tab page
                advancedTabControl.TabPages.Remove(fieldTabPage);
            }

            // if appearance generator exists
            if (AppearanceGenerator != null)
            {
                // set object of property grid
                appearanceGeneratorPropertyGrid.SelectedObject = AppearanceGenerator;
                // update text of group box
                appearanceGeneratorGroupBox.Text = AppearanceGenerator.GetType().Name;
            }
            else
            {
                // remove field tab page
                advancedTabControl.TabPages.Remove(appearanceGeneratorTabPage);
            }
        }

        /// <summary>
        /// Updates the advanced tab page.
        /// </summary>
        private void UpdateAdvancedTabPage()
        {
            if (advancedTabControl.SelectedTab == fieldTabPage)
            {
                UpdateFieldTabPage();
            }
            else if (advancedTabControl.SelectedTab == annotationTabPage)
            {
                UpdateAnnotationTabPage();
            }
            else if (advancedTabControl.SelectedTab == appearanceGeneratorTabPage)
                appearanceGeneratorPropertyGrid.Refresh();
        }

        /// <summary>
        /// Updates the field tab page.
        /// </summary>
        private void UpdateFieldTabPage()
        {
            if (fieldTabControl.SelectedTab == fieldPropertiesTabPage)
                fieldPropertyGrid.Refresh();
            else
                fieldTriggersEditorControl.UpdateTriggersInfo();
        }

        /// <summary>
        /// Updates the annotation tab page.
        /// </summary>
        private void UpdateAnnotationTabPage()
        {
            if (annotationTabControl.SelectedTab == annotationPropertiesTabPage)
                annotationPropertyGrid.Refresh();
            else
                annotationTriggersEditorControl.UpdateTriggersInfo();
        }

        #endregion

        #endregion

    }
}
