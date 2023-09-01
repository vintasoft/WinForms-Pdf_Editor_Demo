using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;
using Vintasoft.Imaging.Pdf.UI;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// Contains common static functions for PDF actions.
    /// </summary>
    public static class PdfActionsTools
    {

        /// <summary>
        /// Returns a description of PDF action.
        /// </summary>
        /// <param name="action">The PDF action.</param>
        /// <returns>Action description.</returns>
        public static string GetActionDescription(PdfAction action)
        {
            if (action is PdfGotoAction)
            {
                PdfGotoAction gotoAction = (PdfGotoAction)action;
                PdfGotoActionExecutor gotoActionExecutor =
                    PdfActionExecutorManager.ApplicationActionExecutor.FindExecutor<PdfGotoActionExecutor>();
                if (gotoActionExecutor != null)
                {
                    VintasoftImage destImage = gotoActionExecutor.GetImageAssociatedWithAction(gotoAction);
                    if (destImage != null)
                    {
                        return string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_ARG0_ARG1_PAGE_NUMBER_ARG2,
                               gotoAction.GetType().Name,
                               gotoAction.Destination.GetType().Name,
                               gotoActionExecutor.ImageViewer.Images.IndexOf(destImage) + 1);
                    }
                    if (gotoAction.Destination != null && gotoAction.Destination.Page != null)
                    {
                        return string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_ARG0_ARG1_DOCUMENT_PAGE_NUMBER_ARG2,
                           gotoAction.GetType().Name,
                           gotoAction.Destination.GetType().Name,
                           gotoAction.Document.Pages.IndexOf(gotoAction.Destination.Page) + 1);
                    }
                }
            }
            else if (action is PdfNamedAction)
            {
                return string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_NAMED_ACTION_ARG0,
                    ((PdfNamedAction)action).ActionName);
            }
            else if (action is PdfLaunchAction)
            {
                return string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_LAUNCH_APPLICATION_ARG0,
                    ((PdfLaunchAction)action).WinCommandLine);
            }
            else if (action is PdfUriAction)
            {
                return string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_OPEN_URL_ARG0_ALT1,
                    ((PdfUriAction)action).URI);
            }
            else if (action is PdfSubmitFormAction)
            {
                return string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SUBMIT_INTERACTIVE_FORM_ARG0_ARG1,
                    ((PdfSubmitFormAction)action).SubmitFormat,
                    ((PdfSubmitFormAction)action).Url);
            }
            return string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_ARG0_ACTION_ARG1, action.ActionType, action.GetType().Name);
        }

        /// <summary>
        /// Returns a description of "Activate" action of PDF annotation.
        /// </summary>
        /// <param name="annotation">The PDF annotation.</param>
        /// <returns>A description of "Activate" action of PDF annotation.</returns>
        public static string GetActivateActionDescription(PdfAnnotation annotation)
        {
            PdfAction action = annotation.GetAction(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_ACTIVATE);
            if (annotation.AdditionalActions != null)
            {
                if (action == null)
                    action = annotation.AdditionalActions.MouseButtonUp;
                if (action == null)
                    action = annotation.AdditionalActions.MouseButtonDown;
            }
            if (action != null)
                return GetActionDescription(action);
            return "";
        }

    }
}
