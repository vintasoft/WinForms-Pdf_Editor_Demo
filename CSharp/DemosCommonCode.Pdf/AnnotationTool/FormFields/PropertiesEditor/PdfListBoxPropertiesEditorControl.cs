using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of
    /// the <see cref="PdfInteractiveFormListBoxField"/>.
    /// </summary>
    public partial class PdfListBoxPropertiesEditorControl : UserControl, IPdfInteractiveFormPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfListBoxPropertiesEditorControl"/> class.
        /// </summary>
        public PdfListBoxPropertiesEditorControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        PdfInteractiveFormListBoxField _field = null;
        /// <summary>
        /// Gets or sets the <see cref="PdfInteractiveFormListBoxField"/>.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public PdfInteractiveFormListBoxField Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;

                if (_field != null)
                    mainPanel.Enabled = true;
                else
                    mainPanel.Enabled = false;

                pdfInteractiveFormChoiceFieldEditorControl.Field = _field;

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
                Field = value as PdfInteractiveFormListBoxField;
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
            if (_field == null)
                return;

            multiselectCheckBox.Checked = _field.IsMultiSelect;
            PdfBrush selectionBrush = _field.SelectionBrush;
            if (selectionBrush == null)
                selectionBrushColorPanelControl.Color = Color.Transparent;
            else
                selectionBrushColorPanelControl.Color = selectionBrush.Color;
            pdfInteractiveFormChoiceFieldEditorControl.UpdateFieldInfo();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the CheckedChanged event of multiselectCheckBox object.
        /// </summary>
        private void multiselectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // update IsMultiSelect property
            _field.IsMultiSelect = multiselectCheckBox.Checked;

            // if only one item can be selected
            if (!_field.IsMultiSelect)
            {
                // if multiple items are selected
                if (_field.FieldValue is string[])
                {
                    // get selected items
                    string[] fieldValue = (string[])_field.FieldValue;
                    // if more than 1 item is selected
                    if (fieldValue.Length > 1)
                        // set the field value to the first selected item
                        _field.FieldValue = fieldValue[0];
                }

                // if multiple default items are selected
                if (_field.FieldDefaultValue is string[])
                {
                    // get selected default items
                    string[] fieldDefaultValue = (string[])_field.FieldDefaultValue;
                    // if more than 1 default item is selected
                    if (fieldDefaultValue.Length > 1)
                        // set the field default value to the first selected default item
                        _field.FieldDefaultValue = fieldDefaultValue[0];
                }
            }

            // update the field information
            pdfInteractiveFormChoiceFieldEditorControl.UpdateFieldInfo();
        }
        
        /// <summary>
        /// Handles the ColorChanged event of selectionBrushColorPanelControl object.
        /// </summary>
        private void selectionBrushColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            // update field selection brush
            _field.SelectionBrush = new PdfBrush(selectionBrushColorPanelControl.Color);
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of pdfInteractiveFormChoiceFieldEditorControl object.
        /// </summary>
        private void pdfInteractiveFormChoiceFieldEditorControl_PropertyValueChanged(object sender, EventArgs e)
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
        /// Occurs when the value of the field property is changed.
        /// </summary>
        public event EventHandler PropertyValueChanged;

        #endregion

    }
}
