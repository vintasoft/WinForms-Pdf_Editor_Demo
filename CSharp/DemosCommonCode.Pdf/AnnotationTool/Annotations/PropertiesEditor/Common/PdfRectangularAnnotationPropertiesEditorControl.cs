using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.Annotations;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of
    /// the <see cref="PdfRectangularAnnotation"/>.
    /// </summary>
    public partial class PdfRectangularAnnotationPropertiesEditorControl : UserControl, IPdfAnnotationPropertiesEditor
    {

        #region Fields

        /// <summary>
        /// The value indicating whether the padding must be updated automatically.
        /// </summary>
        private static bool _autoUpdatePadding = true;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfRectangularAnnotationPropertiesEditorControl"/> class.
        /// </summary>
        public PdfRectangularAnnotationPropertiesEditorControl()
        {
            InitializeComponent();

            autoUpdatePaddingCheckBox.Checked = _autoUpdatePadding;
        }

        #endregion



        #region Properties

        PdfRectangularAnnotation _annotation;
        /// <summary>
        /// Gets or sets the annotation.
        /// </summary>
        public PdfRectangularAnnotation Annotation
        {
            get
            {
                return _annotation;
            }
            set
            {
                _annotation = value;

                pdfAnnotationBorderEffectEditorControl1.Annotation = value;
                mainPanel.Enabled = _annotation != null;

                UpdateAnnotationInfo();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the padding must be updated automatically.
        /// </summary>
        public bool AutoUpdatePadding
        {
            get
            {
                return autoUpdatePaddingCheckBox.Checked;
            }
        }

        /// <summary>
        /// Gets or sets the annotation.
        /// </summary>
        PdfAnnotation IPdfAnnotationPropertiesEditor.Annotation
        {
            get
            {
                return Annotation;
            }
            set
            {
                Annotation = value as PdfRectangularAnnotation;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates the information about annotation.
        /// </summary>
        public void UpdateAnnotationInfo()
        {
            if (_annotation == null)
                return;

            interiorColorPanelControl.Color = _annotation.InteriorColor;
            paddingPanelControl1.PaddingValue = _annotation.Padding;

            pdfAnnotationBorderEffectEditorControl1.UpdateAnnotationInfo();
        } 

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the ColorChanged event of interiorColorPanelControl object.
        /// </summary>
        private void interiorColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            // update annotation interior color
            _annotation.InteriorColor = interiorColorPanelControl.Color;
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the PaddingValueChanged event of paddingPanelControl1 object.
        /// </summary>
        private void paddingPanelControl1_PaddingValueChanged(object sender, EventArgs e)
        {
            // update annotation padding
            _annotation.Padding = paddingPanelControl1.PaddingValue;
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of pdfAnnotationBorderEffectEditorControl1 object.
        /// </summary>
        private void pdfAnnotationBorderEffectEditorControl1_PropertyValueChanged(
            object sender,
            EventArgs e)
        {
            // update annotation padding panel value
            paddingPanelControl1.PaddingValue = _annotation.Padding;
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the CheckedChanged event of autoUpdatePaddingCheckBox object.
        /// </summary>
        private void autoUpdatePaddingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoUpdatePaddingCheckBox.Checked)
            {
                _autoUpdatePadding = true;
                paddingPanelControl1.Enabled = false;
            }
            else
            {
                _autoUpdatePadding = false;
                paddingPanelControl1.Enabled = true;
            }

            OnPropertyValueChanged();
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
