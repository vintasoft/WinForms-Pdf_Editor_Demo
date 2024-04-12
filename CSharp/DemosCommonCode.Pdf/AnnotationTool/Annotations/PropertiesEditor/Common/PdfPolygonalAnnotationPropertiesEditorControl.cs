using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.Annotations;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of the <see cref="PdfPolygonalAnnotation"/>.
    /// </summary>
    public partial class PdfPolygonalAnnotationPropertiesEditorControl : UserControl, IPdfAnnotationPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfPolygonalAnnotationPropertiesEditorControl"/> class.
        /// </summary>
        public PdfPolygonalAnnotationPropertiesEditorControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        PdfPolygonalAnnotation _annotation;
        /// <summary>
        /// Gets or sets the annotation.
        /// </summary>
        public PdfPolygonalAnnotation Annotation
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
                Annotation = value as PdfPolygonalAnnotation;
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
        /// Handles the PropertyValueChanged event of pdfAnnotationBorderEffectEditorControl1 object.
        /// </summary>
        private void pdfAnnotationBorderEffectEditorControl1_PropertyValueChanged(
            object sender,
            EventArgs e)
        {
            // raise property value changed event
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
