using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;

#if !REMOVE_ANNOTATION_PLUGIN
using Vintasoft.Imaging.Annotation.Comments;
using Vintasoft.Imaging.Annotation.UI.VisualTools;
#endif

using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;
using Vintasoft.Imaging.Pdf.UI.Annotations;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.UIActions;

using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.UI;

using DemosCommonCode.Annotation;
using Vintasoft.Imaging.Pdf.UI;
using Vintasoft.Imaging.Pdf;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit annotations of PDF interactive form of PDF document.
    /// </summary>
    public partial class PdfAnnotationToolControl : UserControl
    {

        #region Fields

        /// <summary>
        /// Dictionary: "State name" => "Menu item".
        /// </summary>
        Dictionary<string, ToolStripMenuItem> _commentStateNameToMenuItem;

        /// <summary>
        /// Hovered annotation view. Updates when the annotation context menu is opened.
        /// </summary>
        PdfAnnotationView _hoveredAnnotationView;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAnnotationToolControl"/> class.
        /// </summary>
        public PdfAnnotationToolControl()
        {
            _hoveredAnnotationToolTip = new ToolTip();
            _hoveredAnnotationToolTip.AutomaticDelay = 750;

            InitializeComponent();

            if (DesignMode)
                return;

            interactionModeViewRadioButton.Tag = PdfAnnotationInteractionMode.View;
            interactionModeMarkupRadioButton.Tag = PdfAnnotationInteractionMode.Markup;
            interactionModeEditRadioButton.Tag = PdfAnnotationInteractionMode.Edit;
            interactionModeNoneRadioButton.Tag = PdfAnnotationInteractionMode.None;
#if !REMOVE_ANNOTATION_PLUGIN
            _commentStateNameToMenuItem = new Dictionary<string, ToolStripMenuItem>();
            _commentStateNameToMenuItem.Add(CommentTools.COMMENT_STATE_REVIEW_ACCEPTED, statusAcceptedToolStripMenuItem);
            _commentStateNameToMenuItem.Add(CommentTools.COMMENT_STATE_REVIEW_REJECTED, statusRejectedToolStripMenuItem);
            _commentStateNameToMenuItem.Add(CommentTools.COMMENT_STATE_REVIEW_CANCELLED, statusCancelledToolStripMenuItem);
            _commentStateNameToMenuItem.Add(CommentTools.COMMENT_STATE_REVIEW_COMPLETED, statusCompletedToolStripMenuItem);
            _commentStateNameToMenuItem.Add(CommentTools.COMMENT_STATE_REVIEW_NONE, statusNoneToolStripMenuItem);
            foreach (string stateName in _commentStateNameToMenuItem.Keys)
                _commentStateNameToMenuItem[stateName].Tag = stateName;
#endif
        }

        #endregion



        #region Properties

        PdfAnnotationTool _pdfAnnotationTool;
        /// <summary>
        /// Gets or sets the PDF annotation tool.
        /// </summary>
        public PdfAnnotationTool AnnotationTool
        {
            get
            {
                return _pdfAnnotationTool;
            }
            set
            {
                if (_pdfAnnotationTool != null)
                    UnsubscribeFromPdfAnnotationToolEvents();

                _pdfAnnotationTool = value;
                AnnotationsControl.AnnotationTool = value;
                InteractiveFormControl.AnnotationTool = value;

                if (_pdfAnnotationTool != null)
                    SubscribeToPdfAnnotationToolEvents();

                UpdateUI();
            }
        }

        ToolTip _hoveredAnnotationToolTip;
        /// <summary>
        /// Gets or sets the tooltip of hovered annotation.
        /// </summary>
        public ToolTip HoveredAnnotationToolTip
        {
            get
            {
                return _hoveredAnnotationToolTip;
            }
            set
            {
                _hoveredAnnotationToolTip = value;
            }
        }

        /// <summary>
        /// Gets the copy action.
        /// </summary>
        public UIAction CopyAction
        {
            get
            {
                if (_pdfAnnotationTool.ImageViewer != null && _pdfAnnotationTool.ImageViewer.VisualTool != null)
                    return PdfDemosTools.GetUIAction<CopyItemUIAction>(_pdfAnnotationTool.ImageViewer.VisualTool);
                return null;
            }
        }

        /// <summary>
        /// Gets the cut action.
        /// </summary>
        public UIAction CutAction
        {
            get
            {
                if (_pdfAnnotationTool.ImageViewer != null && _pdfAnnotationTool.ImageViewer.VisualTool != null)
                    return PdfDemosTools.GetUIAction<CutItemUIAction>(_pdfAnnotationTool.ImageViewer.VisualTool);
                return null;
            }
        }

        /// <summary>
        /// Gets the paste action.
        /// </summary>
        public UIAction PasteAction
        {
            get
            {
                if (_pdfAnnotationTool.ImageViewer != null && _pdfAnnotationTool.ImageViewer.VisualTool != null)
                    return PdfDemosTools.GetUIAction<PasteItemUIAction>(_pdfAnnotationTool.ImageViewer.VisualTool);
                return null;
            }
        }

        /// <summary>
        /// Gets the delete action.
        /// </summary>
        public UIAction DeleteAction
        {
            get
            {
                if (_pdfAnnotationTool.ImageViewer != null && _pdfAnnotationTool.ImageViewer.VisualTool != null)
                    return PdfDemosTools.GetUIAction<DeleteItemUIAction>(_pdfAnnotationTool.ImageViewer.VisualTool);
                return null;
            }
        }

        /// <summary>
        /// Gets the bring to back action.
        /// </summary>
        public UIAction BringToBackAction
        {
            get
            {
                if (_pdfAnnotationTool.ImageViewer != null && _pdfAnnotationTool.ImageViewer.VisualTool != null)
                    return PdfDemosTools.GetUIAction<BringToBackItemUIAction>(_pdfAnnotationTool.ImageViewer.VisualTool);
                return null;
            }
        }

        /// <summary>
        /// Gets the bring to front action.
        /// </summary>
        public UIAction BringToFrontAction
        {
            get
            {
                if (_pdfAnnotationTool.ImageViewer != null && _pdfAnnotationTool.ImageViewer.VisualTool != null)
                    return PdfDemosTools.GetUIAction<BringToFrontItemUIAction>(_pdfAnnotationTool.ImageViewer.VisualTool);
                return null;
            }
        }

#if !REMOVE_ANNOTATION_PLUGIN
        CommentVisualTool _commentTool;
        /// <summary>
        /// Sets the <see cref="CommentTool"/> that allows to operate the annotation comments.
        /// </summary>
        [DefaultValue((object)null)]
        public CommentVisualTool CommentTool
        {
            get
            {
                return _commentTool;
            }
            set
            {
                _commentTool = value;
            }
        }
#endif

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates the User Interface.
        /// </summary>
        public void UpdateUI()
        {
            AnnotationsControl.UpdateUI();
            InteractiveFormControl.UpdateUI();
            if (AnnotationTool != null)
            {
                multiSelectCheckBox.Checked = AnnotationTool.AllowMultipleSelection;
                highlightObjectsCheckBox.Checked = AnnotationTool.EditorModeHighlight;
                highlightFieldsCheckBox.Checked = AnnotationTool.FieldHighlight;
                tabNavigationLoopedOnPageCheckBox.Checked = AnnotationTool.IsNavigationLoopedOnFocusedPage;
                UpdateInteractionMode();
            }
        }

        /// <summary>
        /// Shows the form fields tab page.
        /// </summary>
        public void ShowFormFieldsTab()
        {
            toolsTabControl.SelectedTab = formFieldsTabPage;
        }

        /// <summary>
        /// Shows the annotations tab page.
        /// </summary>
        public void ShowAnnotationsTab()
        {
            toolsTabControl.SelectedTab = annotationsTabPage;
        }
        
        #endregion


        #region PROTECTED

        /// <summary>
        /// Raises event <see cref="E:System.Windows.Forms.Control.EnabledChanged" />.
        /// </summary>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            UpdateUI();
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the SelectedIndexChanged event of toolsTabControl object.
        /// </summary>
        private void toolsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cancel annotation building
            AnnotationTool.CancelBuilding();

            UpdateUI();

            // if annotation list must be updated
            if (toolsTabControl.SelectedTab == annotationsTabPage)
                AnnotationsControl.RefreshAnnotationList();
            else
                InteractiveFormControl.RefreshInteractiveFormTree();
        }

        /// <summary>
        /// Handles the CheckedChanged event of interactionModeRadioButton object.
        /// </summary>
        private void interactionModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (AnnotationTool != null)
                {
                    // cancel annotation building
                    AnnotationTool.CancelBuilding();

                    // if radio-button is checked
                    if (((RadioButton)sender).Checked)
                    {
                        // update annotation interaction mode

                        AnnotationTool.InteractionMode = (PdfAnnotationInteractionMode)((Control)sender).Tag;
                        editModeSettingsGroupBox.Enabled = AnnotationTool.InteractionMode == PdfAnnotationInteractionMode.Edit;
                    }
                }
            }
            catch (Exception exception)
            {
                DemosTools.ShowErrorMessage(exception.Message);
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of multiSelectCheckBox object.
        /// </summary>
        private void multiSelectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AnnotationTool != null)
                AnnotationTool.AllowMultipleSelection = multiSelectCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of highlightObjectsCheckBox object.
        /// </summary>
        private void highlightObjectsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AnnotationTool != null)
                AnnotationTool.EditorModeHighlight = highlightObjectsCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of highlightFieldsCheckBox object.
        /// </summary>
        private void highlightFieldsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AnnotationTool != null)
                AnnotationTool.FieldHighlight = highlightFieldsCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of tabNavigationLoopedOnPageCheckBox object.
        /// </summary>
        private void tabNavigationLoopedOnPageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AnnotationTool != null)
                AnnotationTool.IsNavigationLoopedOnFocusedPage = tabNavigationLoopedOnPageCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of buildContinuouslyCheckBox object.
        /// </summary>
        private void buildContinuouslyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AnnotationsControl.AnnotationBuilderControl.NeedBuildAnnotationsContinuously = buildContinuouslyCheckBox.Checked;
            InteractiveFormControl.InteractiveFormFieldBuilder.NeedBuildFormFieldsContinuously = buildContinuouslyCheckBox.Checked;
        }


        #region Annotation context menu

        /// <summary>
        /// Handles the Opened event of annotationContextMenuStrip object.
        /// </summary>
        private void annotationContextMenuStrip_Opened(object sender, EventArgs e)
        {
            bool hasFocusedAnnotation = false;

            // if annotation view is focused
            if (AnnotationTool.FocusedAnnotationView != null)
                hasFocusedAnnotation = true;

            if (!hasFocusedAnnotation)
            {
                // get the cursor point and convert it to viewer coordinates
                Point cursorPosition = AnnotationTool.ImageViewer.PointToClient(Cursor.Position);

                // get the hovered annotation view
                _hoveredAnnotationView = AnnotationTool.FindAnnotationView(cursorPosition.X, cursorPosition.Y, false);

                // if annotation is hovered
                if (_hoveredAnnotationView != null)
                    hasFocusedAnnotation = true;
                else
                    hasFocusedAnnotation = false;
            }

            // text is selected ?
            bool hasSelectedText = false;
            TextSelectionTool textSelection = VisualTool.FindVisualTool<TextSelectionTool>(AnnotationTool.ImageViewer.VisualTool);
            if (textSelection != null)
                hasSelectedText = textSelection.HasSelectedText;

            // update tool strip menu items

            bringToBackToolStripMenuItem.Enabled = CanUseAction(BringToBackAction);
            bringToFrontToolStripMenuItem.Enabled = CanUseAction(BringToFrontAction);
            propertiesToolStripMenuItem.Enabled = hasFocusedAnnotation;
            transformersToolStripMenuItem.Enabled = hasFocusedAnnotation;
            pasteToolStripMenuItem.Enabled = CanUseAction(PasteAction);
            copyToolStripMenuItem.Enabled = CanUseAction(CopyAction);
            deleteToolStripMenuItem.Enabled = CanUseAction(DeleteAction);
            cutToolStripMenuItem.Enabled = CanUseAction(CutAction);
            textMarkupToolStripMenuItem.Enabled = hasSelectedText;

            bool showCommentSubMenu = false;

#if !REMOVE_ANNOTATION_PLUGIN
            if (CommentTool != null)
            {
                // get focused comment
                Comment focusedComment = GetFocusedComment();

                // if comment menu must be shown
                if (CommentTool.Enabled &&
                   (interactionModeViewRadioButton.Checked || interactionModeMarkupRadioButton.Checked) &&
                    _pdfAnnotationTool.FocusedAnnotationView is PdfMarkupAnnotationView &&
                    focusedComment != null && !focusedComment.IsState)
                {
                    UpdateCommentStatesUI(focusedComment);
                    showCommentSubMenu = true;
                }
            }
#endif
            replyToolStripMenuItem.Visible = showCommentSubMenu;
            setStatusToolStripMenuItem.Visible = showCommentSubMenu;
            toolStripSeparator1.Visible = showCommentSubMenu;

        }

        /// <summary>
        /// Handles the Click event of replyToolStripMenuItem object.
        /// </summary>
        private void replyToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            // get focused comment
            Comment comment = GetFocusedComment();
            if (comment != null)
            {
                // add reply
                Comment replyComment = comment.AddReply(Color.Yellow, GetCurrentUserName());
                // get reply control
                CommentControl replyControl = (CommentControl)CommentTool.FindCommentControl(replyComment);
                if (replyControl != null)
                    // move focus to reply control
                    replyControl.SetFocus(replyComment);
            }
