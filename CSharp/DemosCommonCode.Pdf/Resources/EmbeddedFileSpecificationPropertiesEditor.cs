using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A panel that allows to show and change information about the file embedded into PDF document.
    /// </summary>
    public partial class EmbeddedFileSpecificationPropertiesEditor : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="EmbeddedFileSpecificationPropertiesEditor"/> class.
        /// </summary>
        public EmbeddedFileSpecificationPropertiesEditor()
        {
            InitializeComponent();

            UpdateEmbeddedFileSpecificationInfo();
        }

        #endregion



        #region Properties

        PdfEmbeddedFileSpecification _embeddedFileSpecification = null;
        /// <summary>
        /// Gets or sets the embedded file specification.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Browsable(false)]
        public PdfEmbeddedFileSpecification EmbeddedFileSpecification
        {
            get
            {
                return _embeddedFileSpecification;
            }
            set
            {
                _embeddedFileSpecification = value;

                mainPanel.Enabled = _embeddedFileSpecification != null &&
                                    _embeddedFileSpecification.EmbeddedFile != null;

                UpdateEmbeddedFileSpecificationInfo();
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates information about the embedded file.
        /// </summary>
        public void UpdateEmbeddedFileSpecificationInfo()
        {
            string filename = string.Empty;
            string description = string.Empty;
            long uncompressedSize = 0;
            PdfCompression compression = PdfCompression.None;
            long compressedSize = 0;

            if (_embeddedFileSpecification != null)
            {
                filename = _embeddedFileSpecification.Filename;
                description = _embeddedFileSpecification.Description;
                uncompressedSize = _embeddedFileSpecification.UncompressedSize;
                compression = _embeddedFileSpecification.Compression;
                compressedSize = _embeddedFileSpecification.CompressedSize;
            }

            filenameTextBox.Text = filename;
            descriptionTextBox.Text = description;
            uncompressedSizeTextBox.Text = FormatFileSize(uncompressedSize);
            UpdateCompressionComboBox(compression);
            compressedSizeTextBox.Text = FormatFileSize(compressedSize);
        }

        #endregion


        #region PRIVATE 

        #region UI

        /// <summary>
        /// Handles the TextChanged event of FilenameTextBox object.
        /// </summary>
        private void filenameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_embeddedFileSpecification != null && _embeddedFileSpecification.Filename != filenameTextBox.Text)
                // update filename
                _embeddedFileSpecification.Filename = filenameTextBox.Text;
        }

        /// <summary>
        /// Handles the TextChanged event of DescriptionTextBox object.
        /// </summary>
        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_embeddedFileSpecification != null && _embeddedFileSpecification.Description != descriptionTextBox.Text)
                // update file description
                _embeddedFileSpecification.Description = descriptionTextBox.Text;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of CompressionComboBox object.
        /// </summary>
        private void compressionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PdfCompression compression = (PdfCompression)compressionComboBox.SelectedItem;
            if (_embeddedFileSpecification != null &&
                _embeddedFileSpecification.Compression != compression)
            {
                // update file compression
                _embeddedFileSpecification.Compression = (PdfCompression)compressionComboBox.SelectedItem;
                // update file information
                UpdateEmbeddedFileSpecificationInfo();
            }
        }

        #endregion


        /// <summary>
        /// Formats the size of the file.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>Formatted size of the file.</returns>
        private string FormatFileSize(long size)
        {
            string result = string.Empty;
            if (size != 0)
                result = string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_ARG0_BYTES_ALT4, size);
            return result;
        }

        /// <summary>
        /// Updates the compression value in UI.
        /// </summary>
        /// <param name="compression">The compression.</param>
        private void UpdateCompressionComboBox(PdfCompression compression)
        {
            PdfCompression[] defaultCompression = new PdfCompression[] {
                    PdfCompression.None,
                    PdfCompression.Zip,
                    PdfCompression.Lzw,
                    PdfCompression.Ascii85,
                    PdfCompression.AsciiHex,
                    PdfCompression.Zip | PdfCompression.Ascii85 };

            if (compressionComboBox.Items.Count != defaultCompression.Length)
            {
                compressionComboBox.BeginUpdate();
                compressionComboBox.Items.Clear();
                foreach (PdfCompression currentCompression in defaultCompression)
                    compressionComboBox.Items.Add(currentCompression);
                compressionComboBox.EndUpdate();
            }

            bool addCurrentCompression = false;
            if (Array.IndexOf(defaultCompression, compression) == -1)
                addCurrentCompression = true;
            if (addCurrentCompression)
                compressionComboBox.Items.Add(compression);

            compressionComboBox.SelectedItem = compression;
        }

        #endregion

        #endregion

    }
}
