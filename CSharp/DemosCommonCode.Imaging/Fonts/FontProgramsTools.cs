using System.Text;
using System.Windows.Forms;
using Vintasoft.Imaging.Utils;

using DemosCommonCode.Imaging;
using Vintasoft.Imaging.Fonts;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Allows to use custom PDF font program controller for PDF documents, which are opened in PDF demos.
    /// </summary>
    public static class FontProgramsTools
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FontProgramsTools"/> class.
        /// </summary>
        static FontProgramsTools()
        {
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Shows a dialog for refreshing the PostScript font names of programs controller
        /// and refreshes the PostScript font names of programs controller.
        /// </summary>
        /// <param name="dialogOwner">The dialog owner.</param>
        public static DialogResult RefreshPostScriptFontNamesOfProgramsController(Form dialogOwner)
        {
            StringBuilder messageString = new StringBuilder();
            messageString.AppendLine(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_THIS_OPERATION_WILL_PARSE_ALL_FONTS_AVAILABLE_ON_SYSTEM_AND_REFRESH);
            messageString.AppendLine(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_THE_FONT_MAP_BY_REPLACING_CURRENT_NAMES_WITH_ACTUAL_FONT_NAMES);
            messageString.AppendLine(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_IT_CAN_BE_TIME_CONSUMING);
            messageString.AppendLine(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_DO_YOU_WANT_TO_REFRESH_NAMES_OF_ALL_AVAILABLE_FONTS);

            if (MessageBox.Show(messageString.ToString(), PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_REFRESH_FONT_NAMES, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (ActionProgressForm actionProgressForm = new ActionProgressForm(RefreshFontNames, 1, PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_IMAGING_REFRESHING_FONT_NAMES))
                    return actionProgressForm.RunAndShowDialog(dialogOwner);
            }
            else
            {
                return DialogResult.None;
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Refreshes the PostScript font names of programs controller.
        /// </summary>
        /// <param name="progressController">Progress controller.</param>
        private static void RefreshFontNames(IActionProgressController progressController)
        {
            FileFontProgramsControllerBase fontProgramsController = FontProgramsControllerBase.Default as FileFontProgramsControllerBase;
            if (fontProgramsController != null)
                fontProgramsController.RefreshFontNames(progressController);
        }

        #endregion

        #endregion

    }
}