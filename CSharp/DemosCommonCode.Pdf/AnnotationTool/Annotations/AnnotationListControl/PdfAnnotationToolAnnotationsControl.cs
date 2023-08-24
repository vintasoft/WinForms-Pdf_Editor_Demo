using System;
using System.ComponentModel;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.UI.Annotations;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.Utils;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to show information about annotations of PDF Annotation Tool.
    /// </summary>
    public partial class PdfAnnotationToolAnnotationsControl : PdfPageAnnotationsControl
    {

        #region Fields

        /// <summary>
        /// Indicates that the selcted annotation is changing.
        /// </summary>
        bool _isSelectedAnnotationChanging = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAnnotationToolAnnotationsControl"/> class.
        /// </summary>
        public PdfAnnotationToolAnnotationsControl()
        {
            InitializeComponent();

            this.SelectedIndexChanged += new EventHandler(PdfAnnotationToolAnnotationsControl_SelectedIndexChanged);
        }

        #endregion



        #region Properties

        PdfAnnotationTool _annotationTool = null;
        /// <summary>
        /// Gets or sets the PDF annotation tool.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Browsable(false)]
        public PdfAnnotationTool AnnotationTool
        {
            get
            {
                return _annotationTool;
            }
            set
            {
                if (_annotationTool != null)
                {
                    _annotationTool.Activated -= AnnotationTool_Activated;
                    _annotationTool.Deactivated -= AnnotationTool_Deactivated;
                    _annotationTool.FocusedAnnotationViewChanged -= annotationTool_FocusedAnnotationViewChanged;
                    _annotationTool.DocumentSet.Changed -= new EventHandler<ObjectSetListenerEventArgs<PdfDocument>>(DocumentSet_Changed);
                }

                _annotationTool = value;

                if (_annotationTool != null)
                {
                    base.AnnotationList = this.AnnotationList;

                    _annotationTool.Activated += new EventHandler(AnnotationTool_Activated);
                    _annotationTool.Deactivated += new EventHandler(AnnotationTool_Deactivated);
                    _annotationTool.FocusedAnnotationViewChanged += new EventHandler<PdfAnnotationViewChangedEventArgs>(annotationTool_FocusedAnnotationViewChanged);
                    _annotationTool.DocumentSet.Changed += new EventHandler<ObjectSetListenerEventArgs<PdfDocument>>(DocumentSet_Changed);
                }
            }
        }

        /// <summary>
        /// Gets the annotation list.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public override PdfAnnotationList AnnotationList
        {
            get
            {
                if (_annotationTool != null)
                {
                    PdfPage page = _annotationTool.FocusedPage;
                    if (page != null)
                        return page.Annotations;
                }

                return null;
            }
            set
            {
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Refresh the annotation list.
        /// </summary>
        public void RefreshAnnotationList()
        {
            if (AnnotationList != null)
            {
                BeginUpdate();
                try
                {
                    foreach (PdfAnnotation annotation in AnnotationList)
                    {
                        UpdateAnnotation(annotation);
                    }
                }
                finally
                {
                    EndUpdate();
                }
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Updates the annotation list.
        /// </summary>
        private void UpdateAnnotationList()
        {
            if (_annotationTool != null &&
                _annotationTool.ImageViewer != null &&
                _annotationTool.ImageViewer.Image != null)
            {
                PdfPage page = PdfDocumentController.GetPageAssociatedWithImage(_annotationTool.ImageViewer.Image);
                if (page != null)
                    base.AnnotationList = page.Annotations;
                else
                    base.AnnotationList = null;
            }
            else
            {
                base.AnnotationList = null;
            }
        }

        /// <summary>
        /// Handler of PDF DocumentSet.Changed event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ObjectSetListenerEventArgs{PdfDocument}"/> instance containing the event data.</param>
        private void DocumentSet_Changed(object sender, ObjectSetListenerEventArgs<PdfDocument> e)
        {
            UpdateAnnotationList();
        }

        /// <summary>
        /// PDF annotation visual tool is activated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AnnotationTool_Activated(object sender, EventArgs e)
        {
            if (_annotationTool.ImageViewer != null)
            {
                _annotationTool.ImageViewer.FocusedIndexChanged += new EventHandler<FocusedIndexChangedEventArgs>(ImageViewer_FocusedIndexChanged);
                _annotationTool.ImageViewer.ImageReloaded += new EventHandler<ImageReloadEventArgs>(ImageViewer_ImageReloaded);
                UpdateAnnotationList();
            }
        }

        /// <summary>
        /// PDF annotation visual tool is deactivated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AnnotationTool_Deactivated(object sender, EventArgs e)
        {
            if (_annotationTool.ImageViewer != null)
            {
                _annotationTool.ImageViewer.FocusedIndexChanged -= ImageViewer_FocusedIndexChanged;
                _annotationTool.ImageViewer.ImageReloaded -= ImageViewer_ImageReloaded;
                base.AnnotationList = null;
            }
        }

        /// <summary>
        /// Focused image is reloaded in image viewer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageReloadEventArgs"/> instance containing the event data.</param>
        void ImageViewer_ImageReloaded(object sender, ImageReloadEventArgs e)
        {
            UpdateRefreshAnnotationList();
        }

        /// <summary>
        /// Focused image is changed in image viewer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FocusedIndexChangedEventArgs"/> instance containing the event data.</param>
        private void ImageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            UpdateRefreshAnnotationList();
        }

        /// <summary>
        /// Updates the annotation list.
        /// </summary>
        private void UpdateRefreshAnnotationList()
        {
            VintasoftImage image = _annotationTool.ImageViewer.Image;
            if (image != null)
            {
                PdfPage page = PdfDocumentController.GetPageAssociatedWithImage(image);
                if (page != null)
                    base.AnnotationList = page.Annotations;
                else
                    base.AnnotationList = null;
            }
        }

        /// <summary>
        /// Finds the PDF annotation view for the specified PDF annotation.
        /// </summary>
        /// <param name="annotationTool">The PDF annotation tool.</param>
        /// <param name="annotation">The PDF annotation.</param>
        /// <returns>The PDF annotation view for the specified PDF annotation.</returns>
        private PdfAnnotationView FindView(PdfAnnotationTool annotationTool, PdfAnnotation annotation)
        {
            foreach (PdfAnnotationView view in annotationTool.AnnotationViewCollection)
            {
                if (view.Annotation == annotation)
                    return view;
            }

            return null;
        }

        /// <summary>
        /// Focused PDF annotation view is changed in PDF annotation tool.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PdfAnnotationViewChangedEventArgs"/> instance containing the event data.</param>
        private void annotationTool_FocusedAnnotationViewChanged(object sender, PdfAnnotationViewChangedEventArgs e)
        {
            // if control is enabled
            if (!_isSelectedAnnotationChanging && Enabled)
            {
                _isSelectedAnnotationChanging = true;

                // if annotation list is not set
                if (base.AnnotationList == null)
                    // update annotation list
                    UpdateAnnotationList();

                // get PDF annotation view
                PdfAnnotationView annotationView = e.NewValue;
                PdfAnnotation annotation = null;

                // if annotation view is found
                if (annotationView != null)
                    // get annotation associated with annotation view
                    annotation = annotationView.Annotation;

                // set PDF annotation selected in control
                SelectedAnnotation = annotation;

                _isSelectedAnnotationChanging = false;
            }
        }

        /// <summary>
        /// Selected PDF annotation is changed in the control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PdfAnnotationToolAnnotationsControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if control is enabled
            if (!_isSelectedAnnotationChanging && Enabled)
            {
                _isSelectedAnnotationChanging = true;

                // if there is selected annotation
                if (SelectedAnnotation != null)
                {
                    // find the PDF annotation view for PDF annotation
                    PdfAnnotationView view = FindView(_annotationTool, SelectedAnnotation);
                    if (view != null)
                        _annotationTool.PerformSelection(new PdfAnnotationView[] { view });

                    // change focused PDF annotation view in visual tool
                    _annotationTool.FocusedAnnotationView = view;
                }

                _isSelectedAnnotationChanging = false;
            }
        }

        #endregion

        #endregion

    }
}
