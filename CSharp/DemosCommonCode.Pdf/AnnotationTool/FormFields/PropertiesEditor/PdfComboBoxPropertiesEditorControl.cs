using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of the <see cref="PdfInteractiveFormComboBoxField"/>.
    /// </summary>
    public partial class PdfComboBoxPropertiesEditorControl : UserControl, IPdfInteractiveFormPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfComboBoxPropertiesEditorControl"/> class.
        /// </summary>
        public PdfComboBoxPropertiesEditorControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        PdfInteractiveFormComboBoxField _field = null;
        /// <summary>
        /// Gets or sets the <see cref="PdfInteractiveFormComboBoxField"/>.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PdfInteractiveFormComboBoxField Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;
                mainPanel.Enabled = _field != null;
                pdfInteractiveFormChoiceFieldEditorControl.Field = _field;

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

                    editableCheckBox.Checked = _field.IsEdit;
                    spellCheckCheckBox.Checked = !_field.IsDoNotSpellCheck;
                }
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
                Field = value as PdfInteractiveFormComboBoxField;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the CheckedChanged event of editableCheckBox object.
        /// </summary>
        private void editableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if field edit value is changed
            if (_field.IsEdit != editableCheckBox.Checked)
            {
                // if field text can be edited
                if (editableCheckBox.Checked)
                    _field.IsEdit = true;
                else
                    _field.IsEdit = false;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of spellCheckCheckBox object.
        /// </summary>
        private void spellCheckCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isNotSpellChecked = !spellCheckCheckBox.Checked;
            // if field spell check value is changed
            if (_field.IsDoNotSpellCheck != isNotSpellChecked)
            {
                // if field spell check must be disabled
                if (isNotSpellChecked)
                    _field.IsDoNotSpellCheck = true;
                else
                    _field.IsDoNotSpellCheck = false;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of pdfInteractiveFormChoiceFieldEditorControl object.
        /// </summary>
        private void pdfInteractiveFormChoiceFieldEditorControl_PropertyValueChanged(object sender, EventArgs e)
        {
            // raise property valie changed event
            OnPropertyValueChanged();
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
                // update field calculate action
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
                // update field validate action
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
                // update field validate action
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
                // update field validate action
                _field.AdditionalActions.Keystroke = jsAction;
            }
        }

        #endregion


        /// <summary>
        /// Updates the field information.
        /// </summary>
        public void UpdateFieldInfo()
        {
            editableCheckBox.Checked = _field.IsEdit;
            pdfInteractiveFormChoiceFieldEditorControl.UpdateFieldInfo();

            UpdateActionEditorControl();
        }

        /// <summary>
        /// Raises the PropertyValueChanged event.
        /// </summary>
        private void OnPropertyValueChanged()
        {
            if (PropertyValueChanged != null)
                PropertyValueChanged(this, EventArgs.Empty);
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

        #endregion



        #region Events

        /// <summary>
        /// Occurs when the property value is changed.
        /// </summary>
        public event EventHandler PropertyValueChanged;

        #endregion

    }
}
