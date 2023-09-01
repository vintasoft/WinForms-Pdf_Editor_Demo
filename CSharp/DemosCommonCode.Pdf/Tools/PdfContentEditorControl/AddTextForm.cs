using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Content.TextExtraction;
using Vintasoft.Imaging.Pdf.Tree.Fonts;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A form that allows to enter the text, which must be added to a PDF document.
    /// </summary>
    public partial class AddTextForm : Form
    {

        #region Fields

        List<PdfFont> _fonts;
        PdfDocument _document;
        PdfDocument _tempDocument = null;

        #endregion



        #region Constructor

        public AddTextForm(PdfDocument document, IList<PdfFont> fonts, string initialText)
        {
            InitializeComponent();
            _document = document;
            _fonts = new List<PdfFont>();
            _fonts.AddRange(fonts);
            if (_fonts.Count > 0)
            {
                for (int i = 0; i < _fonts.Count; i++)
                    fontComboBox.Items.Add(string.Format("[{1}] {0}", _fonts[i].FontName, _fonts[i].ObjectNumber));
                fontComboBox.SelectedIndex = 0;
            }
            fontSizeComboBox.Text = "12";
            textBox.Text = initialText;
            okButton.Focus();
        }

        #endregion



        #region Properties

        public string TextToAdd
        {
            get
            {
                return textBox.Text;
            }
        }

        public PdfFont TextFont
        {
            get
            {
                return _fonts[fontComboBox.SelectedIndex];
            }
        }

        public float TextSize
        {
            get
            {
                return float.Parse(fontSizeComboBox.Text, CultureInfo.InvariantCulture);
            }
        }

        public Color TextColor
        {
            get
            {
                return colorPanelControl.Color;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of CancelButton object.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (_tempDocument != null)
                _tempDocument.Dispose();
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (fontComboBox.SelectedItem == null)
            {
                DemosTools.ShowWarningMessage(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_TEXT_FONT_IS_NOT_SPECIFIED);
                return;
            }
            if (_tempDocument != null)
                _tempDocument.Dispose();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the TextChanged event of TextBox object.
        /// </summary>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = textBox.Text.Length > 0;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of FontComboBox object.
        /// </summary>
        private void fontComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pdfFontViewerControl.PdfFont = _fonts[fontComboBox.SelectedIndex];
        }

        /// <summary>
        /// Handles the MouseDown event of PdfFontViewerControl object.
        /// </summary>
        private void pdfFontViewerControl_MouseDown(object sender, MouseEventArgs e)
        {
            PdfTextSymbol symbol = pdfFontViewerControl.GetTextSymbol(e.Location);
            if (symbol != null)
                textBox.AppendText(symbol.Symbols);
        }

        /// <summary>
        /// Handles the Click event of AddFontButton object.
        /// </summary>
        private void addFontButton_Click(object sender, EventArgs e)
        {
            CreateFontForm dialog = new CreateFontForm(_document);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PdfFont font = dialog.SelectedFont;
                _fonts.Add(font);
                fontComboBox.Items.Add(string.Format("[{1}] {0}", font.FontName, font.ObjectNumber));
                fontComboBox.SelectedIndex = fontComboBox.Items.Count - 1;
            }
        }

        #endregion

    }
}
