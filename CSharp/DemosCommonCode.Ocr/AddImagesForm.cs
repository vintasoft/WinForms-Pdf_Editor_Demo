﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.ImageProcessing.Info;
using Vintasoft.Imaging.ImageProcessing.Transforms;
using Vintasoft.Imaging.UI;

using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Twain;
#if !REMOVE_PDF_PLUGIN
using DemosCommonCode.Pdf;
#endif

namespace DemosCommonCode.Ocr
{
    /// <summary>
    /// A form that allows to add images.
    /// </summary>
    public partial class AddImagesForm : Form
    {

        #region Fields

        /// <summary>
        /// The simple TWAIN manager to acquire images from scanner.
        /// </summary>
        SimpleTwainManager _simpleTwainManager;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AddImagesForm"/> class.
        /// </summary>
        public AddImagesForm()
        {
            InitializeComponent();

            // set filters in open dialog
            CodecsFileFilters.SetOpenFileDialogFilter(openImageFileDialog);

            // set CustomFontProgramsController for all opened documents
            CustomFontProgramsController.SetDefaultFontProgramsController();

            // set the initial directory in open dialog
            DemosTools.SetTestFilesFolder(openImageFileDialog);

            _simpleTwainManager = new SimpleTwainManager(this, thumbnailViewer1.Images);

            // disable management of images rendering settings
            imageViewer1.ImageRenderingSettings = null;

            // update the UI
            UpdateUI();
        }

        #endregion



        #region Properties

        Dictionary<VintasoftImage, ReadOnlyCollection<ImageRegion>> _segmentationResults;
        /// <summary>
        /// Gets the segmentation results.
        /// </summary>
        public Dictionary<VintasoftImage, ReadOnlyCollection<ImageRegion>> SegmentationResults
        {
            get
            {
                return _segmentationResults;
            }
        }

        bool _openFileWhenShown = false;
        /// <summary>
        /// Gets or sets a value indicating whether
        /// to open image from file when form is shown.
        /// </summary>
        public bool OpenFileWhenShown
        {
            get
            {
                return _openFileWhenShown;
            }
            set
            {
                _openFileWhenShown = value;
            }
        }

        bool _scanImageWhenShown = false;
        /// <summary>
        /// Gets or sets a value indicating whether
        /// to acquire image from scanner when form is shown.
        /// </value>
        public bool ScanImageWhenShown
        {
            get
            {
                return _scanImageWhenShown;
            }
            set
            {
                _scanImageWhenShown = value;
            }
        }

        /// <summary>
        /// Gets currently opened images.
        /// </summary>
        public ImageCollection Images
        {
            get
            {
                return thumbnailViewer1.Images;
            }
        }

        bool _isImageOpening = false;
        /// <summary>
        /// Gets or sets a value indicating whether image is opening.
        /// </summary>
        bool IsImageOpening
        {
            get
            {
                return _isImageOpening;
            }
            set
            {
                _isImageOpening = value;
                UpdateUI();
            }
        }

        bool _isImageProcessing = false;
        /// <summary>
        /// Gets or sets a value indicating whether image is processing.
        /// </summary>
        bool IsImageProcessing
        {
            get
            {
                return _isImageProcessing;
            }
            set
            {
                _isImageProcessing = value;
                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region UI

        #region Add Images

        /// <summary>
        /// Handles the Click event of AddFromFileButton object.
        /// </summary>
        private void addFromFileButton_Click(object sender, EventArgs e)
        {
            // add image(s) from file
            AddImagesFromFiles();
        }

        /// <summary>
        /// Handles the Click event of AddFromScannerButton object.
        /// </summary>
        private void addFromScannerButton_Click(object sender, EventArgs e)
        {
            // add image(s) from scanner
            AddImageFromScanner();
        }

        #endregion


        #region Image Processing

        /// <summary>
        /// Handles the Click event of InvertButton object.
        /// </summary>
        private void invertButton_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommand(new InvertCommand());
        }

        /// <summary>
        /// Handles the Click event of AdaptiveBinarizeButton object.
        /// </summary>
        private void adaptiveBinarizeButton_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommand(new ChangePixelFormatToBlackWhiteCommand(BinarizationMode.Adaptive));
        }

        /// <summary>
        /// Handles the Click event of GlobalBinarizeButton object.
        /// </summary>
        private void globalBinarizeButton_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommand(new ChangePixelFormatToBlackWhiteCommand(BinarizationMode.Global));
        }

