using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Content;
using Vintasoft.Imaging.Pdf.Tree;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A form that allows to edit the PDF content graphics properties of XObject resource.
    /// </summary>
    public partial class PdfResourceGraphicsPropertiesForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfResourceGraphicsPropertiesForm"/> class.
        /// </summary>
        public PdfResourceGraphicsPropertiesForm()
        {
            InitializeComponent();          

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
        /// Handles the CheckedChanged event of colorBlendingCheckBox object.
        /// </summary>
        private void colorBlendingCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            colorBlendingGroupBox.Enabled = colorBlendingCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of alphaConstantCheckBox object.
        /// </summary>
        private void alphaConstantCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            alphaConstantValueEditor.Enabled = alphaConstantCheckBox.Checked;
        }

        /// <summary>
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            if (colorBlendingCheckBox.Checked)
            {
                GraphicsProperties.ColorBlendingMode = (GraphicsStateBlendMode)colorBlendingComboBox.SelectedItem;
            }
            else
            {
                GraphicsProperties.ColorBlendingMode = null;
            }

            if (alphaConstantCheckBox.Checked)
            {
                GraphicsProperties.FillAlphaConstant = alphaConstantValueEditor.Value / alphaConstantValueEditor.MaxValue;
            }
            else
            {
                GraphicsProperties.FillAlphaConstant = null;
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of buttonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion 


        #region UI state

        /// <summary>
        /// Updates the User Interface.
        /// </summary>
        internal void UpdateUI()
        {
            if (GraphicsProperties.ColorBlendingMode != null)
            {
                colorBlendingCheckBox.Checked = true;
                colorBlendingComboBox.SelectedItem = GraphicsProperties.ColorBlendingMode.Value;
            }
            else
            {
                colorBlendingCheckBox.Checked = false;
            }

            if (GraphicsProperties.FillAlphaConstant != null)
            {
                alphaConstantCheckBox.Checked = true;
                alphaConstantValueEditor.Value = GraphicsProperties.FillAlphaConstant.Value * alphaConstantValueEditor.MaxValue;
            }
            else
            {
                alphaConstantCheckBox.Checked = false;
            }
        }

        #endregion

        #endregion

    }
}
