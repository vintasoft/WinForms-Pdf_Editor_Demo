using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of the <see cref="PdfFreeTextAnnotation"/>.
    /// </summary>
    public partial class PdfFreeTextAnnotationPropertiesEditorControl : UserControl, IPdfAnnotationPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfFreeTextAnnotationPropertiesEditorControl"/> class.
        /// </summary>
        public PdfFreeTextAnnotationPropertiesEditorControl()
        {
            InitializeComponent();

            foreach (TextQuaddingType type in Enum.GetValues(typeof(TextQuaddingType)))
                textQuaddingComboBox.Items.Add(type);

            foreach (PdfAnnotationLineEndingStyle style in Enum.GetValues(typeof(PdfAnnotationLineEndingStyle)))
                lineEndingStyleComboBox.Items.Add(style);
        }

        #endregion



        #region Properties

        PdfFreeTextAnnotation _annotation;
        /// <summary>
        /// Gets or sets the annotation.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PdfFreeTextAnnotation Annotation
        {
            get
            {
                return _annotation;
            }
            set
            {
                _annotation = value;

                pdfAnnotationBorderEffectEditorControl1.Annotation = value;
                mainPanel.Enabled = _annotation != null;

                UpdateAnnotationInfo();
            }
        }

        /// <summary>
        /// Gets or sets the annotation.
        /// </summary>
        PdfAnnotation IPdfAnnotationPropertiesEditor.Annotation
        {
            get
            {
                return Annotation;
            }
            set
            {
                Annotation = value as PdfFreeTextAnnotation;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates the information about annotation.
        /// </summary>
        public void UpdateAnnotationInfo()
        {
            if (_annotation == null)
                return;

            textBox.Text = _annotation.Contents;
            textQuaddingComboBox.SelectedItem = _annotation.TextQuadding;
            backColorPanelControl.Color = _annotation.Color;
            pdfFontPanelControl1.PdfFont = _annotation.Font;
            if (pdfFontPanelControl1.PdfDocument == null)
                pdfFontPanelControl1.PdfDocument = _annotation.Document;
            fontSizeNumericUpDown.Value = Convert.ToDecimal(_annotation.FontSize);
            lineEndingStyleComboBox.SelectedItem = _annotation.LineEndingStyle;

            if (_annotation.CalloutLinePoints == null ||
                _annotation.CalloutLinePoints.Length == 0)
                lineEndingStyleComboBox.Enabled = false;
            else
                lineEndingStyleComboBox.Enabled = true;

            pdfAnnotationBorderEffectEditorControl1.UpdateAnnotationInfo();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the TextChanged event of textBox object.
        /// </summary>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            // if annotation content is changed
            if (_annotation.Contents != textBox.Text)
            {
                // update annotation content
                _annotation.Contents = textBox.Text;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of textQuaddingComboBox object.
        /// </summary>
        private void textQuaddingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get text quadding
            TextQuaddingType textQuadding = (TextQuaddingType)textQuaddingComboBox.SelectedItem;

            // if text quadding is changed
            if (_annotation.TextQuadding != textQuadding)
            {
                // update text quadding
                _annotation.TextQuadding = textQuadding;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the ColorChanged event of backColorPanelControl object.
        /// </summary>
        private void backColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            // if annotation color is changed
            if (_annotation.Color != backColorPanelControl.Color)
            {
                // update annotation color
                _annotation.Color = backColorPanelControl.Color;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the PdfFontChanged event of pdfFontPanelControl1 object.
        /// </summary>
        private void pdfFontPanelControl1_PdfFontChanged(object sender, EventArgs e)
        {
            // update the annotation font
            _annotation.Font = pdfFontPanelControl1.PdfFont;
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the ValueChanged event of fontSizeNumericUpDown object.
        /// </summary>
        private void fontSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // get font size
            float fontSize = Convert.ToSingle(fontSizeNumericUpDown.Value);
            // if annotation font size must be updated
            if (_annotation.FontSize != fontSize)
            {
                // update the annotation font size
                _annotation.FontSize = fontSize;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of lineEndingStyleComboBox object.
        /// </summary>
        private void lineEndingStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get annotation line ending style
            PdfAnnotationLineEndingStyle lineEndingStyle =
                (PdfAnnotationLineEndingStyle)lineEndingStyleComboBox.SelectedItem;

            // if line ending style is changed
            if (_annotation.LineEndingStyle != lineEndingStyle)
            {
                // update line ending style
                _annotation.LineEndingStyle = lineEndingStyle;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of pdfAnnotationBorderEffectEditorControl1 object.
        /// </summary>
        private void pdfAnnotationBorderEffectEditorControl1_PropertyValueChanged(
            object sender,
            EventArgs e)
        {
            // raise property value changed event
            OnPropertyValueChanged();
        }


        /// <summary>
        /// Raises the PropertyValueChanged event.
        /// </summary>
        private void OnPropertyValueChanged()
        {
            if (PropertyValueChanged != null)
                PropertyValueChanged(this, EventArgs.Empty);
        }

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when value of property is changed.
        /// </summary>
        public event EventHandler PropertyValueChanged;

        #endregion

    }
}
