using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree.Annotations;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit common properties of the <see cref="PdfAnnotation"/>.
    /// </summary>
    public partial class PdfAnnotationCommonPropertiesEditorControl : UserControl, IPdfAnnotationPropertiesEditor
    {

        #region Fields

        /// <summary>
        /// A value indicating whether the user interface is updating.
        /// </summary>
        bool _isUiUpdating = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfAnnotationCommonPropertiesEditorControl"/> class.
        /// </summary>
        public PdfAnnotationCommonPropertiesEditorControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        PdfAnnotation _annotation;
        /// <summary>
        /// Gets or sets the annotation.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public PdfAnnotation Annotation
        {
            get
            {
                return _annotation;
            }
            set
            {
                if (_annotation != value)
                {
                    _annotation = value;

                    borderStyleControl.Annotation = value;

                    opacityPanel.Enabled = _annotation is PdfMarkupAnnotation;
                    UpdateAnnotationInfo();
                }
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates the information about annotation.
        /// </summary>
        public void UpdateAnnotationInfo()
        {
            _isUiUpdating = true;

            try
            {
                borderStyleControl.UpdateBorderInfo();

                if (_annotation == null)
                {
                    nameTextBox.Text = string.Empty;
                    subjectTextBox.Text = string.Empty;
                    titleTextBox.Text = string.Empty;
                }
                else
                {
                    nameTextBox.Text = _annotation.Name;
                    subjectTextBox.Text = _annotation.Subject;
                    titleTextBox.Text = _annotation.Title;

                    lockedCheckBox.Checked = _annotation.IsLocked;
                    printableCheckBox.Checked = _annotation.IsPrintable;
                    readOnlyCheckBox.Checked = _annotation.IsReadOnly;

                    PdfMarkupAnnotation markupAnnotation = _annotation as PdfMarkupAnnotation;
                    if (markupAnnotation == null)
                        opacityNumericUpDown.Value = opacityNumericUpDown.Maximum;
                    else
                        opacityNumericUpDown.Value = Convert.ToDecimal(markupAnnotation.Opacity) * opacityNumericUpDown.Maximum;
                }
            }
            finally
            {
                _isUiUpdating = false;
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the Scroll event of opacityTrackBar object.
        /// </summary>
        private void opacityTrackBar_Scroll(object sender, EventArgs e)
        {
            // if annotation opacity value is changed
            if (opacityNumericUpDown.Value != opacityTrackBar.Value)
                // update annotation opacity value
                opacityNumericUpDown.Value = opacityTrackBar.Value;
        }

        /// <summary>
        /// Handles the ValueChanged event of opacityNumericUpDown object.
        /// </summary>
        private void opacityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // if annotation opacity value is changed
            if (opacityTrackBar.Value != opacityNumericUpDown.Value)
                // update annotation opacity value
                opacityTrackBar.Value = (int)opacityNumericUpDown.Value;

            // if user interface is not updating
            if (!_isUiUpdating)
            {
                PdfMarkupAnnotation markupAnnotation = (PdfMarkupAnnotation)_annotation;
                // calculate annotation opacity
                float opacity = (float)(opacityNumericUpDown.Value / opacityNumericUpDown.Maximum);
                // update annotation opacity
                markupAnnotation.Opacity = opacity;

                OnPropertyValueChanged();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of nameTextBox object.
        /// </summary>
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            // if user interface is not updating
            if (_isUiUpdating)
                return;

            // update annotation name
            _annotation.Name = nameTextBox.Text;
        }

        /// <summary>
        /// Handles the TextChanged event of subjectTextBox object.
        /// </summary>
        private void subjectTextBox_TextChanged(object sender, EventArgs e)
        {
            // if user interface is not updating
            if (_isUiUpdating)
                return;

            // update annotation subject
            _annotation.Subject = subjectTextBox.Text;
        }

        /// <summary>
        /// Handles the TextChanged event of titleTextBox object.
        /// </summary>
        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            // if user interface is not updating
            if (_isUiUpdating)
                return;

            // update annotation title
            _annotation.Title = titleTextBox.Text;
        }

        /// <summary>
        /// Handles the CheckedChanged event of lockedCheckBox object.
        /// </summary>
        private void lockedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if user interface is not updating
            if (_isUiUpdating)
                return;

            // if annotation must be locked
            if (lockedCheckBox.Checked)
                _annotation.IsLocked = true;
            else
                _annotation.IsLocked = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of printableCheckBox object.
        /// </summary>
        private void printableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if user interface is not updating
            if (_isUiUpdating)
                return;

            // if annotation must be printed on PDF page
            if (printableCheckBox.Checked)
                _annotation.IsPrintable = true;
            else
                _annotation.IsPrintable = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of readOnlyCheckBox object.
        /// </summary>
        private void readOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if user interface is not updating
            if (_isUiUpdating)
                return;

            // if annotation cannot interact with the user
            if (readOnlyCheckBox.Checked)
                _annotation.IsReadOnly = true;
            else
                _annotation.IsReadOnly = false;
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of borderStyleControl object.
        /// </summary>
        private void borderStyleControl_PropertyValueChanged(object sender, EventArgs e)
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
        /// Occurs when value of property is changed.
        /// </summary>
        public event EventHandler PropertyValueChanged;

        #endregion

    }
}