#endif
        }

        /// <summary>
        /// Handles the Click event of setStatusToolStripMenuItem object.
        /// </summary>
        private void setStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string stateName = (string)menuItem.Tag;

            string[] parsedName = stateName.Split('.');
            // get state model
            string stateModel = parsedName[0];
            // get state
            string state = parsedName[1];

            // get focused comment
            Comment repliedComment = GetFocusedComment();
            if (repliedComment != null)
            {
                // update comment state
                Comment stateComment = repliedComment.SetState(
                    Color.Yellow,
                    GetCurrentUserName(),
                    stateModel,
                    state,
                    CommentTools.SPLIT_STATES_BY_USER_NAME);
                // close comment with state
                stateComment.IsOpen = false;
                // update state comment text
                stateComment.Text = string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_ARG0_SETS_BY_ARG1, state, stateComment.UserName);
            }
#endif
        }

        /// <summary>
        /// Handles the Click event of textMarkupHighlightToolStripMenuItem object.
        /// </summary>
        private void textMarkupHighlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfTextMarkupTools.HighlightSelectedText(AnnotationTool.ImageViewer);
        }

        /// <summary>
        /// Handles the Click event of textMarkupStrikeoutToolStripMenuItem object.
        /// </summary>
        private void textMarkupStrikeoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfTextMarkupTools.StrikeoutSelectedText(AnnotationTool.ImageViewer);
        }

        /// <summary>
        /// Handles the Click event of textMarkupUnderlineToolStripMenuItem object.
        /// </summary>
        private void textMarkupUnderlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfTextMarkupTools.UnderlineSelectedText(AnnotationTool.ImageViewer);
        }

        /// <summary>
        /// Handles the Click event of textMarkupSquigglyUnderlineToolStripMenuItem object.
        /// </summary>
        private void textMarkupSquigglyUnderlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfTextMarkupTools.SquigglyUnderlineSelectedText(AnnotationTool.ImageViewer);
        }

        /// <summary>
        /// Handles the Click event of cutToolStripMenuItem object.
        /// </summary>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CutAction.Execute();
            // if interactive form tree must be updated
            if (toolsTabControl.SelectedTab == formFieldsTabPage)
                InteractiveFormControl.RefreshInteractiveFormTree();
        }

        /// <summary>
        /// Handles the Click event of copyToolStripMenuItem object.
        /// </summary>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // execute copy action
            CopyAction.Execute();
        }

        /// <summary>
        /// Handles the Click event of pasteToolStripMenuItem object.
        /// </summary>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // execute paste action
            PasteAction.Execute();
        }

        /// <summary>
        /// Handles the Click event of deleteToolStripMenuItem object.
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // execute delete action
            DeleteAction.Execute();
            // if interactive form tree must be updated
            if (toolsTabControl.SelectedTab == formFieldsTabPage)
                InteractiveFormControl.RefreshInteractiveFormTree();
        }

        /// <summary>
        /// Handles the Click event of bringToFrontToolStripMenuItem object.
        /// </summary>
        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // execute bring to front action
            BringToFrontAction.Execute();
        }

        /// <summary>
        /// Handles the Click event of bringToBackToolStripMenuItem object.
        /// </summary>
        private void bringToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // execute bring to back action
            BringToBackAction.Execute();
        }

        /// <summary>
        /// Handles the Click event of propertiesToolStripMenuItem object.
        /// </summary>
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get focused annotation view
            PdfAnnotationView view = AnnotationTool.FocusedAnnotationView;

            // if annotation is not focused
            if (view == null)
            {
                view = _hoveredAnnotationView;

                // if there is no hovered annotation
                if (view == null)
                    return;
            }

            // create annotation properties dialog
            using (PdfAnnotationPropertiesForm annotationProperties = new PdfAnnotationPropertiesForm(view))
            {
                annotationProperties.ShowDialog();

                // if read only property is set to true, reset annotation focus
                if (view.IsReadOnly)
                {
                    AnnotationTool.FocusedAnnotationView = null;
                }

                UpdateAnnotationView(view);
            }
        }


        #region Transformers

        /// <summary>
        /// Handles the DropDownOpened event of transformersToolStripMenuItem object.
        /// </summary>
        private void transformersToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            // get focused annotation view
            PdfAnnotationView focusedView = AnnotationTool.FocusedAnnotationView;

            // disable the tool strip menu items
            defaultToolStripMenuItem.Enabled = false;
            moveResizeRotateToolStripMenuItem.Enabled = false;
            pointsMoveResizeRotateToolStripMenuItem.Enabled = false;
            distortionToolStripMenuItem.Enabled = false;
            skewToolStripMenuItem.Enabled = false;
            pointsToolStripMenuItem.Enabled = false;
            noneToolStripMenuItem.Enabled = false;

            // if annotation is focused
            if (focusedView != null)
            {
                defaultToolStripMenuItem.Enabled = true;
                noneToolStripMenuItem.Enabled = true;
                // if polygonal or inc annotation is focused
                if (focusedView is PdfPolygonalAnnotationView ||
                    focusedView is PdfInkAnnotationView ||
                    focusedView is PdfTextMarkupAnnotationView)
                {
                    moveResizeRotateToolStripMenuItem.Enabled = true;
                    pointsMoveResizeRotateToolStripMenuItem.Enabled = true;
                    distortionToolStripMenuItem.Enabled = true;
                    skewToolStripMenuItem.Enabled = true;
                    pointsToolStripMenuItem.Enabled = true;
                }
                // if line annotation is focused
                else if (focusedView is PdfLineAnnotationView)
                {
                    moveResizeRotateToolStripMenuItem.Enabled = true;
                    pointsMoveResizeRotateToolStripMenuItem.Enabled = true;
                    pointsToolStripMenuItem.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of defaultToolStripMenuItem object.
        /// </summary>
        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationTool.FocusedAnnotationView.InteractionController =
                AnnotationTool.FocusedAnnotationView.Transformer;
        }

        /// <summary>
        /// Handles the Click event of moveResizeRotateToolStripMenuItem object.
        /// </summary>
        private void moveResizeRotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationTool.FocusedAnnotationView.InteractionController =
                new PointBasedObjectRectangularTransformer(AnnotationTool.FocusedAnnotationView);
        }

        /// <summary>
        /// Handles the Click event of pointsMoveResizeRotateToolStripMenuItem object.
        /// </summary>
        private void pointsMoveResizeRotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationTool.FocusedAnnotationView.InteractionController =
                new CompositeInteractionController(
                    new PointBasedObjectPointTransformer(AnnotationTool.FocusedAnnotationView),
                    new PointBasedObjectRectangularTransformer(AnnotationTool.FocusedAnnotationView));
        }

        /// <summary>
        /// Handles the Click event of distortionToolStripMenuItem object.
        /// </summary>
        private void distortionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationTool.FocusedAnnotationView.InteractionController =
                new PointBasedObjectDistortionTransformer(AnnotationTool.FocusedAnnotationView, false);
        }

        /// <summary>
        /// Handles the Click event of skewToolStripMenuItem object.
        /// </summary>
        private void skewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationTool.FocusedAnnotationView.InteractionController =
                new PointBasedObjectDistortionTransformer(AnnotationTool.FocusedAnnotationView, true);
        }

        /// <summary>
        /// Handles the Click event of pointsToolStripMenuItem object.
        /// </summary>
        private void pointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationTool.FocusedAnnotationView.InteractionController =
                new PointBasedObjectPointTransformer(AnnotationTool.FocusedAnnotationView);
        }

        /// <summary>
        /// Handles the Click event of noneToolStripMenuItem object.
        /// </summary>
        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationTool.FocusedAnnotationView.InteractionController = null;
        }



        #endregion

        #endregion

        #endregion


        #region Annotation context menu

        #region Comments

