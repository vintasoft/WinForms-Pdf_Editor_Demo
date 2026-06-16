using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Vintasoft.Imaging.Drawing.Gdi;
using Vintasoft.Imaging.Pdf.Content.TextExtraction;

namespace CommonCode.Pdf
{
    /// <summary>
    /// A form that allows to edit Unicode symbol of PDF text symbol.
    /// </summary>
    public partial class EditPdfFontSymbolForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EditPdfFontSymbolForm"/> class.
        /// </summary>
        /// <param name="pdfTextSymbol">The PDF text symbol.</param>
        /// <param name="unicodeSymbol">The unicode symbol.</param>
        public EditPdfFontSymbolForm(PdfTextSymbol pdfTextSymbol, char? unicodeSymbol)
        {
            if (pdfTextSymbol == null)
                throw new ArgumentNullException();

            InitializeComponent();

            _pdfTextSymbol = pdfTextSymbol;
            _unicodeSymbol = unicodeSymbol;

            if (unicodeSymbol == null)
                unicodeSymbolTextBox.Text = pdfTextSymbol.Symbols;
            else
                unicodeSymbolTextBox.Text = string.Format("{0}", unicodeSymbol);
        }

        #endregion



        #region Properties

        PdfTextSymbol _pdfTextSymbol;
        /// <summary>
        /// Gets the PDF text symbol.
        /// </summary>
        public PdfTextSymbol PdfTextSymbol
        {
            get
            {
                return _pdfTextSymbol;
            }
        }

        char? _unicodeSymbol;
        /// <summary>
        /// Gets the Unicode symbol of PDF text symbol.
        /// </summary>
        public char? UnicodeSymbol
        {
            get
            {
                return _unicodeSymbol;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Pen pen = new Pen(ForeColor))
            {
                using (SolidBrush fontBrush = new SolidBrush(Color.Black))
                {
                    GraphicsState graphicsState = e.Graphics.Save();
                    try
                    {
                        GdiGraphicsPath symbolPath = (GdiGraphicsPath)_pdfTextSymbol.GetAsGraphicsPath();

                        const float CELL_SIZE = 300f;

                        e.Graphics.TranslateTransform(0, 0);
                        RectangleF symbolBBox = symbolPath.GetBounds();
                        e.Graphics.TranslateTransform(-symbolBBox.X / 1000 + (CELL_SIZE - symbolBBox.Width / 1000 * CELL_SIZE) / 2, 0);
                        e.Graphics.ScaleTransform(CELL_SIZE / 1000, CELL_SIZE / 1000);
                        e.Graphics.FillPath(fontBrush, symbolPath.Source);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        e.Graphics.Restore(graphicsState);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(unicodeSymbolTextBox.Text))
            {
                MessageBox.Show(PdfEditorDemo.Localization.Strings.COMMONCODE_PDF_UNICODE_SYMBOL_CANNOT_BE_EMPTY);
                return;
            }

            _unicodeSymbol = unicodeSymbolTextBox.Text[0];

            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
