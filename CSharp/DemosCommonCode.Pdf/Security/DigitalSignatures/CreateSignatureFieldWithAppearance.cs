using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;

namespace DemosCommonCode.Pdf.Security
{
    /// <summary>
    /// A class that allows to create new signature field or use existing signature field AND
    /// perform signing of PDF document using the signature field.
    /// </summary>
    public class CreateSignatureFieldWithAppearance
    {

        #region Fields

        /// <summary>
        /// The signature appearance that is used to edit the signature appearance of specified signature field.
        /// </summary>
        SignatureAppearanceGraphicsFigure _signatureAppearance;

        #endregion



        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="CreateSignatureFieldWithAppearance"/> class from being created.
        /// </summary>
        private CreateSignatureFieldWithAppearance()
        {
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Shows the <see cref="CreateSignatureFieldForm"/> as a modal dialog.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        /// <param name="annotationRect">The annotation rectangle of new signature field.</param>
        /// <param name="signatureAppearance">The graphics figure that represents the signature appearance.</param>
        /// <returns>
        /// One of the <see cref="DialogResult"/> values.
        /// </returns>
        public static DialogResult ShowDialog(
            PdfDocument document,
            RectangleF annotationRect,
            SignatureAppearanceGraphicsFigure signatureAppearance)
        {
            PdfInteractiveFormSignatureField signatureField = null;
            return ShowDialog(document, annotationRect, signatureAppearance, out signatureField);
        }

        /// <summary>
        /// Shows the <see cref="CreateSignatureFieldForm"/> as a modal dialog.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        /// <param name="annotationRect">The annotation rectangle of new signature field.</param>
        /// <param name="signatureAppearance">The graphics figure that represents the signature appearance.</param>
        /// <returns>
        /// One of the <see cref="DialogResult"/> values.
        /// </returns>
        public static DialogResult ShowDialog(
            PdfDocument document,
            RectangleF annotationRect,
            SignatureAppearanceGraphicsFigure signatureAppearance,
            out PdfInteractiveFormSignatureField signatureField)
        {
            using (CreateSignatureFieldForm form = new CreateSignatureFieldForm(document, annotationRect))
            {
                CreateSignatureFieldWithAppearance appearance = new CreateSignatureFieldWithAppearance();
                DialogResult result = appearance.ShowDialog(form, signatureAppearance);
                signatureField = form.SignatureField;
                return result;
            }
        }

        /// <summary>
        /// Shows the <see cref="CreateSignatureFieldForm"/> as a modal dialog box.
        /// </summary>
        /// <param name="signatureField">The signature field.</param>
        /// <param name="signatureAppearance">The graphics figure that represents the signature appearance.</param>
        /// <returns>
        /// One of the <see cref="DialogResult"/> values.
        /// </returns>
        public static DialogResult ShowDialog(PdfInteractiveFormSignatureField signatureField, SignatureAppearanceGraphicsFigure signatureAppearance)
        {
            using (CreateSignatureFieldForm form = new CreateSignatureFieldForm(signatureField))
            {
                CreateSignatureFieldWithAppearance appearance = new CreateSignatureFieldWithAppearance();
                return appearance.ShowDialog(form, signatureAppearance);
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Shows the specified form as a modal dialog box.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <param name="signatureAppearance">The signature appearance.</param>
        /// <returns>
        /// One of the <see cref="DialogResult"/> values.
        /// </returns>
        private DialogResult ShowDialog(CreateSignatureFieldForm form, SignatureAppearanceGraphicsFigure signatureAppearance)
        {
            _signatureAppearance = signatureAppearance;

            form.CanChangeSignatureAppearance = true;
            form.CreateSignatureAppearance += Form_CreateSignatureAppearance;

            return form.ShowDialog();
        }

        /// <summary>
        /// Creates the signature apperance.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CreateSignatureAppearanceEventArgs"/> instance containing the event data.</param>
        private void Form_CreateSignatureAppearance(object sender, CreateSignatureAppearanceEventArgs e)
        {
            // associate the signature field with signature appearance
            _signatureAppearance.SignatureField = e.SignatureField;
            // create a form that allows to create or edit the appearance of the signature field
            using (CreateSignatureAppearanceForm createSignatureAppearance = new CreateSignatureAppearanceForm(_signatureAppearance))
            {
                // if appearance is created
                if (createSignatureAppearance.ShowDialog() == DialogResult.OK)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        #endregion

        #endregion

    }
}
