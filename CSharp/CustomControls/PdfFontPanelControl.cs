using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree.Fonts;

using DemosCommonCode.Pdf;


namespace DemosCommonCode.CustomControls
{
    /// <summary>
    /// A panel that allows to show the selected PDF font and
    /// select PDF font.
    /// </summary>
    [DefaultEvent("PdfFontChanged")]
    [DefaultProperty("PdfFont")]
    public partial class PdfFontPanelControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfFontPanelControl"/> class.
        /// </summary>
        public PdfFontPanelControl()
        {
            InitializeComponent();

            toolTip1.SetToolTip(fontNameTextBox, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_CUSTOMCONTROLS_DOUBLE_CLICK_ON_THE_TEXT_BOX_FOR_CHANGING_THE_FONT);
        }

        #endregion



        #region Properties

        PdfFont _pdfFont = null;
        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Browsable(false)]
        public PdfFont PdfFont
        {
            get
            {
                return _pdfFont;
            }
            set
            {
                if (_pdfFont != value)
                {
                    _pdfFont = value;

                    string fontName = string.Empty;
                    if (_pdfFont != null)
                        fontName = _pdfFont.FontName;
                    fontNameTextBox.Text = fontName;
                }
            }
        }

        PdfDocument _document = null;
        /// <summary>
        /// Gets or sets the PDF document.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public PdfDocument PdfDocument
        {
            get
            {
                if (_pdfFont == null)
                    return _document;
                else
                    return _pdfFont.Document;
            }
            set
            {
                if (_pdfFont == null)
                    _document = value;
                else
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets or sets the button width.
        /// </summary>
        [Description("The button width.")]
        [DefaultValue(25)]
        public int ButtonWidth
        {
            get
            {
                return fontNameButton.Width;
            }
            set
            {
                fontNameButton.Width = Math.Max(1, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether button is visible.
        /// </summary>
        /// <value>
        /// <b>True</b> if button is visible; otherwise, <b>false</b>.
        /// </value>
        [Description("Indicates whether button is visible.")]
        [DefaultValue(true)]
        public bool ButtonVisible
        {
            get
            {
                return fontNameButton.Visible;
            }
            set
            {
                fontNameButton.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the button margin.
        /// </summary>
        /// <value>
        /// Default value is <b>3</b>.
        /// </value>
        [Description("The button margin.")]
        [DefaultValue(3)]
        public int ButtonMargin
        {
            get
            {
                return fontNameButton.Margin.Left;
            }
            set
            {
                fontNameButton.Margin = new Padding(
                    Math.Max(0, value),
                    fontNameButton.Margin.Top,
                    fontNameButton.Margin.Right,
                    fontNameButton.Margin.Bottom);
            }
        }

        /// <summary>
        /// Gets or sets the button text.
        /// </summary>
        /// <value>
        /// Default value is <b>...</b>.
        /// </value>
        [Description("The button text.")]
        [DefaultValue("...")]
        public string ButtonText
        {
            get
            {
                return fontNameButton.Text;
            }
            set
            {
                if (value != null)
                    fontNameButton.Text = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Shows the font dialog.
        /// </summary>
        public void ShowFontDialog()
        {
            using (CreateFontForm dialog = new CreateFontForm(PdfDocument, PdfFont))
            {
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Owner = Form.ActiveForm;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _pdfFont = dialog.SelectedFont;
                    fontNameTextBox.Text = _pdfFont.FontName;

                    if (PdfFontChanged != null)
                        PdfFontChanged(this, EventArgs.Empty);
                }
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the Click event of FontNameButton object.
        /// </summary>
        private void fontNameButton_Click(object sender, EventArgs e)
        {
            // show font dialog
            ShowFontDialog();
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of FontNameTextBox object.
        /// </summary>
        private void fontNameTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // if font dialog must be shown
            if (e.Button == MouseButtons.Left)
                // show font dialog
                ShowFontDialog();
        } 

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when font is changed.
        /// </summary>
        public event EventHandler PdfFontChanged;

        #endregion

    }
}
