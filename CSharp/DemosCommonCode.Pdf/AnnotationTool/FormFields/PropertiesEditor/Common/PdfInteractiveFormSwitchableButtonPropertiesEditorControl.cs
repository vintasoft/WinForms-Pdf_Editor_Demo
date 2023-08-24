using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of
    /// the <see cref="PdfInteractiveFormSwitchableButtonField"/>.
    /// </summary>
    public partial class PdfInteractiveFormSwitchableButtonPropertiesEditorControl : UserControl, IPdfInteractiveFormPropertiesEditor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfInteractiveFormSwitchableButtonPropertiesEditorControl"/> class.
        /// </summary>
        public PdfInteractiveFormSwitchableButtonPropertiesEditorControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        PdfInteractiveFormSwitchableButtonField _field = null;
        /// <summary>
        /// Gets or sets the <see cref="PdfInteractiveFormSwitchableButtonField"/>.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public PdfInteractiveFormSwitchableButtonField Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;

                if (_field != null && _field.Annotation != null)
                {
                    pdfAnnotationAppearancesEditorControl.Annotation = _field.Annotation;

                    UpdateFieldInfo();
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
                Field = value as PdfInteractiveFormSwitchableButtonField;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates information about the field.
        /// </summary>
        public void UpdateFieldInfo()
        {
            currentAppearanceStateComboBox.BeginUpdate();
            currentAppearanceStateComboBox.Items.Clear();
            if (_field != null)
            {
                string[] names = _field.GetAvailableAppearanceStateNames();
                currentAppearanceStateComboBox.Items.AddRange(names);

                string appearanceStateName = _field.Value;
                if (Array.IndexOf(names, appearanceStateName) == -1)
                    appearanceStateName = "Off";
                currentAppearanceStateComboBox.SelectedItem = appearanceStateName;
            }
            currentAppearanceStateComboBox.EndUpdate();

            pdfAnnotationAppearancesEditorControl.UpdateAppearance();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the SelectedIndexChanged event of CurrentAppearanceStateComboBox object.
        /// </summary>
        private void currentAppearanceStateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get current appearance state value
            string value = currentAppearanceStateComboBox.SelectedItem.ToString();
            // if field value is changed
            if (_field.Value != value)
            {
                _field.Value = value;
                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the AppearanceChanged event of PdfAnnotationAppearancesEditorControl object.
        /// </summary>
        private void pdfAnnotationAppearancesEditorControl_AppearanceChanged(object sender, EventArgs e)
        {
            // raise property value changed event
            OnPropertyValueChanged();
        }


        /// <summary>
        /// Raises the <see cref="PropertyValueChanged"/> event.
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
        /// Occurs when value of property is changed.
        /// </summary>
        public event EventHandler PropertyValueChanged;

        #endregion

    }
}
