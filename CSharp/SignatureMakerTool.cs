using System;
using System.Drawing;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Utils;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;
using Vintasoft.Imaging.Pdf.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

using DemosCommonCode;
using DemosCommonCode.Pdf.Security;


namespace PdfEditorDemo
{
    /// <summary>
    /// Visual tool that allows to add the signature field to a PDF document.
    /// </summary>
    public class SignatureMakerTool : RectangularSelectionTool
    {

        #region Fields

        /// <summary>
        /// The original visual tool.
        /// </summary>
        VisualTool _originalTool = null;

        /// <summary>
        /// Indicates whether the signature field without certificate must be created.
        /// </summary>
        bool _createEmptySignature;

        /// <summary>
        /// The signature appearance.
        /// </summary>
        SignatureAppearanceGraphicsFigure _signatureAppearence;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureMakerTool"/> class.
        /// </summary>
        /// <param name="originalTool">The original visual tool.</param>
        /// <param name="signatureAppearence">The signature appearance.</param>
        /// <param name="createEmptySignature">Indicates whether the signature field
        /// without certificate must be created.</param>
        public SignatureMakerTool(
            VisualTool originalTool,
            SignatureAppearanceGraphicsFigure signatureAppearence,
            bool createEmptySignature)
        {
            _originalTool = originalTool;
            _signatureAppearence = signatureAppearence;
            _createEmptySignature = createEmptySignature;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Occurs when active interaction controller is changed.
        /// </summary>
        /// <param name="e">An event args that contains the event data.</param>
        protected override void OnActiveInteractionControllerChanged(
            PropertyChangedEventArgs<IInteractionController> e)
        {
            base.OnActiveInteractionControllerChanged(e);

            if (e.NewValue == TransformController)
            {
                MakeSignature();
                ImageViewer.VisualTool = _originalTool;
            }
        }


        /// <summary>
        /// Makes the signature.
        /// </summary>
        private void MakeSignature()
        {
            PdfPage page = PdfVisualTool.GetPageFromImage(ImageViewer.Image);
            if (page == null)
                DemosTools.ShowErrorMessage("Is not PDF page, try save document before make signature.");
            PdfDocument document = page.Document;

            PdfInteractiveFormSignatureField signatureField = null;
            // if signature field without certificate must be created
            if (_createEmptySignature)
            {
                CreateEmptySignatureFieldForm createSignatureForm = new CreateEmptySignatureFieldForm(
                    document,
                    ConvertRectangleFromImageSpaceToPageSpace(Rectangle, ImageViewer.Image.Resolution, page),
                    _signatureAppearence);
                if (createSignatureForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // get a new empty signature field
                    signatureField = createSignatureForm.SignatureField;
                }
            }
            // if signature field with certificate must be created
            else
            {
                using (CreateSignatureFieldForm createSignatureForm = new CreateSignatureFieldForm(
                    document,
                    ConvertRectangleFromImageSpaceToPageSpace(Rectangle, ImageViewer.Image.Resolution, page),
                    _signatureAppearence))
                {
                    if (createSignatureForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // get a new signature field
                        signatureField = createSignatureForm.SignatureField;
                    }
                }
            }

            // if signature field is created
            if (signatureField != null)
            {
                // if document does not have interactive form
                if (document.InteractiveForm == null)
                {
                    // create interactive form in the document
                    document.InteractiveForm = new PdfDocumentInteractiveForm(document);
                }

                // use page rotate/crop transform
                AffineMatrix pageRotateCropTransform = page.GetPageRotateCropAffineTransform();
                if (pageRotateCropTransform != null)
                {
                    pageRotateCropTransform.Invert();
                    signatureField.Annotation.MultiplyTransform(pageRotateCropTransform);
                }

                // add signature field to document interactive form AND 
                // add signature annotation to page annotations
                document.InteractiveForm.AddField(signatureField, page);

                // specify that document has signatures
                document.InteractiveForm.SignatureFlags =
                    PdfDocumentSignatureFlags.SignaturesExist | PdfDocumentSignatureFlags.AppendOnly;

                // the viewer application must NOT construct appearance streams and
                // appearance properties for widget annotations in the document
                document.InteractiveForm.NeedAppearances = false;

                // raise the SignatureAdded event
                OnSignatureAdded(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Converts the rectangle from image space to page space.
        /// </summary>
        /// <param name="rect">Rectangle in image space.</param>
        /// <param name="imageResolution">The image resolution.</param>
        /// <param name="page">The PDF page.</param>
        /// <returns><see cref="RectangleF"/> structure in PDF page space.</returns>
        private static RectangleF ConvertRectangleFromImageSpaceToPageSpace(
            RectangleF rect, Resolution imageResolution, PdfPage page)
        {
            // Rectangle -> PointF[]
            PointF[] points = new PointF[] { 
                rect.Location, 
                new PointF(rect.X + rect.Width, rect.Y + rect.Height) };

            // ImageSpace -> PageSpace
            page.PointsToUnits(points, imageResolution);

            // Points -> RectangleF
            float x0 = Math.Min(points[0].X, points[1].X);
            float y0 = Math.Min(points[0].Y, points[1].Y);
            float x1 = Math.Max(points[0].X, points[1].X);
            float y1 = Math.Max(points[0].Y, points[1].Y);
            return new RectangleF(x0, y0, x1 - x0, y1 - y0);
        }

        /// <summary>
        /// Raises the <see cref="SignatureAdded" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnSignatureAdded(EventArgs e)
        {
            if (SignatureAdded != null)
                SignatureAdded(this, e);
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when signature field is added.
        /// </summary>
        public event EventHandler SignatureAdded;

        #endregion

    }
}
