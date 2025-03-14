﻿#if REMOVE_PDF_PLUGIN
#error Remove DocumentSignaturesForm from project.
#endif

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree.DigitalSignatures;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;

namespace DemosCommonCode.Pdf.Security
{
    /// <summary>
    /// A form that shows digital signatures of PDF document.
    /// </summary>
    public partial class DocumentSignaturesForm : Form
    {

        #region Constants

        /// <summary>
        /// "Fail" default color.
        /// </summary>
        static readonly Color FAIL_COLOR = Color.FromArgb(255, 120, 120);

        /// <summary>
        /// "Warning" default color.
        /// </summary>
        static readonly Color WARNING_COLOR = Color.FromArgb(255, 200, 50);

        /// <summary>
        /// "Success" default color.
        /// </summary>
        static readonly Color SUCCESS_COLOR = Color.FromArgb(165, 255, 90);

        /// <summary>
        /// "Signing is not implemented" default color.
        /// </summary>
        static readonly Color SIGNING_NOT_IMPLEMENTED_COLOR = Color.LightGray;

        #endregion



        #region Fields

        /// <summary>
        /// The PDF document.
        /// </summary>
        PdfDocument _document;

        /// <summary>
        /// List of PdfSignatureInformation objects.
        /// </summary>
        List<PdfSignatureInformation> _signatureInfos = new List<PdfSignatureInformation>();

        /// <summary>
        /// List of PdfPkcsSignature objects.
        /// </summary>
        List<PdfPkcsSignature> _signatures = new List<PdfPkcsSignature>();

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentSignaturesForm"/> class.
        /// </summary>
        public DocumentSignaturesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentSignaturesForm"/> class.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        /// <exception cref="Exception">Thrown if
        /// the document does not contain digital signatures.</exception>
        public DocumentSignaturesForm(PdfDocument document)
            : this()
        {
            _document = document;

            if (_document.InteractiveForm == null)
                throw new Exception(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_DOCUMENT_DOES_NOT_CONTAIN_DIGITAL_SIGNATURES);

            BuildSignaturesTreeView();
            UpdateUI();
        }

        #endregion



        /// <summary>
        /// Gets or sets the selected signature field.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PdfInteractiveFormSignatureField SelectedSignatureField
        {
            get
            {
                TreeNode node = signaturesTreeView.SelectedNode;
                if (node == null)
                    return null;
                while (node.Parent != null)
                    node = node.Parent;
                return (PdfInteractiveFormSignatureField)node.Tag;
            }
            set
            {
                foreach (TreeNode node in signaturesTreeView.Nodes)
                    if (node.Tag == value)
                    {
                        signaturesTreeView.SelectedNode = node;
                        break;
                    }

            }
        }


        #region Methods

