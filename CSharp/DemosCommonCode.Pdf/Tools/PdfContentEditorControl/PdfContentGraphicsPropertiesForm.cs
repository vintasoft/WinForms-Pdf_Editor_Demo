using System.Windows.Forms;

using Vintasoft.Imaging.ImageColors;
using Vintasoft.Imaging.Pdf.Content;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Text;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A form that allows to edit the PDF content graphics properties.
    /// </summary>
    public partial class PdfContentGraphicsPropertiesForm : Form
    {
        
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfContentGraphicsPropertiesForm"/> class.
        /// </summary>
        public PdfContentGraphicsPropertiesForm()
        {
            InitializeComponent();

            textRenderingModeComboBox.Items.Add(TextRenderingMode.AddClipPath);
            textRenderingModeComboBox.Items.Add(TextRenderingMode.Fill);
            textRenderingModeComboBox.Items.Add(TextRenderingMode.FillAndAddClipPath);
            textRenderingModeComboBox.Items.Add(TextRenderingMode.FillAndStroke);
            textRenderingModeComboBox.Items.Add(TextRenderingMode.FillAndStrokeAndAddClipPath);
            textRenderingModeComboBox.Items.Add(TextRenderingMode.Invisible);
            textRenderingModeComboBox.Items.Add(TextRenderingMode.Stroke);
            textRenderingModeComboBox.Items.Add(TextRenderingMode.StrokeAndAddClipPath);
            textRenderingModeComboBox.SelectedItem = TextRenderingMode.Fill;

            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Normal);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Color);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.ColorBurn);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.ColorDodge);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Darken);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Difference);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Exclusion);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.HardLight);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Hue);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Lighten);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Luminosity);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Multiply);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Overlay);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Saturation);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.Screen);
            colorBlendingComboBox.Items.Add(GraphicsStateBlendMode.SoftLight);
            colorBlendingComboBox.SelectedItem = GraphicsStateBlendMode.Normal;

            GraphicsProperties = new PdfContentGraphicsProperties();
        }

        #endregion



        #region Properties

        PdfContentGraphicsProperties _graphicsProperties;
        /// <summary>
        /// Gets or sets the PDF content graphics properties.
        /// </summary>
        public PdfContentGraphicsProperties GraphicsProperties
        {
            get
            {
                return _graphicsProperties;
            }
            set
            {
                _graphicsProperties = value;
                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the CheckedChanged event of StrokePropertiesCheckBox object.
        /// </summary>
        private void strokePropertiesCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            strokeGroupBox.Enabled = strokePropertiesCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of FillPropertiesCheckBox object.
        /// </summary>
        private void fillPropertiesCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            fillGroupBox.Enabled = fillPropertiesCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of TextPropertiesCheckBox object.
        /// </summary>
        private void textPropertiesCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            textPropertiesGroupBox.Enabled = textPropertiesCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of ColorBlendingCheckBox object.
        /// </summary>
        private void colorBlendingCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            colorBlendingGroupBox.Enabled = colorBlendingCheckBox.Checked;
        }

        /// <summary>
        /// Handles the Click event of ButtonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            if (fillPropertiesCheckBox.Checked)
            {
                Argb32Color newColor = Argb32Color.FromColor(fillColorPanelControl.Color);
                if (GraphicsProperties.FillColor != newColor)
                    GraphicsProperties.FillColor = newColor;
            }
            else
            {
                GraphicsProperties.FillColor = null;
            }

            if (strokePropertiesCheckBox.Checked)
            {
                Argb32Color newColor = Argb32Color.FromColor(strokeColorPanelControl.Color);
                if (GraphicsProperties.StrokeColor != newColor)
                    GraphicsProperties.StrokeColor = newColor;
                GraphicsProperties.LineWidth = (float)lineWidthNumericUpDown.Value;
            }
            else
            {
                GraphicsProperties.StrokeColor = null;
                GraphicsProperties.LineWidth = null;
            }

            if (textPropertiesCheckBox.Checked)
            {
                GraphicsProperties.TextRenderingMode = (TextRenderingMode)textRenderingModeComboBox.SelectedItem;
            }
            else
            {
                GraphicsProperties.TextRenderingMode = null;
            }

            if (colorBlendingCheckBox.Checked)
            {
                GraphicsProperties.ColorBlendingMode = (GraphicsStateBlendMode)colorBlendingComboBox.SelectedItem;
            }
            else
            {
                GraphicsProperties.ColorBlendingMode = null;
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of ButtonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion


        #region UI State

        /// <summary>
        /// Updates the User Interface.
        /// </summary>
        internal void UpdateUI()
        {
            if (GraphicsProperties.FillColorSpace != null)
            {
                fillPropertiesCheckBox.Checked = true;
                fillColorPanelControl.Color = GraphicsProperties.FillColor.ToColor();
            }
            else
            {
                fillPropertiesCheckBox.Checked = false;
            }

            if (GraphicsProperties.StrokeColorSpace != null)
            {
                strokePropertiesCheckBox.Checked = true;
                strokeColorPanelControl.Color = GraphicsProperties.StrokeColor.ToColor();
                lineWidthNumericUpDown.Value = (decimal)(GraphicsProperties.LineWidth ?? 0);
            }
            else
            {
                strokePropertiesCheckBox.Checked = false;
            }

            if (GraphicsProperties.TextRenderingMode != null)
            {
                textPropertiesCheckBox.Checked = true;
                textRenderingModeComboBox.SelectedItem = GraphicsProperties.TextRenderingMode.Value;
            }
            else
            {
                textPropertiesCheckBox.Checked = false;
            }

            if (GraphicsProperties.ColorBlendingMode != null)
            {
                colorBlendingCheckBox.Checked = true;
                colorBlendingComboBox.SelectedItem = GraphicsProperties.ColorBlendingMode.Value;
            }
            else
            {
                colorBlendingCheckBox.Checked = false;
            }
        }

        #endregion       

        #endregion

    }
}
