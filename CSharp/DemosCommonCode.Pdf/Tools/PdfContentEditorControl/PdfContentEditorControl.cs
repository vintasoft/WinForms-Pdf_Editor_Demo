using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.UI;
using Vintasoft.Imaging.Undo;
using Vintasoft.Imaging.Drawing.Gdi;
#if !REMOVE_OFFICE_PLUGIN
using Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction;
#endif
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Office;
using Vintasoft.Imaging.Pdf.Content;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to create and manage graphics figures,
    /// created graphics figures can be added to the content of PDF page.
    /// </summary>
    public partial class PdfContentEditorControl : UserControl
    {

        #region Fields

        /// <summary>
        /// The text of text box.
        /// </summary>
        string _addText = "";

        /// <summary>
        /// The pen of graphics figure.
        /// </summary>
        PdfPen _pen;

        /// <summary>
        /// The brush of graphics figure.
        /// </summary>
        PdfBrush _brush;

        /// <summary>
        /// The selected mode of higlight pen.
        /// </summary>
        int _selectHighlightPenDialogModeIndex = 0;

        /// <summary>
        /// The open image file dialog.
        /// </summary>
        OpenFileDialog _openImageFileDialog = new OpenFileDialog();

#if !REMOVE_OFFICE_PLUGIN
        /// <summary>
        /// The last built chart figure.
        /// </summary>
        OfficeDocumentFigure _chartFigure;

        /// <summary>
        /// The last built formatted text figure.
        /// </summary>
        OfficeDocumentFigure _formattedTextFigure;
#endif

        /// <summary>
        /// The context menu location.
        /// </summary>
        Point _contextMenuLocation;

        /// <summary>
        /// The undo manager.
        /// </summary>
        UndoManager _undoManager = new UndoManager(20);

        /// <summary>
        /// The undo monitor.
        /// </summary>
        PdfContentEditorToolUndoMonitor _undoMonitor;

        /// <summary>
        /// A value indicating whether undo or redo operation is executing.
        /// </summary>
        bool _isUndoRedoExecuting = false;

        /// <summary>
        /// Dictionary: tool strip button => figure content type.
        /// </summary>
        Dictionary<ToolStripButton, GraphicsFigureContentType> buttonToFigureContentType =
            new Dictionary<ToolStripButton, GraphicsFigureContentType>();

        /// <summary>
        /// A value indicating whether the figure content type buttons are updating.
        /// </summary>
        bool _isFigureContentTypeButtonUpdating = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfContentEditorControl"/> class.
        /// </summary>
        public PdfContentEditorControl()
        {
            InitializeComponent();

            CodecsFileFilters.SetOpenFileDialogFilter(_openImageFileDialog);

            buttonToFigureContentType.Add(textContentToolStripButton, GraphicsFigureContentType.Text);
            buttonToFigureContentType.Add(imageContentToolStripButton, GraphicsFigureContentType.Image);
            buttonToFigureContentType.Add(strokePathContentToolStripButton, GraphicsFigureContentType.StrokePath);
            buttonToFigureContentType.Add(fillPathContentToolStripButton, GraphicsFigureContentType.FillPath);
            buttonToFigureContentType.Add(shadingFillContentToolStripButton, GraphicsFigureContentType.ShadingFill);
            buttonToFigureContentType.Add(clipContentToolStripButton, GraphicsFigureContentType.SetClip);
            buttonToFigureContentType.Add(formContentToolStripButton, GraphicsFigureContentType.Form);

            _undoManager.Changed += UndoManager_Changed;
        }

        #endregion



        #region Properties

        PdfContentEditorTool _contentEditorTool = null;
        /// <summary>
        /// Gets or sets the content editor tool.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public PdfContentEditorTool ContentEditorTool
        {
            get
            {
                return _contentEditorTool;
            }
            set
            {
                // if content editor tool is not empty
                if (_contentEditorTool != null)
                {
                    // unsubscribe from events of content editor tool
                    UnsubscribeFromContentEditorToolEvents(_contentEditorTool);

                    // clear undo manager
                    _undoManager.Clear();

                    if (_undoMonitor != null)
                    {
                        _undoMonitor.Dispose();
                        _undoMonitor = null;
                    }
                }

                // set new content editor tool
                _contentEditorTool = value;

                // if content editor tool is not empty
                if (_contentEditorTool != null)
                {
                    _contentEditorTool.AppendMode = false;
                    _contentEditorTool.FiguresHighlight = true;
                    // set InteractiveContentType
                    _contentEditorTool.InteractiveContentType =
                        GraphicsFigureContentType.Text |
                        GraphicsFigureContentType.Image |
                        GraphicsFigureContentType.Form |
                        GraphicsFigureContentType.StrokePath |
                        GraphicsFigureContentType.FillPath;
                    // subscribe to the events of content editor tool
                    SubscribeToContentEditorToolEvents(_contentEditorTool);
                    // update the list box
                    UpdateFiguresListBox();

                    // create undo monitor
                    _contentEditorTool.UndoManager = _undoManager;
                    _undoMonitor = new PdfContentEditorToolUndoMonitor(_undoManager, _contentEditorTool);
                }

                UpdateUI();
            }
        }

        /// <summary>
        /// Gets the PDF page, which is associated with image loaded in image viewer.
        /// </summary>
        private PdfPage FocusedPage
        {
            get
            {
                if (_contentEditorTool != null)
                    return _contentEditorTool.CurrentPage;

                return null;
            }
        }

#if !REMOVE_OFFICE_PLUGIN
        OfficeDocumentVisualEditor _documentVisualEditor;
        /// <summary>
        /// Gets or sets the visual editor for Office document.
        /// </summary>
        OfficeDocumentVisualEditor DocumentVisualEditor
        {
            get
            {
                return _documentVisualEditor;
            }
            set
            {
                if (_documentVisualEditor != null)
                    _documentVisualEditor.EditingException -= DocumentVisualEditor_EditingException;

                _documentVisualEditor = value;

                if (_documentVisualEditor != null)
                    _documentVisualEditor.EditingException += DocumentVisualEditor_EditingException;

            }
        }
#endif

        #endregion



        #region Methods

        /// <summary>
        /// Updates the user interface of this control.
        /// </summary>
        internal void UpdateUI()
        {
            bool isPdfPage = FocusedPage != null;

            mainPanel.Enabled = _contentEditorTool != null && isPdfPage;
            figuresGroupBox.Enabled = isPdfPage;
            renderFiguresButton.Enabled = _contentEditorTool != null && _contentEditorTool.GetNonContentFigures().Length > 0;
            removeButton.Enabled = _contentEditorTool != null && _contentEditorTool.SelectedFigure != null;
            removeAllButton.Enabled = figuresListBox.Items.Count > 0;
            appendModeToolStripButton.Checked = _contentEditorTool != null && _contentEditorTool.AppendMode;
            groupContentFiguresToolStripButton.Checked = _contentEditorTool != null && _contentEditorTool.GroupContentFigures;
            highlightToolStripButton.Checked = _contentEditorTool != null && _contentEditorTool.FiguresHighlight;
            bool graphicalContentFigureSelected = false;
            bool canEditTextFigure = false;
            if (_contentEditorTool != null)
            {
                if (_contentEditorTool.SelectedFigure is ContentStreamGraphicsFigure)
                    graphicalContentFigureSelected = true;
                else if (_contentEditorTool.SelectedFigure is ContentStreamGraphicsFigureGroup)
                    graphicalContentFigureSelected = (_contentEditorTool.SelectedFigure.ContentType & GraphicsFigureContentType.Text) == 0;

                canEditTextFigure = CanEditTextFigure(_contentEditorTool.SelectedFigureView);

                _isFigureContentTypeButtonUpdating = true;
                foreach (ToolStripButton toolStripButton in buttonToFigureContentType.Keys)
                {
                    if (_contentEditorTool.InteractiveContentType == GraphicsFigureContentType.Any ||
                        (_contentEditorTool.InteractiveContentType & buttonToFigureContentType[toolStripButton]) != 0)
                        toolStripButton.Checked = true;
                    else
                        toolStripButton.Checked = false;
                }
                _isFigureContentTypeButtonUpdating = false;
            }
            verticalMirrorToolStripButton.Enabled = graphicalContentFigureSelected;
            horizontalMirrorToolStripButton.Enabled = graphicalContentFigureSelected;
            rotateClockwiseToolStripButton.Enabled = graphicalContentFigureSelected;
            rotateCounterclockwiseToolStripButton.Enabled = graphicalContentFigureSelected;
            addRectangleClipToolStripButton.Enabled = graphicalContentFigureSelected && (_contentEditorTool.SelectedFigure.ContentType & GraphicsFigureContentType.SetClip) == 0;
            addEllipseClipToolStripButton.Enabled = addRectangleClipToolStripButton.Enabled;
            replaceResourceToolStripButton.Enabled = graphicalContentFigureSelected && GetXObjectFigure(_contentEditorTool.SelectedFigure) != null;
            editTextObjectToolStripButton.Enabled = canEditTextFigure;
            contentGraphicsPropertiesToolStripButton.Enabled = _contentEditorTool != null && CanEditContentGraphicsProperties(_contentEditorTool.SelectedFigure);

            UpdateUndoUI();
        }

        /// <summary>
        /// Returns a value indicating whether the content graphics properties of specified figure can be edited.
        /// </summary>
        /// <param name="figure">The figure.</param>
        /// <returns>
        /// <b>True</b> if content graphics properties of specified figure can be edited; otherwise, <b>false</b>.
        /// </returns>
        private bool CanEditContentGraphicsProperties(GraphicsFigure figure)
        {
            if (figure != null && figure.IsContentFigure)
            {
                if ((figure.ContentType & GraphicsFigureContentType.FillPath) != 0)
                    return true;
                if ((figure.ContentType & GraphicsFigureContentType.StrokePath) != 0)
                    return true;
                if ((figure.ContentType & GraphicsFigureContentType.Text) != 0)
                    return true;
                if ((figure.ContentType & GraphicsFigureContentType.Image) != 0)
                    return true;
                if ((figure.ContentType & GraphicsFigureContentType.Form) != 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a value indicating whether text of specified graphics figure can be edited.
        /// </summary>
        /// <param name="figureView">The figure view.</param>
        /// <returns>A value indicating whether text of specified graphics figure can be edited.</returns>
        private bool CanEditTextFigure(GraphicsFigureView figureView)
        {
#if !REMOVE_OFFICE_PLUGIN
            if (figureView is OfficeContentStreamGraphicsFigureTextGroupView)
                return true;
            if (figureView is OfficeDocumentFigureView)
                return true;
#endif
            if (figureView is ContentStreamGraphicsFigureView &&
                figureView.Figure.ContentType == GraphicsFigureContentType.Text)
                return true;
            return false;
        }

        /// <summary>
        /// Subscribes to the events of content editor tool.
        /// </summary>
        /// <param name="contentEditorTool">The content editor tool.</param>
        private void SubscribeToContentEditorToolEvents(PdfContentEditorTool contentEditorTool)
        {
            contentEditorTool.Activated += new EventHandler(ContentEditorTool_Activated);
            contentEditorTool.Deactivated += new EventHandler(ContentEditorTool_Deactivated);
            contentEditorTool.SelectedFigureViewChanged += new EventHandler(ContentEditorTool_SelectedFigureViewChanged);
            contentEditorTool.FigureViewCollectionChanged += new EventHandler(ContentEditorTool_FigureViewCollectionChanged);
            contentEditorTool.MouseDown += new VisualToolMouseEventHandler(ContentEditorTool_MouseDown);
            contentEditorTool.MouseDoubleClick += new VisualToolMouseEventHandler(ContentEditorTool_MouseDoubleClick);
            contentEditorTool.FigureBuildingFinished += ContentEditorTool_FigureBuildingFinished;
            contentEditorTool.KeyDown += ContentEditorTool_KeyDown;
            contentEditorTool.ActiveInteractionControllerChanged += ContentEditorTool_ActiveInteractionControllerChanged;

            if (contentEditorTool.ImageViewer != null)
                SubscribeToImageViewerEvents(contentEditorTool.ImageViewer);
        }

        /// <summary>
        /// Unsubscribes from the events of content editor tool.
        /// </summary>
        /// <param name="contentEditorTool">The content editor tool.</param>
        private void UnsubscribeFromContentEditorToolEvents(PdfContentEditorTool contentEditorTool)
        {
            contentEditorTool.Activated -= ContentEditorTool_Activated;
            contentEditorTool.Deactivated -= ContentEditorTool_Deactivated;
            contentEditorTool.SelectedFigureViewChanged += ContentEditorTool_SelectedFigureViewChanged;
            contentEditorTool.FigureViewCollectionChanged -= ContentEditorTool_FigureViewCollectionChanged;
            contentEditorTool.MouseDown -= ContentEditorTool_MouseDown;
            contentEditorTool.MouseDoubleClick -= ContentEditorTool_MouseDoubleClick;
            contentEditorTool.FigureBuildingFinished -= ContentEditorTool_FigureBuildingFinished;
            contentEditorTool.KeyDown -= ContentEditorTool_KeyDown;
            contentEditorTool.ActiveInteractionControllerChanged -= ContentEditorTool_ActiveInteractionControllerChanged;

            if (contentEditorTool.ImageViewer != null)
                UnsubscribeFromImageViewerEvents(contentEditorTool.ImageViewer);
        }

        /// <summary>
        /// Subscribes to the events of image viewer.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void SubscribeToImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged += new EventHandler<FocusedIndexChangedEventArgs>(ImageViewer_FocusedIndexChanged);
            imageViewer.FocusedIndexChanging += new EventHandler<FocusedIndexChangedEventArgs>(imageViewer_FocusedIndexChanging);
        }

        /// <summary>
        /// Unsubscribes from the events of image viewer.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void UnsubscribeFromImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged -= ImageViewer_FocusedIndexChanged;
            imageViewer.FocusedIndexChanging -= imageViewer_FocusedIndexChanging;
        }

        /// <summary>
        /// Focused image is changing.
        /// </summary>
        private void imageViewer_FocusedIndexChanging(object sender, FocusedIndexChangedEventArgs e)
        {
            if (figuresListBox.Items.Count > 0)
                figuresListBox.Items.Clear();
        }

        /// <summary>
        /// Focused image is changed.
        /// </summary>
        void ImageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Renders figures on a PDF page.
        /// </summary>
        private void renderFiguresButton_Click(object sender, EventArgs e)
        {
            try
            {
                _contentEditorTool.RenderFiguresOnPage();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }


        #region Graphics figure list box

        /// <summary>
        /// Updates the list box of graphics figures.
        /// </summary>
        private void UpdateFiguresListBox()
        {
            figuresListBox.BeginUpdate();
            try
            {
                int index = 0;
                foreach (GraphicsFigureView view in _contentEditorTool.FigureViewCollection)
                {
                    if (view.IsEnabled)
                    {
                        GraphicsFigureViewItem item = new GraphicsFigureViewItem(view);
                        // add description to list box
                        if (index < figuresListBox.Items.Count)
                            figuresListBox.Items[index] = item;
                        else
                            figuresListBox.Items.Add(item);
                        index++;
                    }
                }
                while (index < figuresListBox.Items.Count)
                    figuresListBox.Items.RemoveAt(figuresListBox.Items.Count - 1);
            }
            finally
            {
                figuresListBox.EndUpdate();
            }
        }

        /// <summary>
        /// Selected figure in figures list is changed.
        /// </summary>
        private void figuresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (figuresListBox.SelectedIndex == -1)
            {
                _contentEditorTool.SelectedFigureView = null;
            }
            else
            {
                GraphicsFigureViewItem graphicsFigureView = (GraphicsFigureViewItem)figuresListBox.Items[figuresListBox.SelectedIndex];
                _contentEditorTool.SelectedFigureView = graphicsFigureView.FigureView;
            }
        }

        #endregion


        #region Content editor tool

        /// <summary>
        /// Handles the Click event of EditTextObjectToolStripButton object.
        /// </summary>
        private void editTextObjectToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {

                GraphicsFigureView figureView = _contentEditorTool.SelectedFigureView;
#if !REMOVE_OFFICE_PLUGIN
                if (figureView is OfficeContentStreamGraphicsFigureTextGroupView)
                {
                    OfficeDocumentFigureView view = ((OfficeContentStreamGraphicsFigureTextGroupView)_contentEditorTool.SelectedFigureView).ConvertToOfficeDocumentFigure(_contentEditorTool.ImageViewer);
                    view.DocumentVisualEditor.EnableEditing(null);
                }
                else if (figureView is OfficeDocumentFigureView)
                {
                    ((OfficeDocumentFigureView)figureView).DocumentVisualEditor.EnableEditing(null);
                }
                else
#endif
                if (figureView is ContentStreamGraphicsFigureView && figureView.Figure.ContentType == GraphicsFigureContentType.Text)
                {
                    ((ContentStreamGraphicsFigureView)figureView).EnableTextEditing(_contentEditorTool.ImageViewer);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of HorizontalMirrorToolStripButton object.
        /// </summary>
        private void horizontalMirrorToolStripButton_Click(object sender, EventArgs e)
        {
            // change the horizontal mirroring of selected figure

            GraphicsFigureView figureView = ContentEditorTool.SelectedFigureView;
            RegionF region = figureView.Figure.GetRegion();
            AffineMatrix transform = AffineMatrix.CreateScaling(-1, 1, region.Center.X, region.Center.Y);
            ContentEditorTool.TransformFigure(figureView, transform);
        }

        /// <summary>
        /// Handles the Click event of VerticalMirrorToolStripButton object.
        /// </summary>
        private void verticalMirrorToolStripButton_Click(object sender, EventArgs e)
        {
            // change the vertical mirroring of selected figure

            GraphicsFigureView figureView = ContentEditorTool.SelectedFigureView;
            RegionF region = figureView.Figure.GetRegion();
            AffineMatrix transform = AffineMatrix.CreateScaling(1, -1, region.Center.X, region.Center.Y);
            ContentEditorTool.TransformFigure(figureView, transform);
        }

        /// <summary>
        /// Handles the Click event of RotateClockwiseToolStripButton object.
        /// </summary>
        private void rotateClockwiseToolStripButton_Click(object sender, EventArgs e)
        {
            // rotate clockwise the selected figure

            GraphicsFigureView figureView = ContentEditorTool.SelectedFigureView;
            RegionF region = figureView.Figure.GetRegion();
            AffineMatrix transform = AffineMatrix.CreateRotation(-90, region.Center.X, region.Center.Y);
            ContentEditorTool.TransformFigure(figureView, transform);
        }

        /// <summary>
        /// Handles the Click event of RotateCounterclockwiseToolStripButton object.
        /// </summary>
        private void rotateCounterclockwiseToolStripButton_Click(object sender, EventArgs e)
        {
            // rotate counterclockwise the selected figure

            GraphicsFigureView figureView = ContentEditorTool.SelectedFigureView;
            RegionF region = figureView.Figure.GetRegion();
            AffineMatrix transform = AffineMatrix.CreateRotation(90, region.Center.X, region.Center.Y);
            ContentEditorTool.TransformFigure(figureView, transform);
        }

        /// <summary>
        /// Handles the Click event of AddRectangularClipToolStripButton object.
        /// </summary>
        private void addRectangularClipToolStripButton_Click(object sender, EventArgs e)
        {
            // adds rectagular clip to the selected figure

            GraphicsFigureView figureView = ContentEditorTool.SelectedFigureView;
            using (GdiGraphicsPath clipPath = new GdiGraphicsPath())
            {
                clipPath.AddPolygon(figureView.Figure.GetRegion().ToPolygon());
                ContentEditorTool.AddFigureClip(ContentEditorTool.SelectedFigureView, clipPath);
            }
        }

        /// <summary>
        /// Handles the Click event of AddEllipseCliptoolStripMenuItem object.
        /// </summary>
        private void addEllipseCliptoolStripMenuItem_Click(object sender, EventArgs e)
        {
            // adds elliptical clip to the selected figure

            GraphicsFigureView figureView = ContentEditorTool.SelectedFigureView;
            using (GdiGraphicsPath clipPath = new GdiGraphicsPath())
            {
                clipPath.AddEllipse(figureView.Figure.GetRegion().Bounds);
                ContentEditorTool.AddFigureClip(ContentEditorTool.SelectedFigureView, clipPath);
            }
        }

        /// <summary>
        /// Handles the Click event of ContentGraphicsPropertiesToolStripButton object.
        /// </summary>
        private void contentGraphicsPropertiesToolStripButton_Click(object sender, EventArgs e)
        {
            EditContentGraphicsProperties(_contentEditorTool.SelectedFigureView);
        }

        /// <summary>
        /// Handles the CheckedChanged event of AppendModeCheckBox object.
        /// </summary>
        private void appendModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ContentEditorTool != null)
                ContentEditorTool.AppendMode = appendModeToolStripButton.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of GroupContentFiguresToolStripButton object.
        /// </summary>
        private void groupContentFiguresToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ContentEditorTool != null)
                ContentEditorTool.GroupContentFigures = groupContentFiguresToolStripButton.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of HighlightCheckBox object.
        /// </summary>
        private void highlightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ContentEditorTool != null)
                ContentEditorTool.FiguresHighlight = highlightToolStripButton.Checked;
        }

        /// <summary>
        /// Content editor tool is activated.
        /// </summary>
        private void ContentEditorTool_Activated(object sender, EventArgs e)
        {
            // update list box
            UpdateFiguresListBox();

            // get the content editor tool
            PdfContentEditorTool visualTool = (PdfContentEditorTool)sender;
            // subscribe to events of content editor tool
            SubscribeToImageViewerEvents(visualTool.ImageViewer);

            // update user interface
            UpdateUI();
        }

        /// <summary>
        /// Content editor tool is deactivated.
        /// </summary>
        private void ContentEditorTool_Deactivated(object sender, EventArgs e)
        {
            // clear list box
            figuresListBox.Items.Clear();

            // get the content editor tool
            PdfContentEditorTool visualTool = (PdfContentEditorTool)sender;
            // unsubscribe from events of content editor tool
            UnsubscribeFromImageViewerEvents(visualTool.ImageViewer);

            // disable control
            mainPanel.Enabled = false;
        }

        /// <summary>
        /// Selected view of figure is changed.
        /// </summary>
        private void ContentEditorTool_SelectedFigureViewChanged(object sender, EventArgs e)
        {
            // if control is enabled
            if (Enabled && mainPanel.Enabled)
            {
                GraphicsFigureView selectedView = _contentEditorTool.SelectedFigureView;
                foreach (GraphicsFigureViewItem item in figuresListBox.Items)
                {
                    if (item.FigureView == selectedView)
                    {
                        figuresListBox.SelectedItem = item;
                        break;
                    }
                }
                UpdateUI();
            }
        }

        /// <summary>
        /// Collection of views is changed.
        /// </summary>
        private void ContentEditorTool_FigureViewCollectionChanged(object sender, EventArgs e)
        {
            UpdateUI();
            UpdateFiguresListBox();
        }

        /// <summary>
        /// Handles the FigureBuildingFinished event of the ContentEditorTool.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ContentEditorTool_FigureBuildingFinished(object sender, EventArgs e)
        {
#if !REMOVE_OFFICE_PLUGIN
            // if selected figure is chart figure
            if (_contentEditorTool.SelectedFigure == _chartFigure)
            {
                // show chart data editor dialog

                _contentEditorTool.SelectedFigureView.InteractionController = _contentEditorTool.SelectedFigureView.Transformer;
                OfficeDocumentVisualEditor visualEditor = CompositeInteractionController.FindInteractionController<OfficeDocumentVisualEditor>(_contentEditorTool.SelectedFigureView.InteractionController);
                if (visualEditor != null)
                {
                    OpenXmlDocumentChartDataForm chartForm = new OpenXmlDocumentChartDataForm();
                    chartForm.Location = FindForm().Location;
                    chartForm.VisualEditor = visualEditor;
                    chartForm.ShowDialog();
                }
            }
            // if selected figure is formatted text figure
            else if (_contentEditorTool.SelectedFigure == _formattedTextFigure)
            {
                // start editing of formatted text

                _contentEditorTool.SelectedFigureView.InteractionController = _contentEditorTool.SelectedFigureView.Transformer;
                OfficeDocumentVisualEditor visualEditor = CompositeInteractionController.FindInteractionController<OfficeDocumentVisualEditor>(_contentEditorTool.SelectedFigureView.InteractionController);
                if (visualEditor != null)
                {
                    visualEditor.EnableEditing(null);
                }
            }
#endif
        }

        /// <summary>
        /// Mouse is down.
        /// </summary>
        private void ContentEditorTool_MouseDown(object sender, VisualToolMouseEventArgs e)
        {
            // if control is enabled and the right mouse button is pressed
            if (Enabled && mainPanel.Enabled && e.Button == MouseButtons.Right)
            {
                // get image viewer
                ImageViewer viewer = e.Viewer;
                // get focused page
                PdfPage page = FocusedPage;

                // convert point to image space
                PointF[] points = new PointF[] { viewer.PointToImageF(e.Location) };
                // convert point to PDF page space
                page.PointsFromImageSpaceToPageSpace(points, viewer.Image.Resolution);

                // get selected view
                GraphicsFigureView view = _contentEditorTool.SelectedFigureView;
                // get point on a PDF page
                PointF point = points[0];
                // if view is empty 
                if (view == null || !view.IsPointOnObject(point.X, point.Y))
                {
                    view = null;
                    // find view
                    foreach (GraphicsFigureView currentView in _contentEditorTool.FigureViewCollection)
                    {
                        if (currentView.IsPointOnObject(point.X, point.Y))
                        {
                            view = currentView;
                            break;
                        }
                    }
                }

                // update selected figure
                _contentEditorTool.SelectedFigureView = view;

                // update context menu location
                _contextMenuLocation = e.Location;

                // if view is empty
                if (view == null)
                    // show context menu strip for image viewer
                    imageViewerContextMenuStrip.Show(viewer, e.Location);
                else
                    // show context menu strip for graphics figure
                    figureViewContextMenuStrip.Show(viewer, e.Location);
            }
        }

        /// <summary>
        /// Mouse is double clicked.
        /// </summary>
        private void ContentEditorTool_MouseDoubleClick(object sender, VisualToolMouseEventArgs e)
        {
            // if control is enabled and figure is selected
            if (Enabled && mainPanel.Enabled && _contentEditorTool.SelectedFigureView != null)
            {
#if !REMOVE_OFFICE_PLUGIN
                if (_contentEditorTool.SelectedFigureView is OfficeDocumentFigureView)
                    return;
#endif
                // if figure is building
                if (_contentEditorTool.SelectedFigureView.Builder != null &&
                     _contentEditorTool.SelectedFigureView.Builder.IsInteracting)
                    return;

                ContentStreamGraphicsFigureTextGroup textGroup = _contentEditorTool.SelectedFigureView.Figure as ContentStreamGraphicsFigureTextGroup;
                ContentStreamGraphicsFigure contentFigure = _contentEditorTool.SelectedFigureView.Figure as ContentStreamGraphicsFigure;
                ContentStreamGraphicsFigure contentXObjectFigure = GetXObjectFigure(_contentEditorTool.SelectedFigureView.Figure);

                // if content figure is form or image
                if (contentXObjectFigure != null)
                {
                    PdfResourcesViewerForm form = new PdfResourcesViewerForm(_contentEditorTool.CurrentPage.Document, true);
                    form.DocumentResourceViewer.SetSelectedResource(_contentEditorTool.CurrentPage, contentXObjectFigure.Resource);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.SelectedResource != null && contentXObjectFigure.Resource != form.SelectedResource)
                            _contentEditorTool.ReplaceResource(contentXObjectFigure, form.SelectedResource);
                    }
                }
                // if content figure is text
                else if (textGroup != null || (contentFigure != null && contentFigure.IsText))
                {
                    // text editor is shown
                }
                else if (CanEditContentGraphicsProperties(_contentEditorTool.SelectedFigure) &&
                    _contentEditorTool.SelectedFigure is ContentStreamGraphicsFigure)
                {
                    // edit content graphics properties
                    EditContentGraphicsProperties(_contentEditorTool.SelectedFigureView);
                }
                else
                {
                    // show property grid of selected figure
                    ShowPropertyGrid();
                }
            }
        }

        /// <summary>
        /// Edits the content graphics properties.
        /// </summary>
        /// <param name="figure">The figure.</param>
        private void EditContentGraphicsProperties(GraphicsFigureView figureView)
        {
            ContentStreamGraphicsFigure contentFigure = figureView.Figure as ContentStreamGraphicsFigure;
            if (contentFigure != null && contentFigure.Resource != null)
            {
                PdfResourceGraphicsPropertiesForm form = new PdfResourceGraphicsPropertiesForm();
                form.GraphicsProperties = new PdfContentGraphicsProperties(contentFigure);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ContentEditorTool.SetContentGraphicsProperties(figureView, form.GraphicsProperties);
                }
            }
            else
            {
                PdfContentGraphicsPropertiesForm form = new PdfContentGraphicsPropertiesForm();
                if (figureView.Figure is ContentStreamGraphicsFigure)
                    form.GraphicsProperties = new PdfContentGraphicsProperties((ContentStreamGraphicsFigure)figureView.Figure);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ContentEditorTool.SetContentGraphicsProperties(figureView, form.GraphicsProperties);
                }
            }
        }

        /// <summary>
        /// Handles the ActiveInteractionControllerChanged event of ContentEditorTool object.
        /// </summary>
        private void ContentEditorTool_ActiveInteractionControllerChanged(object sender, PropertyChangedEventArgs<IInteractionController> e)
        {
#if !REMOVE_OFFICE_PLUGIN
            DocumentVisualEditor = CompositeInteractionController.FindInteractionController<OfficeDocumentVisualEditor>(e.NewValue);
#endif
        }

