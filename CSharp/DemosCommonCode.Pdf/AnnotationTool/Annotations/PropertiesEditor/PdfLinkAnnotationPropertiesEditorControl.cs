using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.Annotations;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of the <see cref="PdfLinkAnnotation"/>.
    /// </summary>
    public partial class PdfLinkAnnotationPropertiesEditorControl : UserControl, IPdfAnnotationPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfLinkAnnotationPropertiesEditorControl"/> class.
        /// </summary>
        public PdfLinkAnnotationPropertiesEditorControl()
        {
            InitializeComponent();

            foreach (PdfAnnotationHighlightingMode mode in Enum.GetValues(typeof(PdfAnnotationHighlightingMode)))
                highlightingModeComboBox.Items.Add(mode);
        }

        #endregion



        #region Properties

        PdfLinkAnnotation _annotation;
        /// <summary>
        /// Gets or sets the annotation.
        /// </summary>
        public PdfLinkAnnotation Annotation
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
                Annotation = value as PdfLinkAnnotation;
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

            highlightingModeComboBox.SelectedItem = _annotation.HighlightingMode;
            if (pdfActionEditorControl.Document == null)
                pdfActionEditorControl.Document = _annotation.Document;
            pdfActionEditorControl.Action = _annotation.ActivateAction;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the SelectedIndexChanged event of highlightingModeComboBox object.
        /// </summary>
        private void highlightingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get higlight mode
            PdfAnnotationHighlightingMode highlightingMode =
                (PdfAnnotationHighlightingMode)highlightingModeComboBox.SelectedItem;

            // if highlight mode is changed
            if (_annotation.HighlightingMode != highlightingMode)
            {
                // update highlight mode
                _annotation.HighlightingMode = highlightingMode;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the ActionChanged event of pdfActionEditorControl object.
        /// </summary>
        private void pdfActionEditorControl_ActionChanged(object sender, EventArgs e)
        {
            // update activate action
            _annotation.ActivateAction = pdfActionEditorControl.Action;
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
