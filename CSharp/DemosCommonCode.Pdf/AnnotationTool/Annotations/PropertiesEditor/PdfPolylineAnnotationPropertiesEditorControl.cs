using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.Annotations;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of the <see cref="PdfPolylineAnnotation"/>.
    /// </summary>
    public partial class PdfPolylineAnnotationPropertiesEditorControl : UserControl, IPdfAnnotationPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfPolylineAnnotationPropertiesEditorControl"/> class.
        /// </summary>
        public PdfPolylineAnnotationPropertiesEditorControl()
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

        PdfPolylineAnnotation _annotation;
        /// <summary>
        /// Gets or sets the annotation.
        /// </summary>
        public PdfPolylineAnnotation Annotation
        {
            get
            {
                return _annotation;
            }
            set
            {
                _annotation = value;

                mainPanel.Enabled = _annotation != null;
                pdfPolygonalAnnotationPropertiesEditorControl.Annotation = value;

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
                Annotation = value as PdfPolylineAnnotation;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the SelectedIndexChanged event of StartPointLineEndingStyleComboBox object.
        /// </summary>
        private void startPointLineEndingStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get start point line ending style
            PdfAnnotationLineEndingStyle lineEndingStyle =
                (PdfAnnotationLineEndingStyle)startPointLineEndingStyleComboBox.SelectedItem;

            // update user interface
            UpdateUI();

            // if start point line ending style is changed
            if (_annotation.StartPointLineEndingStyle != lineEndingStyle)
            {
                // update start point line ending style
                _annotation.StartPointLineEndingStyle = lineEndingStyle;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of EndPointLineEndingStyleComboBox object.
        /// </summary>
        private void endPointLineEndingStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get end point line ending style
            PdfAnnotationLineEndingStyle lineEndingStyle =
                (PdfAnnotationLineEndingStyle)endPointLineEndingStyleComboBox.SelectedItem;

            // update user interface
            UpdateUI();

            // if end point line ending style is changed
            if (_annotation.EndPointLineEndingStyle != lineEndingStyle)
            {
                // update end point line ending style
                _annotation.EndPointLineEndingStyle = lineEndingStyle;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of PdfPolygonalAnnotationPropertiesEditorControl object.
        /// </summary>
        private void pdfPolygonalAnnotationPropertiesEditorControl_PropertyValueChanged(object sender, EventArgs e)
        {
            // raise property value changed event
            OnPropertyValueChanged();
        }


        /// <summary>
        /// Updates the information about annotation.
        /// </summary>
        public void UpdateAnnotationInfo()
        {
            if (_annotation == null)
                return;

            startPointLineEndingStyleComboBox.SelectedItem = _annotation.StartPointLineEndingStyle;
            endPointLineEndingStyleComboBox.SelectedItem = _annotation.EndPointLineEndingStyle;
            UpdateUI();
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

            pdfPolygonalAnnotationPropertiesEditorControl.Enabled =
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



        #region Events

        /// <summary>
        /// Occurs when value of property is changed.
        /// </summary>
        public event EventHandler PropertyValueChanged;

        #endregion

    }
}
