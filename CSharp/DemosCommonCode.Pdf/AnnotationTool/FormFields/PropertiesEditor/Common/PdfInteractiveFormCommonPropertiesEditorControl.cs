using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit common properties of the <see cref="PdfInteractiveFormField"/>.
    /// </summary>
    public partial class PdfInteractiveFormCommonPropertiesEditorControl : UserControl, IPdfInteractiveFormPropertiesEditor
    {

        #region Constants

        /// <summary>
        /// A string that defines that font size must be calculated automatically.
        /// </summary>
        const string FONT_SIZE_AUTO = "Auto";

        /// <summary>
        /// A string that defines that the font size is not specified.
        /// </summary>
        const string FONT_SIZE_NOT_SPECIFIED = "Not Specified";

        #endregion



        #region Fields

        /// <summary>
        /// The annotation of field.
        /// </summary>
        PdfWidgetAnnotation _annotation = null;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfInteractiveFormCommonPropertiesEditorControl"/> class.
        /// </summary>
        public PdfInteractiveFormCommonPropertiesEditorControl()
        {
            InitializeComponent();

            float fontSizeMinValue = 4f;
            float fontSizeMaxValue = 20f;
            float fontSizeStep = 2f;

            fontSizeComboBox.Items.Add(FONT_SIZE_AUTO);
            autoFontSizeMinValueComboBox.Items.Add(FONT_SIZE_NOT_SPECIFIED);
            autoFontSizeMaxValueComboBox.Items.Add(FONT_SIZE_NOT_SPECIFIED);

            for (float fontSize = fontSizeMinValue; fontSize <= fontSizeMaxValue; fontSize += fontSizeStep)
            {
                string fontSizeStr = fontSize.ToString(CultureInfo.InvariantCulture);
                fontSizeComboBox.Items.Add(fontSizeStr);

                autoFontSizeMinValueComboBox.Items.Add(fontSizeStr);
                autoFontSizeMaxValueComboBox.Items.Add(fontSizeStr);
            }
        }

        #endregion



        #region Properties

        #region PUBLIC

        PdfInteractiveFormField _field = null;
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PdfInteractiveFormField Field
        {
            get
            {
                return _field;
            }
            set
            {
                if (_field != value)
                {
                    _field = value;

                    if (_field == null)
                    {
                        borderStyleControl.Annotation = null;
                    }
                    else
                    {
                        _annotation = _field.Annotation;
                        if (_annotation != null)
                        {
                            if (_annotation.AppearanceCharacteristics == null)
                            {
                                _annotation.AppearanceCharacteristics =
                                    new PdfAnnotationAppearanceCharacteristics(_annotation.Document);
                            }
                        }
                        borderStyleControl.Annotation = _annotation;
                    }

                    UpdateFieldInfo();
                    UpdateUI();
                }
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Gets or sets the font size minimum value.
        /// </summary>
        private float FontSizeMinValue
        {
            get
            {
                return _field.AutoFontSizeMinValue;
            }
            set
            {
                _field.AutoFontSizeMinValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the font size maximum value.
        /// </summary>
        private float FontSizeMaxValue
        {
            get
            {
                PdfInteractiveFormTextField textField = _field as PdfInteractiveFormTextField;
                if (textField != null && textField.IsMultiline)
                    return textField.MultilineAutoFontSizeMaxValue;
                else
                    return _field.AutoFontSizeMaxValue;
            }
            set
            {
                PdfInteractiveFormTextField textField = _field as PdfInteractiveFormTextField;
                if (textField != null && textField.IsMultiline)
                    textField.MultilineAutoFontSizeMaxValue = value;
                else
                    _field.AutoFontSizeMaxValue = value;
            }
        }

        #endregion

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates the field information.
        /// </summary>
        public void UpdateFieldInfo()
        {
            borderStyleControl.UpdateBorderInfo();

            if (_field == null)
            {
                nameTextBox.Text = string.Empty;
                pdfFontPanelControl.PdfFont = null;
            }
            else
            {
                nameTextBox.Text = _field.PartialName;

                SetFontSizeComboBoxValue(fontSizeComboBox, _field.FontSize);
                SetFontSizeComboBoxValue(autoFontSizeMinValueComboBox, FontSizeMinValue);
                SetFontSizeComboBoxValue(autoFontSizeMaxValueComboBox, FontSizeMaxValue);

                pdfFontPanelControl.PdfFont = _field.Font;
                if (pdfFontPanelControl.PdfDocument == null)
                    pdfFontPanelControl.PdfDocument = _field.Document;
                fontColorPanelControl.Color = _field.TextColor;

                if (_field is PdfInteractiveFormVintasoftBarcodeField)
                {
                    PdfInteractiveFormVintasoftBarcodeField field = (PdfInteractiveFormVintasoftBarcodeField)_field;
                    backgroundColorPanelControl.Color = field.BackgroundColor;
                }
                else if (_annotation != null)
                    backgroundColorPanelControl.Color = _annotation.AppearanceCharacteristics.BackgroundColor;

                requiredCheckBox.Checked = _field.IsRequired;
                readOnlyCheckBox.Checked = _field.IsReadOnly;
                noExportCheckBox.Checked = _field.IsNoExport;
            }
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the TextChanged event of nameTextBox object.
        /// </summary>
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            // if field value is not changed
            if (_field == null || string.IsNullOrEmpty(nameTextBox.Text))
                return;

            // update field partial name
            _field.PartialName = nameTextBox.Text;
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the PdfFontChanged event of pdfFontPanelControl object.
        /// </summary>
        private void pdfFontPanelControl_PdfFontChanged(object sender, EventArgs e)
        {
            if (_field != null)
            {
                // update field font
                _field.Font = pdfFontPanelControl.PdfFont;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the ValueUpdate event of fontSizeComboBox object.
        /// </summary>
        private void fontSizeComboBox_ValueUpdate(object sender, EventArgs e)
        {
            if (_field != null)
            {
                float value;
                // if font size is correct
                if (GetFontSizeComboBoxValue(fontSizeComboBox, out value))
                {
                    bool isAutoSize = value == 0;
                    // if font size must be calculated automatically
                    if (isAutoSize && !FONT_SIZE_AUTO.Equals(fontSizeComboBox.Text))
                        fontSizeComboBox.Text = FONT_SIZE_AUTO;

                    // update font size
                    _field.FontSize = value;
                    OnPropertyValueChanged();

                    // if font size must be calculated automatically
                    if (isAutoSize)
                    {
                        autoFontSizeMinValueComboBox.Enabled = true;
                        autoFontSizeMaxValueComboBox.Enabled = true;
                    }
                    else
                    {
                        autoFontSizeMinValueComboBox.Enabled = false;
                        autoFontSizeMaxValueComboBox.Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the ValueUpdate event of autoFontSizeMinValueComboBox object.
        /// </summary>
        private void autoFontSizeMinValueComboBox_ValueUpdate(object sender, EventArgs e)
        {
            if (_field != null)
            {
                float value;
                // if minimum font size is correct
                if (GetFontSizeComboBoxValue(autoFontSizeMinValueComboBox, out value))
                {
                    // if minimum font size is not specified
                    if (value == 0 && !FONT_SIZE_NOT_SPECIFIED.Equals(autoFontSizeMinValueComboBox.Text))
                        autoFontSizeMinValueComboBox.Text = FONT_SIZE_NOT_SPECIFIED;

                    // update minimum font size
                    FontSizeMinValue = value;
                    OnPropertyValueChanged();
                }
            }
        }

        /// <summary>
        /// Handles the ValueUpdate event of autoFontSizeMaxValueComboBox object.
        /// </summary>
        private void autoFontSizeMaxValueComboBox_ValueUpdate(object sender, EventArgs e)
        {
            if (_field != null)
            {
                float value;
                // if maximum font size is correct
                if (GetFontSizeComboBoxValue((ComboBox)autoFontSizeMaxValueComboBox, out value))
                {
                    // if maximum font size is not specified
                    if (value == 0 && !FONT_SIZE_NOT_SPECIFIED.Equals(autoFontSizeMaxValueComboBox.Text))
                        autoFontSizeMaxValueComboBox.Text = FONT_SIZE_NOT_SPECIFIED;

                    // update maximum font size
                    FontSizeMaxValue = value;
                    OnPropertyValueChanged();
                }
            }
        }

        /// <summary>
        /// Handles the ColorChanged event of fontColorPanelControl object.
        /// </summary>
        private void fontColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            if (_field != null)
            {
                // update text color
                _field.TextColor = fontColorPanelControl.Color;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the ColorChanged event of backgroundColorPanelControl object.
        /// </summary>
        private void backgroundColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            if (_field != null || _annotation != null)
            {
                // if barcode field is selected
                if (_field is PdfInteractiveFormVintasoftBarcodeField)
                {
                    PdfInteractiveFormVintasoftBarcodeField field = (PdfInteractiveFormVintasoftBarcodeField)_field;
                    // update background color
                    field.BackgroundColor = backgroundColorPanelControl.Color;
                }
                else
                {
                    // update appearance background color
                    _annotation.AppearanceCharacteristics.BackgroundColor = backgroundColorPanelControl.Color;
                }
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of requiredCheckBox object.
        /// </summary>
        private void requiredCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_field != null)
            {
                // if field is required
                if (requiredCheckBox.Checked)
                    _field.IsRequired = true;
                else
                    _field.IsRequired = false;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of readOnlyCheckBox object.
        /// </summary>
        private void readOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_field != null)
            {
                // if field is readonly
                if (readOnlyCheckBox.Checked)
                    _field.IsReadOnly = true;
                else
                    _field.IsReadOnly = false;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of noExportCheckBox object.
        /// </summary>
        private void noExportCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_field != null)
            {
                // if field value can not be exported
                if (noExportCheckBox.Checked)
                    _field.IsNoExport = true;
                else
                    _field.IsNoExport = false;
                OnPropertyValueChanged();
            }
        }

        #endregion


        /// <summary>
        /// Updates the User Interface.
        /// </summary>
        private void UpdateUI()
        {
            borderGroupBox.Enabled = _annotation != null;
            backgroundPanel.Enabled = _annotation != null;
            fontGroupBox.Enabled = true;

            if (_field is PdfInteractiveFormSignatureField)
            {
                fontGroupBox.Enabled = false;
            }
            else if (_field is PdfInteractiveFormBarcodeField)
            {
                fontGroupBox.Enabled = false;

                if (_field is PdfInteractiveFormVintasoftBarcodeField)
                {
                    borderGroupBox.Enabled = true;
                    backgroundPanel.Enabled = true;
                }
                else
                {
                    borderGroupBox.Enabled = false;
                    backgroundPanel.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Sets the font size.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="value">The value.</param>
        private void SetFontSizeComboBoxValue(ComboBox comboBox, float value)
        {
            int index = 0;

            if (value != 0)
            {
                index = -1;
                for (int i = 1; i < comboBox.Items.Count; i++)
                {
                    if (Convert.ToSingle(comboBox.Items[i]) == value)
                    {
                        index = i;
                        break;
                    }
                }
            }

            if (index >= 0)
                comboBox.SelectedIndex = index;
            else
                comboBox.Text = value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns the font size.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="value">The value.</param>
        private bool GetFontSizeComboBoxValue(ComboBox comboBox, out float value)
        {
            string text = comboBox.Text;

            if (FONT_SIZE_AUTO.Equals(text, StringComparison.InvariantCultureIgnoreCase) ||
                FONT_SIZE_NOT_SPECIFIED.Equals(text, StringComparison.InvariantCultureIgnoreCase))
                text = "0";

            text = text.Replace(",", ".");
            return float.TryParse(text, NumberStyles.Float | NumberStyles.AllowThousands,
                CultureInfo.InvariantCulture, out value);
        }

        /// <summary>
        /// The border style is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void borderStyleControl_PropertyValueChanged(object sender, EventArgs e)
        {
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
        /// Occurs when the property value is changed.
        /// </summary>
        public event EventHandler PropertyValueChanged;

        #endregion

    }
}