        /// <summary>
        /// "OK" button is clicked.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// "Verify All Signatures" button is clicked.
        /// </summary>
        private void verifyAllButton_Click(object sender, EventArgs e)
        {
            // for each signature field
            for (int i = 0; i < _signatures.Count; i++)
            {
                // if signature field does not have signature information
                if (_signatureInfos[i] == null)
                    continue;

                PdfSignatureInformation signatureInfo = _signatureInfos[i];
                PdfPkcsSignature signature = _signatures[i];
                TreeNode node = signaturesTreeView.Nodes[i];
                TreeNode subNode;

                // if signature information does not have PKCS signature
                // (signature is not supported OR damaged)
                if (signature == null)
                {
                    node.BackColor = FAIL_COLOR;
                }
                // if signature cannot be used for signing
                else if (!signature.IsSigningImplemented)
                {
                    node.BackColor = SIGNING_NOT_IMPLEMENTED_COLOR;
                    node.Nodes[0].BackColor = node.BackColor;
                }
                else
                {
                    // verify signature

                    bool signatureVerifyResult = false;
                    bool embeddedTimestampVerifyResult = false;
                    bool certificateVerifyResult = false;
                    bool hasTimestampCertificate = false;
                    bool timestampCertificateVerifyResult = false;
                    bool signatureCoversWholeDocument = false;
                    signaturesTreeView.Nodes[i].Nodes[0].Nodes.Clear();
                    X509Chain certChain = null;
                    X509Chain timestampCertChain = null;

                    node.BackColor = Color.White;
                    node.Nodes[0].Text = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_VERIFYING_SIGNATURE;
                    node.Expand();
                    Application.DoEvents();

                    bool failed = false;
                    bool pagesModified = false;
                    string subsequentChangesMessage = "";
                    try
                    {
                        // check that signature covers the whole document
                        signatureCoversWholeDocument = _signatureInfos[i].SignatureCoversWholeDocument();

                        // verify PKCS signature
                        signatureVerifyResult = signature.VerifySignature();

                        // if signature has embedded timestamp
                        if (signature.HasEmbeddedTimeStamp)
                        {
                            // verify embedded timestamp
                            embeddedTimestampVerifyResult = signature.VerifyTimestamp();
                        }

                        // signer revision
                        PdfDocumentRevision signerRevision = signatureInfo.SignedRevision;
                        node.Tag = signatureInfo.SignedRevision;

                        // if signature verification is success and signature does not cover the whole document
                        if (signerRevision != null && signatureVerifyResult && !signatureCoversWholeDocument)
                        {
                            // check subsequent changes
                            using (PdfDocumentRevisionComparer revisionComparer = signatureInfo.GetDocumentChanges())
                            {
                                // detect modified page(s)
                                pagesModified = revisionComparer.HasModifiedPages;

                                // build subsequent changes message
                                if (revisionComparer.ChangedPageContents.Count > 0)
                                    subsequentChangesMessage += string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_ARG0_PAGES_MODIFIED, revisionComparer.ChangedPageContents.Count);
                                if (revisionComparer.AddedPages.Count > 0)
                                    subsequentChangesMessage += string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_ARG0_PAGES_ADDED, revisionComparer.AddedPages.Count);
                                if (revisionComparer.RemovedPages.Count > 0)
                                    subsequentChangesMessage += string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_ARG0_PAGES_REMOVED, revisionComparer.RemovedPages.Count);
                                if (revisionComparer.RemovedAnnotations.Count > 0)
                                    subsequentChangesMessage += string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_ANNOTATIONSS_ON_ARG0_PAGES_REMOVED, revisionComparer.RemovedAnnotations.Count);
                                if (revisionComparer.RemovedAnnotations.Count > 0)
                                    subsequentChangesMessage += string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_REMOVED_ANNOTATIONS_ON_ARG0_PAGES, revisionComparer.RemovedAnnotations.Count);
                                if (revisionComparer.AddedAnnotations.Count > 0)
                                    subsequentChangesMessage += string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_ADDED_ANNOTATIONS_ON_ARG0_PAGES, revisionComparer.AddedAnnotations.Count);
                                if (revisionComparer.ChangedAnnotations.Count > 0)
                                    subsequentChangesMessage += string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_CHANGED_ANNOTATIONS_ON_ARG0_PAGES, revisionComparer.ChangedAnnotations.Count);
                                if (revisionComparer.MiscellaneousChanges.Count > 0)
                                    subsequentChangesMessage += string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_MISCELLANEOUS_CHANGES_ARG0, revisionComparer.MiscellaneousChanges.Count);
                            }
                        }

                        // use certificate chain from signature to build and verify certificate chain (no revocation check)
                        bool useSigningCertificateChainToBuildChain = useSigningCertificateChainToBuildChainCheckBox.Checked;

                        // build and verify signing certificate chain
                        certificateVerifyResult = BuildX509Chain(signature.SigningCertificateChain, useSigningCertificateChainToBuildChain, out certChain);

                        // if signature has Timestamp
                        X509Certificate2 timestampCertificate = signature.TimestampCertificate;
                        if (timestampCertificate != null)
                        {
                            hasTimestampCertificate = true;
                            // build and verify timestamp certificate chain
                            timestampCertificateVerifyResult = BuildX509Chain(signature.TimestampCertificateChain, useSigningCertificateChainToBuildChain, out timestampCertChain);
                        }
                    }
                    catch (Exception validateException)
                    {
                        failed = true;
                        node.BackColor = FAIL_COLOR;
                        node.Nodes[0].Text = string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_ERROR_ARG0, validateException.Message);
                        node.Nodes[0].BackColor = FAIL_COLOR;
                    }
                    if (failed)
                        continue;

                    // show signature verification results

                    Color validateColor = Color.White;
                    string validateResult = "";

                    // if signature verification is failed OR signature does not cover the whole document AND pages are modified
                    if (!signatureVerifyResult || (!signatureCoversWholeDocument && pagesModified))
                    {
                        validateResult = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_IS_INVALID;
                        validateColor = FAIL_COLOR;
                    }
                    // if certificate validation is failed
                    else if (!certificateVerifyResult || (hasTimestampCertificate && !timestampCertificateVerifyResult) || (signature.HasEmbeddedTimeStamp && !embeddedTimestampVerifyResult))
                    {
                        validateResult = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_VALIDITY_IS_UNKNOWN;
                        validateColor = WARNING_COLOR;
                    }
                    // certificate is valid
                    else
                    {
                        validateResult = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_IS_VALID;
                        validateColor = SUCCESS_COLOR;
                    }
                    node.BackColor = validateColor;
                    node.Nodes[0].Text = validateResult;
                    node.Nodes[0].BackColor = validateColor;


                    // show signature verification details

                    // if signature verification is successful
                    if (signatureVerifyResult)
                    {
                        // if signature covers the whole document
                        if (signatureCoversWholeDocument)
                        {
                            // verification passed
                            subNode = node.Nodes[0].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_VERIFICATION_DOCUMENT_HAS_NOT_BEEN_MODIFIED_SINCE_THIS_SIGNATURE_WAS_APPLIED);
                            subNode.BackColor = SUCCESS_COLOR;
                        }
                        // if signature does NOT cover the whole document
                        else
                        {
                            // if pages are modified
                            if (pagesModified)
                            {
                                // verification falied
                                subNode = node.Nodes[0].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_VERIFICATION_DOCUMENT_HAS_BEEN_MODIFIED_OR_CORRUPTED_SINCE_IT_WAS_SIGNED);
                                subNode.BackColor = FAIL_COLOR;
                                if (subsequentChangesMessage != "")
                                {
                                    subNode = node.Nodes[0].Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SUBSEQUENT_CHANGES_ARG0, subsequentChangesMessage));
                                    subNode.BackColor = FAIL_COLOR;
                                }
                            }
                            else
                            {
                                // verification passed
                                if (subsequentChangesMessage != "")
                                {
                                    subNode = node.Nodes[0].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_VERIFICATION_THE_REVISION_OF_THE_DOCUMENT_THAT_WAS_COVERED_BY_THIS_SIGNATURE_HAS_NOT_BEEN_ALTERED_HOWEVER_THERE_HAVE_BEEN_SUBSEQUENT_CHANGES_TO_THE_DOCUMENT);
                                    subNode.BackColor = WARNING_COLOR;
                                    subNode = node.Nodes[0].Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SUBSEQUENT_CHANGES_ARG0_ALT1, subsequentChangesMessage));
                                    subNode.BackColor = WARNING_COLOR;
                                }
                                else
                                {
                                    subNode = node.Nodes[0].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_VERIFICATION_DOCUMENT_HAS_NOT_BEEN_MODIFIED_SINCE_THIS_SIGNATURE_WAS_APPLIED_ALT1);
                                    subNode.BackColor = SUCCESS_COLOR;
                                }
                            }
                        }
                    }
                    // if signature verification is NOT successful
                    else
                    {
                        // verification falied
                        subNode = node.Nodes[0].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_VERIFICATION_DOCUMENT_HAS_BEEN_MODIFIED_OR_CORRUPTED_SINCE_IT_WAS_SIGNED_ALT1);
                        subNode.BackColor = FAIL_COLOR;
                    }

                    // if signature has embedded timestamp
                    if (signature.HasEmbeddedTimeStamp)
                    {
                        if (embeddedTimestampVerifyResult)
                        {
                            subNode = node.Nodes[0].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_TIMESTAMP_VERIFICATION_TIMESTAMP_IS_VALID);
                            subNode.BackColor = SUCCESS_COLOR;
                        }
                        else
                        {
                            // verification falied
                            subNode = node.Nodes[0].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_TIMESTAMP_VERIFICATION_TIMESTAMP_IS_CORRUPTED);
                            subNode.BackColor = FAIL_COLOR;
                        }
                    }

                    // show certificate verification details
                    if (certChain != null)
                    {
                        // if certificate verification is successful 
                        if (certificateVerifyResult)
                        {
                            subNode = node.Nodes[0].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_CERTIFICATE_VERIFICATION_SIGNERS_CERTIFICATE_IS_VALID);
                            subNode.BackColor = SUCCESS_COLOR;
                        }
                        // if certificate verification is NOT successful 
                        else
                        {
                            subNode = node.Nodes[0].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_CERTIFICATE_VERIFICATION_SIGNERS_CERTIFICATE_IS_INVALID);
                            subNode.BackColor = WARNING_COLOR;
                            foreach (X509ChainStatus status in certChain.ChainStatus)
                                subNode.Nodes.Add(string.Format("{0}: {1}", status.Status, status.StatusInformation));
                        }
                    }

                    if (hasTimestampCertificate)
                    {
                        // if timestamp certificate verification is successful 
                        if (timestampCertificateVerifyResult)
                        {
                            subNode = node.Nodes[0].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_TIMESTAMP_CERTIFICATE_VERIFICATION_CERTIFICATE_IS_VALID);
                            subNode.BackColor = SUCCESS_COLOR;
                        }
                        // if certificate verification is NOT successful 
                        else
                        {
                            subNode = node.Nodes[0].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_TIMESTAMP_CERTIFICATE_VERIFICATION_CERTIFICATE_IS_INVALID);
                            subNode.BackColor = WARNING_COLOR;
                            foreach (X509ChainStatus status in timestampCertChain.ChainStatus)
                                subNode.Nodes.Add(string.Format("{0}: {1}", status.Status, status.StatusInformation));
                        }
                    }

                    node.Nodes[0].Expand();
                    Application.DoEvents();
                }
            }
        }

        /// <summary>
        /// Builds the X509 chain.
        /// </summary>
        /// <param name="signingCertificateChain">The signing certificate chain.</param>
        /// <param name="useSigningCertificateChain">Use certificate chain from signature to build and verify certificate chain (no revocation check).</param>
        /// <param name="certChain">The cert chain.</param>
        /// <returns><b>True</b> if the X.509 certificate is valid; otherwise, <b>false</b>.</returns>
        private bool BuildX509Chain(X509Certificate2[] signingCertificateChain, bool useSigningCertificateChainToBuildChain, out X509Chain certChain)
        {
            // signing certificate
            X509Certificate2 certificate = signingCertificateChain[0];
            // 
            // root certificate of signing certificate chain
            X509Certificate2 signingCertificateChainRoot = signingCertificateChain[signingCertificateChain.Length - 1];

            // need use signing certificate chain from signature
            if (signingCertificateChain.Length == 1)
                useSigningCertificateChainToBuildChain = false;

            // create X509Chain
            certChain = new X509Chain();

            // if need use signing certificate chain from signature
            if (useSigningCertificateChainToBuildChain)
            {
                // add certificate chain to ExtraStore of certChain
                for (int j = signingCertificateChain.Length - 1; j > 0; j--)
                    certChain.ChainPolicy.ExtraStore.Add(signingCertificateChain[j]);

                // no revocation check is performed on the certificate
                certChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

                // ignore that the chain cannot be verified due to an unknown certificate authority (CA)
                certChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            }

            // build and verify certificate chain
            bool certificateVerifyResult = certChain.Build(certificate);

            // if need use signing certificate chain from signature and 
            if (useSigningCertificateChainToBuildChain && certificateVerifyResult)
            {
                // check builded chainRoot and root certificate of signing certificate chain from signature 
                if (certChain.ChainElements.Count < signingCertificateChain.Length)
                {
                    certificateVerifyResult = false;
                }
                else
                {
                    X509Certificate2 chainRoot = certChain.ChainElements[signingCertificateChain.Length - 1].Certificate;
                    if (!chainRoot.RawData.SequenceEqual(signingCertificateChainRoot.RawData))
                        certificateVerifyResult = false;
                }
            }

            return certificateVerifyResult;
        }


        /// <summary>
        /// Handles the Click event of the "Save Document Revision" button.
        /// </summary>
        private void saveDocumentRevisionButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_PDF_DOCUMENTS_PDFPDF;
            try
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    PdfDocumentRevision revision = (PdfDocumentRevision)signaturesTreeView.SelectedNode.Tag;
                    revision.CopyRevisionTo(saveFile.FileName);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Updates the User Interface.
        /// </summary>       
        private void UpdateUI()
        {
            if (signaturesTreeView.SelectedNode != null &&
                signaturesTreeView.SelectedNode.Tag is PdfDocumentRevision)
            {
                PdfDocumentRevision revision = (PdfDocumentRevision)signaturesTreeView.SelectedNode.Tag;
                saveDocumentRevisionButton.Text = string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SAVE_DOCUMENT_RESIVION_ARG0_AS, revision.RevisionNumber);
                saveDocumentRevisionButton.Enabled = true;
            }
            else
            {
                saveDocumentRevisionButton.Text = PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SAVE_DOCUMENT_RESIVION_AS;
                saveDocumentRevisionButton.Enabled = false;
            }
        }

        /// <summary>
        /// Builds the tree view for signatures.
        /// </summary>
        private void BuildSignaturesTreeView()
        {
            signaturesTreeView.Nodes.Clear();

            // if document has interactive form
            if (_document.InteractiveForm != null)
            {
                // get signature fields of PDF document
                PdfInteractiveFormSignatureField[] signatureFields = _document.InteractiveForm.GetSignatureFields();
                // for each signature field
                for (int i = 0; i < signatureFields.Length; i++)
                {
                    PdfInteractiveFormSignatureField signatureField = signatureFields[i];

                    // get signature information
                    PdfSignatureInformation signatureInfo = signatureFields[i].SignatureInfo;
                    _signatureInfos.Add(signatureInfo);

                    // text of signature header
                    string signatureText = "";

                    // if signature has information about document revision
                    if (signatureInfo != null && signatureInfo.SignedRevision != null)
                        signatureText += string.Format("{0}: ", signatureInfo.SignedRevision);

                    // signature field fully qualified name
                    signatureText += string.Format("{0}: ", signatureField.FullyQualifiedName);

                    // get PKCS signature
                    PdfPkcsSignature signature = null;
                    if (signatureInfo == null)
                    {
                        signatureText += PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_UNSIGNED_SIGNATURE_FIELD;
                    }
                    else
                    {
                        try
                        {
                            signature = signatureInfo.GetSignature();
                            signatureText += ConvertCertificateToString(signature.SigningCertificate);
                        }
                        catch (Exception ex)
                        {
                            signatureText += string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_NOT_SUPPORTED_OR_CORRUPTED_SIGNATURE_ARG0, ex.Message);
                        }
                    }
                    _signatures.Add(signature);

                    // add signature header text to tree view
                    TreeNode node = signaturesTreeView.Nodes.Add(signatureText);
                    node.Tag = signatureField;

                    // if signature field has signature info
                    if (signatureInfo != null)
                    {
                        if (signature != null)
                        {
                            if (signature.IsSigningImplemented)
                                signaturesTreeView.Nodes[i].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_IS_NOT_VERIFIED);
                            else
                                signaturesTreeView.Nodes[i].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNING_IS_NOT_IMPLEMENTED);
                        }

                        // add signature details
                        TreeNode signatureDetailsNode = signaturesTreeView.Nodes[i].Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_DETAILS);

                        if (signature != null)
                        {
                            if (signature.IsTimeStamp || signature.HasEmbeddedTimeStamp)
                            {
                                TreeNode timestampDetails = null;
                                if (signature.IsTimeStamp)
                                {
                                    timestampDetails = signatureDetailsNode.Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_IS_A_DOCUMENT_TIMESTAMP_SIGNATURE);
                                }
                                else if (signature.HasEmbeddedTimeStamp)
                                {
                                    timestampDetails = signatureDetailsNode.Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_INCLUDES_AN_EMBEDED_TIMESTAMP);
                                    if (signature.TimestampCertificate != null)
                                    {
                                        timestampDetails.Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_TIMESTAMP_CERTIFICATE_ARG0, ConvertCertificateToString(signature.TimestampCertificate)));
                                        TreeNode timestampCertificateDetails = timestampDetails.Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_TIMESTAMP_CERTIFICATE_DETAILS);
                                        timestampCertificateDetails.Tag = signature.TimestampCertificate;

                                        if (signature.TimestampCertificateChain.Length > 1)
                                        {
                                            AddCerteficateChainToTreeView(signature.TimestampCertificateChain, timestampDetails.Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_TIMESTAMP_CERTIFICATE_CHAIN));
                                        }
                                    }
                                }
                                timestampDetails.Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_TIMESTAMP_DATE_ARG0, signature.TimeStampDate));
                                timestampDetails.Expand();
                            }

                            TreeNode certificateDetails = signatureDetailsNode.Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_CERTIFICATE_DETAILS);
                            certificateDetails.Tag = signature.SigningCertificate;
                            signatureDetailsNode.Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNATURE_ALGORITHM_ARG0, signature.SignatureAlgorithmName));
                            if (signature.SigningCertificateChain.Length > 1)
                            {
                                AddCerteficateChainToTreeView(signature.SigningCertificateChain, signatureDetailsNode.Nodes.Add(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_CERTIFICATE_CHAIN));
                            }
                        }

                        // add signature information details
                        signatureDetailsNode.Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_FILTER_ARG0_ARG1, signatureInfo.Filter, signatureInfo.SubFilter));

                        if (signatureInfo.SignerName != null)
                            signatureDetailsNode.Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_NAME_OF_SIGNER_ARG0, signatureInfo.SignerName));
                        if (signatureInfo.Reason != null)
                            signatureDetailsNode.Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_REASON_ARG0, signatureInfo.Reason));
                        if (signatureInfo.ContactInfo != null)
                            signatureDetailsNode.Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_CONTACT_INFO_ARG0, signatureInfo.ContactInfo));
                        if (signatureInfo.Location != null)
                            signatureDetailsNode.Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_LOCATION_ARG0, signatureInfo.Location));
                        if (signatureInfo.SigningTime != DateTime.MinValue)
                            signatureDetailsNode.Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_SIGNING_TIME_ARG0, signatureInfo.SigningTime));
                        if (signatureInfo.BuildProperties != null)
                        {
                            if (signatureInfo.BuildProperties.Application != null)
                            {
                                if (signatureInfo.BuildProperties.Application.Name != null)
                                    signatureDetailsNode.Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_APPLICATION_ARG0, signatureInfo.BuildProperties.Application.Name));
                            }
                        }
                    }

                    if (signatureField.Annotation.Page != null)
                        signaturesTreeView.Nodes[i].Nodes.Add(string.Format(PdfEditorDemo.Localization.Strings.DEMOSCOMMONCODE_PDF_SECURITY_PAGE_ARG0, _document.Pages.IndexOf(signatureField.Annotation.Page) + 1));

                    signaturesTreeView.Nodes[i].Expand();
                }
            }
        }

        /// <summary>
        /// Adds the certeficate chain to tree view.
        /// </summary>
        /// <param name="certificateChain">The certificate chain.</param>
        /// <param name="treeNode">The tree node.</param>
        private void AddCerteficateChainToTreeView(X509Certificate2[] certificateChain, TreeNode treeNode)
        {
            treeNode.Expand();
            for (int j = certificateChain.Length - 1; j >= 0; j--)
            {
                treeNode.Nodes.Add(ConvertCertificateToString(certificateChain[j]));
                treeNode.Nodes[0].Tag = certificateChain[j];
                treeNode = treeNode.Nodes[0];
                treeNode.Expand();
            }
        }

        /// <summary>
        /// Converts the certificate to string.
        /// </summary>
        /// <param name="certificate">The certificate.</param>
        private string ConvertCertificateToString(X509Certificate2 certificate)
        {
            string email = certificate.GetNameInfo(X509NameType.EmailName, false);
            if (email != "")
                return string.Format("{0} <{1}>", certificate.GetNameInfo(X509NameType.SimpleName, false), email);
            else
                return certificate.GetNameInfo(X509NameType.SimpleName, false);
        }

        /// <summary>
        /// Handles the NodeMouseClick event of the signaturesTreeView control.
        /// </summary>
        private void signaturesTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Node.Tag is X509Certificate2)
                    X509Certificate2UI.DisplayCertificate((X509Certificate2)e.Node.Tag, this.Handle);
            }
        }

        /// <summary>
        /// Handles the AfterSelect event of the signaturesTreeView control.
        /// </summary>
        private void signaturesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateUI();
        }


        #endregion


    }
}