        /// <summary>
        /// Handles the Click event of ThresholdBinarizeButton object.
        /// </summary>
        private void thresholdBinarizeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int threshold = int.Parse(thresholdComboBox.Text, CultureInfo.InvariantCulture);
                ExecuteProcessingCommand(new ChangePixelFormatToBlackWhiteCommand(threshold));
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of RotateButton object.
        /// </summary>
        private void rotateButton_Click(object sender, EventArgs e)
        {
            try
            {
                double angle = double.Parse(rotateAngleComboBox.Text, CultureInfo.InvariantCulture);
                ExecuteProcessingCommand(new RotateCommand(angle));
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of RemoveTablesButton object.
        /// </summary>
        private void removeTablesButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ExecuteProcessingCommand(new LineRemovalCommand(LinesType.Tables));
#endif
        }

        /// <summary>
        /// Handles the Click event of AutoTextInvertButton object.
        /// </summary>
        private void autoTextInvertButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ExecuteProcessingCommand(new AutoTextInvertCommand());
#endif
        }

        /// <summary>
        /// Handles the Click event of AutoOrientationButton object.
        /// </summary>
        private void autoOrientationButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ExecuteProcessingCommand(new AutoTextOrientationCommand());
#endif
        }

        #endregion


        /// <summary>
        /// Handles the CheckedChanged event of OcrPreprocessingCheckBox object.
        /// </summary>
        private void ocrPreprocessingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ocrPreprocessingGroupBox.Enabled = ocrPreprocessingCheckBox.Checked;
        }

        /// <summary>
        /// Handles the Shown event of AddImagesForm object.
        /// </summary>
        private void AddImagesForm_Shown(object sender, EventArgs e)
        {
            if (OpenFileWhenShown)
                AddImagesFromFiles();

            if (ScanImageWhenShown)
                AddImageFromScanner();

            okButton.Focus();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the ThumbnailAdded event of ThumbnailViewer1 object.
        /// </summary>
        private void thumbnailViewer1_ThumbnailAdded(object sender, ThumbnailEventArgs e)
        {
            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the ThumbnailRemoved event of ThumbnailViewer1 object.
        /// </summary>
        private void thumbnailViewer1_ThumbnailRemoved(object sender, ThumbnailEventArgs e)
        {
            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of ButtonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            thumbnailViewer1.Images.ClearAndDisposeItems();
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (ocrPreprocessingCheckBox.Checked)
                ExecuteOcrPreprocessing();

            DialogResult = DialogResult.OK;
        }

        #endregion


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            // get the current status of application
            bool isImagesOpening = IsImageOpening;
            bool isImagesEmpty = Images.Count == 0;
            bool isImagesProcessing = IsImageProcessing;

            // Add from File...
            addFromFileButton.Enabled = !isImagesOpening && !isImagesProcessing;

            // Scan...
            addFromScannerButton.Enabled = !isImagesOpening && !isImagesProcessing;

            // Processing
            processingGroupBox.Enabled = !isImagesOpening && !isImagesProcessing && !isImagesEmpty;
            // "All Images" radio button
            allImagesRadioButton.Enabled = Images.Count > 1;
            // "Current Image" radio button
            if (Images.Count == 1)
                currentImageRadioButton.Checked = true;

            // OCR Preprocessing
            ocrPreprocessingGroupBox.Enabled = !isImagesOpening && !isImagesProcessing && !isImagesEmpty;

            // "OK" button
            okButton.Enabled = !isImagesOpening && !isImagesProcessing && !isImagesEmpty;

            // "Cancel" button
            buttonCancel.Enabled = !isImagesOpening && !isImagesProcessing;

            thumbnailViewer1.Enabled = !isImagesOpening && !isImagesProcessing;
            imageViewer1.Enabled = !isImagesOpening && !isImagesProcessing;
        }

        /// <summary>
        /// Adds image(s) from file.
        /// </summary>
        private void AddImagesFromFiles()
        {
            IsImageOpening = true;

            RenderingSettingsForm renderingSettings = null;

            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openImageFileDialog.FileNames.Length; i++)
                {
                    try
                    {
                        using (ImageCollection images = new ImageCollection())
                        {
                            DocumentPasswordForm.EnableAuthentication(images);
                            try
                            {
                                // load images
                                images.Add(openImageFileDialog.FileNames[i]);
                                // check images format
                                for (int j = 0; j < images.Count; j++)
                                {
                                    switch (images[j].PixelFormat)
                                    {
                                        case PixelFormat.Bgr555:
                                        case PixelFormat.Bgr565:
                                            ChangePixelFormatToBgrCommand to24 = new ChangePixelFormatToBgrCommand(PixelFormat.Bgr24);
                                            to24.ExecuteInPlace(images[j]);
                                            break;
                                    }
                                }

                                // if image is vector
                                if (images[0].SourceInfo.Decoder.IsVectorDecoder)
                                {
                                    // show rendering settings form
                                    if (renderingSettings == null)
                                    {
                                        renderingSettings = new RenderingSettingsForm(images[0].RenderingSettings);
                                        renderingSettings.ShowDialog();
                                    }

                                    // set rendering settings
                                    for (int j = 0; j < images.Count; j++)
                                        images[j].RenderingSettings = (RenderingSettings)renderingSettings.RenderingSettings.Clone();
                                }

                                // add images
                                thumbnailViewer1.Images.AddRange(images.ToArray());
                            }
                            finally
                            {
                                DocumentPasswordForm.DisableAuthentication(images);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
            }

            IsImageOpening = false;
        }

        /// <summary>
        /// Adds an image from scanner.
        /// </summary>
        private void AddImageFromScanner()
        {
            IsImageOpening = true;

            try
            {
                _simpleTwainManager.SelectDeviceAndAcquireImage();
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e);
            }

            IsImageOpening = false;
        }

        /// <summary>
        /// Handler of the OcrPreprocessingCommand.Progress event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageProcessingProgressEventArgs"/> instance containing the event data.</param>
        private void preprocessingCommand_Progress(object sender, ImageProcessingProgressEventArgs e)
        {
            currentImageProgressBar.Value = e.Progress;
        }

        /// <summary>
        /// Executes the OCR preprocessing.
        /// </summary>
        private void ExecuteOcrPreprocessing()
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            IsImageProcessing = true;
            OcrPreprocessingCommand preprocessingCommand = new OcrPreprocessingCommand();

            // leave only checked commands
            preprocessingCommand.Binarization = null;
            if (!autoInvertCheckBox.Checked)
                preprocessingCommand.AutomaticalInvert = null;
            if (!halftoneRemovalCheckBox.Checked)
                preprocessingCommand.HalftoneRemoval = null;
            if (!clearBorderCheckBox.Checked)
                preprocessingCommand.BorderClear = null;
            if (!despeckleCheckBox.Checked)
                preprocessingCommand.Despeckle = null;
            if (!deskewChekBox.Checked)
                preprocessingCommand.Deskew = null;
            if (!holePunchRemovalCheckBox.Checked)
                preprocessingCommand.HolePunchRemoval = null;
            if (!autoOrientationCheckBox.Checked)
                preprocessingCommand.AutomaticalOrientation = null;
            else
                preprocessingCommand.AutomaticalOrientation = new AutoTextOrientationCommand();

            if (!segmentationCheckBox.Checked)
            {
                preprocessingCommand.Segmentation = null;
            }
            else
            {
                _segmentationResults = new Dictionary<VintasoftImage, ReadOnlyCollection<ImageRegion>>();
                preprocessingCommand.Segmentation.BorderSize = 2;
            }

            if (preprocessingCommand.SupportedPixelFormats[0] == PixelFormat.Undefined)
                return;

            preprocessingCommand.Progress += new EventHandler<ImageProcessingProgressEventArgs>(preprocessingCommand_Progress);

            allImagesProgressBar.Value = 0;
            allImagesProgressBar.Maximum = Images.Count;

            // for each image
            for (int i = 0; i < Images.Count; i++)
            {
                allImagesProgressBar.Value = i + 1;
                try
                {
                    // execute processing command
                    preprocessingCommand.ExecuteInPlace(Images[i]);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }

                if (preprocessingCommand.Segmentation != null)
                {
                    _segmentationResults.Add(Images[i], preprocessingCommand.SegmentationTextRegions);
                }
                Application.DoEvents();
            }
            IsImageProcessing = false;
#endif
        }

        /// <summary>
        /// Executes the processing command.
        /// </summary>
        /// <param name="command">The processing command.</param>
        private void ExecuteProcessingCommand(ProcessingCommandBase command)
        {
            IsImageProcessing = true;

            try
            {
                if (currentImageRadioButton.Checked)
                {
                    if (imageViewer1.Image != null)
                    {
                        // execute command on current image
                        command.ExecuteInPlace(imageViewer1.Image);
                    }
                }
                else
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        // execute command on all images
                        command.ExecuteInPlace(Images[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            finally
            {
                IsImageProcessing = false;
            }
        }

        #endregion

    }
}
