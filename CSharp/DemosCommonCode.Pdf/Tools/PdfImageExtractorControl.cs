using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Content.ImageExtraction;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.UI;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

using DemosCommonCode.Imaging.Codecs;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to extract image-resources from PDF page.
    /// </summary>
    public partial class PdfImageExtractorControl : UserControl
    {

        #region Fields

        /// <summary>
        /// Determines that image is selected in image viewer.
        /// </summary>
        bool _isImageSelected = false;

        /// <summary>
        /// Determines that visual tool is activated.
        /// </summary>
        bool _isVisualToolActivated = false;

        /// <summary>
        /// Determines that image, which is selected in visual tool, is changing.
        /// </summary>
        bool _isSelectedImageChanging = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfImageExtractorControl"/> class.
        /// </summary>
        public PdfImageExtractorControl()
        {
            InitializeComponent();

            DemosTools.SetTestFilesFolder(ImageSaveFileDialog);
            CodecsFileFilters.SetSaveFileDialogFilter(ImageSaveFileDialog, false, false);
        }

        #endregion



        #region Properties

        PdfImageExtractorTool _imageExtractorTool = null;
        /// <summary>
        /// Gets or sets the PDF image extractor tool.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public PdfImageExtractorTool ImageExtractorTool
        {
            get
            {
                return _imageExtractorTool;
            }
            set
            {
                if (_imageExtractorTool == value)
                    return;

                if (_imageExtractorTool != null)
                    UnsubscribeFromVisualToolEvents(_imageExtractorTool);

                _imageExtractorTool = value;
                _isVisualToolActivated = false;

                if (_imageExtractorTool != null)
                    SubscribeToVisualToolEvents(_imageExtractorTool);

                UpdateImageResourcesListBox();
                UpdateUI();
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Updates the user interface of this control.
        /// </summary>
        private void UpdateUI()
        {
            bool containsTool = _imageExtractorTool != null;

            mainPanel.Enabled = containsTool &&
                _imageExtractorTool.ImageViewer != null &&
                _imageExtractorTool.ImageViewer.Image != null &&
                PdfDocumentController.GetPageAssociatedWithImage(_imageExtractorTool.ImageViewer.Image) != null;

            if (mainPanel.Enabled)
            {
                bool resourceIsSelected = false;
                if (containsTool)
                    resourceIsSelected = _imageExtractorTool.SelectedImage != null;
                bool containsImages = containsTool && _imageExtractorTool.ContentImages != null;
                if (containsImages)
                    containsImages = _imageExtractorTool.ContentImages.Length > 0;

                saveGroupBox.Enabled = resourceIsSelected;
                viewContentImageButton.Enabled = resourceIsSelected;
            }
        }


        /// <summary>
        /// Returns the description of content image.
        /// </summary>
        /// <param name="contentImage">The content image.</param>
        /// <returns>The description of content image.</returns>
        private string GetContentImageDescription(ContentImage contentImage)
        {
            string result = string.Empty;

            PdfImageResource resource = contentImage.ImageResource;
            // if resource is inline
            if (resource.IsInline)
                result = "Inline, ";
            else
                result = string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_RESOURCE_03, resource.ObjectNumber.ToString());

            // size of resource
            result += string.Format("{0}x{1} px, ", resource.Width, resource.Height);
            // compression of resource
            result += string.Format("compression={0}, ", resource.Compression);
            // compressed size of resource
            result += string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_ARG0_BYTES_ALT6, resource.Length);
            return result;
        }

        /// <summary>
        /// Returns the zoom of transformed image.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        /// <returns>The zoom of transformed image.</returns>
        private float GetTransformedImageZoom(ImageViewer imageViewer)
        {
            int zoom = imageViewer.Zoom;
            return (96f / 72f) * (zoom / 100f);
        }


        #region ImageResourcesListBox

        /// <summary>
        /// Image resource is changed in list box.
        /// </summary>
        private void imageResourcesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSelectedImageChanging)
                return;

            ContentImage contentImage = null;

            if (imageResourcesListBox.SelectedIndex != -1)
                contentImage = _imageExtractorTool.ContentImages[imageResourcesListBox.SelectedIndex];

            _imageExtractorTool.SelectedImage = contentImage;
            _isImageSelected = contentImage != null;

            UpdateUI();
        }

        /// <summary>
        /// Image resource is clicked.
        /// </summary>
        private void imageResourcesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (imageResourcesListBox.SelectedIndex != -1)
                viewContentImageButton_Click(sender, e);
        }

        /// <summary>
        /// Updates the image resources in list box.
        /// </summary>
        private void UpdateImageResourcesListBox()
        {
            imageResourcesListBox.BeginUpdate();
            try
            {
                // clear items
                imageResourcesListBox.Items.Clear();
                // if visual tool is activated
                if (_imageExtractorTool != null && _isVisualToolActivated)
                {
                    // get content images of current PDF page
                    ContentImage[] contentImages = _imageExtractorTool.ContentImages;
                    // if content images is exist
                    if (contentImages != null)
                    {
                        // add all content images
                        foreach (ContentImage contentImage in contentImages)
                            imageResourcesListBox.Items.Add(GetContentImageDescription(contentImage));
                    }
                }
            }
            finally
            {
                imageResourcesListBox.EndUpdate();
            }
        }

        /// <summary>
        /// Updates the description of focused image.
        /// </summary>
        private void UpdateFocusedImageDescription()
        {
            int selectedIndex = imageResourcesListBox.SelectedIndex;

            if (selectedIndex != -1)
            {
                imageResourcesListBox.Items[selectedIndex] = 
                    GetContentImageDescription(_imageExtractorTool.SelectedImage);
            }
        }

        #endregion


        #region Buttons

        /// <summary>
        /// "View content image" button is clicked.
        /// </summary>
        private void viewContentImageButton_Click(object sender, EventArgs e)
        {
            // get the image viewer
            ImageViewer imageViewer = _imageExtractorTool.ImageViewer;
            // get the transformed zoom of content image
            float zoom = GetTransformedImageZoom(imageViewer);

            // get selected image
            ContentImage contentImage = _imageExtractorTool.SelectedImage;

            PdfCompression previousCompression = contentImage.ImageResource.Compression;
            // create a dialog with information about content image
            using (ViewContentImageForm viewContentImageForm = new ViewContentImageForm(contentImage, zoom))
            {
                // show the dialog
                viewContentImageForm.ShowDialog();

                if (previousCompression != contentImage.ImageResource.Compression)
                {
                    UpdateFocusedImageDescription();

                    imageViewer.ReloadImage();
                }
            }
        }

        /// <summary>
        /// "Save image resource" button is clicked.
        /// </summary>
        private void saveImageResourceButton_Click(object sender, EventArgs e)
        {
            // show dialog for file selection
            if (ImageSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // get image resource of selected image
                PdfImageResource imageResource = _imageExtractorTool.SelectedImage.ImageResource;

                // get image of image resource
                using (VintasoftImage image = imageResource.GetImage())
                {
                    // save image to a file
                    image.Save(ImageSaveFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// "Save transformed image" button is clicked.
        /// </summary>
        private void saveTransformedImageButton_Click(object sender, EventArgs e)
        {
            // show dialog for file selection
            if (ImageSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // get image of selected image
                ContentImage contentImage = _imageExtractorTool.SelectedImage;
                // get zoom of transformed image
                float zoom = GetTransformedImageZoom(_imageExtractorTool.ImageViewer);
                // get image
                using (VintasoftImage image = contentImage.RenderImage(zoom))
                {
                    // save image to a file
                    image.Save(ImageSaveFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the "Copy Image to Clipboard" menu item.
        /// </summary>
        private void copyImageToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageExtractorTool.CopyAction.Execute();
        }

        #endregion


        #region Visual tool

        /// <summary>
        /// Subscribes to the events of visual tool.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        private void SubscribeToVisualToolEvents(PdfImageExtractorTool visualTool)
        {
            visualTool.Activated += new EventHandler(VisualTool_Activated);
            visualTool.Deactivated += new EventHandler(VisualTool_Deactivated);
            visualTool.ImageMouseEnter += new EventHandler<PdfImageExtractorEventArgs>(VisualTool_ImageMouseEnter);
            visualTool.ImageMouseLeave += new EventHandler<PdfImageExtractorEventArgs>(VisualTool_ImageMouseLeave);
            visualTool.MouseDown += new VisualToolMouseEventHandler(VisualTool_MouseDown);
            visualTool.MouseDoubleClick += new VisualToolMouseEventHandler(VisualTool_MouseDoubleClick);
            visualTool.SelectedImageChanged += new EventHandler(VisualTool_SelectedImageChanged);

            if (visualTool.ImageViewer != null)
            {
                SubscribeToImageViewerEvents(visualTool.ImageViewer);
                _isVisualToolActivated = true;
            }
        }

        /// <summary>
        /// Unsubscribes from the events of visual tool.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        private void UnsubscribeFromVisualToolEvents(PdfImageExtractorTool visualTool)
        {
            visualTool.Activated -= VisualTool_Activated;
            visualTool.Deactivated -= VisualTool_Deactivated;
            visualTool.ImageMouseEnter -= VisualTool_ImageMouseEnter;
            visualTool.ImageMouseLeave -= VisualTool_ImageMouseLeave;
            visualTool.MouseDown -= VisualTool_MouseDown;
            visualTool.MouseDoubleClick -= VisualTool_MouseDoubleClick;
            visualTool.SelectedImageChanged -= VisualTool_SelectedImageChanged;

            if (visualTool.ImageViewer != null)
            {
                UnsubscribeFromImageViewerEvents(visualTool.ImageViewer);
                _isVisualToolActivated = false;
            }
        }

        /// <summary>
        /// Visual tool is activated.
        /// </summary>
        private void VisualTool_Activated(object sender, EventArgs e)
        {
            PdfVisualTool visualTool = (PdfVisualTool)sender;

            _isImageSelected = false;
            SubscribeToImageViewerEvents(visualTool.ImageViewer);
            _isVisualToolActivated = true;
            UpdateImageResourcesListBox();
            UpdateUI();
        }

        /// <summary>
        /// Visual tool is deactivated.
        /// </summary>
        private void VisualTool_Deactivated(object sender, EventArgs e)
        {
            PdfVisualTool visualTool = (PdfVisualTool)sender;

            UnsubscribeFromImageViewerEvents(visualTool.ImageViewer);
            _isVisualToolActivated = false;
            UpdateImageResourcesListBox();
            mainPanel.Enabled = false;
        }

        /// <summary>
        /// Mouse pointer enters an image on PDF page.
        /// </summary>
        private void VisualTool_ImageMouseEnter(object sender, PdfImageExtractorEventArgs e)
        {
            if (!Enabled || !mainPanel.Enabled || _isImageSelected)
                return;

            _isSelectedImageChanging = true;
            _imageExtractorTool.SelectedImage = e.ContentImage;
            imageResourcesListBox.SelectedIndex = Array.IndexOf(_imageExtractorTool.ContentImages, e.ContentImage);
            _isSelectedImageChanging = false;
        }

        /// <summary>
        /// Mouse pointer leaves an image on PDF page.
        /// </summary>
        private void VisualTool_ImageMouseLeave(object sender, PdfImageExtractorEventArgs e)
        {
            if (!Enabled || !mainPanel.Enabled || _isImageSelected)
                return;

            _isSelectedImageChanging = true;
            _imageExtractorTool.SelectedImage = null;
            imageResourcesListBox.SelectedIndex = -1;
            _isSelectedImageChanging = false;
        }

        /// <summary>
        /// Mouse is down on an image on PDF page.
        /// </summary>
        private void VisualTool_MouseDown(object sender, VisualToolMouseEventArgs e)
        {
            if (!Enabled || !mainPanel.Enabled)
                return;

            // if left or right mouse button is clicked
            if (e.Button == MouseButtons.Left ||
                e.Button == MouseButtons.Right)
            {
                ContentImage image = _imageExtractorTool.FindImageInViewerSpace(e.Location);

                _isImageSelected = image != null;

                // set image as selected image
                _imageExtractorTool.SelectedImage = image;
                // update resource index in list box
                imageResourcesListBox.SelectedIndex = Array.IndexOf(_imageExtractorTool.ContentImages, image);
                UpdateUI();
            }

            // if right mouse button is clicked
            if (e.Button == MouseButtons.Right)
                // show context menu
                ImageExtractorContextMenuStrip.Show(_imageExtractorTool.ImageViewer, e.Location);
        }

        /// <summary>
        /// Mouse is double click on an image on PDF page.
        /// </summary>
        void VisualTool_MouseDoubleClick(object sender, VisualToolMouseEventArgs e)
        {
            if (!Enabled || !mainPanel.Enabled)
                return;

            // get selected image
            ContentImage contentImage = _imageExtractorTool.SelectedImage;

            if (contentImage != null &&
                e.Button == MouseButtons.Left)
            {
                // get the image viewer
                ImageViewer imageViewer = _imageExtractorTool.ImageViewer;
                // get the transformed zoom of content image
                float zoom = GetTransformedImageZoom(imageViewer);

                PdfCompression previousCompression = contentImage.ImageResource.Compression;
                // create a dialog with information about content image
                using (ViewContentImageForm viewContentImageForm = new ViewContentImageForm(contentImage, zoom))
                {
                    // show the dialog
                    viewContentImageForm.ShowDialog();

                    if (previousCompression != contentImage.ImageResource.Compression)
                    {
                        UpdateFocusedImageDescription();

                        imageViewer.ReloadImage();
                    }
                }
            }
        }

        /// <summary>
        /// Selected image is changed in visual tool.
        /// </summary>
        void VisualTool_SelectedImageChanged(object sender, EventArgs e)
        {
            if (!Enabled || !mainPanel.Enabled)
                return;

            imageResourcesListBox.SelectedIndex = Array.IndexOf(_imageExtractorTool.ContentImages, _imageExtractorTool.SelectedImage);
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Subscribes to the events of image viewer.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void SubscribeToImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged += new EventHandler<FocusedIndexChangedEventArgs>(ImageViewer_FocusedIndexChanged);
        }

        /// <summary>
        /// Unsubscribes from the events of image viewer.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void UnsubscribeFromImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged -= ImageViewer_FocusedIndexChanged;
        }

        /// <summary>
        /// Focused image in image viewer is changed.
        /// </summary>
        private void ImageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            _isSelectedImageChanging = false;
            _isImageSelected = false;
            _imageExtractorTool.SelectedImage = null;

            UpdateImageResourcesListBox();
            UpdateUI();
        }

        #endregion


        #region ImageExtractorContextMenuStrip

        /// <summary>
        /// Context menu strip is opening.
        /// </summary>
        private void ImageExtractorContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _imageExtractorTool.SelectedImage == null;
        }

        #endregion

        #endregion

    }
}
