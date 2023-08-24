using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.UI;

using DemosCommonCode.Imaging;

namespace DemosCommonCode.Pdf.Security
{
    /// <summary>
    /// A form that allows to edit the redaction mark appearance.
    /// </summary>
    public partial class RedactionMarkAppearanceEditor : Form
    {
        
        #region Fields

        /// <summary>
        /// The PDF document.
        /// </summary>
        PdfDocument _document;

        /// <summary>
        /// The redaction mark appearance.
        /// </summary>
        RedactionMarkAppearanceGraphicsFigure _redactionMarkAppearance;

        #endregion



        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="RedactionMarkAppearanceEditor"/> class
        /// from being created.
        /// </summary>
        private RedactionMarkAppearanceEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RedactionMarkAppearanceEditor"/> class.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="redactionMarkAppearance">The redaction mark appearance.</param>
        public RedactionMarkAppearanceEditor(
            PdfDocument document,
            RedactionMarkAppearanceGraphicsFigure redactionMarkAppearance)
            : this()
        {
            _document = document;
            _redactionMarkAppearance = redactionMarkAppearance;
            if (_redactionMarkAppearance.Font == null ||
                _redactionMarkAppearance.Font.Document != document)
                _redactionMarkAppearance.Font = _document.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);

            // create temp PDF document
            SizeF size = redactionMarkEditor.Size;
            size.Width *= 72f / 96f;
            size.Height *= 72f / 96f;
            MemoryStream ms = new MemoryStream();
            using (PdfDocument tempDocument = new PdfDocument())
            {
                tempDocument.Pages.Add(size);
                tempDocument.Save(ms);
            }
            redactionMarkEditor.Images.Add(ms, true);
            _redactionMarkAppearance.SetRegion(new RegionF(new RectangleF(PointF.Empty, size)));

            // use PdfContentEditorTool for editing the signature appearance
            PdfContentEditorTool editorTool = new PdfContentEditorTool();
            GraphicsFigureView view = GraphicsFigureViewFactory.CreateView(_redactionMarkAppearance);
            view.Transformer = null;
            view.Builder = null;
            editorTool.FigureViewCollection.Add(view);
            redactionMarkEditor.VisualTool = editorTool;

            alignmentComboBox.Items.Add(PdfContentAlignment.Center);
            alignmentComboBox.Items.Add(PdfContentAlignment.Top);
            alignmentComboBox.Items.Add(PdfContentAlignment.Bottom);
            alignmentComboBox.Items.Add(PdfContentAlignment.Left);
            alignmentComboBox.Items.Add(PdfContentAlignment.Right);
            alignmentComboBox.Items.Add(PdfContentAlignment.Top | PdfContentAlignment.Left);
            alignmentComboBox.Items.Add(PdfContentAlignment.Top | PdfContentAlignment.Right);
            alignmentComboBox.Items.Add(PdfContentAlignment.Top | PdfContentAlignment.Left | PdfContentAlignment.Right);
            alignmentComboBox.Items.Add(PdfContentAlignment.Bottom | PdfContentAlignment.Left);
            alignmentComboBox.Items.Add(PdfContentAlignment.Bottom | PdfContentAlignment.Right);
            alignmentComboBox.Items.Add(PdfContentAlignment.Bottom | PdfContentAlignment.Right | PdfContentAlignment.Left);
            alignmentComboBox.Items.Add(PdfContentAlignment.Left | PdfContentAlignment.Top);
            alignmentComboBox.Items.Add(PdfContentAlignment.Left | PdfContentAlignment.Bottom);
            alignmentComboBox.Items.Add(PdfContentAlignment.Left | PdfContentAlignment.Bottom | PdfContentAlignment.Top);
            alignmentComboBox.Items.Add(PdfContentAlignment.Right | PdfContentAlignment.Top);
            alignmentComboBox.Items.Add(PdfContentAlignment.Right | PdfContentAlignment.Bottom);
            alignmentComboBox.Items.Add(PdfContentAlignment.Right | PdfContentAlignment.Bottom | PdfContentAlignment.Top);
            alignmentComboBox.SelectedItem = _redactionMarkAppearance.TextAlignment;
                        
            fillColorPanelControl.Color = _redactionMarkAppearance.FillColor;
            isFillColorEnabledCheckBox.Checked = !_redactionMarkAppearance.FillColor.IsEmpty;

