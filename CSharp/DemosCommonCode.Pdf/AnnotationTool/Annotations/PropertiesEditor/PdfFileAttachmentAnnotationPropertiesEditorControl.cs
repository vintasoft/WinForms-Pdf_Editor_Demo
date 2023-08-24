using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.Annotations;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of
    /// the <see cref="PdfFileAttachmentAnnotation"/>.
    /// </summary>
    public partial class PdfFileAttachmentAnnotationPropertiesEditorControl : UserControl, IPdfAnnotationPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfFileAttachmentAnnotationPropertiesEditorControl"/> class.
        /// </summary>
        public PdfFileAttachmentAnnotationPropertiesEditorControl()
        {
            InitializeComponent();

            string[] standardIconNames = new string[]{
                "Graph",
                "PushPin",
                "Paperclip",
                "Tag" };

            foreach (string iconName in standardIconNames)
                iconComboBox.Items.Add(iconName);
        }

        #endregion



        #region Properties

        PdfFileAttachmentAnnotation _annotation;
        /// <summary>
        /// Gets or sets the annotation.
        /// </summary>
        public PdfFileAttachmentAnnotation Annotation
        {
            get
            {
                return _annotation;
            }
            set
            {
                _annotation = value;

                if (_annotation != null)
                {
                    mainPanel.Enabled = true;
                    embeddedFileSpecificationViewer.EmbeddedFileSpecification = _annotation.FileSpecification;
                }
                else
                    mainPanel.Enabled = false;

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
                Annotation = value as PdfFileAttachmentAnnotation;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates information about the annotation.
        /// </summary>
        public void UpdateAnnotationInfo()
        {
            if (_annotation == null)
                return;

            iconComboBox.Text = _annotation.IconName;

            embeddedFileSpecificationViewer.UpdateEmbeddedFileSpecificationInfo();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the TextChanged event of IconComboBox object.
        /// </summary>
        private void iconComboBox_TextChanged(object sender, EventArgs e)
        {
            // if annotation icon is changed
            if (iconComboBox.Text != null &&
                iconComboBox.Text != _annotation.IconName)
            {
                // update annotation icon
                _annotation.IconName = iconComboBox.Text;
                OnPropertyValueChanged();
            }
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
