using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.UI;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Utils;

using DemosCommonCode.Imaging;
using DemosCommonCode.Pdf.Security;
using Vintasoft.Imaging.Text;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to create, manage and apply redaction marks to a PDF page.
    /// </summary>
    public partial class PdfRemoveContentControl : UserControl
    {

        #region Fields

        /// <summary>
        /// Indicates that this is the first build of redaction mark.
        /// </summary>
        bool _isFirstBuild = true;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfRemoveContentControl"/> class.
        /// </summary>
        public PdfRemoveContentControl()
        {
            InitializeComponent();

            removeAllToolStripButton.Tag = PdfRedactionMarkType.RemoveAll;
            removeAnnotationsToolStripButton.Tag = PdfRedactionMarkType.RemoveAnnotations;
            removeRasterGraphicsToolStripButton.Tag = PdfRedactionMarkType.RemoveRasterGraphics;
            removeTextToolStripButton.Tag = PdfRedactionMarkType.RemoveText;
            removeVectorGraphicsToolStripButton.Tag = PdfRedactionMarkType.RemoveVectorGraphics;
        }

        #endregion



        #region Properties

        PdfRemoveContentTool _removeContentTool = null;
        /// <summary>
        /// Gets or sets the remove content tool.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public PdfRemoveContentTool RemoveContentTool
        {
            get
            {
                return _removeContentTool;
            }
            set
            {
                if (_removeContentTool != null)
                    UnsubscribeFromVisualToolEvents(_removeContentTool);

                _removeContentTool = value;

                if (_removeContentTool != null)
                    SubscribeToVisualToolEvents(_removeContentTool);

                UpdateUI();
            }
        }

        TextSelectionTool _textSelectionTool = null;
        /// <summary>
        /// Gets or sets the text selection tool.
        /// </summary>
        public TextSelectionTool TextSelectionTool
        {
            get
            {
                return _textSelectionTool;
            }
            set
            {
                _textSelectionTool = value;
            }
        }

        ThumbnailViewer _thumbnailViewer = null;
        /// <summary>
        /// Gets or sets the thumbnail viewer.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public ThumbnailViewer ThumbnailViewer
        {
            get
            {
                return _thumbnailViewer;
            }
            set
            {
                _thumbnailViewer = value;
                markSelectedPagesFrmRedactionToolStripButton.Visible = _thumbnailViewer != null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the dialog for packing PDF document must be shown
        /// when mark is applied.
        /// </summary>
        public bool ShowPackDialogAfterMarkApplied
        {
            get
            {
                return showPackDialogAfterMarkAppliesCheckBox.Checked;
            }
        }

        /// <summary>
        /// Gets the current image of image viewer.
        /// </summary>
        private VintasoftImage CurrentImage
        {
            get
            {
                if (_removeContentTool == null ||
                    _removeContentTool.ImageViewer == null)
                    return null;

                return _removeContentTool.ImageViewer.Image;
            }
        }

        /// <summary>
        /// Gets the current PDF page.
        /// </summary>
        private PdfPage CurrentPage
        {
            get
            {
                VintasoftImage image = CurrentImage;
                if (image != null)
                    return PdfDocumentController.GetPageAssociatedWithImage(image);

                return null;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Updates the user interface of this control.
        /// </summary>
        private void UpdateUI()
        {
            mainPanel.Enabled =
                _removeContentTool != null &&
                _removeContentTool.ImageViewer != null &&
                _removeContentTool.ImageViewer.Image != null &&
                PdfDocumentController.GetPageAssociatedWithImage(_removeContentTool.ImageViewer.Image) != null;

            if (mainPanel.Enabled)
            {
                bool redactionMarkIsSelected = false;
                bool containsRedactionMarks = false;
                bool containsImage = CurrentImage != null;
                bool containsAppearance = false;

                if (_removeContentTool != null)
                {
                    redactionMarkIsSelected = _removeContentTool.FocusedSelectionItem != null;
                    containsRedactionMarks = _removeContentTool.Selection.Count > 0;
                    containsAppearance = _removeContentTool.RedactionMarkAppearance != null;
                }

                addRedactionMarkGroupBox.Enabled = containsImage;

                applyRedactionMarksToolStripButton.Enabled = containsRedactionMarks && containsImage;
                deleteSelectedRedactionMarkToolStripButton.Enabled = redactionMarkIsSelected;
                redactionMarkAppearancePropertiesToolStripButton.Enabled = containsImage && containsAppearance;
            }
        }


        /// <summary>
        /// Subscribes to the events of visual tool.
        /// </summary>
        /// <param name="removeContentTool">The remove content tool.</param>
        private void SubscribeToVisualToolEvents(PdfRemoveContentTool removeContentTool)
        {
            removeContentTool.Activated += new EventHandler(RemoveContentTool_Activated);
            removeContentTool.Deactivated += new EventHandler(RemoveContentTool_Deactivated);
            removeContentTool.SelectionChanged += new EventHandler(RemoveContentTool_SelectionChanged);
            removeContentTool.FocusedRectangleChanged += new PropertyChangedEventHandler<RedactionMark>(RemoveContentTool_FocusedRectangleChanged);
            removeContentTool.MouseDown += new VisualToolMouseEventHandler(RemoveContentTool_MouseDown);

            if (removeContentTool.ImageViewer != null)
                SubscribeToImageViewerEvents(removeContentTool.ImageViewer);
        }

        /// <summary>
        /// Unsubscribes from the events of visual tool.
        /// </summary>
        /// <param name="removeContentTool">The remove content tool.</param>
        private void UnsubscribeFromVisualToolEvents(PdfRemoveContentTool removeContentTool)
        {
            removeContentTool.Activated -= RemoveContentTool_Activated;
            removeContentTool.Deactivated -= RemoveContentTool_Deactivated;
            removeContentTool.SelectionChanged -= RemoveContentTool_SelectionChanged;
            removeContentTool.FocusedRectangleChanged -= RemoveContentTool_FocusedRectangleChanged;
            removeContentTool.MouseDown -= RemoveContentTool_MouseDown;

            if (removeContentTool.ImageViewer != null)
                UnsubscribeFromVisualToolEvents(removeContentTool.ImageViewer);
        }

        /// <summary>
        /// Subscribes to the events of viewer.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void SubscribeToImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged += new EventHandler<FocusedIndexChangedEventArgs>(imageViewer_FocusedIndexChanged);
        }

        /// <summary>
        /// Unsubscribes from the events of viewer.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void UnsubscribeFromVisualToolEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged -= imageViewer_FocusedIndexChanged;
        }


        #region 'Main' buttons

        /// <summary>
        /// Applies the redaction marks to the current PDF document.
        /// </summary>
        private void applyRedactionMarksToolStripButton_Click(object sender, EventArgs e)
        {
            // determines that the temporary redaction mark appearance must be reset
            bool createTemporaryAppearance = _removeContentTool.RedactionMarkAppearance == null;
            try
            {
                // get current PDF page
                PdfPage pdfPage = CurrentPage;
                // get current PDF document
                PdfDocument pdfDocument = pdfPage.Document;

                // if temporary redaction mark appearance must be created
                if (createTemporaryAppearance)
                    // create redaction mark appearance
                    _removeContentTool.RedactionMarkAppearance = new RedactionMarkAppearanceGraphicsFigure();

                // get redaction mark appearance
                RedactionMarkAppearanceGraphicsFigure appearance =
                    (RedactionMarkAppearanceGraphicsFigure)_removeContentTool.RedactionMarkAppearance;

                // determines that the redaction mark appearance text is drawn
                bool drawText = !string.IsNullOrEmpty(appearance.Text);

                // create the redaction mark appearance font must be created
                if (drawText && (appearance.Font == null || appearance.Font.Document != pdfDocument))
                    // create the redaction mark appearance font
                    appearance.Font = pdfDocument.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);

                // create a dialog that will show process progress
                using (ActionProgressForm progressForm = new ActionProgressForm(
                    ApplyRedactionMarks, 2, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_REMOVE_CONTENT_AND_BLACKOUT))
                {
                    // apply the redaction marks to the current PDF document
                    if (progressForm.RunAndShowDialog(this.ParentForm) != DialogResult.OK)
                    {
                        return;
                    }
                }

                if (RedactionMarkApplied != null)
                    // raise the RedactionMarkApplied event
                    RedactionMarkApplied(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            finally
            {
                // if temporary redaction mark appearance was created
                if (createTemporaryAppearance)
                    // remove the temporary redaction mark appearance
                    _removeContentTool.RedactionMarkAppearance = null;
                // update UI
                UpdateUI();
            }
        }

        /// <summary>
        /// Applies the redaction marks to PDF document.
        /// </summary>
        /// <param name="progressController">The progress controller.</param>
        private void ApplyRedactionMarks(IActionProgressController progressController)
        {
            RemoveContentTool.ApplyRedactionMarks(progressController);
            if (TextSelectionTool != null)
                TextSelectionTool.ClearSelection();
        }

        /// <summary>
        /// Marks the selected pages for redaction.
        /// </summary>
        private void markSelectedPagesFrmRedactionToolStripButton_Click(object sender, EventArgs e)
        {
            ImageViewer imageViewer = _removeContentTool.ImageViewer;
            if (imageViewer.Images.Count == 0)
                return;

            // get selected images
            VintasoftImage[] selectedImages = _thumbnailViewer.GetSelectedImages();
            // if images are NOT selected
            if (selectedImages.Length == 0)
                // get current image as selected image
                selectedImages = new VintasoftImage[] { imageViewer.Image };
            // for each selected image
            foreach (VintasoftImage image in selectedImages)
            {
                // get redaction marks of image
                IList<RedactionMark> redactionMarks = _removeContentTool.GetSelection(image);
                // remove redaction marks
                redactionMarks.Clear();
                // create new redaction mark for the whole image
                redactionMarks.Add(new PageRedactionMark(image));
                // if image is focused in image viewer
                if (image == imageViewer.Image)
                    // set focus in viewer to the first redaction mark of image
                    _removeContentTool.FocusedSelectionItem = redactionMarks[0];
            }
        }

        /// <summary>
        /// Deletes the selected redaction mark.
        /// </summary>
        private void deleteSelectedRedactionMarkToolStripButton_Click(object sender, EventArgs e)
        {
            _removeContentTool.DeleteAction.Execute();
        }

        /// <summary>
        /// Shows a form that allows to edit appearance of redaction mark.
        /// </summary>
        private void redactionMarkAppearancePropertiesToolStripButton_Click(object sender, EventArgs e)
        {
            using (RedactionMarkAppearanceEditor editorForm =
                new RedactionMarkAppearanceEditor(CurrentPage.Document,
                    (RedactionMarkAppearanceGraphicsFigure)_removeContentTool.RedactionMarkAppearance))
            {
                editorForm.ShowDialog();
            }
        }

        #endregion


        #region 'Add Redaction Mark' group

        /// <summary>
        /// Adds the redaction mark to a PDF page.
        /// </summary>
        private void AddRedactionMarkButton_Click(object sender, EventArgs e)
        {
            // get button
            ToolStripButton button = (ToolStripButton)sender;
            // get type of mark
            PdfRedactionMarkType markType = (PdfRedactionMarkType)button.Tag;

            bool setSelectedTextToRedactionMark =
                markType == PdfRedactionMarkType.RemoveText && TextSelectionTool != null && !string.IsNullOrEmpty(TextSelectionTool.SelectedText);

            if (_isFirstBuild && !setSelectedTextToRedactionMark)
            {
                string message =
                    PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_1_SELECT_THE_AREA_ON_PAGE + Environment.NewLine +
                    PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_2_PRESS_APPLY_REDACTION_MARKS_WHEN_THE_REDACTION_MARKS_MUST_BE_APPLIED_TO_THE_PAGE;
                MessageBox.Show(message, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isFirstBuild = false;
            }

            try
            {
                // if text must be added to the redaction 
                if (setSelectedTextToRedactionMark)
                {
                    // add selected text to the redaction marks
                    VintasoftImage[] imagesWithSelection = TextSelectionTool.GetSelectionImages();
                    foreach (VintasoftImage image in imagesWithSelection)
                    {
                        TextRegion selectedText = TextSelectionTool.GetSelectedRegion(image);
                        if (!selectedText.IsEmpty)
                        {
                            RemoveContentTool.Add(image, new TextRedactionMark(image, selectedText));
                        }
                    }
                    TextSelectionTool.ClearSelection();
                }
                else
                {
                    // create new mark
                    RedactionMark mark = new RedactionMark(CurrentImage);
                    mark.MarkType = markType;
                    // add and build mark
                    RemoveContentTool.AddAndBuild(mark);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_IMAGE_IS_NOT_PDF_PAGE)
                    MessageBox.Show(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_CURRENT_IMAGE_IS_NOT_PDF_PAGE_SAVE_DOCUMENT_AND_TRY_AGAIN, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_INFORMATION_ALT1,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Marks a content of selected page for removal.
        /// </summary>
        private void removeSelectedPageToolStripButton_Click(object sender, EventArgs e)
        {
            // get current image
            VintasoftImage image = CurrentImage;
            // get redaction marks of image
            IList<RedactionMark> redactionMarks = _removeContentTool.GetSelection(image);
            // clear redation marks
            redactionMarks.Clear();
            // create redaction mark of page
            redactionMarks.Add(new PageRedactionMark(image));
            // select new mark
            _removeContentTool.FocusedSelectionItem = redactionMarks[0];
        }

        #endregion


        #region Redaction mark list box

        /// <summary>
        /// Updates the list box of redaction marks.
        /// </summary>
        private void UpdateRedactionMarksListBox()
        {
            redactionMarksListBox.BeginUpdate();
            try
            {
                redactionMarksListBox.Items.Clear();

                if (_removeContentTool != null)
                {
                    foreach (RedactionMark mark in _removeContentTool.Selection)
                        redactionMarksListBox.Items.Add(GetRedactionMarkDescription(mark));
                }
            }
            finally
            {
                redactionMarksListBox.EndUpdate();
            }
        }

        /// <summary>
        /// Selected index of list box is changed.
        /// </summary>
        private void redactionMarksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get selected index
            int selectedIndex = redactionMarksListBox.SelectedIndex;
            // selected redaction mark
            RedactionMark selectedRedactionMark = null;

            // if redaction mark is selected
            if (selectedIndex != -1)
                // get selected mark
                selectedRedactionMark = _removeContentTool.Selection[selectedIndex];

            // set focused mark
            _removeContentTool.FocusedSelectionItem = selectedRedactionMark;
        }

        #endregion


        #region Visual Tool

        /// <summary>
        /// Visual tool is activated.
        /// </summary>
        private void RemoveContentTool_Activated(object sender, EventArgs e)
        {
            // get visual tool
            VisualTool visualTool = (VisualTool)sender;
            // subscribe to the events of visual tool
            SubscribeToImageViewerEvents(visualTool.ImageViewer);
            UpdateUI();
        }

        /// <summary>
        /// Visual tool is deactivated.
        /// </summary>
        private void RemoveContentTool_Deactivated(object sender, EventArgs e)
        {
            // get visual tool
            VisualTool visualTool = (VisualTool)sender;
            // unsubscribe from events of visual tool
            UnsubscribeFromVisualToolEvents(visualTool.ImageViewer);

            mainPanel.Enabled = false;
        }

        /// <summary>
        /// Visual tool selection is changed.
        /// </summary>
        private void RemoveContentTool_SelectionChanged(object sender, EventArgs e)
        {
            UpdateRedactionMarksListBox();
            UpdateUI();
        }

        /// <summary>
        /// Focused rectangle of visual tool is changed.
        /// </summary>
        private void RemoveContentTool_FocusedRectangleChanged(
            object sender,
            PropertyChangedEventArgs<RedactionMark> e)
        {
            // find focused mark
            int index = _removeContentTool.Selection.IndexOf(e.NewValue);

            // if selected index is changed
            if (redactionMarksListBox.SelectedIndex != index)
                redactionMarksListBox.SelectedIndex = index;

            // update user interface
            UpdateUI();
        }

        /// <summary>
        /// Mouse is down.
        /// </summary>
        private void RemoveContentTool_MouseDown(object sender, VisualToolMouseEventArgs e)
        {
            // if visual tool is enabled and the right mouse button is pressed
            if (Enabled && mainPanel.Enabled && e.Button == MouseButtons.Right)
            {
                RedactionMark selectedMark = null;
                // get image viewer
                ImageViewer imageViewer = _removeContentTool.ImageViewer;
                IList<RedactionMark> selection = _removeContentTool.Selection;
                if (selection.Count > 0)
                {
                    IInteractiveObject interactiveObject;
                    for (int i = selection.Count - 1; i >= 0; i--)
                    {
                        interactiveObject = (IInteractiveObject)selection[i];
                        PointFTransform transform = interactiveObject.GetPointTransform(imageViewer, imageViewer.Image).GetInverseTransform();
                        PointF point = transform.TransformPoint(e.Location);
                        if (interactiveObject.IsPointOnObject(point.X, point.Y))
                        {
                            selectedMark = selection[i];
                            break;
                        }
                    }
                }

                ContextMenuStrip contextMenu = redactionMarkContextMenuStrip;
                if (selectedMark == null)
                    contextMenu = imageViewerContextMenuStrip;

                _removeContentTool.FocusedSelectionItem = selectedMark;
                contextMenu.Show(imageViewer, e.Location);
                e.Handled = true;
            }
        }

        #endregion


        #region Context Menu

        #region Remove content control

        /// <summary>
        /// Context menu strip of redaction mark is opening.
        /// </summary>
        private void redactionMarkContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _removeContentTool == null;

            cutToolStripMenuItem.Enabled = _removeContentTool.CutAction.IsEnabled;
            copyToolStripMenuItem.Enabled = _removeContentTool.CopyAction.IsEnabled;
            pasteToolStripMenuItem.Enabled = _removeContentTool.PasteAction.IsEnabled;
            deleteToolStripMenuItem.Enabled = _removeContentTool.DeleteAction.IsEnabled;
        }

        /// <summary>
        /// Cuts redaction mark.
        /// </summary>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _removeContentTool.CutAction.Execute();
        }

        /// <summary>
        /// Copies redaction mark.
        /// </summary>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _removeContentTool.CopyAction.Execute();
        }

        /// <summary>
        /// Pastes redaction mark.
        /// </summary>
        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _removeContentTool.PasteAction.Execute();
        }

        /// <summary>
        /// Deletes redaction mark.
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _removeContentTool.DeleteAction.Execute();
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Focused image is changed.
        /// </summary>
        private void imageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Context menu of image viewer is opening.
        /// </summary>
        private void imageViewerContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            imageViewerPasteToolStripMenuItem.Enabled = _removeContentTool.PasteAction.IsEnabled;
            imageViewerRemoveAllToolStripMenuItem.Enabled = redactionMarksListBox.Items.Count > 0;
        }

        /// <summary>
        /// Pastes a redaction mark.
        /// </summary>
        private void imageViewerPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _removeContentTool.PasteAction.Execute();
        }

        /// <summary>
        /// Removes all redaction marks.
        /// </summary>
        private void imageViewerRemoveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _removeContentTool.Selection.Clear();
        }

        #endregion

        #endregion


        #region Common

        /// <summary>
        /// Returns the description of redaction mark.
        /// </summary>
        /// <param name="mark">The mark.</param>
        private string GetRedactionMarkDescription(RedactionMark mark)
        {
            return string.Format("{0}", mark.MarkType);
        }

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when redaction mark is applied.
        /// </summary>
        public event EventHandler RedactionMarkApplied;

        #endregion

    }
}
