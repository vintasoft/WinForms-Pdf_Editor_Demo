using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree;


namespace DemosCommonCode.Pdf.JavaScript
{
    /// <summary>
    /// A form that allows to edit the JavaScript of PDF document.
    /// </summary>
    public partial class PdfJavaScriptActionDictionaryEditorDialog : Form
    {

        #region Fields

        /// <summary>
        /// The dictionary (script name => script code) that
        /// contains information about new scripts.
        /// </summary>
        Dictionary<string, string> _javaScriptNameToJavaScriptCode =
            new Dictionary<string, string>();

        /// <summary>
        /// The dictionary (script object => script code) that
        /// contains information about existing scripts.
        /// </summary>
        Dictionary<PdfJavaScriptAction, string> _javaScriptActionToJavaScriptName =
            new Dictionary<PdfJavaScriptAction, string>();

        /// <summary>
        /// The dictionary (script object => script code) that
        /// contains information about modified existing scripts.
        /// </summary>
        Dictionary<PdfJavaScriptAction, string> _javaScriptActionToJavaScriptCode =
            new Dictionary<PdfJavaScriptAction, string>();

        /// <summary>
        /// The dictionary that contains JavaScript actions of PDF document.
        /// </summary>
        PdfJavaScriptActionDictionary _javaScriptActionDictionary = null;

        /// <summary>
        /// The name of selected JavaScript action.
        /// </summary>
        string _selectedJavaScriptActionName = null;

        /// <summary>
        /// Indicates that list box is changing.
        /// </summary>
        bool _isListBoxChanging = false;

        #endregion



        #region Constructor

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfJavaScriptActionDictionaryEditorDialog"/> class.
        /// </summary>
        /// <param name="javaScriptActionDictionary">The dictionary that contains
        /// JavaScript actions of PDF document.</param>
        public PdfJavaScriptActionDictionaryEditorDialog(
            PdfJavaScriptActionDictionary javaScriptActionDictionary)
        {
            if (javaScriptActionDictionary == null)
                throw new ArgumentNullException();

            InitializeComponent();

            _javaScriptActionDictionary = javaScriptActionDictionary;

            foreach (string key in javaScriptActionDictionary.Keys)
                if (javaScriptActionDictionary[key] != null)
                    _javaScriptActionToJavaScriptName.Add(javaScriptActionDictionary[key], key);

            // add all scripts to the list box

            javaScripActionsListBox.BeginUpdate();
            foreach (string key in javaScriptActionDictionary.Keys)
                javaScripActionsListBox.Items.Add(key);
            javaScripActionsListBox.SelectedIndex = -1;
            javaScripActionsListBox.EndUpdate();

            wordWrapCheckBox.Checked = javaScriptTextBox.WordWrap;

            UpdateUI();
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the SelectedIndexChanged event of JavaScripActionsListBox object.
        /// </summary>
        private void javaScripActionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if list box is changing
            if (_isListBoxChanging)
                return;

            // get selected item
            string selectedItem = javaScripActionsListBox.SelectedItem as string;

            // if selected item can not be updated
            if (selectedItem == _selectedJavaScriptActionName)
                return;

            // save selected JavaScript code
            SaveSelectedJavaScript();

            // update selected JavaScript
            _selectedJavaScriptActionName = selectedItem;

            // update text box
            javaScriptTextBox.Text = GetJavaScriptCode(_selectedJavaScriptActionName);
            // update UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // save selected JavaScript code
            SaveSelectedJavaScript();

            string[] keys = new string[_javaScriptActionDictionary.Count];
            _javaScriptActionDictionary.Keys.CopyTo(keys, 0);
            // for each actions in PDF document
            foreach (string key in keys)
            {
                // get action
                PdfJavaScriptAction action = _javaScriptActionDictionary[key];

                string javaScriptCode = string.Empty;
                // if action contains JavaScript
                if (_javaScriptActionToJavaScriptCode.TryGetValue(action, out javaScriptCode))
                    // update action JavaScript
                    action.JavaScript = javaScriptCode;

                string newKey = string.Empty;
                // if JavaScript action must be updated
                if (_javaScriptActionToJavaScriptName.TryGetValue(action, out newKey))
                {
                    if (!string.Equals(newKey, key, StringComparison.InvariantCulture))
                    {
                        // remove old JavaScript action key
                        _javaScriptActionDictionary.Remove(key);
                        // add new JavaScript action key
                        _javaScriptActionDictionary.Add(newKey, action);
                    }
                }
                else
                {
                    // remove JavaScript action
                    _javaScriptActionDictionary.Remove(key);
                }
            }

            // for each JavaScript key in new JavaScript keys dictionary
            foreach (string key in _javaScriptNameToJavaScriptCode.Keys)
            {
                // create action
                PdfJavaScriptAction action = new PdfJavaScriptAction(_javaScriptActionDictionary.Document);
                // update JavaScript code
                action.JavaScript = _javaScriptNameToJavaScriptCode[key];
                // add JavaScript action
                _javaScriptActionDictionary.Add(key, action);
            }
        }

