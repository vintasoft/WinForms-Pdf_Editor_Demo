using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;

namespace DemosCommonCode.Pdf.Security
{
    /// <summary>
    /// A form that allows to select signature field from list.
    /// </summary>
    public partial class SelectSignatureFieldForm : Form
    {

        #region Fields

        /// <summary>
        /// Array of signature fields.
        /// </summary>
        PdfInteractiveFormSignatureField[] _fields;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectSignatureFieldForm"/> class.
        /// </summary>
        public SelectSignatureFieldForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectSignatureFieldForm"/> class.
        /// </summary>
        /// <param name="fields">The signature fields.</param>
        public SelectSignatureFieldForm(PdfInteractiveFormSignatureField[] fields)
            : this()
        {
            _fields = fields;
            for (int i = 0; i < _fields.Length; i++)
                signaturesListBox.Items.Add(GetSignatureFieldFriendlyName(_fields[i]));
            signaturesListBox.SelectedIndex = 0;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the selected signature field.
        /// </summary>
        public PdfInteractiveFormSignatureField SelectedField
        {
            get
            {
                return _fields[signaturesListBox.SelectedIndex];
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of the "OK" button.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of the "Cancel" button.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Gets the friendly name of the signature field.
        /// </summary>
        /// <param name="field">The field.</param>
        private string GetSignatureFieldFriendlyName(PdfInteractiveFormSignatureField field)
        {
            string name = field.FullyQualifiedName;

            // Signer name
            if (field.SignatureInfo != null && field.SignatureInfo.SignerName != null)
                name = string.Format("{0}: {1}", name, field.SignatureInfo.SignerName);

            // PDF Page
            if (field.Annotation.Page != null)
                return string.Format("Page {0}: {1}",
                    field.Document.Pages.IndexOf(field.Annotation.Page) + 1, name);

            return name;
        }

        #endregion

    }
}