#if !REMOVE_ANNOTATION_PLUGIN
        /// <summary>
        /// Returns the comment, that is focused.
        /// </summary>
        /// <returns>Replied <see cref="Comment"/>.</returns>
        private Comment GetFocusedComment()
        {
            CommentCollection comments = CommentTool.CommentController.GetComments(CommentTool.CommentController.ImageViewer.Image);

            if (comments != null && _pdfAnnotationTool.FocusedAnnotationView != null)
                return comments.FindBySource(_pdfAnnotationTool.FocusedAnnotationView.Annotation);

            return null;
        }
#endif

        /// <summary>
        /// Returns the name of the current user.
        /// </summary>
        /// <returns>The name of the current user.</returns>
        private string GetCurrentUserName()
        {
            return Environment.UserName;
        }

#if !REMOVE_ANNOTATION_PLUGIN
        /// <summary>
        /// Updates the states UI of comment.
        /// </summary>
        private void UpdateCommentStatesUI(Comment currentComment)
        {
            if (currentComment == null)
                return;

            Comment[] states = currentComment.GetStates(CommentTools.SPLIT_STATES_BY_USER_NAME);

            // update items of state menu item
            foreach (ToolStripMenuItem item in _commentStateNameToMenuItem.Values)
            {
                item.Enabled = !currentComment.IsReadOnly;
                item.Checked = false;
            }
            if (states != null)
            {
                foreach (Comment state in states)
                {
                    if (!CommentTools.SPLIT_STATES_BY_USER_NAME || state.UserName == GetCurrentUserName())
                    {
                        ToolStripMenuItem item = null;
                        string stateName = string.Format("{0}.{1}", state.StateModel, state.ParentState);
                        if (_commentStateNameToMenuItem.TryGetValue(stateName, out item))
                            item.Checked = true;
                    }
                }
            }

        }
