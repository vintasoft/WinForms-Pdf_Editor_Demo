using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Content.ImageExtraction;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A form that allows to view PDF contant image.
    /// </summary>
    public partial class ViewContentImageForm : Form
    {

        #region Fields

        ContentImage _contentImage;
        float _zoom;
        RadioButton _previousRadioButtonChecked = null;

        #endregion



        #region Constructor

        public ViewContentImageForm(ContentImage contentImage, float zoom)
        {
            InitializeComponent();

            if (contentImage == null)
                throw new ArgumentNullException("contentImage");

            _zoom = zoom;
            _contentImage = contentImage;

            _previousRadioButtonChecked = transformedImageRadioButton;
            UpdateContentImageInfo();
            ReloadResourceImage();
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the CheckedChanged event of ViewImageRadioButton object.
        /// </summary>
        private void viewImageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton != _previousRadioButtonChecked)
            {
                ReloadResourceImage();
                _previousRadioButtonChecked = radioButton;
            }
        }

        private void ReloadResourceImage()
        {
            if (_contentImage == null)
                return;

            try
            {
                VintasoftImage img = imageViewer.Image;

                if (originalImageRadioButton.Checked)
                    imageViewer.Image = _contentImage.ImageResource.GetImage();
                else if (transformedImageRadioButton.Checked)
                    imageViewer.Image = _contentImage.RenderImage(_zoom);

                if (img != null)
                    img.Dispose();
            }
            catch (Exception exc)
            {
                DemosTools.ShowErrorMessage(exc);
            }
        }

        /// <summary>
        /// Handles the Click event of SaveAsButton object.
        /// </summary>
        private void saveAsButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                imageViewer.Image.Save(saveFileDialog.FileName);
        }

        /// <summary>
        /// Handles the Click event of ViewResourceButton object.
        /// </summary>
        private void viewResourceButton_Click(object sender, EventArgs e)
        {
            PdfCompression previousCompression = _contentImage.ImageResource.Compression;
            using (PdfResourcesViewerForm form =
                new PdfResourcesViewerForm(_contentImage.ImageResource))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.Owner = this.ParentForm;
                form.ShowDialog();

                if (previousCompression != _contentImage.ImageResource.Compression)
                {
                    UpdateContentImageInfo();
                    ReloadResourceImage();
                }
            }
        }

        private void UpdateContentImageInfo()
        {
            compressionLabel.Text = string.Format("{0}", _contentImage.ImageResource.Compression);
            compressedSizeLabel.Text = string.Format("{0} bytes", _contentImage.ImageResource.Length);
            originalSizeLabel.Text = string.Format("{0}x{1} px", _contentImage.ImageResource.Width, _contentImage.ImageResource.Height);
            RegionF region = _contentImage.Region;
            LTlabel.Text = string.Format("({0};{1})", region.LeftTop.X, region.LeftTop.Y);
            LBlabel.Text = string.Format("({0};{1})", region.LeftBottom.X, region.LeftBottom.Y);
            RTlabel.Text = string.Format("({0};{1})", region.RightTop.X, region.RightTop.Y);
            RBlabel.Text = string.Format("({0};{1})", region.RightBottom.X, region.RightBottom.Y);
            regionGroupBox.Text = string.Format("Region in page content (Resolution: {0})", _contentImage.Resolution);
        }

        #endregion

    }
}
