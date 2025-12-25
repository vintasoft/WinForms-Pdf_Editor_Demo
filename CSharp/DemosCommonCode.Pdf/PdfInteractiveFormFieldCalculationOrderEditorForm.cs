using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A form that allows to change the calculation order of PDF interactive form.
    /// </summary>
    public partial class PdfInteractiveFormFieldCalculationOrderEditorForm : Form
    {

        #region Nested classes

        /// <summary>
        /// List box item.
        /// </summary>
        class ListBoxItem
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="ListBoxItem"/> class.
            /// </summary>
            /// <param name="field">The field.</param>
            public ListBoxItem(PdfInteractiveFormField field)
            {
                Field = field;
            }


            PdfInteractiveFormField _field = null;
            /// <summary>
            /// Gets or sets the field.
            /// </summary>
            public PdfInteractiveFormField Field
            {
                get
                {
                    return _field;
                }
                set
                {
                    _field = value;
                }
            }



            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return Field.FullyQualifiedName;
            }

        }

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfInteractiveFormFieldCalculationOrderEditorForm"/> class.
        /// </summary>
        public PdfInteractiveFormFieldCalculationOrderEditorForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        PdfDocumentInteractiveForm _interactiveForm = null;
        /// <summary>
        /// Gets or sets the PDF document interactive form.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PdfDocumentInteractiveForm InteractiveForm
        {
            get
            {
                return _interactiveForm;
            }
            set
            {
                _interactiveForm = value;

                // if interactive form is NOT empty
                if (_interactiveForm != null)
                {
                    // a list of fields with "Calculate" action
                    List<PdfInteractiveFormField> fieldsWithCalculateAction = new List<PdfInteractiveFormField>();

                    // if form has calculation order
                    if (_interactiveForm.CalculationOrder != null)
                    {
                        // for each field in caculation order
                        foreach (PdfInteractiveFormField formField in _interactiveForm.CalculationOrder)
                        {
                            // if field has the "Calculate" action
                            if (formField.IsCalculated)
                            {
                                // add field to a form list box
                                interactiveFormListBox.Items.Add(new ListBoxItem(formField));
                                // add field to a list of fields with "Calculate" action
                                fieldsWithCalculateAction.Add(formField);
                            }
                        }
                    }

                    // get all interactive form fields of interactive form
                    PdfInteractiveFormField[] interactiveFormFields = _interactiveForm.GetFields();
                    // for each field
                    foreach (PdfInteractiveFormField formField in interactiveFormFields)
                    {
                        // if field has "Calculate" action
                        if (formField.IsCalculated)
                        {
                            // if list of fields with "Calculate" action does NOT contain field
                            if (!fieldsWithCalculateAction.Contains(formField))
                                // add field to a form list box
                                interactiveFormListBox.Items.Add(new ListBoxItem(formField));
                        }
                    }
                }

                UpdateUI();
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Updates the user interface of this control.
        /// </summary>
        private void UpdateUI()
        {
            int selectedIndex = interactiveFormListBox.SelectedIndex;

            moveDownButton.Enabled = selectedIndex != -1 && selectedIndex != interactiveFormListBox.Items.Count - 1;
            moveUpButton.Enabled = selectedIndex != -1 && selectedIndex > 0;
            okButton.Enabled = _interactiveForm != null;
        }

        /// <summary>
        /// "Ok" button is clicked.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (interactiveFormListBox.Items.Count == 0 &&
                _interactiveForm.CalculationOrder == null)
                return;

            if (_interactiveForm.CalculationOrder == null)
                _interactiveForm.CalculationOrder = new PdfInteractiveFormFieldList(_interactiveForm.Document);
            else
                _interactiveForm.CalculationOrder.Clear();

            PdfInteractiveFormFieldList list = _interactiveForm.CalculationOrder;

            foreach (ListBoxItem item in interactiveFormListBox.Items)
                list.Add(item.Field);
        }

        /// <summary>
        /// PDF interactive field is moved up.
        /// </summary>
        private void moveUpButton_Click(object sender, EventArgs e)
        {
            MoveSelected(true);
        }

        /// <summary>
        /// PDF interactive field is moved down.
        /// </summary>
        private void moveDownButton_Click(object sender, EventArgs e)
        {
            MoveSelected(false);
        }

        /// <summary>
        /// Current interactive field is changed.
        /// </summary>
        private void interactiveFormListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Moves the selected interactive field in list box.
        /// </summary>
        /// <param name="moveUp">Determines that interactive field must be moved up.</param>
        private void MoveSelected(bool moveUp)
        {
            // get selected index
            int index = interactiveFormListBox.SelectedIndex;

            // if interactive field is move up
            if (moveUp)
                index--;
            else
                index++;

            // get selected item
            object item = interactiveFormListBox.SelectedItem;
            // remove selected item
            interactiveFormListBox.Items.Remove(item);
            // insert selected item
            interactiveFormListBox.Items.Insert(index, item);
            // set selected item
            interactiveFormListBox.SelectedItem = item;
        }

        #endregion

    }
}
