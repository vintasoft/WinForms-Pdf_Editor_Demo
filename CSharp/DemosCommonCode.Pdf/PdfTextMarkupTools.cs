using System;
using System.Drawing;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.UI;
using Vintasoft.Imaging.Pdf.UI.Annotations;
using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// Contains common static functions for text markup on PDF page using PDF text markup annotation.
    /// </summary>
    public class PdfTextMarkupTools
    {

        #region Methods

        #region PUBLIC

        /// <summary>
        /// Highlights selected text on focused PDF page.
        /// </summary>
        public static PdfTextMarkupAnnotation HighlightSelectedText(ImageViewer viewer)
        {
            Color highlightTextColor = GetHighlightTextColor(viewer);
            return MarkupSelectedText(viewer, PdfAnnotationType.Highlight, highlightTextColor);
        }

        /// <summary>
        /// Strikeouts selected text on focused PDF page.
        /// </summary>
        public static PdfTextMarkupAnnotation StrikeoutSelectedText(ImageViewer viewer)
        {
            Color strikeoutTextColor = GetStrikeoutTextColor(viewer);
            return MarkupSelectedText(viewer, PdfAnnotationType.StrikeOut, strikeoutTextColor);
        }

        /// <summary>
        /// Underlines selected text on focused PDF page.
        /// </summary>
        /// <returns></returns>
        public static PdfTextMarkupAnnotation UnderlineSelectedText(ImageViewer viewer)
        {
            Color underlineTextColor = GetUnderlineTextColor(viewer);
            return MarkupSelectedText(viewer, PdfAnnotationType.Underline, underlineTextColor);
        }

        /// <summary>
        /// Squiggly underlines selected text on focused PDF page.
        /// </summary>
        public static PdfTextMarkupAnnotation SquigglyUnderlineSelectedText(ImageViewer viewer)
        {
            Color squigglyUnderlineTextColor = GetSquigglyUnderlineTextColor(viewer);
            return MarkupSelectedText(viewer, PdfAnnotationType.Squiggly, squigglyUnderlineTextColor);
        }

        /// <summary>
        /// Markups selected text on focused PDF page.
        /// </summary>
        /// <param name="annotationType">Type of the annotation.</param>
        /// <param name="viewer">The image viewer.</param>
        /// <param name="color">The color.</param>
        public static PdfTextMarkupAnnotation MarkupSelectedText(ImageViewer viewer, PdfAnnotationType annotationType, Color color)
        {
            TextSelectionTool textSelection = VisualTool.FindVisualTool<TextSelectionTool>(viewer.VisualTool);
            if (textSelection != null && textSelection.HasSelectedText)
            {
                TextRegion selectedRegion = textSelection.GetSelectedRegion(viewer.Image);
                if (!selectedRegion.IsEmpty)
                {
                    PdfPage page = PdfDocumentController.GetPageAssociatedWithImage(viewer.Image);

                    PdfTextMarkupAnnotation annotation = new PdfTextMarkupAnnotation(page, annotationType);
                    annotation.Color = color;
                    annotation.SetArea(selectedRegion);
                    annotation.Title = Environment.UserName;
                    annotation.Subject = annotationType.ToString();

                    if (page.Annotations == null)
                        page.Annotations = new PdfAnnotationList(page.Document);
                    page.Annotations.Add(annotation);

                    textSelection.ClearSelection();

                    // if viewer does not contains PdfAnnotationTool
                    if (VisualTool.FindVisualTool<PdfAnnotationTool>(viewer.VisualTool) == null)
                    {
                        // reload image
                        viewer.Image.Reload(true);
                    }

                    return annotation;
                }
            }
            return null;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Returns color of highlight text.
        /// </summary>
        /// <param name="viewer">The image viewer.</param>
        /// <returns>Color of highlight text.</returns>
        private static Color GetHighlightTextColor(ImageViewer viewer)
        {
            PdfTextMarkupTool markupTool = GetTextMarkupTool(viewer);
            if (markupTool != null)
                return markupTool.HighlightColor;
            return Color.FromArgb(255, 209, 0);
        }

        /// <summary>
        /// Returns color of strikeout text.
        /// </summary>
        /// <param name="viewer">The image viewer.</param>
        /// <returns>Color of strikeout text.</returns>
        private static Color GetStrikeoutTextColor(ImageViewer viewer)
        {
            PdfTextMarkupTool markupTool = GetTextMarkupTool(viewer);
            if (markupTool != null)
                return markupTool.StrikeoutColor;
            return Color.FromArgb(229, 34, 55);
        }

        /// <summary>
        /// Returns color of underline text.
        /// </summary>
        /// <param name="viewer">The image viewer.</param>
        /// <returns>Color of underline text.</returns>
        private static Color GetUnderlineTextColor(ImageViewer viewer)
        {
            PdfTextMarkupTool markupTool = GetTextMarkupTool(viewer);
            if (markupTool != null)
                return markupTool.UnderlineColor;
            return Color.FromArgb(106, 217, 38);
        }

        /// <summary>
        /// Returns color of Squiggly underline text.
        /// </summary>
        /// <param name="viewer">The image viewer.</param>
        /// <returns>Color of Squiggly underline text.</returns>
        private static Color GetSquigglyUnderlineTextColor(ImageViewer viewer)
        {
            PdfTextMarkupTool markupTool = GetTextMarkupTool(viewer);
            if (markupTool != null)
                return markupTool.SquigglyUnderlineColor;
            return Color.FromArgb(0, 198, 198);
        }

        /// <summary>
        /// Returns the PDF text markup tool.
        /// </summary>
        /// <param name="viewer">The image viewer.</param>
        private static PdfTextMarkupTool GetTextMarkupTool(ImageViewer viewer)
        {
            if (viewer == null)
                return null;
            return VisualTool.FindVisualTool<PdfTextMarkupTool>(viewer.VisualTool);
        }

        #endregion

        #endregion

    }
}
