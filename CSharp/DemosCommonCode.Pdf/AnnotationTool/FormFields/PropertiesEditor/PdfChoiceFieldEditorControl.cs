using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit the <see cref="PdfInteractiveFormChoiceField"/>.
    /// </summary>
    [System.ComponentModel.DefaultEvent("PropertyValueChanged")]
    public partial class PdfChoiceFieldEditorControl : UserControl, IPdfInteractiveFormPropertiesEditor
    {

        #region Constants

        /// <summary>
        /// The array separator.
        /// </summary>
        const char ARRAY_SEPARATOR = ';';

        #endregion



        #region Fields

        /// <summary>
        /// A value indicating whether the item is moving.
        /// </summary>
        bool _isItemMoving = false;

        /// <summary>
        /// A value indicating whether that field with displayed value must to be copied to a field with exported value.
        /// </summary>
        bool _copyDisplayedValue = true;

        /// <summary>
        /// A value indicating whether the item is changing.
        /// </summary>
        bool _isDisplayedValueChanging = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance
        /// of the <see cref="PdfChoiceFieldEditorControl"/> class.
        /// </summary>
        public PdfChoiceFieldEditorControl()
        {
            InitializeComponent();

            foreach (TextQuaddingType quaddingType in Enum.GetValues(typeof(TextQuaddingType)))
                textQuaddingComboBox.Items.Add(quaddingType);
        }

        #endregion



        #region Properties

        PdfInteractiveFormChoiceField _field = null;
        /// <summary>
        /// Gets or sets the form choice fields items.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public PdfInteractiveFormChoiceField Field
        {
            get
            {
                return _field;
            }
            set
            {
                if (_field != null)
                    _field.Items.Changed -= new CollectionChangeEventHandler<PdfInteractiveFormChoiceFieldItem>(Items_Changed);

                _field = value;

                mainPanel.Enabled = _field != null;
                displayedValueTextBox.Text = string.Empty;

                itemsListBox.BeginUpdate();
                itemsListBox.Items.Clear();

                if (_field == null)
                {
                    valueComboBox.Text = string.Empty;
                    defaultValueComboBox.Text = string.Empty;
                }
                else
                {
                    UpdateItemsListBox();

                    UpdateFieldInfo();

                    _field.Items.Changed += new CollectionChangeEventHandler<PdfInteractiveFormChoiceFieldItem>(Items_Changed);
                }

                itemsListBox.EndUpdate();

                UpdateUI();
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
                Field = value as PdfInteractiveFormChoiceField;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates value and default value of the <see cref="PdfInteractiveFormComboBoxField"/>.
        /// </summary>
        public void UpdateFieldInfo()
        {
            ComboBoxStyle dropDownStyle = ComboBoxStyle.DropDown;
            if (_field is PdfInteractiveFormListBoxField)
            {
                if (!((PdfInteractiveFormListBoxField)_field).IsMultiSelect)
                    dropDownStyle = ComboBoxStyle.DropDownList;
            }

            valueComboBox.DropDownStyle = dropDownStyle;
            UpdateItemsComboBox(valueComboBox, _field);
            UpdateTextComboBox(valueComboBox, _field.FieldValue);

            defaultValueComboBox.DropDownStyle = dropDownStyle;
            UpdateItemsComboBox(defaultValueComboBox, _field);
            UpdateTextComboBox(defaultValueComboBox, _field.FieldDefaultValue);

            textQuaddingComboBox.SelectedItem = _field.TextQuadding;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            bool isItemSelected = itemsListBox.SelectedIndex != -1;
            bool isFirstItemSelected = itemsListBox.SelectedIndex == 0;
            bool isLastItemSelected = itemsListBox.SelectedIndex == itemsListBox.Items.Count - 1;
            bool canAddItem = false;
            if (!string.IsNullOrEmpty(exportedValueTextBox.Text) &&
                !string.IsNullOrEmpty(displayedValueTextBox.Text))
                canAddItem = FindItem(_field, exportedValueTextBox.Text) == null;
            else
                canAddItem = false;

            addButton.Enabled = canAddItem;
            moveUpButton.Enabled = isItemSelected && !isFirstItemSelected;
            moveDownButton.Enabled = isItemSelected && !isLastItemSelected;
            deleteButton.Enabled = isItemSelected;
        }


        #region UI

        /// <summary>
        /// Handles the SelectedIndexChanged event of textQuaddingComboBox object.
        /// </summary>
        private void textQuaddingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get text quadding
            TextQuaddingType textQuadding = (TextQuaddingType)textQuaddingComboBox.SelectedItem;
            // if text quadding is changed
            if (_field.TextQuadding != textQuadding)
            {
                // update text quadding
                _field.TextQuadding = textQuadding;
                OnPropertyValueChanged();
            }
        }


        #region Value

        /// <summary>
        /// Handles the SelectedIndexChanged event of valueComboBox object.
        /// </summary>
        private void valueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if list box field is selected
            if (_field is PdfInteractiveFormListBoxField)
                UpdateListBoxFieldValue((PdfInteractiveFormListBoxField)_field, valueComboBox.Text);
            else
                // update field value
                _field.FieldValue = valueComboBox.SelectedItem;
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the TextUpdate event of valueComboBox object.
        /// </summary>
        private void valueComboBox_TextUpdate(object sender, EventArgs e)
        {
            // if list box field is selected
            if (_field is PdfInteractiveFormListBoxField)
                UpdateListBoxFieldValue((PdfInteractiveFormListBoxField)_field, valueComboBox.Text);
            else
                // update field value
                _field.FieldValue = valueComboBox.Text;
            OnPropertyValueChanged();
        }

        #endregion


        #region Default Value

        /// <summary>
        /// Handles the SelectedIndexChanged event of defaultValueComboBox object.
        /// </summary>
        private void defaultValueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update field default value
            _field.FieldDefaultValue = defaultValueComboBox.SelectedItem;
            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the TextUpdate event of defaultValueComboBox object.
        /// </summary>
        private void defaultValueComboBox_TextUpdate(object sender, EventArgs e)
        {
            // if list box field is selected
            if (_field is PdfInteractiveFormListBoxField)
            {
                string[] result = null;
                try
                {
                    // create array from string
                    result = CreateArrayFromString(defaultValueComboBox.Text);
                    // remove invalid items
                    result = RemoveInvalidItems(result, _field.Items);
                }
                catch
                {
                    return;
                }
                // update default value
                _field.FieldDefaultValue = result;
            }
            else
            {
                // update default value
                _field.FieldDefaultValue = defaultValueComboBox.Text;
            }
            OnPropertyValueChanged();
        }

        #endregion


        #region Items

        /// <summary>
        /// Handles the SelectedIndexChanged event of itemsListBox object.
        /// </summary>
        private void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get selected index
            int selectedIndex = itemsListBox.SelectedIndex;

            // displayed value
            string displayedValue = string.Empty;
            // exported value
            string exportedValue = string.Empty;

            // if item is selected
            if (selectedIndex != -1)
            {
                // get item
                PdfInteractiveFormChoiceFieldItem item = _field.Items[selectedIndex];

                displayedValue = item.DisplayedValue;
                exportedValue = displayedValue;

                // get field extended item
                PdfInteractiveFormChoiceFieldExtendedItem extendedItem =
                    item as PdfInteractiveFormChoiceFieldExtendedItem;
                if (extendedItem != null)
                    // get exported value
                    exportedValue = extendedItem.ExportedValue;

                // update displayed value
                displayedValueTextBox.Text = displayedValue;
                // update exported value
                exportedValueTextBox.Text = exportedValue;

            }

            // if displayed value must be copied
            if (displayedValue == exportedValue)
                _copyDisplayedValue = true;
            else
                _copyDisplayedValue = false;

            UpdateUI();
        }

        /// <summary>
        /// Handles the Changed event of Items object.
        /// </summary>
        void Items_Changed(
            object sender,
            CollectionChangeEventArgs<PdfInteractiveFormChoiceFieldItem> e)
        {
            // if item is not moving
            if (!_isItemMoving)
            {
                // update list box items
                UpdateItemsListBox();

                // update combo box items
                UpdateItemsComboBox(valueComboBox, _field);
                // update combo box text
                UpdateTextComboBox(valueComboBox, _field.FieldValue);

                // update combo box items
                UpdateItemsComboBox(defaultValueComboBox, _field);
                // update combo box text
                UpdateTextComboBox(defaultValueComboBox, _field.FieldDefaultValue);
            }
        }

        /// <summary>
        /// Handles the TextChanged event of diplayedValueTextBox object.
        /// </summary>
        private void diplayedValueTextBox_TextChanged(object sender, EventArgs e)
        {
            _isDisplayedValueChanging = true;
            try
            {
                // if the displayed value must be copied
                if (_copyDisplayedValue)
                    // copy displayed value
                    exportedValueTextBox.Text = displayedValueTextBox.Text;

                UpdateUI();
            }
            finally
            {
                _isDisplayedValueChanging = false;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of exportedValueTextBox object.
        /// </summary>
        private void exportedValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_isDisplayedValueChanging)
                return;

            // if displayed value must be copied
            if (displayedValueTextBox.Text == exportedValueTextBox.Text)
                _copyDisplayedValue = true;
            else
                _copyDisplayedValue = false;

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of addButton object.
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // get displayed value
                string displayedValue = displayedValueTextBox.Text;
                // get exported value
                string exportedValue = exportedValueTextBox.Text;

                PdfInteractiveFormChoiceFieldItem item = null;
                // if displayed and exported value is not equal
                if (displayedValue != exportedValue)
                    item = new PdfInteractiveFormChoiceFieldExtendedItem(_field.Document, exportedValue, displayedValue);
                else
                    item = new PdfInteractiveFormChoiceFieldItem(_field.Document, displayedValue);

                // add new item to current field
                _field.Items.Add(item);
                // update selected item
                itemsListBox.SelectedIndex = _field.Items.Count - 1;
                // raise proerty value changed event
                OnPropertyValueChanged();

                // update focus
                displayedValueTextBox.Focus();
                // update selection
                displayedValueTextBox.SelectAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of deleteButton object.
        /// </summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // get selected index
            int index = itemsListBox.SelectedIndex;

            // get selected item index after remove
            int selectedIndex = index;
            // if last item is selected
            if (selectedIndex == itemsListBox.Items.Count - 1)
                selectedIndex -= 1;

            // if list box field is selected
            if (_field is PdfInteractiveFormListBoxField)
            {
                PdfInteractiveFormListBoxField listBoxField = (PdfInteractiveFormListBoxField)_field;
                // if list box field contains selected items
                if (listBoxField.SelectedItemIndexes != null)
                {

                    // remove current selected item from list box selected items

                    List<int> selectedItemIndexes = new List<int>(listBoxField.SelectedItemIndexes);
                    if (selectedItemIndexes.Contains(index))
                        selectedItemIndexes.Remove(index);

                    for (int i = 0; i < selectedItemIndexes.Count; i++)
                        if (selectedItemIndexes[i] > index)
                            selectedItemIndexes[i] -= 1;

                    listBoxField.SelectedItemIndexes = selectedItemIndexes.ToArray();
                }
            }

            // remove selected item
            _field.Items.RemoveAt(index);

            // update displayed value
            displayedValueTextBox.Text = string.Empty;
            // update selected index
            itemsListBox.SelectedIndex = selectedIndex;
            // update user interface
            UpdateUI();

            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the Click event of moveUpButton object.
        /// </summary>
        private void moveUpButton_Click(object sender, EventArgs e)
        {
            // move the selected item up
            MoveSelectedItem(true);

            OnPropertyValueChanged();
        }

        /// <summary>
        /// Handles the Click event of moveDownButton object.
        /// </summary>
        private void moveDownButton_Click(object sender, EventArgs e)
        {
            // move the selected item down
            MoveSelectedItem(false);

            OnPropertyValueChanged();
        }

        #endregion

        #endregion


        #region Value

        /// <summary>
        /// Updates value of the ListBox.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        private void UpdateListBoxFieldValue(PdfInteractiveFormListBoxField field, string value)
        {
            string[] result = null;
            try
            {
                result = CreateArrayFromString(value);
                result = RemoveInvalidItems(result, field.Items);
            }
            catch
            {
                return;
            }
            field.FieldValue = result;
        }

        #endregion


        #region Items

        /// <summary>
        /// Finds the specified displayed value in item collection.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="displayedValue">The displayed value of item.</param>
        /// <returns>
        /// Reference to the item if item is found in the collection;
        /// otherwise, <b>null</b>.
        /// </returns>
        private PdfInteractiveFormChoiceFieldItem FindItem(
            PdfInteractiveFormChoiceField field,
            string displayedValue)
        {
            foreach (PdfInteractiveFormChoiceFieldItem item in _field.Items)
            {
                if (item is PdfInteractiveFormChoiceFieldExtendedItem)
                {
                    PdfInteractiveFormChoiceFieldExtendedItem extendedItem =
                        (PdfInteractiveFormChoiceFieldExtendedItem)item;
                    if (extendedItem.ExportedValue == displayedValue)
                        return item;
                }
                else if (item.DisplayedValue == displayedValue)
                    return item;
            }
            return null;
        }

        /// <summary>
        /// Updates the items in list box.
        /// </summary>
        private void UpdateItemsListBox()
        {
            itemsListBox.BeginUpdate();
            itemsListBox.Items.Clear();

            foreach (PdfInteractiveFormChoiceFieldItem item in _field.Items)
                itemsListBox.Items.Add(item.DisplayedValue);

            itemsListBox.EndUpdate();
        }

        /// <summary>
        /// Moves the selected item.
        /// </summary>
        /// <param name="moveUp">Indicates that the selected item must be moved up.</param>
        private void MoveSelectedItem(bool moveUp)
        {
            _isItemMoving = true;
            try
            {
                // get current selected item index
                int selectedItemIndex = itemsListBox.SelectedIndex;
                // get current selected item
                PdfInteractiveFormChoiceFieldItem selectedItem = _field.Items[selectedItemIndex];

                // new item index
                int newIndex = selectedItemIndex;
                // if index should be increased
                if (moveUp)
                {
                    if (selectedItemIndex == 0)
                        return;

                    newIndex = selectedItemIndex - 1;
                }
                // if index should be reduced
                else
                {
                    if (selectedItemIndex == _field.Items.Count - 1)
                        return;

                    newIndex = selectedItemIndex + 1;
                }

                // remove selected item
                _field.Items.Remove(selectedItem);
                // add selected item to new position
                _field.Items.Insert(newIndex, selectedItem);

                // if moved the list box interactive form field
                if (_field is PdfInteractiveFormListBoxField)
                {
                    PdfInteractiveFormListBoxField listBoxField = (PdfInteractiveFormListBoxField)_field;


                    // updates the selected items

                    int[] selectedItemIndexes = listBoxField.SelectedItemIndexes;
                    if (selectedItemIndexes != null)
                    {
                        bool selectedItemIndexesChanged = false;
                        for (int i = 0; i < selectedItemIndexes.Length; i++)
                        {
                            if (selectedItemIndexes[i] == selectedItemIndex)
                            {
                                selectedItemIndexes[i] = newIndex;
                                selectedItemIndexesChanged = true;
                            }
                            else if (selectedItemIndexes[i] == newIndex)
                            {
                                selectedItemIndexes[i] = selectedItemIndex;
                                selectedItemIndexesChanged = true;
                            }
                        }

                        if (selectedItemIndexesChanged)
                            listBoxField.SelectedItemIndexes = selectedItemIndexes;
                    }
                }


                // updates the user interface

                UpdateItemsListBox();

                UpdateItemsComboBox(valueComboBox, _field);
                UpdateTextComboBox(valueComboBox, _field.FieldValue);

                UpdateItemsComboBox(defaultValueComboBox, _field);
                UpdateTextComboBox(defaultValueComboBox, _field.FieldDefaultValue);

                itemsListBox.SelectedIndex = newIndex;
            }
            finally
            {
                _isItemMoving = false;
            }
        }

        #endregion


        #region Common

        /// <summary>
        /// Updates the items of combo box.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="field">The field.</param>
        private void UpdateItemsComboBox(ComboBox comboBox,
            PdfInteractiveFormChoiceField field)
        {
            comboBox.BeginUpdate();

            comboBox.Items.Clear();

            if ((field is PdfInteractiveFormListBoxField) &&
                ((PdfInteractiveFormListBoxField)_field).IsMultiSelect)
            {
                int count = Math.Min(2, field.Items.Count);

                string result = string.Empty;

                for (int i = 0; i < count; i++)
                    result += string.Format("\"{0}\"{1} ", field.Items[i].DisplayedValue, ARRAY_SEPARATOR);

                if (!string.IsNullOrEmpty(result))
                {
                    result = result.Trim();
                    result = result.TrimEnd(ARRAY_SEPARATOR);
                    comboBox.Items.Add(result);
                }
            }
            else
            {
                foreach (PdfInteractiveFormChoiceFieldItem item in field.Items)
                    comboBox.Items.Add(item.DisplayedValue);
            }

            comboBox.EndUpdate();
        }

        /// <summary>
        /// Updates the text of combo box.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="selectedItem">The selected item.</param>
        private void UpdateTextComboBox(ComboBox comboBox,
            object selectedItem)
        {
            string text = string.Empty;

            if (selectedItem != null)
            {
                if (_field is PdfInteractiveFormListBoxField)
                {
                    if (selectedItem is string[])
                        text = CreateStringFromArray((string[])selectedItem);
                    else
                        text = selectedItem.ToString();
                }
                else
                    text = selectedItem.ToString();
            }

            comboBox.Text = text;
        }

        /// <summary>
        /// Removes invalid items.
        /// </summary>
        /// <param name="items">An item array from which invalid values must be removed.</param>
        /// <param name="itemList">A list with "good" items.</param>
        private string[] RemoveInvalidItems(
            string[] items,
            PdfInteractiveFormChoiceFieldItemList itemList)
        {
            List<string> result = new List<string>();

            foreach (string sourceItem in items)
            {
                if (result.Contains(sourceItem))
                    continue;

                foreach (PdfInteractiveFormChoiceFieldItem item in itemList)
                {
                    if (sourceItem == item.DisplayedValue)
                    {
                        result.Add(sourceItem);
                        break;
                    }
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Creates the array from string.
        /// </summary>
        /// <param name="sourceStr">The source string.</param>
        private string[] CreateArrayFromString(string sourceStr)
        {
            if (string.IsNullOrEmpty(sourceStr))
                return new string[0];

            string[] splitedSourceStr = sourceStr.Split(
                new string[] { string.Format("{0} ", ARRAY_SEPARATOR) }, StringSplitOptions.None);

            for (int i = 0; i < splitedSourceStr.Length; i++)
            {
                string currentStr = splitedSourceStr[i];

                int startIndex = currentStr.IndexOf('\"') + 1;
                int endIndex = currentStr.LastIndexOf('\"');

                if (endIndex != -1)
                    splitedSourceStr[i] = currentStr.Substring(startIndex, endIndex - startIndex);
            }

            return splitedSourceStr;
        }

        /// <summary>
        /// Creates the string from array.
        /// </summary>
        /// <param name="sourceArray">The source array.</param>
        private string CreateStringFromArray(params string[] sourceArray)
        {
            string result = string.Empty;

            if (sourceArray != null && sourceArray.Length > 0)
            {
                foreach (string sourceItem in sourceArray)
                    result += string.Format("\"{0}\"{1} ", sourceItem, ARRAY_SEPARATOR);

                result = result.TrimEnd(' ');
                result = result.TrimEnd(ARRAY_SEPARATOR);
            }

            return result;
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

        #endregion



        #region Events

        /// <summary>
        /// Occurs when value of property is changed.
        /// </summary>
        public event EventHandler PropertyValueChanged;

        #endregion

    }
}
