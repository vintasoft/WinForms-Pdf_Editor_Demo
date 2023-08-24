using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Encoders;

using DemosCommonCode.Imaging.Codecs.Dialogs;


namespace PdfEditorDemo
{
    /// <summary>
    /// A form that allows to specify parameters for image encoding.
    /// </summary>
    public partial class SetCompressionParamsForm : Form
    {

        #region Fields

        /// <summary>
        /// The PDF encoder settings.
        /// </summary>
        PdfEncoderSettings _encoderSettings;

        #endregion



        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SetCompressionParamsForm"/> class.
        /// </summary>
        /// <param name="index">Page index.</param>
        /// <param name="image">Page image.</param>
        /// <param name="encoderSettings">PDF encoder settings.</param>
        public SetCompressionParamsForm(
            int index,
            VintasoftImage image,
            PdfEncoderSettings encoderSettings)
        {
            InitializeComponent();

            _encoderSettings = encoderSettings;
            compressionComboBox.Items.Add(PdfImageCompression.Auto);
            compressionComboBox.Items.Add(PdfImageCompression.Zip);
            compressionComboBox.Items.Add(PdfImageCompression.Lzw);
            compressionComboBox.Items.Add(PdfImageCompression.Jpeg);
            if (AvailableEncoders.IsEncoderAvailable("Jpeg2000"))
                compressionComboBox.Items.Add(PdfImageCompression.Jpeg2000);
            compressionComboBox.Items.Add(PdfImageCompression.CcittFax);
            if (AvailableEncoders.IsEncoderAvailable("Jbig2"))
                compressionComboBox.Items.Add(PdfImageCompression.Jbig2);
            compressionComboBox.Items.Add(PdfImageCompression.None);
            _encoderSettings = encoderSettings;
            compressionComboBox.SelectedItem = encoderSettings.Compression;

            jpegQualityNumericUpDown.Value = encoderSettings.JpegQuality;
            jpegGrayscaleCheckBox.Checked = encoderSettings.JpegSaveAsGrayscale;
            jbig2LossyCheckBox.Checked = encoderSettings.Jbig2Settings.Lossy;
            jbig2UseGlobalsCheckBox.Checked = encoderSettings.Jbig2UseGlobals;

            imageNumberLabel.Text = (index + 1).ToString();
            pixelFormatLabel.Text = image.PixelFormat.ToString();
            sizeLabel.Text = string.Format("{0}x{1} pixels", image.Width, image.Height);
        }

        #endregion



        #region Properties

        bool _useCompressionForAllImages = false;
        /// <summary>
        /// Gets a value indicating whether to use compression for all images.
        /// </summary>
        /// <value>
        /// <b>True</b> if compression is used for all images; otherwise, <b>false</b>.
        /// </value>
        public bool UseCompressionForAllImages
        {
            get
            {
                return _useCompressionForAllImages;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// "Ok" button is clicked.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            SetParams();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// "For all" button is clicked.
        /// </summary>
        private void forAllButton_Click(object sender, EventArgs e)
        {
            _useCompressionForAllImages = true;
            SetParams();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of CompressionComboBox object.
        /// </summary>
        private void compressionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _encoderSettings.Compression = (PdfImageCompression)compressionComboBox.SelectedItem;
            jpegParamsGroupBox.Visible = false;
            jbig2ParamsGroupBox.Visible = false;
            jpeg2000CompressionGroupBox.Visible = false;
            switch (_encoderSettings.Compression)
            {
                case PdfImageCompression.Jpeg:
                    jpegParamsGroupBox.Visible = true;
                    break;
                case PdfImageCompression.Jbig2:
                    jbig2ParamsGroupBox.Visible = true;
                    break;
                case PdfImageCompression.Jpeg2000:
                    jpeg2000CompressionGroupBox.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of Jpeg2000SettingsButton object.
        /// </summary>
        private void jpeg2000SettingsButton_Click(object sender, EventArgs e)
        {
            using (Jpeg2000EncoderSettingsForm jpeg2000SettingsDialog = new Jpeg2000EncoderSettingsForm())
            {
                jpeg2000SettingsDialog.EncoderSettings = _encoderSettings.Jpeg2000Settings;
                jpeg2000SettingsDialog.ShowDialog();
            }
        }


        /// <summary>
        /// Sets the parameters of encoder.
        /// </summary>
        private void SetParams()
        {
            _encoderSettings.JpegQuality = (int)jpegQualityNumericUpDown.Value;
            _encoderSettings.JpegSaveAsGrayscale = jpegGrayscaleCheckBox.Checked;
            _encoderSettings.Jbig2Settings.Lossy = jbig2LossyCheckBox.Checked;
            _encoderSettings.Jbig2UseGlobals = jbig2LossyCheckBox.Checked;
        }

        #endregion

    }
}
