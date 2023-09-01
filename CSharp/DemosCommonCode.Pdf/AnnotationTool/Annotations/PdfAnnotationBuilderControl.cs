using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.UI.Annotations;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

using DemosCommonCode.CustomControls;
using System.IO;
using DemosCommonCode.Office;
#if !REMOVE_OFFICE_PLUGIN
using Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction;
#endif

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A panel that allows to add and build new PDF annotations on a PDF page.
    /// </summary>
    public partial class PdfAnnotationBuilderControl : UserControl
    {

        #region Constants

        /// <summary>
        /// The text font default size.
        /// </summary>
        const float TEXT_FONT_DEFAULT_SIZE = 12;

        #endregion



        #region Fields

        /// <summary>
        /// Dictionary: the tool strip menu item => annotation type, which must be built.
        /// </summary>
        Dictionary<ToolStripItem, AnnotationType> _toolStripItemToAnnotationType =
            new Dictionary<ToolStripItem, AnnotationType>();

        /// <summary>
        /// The background color of annotations.
        /// </summary>
        Color _annotationFillColor = Color.White;

        /// <summary>
        /// The mouse observer of visual tool.
        /// </summary>
        VisualToolMouseObserver _visualToolMouseObserver = new VisualToolMouseObserver();

        /// <summary>
        ///  The prevous icon name of file attachment annotation.
        /// </summary>
        string _previousFileAttachmentIconName = string.Empty;

        /// <summary>
        /// The annotation button, which is currently selected in the control.
        /// </summary>
        ToolStripItem _selectedAnnotationButton;

        /// <summary>
        /// The type of the last built annotation.
        /// </summary>
        AnnotationType _lastBuiltAnnotationType = AnnotationType.Unknown;

        /// <summary>
        ///  value indicating whether the focused index of image viewer is changing.
        /// </summary>
        bool _isFocusedIndexChanging = false;

        /// <summary>
        /// A value indicating whether the interaction mode is changing.
        /// </summary>
        bool _isInteractionModeChanging = false;

        /// <summary>
        ///  value indicating whether the annotation building must be continued after changing focus in viewer.
        /// </summary>
        bool _needContinueBuildAnnotationsAfterFocusedIndexChanged = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAnnotationBuilderControl"/> class.
        /// </summary>
        public PdfAnnotationBuilderControl()
        {
            InitializeComponent();

            InitializeAnnotationButtons();
        }

        #endregion



        #region Properties

        PdfAnnotationTool _annotationTool = null;
        /// <summary>
        /// Gets or sets the PDF annotation tool.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if
        /// new annotation tool is activated already.</exception>
        [Browsable(false)]
        [DefaultValue((object)null)]
        public PdfAnnotationTool AnnotationTool
        {
            get
            {
                return _annotationTool;
            }
            set
            {
                if (_annotationTool != value)
                {
                    if (value != null && value.ImageViewer != null)
                        throw new InvalidOperationException("Annotation tool should be deactivated.");

                    // if annotation tool is not empty
                    if (_annotationTool != null)
                        UnscribeFromPdfAnnotationToolEvents(_annotationTool);

                    // set new annotation tool
                    _annotationTool = value;
                    _visualToolMouseObserver.VisualTool = value;

                    // update user interface
                    UpdateUI();

                    // if annotation tool is not empty
                    if (_annotationTool != null)
                        SubscribeToPdfAnnotationToolEvents(_annotationTool);
                }
            }
        }

        bool _needBuildAnnotationsContinuously = false;
        /// <summary>
        /// Gets a value indicating whether the annotations must be built continuously.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public bool NeedBuildAnnotationsContinuously
        {
            get
            {
                return _needBuildAnnotationsContinuously;
            }
            set
            {
                _needBuildAnnotationsContinuously = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Cancels the annotation building.
        /// </summary>
        public void CancelAnnotationBuilding()
        {
            EndBuilding();
            _annotationTool.CancelBuilding();
        }

        /// <summary>
        /// Updates the user interface of this control.
        /// </summary>
        public void UpdateUI()
        {
            mainToolStrip.Enabled =
                _annotationTool != null &&
                _annotationTool.ImageViewer != null &&
                _annotationTool.ImageViewer.Image != null &&
                PdfDocumentController.GetPageAssociatedWithImage(_annotationTool.ImageViewer.Image) != null;
        }

        #endregion


        #region PRIVATE

        #region Image viewer

        /// <summary>
        /// Subscribes to the image viewer events.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void SubscribeToImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged += new EventHandler<FocusedIndexChangedEventArgs>(imageViewer_FocusedIndexChanged);
            imageViewer.VisualToolChanging += new EventHandler<VisualToolChangedEventArgs>(imageViewer_VisualToolChanging);
        }

        /// <summary>
        /// Unsubscribes from the image viewer events.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void UnscribeFromImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged -= new EventHandler<FocusedIndexChangedEventArgs>(imageViewer_FocusedIndexChanged);
            imageViewer.VisualToolChanging -= new EventHandler<VisualToolChangedEventArgs>(imageViewer_VisualToolChanging);
        }

        /// <summary>
        /// Index, of focused image in viewer, is changing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FocusedIndexChangedEventArgs"/> instance containing the event data.</param>
        private void imageViewer_FocusedIndexChanging(object sender, FocusedIndexChangedEventArgs e)
        {
            _isFocusedIndexChanging = true;

            if (AnnotationTool != null)
            {
                if (NeedBuildAnnotationsContinuously)
                {
                    // if focused annotation view is not empty
                    if (AnnotationTool.FocusedAnnotationView != null &&
                        IsNotPdfWidgetAnnotation(AnnotationTool.FocusedAnnotationView))
                    {
                        // if focused annotation view is building
                        if (AnnotationTool.FocusedAnnotationView.IsBuilding)
                        {
                            _needContinueBuildAnnotationsAfterFocusedIndexChanged = true;

                            AnnotationTool.CancelBuilding();
                        }
                    }
                }
                else
                {
                    EndBuilding();
                }
            }
        }

        /// <summary>
        /// Index, of focused image in viewer, is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FocusedIndexChangedEventArgs"/> instance containing the event data.</param>
        private void imageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            _isFocusedIndexChanging = false;

            UpdateUI();

            if (_needContinueBuildAnnotationsAfterFocusedIndexChanged &&
                AnnotationTool.ImageViewer.FocusedIndex != -1)
            {
                AddAndBuildAnnotation(_lastBuiltAnnotationType);
            }

            _needContinueBuildAnnotationsAfterFocusedIndexChanged = false;
        }

        /// <summary>
        /// Visual tool of image viewer is changing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisualToolChangedEventArgs"/> instance containing the event data.</param>
        private void imageViewer_VisualToolChanging(object sender, VisualToolChangedEventArgs e)
        {
            if (AnnotationTool != null)
                AnnotationTool.CancelBuilding();
        }

        #endregion


        #region PDF annotation tool

        /// <summary>
        /// Subscribes to the PDF annotation tool events.
        /// </summary>
        /// <param name="annotationTool">The annotation tool.</param>
        private void SubscribeToPdfAnnotationToolEvents(PdfAnnotationTool annotationTool)
        {
            annotationTool.Activating += new EventHandler(pdfAnnotationTool_Activating);
            annotationTool.Activated += new EventHandler(pdfAnnotationTool_Activated);
            annotationTool.Deactivating += new EventHandler(pdfAnnotationTool_Deactivating);
            annotationTool.Deactivated += new EventHandler(pdfAnnotationTool_Deactivated);
            annotationTool.BuildingFinished += new EventHandler<PdfAnnotationViewEventArgs>(pdfAnnotationTool_BuildingFinished);
            annotationTool.BuildingCanceled += new EventHandler<PdfAnnotationViewEventArgs>(pdfAnnotationTool_BuildingCanceled);
        }

        /// <summary>
        /// Unsubscribes from the PDF annotation tool events.
        /// </summary>
        /// <param name="annotationTool">The annotation tool.</param>
        private void UnscribeFromPdfAnnotationToolEvents(PdfAnnotationTool annotationTool)
        {
            annotationTool.Activating -= new EventHandler(pdfAnnotationTool_Activating);
            annotationTool.Activated -= new EventHandler(pdfAnnotationTool_Activated);
            annotationTool.Deactivating -= new EventHandler(pdfAnnotationTool_Deactivating);
            annotationTool.Deactivated -= new EventHandler(pdfAnnotationTool_Deactivated);
            annotationTool.BuildingFinished -= new EventHandler<PdfAnnotationViewEventArgs>(pdfAnnotationTool_BuildingFinished);
            annotationTool.BuildingCanceled -= new EventHandler<PdfAnnotationViewEventArgs>(pdfAnnotationTool_BuildingCanceled);
        }

        /// <summary>
        /// PDF annotation tool is activating.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pdfAnnotationTool_Activating(object sender, EventArgs e)
        {
            AnnotationTool.ImageViewer.FocusedIndexChanging += new EventHandler<FocusedIndexChangedEventArgs>(imageViewer_FocusedIndexChanging);
        }

        /// <summary>
        /// PDF annotation tool is activated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pdfAnnotationTool_Activated(object sender, EventArgs e)
        {
            SubscribeToImageViewerEvents(AnnotationTool.ImageViewer);

            UpdateUI();
        }

        /// <summary>
        /// PDF annotation tool is deactivating.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pdfAnnotationTool_Deactivating(object sender, EventArgs e)
        {
            AnnotationTool.ImageViewer.FocusedIndexChanging -= new EventHandler<FocusedIndexChangedEventArgs>(imageViewer_FocusedIndexChanging);
        }

        /// <summary>
        /// PDF annotation tool is deactivated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pdfAnnotationTool_Deactivated(object sender, EventArgs e)
        {
            UnscribeFromImageViewerEvents(AnnotationTool.ImageViewer);

            mainToolStrip.Enabled = false;
        }

        /// <summary>
        /// The annotation building is finished.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PdfAnnotationViewEventArgs"/> instance containing the event data.</param>
        private void pdfAnnotationTool_BuildingFinished(object sender, PdfAnnotationViewEventArgs e)
        {
            // if annotation tool does not contain annotation
            if (!_annotationTool.AnnotationCollection.Contains(e.AnnotationView.Annotation))
                return;

            // if annotation view is PDF link annotation view
            if (e.AnnotationView is PdfLinkAnnotationView)
            {
                // create new action
                PdfAction activateAction = CreatePdfActionForm.CreateAction(e.AnnotationView.Annotation.Document, null);
                // if action is not empty
                if (activateAction != null)
                {
                    if (PdfActionsEditorTool.EditAction(activateAction, AnnotationTool.ImageViewer.Images, null))
                        e.AnnotationView.Annotation.ActivateAction = activateAction;
                }
                ((PdfLinkAnnotationView)e.AnnotationView).IsHighlighted = false;
            }
            // if annotation view is PDF file attachment annotation view
            else if (e.AnnotationView is PdfFileAttachmentAnnotationView)
            {
                // get the annotation
                PdfFileAttachmentAnnotation fileAttachmentAnnotation = ((PdfFileAttachmentAnnotation)e.AnnotationView.Annotation);
                SetEmbeddedFile(fileAttachmentAnnotation.Document, fileAttachmentAnnotation);
            }
#if !REMOVE_OFFICE_PLUGIN
            // if annotation view is PDF office document annotation view
            else if (e.AnnotationView is PdfOfficeDocumentAnnotationView)
            {
                // if last buil annotation is Cart
                if (_lastBuiltAnnotationType == AnnotationType.Chart)
                {
                    // show chart data editor dialog
                    e.AnnotationView.InteractionController = e.AnnotationView.Transformer;
                    OfficeDocumentVisualEditor visualEditor = CompositeInteractionController.FindInteractionController<OfficeDocumentVisualEditor>(e.AnnotationView.InteractionController);
                    if (visualEditor != null)
                    {
                        OpenXmlDocumentChartDataForm chartForm = new OpenXmlDocumentChartDataForm();
                        chartForm.Location = FindForm().Location;
                        chartForm.VisualEditor = visualEditor;
                        chartForm.ShowDialog();
                    }
                }
            }
#endif
            if (IsNotPdfWidgetAnnotation(e.AnnotationView))
            {
                if (NeedBuildAnnotationsContinuously)
                {
                    AddAndBuildAnnotation(_lastBuiltAnnotationType);
                }
                else
                {
                    EndBuilding();
                }
            }
        }
    

        /// <summary>
        /// The annotation building is canceled.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PdfAnnotationViewEventArgs"/> instance containing the event data.</param>
        private void pdfAnnotationTool_BuildingCanceled(object sender, PdfAnnotationViewEventArgs e)
        {
            if (!_isFocusedIndexChanging &&
                !_isInteractionModeChanging)
                EndBuilding();
        }

        #endregion


        #region Annotation buttons

        /// <summary>
        /// Initializes the annotation buttons.
        /// </summary>
        private void InitializeAnnotationButtons()
        {
            InitializeAnnotationButton(lineToolStripSplitButton,
                "Line", AnnotationType.Line);

            InitializeAnnotationButton(lineWithArrowToolStripMenuItem,
                "LineWithArrow", AnnotationType.LineWithArrow);

            InitializeAnnotationButton(lineWithArrowsToolStripMenuItem,
                "LineWithArrows", AnnotationType.LineWithArrows);

            InitializeAnnotationButton(inkToolStripButton,
                "Ink", AnnotationType.Ink);

            InitializeAnnotationButton(rectangleToolStripSplitButton,
                "Rectangle", AnnotationType.Rectangle);

            InitializeAnnotationButton(filledRectangleToolStripMenuItem,
                "FilledRectangle", AnnotationType.FilledRectangle);

            InitializeAnnotationButton(cloudRectangleToolStripMenuItem,
                "CloudRectangle", AnnotationType.CloudRectangle);

            InitializeAnnotationButton(cloudFilledRectangleToolStripMenuItem,
                "CloudFilledRectangle", AnnotationType.CloudFilledRectangle);

            InitializeAnnotationButton(ellipseToolStripSplitButton,
                "Ellipse", AnnotationType.Ellipse);

            InitializeAnnotationButton(filledEllipseToolStripMenuItem,
                "FilledEllipse", AnnotationType.FilledEllipse);

            InitializeAnnotationButton(cloudEllipseToolStripMenuItem,
                "CloudEllipse", AnnotationType.CloudEllipse);

            InitializeAnnotationButton(cloudFilledEllipseToolStripMenuItem,
                "CloudFilledEllipse", AnnotationType.CloudFilledEllipse);

            InitializeAnnotationButton(polylineToolStripSplitButton,
                "Polyline", AnnotationType.Polyline);

            InitializeAnnotationButton(polylineWithArrowToolStripMenuItem,
                "PolylineWithArrow", AnnotationType.PolylineWithArrow);

            InitializeAnnotationButton(polylineWithArrowsToolStripMenuItem,
                "PolylineWithArrows", AnnotationType.PolylineWithArrows);

            InitializeAnnotationButton(freehandPolylineToolStripMenuItem,
                "FreehandPolyline", AnnotationType.FreehandPolyline);

            InitializeAnnotationButton(polygonToolStripSplitButton,
                "Polygon", AnnotationType.Polygon);

            InitializeAnnotationButton(filledPolygonToolStripMenuItem,
                "FilledPolygon", AnnotationType.FilledPolygon);

            InitializeAnnotationButton(cloudPolygonToolStripMenuItem,
                "CloudPolygon", AnnotationType.CloudPolygon);

            InitializeAnnotationButton(cloudFilledPolygonToolStripMenuItem,
                "CloudFilledPolygon", AnnotationType.CloudFilledPolygon);

            InitializeAnnotationButton(freehandPolygonToolStripMenuItem,
                "FreehandPolygon", AnnotationType.FreehandPolygon);

            InitializeAnnotationButton(linkToolStripButton,
                "Link", AnnotationType.Link);

            InitializeAnnotationButton(labelToolStripButton,
                "Label", AnnotationType.Label);

            InitializeAnnotationButton(textToolStripButton,
                "Text", AnnotationType.Text);

            InitializeAnnotationButton(cloudTextToolStripMenuItem,
                "CloudText", AnnotationType.CloudText);

            InitializeAnnotationButton(freeTextToolStripButton,
                "FreeText", AnnotationType.FreeText);

            InitializeAnnotationButton(cloudFreeTextToolStripMenuItem,
                "CloudFreeText", AnnotationType.CloudFreeText);

            InitializeAnnotationButton(fileAttachmentToolStripButton,
                "FileAttachment", AnnotationType.FileAttachment);

            InitializeAnnotationButton(graphFileAttachmentToolStripMenuItem,
                "GraphFileAttachment", AnnotationType.GraphFileAttachment);

            InitializeAnnotationButton(pushPinFileAttachmentToolStripMenuItem,
                "PushPinFileAttachment", AnnotationType.PushPinFileAttachment);

            InitializeAnnotationButton(paperclipFileAttachmentToolStripMenuItem,
                "PaperclipFileAttachment", AnnotationType.PaperclipFileAttachment);

            InitializeAnnotationButton(tagFileAttachmentToolStripMenuItem,
                "TagFileAttachment", AnnotationType.TagFileAttachment);

            InitializeAnnotationButton(textCommentToolStripMenuItem,
                "Text_Comment", AnnotationType.Text_Comment);

            InitializeAnnotationButton(textCheckToolStripMenuItem,
                "Text_Check", AnnotationType.Text_Check);

            InitializeAnnotationButton(textCheckmarkToolStripMenuItem,
                "Text_Checkmark", AnnotationType.Text_Checkmark);

            InitializeAnnotationButton(textCircleToolStripMenuItem,
                "Text_Circle", AnnotationType.Text_Circle);

            InitializeAnnotationButton(textRectangleToolStripMenuItem,
                "Text_Rectangle", AnnotationType.Text_Rectangle);

            InitializeAnnotationButton(textCrossToolStripMenuItem,
                "Text_Cross", AnnotationType.Text_Cross);

            InitializeAnnotationButton(textCrossHairsToolStripMenuItem,
                "Text_CrossHairs", AnnotationType.Text_CrossHairs);

            InitializeAnnotationButton(textHelpToolStripMenuItem,
                "Text_Help", AnnotationType.Text_Help);

            InitializeAnnotationButton(textInsertToolStripMenuItem,
                "Text_Insert", AnnotationType.Text_Insert);

            InitializeAnnotationButton(textKeyToolStripMenuItem,
                "Text_Key", AnnotationType.Text_Key);

            InitializeAnnotationButton(textNewParagraphToolStripMenuItem,
                "Text_NewParagraph", AnnotationType.Text_NewParagraph);

            InitializeAnnotationButton(textNoteToolStripMenuItem,
                "Text_Note", AnnotationType.Text_Note);

            InitializeAnnotationButton(textParagraphToolStripMenuItem,
                "Text_Paragraph", AnnotationType.Text_Paragraph);

            InitializeAnnotationButton(textRightArrowToolStripMenuItem,
                "Text_RightArrow", AnnotationType.Text_RightArrow);

            InitializeAnnotationButton(textRightPointerToolStripMenuItem,
                "Text_RightPointer", AnnotationType.Text_RightPointer);

            InitializeAnnotationButton(textStarToolStripMenuItem,
                "Text_Star", AnnotationType.Text_Star);

            InitializeAnnotationButton(textUpArrowToolStripMenuItem,
                "Text_UpArrow", AnnotationType.Text_UpArrow);

            InitializeAnnotationButton(textUpLeftArrowToolStripMenuItem,
                "Text_UpLeftArrow", AnnotationType.Text_UpLeftArrow);

            InitializeAnnotationButton(officeDocumentToolStripMenuItem,
                "OfficeDocument", AnnotationType.OfficeDocument);

            InitializeAnnotationButton(formattedTextToolStripSplitButton,
                "EmptyDocument", AnnotationType.EmptyOfficeDocument);

            InitializeAnnotationButton(chartToolStripButton,
                "Chart", AnnotationType.Chart);
        }

        /// <summary>
        /// Initializes the annotation button.
        /// </summary>
        /// <param name="annotationButton">A button, which must be clicked for starting of annotation building.</param>
        /// <param name="annotationImageResourceName">Name of the resource, which stores image for annotation button.</param>
        /// <param name="annotationType">The annotation type, which must be built when button is clicked.</param>
        private void InitializeAnnotationButton(
            ToolStripItem annotationButton,
            string annotationImageResourceName,
            AnnotationType annotationType)
        {
            string resourceNameFormatString = "DemosCommonCode.Pdf.AnnotationTool.Annotations.Resources.{0}.png";
            annotationButton.Image = DemosResourcesManager.GetResourceAsBitmap(string.Format(resourceNameFormatString, annotationImageResourceName));

            _toolStripItemToAnnotationType[annotationButton] = annotationType;
        }

        /// <summary>
        /// Handles the ButtonClick event of AddAndBuildAnnotationToolStripButton object.
        /// </summary>
        private void addAndBuildAnnotationToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            ToolStripItem toolStripItem = (ToolStripItem)sender;

            // get new building annotation type
            AnnotationType annotationType = _toolStripItemToAnnotationType[toolStripItem];

            // if buiding must be stopped
            if (_lastBuiltAnnotationType == annotationType ||
               (sender is CheckedToolStripSplitButton &&
               ((CheckedToolStripSplitButton)sender).Checked))
            {
                toolStripItem = null;
                annotationType = AnnotationType.Unknown;
            }

            // cancel current building
            _annotationTool.CancelBuilding();

            // select the button of building annotation
            SetSelectedAnnotationButton(toolStripItem);
            // add and build annotation
            AddAndBuildAnnotation(annotationType);
        }

        /// <summary>
        /// Sets the selected annotation button.
        /// </summary>
        /// <param name="annotationButton">The annotation button, which must be selected.</param>
        private void SetSelectedAnnotationButton(ToolStripItem annotationButton)
        {
            // uncheck current button
            SetAnnotationButtonCheckedState(_selectedAnnotationButton, false);

            // check specified button
            SetAnnotationButtonCheckedState(annotationButton, true);
            _selectedAnnotationButton = annotationButton;
        }

        /// <summary>
        /// Sets the checked state of annotation button.
        /// </summary>
        /// <param name="annotationButton">The annotation button.</param>
        /// <param name="isAnnotationButtonChecked">Indicates that annotation button is checked.</param>
        private void SetAnnotationButtonCheckedState(ToolStripItem annotationButton, bool isAnnotationButtonChecked)
        {
            if (annotationButton == null)
                return;

            if (annotationButton is ToolStripButton)
            {
                ((ToolStripButton)annotationButton).Checked = isAnnotationButtonChecked;
            }
            else if (annotationButton is ToolStripMenuItem)
            {
                ((ToolStripMenuItem)annotationButton).Checked = isAnnotationButtonChecked;

                if (annotationButton.OwnerItem != null)
                    SetAnnotationButtonCheckedState(annotationButton.OwnerItem, isAnnotationButtonChecked);
            }
            else if (annotationButton is CheckedToolStripSplitButton)
            {
                ((CheckedToolStripSplitButton)annotationButton).Checked = isAnnotationButtonChecked;
            }
        }

        /// <summary>
        /// Ends the annotation building.
        /// </summary>
        private void EndBuilding()
        {
            _lastBuiltAnnotationType = AnnotationType.Unknown;
            SetSelectedAnnotationButton(null);
        }

        #endregion


        #region AddAndBuild...

        /// <summary>
        /// Adds and builds a PDF annotation.
        /// </summary>
        /// <param name="annotationType">The type of annotation, which must be built.</param>
        private void AddAndBuildAnnotation(AnnotationType annotationType)
        {
            try
            {
                _lastBuiltAnnotationType = annotationType;

                switch (annotationType)
                {
                    case AnnotationType.Line:
                        AddAndBuildLineAnnotation(
                            PdfAnnotationLineEndingStyle.None,
                            PdfAnnotationLineEndingStyle.None);
                        break;

                    case AnnotationType.LineWithArrow:
                        AddAndBuildLineAnnotation(
                            PdfAnnotationLineEndingStyle.OpenArrow,
                            PdfAnnotationLineEndingStyle.None);
                        break;

                    case AnnotationType.LineWithArrows:
                        AddAndBuildLineAnnotation(
                            PdfAnnotationLineEndingStyle.OpenArrow,
                            PdfAnnotationLineEndingStyle.OpenArrow);
                        break;

                    case AnnotationType.Ink:
                        AddAndBuildInkAnnotation();
                        break;

                    case AnnotationType.Rectangle:
                        AddAndBuildSquareAnnotation(
                            PdfAnnotationBorderEffectType.Solid,
                            Color.Empty, 5);
                        break;

                    case AnnotationType.FilledRectangle:
                        AddAndBuildSquareAnnotation(
                            PdfAnnotationBorderEffectType.Solid,
                            _annotationFillColor, 5);
                        break;

                    case AnnotationType.CloudRectangle:
                        AddAndBuildSquareAnnotation(
                            PdfAnnotationBorderEffectType.Cloudy,
                            Color.Empty, 1);
                        break;

                    case AnnotationType.CloudFilledRectangle:
                        AddAndBuildSquareAnnotation(
                            PdfAnnotationBorderEffectType.Cloudy,
                            _annotationFillColor, 1);
                        break;

                    case AnnotationType.Ellipse:
                        AddAndBuildCircleAnnotation(
                            PdfAnnotationBorderEffectType.Solid,
                            Color.Empty, 5);
                        break;

                    case AnnotationType.FilledEllipse:
                        AddAndBuildCircleAnnotation(
                            PdfAnnotationBorderEffectType.Solid,
                            _annotationFillColor, 5);
                        break;

                    case AnnotationType.CloudEllipse:
                        AddAndBuildCircleAnnotation(
                            PdfAnnotationBorderEffectType.Cloudy,
                            Color.Empty, 1);
                        break;

                    case AnnotationType.CloudFilledEllipse:
                        AddAndBuildCircleAnnotation(
                            PdfAnnotationBorderEffectType.Cloudy,
                            _annotationFillColor, 1);
                        break;

                    case AnnotationType.Polyline:
                        AddAndBuildPolylineAnnotation(
                            PdfAnnotationLineEndingStyle.None,
                             PdfAnnotationLineEndingStyle.None);
                        break;

                    case AnnotationType.PolylineWithArrow:
                        AddAndBuildPolylineAnnotation(
                            PdfAnnotationLineEndingStyle.OpenArrow,
                             PdfAnnotationLineEndingStyle.None);
                        break;

                    case AnnotationType.PolylineWithArrows:
                        AddAndBuildPolylineAnnotation(
                            PdfAnnotationLineEndingStyle.OpenArrow,
                             PdfAnnotationLineEndingStyle.OpenArrow);
                        break;

                    case AnnotationType.FreehandPolyline:
                        AddAndBuildFreehandPolylineAnnotation();
                        break;

                    case AnnotationType.Polygon:
                        AddAndBuildPolygonAnnotation(
                            PdfAnnotationBorderEffectType.Solid,
                            Color.Empty, 5);
                        break;

                    case AnnotationType.FilledPolygon:
                        AddAndBuildPolygonAnnotation(
                            PdfAnnotationBorderEffectType.Solid,
                            _annotationFillColor, 5);
                        break;

                    case AnnotationType.CloudPolygon:
                        AddAndBuildPolygonAnnotation(
                            PdfAnnotationBorderEffectType.Cloudy,
                            Color.Empty, 1);
                        break;

                    case AnnotationType.CloudFilledPolygon:
                        AddAndBuildPolygonAnnotation(
                            PdfAnnotationBorderEffectType.Cloudy,
                            _annotationFillColor, 1);
                        break;

                    case AnnotationType.FreehandPolygon:
                        AddAndBuildFreehandPolygonAnnotation(_annotationFillColor);
                        break;

                    case AnnotationType.Link:
                        AddAndBuildLinkAnnotation();
                        break;

                    case AnnotationType.Label:
                        AddAndBuildLabelAnnotation();
                        break;

                    case AnnotationType.Text:
                        AddAndBuildTextAnnotation(PdfAnnotationBorderEffectType.Solid);
                        break;

                    case AnnotationType.CloudText:
                        AddAndBuildTextAnnotation(PdfAnnotationBorderEffectType.Cloudy);
                        break;

                    case AnnotationType.FreeText:
                        AddAndBuildFreeTextAnnotation(PdfAnnotationBorderEffectType.Solid);
                        break;

                    case AnnotationType.CloudFreeText:
                        AddAndBuildFreeTextAnnotation(PdfAnnotationBorderEffectType.Cloudy);
                        break;

                    case AnnotationType.FileAttachment:
                        AddAndBuildFileAttachmentAnnotation(_previousFileAttachmentIconName);
                        break;

                    case AnnotationType.GraphFileAttachment:
                        AddAndBuildFileAttachmentAnnotation("Graph");
                        break;

                    case AnnotationType.PushPinFileAttachment:
                        AddAndBuildFileAttachmentAnnotation("PushPin");
                        break;

                    case AnnotationType.PaperclipFileAttachment:
                        AddAndBuildFileAttachmentAnnotation("Paperclip");
                        break;

                    case AnnotationType.TagFileAttachment:
                        AddAndBuildFileAttachmentAnnotation("Tag");
                        break;

                    case AnnotationType.Text_Comment:
                        AddAndBuildTextAnnotation(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_COMMENT);
                        break;

                    case AnnotationType.Text_Check:
                        AddAndBuildTextAnnotation("Check");
                        break;

                    case AnnotationType.Text_Checkmark:
                        AddAndBuildTextAnnotation("Checkmark");
                        break;

                    case AnnotationType.Text_Circle:
                        AddAndBuildTextAnnotation("Circle");
                        break;

                    case AnnotationType.Text_Rectangle:
                        AddAndBuildTextAnnotation("Rectangle");
                        break;

                    case AnnotationType.Text_Cross:
                        AddAndBuildTextAnnotation("Cross");
                        break;

                    case AnnotationType.Text_CrossHairs:
                        AddAndBuildTextAnnotation("CrossHairs");
                        break;

                    case AnnotationType.Text_Help:
                        AddAndBuildTextAnnotation(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_HELP);
                        break;

                    case AnnotationType.Text_Insert:
                        AddAndBuildTextAnnotation(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_INSERT);
                        break;

                    case AnnotationType.Text_Key:
                        AddAndBuildTextAnnotation("Key");
                        break;

                    case AnnotationType.Text_NewParagraph:
                        AddAndBuildTextAnnotation("NewParagraph");
                        break;

                    case AnnotationType.Text_Note:
                        AddAndBuildTextAnnotation("Note");
                        break;

                    case AnnotationType.Text_Paragraph:
                        AddAndBuildTextAnnotation("Paragraph");
                        break;

                    case AnnotationType.Text_RightArrow:
                        AddAndBuildTextAnnotation("RightArrow");
                        break;

                    case AnnotationType.Text_RightPointer:
                        AddAndBuildTextAnnotation("RightPointer");
                        break;

                    case AnnotationType.Text_Star:
                        AddAndBuildTextAnnotation("Star");
                        break;

                    case AnnotationType.Text_UpArrow:
                        AddAndBuildTextAnnotation("UpArrow");
                        break;

                    case AnnotationType.Text_UpLeftArrow:
                        AddAndBuildTextAnnotation("UpLeftArrow");
                        break;

                    case AnnotationType.EmptyOfficeDocument:
                        AddAndBuildOfficeDocumentAnnotation(DemosResourcesManager.GetResourceAsStream("EmptyDocument.docx"));
                        break;

                    case AnnotationType.OfficeDocument:
#if !REMOVE_OFFICE_PLUGIN
                        Stream officeDocumentStream = OfficeDemosTools.SelectOfficeDocument();
                        if (officeDocumentStream != null)
                            AddAndBuildOfficeDocumentAnnotation(officeDocumentStream);
#endif
                        break;

                    case AnnotationType.Chart:
                        AddAndBuildChartAnnotation();
                        break;
                }
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e.Message);
            }
        }

        /// <summary>
        /// Adds and builds a PDF annotation.
        /// </summary>
        /// <param name="annotation">A PDF annotation.</param>
        /// <returns>A PDF annotation view.</returns>
        /// <exception cref="InvalidOperationException">Thrown if annotation tool is empty.</exception>
        private PdfAnnotationView AddAndBuildAnnotation(PdfAnnotation annotation)
        {
            // if annotation tool is empty
            if (_annotationTool == null)
                throw new InvalidOperationException();

            annotation.Modified = DateTime.Now;
            annotation.Title = Environment.UserName;

            SetInteractionMode(annotation);

            if (!_annotationTool.ImageViewer.Focused)
                _annotationTool.ImageViewer.Focus();

            // if focused annotation view is not empty
            if (_annotationTool.FocusedAnnotationView != null)
            {
                // if focused annotation view is building
                if (_annotationTool.FocusedAnnotationView.IsBuilding)
                {
                    // if focused annotation view building is started
                    if (_annotationTool.FocusedAnnotationView.IsBuildingStarted)
                    {
                        // finish interaction
                        _annotationTool.FinishInteraction();
                    }
                    // if focused annotation view building is not started
                    else
                    {
                        // cancel building of annotation
                        _annotationTool.CancelBuilding();
                    }
                }
            }

            // if the unique name for the annotation must be created
            if (_annotationTool.InteractiveFormEditorManager.UseUniqueAnnotationName)
            {
                // get the unique name
                annotation.Name = _annotationTool.InteractiveFormEditorManager.GetUniqueAnnotationName(
                    _annotationTool.AnnotationCollection, annotation);
            }

            try 
            { 
                // build the annotation
                return _annotationTool.AddAndBuildAnnotation(annotation);
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Adds and builds a PDF annotation.
        /// </summary>
        /// <param name="annotationView">A PDF annotation view.</param>
        /// <exception cref="InvalidOperationException">Thrown if annotation tool is empty.</exception>
        private void AddAndBuildAnnotation(PdfAnnotationView annotationView)
        {
            // if annotation tool is empty
            if (_annotationTool == null)
                throw new InvalidOperationException();

            SetInteractionMode(annotationView.Annotation);

            // if focused annotation view is not empty
            if (_annotationTool.FocusedAnnotationView != null)
            {
                // if focused annotation view is building
                if (_annotationTool.FocusedAnnotationView.IsBuilding)
                {
                    // if focused annotation view building is started
                    if (_annotationTool.FocusedAnnotationView.IsBuildingStarted)
                    {
                        // finish interaction
                        _annotationTool.FinishInteraction();
                    }
                    // if focused annotation view building is not started
                    else
                    {
                        // cancel building annotation
                        _annotationTool.CancelBuilding();
                    }

                    // if focused annotation view is ink annotation view
                    if (_annotationTool.FocusedAnnotationView is PdfInkAnnotationView)
                        return;
                }
            }

            // if the unique name for the annotation must be created
            if (_annotationTool.InteractiveFormEditorManager.UseUniqueAnnotationName)
            {
                // get the unique name
                annotationView.Annotation.Name = _annotationTool.InteractiveFormEditorManager.GetUniqueAnnotationName(
                    _annotationTool.AnnotationCollection, annotationView.Annotation);
            }

            // build the annotation
            _annotationTool.AddAndBuildAnnotation(annotationView);
        }


        /// <summary>
        /// Adds and builds a line annotation.
        /// </summary>
        /// <param name="startPointLineEndingStyle">The line ending style of start point.</param>
        /// <param name="endPointLineEndingStyle">The line ending style of end point.</param>
        private void AddAndBuildLineAnnotation(
            PdfAnnotationLineEndingStyle startPointLineEndingStyle,
            PdfAnnotationLineEndingStyle endPointLineEndingStyle)
        {
            // create new line annotation
            PdfLineAnnotation line = new PdfLineAnnotation(AnnotationTool.FocusedPage);
            // set the annotation rectangle
            line.Rectangle = GetNewAnnotationRectangle();
            // set the annotation color
            line.Color = Color.Black;
            // set the annotation border width
            line.BorderWidth = 3;
            if (startPointLineEndingStyle != PdfAnnotationLineEndingStyle.None)
            {
                // set start point line ending style
                line.StartPointLineEndingStyle = startPointLineEndingStyle;
            }
            if (endPointLineEndingStyle != PdfAnnotationLineEndingStyle.None)
            {
                // set end point line ending style
                line.EndPointLineEndingStyle = endPointLineEndingStyle;
            }

            // build the line annotation
            AddAndBuildAnnotation(line);
        }

        /// <summary>
        /// Adds and builds a polyline annotation.
        /// </summary>
        /// <param name="startPointLineEndingStyle">The line ending style of start point.</param>
        /// <param name="endPointLineEndingStyle">The line ending style of end point.</param>
        private void AddAndBuildPolylineAnnotation(
            PdfAnnotationLineEndingStyle startPointLineEndingStyle,
            PdfAnnotationLineEndingStyle endPointLineEndingStyle)
        {
            // create new polyline annotation
            PdfPolylineAnnotation polyline = new PdfPolylineAnnotation(AnnotationTool.FocusedPage);
            // set the annotation rectangle
            polyline.Rectangle = GetNewAnnotationRectangle();
            // set the annotation color
            polyline.Color = Color.Black;
            // set the annotation border width
            polyline.BorderWidth = 3;
            if (startPointLineEndingStyle != PdfAnnotationLineEndingStyle.None)
            {
                // set start point line ending style
                polyline.StartPointLineEndingStyle = startPointLineEndingStyle;
            }
            if (endPointLineEndingStyle != PdfAnnotationLineEndingStyle.None)
            {
                // set end point line ending style
                polyline.EndPointLineEndingStyle = endPointLineEndingStyle;
            }

            // build the polyline annotation
            AddAndBuildAnnotation(polyline);
        }

        /// <summary>
        /// Adds and builds a freehand polyline annotation.
        /// </summary>
        private void AddAndBuildFreehandPolylineAnnotation()
        {
            // create new polyline annotation
            PdfPolylineAnnotation polyline = new PdfPolylineAnnotation(AnnotationTool.FocusedPage);
            // set the annotation rectangle
            polyline.Rectangle = GetNewAnnotationRectangle();
            // set the annotation color
            polyline.Color = Color.Red;
            // set the annotation border width
            polyline.BorderWidth = 3;
            // create new polyline annotation view
            PdfPolygonalAnnotationView view = new PdfPolylineAnnotationView(polyline, AnnotationTool.FocusedJsDoc);

            // create new freehand builder
            PointBasedObjectFreehandBuilder builder = new PointBasedObjectFreehandBuilder(view, 2, 0.1f);
            // 0 - MouseUp, 1 - MouseClick, 2 - MouseDoubleClick
            builder.FinishBuildingMouseClickCount = 2;
            // set the freehand builder to the polyline annotation view
            view.Builder = builder;

            // build the polyline annotation
            AddAndBuildAnnotation(view);
        }

        /// <summary>
        /// Adds and builds an Ink annotation.
        /// </summary>
        private void AddAndBuildInkAnnotation()
        {
            // create new ink annotation
            PdfInkAnnotation ink = new PdfInkAnnotation(AnnotationTool.FocusedPage);
            // set the annotation rectangle
            ink.Rectangle = GetNewAnnotationRectangle();
            // set the annotation color
            ink.Color = Color.Red;
            // set the annotation border width
            ink.BorderWidth = 2;
            // create new ink annotation view
            PdfInkAnnotationView inkView = new PdfInkAnnotationView(ink, AnnotationTool.FocusedJsDoc);

            // get a minimum line border width
            float accuracy = ink.BorderWidth;
            // create new annotation builder
            PdfInkAnnotationBuilder builder = new PdfInkAnnotationBuilder(inkView, accuracy);
            // set the builder cursor
            builder.BuildingArea.Cursor = Cursors.Cross;
            // set the annotation builder to the ink annotation view
            inkView.Builder = builder;

            // build the ink annotation
            AddAndBuildAnnotation(inkView);
        }

        /// <summary>
        /// Adds and builds a freehand polygon annotation.
        /// </summary>
        /// <param name="interiorColor">The background color of polygon annotation.</param>
        private void AddAndBuildFreehandPolygonAnnotation(Color interiorColor)
        {
            // create new polygon annotation
            PdfPolygonAnnotation polygon = new PdfPolygonAnnotation(AnnotationTool.FocusedPage);
            // set the annotation rectangle
            polygon.Rectangle = GetNewAnnotationRectangle();
            // set the annotation color
            polygon.Color = Color.Red;
            // set the annotation background color
            polygon.InteriorColor = interiorColor;
            // set the annotation border width
            polygon.BorderWidth = 3;
            // create new polygon annotation view
            PdfPolygonalAnnotationView view = new PdfPolygonAnnotationView(polygon, AnnotationTool.FocusedJsDoc);

            // create new freehand builder
            PointBasedObjectFreehandBuilder builder = new PointBasedObjectFreehandBuilder(view, 2, 0.1f);
            // 0 - MouseUp, 1 - MouseClick, 2 - MouseDoubleClick
            builder.FinishBuildingMouseClickCount = 2;
            // set the freehand builder to the polygon annotation view
            view.Builder = builder;

            // build the polygon annotation
            AddAndBuildAnnotation(view);
        }

        /// <summary>
        /// Adds and builds a polygon annotation.
        /// </summary>
        /// <param name="borderEffect">The border effect of polygon annotation.</param>
        /// <param name="interiorColor">The background color of polygon annotation.</param>
        /// <param name="borderWidth">The border width of circle annotation.</param>
        private void AddAndBuildPolygonAnnotation(
            PdfAnnotationBorderEffectType borderEffect,
            Color interiorColor,
            int borderWidth)
        {
            // create new polygon annotation
            PdfPolygonAnnotation polygon = new PdfPolygonAnnotation(AnnotationTool.FocusedPage);
            // set the annotation rectangle
            polygon.Rectangle = GetNewAnnotationRectangle();
            // set the annotation color
            polygon.Color = Color.Black;
            // set the annotation background color
            polygon.InteriorColor = interiorColor;
            // set the annotation border width
            polygon.BorderWidth = borderWidth;
            // set the annotation border effect
            polygon.BorderEffect = borderEffect;
            polygon.BorderEffectIntensity = 2f;
            // build the polygon annotation
            AddAndBuildAnnotation(polygon);
        }

        /// <summary>
        /// Adds and builds a circle annotation.
        /// </summary>
        /// <param name="borderEffect">The border effect of circle annotation.</param>
        /// <param name="interiorColor">The background color of circle annotation.</param>
        /// <param name="borderWidth">The border width of circle annotation.</param>
        private void AddAndBuildCircleAnnotation(
            PdfAnnotationBorderEffectType borderEffect,
            Color interiorColor,
            int borderWidth)
        {
            // create new circle annotation
            PdfCircleAnnotation circle = new PdfCircleAnnotation(AnnotationTool.FocusedPage);
            // set the annotation rectangle
            circle.Rectangle = GetNewAnnotationRectangle();
            // set the annotation color
            circle.Color = Color.Black;
            // set the annotation border effect
            circle.BorderEffect = borderEffect;
            circle.BorderEffectIntensity = 2f;
            // set the annotation background color
            circle.InteriorColor = interiorColor;
            // set the annotation border width
            circle.BorderWidth = borderWidth;

            // build the polygon annotation
            AddAndBuildAnnotation(circle);
        }

        /// <summary>
        /// Adds and builds a square annotation.
        /// </summary>
        /// <param name="borderEffect">The border effect of square annotation.</param>
        /// <param name="interiorColor">The background color of square annotation.</param>
        /// <param name="borderWidth">The border width of circle annotation.</param>
        private void AddAndBuildSquareAnnotation(
            PdfAnnotationBorderEffectType borderEffect,
            Color interiorColor,
            int borderWidth)
        {
            // create new square annotation
            PdfSquareAnnotation square = new PdfSquareAnnotation(AnnotationTool.FocusedPage);
            // set the annotation rectangle
            square.Rectangle = GetNewAnnotationRectangle();
            // set the annotation color
            square.Color = Color.Black;
            // set the annotation background color
            square.InteriorColor = interiorColor;
            // set the annotation border width
            square.BorderWidth = borderWidth;
            // set the annotation border effect
            square.BorderEffect = borderEffect;
            square.BorderEffectIntensity = 2f;

            // build the square annotation
            AddAndBuildAnnotation(square);

            // set default size of building annotation
            PointBasedObjectLineBuilder builder = AnnotationTool.FocusedAnnotationView.Builder as PointBasedObjectLineBuilder;
            if (builder != null)
                builder.DefaultSize = new SizeF(200, 100);
        }

        /// <summary>
        /// Adds and builds a file attachment annotation.
        /// </summary>
        /// <param name="iconName">The icon of file attachment annotation.</param>
        private void AddAndBuildFileAttachmentAnnotation(string iconName)
        {
            // create new file attachment annotation
            PdfFileAttachmentAnnotation fileAttachment = new PdfFileAttachmentAnnotation(AnnotationTool.FocusedPage);
            // set the annotation color
            fileAttachment.Color = Color.Yellow;
            // set the annotation rectangle
            fileAttachment.Rectangle = GetNewAnnotationRectangle();
            // if icon name is not empty
            if (!string.IsNullOrEmpty(iconName))
            {
                // set the icon name
                fileAttachment.IconName = iconName;
                _previousFileAttachmentIconName = iconName;
            }

            // build the file attachment annotation
            AddAndBuildAnnotation(fileAttachment);
        }

        /// <summary>
        /// Adds and builds a office document annotation.
        /// </summary>
        /// <param name="documentStream">The document stream.</param>
        public PdfOfficeDocumentAnnotation AddAndBuildOfficeDocumentAnnotation(Stream documentStream)
        {
            // create new office doeument annotation
            PdfOfficeDocumentAnnotation officeAnnotation = new PdfOfficeDocumentAnnotation(AnnotationTool.FocusedPage);
            officeAnnotation.CreationDate = DateTime.Now;

            // set office document stream
            officeAnnotation.SetDocumentStream(documentStream);
            documentStream.Dispose();

            // set the annotation rectangle
            officeAnnotation.Rectangle = GetNewAnnotationRectangle();
            
            // build the comment annotation
            AddAndBuildAnnotation(officeAnnotation);
            return officeAnnotation;
        }

        /// <summary>
        /// Adds and builds a chart annotation.
        /// </summary>
        public PdfOfficeDocumentAnnotation AddAndBuildChartAnnotation()
        {
            // select chart
            Stream documentStream = OfficeDemosTools.SelectChartResource();
            if (documentStream != null)
            {
                // create new office doeument annotation
                PdfOfficeDocumentAnnotation officeAnnotation = new PdfOfficeDocumentAnnotation(AnnotationTool.FocusedPage);
                officeAnnotation.CreationDate = DateTime.Now;

                // set office document stream
                officeAnnotation.SetDocumentStream(documentStream);
                documentStream.Dispose();

                // enable use releative size instread specified size of graphics object
                officeAnnotation.UseGraphicObjectReleativeSize = true;

                // set the annotation rectangle
                officeAnnotation.Rectangle = GetNewAnnotationRectangle();

                // build the comment annotation
                AddAndBuildAnnotation(officeAnnotation);
                return officeAnnotation;
            }
            return null;
        }


        /// <summary>
        /// Adds and builds a text annotation.
        /// </summary>
        /// <param name="stickName">The stick name.</param>
        public PdfTextAnnotation AddAndBuildTextAnnotation(string stickName)
        {
            // create new file attachment annotation
            PdfTextAnnotation commentAnnotation = new PdfTextAnnotation(AnnotationTool.FocusedPage);
            commentAnnotation.CreationDate = DateTime.Now;
            commentAnnotation.StickName = stickName;
            // set the annotation color
            if (stickName == "Checkmark")
                commentAnnotation.Color = Color.FromArgb(64, 64, 64);
            else
                commentAnnotation.Color = Color.Yellow;
            // set the annotation rectangle
            commentAnnotation.Rectangle = GetNewAnnotationRectangle();
            // build the comment annotation
            AddAndBuildAnnotation(commentAnnotation);
            return commentAnnotation;
        }


        /// <summary>
        /// Adds and builds a link annotation.
        /// </summary>
        private void AddAndBuildLinkAnnotation()
        {
            // create new link annotation
            PdfLinkAnnotation link = new PdfLinkAnnotation(AnnotationTool.FocusedPage);
            // set the annotation rectangle
            link.Rectangle = GetNewAnnotationRectangle();
            // create new link annotation view
            PdfAnnotationView view = AddAndBuildAnnotation(link);
            // if annotation tool interaction mode is not edit
            if (AnnotationTool.InteractionMode != PdfAnnotationInteractionMode.Edit)
            {
                // highlight link annotation
                ((PdfLinkAnnotationView)view).IsHighlighted = true;
            }
        }

        /// <summary>
        /// Adds and builds a text annotation.
        /// </summary>
        /// <param name="borderEffect">The border effect of text annotation.</param>
        private void AddAndBuildTextAnnotation(
            PdfAnnotationBorderEffectType borderEffect)
        {
            // create new free text annotation
            PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(AnnotationTool.FocusedPage);
            // set the annotation rectangle
            textAnnotation.Rectangle = PdfAnnotationsTools.GetNewAnnotationRectangle(AnnotationTool, _visualToolMouseObserver,
                TEXT_FONT_DEFAULT_SIZE * 6f, TEXT_FONT_DEFAULT_SIZE * 1.5f);
            // set the annotation color
            textAnnotation.Color = Color.White;
            // set the font of the annotation
            PdfFont font = textAnnotation.Document.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);
            textAnnotation.SetTextDefaultAppearance(font, TEXT_FONT_DEFAULT_SIZE, Color.Black);
            // set the annotation border width
            textAnnotation.BorderWidth = 1;
            // set the annotation border effect
            textAnnotation.BorderEffect = borderEffect;
            textAnnotation.BorderEffectIntensity = 2f;

            // build the free text annotation
            AddAndBuildAnnotation(textAnnotation);
        }

        /// <summary>
        /// Adds and builds a label annotation.
        /// </summary>
        private void AddAndBuildLabelAnnotation()
        {
            // create new free text annotation
            PdfFreeTextAnnotation label = new PdfFreeTextAnnotation(AnnotationTool.FocusedPage);
            // set the annotation rectangle
            label.Rectangle = PdfAnnotationsTools.GetNewAnnotationRectangle(AnnotationTool, _visualToolMouseObserver,
                TEXT_FONT_DEFAULT_SIZE * 6f, TEXT_FONT_DEFAULT_SIZE * 1.5f);
            // set the content of the annotation
            label.Contents = "Label";
            // set the font of the annotation
            PdfFont font = label.Document.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);
            label.SetTextDefaultAppearance(font, TEXT_FONT_DEFAULT_SIZE, Color.Black);
            // set the annotation border width
            label.BorderWidth = 0;
            label.IsLocked = true;

            // build the free text annotation
            AddAndBuildAnnotation(label);
        }

        /// <summary>
        /// Adds and builds a free text annotation.
        /// </summary>
        /// <param name="borderEffect">The border effect of free text annotation.</param>
        private void AddAndBuildFreeTextAnnotation(
            PdfAnnotationBorderEffectType borderEffect)
        {
            // create new free text annotation
            PdfFreeTextAnnotation freeText = new PdfFreeTextAnnotation(AnnotationTool.FocusedPage);
            freeText.LineEndingStyle = PdfAnnotationLineEndingStyle.OpenArrow;
            // set the annotation rectangle
            freeText.Rectangle = GetNewAnnotationRectangle();
            // set the annotation color
            freeText.Color = Color.White;
            // set the font of the annotation
            PdfFont font = freeText.Document.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);
            freeText.SetTextDefaultAppearance(font, TEXT_FONT_DEFAULT_SIZE, Color.Black);
            // set the annotation border width
            freeText.BorderWidth = 1;
            // set the annotation border effect
            freeText.BorderEffect = borderEffect;
            freeText.BorderEffectIntensity = 2f;
            // set the annotation rectangle
            freeText.Rectangle = new RectangleF(0, 0, 100, 100);
            // set the annotation text padding
            freeText.TextPadding = new PaddingF(0, 100 - TEXT_FONT_DEFAULT_SIZE * 1.5f, 0, 0);
            // set the annotation callout line
            freeText.CalloutLinePoints = new PointF[3] {
                new PointF(50, 100),
                new PointF(50, 50),
                new PointF(50, TEXT_FONT_DEFAULT_SIZE * 1.5f) };

            // build the free text annotation
            AddAndBuildAnnotation(freeText);
        }

        #endregion


        /// <summary>
        /// Determines whether the specified view is not widget annotation.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns>
        /// <b>true</b> if the annotation view is not widget annotation; otherwise, <b>false</b>.
        /// </returns>
        private bool IsNotPdfWidgetAnnotation(PdfAnnotationView view)
        {
            if (view is PdfWidgetAnnotationView)
                return false;

            return true;
        }

        /// <summary>
        /// Sets the embedded file to the PDF file attachment annotation.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        /// <param name="fileAttachmentAnnotation">The PDF file attachment annotation.</param>
        private static void SetEmbeddedFile(PdfDocument document, PdfFileAttachmentAnnotation fileAttachmentAnnotation)
        {
            // create embedded file specification form
            using (EmbeddedFileSpecificationForm embeddedFileSpecificationForm = new EmbeddedFileSpecificationForm())
            {
                // get file specification
                PdfEmbeddedFileSpecification fileSpecification = fileAttachmentAnnotation.FileSpecification;
                // if file specification is not empty
                if (fileSpecification == null)
                {
                    // create new file specification
                    fileSpecification = new PdfEmbeddedFileSpecification(document);
                }
                // set file specification to the form
                embeddedFileSpecificationForm.EmbeddedFileSpecification = fileSpecification;

                // if dialog result is OK
                if (embeddedFileSpecificationForm.ShowDialog() == DialogResult.OK)
                {
                    // set file specification to the file attachment annotation
                    fileAttachmentAnnotation.FileSpecification = fileSpecification;
                }
            }
        }

        /// <summary>
        /// Returns the rectangle for new annotation specified using
        /// the appearance generator key (builder button).
        /// </summary>
        private RectangleF GetNewAnnotationRectangle()
        {
            return PdfAnnotationsTools.GetNewAnnotationRectangle(AnnotationTool, _visualToolMouseObserver, 20, 20);
        }

        /// <summary>
        /// Sets the interaction mode of PDF annotation tool.
        /// </summary>
        /// <param name="annotationToBuild">A PDF annotation.</param>
        private void SetInteractionMode(PdfAnnotation annotationToBuild)
        {
            _isInteractionModeChanging = true;

            switch (_annotationTool.InteractionMode)
            {
                case PdfAnnotationInteractionMode.None:
                case PdfAnnotationInteractionMode.View:
                    if (annotationToBuild is PdfMarkupAnnotation)
                        _annotationTool.InteractionMode = PdfAnnotationInteractionMode.Markup;
                    else
                        _annotationTool.InteractionMode = PdfAnnotationInteractionMode.Edit;
                    break;

                case PdfAnnotationInteractionMode.Markup:
                    if (!(annotationToBuild is PdfMarkupAnnotation))
                        _annotationTool.InteractionMode = PdfAnnotationInteractionMode.Edit;
                    break;
            }

            _isInteractionModeChanging = false;
        }

        #endregion

        #endregion

    }
}
