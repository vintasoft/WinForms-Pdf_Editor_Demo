using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.UI.Annotations;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit PDF annotations.
    /// </summary>
    public partial class PdfAnnotationsControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAnnotationsControl"/> class.
        /// </summary>
        public PdfAnnotationsControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        PdfAnnotationTool _annotationTool = null;
        /// <summary>
        /// Gets or sets the PDF annotation tool.
        /// </summary>
        public PdfAnnotationTool AnnotationTool
        {
            get
            {
                return _annotationTool;
            }
            set
            {
                // if annotation tool is not empty
                if (_annotationTool != null)
                    UnsubscribeFromAnnotationTool(_annotationTool);

                // set new annotation tool
                _annotationTool = value;
                AnnotationBuilderControl.AnnotationTool = value;
                pdfAnnotationToolAnnotationsControl.AnnotationTool = value;

                // if annotation tool is not empty
                if (_annotationTool != null)
                    SubscribeToAnnotationTool(_annotationTool);

                // update user interface
                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates the user interface.
        /// </summary>
        public void UpdateUI()
        {
            mainPanel.Enabled =
                _annotationTool != null &&
                _annotationTool.ImageViewer != null;

            AnnotationBuilderControl.UpdateUI();
        }

        /// <summary>
        /// Updates the annotation.
        /// </summary>
        /// <param name="annotation">The annotation.</param>
        public void UpdateAnnotation(PdfAnnotation annotation)
        {
            pdfAnnotationToolAnnotationsControl.UpdateAnnotation(annotation);
        }

        /// <summary>
        /// Refresh the annotation list.
        /// </summary>
        public void RefreshAnnotationList()
        {
            pdfAnnotationToolAnnotationsControl.RefreshAnnotationList();
            if (AnnotationTool != null)
            {
                PdfAnnotationView focusedAnnotationView = AnnotationTool.FocusedAnnotationView;
                if (focusedAnnotationView != null)
                {
                    PdfAnnotation focusedAnnotation = focusedAnnotationView.Annotation;
                    pdfAnnotationToolAnnotationsControl.SelectedAnnotation = focusedAnnotation;
                }
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the Activated event of AnnotationTool object.
        /// </summary>
        private void AnnotationTool_Activated(object sender, EventArgs e)
        {
            // enable main panel
            mainPanel.Enabled = true;
        }

        /// <summary>
        /// Handles the Deactivated event of AnnotationTool object.
        /// </summary>
        private void AnnotationTool_Deactivated(object sender, EventArgs e)
        {
            // disable main panel
            mainPanel.Enabled = false;
        }


        /// <summary>
        /// Subscribes to the annotation tool events.
        /// </summary>
        /// <param name="annotationTool">The annotation tool.</param>
        private void SubscribeToAnnotationTool(PdfAnnotationTool annotationTool)
        {
            annotationTool.Activated += new EventHandler(AnnotationTool_Activated);
            annotationTool.Deactivated += new EventHandler(AnnotationTool_Deactivated);
            annotationTool.MouseDoubleClick += new VisualToolMouseEventHandler(AnnotationTool_MouseDoubleClick);
            annotationTool.ActiveInteractionControllerChanged += new PropertyChangedEventHandler<IInteractionController>(AnnotationTool_ActiveInteractionControllerChanged);
            annotationTool.BuildingStarted += new EventHandler<PdfAnnotationViewEventArgs>(annotationTool_BuildingStarted);
            annotationTool.BuildingFinished += new EventHandler<PdfAnnotationViewEventArgs>(annotationTool_BuildingFinished);
            annotationTool.BuildingCanceled += new EventHandler<PdfAnnotationViewEventArgs>(annotationTool_BuildingCanceled);
        }

        /// <summary>
        /// Unsubscribes from the annotation tool events.
        /// </summary>
        /// <param name="annotationTool">The annotation tool.</param>
        private void UnsubscribeFromAnnotationTool(PdfAnnotationTool annotationTool)
        {
            annotationTool.Activated -= new EventHandler(AnnotationTool_Activated);
            annotationTool.Deactivated -= new EventHandler(AnnotationTool_Deactivated);
            annotationTool.MouseDoubleClick -= new VisualToolMouseEventHandler(AnnotationTool_MouseDoubleClick);
            annotationTool.ActiveInteractionControllerChanged -= new PropertyChangedEventHandler<IInteractionController>(AnnotationTool_ActiveInteractionControllerChanged);
            annotationTool.BuildingStarted -= annotationTool_BuildingStarted;
            annotationTool.BuildingFinished -= annotationTool_BuildingFinished;
            annotationTool.BuildingCanceled -= annotationTool_BuildingCanceled;
        }

        /// <summary>
        /// Annotation building is started.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PdfAnnotationViewEventArgs"/> instance containing the event data.</param>
        private void annotationTool_BuildingStarted(object sender, PdfAnnotationViewEventArgs e)
        {
            pdfAnnotationToolAnnotationsControl.Enabled = false;
        }

        /// <summary>
        /// Annotaiton building is finished.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PdfAnnotationViewEventArgs"/> instance containing the event data.</param>
        private void annotationTool_BuildingFinished(object sender, PdfAnnotationViewEventArgs e)
        {
            if (!AnnotationTool.IsFocusedAnnotationBuilding)
                pdfAnnotationToolAnnotationsControl.Enabled = true;
        }

        /// <summary>
        /// Annotation building is canceled.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PdfAnnotationViewEventArgs"/> instance containing the event data.</param>
        private void annotationTool_BuildingCanceled(object sender, PdfAnnotationViewEventArgs e)
        {
            pdfAnnotationToolAnnotationsControl.Enabled = true;
        }

        /// <summary>
        /// Active interaction controller is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs{IInteractionController}"/> instance containing the event data.</param>
        private void AnnotationTool_ActiveInteractionControllerChanged(
            object sender,
            PropertyChangedEventArgs<IInteractionController> e)
        {
            if (e.OldValue != null)
                e.OldValue.InteractionFinished -= new EventHandler<InteractionEventArgs>(ActiveInteractionController_InteractionFinished);
            if (e.NewValue != null)
                e.NewValue.InteractionFinished += new EventHandler<InteractionEventArgs>(ActiveInteractionController_InteractionFinished);
        }

        /// <summary>
        /// The interaction is finished.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InteractionEventArgs"/> instance containing the event data.</param>
        private void ActiveInteractionController_InteractionFinished(object sender, InteractionEventArgs e)
        {
            if (_annotationTool.FocusedAnnotationView != null)
                UpdateAnnotation(_annotationTool.FocusedAnnotationView.Annotation);
            if (_annotationTool.InteractionMode == PdfAnnotationInteractionMode.Edit)
            {
                foreach (PdfAnnotationView view in _annotationTool.SelectedAnnotationViewCollection)
                    UpdateAnnotation(view.Annotation);
            }
        }

        /// <summary>
        /// Mouse is double clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisualToolMouseEventArgs"/> instance containing the event data.</param>
        private void AnnotationTool_MouseDoubleClick(object sender, VisualToolMouseEventArgs e)
        {
            // if left mouse button is down
            if (e.Button == MouseButtons.Left)
            {
                // if tool uses View or Markup mode
                if (AnnotationTool.InteractionMode == PdfAnnotationInteractionMode.View ||
                    AnnotationTool.InteractionMode == PdfAnnotationInteractionMode.Markup)
                {
                    // get focused annotation view
                    PdfAnnotationView focusedView = AnnotationTool.FindAnnotationView(e.X, e.Y);
                    // if focused annotation view is File Attachment Annotation
                    if (focusedView is PdfFileAttachmentAnnotationView)
                    {
                        // get the annotation
                        PdfFileAttachmentAnnotation annotation = (PdfFileAttachmentAnnotation)focusedView.Annotation;

                        // if file specification is not empty
                        // and embedded file is not empty
                        if (annotation.FileSpecification != null && annotation.FileSpecification.EmbeddedFile != null)
                        {
                            OpenOrSaveFileAttachment(annotation);
                            e.Handled = true;
                        }
                        // if file specification is empty
                        // or embedded file is empty
                        else
                        {
                            SetEmbeddedFile(annotation);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the embedded file to the PDF file attachment annotation.
        /// </summary>
        /// <param name="annotation">The PDF file attachment annotation.</param>
        private static void SetEmbeddedFile(PdfFileAttachmentAnnotation annotation)
        {
            // create embedded file specification form
            using (EmbeddedFileSpecificationForm embeddedFileSpecificationForm = new EmbeddedFileSpecificationForm())
            {
                // get file specification
                PdfEmbeddedFileSpecification fileSpecification = annotation.FileSpecification;
                // if file specification is not empty
                if (fileSpecification == null)
                {
                    // create new file specification
                    fileSpecification = new PdfEmbeddedFileSpecification(annotation.Document);
                }
                // set file specification to the form
                embeddedFileSpecificationForm.EmbeddedFileSpecification = fileSpecification;

                // if dialog result is OK
                if (embeddedFileSpecificationForm.ShowDialog() == DialogResult.OK)
                {
                    // set file specification to the file attachment annotation
                    annotation.FileSpecification = fileSpecification;
                }
            }
        }

        /// <summary>
        /// Opens or saves the embedded file from PDF file attachment annotation.
        /// </summary>
        /// <param name="annotation">The PDF file attachment annotation.</param>
        private static void OpenOrSaveFileAttachment(PdfFileAttachmentAnnotation annotation)
        {
            try
            {
                // get embedded file name
                string filename = Path.GetFileName(annotation.FileSpecification.Filename);

                // get description
                string description = annotation.Contents;
                if (string.IsNullOrEmpty(description))
                    description = annotation.FileSpecification.Description;
                if (string.IsNullOrEmpty(description))
                    description = Path.GetExtension(filename);

                // get message for message box
                string message =
                    PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_OPEN_FILE_ARG0_ARG1_USING_THE_DEFAULT_APPLICATION_OR_SAVE_FILE_TO_A_DISKRN +
                    PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_PRESS_YES_TO_OPEN_FILE_USING_THE_DEFAULT_APPLICATIONRN +
                    PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_PRESS_NO_TO_SAVE_FILE_TO_A_DISKRN +
                    PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_PRESS_CANCEL_TO_CANCEL_THIS_ACTION;
                // show message box
                DialogResult result = MessageBox.Show(string.Format(message, filename, description),
                    PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_EMBEDDED_FILE, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                // if dialog result is YES
                if (result == DialogResult.Yes)
                {
                    // get temp file name
                    string tempFilename = Path.GetTempFileName();
                    tempFilename = Path.Combine(Path.GetDirectoryName(tempFilename),
                        Path.GetFileNameWithoutExtension(tempFilename) + Path.GetExtension(filename));
                    // save embedded file to the temp file
                    File.WriteAllBytes(tempFilename, annotation.FileSpecification.EmbeddedFile.GetBytes());

                    // open temp file
                    ProcessStartInfo processInfo = new ProcessStartInfo(tempFilename);
                    processInfo.UseShellExecute = true;
                    Process.Start(processInfo);
                }
                // if dialog result is NO
                else if (result == DialogResult.No)
                {
                    // create save file dialog
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        // set filename
                        saveDialog.FileName = filename;
                        // set default extension
                        saveDialog.DefaultExt = Path.GetExtension(filename);
                        // if dialog result is OK
                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            // save embedded file to the new file
                            File.WriteAllBytes(saveDialog.FileName, annotation.FileSpecification.EmbeddedFile.GetBytes());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Annotation is double clicked.
        /// </summary>
        private void pdfAnnotationToolAnnotationsControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // if annotation is focused
            if (pdfAnnotationToolAnnotationsControl.SelectedAnnotation != null)
            {
                PdfAnnotation annotation = pdfAnnotationToolAnnotationsControl.SelectedAnnotation;
                PdfAnnotationView view = AnnotationTool.GetAnnotationViewAssociatedWith(annotation);
                // create annotation properties dialog
                if (view != null)
                {
                    using (PdfAnnotationPropertiesForm annotationProperties = new PdfAnnotationPropertiesForm(view))
                        annotationProperties.ShowDialog();
                }
                else
                {
                    using (PdfAnnotationPropertiesForm annotationProperties = new PdfAnnotationPropertiesForm(annotation))
                        annotationProperties.ShowDialog();
                }
                pdfAnnotationToolAnnotationsControl.UpdateAnnotation(annotation);
            }
        }

        #endregion

        #endregion

    }
}