        /// <summary>
        /// Handles the Click event of AddButton object.
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            string title = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_JAVASCRIPT_JAVASCRIPT_ACTION_NAME;
            string message = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_JAVASCRIPT_ENTER_NAME_OF_JAVASCRIPT_ACTION;

            // get JavaScript action names
            string[] javaScriptNames = GetJavaScriptActionNames();
            // create dialog
            using (PdfJavaScriptActionDictionaryRenameActionDialog dialog =
                new PdfJavaScriptActionDictionaryRenameActionDialog(title, message, javaScriptNames))
            {
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Owner = this;
                dialog.ActionName = string.Empty;

                // show dialog
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string actionName = dialog.ActionName;
                    _javaScriptNameToJavaScriptCode.Add(actionName, string.Empty);
                    // add action name to the list box
                    javaScripActionsListBox.Items.Add(actionName);
                    // set action name as focused in list box
                    javaScripActionsListBox.SelectedItem = actionName;
                    javaScriptTextBox.Focus();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of RenameButton object.
        /// </summary>
        private void renameButton_Click(object sender, EventArgs e)
        {
            string title = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_JAVASCRIPT_JAVASCRIPT_ACTION_NAME_ALT1;
            string message = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_JAVASCRIPT_ENTER_NAME_OF_JAVASCRIPT_ACTION_ALT1;

            // get JavaScript action names
            string[] javaScriptNames = GetJavaScriptActionNames();
            // create dialog
            using (PdfJavaScriptActionDictionaryRenameActionDialog dialog =
               new PdfJavaScriptActionDictionaryRenameActionDialog(title, message, javaScriptNames))
            {
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Owner = this;
                dialog.ActionName = _selectedJavaScriptActionName;

                // if JavaScript action name must be updated
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // get new JavaScript action name
                    string actionName = dialog.ActionName;

                    // find the JavaScript action
                    PdfJavaScriptAction action = GetActionByName(
                        _javaScriptActionToJavaScriptName,
                        _selectedJavaScriptActionName);
                    // if JavaScript action is found
                    if (action != null)
                    {
                        // update JavaScript action name
                        _javaScriptActionToJavaScriptName[action] = actionName;
                    }
                    else
                    {
                        // get JavaScript code
                        string javaScript = _javaScriptNameToJavaScriptCode[_selectedJavaScriptActionName];
                        // remove selected JavaScript action
                        _javaScriptNameToJavaScriptCode.Remove(_selectedJavaScriptActionName);
                        // add new JavaScript action
                        _javaScriptNameToJavaScriptCode.Add(actionName, javaScript);
                    }
                    _selectedJavaScriptActionName = actionName;


                    // update JavaScript actions list box

                    _isListBoxChanging = true;
                    javaScripActionsListBox.BeginUpdate();
                    javaScripActionsListBox.Items[javaScripActionsListBox.SelectedIndex] = actionName;
                    javaScripActionsListBox.SelectedItem = actionName;
                    javaScripActionsListBox.EndUpdate();
                    _isListBoxChanging = false;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of RemoveButton object.
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            // get name of selected action
            string selectedJavaScriptName = javaScripActionsListBox.SelectedItem.ToString();

            // get JavaScript action
            PdfJavaScriptAction action = GetActionByName(_javaScriptActionToJavaScriptName, selectedJavaScriptName);

            // if action is found
            if (action != null)
            {
                // remove exist JavaScript action

                _javaScriptActionToJavaScriptName.Remove(action);
                _javaScriptActionToJavaScriptCode.Remove(action);
            }
            else
            {
                // remove new JavaScript action

                _javaScriptNameToJavaScriptCode.Remove(selectedJavaScriptName);
            }

            // update JavaScript actions list box

            _selectedJavaScriptActionName = string.Empty;
            int selectedItemIndex = javaScripActionsListBox.SelectedIndex;
            javaScripActionsListBox.BeginUpdate();
            javaScripActionsListBox.Items.Remove(selectedJavaScriptName);
            if (selectedItemIndex >= javaScripActionsListBox.Items.Count)
                selectedItemIndex--;
            javaScripActionsListBox.SelectedIndex = selectedItemIndex;
            javaScripActionsListBox.EndUpdate();

            // update UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the CheckedChanged event of WordWrapCheckBox object.
        /// </summary>
        private void wordWrapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if word wrap must be enabled
            if (wordWrapCheckBox.Checked)
                javaScriptTextBox.WordWrap = true;
            else
                javaScriptTextBox.WordWrap = false;
        }

        #endregion


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            bool isSelectedJavaScript = javaScripActionsListBox.SelectedIndex != -1;

            renameButton.Enabled = isSelectedJavaScript;
            removeButton.Enabled = isSelectedJavaScript;

            javaScriptTextBox.Enabled = isSelectedJavaScript;
        }

        /// <summary>
        /// Saves the selected JavaScript code.
        /// </summary>
        private void SaveSelectedJavaScript()
        {
            if (string.IsNullOrEmpty(_selectedJavaScriptActionName))
                return;

            string javaScriptCode = javaScriptTextBox.Text;
            string previousJavaScriptCode = GetJavaScriptCode(_selectedJavaScriptActionName);

            if (!string.Equals(previousJavaScriptCode, javaScriptCode, StringComparison.InvariantCulture))
            {
                PdfJavaScriptAction action =
                    GetActionByName(_javaScriptActionToJavaScriptName, _selectedJavaScriptActionName);
                if (action != null)
                    _javaScriptActionToJavaScriptCode[action] = javaScriptCode;
                else
                    _javaScriptNameToJavaScriptCode[_selectedJavaScriptActionName] = javaScriptCode;
            }
        }

        /// <summary>
        /// Returns the JavaScript code.
        /// </summary>
        /// <param name="name">The name.</param>
        private string GetJavaScriptCode(string name)
        {
            string code = string.Empty;

            if (!string.IsNullOrEmpty(name) &&
                !_javaScriptNameToJavaScriptCode.TryGetValue(name, out code))
            {
                PdfJavaScriptAction action = GetActionByName(_javaScriptActionToJavaScriptName, name);
                if (action!=null && !_javaScriptActionToJavaScriptCode.TryGetValue(action, out code))
                    code = PreprocessJavaScriptCode(action.JavaScript);
            }

            return code;
        }

        /// <summary>
        /// Returns the names of all JavaScripts.
        /// </summary>
        private string[] GetJavaScriptActionNames()
        {
            int count = _javaScriptActionToJavaScriptName.Count +
                _javaScriptNameToJavaScriptCode.Count;
            string[] names = new string[count];

            _javaScriptActionToJavaScriptName.Values.CopyTo(names, 0);
            _javaScriptNameToJavaScriptCode.Keys.CopyTo(names, _javaScriptActionToJavaScriptName.Count);

            return names;
        }

        /// <summary>
        /// Preprocesses the JavaScript code.
        /// </summary>
        /// <param name="jsCode">The JavaScript code.</param>
        /// <returns>Preprocessed JavaScript code.</returns>
        private string PreprocessJavaScriptCode(string jsCode)
        {
            jsCode = jsCode.Replace("\r\n", "\n");
            jsCode = jsCode.Replace("\r", "\n");
            jsCode = jsCode.Replace("\n", "\r\n");
            return jsCode;
        }

        /// <summary>
        /// Returns the action by the action name.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <param name="actionName">The action name.</param>
        /// <returns>The action.</returns>
        private PdfJavaScriptAction GetActionByName(
            Dictionary<PdfJavaScriptAction, string> dict,
            string actionName)
        {
            foreach (PdfJavaScriptAction action in dict.Keys)
            {
                if (dict[action] == actionName)
                    return action;
            }

            return null;
        }

        #endregion

    }
}