#if !REMOVE_OFFICE_PLUGIN
        /// <summary>
        /// Handles the EditingException event of DocumentVisualEditor object.
        /// </summary>
        private void DocumentVisualEditor_EditingException(object sender, ExceptionEventArgs e)
        {
            if (_contentEditorTool != null && _documentVisualEditor != null)
            {
                ImageViewer imageViewer = _contentEditorTool.ImageViewer;

                // get text caret position in text space
                PointF caretLocationInTextSpace = _documentVisualEditor.TextTool.FocusedTextSymbol.Region.LeftTop;

                // get transformation from text space to the image viewer space
                AffineMatrix fromTextToImage = _documentVisualEditor.TextTool.FocusedTextRegion.GetTransformFromTextToImageSpace(imageViewer.Image.Resolution);
                AffineMatrix fromImageToViewer = _contentEditorTool.ImageViewer.GetTransformFromImageToControl(imageViewer.Image);
                AffineMatrix fromTextToViewer = AffineMatrix.Multiply(fromTextToImage, fromImageToViewer);

                // apply transform to the caret location point
                PointF caretLocationInViewerSpace = PointFAffineTransform.TransformPoint(fromTextToViewer, caretLocationInTextSpace);
                Point toolTipLocation = new Point((int)caretLocationInViewerSpace.X, (int)caretLocationInViewerSpace.Y);

                // hide previous toolTip
                textEditingExceptionToolTip.Hide(imageViewer);
                // show new toolTip
                textEditingExceptionToolTip.Show(e.Exception.Message, imageViewer, toolTipLocation, 3000);
            }
        }