            borderColorPanelControl.Color = _redactionMarkAppearance.BorderColor;
            borderWidthNumericUpDown.Value = (decimal)_redactionMarkAppearance.BorderWidth;
            isBorderPropertiesEnabledCheckBox.Checked = !_redactionMarkAppearance.BorderColor.IsEmpty;

            autoFontSizeCheckBox.Checked = _redactionMarkAppearance.AutoFontSize;

            overlayTextBox.Text = _redactionMarkAppearance.Text;
            fontSizeNumericUpDown.Value = (decimal)_redactionMarkAppearance.FontSize;
            fontColorPanelControl.Color = _redactionMarkAppearance.TextColor;            

            UpdateUI();
        }

        #endregion



        #region Methods

        /// <summary>
        /// Updates the user interface.
        /// </summary>
        private void UpdateUI()
        {
            fillColorPanelControl.Enabled = isFillColorEnabledCheckBox.Checked;
            borderPropertiesGroupBox.Enabled = isBorderPropertiesEnabledCheckBox.Checked;
        }


        /// <summary>
        /// The fill color is enabled/disabled.
        /// </summary>
        private void isFillColorEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isFillColorEnabledCheckBox.Checked)
                _redactionMarkAppearance.FillColor = fillColorPanelControl.Color;
            else
                _redactionMarkAppearance.FillColor = Color.Empty;

            UpdateUI();
        }

        /// <summary>
        /// The fill color is changed.
        /// </summary>
        private void fillColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            _redactionMarkAppearance.FillColor = fillColorPanelControl.Color;
        }


        /// <summary>
        /// The border is enabled/disabled.
        /// </summary>
        private void isBorderPropertiesEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isBorderPropertiesEnabledCheckBox.Checked)
            {
                if (borderColorPanelControl.Color != Color.Empty)
                {
                    _redactionMarkAppearance.BorderColor = borderColorPanelControl.Color;
                }
                else
                {
                    _redactionMarkAppearance.BorderColor = Color.Black;
                    borderColorPanelControl.Color = Color.Black;
                }

                _redactionMarkAppearance.BorderWidth = (float)borderWidthNumericUpDown.Value;
                
            }
            else
            {
                _redactionMarkAppearance.BorderColor = Color.Empty;
                _redactionMarkAppearance.BorderWidth = 0;
                _redactionMarkAppearance.BorderWidth = 0;
            }

            UpdateUI();
        }

        /// <summary>
        /// The border color is changed.
        /// </summary>
        private void borderColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            _redactionMarkAppearance.BorderColor = borderColorPanelControl.Color;
        }

        /// <summary>
        /// The border width is changed.
        /// </summary>
        private void borderWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _redactionMarkAppearance.BorderWidth = (float)borderWidthNumericUpDown.Value;
        }


        /// <summary>
        /// The overlay text is changed.
        /// </summary>
        private void overlayTextBox_TextChanged(object sender, EventArgs e)
        {
            _redactionMarkAppearance.Text = overlayTextBox.Text;
        }

        /// <summary>
        /// The overlay text alignment is changed.
        /// </summary>
        private void alignmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _redactionMarkAppearance.TextAlignment = (PdfContentAlignment)alignmentComboBox.SelectedItem;
        }

        /// <summary>
        /// The text color is changed.
        /// </summary>
        private void fontColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            _redactionMarkAppearance.TextColor = fontColorPanelControl.Color;            
        }

        /// <summary>
        /// The "Font..." button is clicked.
        /// </summary>
        private void fontButton_Click(object sender, EventArgs e)
        {
            CreateFontForm fontForm = new CreateFontForm(_document);
            if (fontForm.ShowDialog() == DialogResult.OK)
                _redactionMarkAppearance.Font = fontForm.SelectedFont;
        }

        /// <summary>
        /// The overlay text font size is changed.
        /// </summary>
        private void fontSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _redactionMarkAppearance.FontSize = (float)fontSizeNumericUpDown.Value;
        }

        /// <summary>
        /// The auto font size is enabled/disabled.
        /// </summary>
        private void autoFontSizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _redactionMarkAppearance.AutoFontSize = autoFontSizeCheckBox.Checked;
            fontSizeNumericUpDown.Enabled = !autoFontSizeCheckBox.Checked;
        }


        /// <summary>
        /// "Ok" button is clicked.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

    }
}
