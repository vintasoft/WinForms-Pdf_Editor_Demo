using System;
using System.Drawing;
using System.Windows.Forms;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Tree;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A form that allows to set the blending settings for PDF pen or PDF brush.
    /// </summary>
    public partial class SelectHighlightForm : Form
    {

        PdfPen _pen;
        PdfBrush _brush;



        public SelectHighlightForm(PdfPen pen)
        {
            InitializeComponent();

            _pen = pen;
            propertyGrid.SelectedObject = _pen;
            Text = "Pen";
        }

        public SelectHighlightForm(PdfBrush brush)
        {
            InitializeComponent();

            _brush = brush;
            propertyGrid.SelectedObject = _brush;
            Text = "Brush";
        }



        public int ModeIndex
        {
            get
            {
                return modeComboBox.SelectedIndex;
            }
            set
            {
                modeComboBox.SelectedIndex = value;
            }
        }



        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of CancelButton object.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of ModeComboBox object.
        /// </summary>
        private void modeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modeComboBox.SelectedIndex >= 0)
            {
                GraphicsStateBlendMode blendingMode = GraphicsStateBlendMode.Normal;
                Color blendColor = Color.Black;
                switch (modeComboBox.SelectedIndex)
                {
                    //Text highlight (yellow)
                    case 0:
                        blendingMode = GraphicsStateBlendMode.Multiply;
                        blendColor = Color.Yellow;
                        break;
                    //Text highlight (red)
                    case 1:
                        blendingMode = GraphicsStateBlendMode.Multiply;
                        blendColor = Color.Red;
                        break;
                    //Text highlight (green)
                    case 2:
                        blendingMode = GraphicsStateBlendMode.Multiply;
                        blendColor = Color.Lime;
                        break;
                    //Invert
                    case 3:
                        blendingMode = GraphicsStateBlendMode.Difference;
                        blendColor = Color.White;
                        break;
                    //Soft light
                    case 4:
                        blendingMode = GraphicsStateBlendMode.SoftLight;
                        blendColor = Color.White;
                        break;
                    //Soft light (red)
                    case 5:
                        blendingMode = GraphicsStateBlendMode.SoftLight;
                        blendColor = Color.Red;
                        break;
                    //Soft light (green)
                    case 6:
                        blendingMode = GraphicsStateBlendMode.SoftLight;
                        blendColor = Color.Lime;
                        break;
                    //Soft light (blue)
                    case 7:
                        blendingMode = GraphicsStateBlendMode.SoftLight;
                        blendColor = Color.Blue;
                        break;
                    //Hue (red)
                    case 8:
                        blendingMode = GraphicsStateBlendMode.Hue;
                        blendColor = Color.Red;
                        break;
                    //Hue (green)
                    case 9:
                        blendingMode = GraphicsStateBlendMode.Hue;
                        blendColor = Color.Lime;
                        break;
                    //Hue (blue)
                    case 10:
                        blendingMode = GraphicsStateBlendMode.Hue;
                        blendColor = Color.Blue;
                        break;
                }
                if (_pen != null)
                {
                    _pen.BlendMode = blendingMode;
                    _pen.Color = blendColor;
                    propertyGrid.SelectedObject = _pen;
                }
                else
                {
                    _brush.BlendMode = blendingMode;
                    _brush.Color = blendColor;
                    propertyGrid.SelectedObject = _brush;
                }
            }
        }

    }
}