#endif

        #endregion

        /// <summary>
        /// Determines whether the specified action can be used.
        /// </summary>
        private bool CanUseAction(UIAction action)
        {
            if (action == null)
                return false;
            return action.IsEnabled;
        }

        #endregion


        #region PDF annotation tool

        /// <summary>
        /// Subscribes to the PDF annotation tool events.
        /// </summary>
        private void SubscribeToPdfAnnotationToolEvents()
        {
            _pdfAnnotationTool.InteractionModeChanged += new PropertyChangedEventHandler<PdfAnnotationInteractionMode>(pdfAnnotationTool_InteractionModeChanged);
            _pdfAnnotationTool.MouseDoubleClick += new VisualToolMouseEventHandler(pdfAnnotationTool_MouseDoubleClick);
            _pdfAnnotationTool.MouseDown += new VisualToolMouseEventHandler(pdfAnnotationTool_MouseDown);
            _pdfAnnotationTool.HoveredAnnotationChanged += new EventHandler<PdfAnnotationEventArgs>(pdfAnnotationTool_HoveredAnnotationChanged);
        }

        /// <summary>
        /// Unsubscribes from the PDF annotation tool events.
        /// </summary>
        private void UnsubscribeFromPdfAnnotationToolEvents()
        {
            _pdfAnnotationTool.InteractionModeChanged -= new PropertyChangedEventHandler<PdfAnnotationInteractionMode>(pdfAnnotationTool_InteractionModeChanged);
            _pdfAnnotationTool.MouseDoubleClick -= new VisualToolMouseEventHandler(pdfAnnotationTool_MouseDoubleClick);
            _pdfAnnotationTool.MouseDown -= new VisualToolMouseEventHandler(pdfAnnotationTool_MouseDown);
            _pdfAnnotationTool.HoveredAnnotationChanged -= new EventHandler<PdfAnnotationEventArgs>(pdfAnnotationTool_HoveredAnnotationChanged);
        }

        /// <summary>
        /// Interaction mode of PDF annotation tool is changed.
        /// </summary>
        private void pdfAnnotationTool_InteractionModeChanged(object sender, PropertyChangedEventArgs<PdfAnnotationInteractionMode> e)
        {
            AnnotationTool.CancelBuilding();

            UpdateInteractionMode();
        }

        /// <summary>
        /// Mouse is double clicked.
        /// </summary>
        private void pdfAnnotationTool_MouseDoubleClick(object sender, VisualToolMouseEventArgs e)
        {
            if (!e.Handled && e.Button == MouseButtons.Left)
            {
                if (AnnotationTool.InteractionMode != PdfAnnotationInteractionMode.None)
                {
                    // if focused page is exist
                    if (AnnotationTool.FocusedPage != null)
                    {
                        // find view of annotation
                        PdfAnnotationView annotationView = AnnotationTool.FindAnnotationView(e.X, e.Y);
                        // annotation is selected and is no FreeText annotation then
                        if (annotationView != null && !(annotationView is PdfFreeTextAnnotationView))
                        {
                            // if annotation is not building
                            if (!annotationView.IsBuilding)
                            {
                                if (AnnotationTool.InteractionMode == PdfAnnotationInteractionMode.Edit)
                                {
                                    // create annotation properties dialog
                                    using (PdfAnnotationPropertiesForm annotationProperties = new PdfAnnotationPropertiesForm(
                                        annotationView))
                                    {
                                        annotationProperties.ShowDialog();
                                        UpdateAnnotationView(annotationView);
                                        e.Handled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Mouse is down.
        /// </summary>
        private void pdfAnnotationTool_MouseDown(object sender, VisualToolMouseEventArgs e)
        {
            // if mouse button is right
            if (e.Button == MouseButtons.Right)
            {
                // if annotation can be changed
                if (AnnotationTool.Enabled && AnnotationTool.InteractionMode != PdfAnnotationInteractionMode.None)
                {
                    // if focused page is exist
                    if (AnnotationTool.FocusedPage != null)
                    {
                        if (AnnotationTool.FocusedAnnotationView != null)
                            AnnotationTool.CancelBuilding();

                        // find view of annotation
                        AnnotationTool.FocusedAnnotationView = AnnotationTool.FindAnnotationView(e.X, e.Y);

                        if (AnnotationTool.InteractionMode == PdfAnnotationInteractionMode.Edit ||
                            AnnotationTool.FocusedAnnotationView == null ||
                            AnnotationTool.FocusedAnnotationView is PdfMarkupAnnotationView)
                        {
                            // show annotationContextMenuStrip
                            annotationContextMenuStrip.Show(AnnotationTool.ImageViewer, new Point(e.X, e.Y));
                        }

                        e.Handled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Hovered annotation is changed.
        /// </summary>
        private void pdfAnnotationTool_HoveredAnnotationChanged(
            object sender,
            PdfAnnotationEventArgs e)
        {
            if (_hoveredAnnotationToolTip != null)
            {
                if (e.Annotation == null)
                {
                    _hoveredAnnotationToolTip.RemoveAll();
                }
                else
                {
                    string text = "";
                    // if tooltip must be shown
                    if (toolTipCheckBox.Checked)
                    {
                        switch (AnnotationTool.InteractionMode)
                        {
                            case PdfAnnotationInteractionMode.Edit:
                                // if widget annotation is selected
                                if (e.Annotation is PdfWidgetAnnotation)
                                {
                                    PdfInteractiveFormField field = ((PdfWidgetAnnotation)e.Annotation).Field;
                                    string name = field.FullyQualifiedName;
                                    if (field is PdfInteractiveFormSwitchableButtonField)
                                        if (string.IsNullOrEmpty(field.PartialName))
                                            name += string.Format(".{0}", ((PdfInteractiveFormSwitchableButtonField)field).ButtonValue);
                                    text = string.Format("{0} ({1})", name, field.GetType().Name);
                                }
                                else
                                {
                                    PdfAnnotation annotation = e.Annotation;
                                    if (annotation.Name == null)
                                        text = annotation.GetType().Name;
                                    else
                                        text = string.Format("{0} ({1})", annotation.Name, annotation.GetType().Name);
                                }
                                string activateAction = PdfActionsTools.GetActivateActionDescription(e.Annotation);
                                if (activateAction != "")
                                    text += string.Format(": {0}", activateAction);
                                break;

                            case PdfAnnotationInteractionMode.Markup:
                            case PdfAnnotationInteractionMode.View:
                                // if widget annotation is selected
                                if (e.Annotation is PdfWidgetAnnotation)
                                {
                                    PdfInteractiveFormField field = ((PdfWidgetAnnotation)e.Annotation).Field;
                                    text = field.UserInterfaceName;
                                }
                                // if markup annotation is selected
                                else if (e.Annotation is PdfMarkupAnnotation)
                                {
                                    PdfAnnotation annotation = e.Annotation;
                                    if (annotation is PdfFileAttachmentAnnotation)
                                    {
                                        text = ((PdfFileAttachmentAnnotation)annotation).Contents;
                                        if (text == null && ((PdfFileAttachmentAnnotation)annotation).FileSpecification != null)
                                            text = ((PdfFileAttachmentAnnotation)annotation).FileSpecification.Description;
                                    }
                                    else
                                    {
                                        if (annotation.Contents != null)
                                            text = annotation.Contents;
                                    }

                                }
                                // if link annotation is selected
                                else if (e.Annotation is PdfLinkAnnotation)
                                {
                                    text = PdfActionsTools.GetActivateActionDescription(e.Annotation);
                                }
                                break;
                        }
                    }

                    // if tool tip must be updated
                    if (_hoveredAnnotationToolTip.GetToolTip(AnnotationTool.ImageViewer) != text)
                    {
                        _hoveredAnnotationToolTip.RemoveAll();
                        _hoveredAnnotationToolTip.Show(text, AnnotationTool.ImageViewer);
                    }
                }
            }
        }

        #endregion


        /// <summary>
        /// Updates information about interaction mode in application UI.
        /// </summary>
        private void UpdateInteractionMode()
        {
            if (AnnotationTool != null)
            {
                switch (AnnotationTool.InteractionMode)
                {
                    case PdfAnnotationInteractionMode.View:
                        interactionModeViewRadioButton.Checked = true;
                        break;
                    case PdfAnnotationInteractionMode.Markup:
                        interactionModeMarkupRadioButton.Checked = true;
                        break;
                    case PdfAnnotationInteractionMode.Edit:
                        interactionModeEditRadioButton.Checked = true;
                        break;
                    case PdfAnnotationInteractionMode.None:
                        interactionModeNoneRadioButton.Checked = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Updates the view of PDF annotation.
        /// </summary>
        /// <param name="view">The view of PDF annotation.</param>
        private void UpdateAnnotationView(PdfAnnotationView view)
        {
            if (toolsTabControl.SelectedTab == annotationsTabPage)
            {
                AnnotationsControl.UpdateAnnotation(view.Annotation);
            }
            else
            {
                if (view.Figure is PdfWidgetAnnotationGraphicsFigure)
                {
                    PdfInteractiveFormField field = ((PdfWidgetAnnotationGraphicsFigure)view.Figure).Field;
                    InteractiveFormControl.UpdateField(field);
                }
            }
        }

        #endregion

        #endregion


    }
}
