using System.Drawing;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;
using Vintasoft.Imaging.Pdf.UI.Annotations;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// Contains common static functions for PDF annotations.
    /// </summary>
    public static class PdfAnnotationsTools
    {

        /// <summary>
        /// Returns the annotation rectangle on PDF page.
        /// </summary>
        /// <param name="annotationTool">PDF annotation tool.</param>
        /// <param name="visualToolMouseObserver">Mouse observer of PDF annotation tool.</param>
        /// <param name="annotationWidth">The annotation width.</param>
        /// <param name="annotationHeight">The annotation height.</param>
        /// <returns>Annotation rectangle on PDF page.</returns>
        public static RectangleF GetNewAnnotationRectangle(
            PdfAnnotationTool annotationTool,
            VisualToolMouseObserver visualToolMouseObserver,
            float annotationWidth,
            float annotationHeight)
        {
            // get PDF page
            PdfPage page = annotationTool.FocusedPage;

            // get transform from page space to the image space
            PointFTransform transform = PointFAffineTransform.FromMatrix(page.GetTransformFromPageSpaceToImageSpace(annotationTool.ImageViewer.Image.Resolution));
            // get transform from image space to the page space
            transform = transform.GetInverseTransform();

            // get the annotation rectangle on PDF page
            RectangleF pageVisibleRect = PointFTransform.TransformBoundingBox(transform,
                annotationTool.ImageViewer.ViewerState.ImageVisibleRect);

            // get annotation location on PDF page
            float locationX = pageVisibleRect.X;
            float locationY = pageVisibleRect.Y + pageVisibleRect.Height - annotationHeight;

            // if visual tool has mouse focus
            if (visualToolMouseObserver.VisualToolHasMouseFocus)
            {
                // get mouse location on image
                PointF location = annotationTool.ImageViewer.PointToImageF(visualToolMouseObserver.VisualToolMouseLocation);
                // get mouse location on PDF page
                location = transform.TransformPoint(location);
                // get annotation location on PDF page
                locationX = location.X;
                locationY = location.Y;
            }

            // returns annotation rectangle on PDF page
            return new RectangleF(locationX, locationY, annotationWidth, annotationHeight);
        }

        /// <summary>
        /// Determines that the annotation line ending style is represented by closed figure.
        /// </summary>
        public static bool IsClosedLineEndingStyle(PdfAnnotationLineEndingStyle style)
        {
            return style == PdfAnnotationLineEndingStyle.Square ||
                   style == PdfAnnotationLineEndingStyle.Circle ||
                   style == PdfAnnotationLineEndingStyle.Diamond ||
                   style == PdfAnnotationLineEndingStyle.ClosedArrow ||
                   style == PdfAnnotationLineEndingStyle.RClosedArrow;
        }

    }
}
