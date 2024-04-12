using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of the <see cref="PdfInteractiveFormTextField"/>.
    /// </summary>
    public partial class PdfTextFieldPropertiesEditorControl : UserControl, IPdfInteractiveFormPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfTextFieldPropertiesEditorControl"/> class.
        /// </summary>
        public PdfTextFieldPropertiesEditorControl()
        {
            InitializeComponent();

            foreach (TextQuaddingType item in Enum.GetValues(typeof(TextQuaddingType)))
                textQuaddingComboBox.Items.Add(item);
        }

        #endregion



        #region Properties

        PdfInteractiveFormTextField _field = null;
        /// <summary>
        /// Gets or sets the <see cref="PdfInteractiveFormTextField"/>.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public PdfInteractiveFormTextField Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;

                mainPanel.Enabled = _field != null;

                if (_field == null)
                {
                    calculatePdfActionEditorControl.Document = null;
                    validatePdfActionEditorControl.Document = null;
                    formatPdfActionEditorControl.Document = null;
                    keystrokePdfActionEditorControl.Document = null;
                }
                else
                {
                    calculatePdfActionEditorControl.Document = _field.Document;
                    validatePdfActionEditorControl.Document = _field.Document;
                    formatPdfActionEditorControl.Document = _field.Document;
                    keystrokePdfActionEditorControl.Document = _field.Document;
                }

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
                Field = value as PdfInteractiveFormTextField;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates the field information.
        /// </summary>
        public void UpdateFieldInfo()
        {
            string value = string.Empty;
            string defaultValue = string.Empty;

            if (_field != null)
            {
                value = AddControlSymbols(_field.TextValue);
                defaultValue = AddControlSymbols(_field.TextDefaultValue);
                textQuaddingComboBox.SelectedItem = _field.TextQuadding;
                multilineCheckBox.Checked = _field.IsMultiline;
                passwordCheckBox.Checked = _field.IsPassword;
                spellCheckCheckBox.Checked = !_field.IsDoNotSpellCheck;

                UpdateActionEditorControl();
            }

            valueTextBox.Text = value;
            defaultValueTextBox.Text = defaultValue;
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the CheckedChanged event of multilineCheckBox object.
        /// </summary>
        private void multilineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if field multiline is change
            if (_field.IsMultiline != multilineCheckBox.Checked)
            {
                // if text must be single line
                if (!multilineCheckBox.Checked)
                {
                    // if text is not empty
                    if (!string.IsNullOrEmpty(valueTextBox.Text))
                        // get first line
                        valueTextBox.Text = valueTextBox.Lines[0];

                    // if text is not empty
                    if (!string.IsNullOrEmpty(defaultValueTextBox.Text))
                        // get first line
                        defaultValueTextBox.Text = defaultValueTextBox.Lines[0];
                }

                // if field must be multiline
                if (multilineCheckBox.Checked)
                    _field.IsMultiline = true;
                else
                    _field.IsMultiline = false;

                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of passwordCheckBox object.
        /// </summary>
        private void passwordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if field password is changed
            if (_field.IsPassword != passwordCheckBox.Checked)
            {
                // if field contains the password
                if (passwordCheckBox.Checked)
                    _field.IsPassword = true;
                else
                    _field.IsPassword = false;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of spellCheckCheckBox object.
        /// </summary>
        private void spellCheckCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isNotSpellChecked = !spellCheckCheckBox.Checked;
            // if spell check is changed
            if (_field.IsDoNotSpellCheck != isNotSpellChecked)
            {
                // if field spell check is disabled
                if (isNotSpellChecked)
                    _field.IsDoNotSpellCheck = true;
                else
                    _field.IsDoNotSpellCheck = false;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of valueTextBox object.
        /// </summary>
        private void valueTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = RemoveControlSybmols(valueTextBox.Text);
            // if field value is changed
            if (value != _field.TextValue)
            {
                // update field value
                _field.TextValue = value;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of defaultValueTextBox object.
        /// </summary>
        private void defaultValueTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = RemoveControlSybmols(defaultValueTextBox.Text);
            // if field default value is changed
            if (value != _field.TextDefaultValue)
            {
                // update default field value
                _field.TextDefaultValue = value;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the KeyDown event of textBox object.
        /// </summary>
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            // if enter key down
            if (!_field.IsMultiline && e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of textQuaddingComboBox object.
        /// </summary>
        private void textQuaddingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextQuaddingType textQuadding = (TextQuaddingType)textQuaddingComboBox.SelectedItem;
            // if text quadding is changed
            if (_field.TextQuadding != textQuadding)
            {
                // update text quadding
                _field.TextQuadding = textQuadding;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of actionsTabControl object.
        /// </summary>
        private void actionsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if value tab page is selected
            if (actionsTabControl.SelectedTab != valueTabPage)
                // update action editor control
                UpdateActionEditorControl();
        }

        /// <summary>
        /// Handles the ActionChanged event of calculatePdfActionEditorControl object.
        /// </summary>
        private void calculatePdfActionEditorControl_ActionChanged(object sender, EventArgs e)
        {
            PdfJavaScriptAction jsAction = calculatePdfActionEditorControl.Action as PdfJavaScriptAction;
            // if selected action is not JavaScript action
            if (calculatePdfActionEditorControl.Action != null && jsAction == null)
            {
                // show error message

                string message = "Calculate action of form field is not derived from PdfJavaScriptAction.";
                calculatePdfActionEditorControl.Action = null;
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // update calculate action
                _field.AdditionalActions.Calculate = jsAction;
            }
        }

        /// <summary>
        /// Handles the ActionChanged event of validatePdfActionEditorControl object.
        /// </summary>
        private void validatePdfActionEditorControl_ActionChanged(object sender, EventArgs e)
        {
            PdfJavaScriptAction jsAction = validatePdfActionEditorControl.Action as PdfJavaScriptAction;
            // if selected action is not JavaScript action
            if (validatePdfActionEditorControl.Action != null && jsAction == null)
            {
                // show error message

                string message = "Validate action of form field is not derived from PdfJavaScriptAction.";
                validatePdfActionEditorControl.Action = null;
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // update validate action
                _field.AdditionalActions.Validate = jsAction;
            }
        }

        /// <summary>
        /// Handles the ActionChanged event of formatPdfActionEditorControl object.
        /// </summary>
        private void formatPdfActionEditorControl_ActionChanged(object sender, EventArgs e)
        {
            PdfJavaScriptAction jsAction = formatPdfActionEditorControl.Action as PdfJavaScriptAction;
            // if selected action is not JavaScript action
            if (formatPdfActionEditorControl.Action != null && jsAction == null)
            {
                // show error message

                string message = "The Format action of form field is not derived from PdfJavaScriptAction.";
                formatPdfActionEditorControl.Action = null;
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // update format action
                _field.AdditionalActions.Format = jsAction;
            }
        }

        /// <summary>
        /// Handles the ActionChanged event of keystrokePdfActionEditorControl object.
        /// </summary>
        private void keystrokePdfActionEditorControl_ActionChanged(object sender, EventArgs e)
        {
            PdfJavaScriptAction jsAction = keystrokePdfActionEditorControl.Action as PdfJavaScriptAction;
            // if selected action is not JavaScript action
            if (keystrokePdfActionEditorControl.Action != null && jsAction == null)
            {
                // show error message

                string message = "The Keystroke action of form field is not derived from PdfJavaScriptAction.";
                keystrokePdfActionEditorControl.Action = null;
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // update keystroke action
                _field.AdditionalActions.Keystroke = jsAction;
            }
        }

        #endregion


        /// <summary>
        /// Adds the '\r' symbol to a string.
        /// </summary>
        /// <param name="str">The source string.</param>
        /// <returns>String with '\r' symbol.</returns>
        private static string AddControlSymbols(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            string result = str.Replace("\r", "");
            result = result.Replace("\n", "\r\n");
            return result;
        }

        /// <summary>
        /// Removes the '\r' symbol from a string.
        /// </summary>
        /// <param name="str">The source string.</param>
        /// <returns>String without '\r' symbol.</returns>
        private static string RemoveControlSybmols(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            string result = str.Replace("\r", "");
            return result;
        }

        /// <summary>
        /// Updates the action editor control.
        /// </summary>
        private void UpdateActionEditorControl()
        {
            if (_field.AdditionalActions == null)
                _field.AdditionalActions = new PdfInteractiveFormFieldAdditionalActions(_field.Document);

            if (actionsTabControl.SelectedTab == calculateActionTabPage)
                calculatePdfActionEditorControl.Action = _field.AdditionalActions.Calculate;
            else if (actionsTabControl.SelectedTab == validateActionTabPage)
                validatePdfActionEditorControl.Action = _field.AdditionalActions.Validate;
            else if (actionsTabControl.SelectedTab == formatActionTabPage)
                formatPdfActionEditorControl.Action = _field.AdditionalActions.Format;
            else if (actionsTabControl.SelectedTab == keystrokeActionTabPage)
                keystrokePdfActionEditorControl.Action = _field.AdditionalActions.Keystroke;
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
