using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;
using Vintasoft.Imaging.Pdf.UI.Annotations;
using Vintasoft.Imaging.Spelling.UI;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Stores and manages settings for interaction areas of PDF visual tool.
    /// </summary>
    public class PdfInteractionAreaAppearanceManager : InteractionAreaAppearanceManager
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfInteractionAreaAppearanceManager"/> class.
        /// </summary>
        public PdfInteractionAreaAppearanceManager()
        {
        }

        #endregion



        #region Properties

        bool _isEnabledFormFieldSpellChecking = true;
        /// <summary>
        /// Gets or sets a value indicating whether the spell checking of PDF interactive form fields is enabled.
        /// </summary>
        /// <value>
        /// <b>true</b> if spell checking of PDF interactive form fields is enabled; otherwise, <b>false</b>.
        /// </value>
        public bool IsEnabledFormFieldSpellChecking
        {
            get
            {
                return _isEnabledFormFieldSpellChecking;
            }
            set
            {
                if (_isEnabledFormFieldSpellChecking != value)
                {
                    _isEnabledFormFieldSpellChecking = value;

                    ApplyAppearanceSettings();
                }
            }
        }

        bool _isEnabledAnnotationsSpellChecking = true;
        /// <summary>
        /// Gets or sets a value indicating whether the spell checking of PDF annotations is enabled.
        /// </summary>
        /// <value>
        /// <b>true</b> if spell checking of PDF annotations is enabled; otherwise, <b>false</b>.
        /// </value>
        public bool IsEnabledAnnotationsSpellChecking
        {
            get
            {
                return _isEnabledAnnotationsSpellChecking;
            }
            set
            {
                if (_isEnabledAnnotationsSpellChecking != value)
                {
                    _isEnabledAnnotationsSpellChecking = value;

                    ApplyAppearanceSettings();
                }
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Sets the spell check manager settings.
        /// </summary>
        /// <param name="manager">The spell check manager.</param>
        public override void SetSpellCheckManagerSettings(RichTextBoxSpellCheckManager manager)
        {
            base.SetSpellCheckManagerSettings(manager);

            bool isSpellCheckEnabled = false;

            // if visual tool is PdfAnnotationTool
            if (VisualTool is PdfAnnotationTool)
            {
                PdfAnnotationTool annotationTool = (PdfAnnotationTool)VisualTool;

                // if focused PDF interactive form field is text field or combo box field
                if (annotationTool.FocusedField is PdfInteractiveFormTextField ||
                    annotationTool.FocusedField is PdfInteractiveFormComboBoxField)
                {
                    isSpellCheckEnabled = IsEnabledFormFieldSpellChecking;
                }
                else
                {
                    isSpellCheckEnabled = IsEnabledAnnotationsSpellChecking;
                }
            }

            // update spell check
            manager.IsEnabled = isSpellCheckEnabled;
        }

        #endregion

    }
}
