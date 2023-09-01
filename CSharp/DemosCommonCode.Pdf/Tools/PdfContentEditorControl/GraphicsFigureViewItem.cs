using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.UI;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// Provides GraphicsFigureView item.
    /// </summary>
    public class GraphicsFigureViewItem
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicsFigureViewItem"/> class.
        /// </summary>
        /// <param name="figureView">The figure view.</param>
        public GraphicsFigureViewItem(GraphicsFigureView figureView)
        {
            _figureView = figureView;
        }



        GraphicsFigureView _figureView;
        /// <summary>
        /// Gets the figure view.
        /// </summary>
        public GraphicsFigureView FigureView
        {
            get
            {
                return _figureView;
            }
        }



        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return GetDescription(FigureView);
        }

        /// <summary>
        /// Returns description of specified figure view.
        /// </summary>
        /// <param name="figureView">The figure view.</param>
        public static string GetDescription(GraphicsFigureView figureView)
        {
            GraphicsFigure figure = figureView.Figure;
            if (figure is ContentStreamGraphicsFigure)
                return string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_CONTENT_ARG0, figure.ContentType);
            if (figure is ContentStreamGraphicsFigureTextGroup)
                return PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_TEXT_CONTENT_GROUP;
            if (figure is ContentStreamGraphicsFigureGroup)
                return string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_CONTENT_GROUP_ARG0, figure.ContentType);
            return figureView.Figure.GetType().Name;
        }

    }
}
