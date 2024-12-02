using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of
    /// the <see cref="PdfInteractiveFormBarcodeField"/>.
    /// </summary>
    public partial class PdfBarcodeFieldPropertiesEditorControl : UserControl, IPdfInteractiveFormPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfBarcodeFieldPropertiesEditorControl"/> class.
        /// </summary>
        public PdfBarcodeFieldPropertiesEditorControl()
        {
            InitializeComponent();

            foreach (BarcodeSymbologyType type in Enum.GetValues(typeof(BarcodeSymbologyType)))
            {
                if (type == BarcodeSymbologyType.Unsupported)
                    continue;

                barcodeSymbologyComboBox.Items.Add(type);
            }

            foreach (BarcodeDataPreparationMode mode in Enum.GetValues(typeof(BarcodeDataPreparationMode)))
                dataPreparationStepsComboBox.Items.Add(mode);

            moduleWidthNumericUpDown.Minimum = decimal.MinValue;
            moduleWidthNumericUpDown.Maximum = decimal.MaxValue;
        }

        #endregion



        #region Properties

        PdfInteractiveFormBarcodeField _field = null;
        /// <summary>
        /// Gets or sets the <see cref="PdfInteractiveFormBarcodeField"/>.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PdfInteractiveFormBarcodeField Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;

                mainTabControl.Enabled = _field != null;

                UpdateFieldInfo();
            }
        }

        /// <summary>
        /// Gets or sets the PDF interactive form field.
        /// </summary>
        PdfInteractiveFormField IPdfInteractiveFormPropertiesEditor.Field
        {
            get
            {
                return Field;
            }
            set
            {
                Field = value as PdfInteractiveFormBarcodeField;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the SelectedIndexChanged event of mainTabControl object.
        /// </summary>
        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update field info
            UpdateFieldInfo();
        }

        /// <summary>
        /// Handles the ActionChanged event of calculateActionEditorControl object.
        /// </summary>
        private void calculateActionEditorControl_ActionChanged(object sender, EventArgs e)
        {
            PdfJavaScriptAction jsAction = calculateActionEditorControl.Action as PdfJavaScriptAction;
            // if selected action is not JavaScript action
            if (calculateActionEditorControl.Action != null && jsAction == null)
            {
                // show error message

                string message = "Activate action of form field is not derived from PdfJavaScriptAction.";
                calculateActionEditorControl.Action = null;
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // update calculate action
                _field.AdditionalActions.Calculate = jsAction;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of barcodeSymbologyComboBox object.
        /// </summary>
        private void barcodeSymbologyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get barcode symbology type
            BarcodeSymbologyType barcodeSymbologyType = (BarcodeSymbologyType)barcodeSymbologyComboBox.SelectedItem;
            // if barcode symbology is changed
            if (_field.BarcodeSymbology != barcodeSymbologyType)
            {
                // if barcode symbology is not supported
                if (barcodeSymbologyType == BarcodeSymbologyType.Unsupported)
                {
                    // show error message

                    string message = "Unsupported value can not be used.";
                    barcodeSymbologyComboBox.SelectedItem = _field.BarcodeSymbology;
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // update barcode symbology
                    _field.BarcodeSymbology = barcodeSymbologyType;

                    OnPropertyValueChanged();

                    UpdateErrorCorrectionCoefficientComboBox();
                }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of errorCorrectionCoefficientComboBox object.
        /// </summary>
        private void errorCorrectionCoefficientComboBox_SelectedIndexChanged(
    object sender,
    EventArgs e)
        {
            // if error correction coefficient is changed
            if (_field.ErrorCorrectionCoefficient != errorCorrectionCoefficientComboBox.SelectedIndex)
            {
                // update error correction coefficient is changed
                _field.ErrorCorrectionCoefficient = errorCorrectionCoefficientComboBox.SelectedIndex;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of valueTextBox object.
        /// </summary>
        private void valueTextBox_TextChanged(object sender, EventArgs e)
        {
            // get value
            string newValue = valueTextBox.Text;
            // if field value is not exist
            if (_field.Value == null)
            {
                // create field value
                _field.Value = new PdfInteractiveFormTextFieldStringValue(_field.Document, newValue);
            }
            else
            {
                // if field value is not changed
                if (_field.Value.TextValue == newValue)
                    return;

                // update field value
                _field.Value.TextValue = newValue;
            }

            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the TextChanged event of defaultValueTextBox object.
        /// </summary>
        private void defaultValueTextBox_TextChanged(object sender, EventArgs e)
        {
            // get value
            string newValue = defaultValueTextBox.Text;
            // if default field value is not exist
            if (_field.DefaultValue == null)
            {
                // create default field value
                _field.DefaultValue = new PdfInteractiveFormTextFieldStringValue(_field.Document, newValue);
            }
            else
            {
                // if default field value is not changed
                if (_field.DefaultValue.TextValue == newValue)
                    return;

                // update default field value
                _field.DefaultValue.TextValue = newValue;
            }

            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of dataPreparationStepsComboBox object.
        /// </summary>
        private void dataPreparationStepsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeDataPreparationMode dataPreparationSteps =
                (BarcodeDataPreparationMode)dataPreparationStepsComboBox.SelectedItem;
            // if data preparation steps is changed
            if (_field.DataPreparationSteps != dataPreparationSteps)
            {
                // update data preparation steps
                _field.DataPreparationSteps = dataPreparationSteps;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of moduleWidthNumericUpDown object.
        /// </summary>
        private void moduleWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // get module width
            float moduleWidth = Convert.ToSingle(moduleWidthNumericUpDown.Value);
            // if module width is changed
            if (_field.ModuleWidth != moduleWidth)
            {
                // update modula width
                _field.ModuleWidth = moduleWidth;
                OnPropertyValueChanged();
            }
        }

        #endregion


        /// <summary>
        /// Updates information about the field.
        /// </summary>
        public void UpdateFieldInfo()
        {
            if (_field == null)
                return;

            if (mainTabControl.SelectedTab == valueTabPage)
            {
                bool updateErrorCorrectionCoefficientComboBox =
                    barcodeSymbologyComboBox.SelectedItem == null ||
                    (BarcodeSymbologyType)barcodeSymbologyComboBox.SelectedItem == _field.BarcodeSymbology;
                if (_field.BarcodeSymbology == BarcodeSymbologyType.Unsupported &&
                    !barcodeSymbologyComboBox.Items.Contains(BarcodeSymbologyType.Unsupported))
                    barcodeSymbologyComboBox.Items.Add(BarcodeSymbologyType.Unsupported);
                if (_field.BarcodeSymbology != BarcodeSymbologyType.Unsupported &&
                    barcodeSymbologyComboBox.Items.Contains(BarcodeSymbologyType.Unsupported))
                    barcodeSymbologyComboBox.Items.Remove(BarcodeSymbologyType.Unsupported);

                barcodeSymbologyComboBox.SelectedItem = _field.BarcodeSymbology;

                if (updateErrorCorrectionCoefficientComboBox)
                    UpdateErrorCorrectionCoefficientComboBox();

                if (_field.Value == null)
                    valueTextBox.Text = string.Empty;
                else
                    valueTextBox.Text = _field.Value.TextValue;

                if (_field.DefaultValue == null)
                    defaultValueTextBox.Text = string.Empty;
                else
                    defaultValueTextBox.Text = _field.DefaultValue.TextValue;

                dataPreparationStepsComboBox.SelectedItem = _field.DataPreparationSteps;
                moduleWidthNumericUpDown.Value = Convert.ToDecimal(_field.ModuleWidth);
            }
            else if (mainTabControl.SelectedTab == calculateTabPage)
            {
                if (_field.AdditionalActions == null)
                    _field.AdditionalActions = new PdfInteractiveFormFieldAdditionalActions(_field.Document);

                calculateActionEditorControl.Action = _field.AdditionalActions.Calculate;
            }
        }

        /// <summary>
        /// Updates the error correction coefficient ComboBox.
        /// </summary>
        private void UpdateErrorCorrectionCoefficientComboBox()
        {
            BarcodeSymbologyType barcodeSymbologyType = (BarcodeSymbologyType)barcodeSymbologyComboBox.SelectedItem;
            errorCorrectionCoefficientComboBox.Items.Clear();

            if (barcodeSymbologyType == BarcodeSymbologyType.PDF417)
            {
                for (int i = 0; i < 9; i++)
                    errorCorrectionCoefficientComboBox.Items.Add(string.Format("Level{0}", i));
            }
            else if (barcodeSymbologyType == BarcodeSymbologyType.QRCode)
            {
                errorCorrectionCoefficientComboBox.Items.Add("L");
                errorCorrectionCoefficientComboBox.Items.Add("M");
                errorCorrectionCoefficientComboBox.Items.Add("Q");
                errorCorrectionCoefficientComboBox.Items.Add("H");
            }

            if (errorCorrectionCoefficientComboBox.Items.Count > 0)
            {
                if (_field.ErrorCorrectionCoefficient < errorCorrectionCoefficientComboBox.Items.Count &&
                    _field.ErrorCorrectionCoefficient >= 0)
                    errorCorrectionCoefficientComboBox.SelectedIndex = _field.ErrorCorrectionCoefficient;
                errorCorrectionCoefficientComboBox.Enabled = true;
            }
            else
                errorCorrectionCoefficientComboBox.Enabled = false;
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



        #region Events

        /// <summary>
        /// Occurs when value of property is changed.
        /// </summary>
        public event EventHandler PropertyValueChanged;

        #endregion

    }
}
