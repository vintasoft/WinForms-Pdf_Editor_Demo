﻿using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.UI;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to edit the thumbnail viewer settings.
    /// </summary>
    public partial class ThumbnailViewerSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// The thumbnail viewer;
        /// </summary>
        ThumbnailViewer _viewer;

        /// <summary>
        /// The "Normal" appearance of thumbnail.
        /// </summary>
        ThumbnailAppearance _normalThumbnailAppearance;

        /// <summary>
        /// The "Focused" appearance of thumbnail.
        /// </summary>
        ThumbnailAppearance _focusedThumbnailAppearance;

        /// <summary>
        /// The "Hovered" appearance of thumbnail.
        /// </summary>
        ThumbnailAppearance _hoveredThumbnailAppearance;

        /// <summary>
        /// The "Selected" appearance of thumbnail.
        /// </summary>
        ThumbnailAppearance _selectedThumbnailAppearance;

        /// <summary>
        /// The "NotReady" appearance of thumbnail.
        /// </summary>
        ThumbnailAppearance _notReadyThumbnailAppearance;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ThumbnailViewerSettingsForm"/> class.
        /// </summary>
        /// <param name="viewer">The thumbnail viewer.</param>
        public ThumbnailViewerSettingsForm(ThumbnailViewer viewer)
            : this()
        {
            _viewer = viewer;
            _normalThumbnailAppearance = new ThumbnailAppearance(viewer.ThumbnailAppearance);
            _focusedThumbnailAppearance = new ThumbnailAppearance(viewer.FocusedThumbnailAppearance);
            _hoveredThumbnailAppearance = new ThumbnailAppearance(viewer.HoveredThumbnailAppearance);
            _selectedThumbnailAppearance = new ThumbnailAppearance(viewer.SelectedThumbnailAppearance);
            _notReadyThumbnailAppearance = new ThumbnailAppearance(viewer.NotReadyThumbnailAppearance);
            thumbnailAppearanceComboBox.SelectedIndex = 0;
            ShowSettings();
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="ThumbnailViewerSettingsForm"/> class.
        /// </summary>
        private ThumbnailViewerSettingsForm()
        {
            InitializeComponent();

            thumbnailFlowStyleComboBox.Items.Add(ThumbnailFlowStyle.WrappedRows);
            thumbnailFlowStyleComboBox.Items.Add(ThumbnailFlowStyle.SingleRow);
            thumbnailFlowStyleComboBox.Items.Add(ThumbnailFlowStyle.SingleColumn);
            thumbnailFlowStyleComboBox.Items.Add(ThumbnailFlowStyle.FixedColumns);

            thumbnailScaleComboBox.Items.Add(ThumbnailScale.Smallest);
            thumbnailScaleComboBox.Items.Add(ThumbnailScale.Small);
            thumbnailScaleComboBox.Items.Add(ThumbnailScale.Normal);
            thumbnailScaleComboBox.Items.Add(ThumbnailScale.Large);

            thumbnailAppearanceComboBox.Items.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_NORMAL);
            thumbnailAppearanceComboBox.Items.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_FOCUSED);
            thumbnailAppearanceComboBox.Items.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_HOVERED);
            thumbnailAppearanceComboBox.Items.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_SELECTED);
            thumbnailAppearanceComboBox.Items.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_NOT_READY);
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of ButtonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // if settings are updated
            if (SetSettings())
                DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of ThumbnailAppearanceComboBox object.
        /// </summary>
        private void thumbnailAppearanceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update thumbnail appearance
            InitAppearance(GetSelectedAppearance());
        }

        /// <summary>
        /// Handles the Click event of EditThumbnailAppearanceButton object.
        /// </summary>
        private void editThumbnailAppearanceButton_Click(object sender, EventArgs e)
        {
            // get selected appearance
            ThumbnailAppearance appearance = GetSelectedAppearance();

            // create appearance settings form
            using (ThumbnailAppearanceSettingsForm thumbnailAppearanceSettingsDialog =
                new ThumbnailAppearanceSettingsForm(appearance))
            {
                // if appearance is changed
                if (thumbnailAppearanceSettingsDialog.ShowDialog() == DialogResult.OK)
                    // init appearance
                    InitAppearance(appearance);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of ThumbnailFlowStyleComboBox object.
        /// </summary>
        private void thumbnailFlowStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if thumbanil flow style is fixel columns
            if ((ThumbnailFlowStyle)thumbnailFlowStyleComboBox.SelectedItem == ThumbnailFlowStyle.FixedColumns)
            {
                thumbnailColumnsCountComboBox.Enabled = true;
            }
            else
            {
                thumbnailColumnsCountComboBox.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of CaptionIsVisibleCheckBox object.
        /// </summary>
        private void captionIsVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if thumbnail caption must be shown
            if (captionIsVisibleCheckBox.Checked)
                thumbnailCaptionGroupBox.Enabled = true;
            else
                thumbnailCaptionGroupBox.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of CaptionFontSelectButton object.
        /// </summary>
        private void captionFontSelectButton_Click(object sender, EventArgs e)
        {
            // show caption font dialog
            captionFontDialog.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of CaptionFormatHelpButton object.
        /// </summary>
        private void captionFormatHelpButton_Click(object sender, EventArgs e)
        {
            // show information about ThumbnailCaption.CaptionFormat property
            MessageBox.Show(
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_EXAMPLESRN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_FILE_FILENAME_PAGE_PAGENUMBERRN +
                "'{ImageSizeMpx:f2} MPX'\n" +
                "\n" +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_LIST_OF_PREDEFINED_FORMAT_VARIABLESRN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_PAGELABEL_PAGE_LABELRN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_PAGENUMBER_PAGE_NUMBER_IN_SOURCE_IMAGE_FILERN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_PAGEINDEX_PAGE_INDEX_IN_SOURCE_IMAGE_FILERN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_IMAGENUMBER_IMAGE_NUMBER_IN_IMAGE_COLLECTIONRN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_IMAGEINDEX_IMAGE_INDEX_IN_IMAGE_COLLECTIONRN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_FILENAME_FILENAME_WITHOUT_DIRECTORYRN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_FULLFILENAME_FULL_FILENAMERN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_DIRECTORYNAME_DIRECTORY_NAMERN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_DECODERNAME_DECODER_NAMERN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_IMAGEWIDTHPX_SOURCE_IMAGE_WIDTH_IN_PIXELSRN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_IMAGEHEIGHTPX_SOURCE_IMAGE_HEIGHT_IN_PIXELSRN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_IMAGESIZEMPX_SOURCE_IMAGE_SIZE_IN_MEGAPIXELSRN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_IMAGEHRES_SOURCE_IMAGE_HORIZONTAL_RESOLUTION_IN_DPIRN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_IMAGEVRES_SOURCE_IMAGE_VERTICAL_RESOLUTION_IN_DPIRN +
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_IMAGEBITSPERPIXEL_SOURCE_IMAGE_BITS_PER_PIXEL,
                PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_THUMBNAILCAPTIONCAPTIONFORMAT_PROPERTY);
        }

        #endregion


        /// <summary>
        /// Shows the settings of thumbnail viewer.
        /// </summary>
        private void ShowSettings()
        {
            generateOnlyVisibleThumbnailsCheckBox.Checked = _viewer.GenerateOnlyVisibleThumbnails;
            thumbnailSizeComboBox.Text = String.Format("{0} x {1}",
                _viewer.ThumbnailSize.Width, _viewer.ThumbnailSize.Height);
            thumbnailFlowStyleComboBox.SelectedItem = _viewer.ThumbnailFlowStyle;
            thumbnailColumnsCountComboBox.SelectedIndex = _viewer.ThumbnailFixedColumnCount - 1;
            thumbnailScaleComboBox.SelectedItem = _viewer.ThumbnailScale;
            thumbnailViewerBackColorPanelControl.Color = _viewer.BackColor;
            thumbnailRenderingThreadCountNumericUpDown.Value = _viewer.ThumbnailRenderingThreadCount;
            imagePaddingEditorControl.PaddingValue = _viewer.ThumbnailImagePadding;
            thumbnailsAnchorEditorControl.SelectedAnchorType = _viewer.ThumbnailsAnchor;

            captionIsVisibleCheckBox.Checked = _viewer.ThumbnailCaption.IsVisible;

            captionPaddingFEditorControl.PaddingValue = _viewer.ThumbnailCaption.Padding;
            captionAnchorTypeEditor.SelectedAnchorType = _viewer.ThumbnailCaption.Anchor;
            captionFormatTextBox.Text = _viewer.ThumbnailCaption.CaptionFormat;
            captionTextColorPanelControl.Color = _viewer.ThumbnailCaption.TextColor;
            captionFontDialog.Font = _viewer.ThumbnailCaption.Font;

            showThumbnailCheckBoxCheckBox.Checked = _viewer.ShowThumbnailCheckBox;
            thumbnailControlAnchorTypeEditor.SelectedAnchorType = _viewer.ThumbnailControlAnchor;
            thumbnailControlPaddingFEditorControl.PaddingValue = _viewer.ThumbnailControlPadding;
        }

        /// <summary>
        /// Saves the settings of thumbnail viewer.
        /// </summary>
        private bool SetSettings()
        {
            _viewer.GenerateOnlyVisibleThumbnails = generateOnlyVisibleThumbnailsCheckBox.Checked;

            // Thumbnail Size
            try
            {
                string[] sizeStrings = thumbnailSizeComboBox.Text.Split('x');
                int width;
                int height;
                if (sizeStrings.Length == 1)
                {
                    width = Convert.ToInt32(sizeStrings[0]);
                    height = width;
                }
                else
                {
                    width = Convert.ToInt32(sizeStrings[0]);
                    height = Convert.ToInt32(sizeStrings[1]);
                }
                _viewer.ThumbnailSize = new Size(width, height);
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e);
                return false;
            }

            if ((ThumbnailFlowStyle)thumbnailFlowStyleComboBox.SelectedItem == ThumbnailFlowStyle.FixedColumns)
                _viewer.ThumbnailFixedColumnCount = (int)thumbnailColumnsCountComboBox.SelectedIndex + 1;
            _viewer.ThumbnailFlowStyle = (ThumbnailFlowStyle)thumbnailFlowStyleComboBox.SelectedItem;
            _viewer.ThumbnailScale = (ThumbnailScale)thumbnailScaleComboBox.SelectedItem;
            _viewer.BackColor = thumbnailViewerBackColorPanelControl.Color;
            _viewer.ThumbnailRenderingThreadCount = (int)thumbnailRenderingThreadCountNumericUpDown.Value;
            _viewer.ThumbnailsAnchor = thumbnailsAnchorEditorControl.SelectedAnchorType;

            _viewer.ThumbnailAppearance = _normalThumbnailAppearance;
            _viewer.FocusedThumbnailAppearance = _focusedThumbnailAppearance;
            _viewer.HoveredThumbnailAppearance = _hoveredThumbnailAppearance;
            _viewer.SelectedThumbnailAppearance = _selectedThumbnailAppearance;
            _viewer.NotReadyThumbnailAppearance = _notReadyThumbnailAppearance;

            _viewer.ThumbnailImagePadding = imagePaddingEditorControl.PaddingValue;

            _viewer.ThumbnailCaption.IsVisible = captionIsVisibleCheckBox.Checked;
            _viewer.ThumbnailCaption.Padding = captionPaddingFEditorControl.PaddingValue;
            _viewer.ThumbnailCaption.TextColor = captionTextColorPanelControl.Color;
            _viewer.ThumbnailCaption.CaptionFormat = captionFormatTextBox.Text;
            _viewer.ThumbnailCaption.Anchor = captionAnchorTypeEditor.SelectedAnchorType;
            _viewer.ThumbnailCaption.Font = captionFontDialog.Font;

            _viewer.ShowThumbnailCheckBox = showThumbnailCheckBoxCheckBox.Checked;
            _viewer.ThumbnailControlAnchor = thumbnailControlAnchorTypeEditor.SelectedAnchorType;
            _viewer.ThumbnailControlPadding = thumbnailControlPaddingFEditorControl.PaddingValue;

            return true;
        }

        /// <summary>
        /// Returns the selected appearance.
        /// </summary>
        private ThumbnailAppearance GetSelectedAppearance()
        {
            switch (thumbnailAppearanceComboBox.SelectedIndex)
            {
                case 0:
                    return _normalThumbnailAppearance;

                case 1:
                    return _focusedThumbnailAppearance;

                case 2:
                    return _hoveredThumbnailAppearance;

                case 3:
                    return _selectedThumbnailAppearance;

                case 4:
                    return _notReadyThumbnailAppearance;

                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Shows settings of the appearance.
        /// </summary>
        /// <param name="thumbnailAppearance">The appearance of thumbnail.</param>
        private void InitAppearance(ThumbnailAppearance thumbnailAppearance)
        {
            thumbnailAppearanceBackColorPanelControl.Color = thumbnailAppearance.BackColor;
            thumbnailAppearanceBorderColorPanelControl.Color = thumbnailAppearance.BorderColor;
            borderWidthValueLabel.Text = thumbnailAppearance.BorderWidth.ToString();
            borderStyleValueLabel.Text = thumbnailAppearance.BorderStyle.ToString();
        }

        #endregion

    }
}
