using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// Represents an editor of PDF Embedded File Specification object.
    /// </summary>
    public partial class EmbeddedFileSpecificationForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedFileSpecificationForm"/> class.
        /// </summary>
        public EmbeddedFileSpecificationForm()
        {
            InitializeComponent();

            // init compression combo box
            compressionComboBox.Items.Add(PdfCompression.None);
            compressionComboBox.Items.Add(PdfCompression.Zip);
            compressionComboBox.Items.Add(PdfCompression.Lzw);
            compressionComboBox.Items.Add(PdfCompression.Ascii85);
            compressionComboBox.Items.Add(PdfCompression.AsciiHex);
            compressionComboBox.Items.Add(PdfCompression.Zip | PdfCompression.Ascii85);
        }

        #endregion



        #region Properties

        PdfEmbeddedFileSpecification _embeddedFileSpecification;
        /// <summary>
        /// Gets or sets the embedded file specification.
        /// </summary>
        [Browsable(false)]
        [DefaultValue((object)null)]
        public PdfEmbeddedFileSpecification EmbeddedFileSpecification
        {
            get
            {
                return _embeddedFileSpecification;
            }
            set
            {
                _embeddedFileSpecification = value;
                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // update file description
            _embeddedFileSpecification.Filename = filenameTextBox.Text;
            // update file specification
            _embeddedFileSpecification.Description = fileDescriptionTextBox.Text;
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of buttonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // cancel this form
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of compressionComboBox object.
        /// </summary>
        private void compressionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if embedded file exists
            if (_embeddedFileSpecification.EmbeddedFile != null)
            {
                // set selected PDF compression to the embedded file
                _embeddedFileSpecification.EmbeddedFile.Compression = (PdfCompression)compressionComboBox.SelectedItem;
                // update user interface
                UpdateUI();
            }
        }

        /// <summary>
        /// Handles the Click event of browseButton object.
        /// </summary>
        private void browseButton_Click(object sender, EventArgs e)
        {
            // create open file dialog
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                try
                {
                    // if file must be opened
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        // set new embedded file
                        _embeddedFileSpecification.EmbeddedFile = new PdfEmbeddedFile(_embeddedFileSpecification.Document, openFile.FileName);
                        // set new embedded file name
                        _embeddedFileSpecification.Filename = Path.GetFileName(openFile.FileName);
                        // update user interface
                        UpdateUI();
                    }
                }

                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of saveAsButton object.
        /// </summary>
        private void saveAsButton_Click(object sender, EventArgs e)
        {
            // create save file dialog
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                try
                {
                    // get embedded file name
                    string filename = Path.GetFileName(_embeddedFileSpecification.Filename);
                    // set default save extension
                    saveFile.DefaultExt = Path.GetExtension(filename);
                    // set save file name
                    saveFile.FileName = filename;
                    // if file must be saved
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        // save embedded file
                        File.WriteAllBytes(saveFile.FileName, _embeddedFileSpecification.EmbeddedFile.GetBytes());
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        #endregion


        /// <summary>
        /// Updates the User Interface.
        /// </summary>
        private void UpdateUI()
        {
            // if embedded file specification is not empty
            if (_embeddedFileSpecification != null)
            {
                // set filename to the filename text box
                filenameTextBox.Text = _embeddedFileSpecification.Filename;
                // set description to the decription text box
                fileDescriptionTextBox.Text = _embeddedFileSpecification.Description;
                // if embedded file is empty
                if (_embeddedFileSpecification.EmbeddedFile == null)
                {
                    // disable "Save As..." button 
                    saveAsButton.Enabled = false;
                    // set empty string to the size text box
                    sizeTextBox.Text = "";
                    // set empty string to the compressed size text box
                    compressedSizeTextBox.Text = "";
                    // disable compression combo box
                    compressionComboBox.Enabled = false;
                    // set PDF compression "None" as selected compression
                    compressionComboBox.SelectedItem = PdfCompression.None;
                }
                // if embedded file is not empty
                else
                {
                    // enable "Save As..." button
                    saveAsButton.Enabled = true;
                    // if embedded file uncompressed size is greater than 0
                    if (_embeddedFileSpecification.UncompressedSize > 0)
                    {
                        // set the information to the size text box
                        sizeTextBox.Text = string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_ARG0_BYTES_ALT2, _embeddedFileSpecification.UncompressedSize);
                    }
                    else
                    {
                        // set empty string to the size text box
                        sizeTextBox.Text = "";
                    }
                    // if embedded file compressed size is greater than 0
                    if (_embeddedFileSpecification.CompressedSize > 0)
                    {
                        // set the information to the compressed size text box
                        compressedSizeTextBox.Text = string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_ARG0_BYTES_ALT3, _embeddedFileSpecification.CompressedSize);
                    }
                    else
                    {
                        // set empty string to the size text box
                        compressedSizeTextBox.Text = "";
                    }
                    // enable compression combo box
                    compressionComboBox.Enabled = true;
                    // if compression combo box does not contain compression of embedded file
                    if (!compressionComboBox.Items.Contains(_embeddedFileSpecification.EmbeddedFile.Compression))
                    {
                        // add compression of embedded file to the compression combo box
                        compressionComboBox.Items.Add(_embeddedFileSpecification.EmbeddedFile.Compression);
                    }
                    // set embedded file compression as selected compression
                    compressionComboBox.SelectedItem = _embeddedFileSpecification.EmbeddedFile.Compression;
                }
            }
        }

        #endregion

    }
}
