using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.Annotations;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of the <see cref="PdfLineAnnotation"/>.
    /// </summary>
    public partial class PdfLineAnnotationPropertiesEditorControl : UserControl, IPdfAnnotationPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfLineAnnotationPropertiesEditorControl"/> class.
        /// </summary>
        public PdfLineAnnotationPropertiesEditorControl()
        {
            InitializeComponent();

            foreach (PdfAnnotationLineEndingStyle style in Enum.GetValues(typeof(PdfAnnotationLineEndingStyle)))
            {
                startPointLineEndingStyleComboBox.Items.Add(style);
                endPointLineEndingStyleComboBox.Items.Add(style);
            }
        }

        #endregion



        #region Properties

        PdfLineAnnotation _annotation;
        /// <summary>
        /// Gets or sets the annotation.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PdfLineAnnotation Annotation
        {
            get
            {
                return _annotation;
            }
            set
            {
                _annotation = value;

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
                Annotation = value as PdfLineAnnotation;
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

            startPointLineEndingStyleComboBox.SelectedItem = _annotation.StartPointLineEndingStyle;
            endPointLineEndingStyleComboBox.SelectedItem = _annotation.EndPointLineEndingStyle;
            interiorColorColorPanelControl.Color = _annotation.InteriorColor;
            UpdateUI();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the SelectedIndexChanged event of StartPointLineEndingStyleComboBox object.
        /// </summary>
        private void StartPointLineEndingStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update start point line ending style
            _annotation.StartPointLineEndingStyle = (PdfAnnotationLineEndingStyle)startPointLineEndingStyleComboBox.SelectedItem;
            UpdateUI();
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of EndPointLineEndingStyleComboBox object.
        /// </summary>
        private void EndPointLineEndingStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update end point line ending style
            _annotation.EndPointLineEndingStyle = (PdfAnnotationLineEndingStyle)endPointLineEndingStyleComboBox.SelectedItem;
            UpdateUI();
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the ColorChanged event of InteriorColorColorPanelControl object.
        /// </summary>
        private void InteriorColorColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            // update annotation interior color
            _annotation.InteriorColor = interiorColorColorPanelControl.Color;
            OnPropertyValueChanged();
        }


        /// <summary>
        /// Updates the user interface of this control.
        /// </summary>
        private void UpdateUI()
        {
            PdfAnnotationLineEndingStyle startPointLineEndingStyle = PdfAnnotationLineEndingStyle.None;
            if (startPointLineEndingStyleComboBox.SelectedItem != null)
                startPointLineEndingStyle = (PdfAnnotationLineEndingStyle)startPointLineEndingStyleComboBox.SelectedItem;

            PdfAnnotationLineEndingStyle endPointLineEndingStyle = PdfAnnotationLineEndingStyle.None;
            if (endPointLineEndingStyleComboBox.SelectedItem != null)
                endPointLineEndingStyle = (PdfAnnotationLineEndingStyle)endPointLineEndingStyleComboBox.SelectedItem;

            interiorColorColorPanelControl.Enabled =
                PdfAnnotationsTools.IsClosedLineEndingStyle(startPointLineEndingStyle) ||
                PdfAnnotationsTools.IsClosedLineEndingStyle(endPointLineEndingStyle);
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
