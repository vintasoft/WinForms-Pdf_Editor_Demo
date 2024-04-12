using System;
using System.Windows.Forms;

namespace DemosCommonCode.Pdf.JavaScript
{
    /// <summary>
    /// A form that allows to rename the JavaScript Action of PDF document.
    /// </summary>
    public partial class PdfJavaScriptActionDictionaryRenameActionDialog : Form
    {

        #region Fields

        /// <summary>
        /// An array of JavaScript action names.
        /// </summary>
        string[] _javaScriptActionNames = null;

        #endregion



        #region Constructor

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfJavaScriptActionDictionaryRenameActionDialog"/> class.
        /// </summary>
        /// <param name="title">The dialog title.</param>
        /// <param name="message">The dialog message.</param>
        /// <param name="javaScriptActionNames">An array
        /// that contains JavaScript action names of PDF document.</param>
        public PdfJavaScriptActionDictionaryRenameActionDialog(
            string title, string message, string[] javaScriptActionNames)
        {
            InitializeComponent();

            Text = title;
            messageLabel.Text = message;
            _javaScriptActionNames = javaScriptActionNames;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the name of the action.
        /// </summary>
        /// <value>
        /// The name of the action.
        /// </value>
        public string ActionName
        {
            get
            {
                return textBox.Text;
            }
            set
            {
                textBox.Text = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // get name of action
            string name = textBox.Text;
            name = name.Trim();

            // if name is empty
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_JAVASCRIPT_NAME_CAN_NOT_BE_EMPTY, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_JAVASCRIPT_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // search name in dictionary
            foreach (string key in _javaScriptActionNames)
            {
                // if JavaScript with specified name is exist
                if (String.Equals(key, name, StringComparison.InvariantCulture))
                {
                    string errorMessage = string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_JAVASCRIPT_PDF_DOCUMENT_ALREADY_CONTAINS_CTION_WITH_NAME_ARG0, name);
                    MessageBox.Show(errorMessage, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_JAVASCRIPT_ERROR_ALT1, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