#endif

        /// <summary>
        /// Returns the XObject content figure (form or image).
        /// </summary>
        /// <param name="figure">The figure.</param>
        /// <returns>The XObject content figure (form or image).</returns>
        private ContentStreamGraphicsFigure GetXObjectFigure(GraphicsFigure figure)
        {
            if (figure == null)
                return null;
            if (figure is ContentStreamGraphicsFigureTextGroup)
                return null;
            ContentStreamGraphicsFigureGroup contentFigureGroup = figure as ContentStreamGraphicsFigureGroup;
            if (contentFigureGroup != null)
            {
                foreach (ContentStreamGraphicsFigure groupItem in contentFigureGroup)
                {
                    ContentStreamGraphicsFigure result = GetXObjectFigure(groupItem);
                    if (result != null)
                        return result;
                }
                return null;
            }
            ContentStreamGraphicsFigure contentFigure = figure as ContentStreamGraphicsFigure;
            if (contentFigure == null)
                return null;
            if (contentFigure.Resource != null)
                return contentFigure;
            return null;
        }

        #endregion


        #region Set figure settings

        /// <summary>
        /// Sets the pen settings.
        /// </summary>
        private bool SetPenSettings()
        {
            // if pen is empty
            if (_pen == null)
            {
                // create pen
                _pen = new PdfPen(Color.Black);
                _pen.LineJoinStyle = GraphicsStateLineJoinStyle.RoundJoin;
            }
            else
                _pen = (PdfPen)_pen.Clone();

            // create form that allows to edit pen settings
            using (PropertyGridForm dialog = new PropertyGridForm(_pen, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SET_PROPERTIES_OF_PEN, true))
            {
                return dialog.ShowDialog() == DialogResult.OK;
            }
        }

        /// <summary>
        /// Sets the settings of highlight pen.
        /// </summary>
        private bool SetHighlightPenSettings()
        {
            // if pen is empty
            if (_pen == null)
            {
                // create pen
                _pen = new PdfPen(Color.Black, 10);
                _pen.LineJoinStyle = GraphicsStateLineJoinStyle.RoundJoin;
            }
            else
                _pen = (PdfPen)_pen.Clone();

            // create form that allows to set highlighting of pen
            using (SelectHighlightForm dlg = new SelectHighlightForm(_pen))
            {
                // set highlight mode of pen
                dlg.ModeIndex = _selectHighlightPenDialogModeIndex;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // save highlight mode of pen
                    _selectHighlightPenDialogModeIndex = dlg.ModeIndex;
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Sets the settings of highlight brush.
        /// </summary>
        private bool SetHighlightBrushSettings()
        {
            // if brush is empty
            if (_brush == null)
                // create brush
                _brush = new PdfBrush(Color.Black);
            else
                _brush = (PdfBrush)_brush.Clone();

            // create form that allows to set highlighting of brush
            using (SelectHighlightForm dlg = new SelectHighlightForm(_brush))
            {
                // set highlight mode of brush
                dlg.ModeIndex = _selectHighlightPenDialogModeIndex;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // save highlight mode of brush
                    _selectHighlightPenDialogModeIndex = dlg.ModeIndex;
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Sets the settings of brush.
        /// </summary>
        private bool SetBrushSettings()
        {
            // if brush is empty
            if (_brush == null)
                // create brush
                _brush = new PdfBrush(Color.FromArgb(70, Color.FromArgb(255, 255, 0)));
            else
                _brush = (PdfBrush)_brush.Clone();

            // create form that allows to edit brush settings
            using (PropertyGridForm dialog = new PropertyGridForm(_brush, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SET_PROPERTIES_OF_BRUSH, true))
            {
                return dialog.ShowDialog() == DialogResult.OK;
            }
        }

        #endregion


        #region Add figures

        /// <summary>
        /// Adds the text line.
        /// </summary>
        private void addTextToolStripButton_Click(object sender, EventArgs e)
        {
            // get fonts of PDF document
            IList<PdfFont> fonts = FocusedPage.Document.GetFonts();
            // create dialog that allows to enter text
            using (AddTextForm addTextDialog = new AddTextForm(FocusedPage.Document, fonts, _addText))
            {
                // show dialog
                if (addTextDialog.ShowDialog() == DialogResult.OK)
                {
                    // set text
                    _addText = addTextDialog.TextToAdd;
                    // create PDF brush of text line
                    PdfBrush textBrush = new PdfBrush(addTextDialog.TextColor);
                    // build of text line
                    _contentEditorTool.StartBuildTextLine(_addText, addTextDialog.TextFont, addTextDialog.TextSize, textBrush);
                }
            }
        }

        /// <summary>
        /// Adds the text box.
        /// </summary>
        private void addTextBoxToolStripButton_Click(object sender, EventArgs e)
        {
            // get fonts of PDF document
            IList<PdfFont> fonts = FocusedPage.Document.GetFonts();
            // create dialog that allows to enter text
            using (AddTextForm addTextDialog = new AddTextForm(FocusedPage.Document, fonts, _addText))
            {
                // show dialog
                if (addTextDialog.ShowDialog() == DialogResult.OK)
                {
                    // set pen of text box
                    PdfPen pen = null;
                    if (SetPenSettings())
                        pen = _pen;
                    // set brush of text box
                    PdfBrush brush = null;
                    if (SetBrushSettings())
                        brush = _brush;
                    // set text
                    _addText = addTextDialog.TextToAdd;
                    // create figure
                    TextBoxFigure textBox = new TextBoxFigure(new PdfBrush(addTextDialog.TextColor),
                        _addText, addTextDialog.TextFont, addTextDialog.TextSize);
                    textBox.CanRotate = true;
                    // set pen
                    textBox.Pen = pen;
                    // set brush
                    textBox.Brush = brush;
                    // create property grid form of text box
                    using (PropertyGridForm dialog = new PropertyGridForm(textBox, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SET_PROPERTIES_OF_TEXTBOXFIGURE, true))
                    {
                        // show dialog
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            // build of text box
                            _contentEditorTool.StartBuildFigure(textBox);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds the image figure based on PDF image-resource.
        /// </summary>
        private void drawImageToolStripButton_Click(object sender, EventArgs e)
        {
            // create dialog that allows to select PDF image-resource
            using (PdfResourcesViewerForm dialog = new PdfResourcesViewerForm(FocusedPage.Document))
            {
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Owner = this.ParentForm;
                dialog.ShowFormResources = false;
                dialog.ShowImageResources = true;
                dialog.CanAddResources = true;

                // show dialog
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // build of image
                    _contentEditorTool.StartBuildImage((PdfImageResource)dialog.SelectedResource);
                }
            }
        }

        /// <summary>
        /// Adds the image figure based on PDF form-resource.
        /// </summary>
        private void drawFormXObjectToolStripButton_Click(object sender, EventArgs e)
        {
            using (PdfResourcesViewerForm dialog = new PdfResourcesViewerForm(FocusedPage.Document, true))
            {
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Owner = this.ParentForm;
                dialog.ShowFormResources = true;
                dialog.ShowImageResources = false;
                dialog.CanAddResources = true;

                if (dialog.ShowDialog() == DialogResult.OK && (dialog.SelectedResource is PdfFormXObjectResource))
                {
                    _contentEditorTool.StartBuildFormXObject(null, null, (PdfFormXObjectResource)dialog.SelectedResource);
                }
            }
        }

        /// <summary>
        /// Adds the image figure based on VintasoftImage.
        /// </summary>
        private void drawVintasoftImageToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                // if image is selected
                if (_openImageFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // select image from file
                    VintasoftImage image = SelectImageForm.SelectImageFromFile(_openImageFileDialog.FileName);

                    // if image is not selected
                    if (image == null)
                        return;

                    // create figure
                    VintasoftImageFigure figure = new VintasoftImageFigure();
                    figure.CanRotate = true;
                    figure.Image = image;

                    // create property grid of figure
                    using (PropertyGridForm figurePropertiesForm = new PropertyGridForm(figure, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_VINTASOFTIMAGEFIGURE_PROPERTIES))
                    {
                        if (figurePropertiesForm.ShowDialog() == DialogResult.OK)
                            // build of the figure
                            _contentEditorTool.StartBuildFigure(figure);
                    }
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Adds the Office document figure.
        /// </summary>
        private void drawOfficeDocumentButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_OFFICE_PLUGIN
            try
            {
                // select Office document
                Stream documentStream = OfficeDemosTools.SelectOfficeDocument();

                // if document is selected
                if (documentStream != null)
                {
                    // create figure
                    OfficeDocumentFigure figure = new OfficeDocumentFigure(_contentEditorTool.DocumentFontController);

                    figure.SetDocumentStream(documentStream, true);

                    // build the figure
                    _contentEditorTool.StartBuildFigure(figure);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
#endif
        }

        /// <summary>
        /// Adds the formatted text.
        /// </summary>
        private void formattedTextButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_OFFICE_PLUGIN
            // create figure
            OfficeDocumentFigure figure = new OfficeDocumentFigure(_contentEditorTool.DocumentFontController);
            figure.SetDocumentStream(DemosResourcesManager.GetResourceAsStream("EmptyDocument.docx"), true);
            figure.Brush = null;

            _formattedTextFigure = figure;

            // build the figure
            _contentEditorTool.StartBuildFigure(figure);
#endif
        }

        /// <summary>
        /// Adds the chart.
        /// </summary>
        private void drawChartToolStripButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_OFFICE_PLUGIN
            Stream chartStream = OfficeDemosTools.SelectChartResource();
            if (chartStream != null)
            {
                // create figure
                OfficeDocumentFigure figure = new OfficeDocumentFigure();
                figure.UseGraphicObjectRelativeSize = true;
                figure.SetDocumentStream(chartStream, true);
                _chartFigure = figure;

                // build the figure
                _contentEditorTool.StartBuildFigure(figure);
            }
#endif
        }


        /// <summary>
        /// Adds the rectangle.
        /// </summary>
        private void drawRectangleToolStripButton_Click(object sender, EventArgs e)
        {
            if (SetPenSettings() && SetBrushSettings())
            {
                // build the rectangle
                _contentEditorTool.StartBuildRectangle(_pen, _brush);
            }
        }

        /// <summary>
        /// Adds the filled rectangle.
        /// </summary>
        private void fillRectangleToolStripButton_Click(object sender, EventArgs e)
        {
            if (SetBrushSettings())
            {
                // build the rectangle
                _contentEditorTool.StartBuildRectangle(null, _brush);
            }
        }

        /// <summary>
        /// Adds the highlighted rectangle.
        /// </summary>
        private void fillRectangleUseBlendingModeToolStripButton_Click(object sender, EventArgs e)
        {
            if (SetHighlightBrushSettings())
            {
                // build the rectangle
                _contentEditorTool.StartBuildRectangle(null, _brush);
            }
        }

        /// <summary>
        /// Adds the freehand lines.
        /// </summary>
        private void drawLinesUseBlendingModeToolStripButton_Click(object sender, EventArgs e)
        {
            if (SetHighlightPenSettings())
            {
                // build the freehand lines
                _contentEditorTool.StartBuildFreehandLines(_pen);
            }
        }

        /// <summary>
        /// Adds the ellipse.
        /// </summary>
        private void drawEllipseToolStripButton_Click(object sender, EventArgs e)
        {
            if (SetPenSettings() && SetBrushSettings())
            {
                // build the ellipse
                _contentEditorTool.StartBuildEllipse(_pen, _brush);
            }
        }

        /// <summary>
        /// Adds the lines.
        /// </summary>
        private void drawLinesToolStripButton_Click(object sender, EventArgs e)
        {
            if (SetPenSettings())
            {
                // build the lines
                _contentEditorTool.StartBuildLines(_pen);
            }
        }

        /// <summary>
        /// Adds the freehand lines.
        /// </summary>
        private void freeHandLineToolStripButton_Click(object sender, EventArgs e)
        {
            if (SetPenSettings())
            {
                // build the freehand lines
                _contentEditorTool.StartBuildFreehandLines(_pen);
            }
        }

        /// <summary>
        /// Adds the curves.
        /// </summary>
        private void drawCurvesToolStripButton_Click(object sender, EventArgs e)
        {
            if (SetPenSettings())
            {
                // build the curves
                _contentEditorTool.StartBuildCurves(_pen);
            }
        }

        /// <summary>
        /// Adds the polygon.
        /// </summary>
        private void drawPolygonToolStripButton_Click(object sender, EventArgs e)
        {
            if (SetPenSettings() && SetBrushSettings())
            {
                // build the polygon
                _contentEditorTool.StartBuildPolygon(_pen, _brush);
            }
        }

        /// <summary>
        /// Adds the closed curves.
        /// </summary>
        private void drawClosedCurvesToolStripButton_Click(object sender, EventArgs e)
        {
            if (SetPenSettings() && SetBrushSettings())
            {
                // build the closed curves
                _contentEditorTool.StartBuildClosedCurves(_pen, _brush);
            }
        }

        #endregion


        #region Context menu strip

        /// <summary>
        /// Context menu strip of figure is opening.
        /// </summary>
        private void figureViewContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            cutToolStripMenuItem.Enabled = _contentEditorTool.CutAction.IsEnabled;
            copyToolStripMenuItem.Enabled = _contentEditorTool.CopyAction.IsEnabled;
            pasteToolStripMenuItem.Enabled = _contentEditorTool.PasteAction.IsEnabled;
            deleteToolStripMenuItem.Enabled = _contentEditorTool.DeleteAction.IsEnabled;
            propertiesToolStripMenuItem.Enabled = _contentEditorTool.SelectedFigure != null;
            bringToBackToolStripMenuItem.Enabled = _contentEditorTool.BringToBackAction.IsEnabled;
            bringToFrontToolStripMenuItem.Enabled = _contentEditorTool.BringToFrontAction.IsEnabled;

            ContentStreamGraphicsFigureView contentStreamFigure = _contentEditorTool.SelectedFigureView as ContentStreamGraphicsFigureView;
            replaceResourceToolStripMenuItem.Enabled = contentStreamFigure != null && contentStreamFigure.ContentFigure.HasResource;

            if (figureViewContextMenuStrip.SourceControl == ContentEditorTool.ImageViewer)
            {
                GraphicsFigureView[] figures = ContentEditorTool.FindFigures(_contextMenuLocation);
                if (figures.Length > 0)
                {
                    selectFigureToolStripMenuItem.DropDownItems.Clear();
                    selectFigureToolStripMenuItem.Enabled = true;
                    foreach (GraphicsFigureView figure in figures)
                    {
                        ToolStripMenuItem menuItem = new ToolStripMenuItem(GraphicsFigureViewItem.GetDescription(figure));
                        menuItem.Tag = figure;
                        menuItem.Click += SelectFigureMenuItem_Click;
                        selectFigureToolStripMenuItem.DropDownItems.Add(menuItem);
                    }
                }
                else
                {
                    selectFigureToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                selectFigureToolStripMenuItem.Enabled = false;
            }

            contentGraphicsPropertiesToolStripMenuItem.Enabled = _contentEditorTool != null && CanEditContentGraphicsProperties(_contentEditorTool.SelectedFigure);
        }

        /// <summary>
        /// Selects the figure (context menu "Select Figure").
        /// </summary>
        private void SelectFigureMenuItem_Click(object sender, EventArgs e)
        {
            GraphicsFigureView figure = (GraphicsFigureView)((ToolStripMenuItem)sender).Tag;
            ContentEditorTool.SelectedFigureView = figure;
        }

        /// <summary>
        /// Context menu strip of image viewer is opening.
        /// </summary>
        private void imageViewerContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            pasteToolStripMenuItem1.Enabled = _contentEditorTool.PasteAction.IsEnabled;
            removeAllToolStripMenuItem.Enabled = _contentEditorTool.FigureViewCollection.Count > 0;
        }

        /// <summary>
        /// Cuts the figure.
        /// </summary>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _contentEditorTool.CutAction.Execute();
        }

        /// <summary>
        /// Copies the figure.
        /// </summary>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _contentEditorTool.CopyAction.Execute();
        }

        /// <summary>
        /// Pastes the figure.
        /// </summary>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _contentEditorTool.PasteAction.Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Deletes the figure.
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedFigure();
        }

        /// <summary>
        /// Removes selected figure.
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedFigure();
        }

        /// <summary>
        /// Removes all figures.
        /// </summary>
        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<GraphicsFigureView> figures = GetCurrentFigures();
            if (figures.Count == _contentEditorTool.FigureViewCollection.Count)
                _contentEditorTool.RemoveAllFigures();
            else
                _contentEditorTool.RemoveFigures(figures);
        }

        /// <summary>
        /// Returns collection that contains current figure list.
        /// </summary>
        private List<GraphicsFigureView> GetCurrentFigures()
        {
            List<GraphicsFigureView> result = new List<GraphicsFigureView>(figuresListBox.Items.Count);
            foreach (GraphicsFigureViewItem figureViewItem in figuresListBox.Items)
                result.Add(figureViewItem.FigureView);
            return result;
        }


        /// <summary>
        /// Handles the Click event of ReplaceResourceToolStripMenuItem object.
        /// </summary>
        private void replaceResourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphicsFigureView figureView = _contentEditorTool.SelectedFigureView;
            ContentStreamGraphicsFigure figure = GetXObjectFigure(figureView.Figure);
            PdfResourcesViewerForm form = new PdfResourcesViewerForm(_contentEditorTool.CurrentPage.Document, true);
            form.DocumentResourceViewer.SelectedResource = figure.Resource;
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.SelectedResource != null)
                    _contentEditorTool.ReplaceResource(figure, form.SelectedResource);
            }
        }


        /// <summary>
        /// "Bring To Front" menu is selected in context menu.
        /// </summary>
        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _contentEditorTool.BringToFrontAction.Execute();
        }

        /// <summary>
        /// "Bring To Back" menu is selected in context menu.
        /// </summary>
        private void bringToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _contentEditorTool.BringToBackAction.Execute();
        }

        /// <summary>
        /// Shows properties of figure.
        /// </summary>
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPropertyGrid();
        }

        /// <summary>
        /// Shows the property grid of selected figure.
        /// </summary>
        private void ShowPropertyGrid()
        {
            // get selected graphics figure
            GraphicsFigureView view = _contentEditorTool.SelectedFigureView;
            // create property grid form
            using (PropertyGridForm dialog = new PropertyGridForm(view.Figure, GraphicsFigureViewItem.GetDescription(view)))
            {
                // show dialog
                dialog.ShowDialog();
                // update graphics figure
                _contentEditorTool.InvalidateItem(view);
            }
        }

        /// <summary>
        /// Deletes the selected figure.
        /// </summary>
        private void DeleteSelectedFigure()
        {
            _contentEditorTool.DeleteAction.Execute();
        }

        /// <summary>
        /// Handles the CheckedChanged event of InteractiveContentTypeToolStripButton object.
        /// </summary>
        private void interactiveContentTypeToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_contentEditorTool != null && !_isFigureContentTypeButtonUpdating)
            {
                GraphicsFigureContentType interactiveContentType = GraphicsFigureContentType.NoContent;
                bool isAllButtonsChecked = true;

                // get figure content type

                foreach (ToolStripButton toolStripButton in buttonToFigureContentType.Keys)
                {
                    if (toolStripButton.Checked)
                        interactiveContentType |= buttonToFigureContentType[toolStripButton];
                    else
                        isAllButtonsChecked = false;
                }

                if (isAllButtonsChecked)
                    interactiveContentType = GraphicsFigureContentType.Any;

                // if figure content type must be updated
                if (_contentEditorTool.InteractiveContentType != interactiveContentType)
                {
                    // update figure content type
                    _contentEditorTool.InteractiveContentType = interactiveContentType;

                    UpdateFiguresListBox();

                    // updte UI
                    UpdateUI();
                }
            }
        }

        /// <summary>
        /// Handles the MouseDown event of InteractiveContentTypeToolStripButton object.
        /// </summary>
        private void interactiveContentTypeToolStripButton_MouseDown(object sender, MouseEventArgs e)
        {
            // if right mouse button is clicked
            if (e.Button == MouseButtons.Right)
            {
                if (_contentEditorTool != null && !_isFigureContentTypeButtonUpdating)
                {
                    // create empty value
                    GraphicsFigureContentType interactiveContentType = GraphicsFigureContentType.NoContent;
                    // set selected figure content type
                    interactiveContentType |= buttonToFigureContentType[(ToolStripButton)sender];
                    // update value in visual tool
                    _contentEditorTool.InteractiveContentType = interactiveContentType;

                    UpdateFiguresListBox();

                    // updte UI
                    UpdateUI();
                }
            }
        }

        #endregion


        #region Undo/Redo

        /// <summary>
        /// Handles the Changed event of the UndoManager.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UndoManagerChangedEventArgs"/> instance containing the event data.</param>
        private void UndoManager_Changed(object sender, UndoManagerChangedEventArgs e)
        {
            UpdateUndoUI();
        }

        /// <summary>
        /// Updates the UI state of undo / redo.
        /// </summary>
        private void UpdateUndoUI()
        {
            // if undo manager contains undo actions and undo action is not executing now
            if (_undoManager.UndoCount > 0 && !_isUndoRedoExecuting)
            {
                // get undo manager actions
                ReadOnlyCollection<UndoAction> actions = _undoManager.GetActions();

                // clear action lists
                undoToolStripSplitButton.DropDownItems.Clear();

                // from current action to the first action
                for (int i = _undoManager.CurrentActionIndex; i >= 0; i--)
                {
                    // create tool strip item
                    undoToolStripSplitButton.DropDownItems.Add(actions[i].ToString());
                }

                // update button properties
                undoToolStripSplitButton.Enabled = true;
                undoToolStripSplitButton.ToolTipText = string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_UNDO_CTRLZ_ARG0, _undoManager.UndoDescription).Trim();
            }
            else
            {
                // update button properties
                undoToolStripSplitButton.Enabled = false;
                undoToolStripSplitButton.ToolTipText = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_UNDO;
            }

            // if undo manager contains redo actions and redo action is not executing now
            if (_undoManager.RedoCount > 0 && !_isUndoRedoExecuting)
            {
                // get undo manager actions
                ReadOnlyCollection<UndoAction> actions = _undoManager.GetActions();

                // clear action lists
                redoToolStripSplitButton.DropDownItems.Clear();

                // from next action to the last action
                for (int i = _undoManager.CurrentActionIndex + 1; i < actions.Count; i++)
                {
                    // create tool strip item
                    redoToolStripSplitButton.DropDownItems.Add(actions[i].ToString());
                }

                // update button properties
                redoToolStripSplitButton.Enabled = true;
                redoToolStripSplitButton.ToolTipText = string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_REDO_CTRLY_ARG0, _undoManager.RedoDescription).Trim();
            }
            else
            {
                // update button properties
                redoToolStripSplitButton.Enabled = false;
                redoToolStripSplitButton.ToolTipText = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_REDO;
            }
        }

        /// <summary>
        /// Handles the ButtonClick event of UndoToolStripSplitButton object.
        /// </summary>
        private void undoToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            // start undo execution
            _isUndoRedoExecuting = true;
            // execute a single undo operation
            _undoManager.Undo();
            // end undo execution
            _isUndoRedoExecuting = false;

            UpdateUI();
        }

        /// <summary>
        /// Handles the ButtonClick event of RedoToolStripSplitButton object.
        /// </summary>
        private void redoToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            // start redo execution
            _isUndoRedoExecuting = true;
            // execute a single redo operation
            _undoManager.Redo();
            // end redo execution
            _isUndoRedoExecuting = false;

            UpdateUI();
        }

        /// <summary>
        /// Handles the DropDownItemClicked event of UndoToolStripSplitButton object.
        /// </summary>
        private void undoToolStripSplitButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // start undo execution
            _isUndoRedoExecuting = true;

            // get clicked action index
            int undoItemIndex = undoToolStripSplitButton.DropDownItems.IndexOf(e.ClickedItem);

            // execute undo
            _undoManager.Undo(undoItemIndex + 1);

            // end undo execution
            _isUndoRedoExecuting = false;

            UpdateUI();
        }

        /// <summary>
        /// Handles the DropDownItemClicked event of RedoToolStripSplitButton object.
        /// </summary>
        private void redoToolStripSplitButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // start redo execution
            _isUndoRedoExecuting = true;

            // get clicked action index
            int redoItemIndex = redoToolStripSplitButton.DropDownItems.IndexOf(e.ClickedItem);

            // execute redo
            _undoManager.Redo(redoItemIndex + 1);

            // end redo execution
            _isUndoRedoExecuting = false;

            UpdateUI();
        }

        /// <summary>
        /// Handles the KeyDown event of the ContentEditorTool.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void ContentEditorTool_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                if (undoToolStripSplitButton.Enabled)
                    undoToolStripSplitButton.PerformButtonClick();
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                if (redoToolStripSplitButton.Enabled)
                    redoToolStripSplitButton.PerformButtonClick();
            }
        }

        #endregion

        #endregion


    }
}
