using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of
    /// the <see cref="PdfInteractiveFormCheckBoxField"/>.
    /// </summary>
    public partial class PdfCheckBoxPropertiesEditorControl : UserControl, IPdfInteractiveFormPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfCheckBoxPropertiesEditorControl"/> class.
        /// </summary>
        public PdfCheckBoxPropertiesEditorControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        PdfInteractiveFormCheckBoxField _field = null;
        /// <summary>
        /// Gets or sets the <see cref="PdfInteractiveFormCheckBoxField"/>.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public PdfInteractiveFormCheckBoxField Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;

                pdfInteractiveFormSwitchableButtonPropertiesEditorControl.Field = _field;
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
                Field = value as PdfInteractiveFormCheckBoxField;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates information of the field.
        /// </summary>
        public void UpdateFieldInfo()
        {
            pdfInteractiveFormSwitchableButtonPropertiesEditorControl.UpdateFieldInfo();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the PropertyValueChanged event of PdfInteractiveFormSwitchableButtonPropertiesEditorControl object.
        /// </summary>
        private void pdfInteractiveFormSwitchableButtonPropertiesEditorControl_PropertyValueChanged(object sender, EventArgs e)
        {
            // raise proeprty changed event
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
