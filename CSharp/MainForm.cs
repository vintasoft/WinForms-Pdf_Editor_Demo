using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.Codecs.ImageFiles;
using Vintasoft.Imaging.Processing;
using Vintasoft.Imaging.Spelling;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.UIActions;
using Vintasoft.Imaging.Utils;
using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.Fonts;
#if !REMOVE_OCR_PLUGIN
using Vintasoft.Imaging.Ocr.Tesseract;
using Vintasoft.Imaging.Ocr;
#endif
using Vintasoft.Imaging.ImageProcessing.Info;

#if !REMOVE_ANNOTATION_PLUGIN
using Vintasoft.Imaging.Annotation.Comments;
using Vintasoft.Imaging.Annotation.Comments.Pdf;
using Vintasoft.Imaging.Annotation.UI.VisualTools;
using Vintasoft.Imaging.Annotation.UI.Comments;
#endif

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.JavaScript;
using Vintasoft.Imaging.Pdf.JavaScriptApi;
using Vintasoft.Imaging.Pdf.Processing;
using Vintasoft.Imaging.Pdf.Processing.Analyzers;
using Vintasoft.Imaging.Pdf.Processing.BasicTypes;
using Vintasoft.Imaging.Pdf.Processing.PdfA;
using Vintasoft.Imaging.Pdf.Processing.Fonts;
using Vintasoft.Imaging.Pdf.Processing.Images;
using Vintasoft.Imaging.Pdf.Security;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.FileAttachments;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;
using Vintasoft.Imaging.Pdf.UI;
using Vintasoft.Imaging.Pdf.UI.Annotations;
#if !REMOVE_OCR_PLUGIN
using Vintasoft.Imaging.Pdf.Ocr;
#endif

using DemosCommonCode;
using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Imaging.Codecs.Dialogs;
using DemosCommonCode.Imaging.ColorManagement;
using DemosCommonCode.Pdf;
using DemosCommonCode.Pdf.JavaScript;
using DemosCommonCode.Pdf.Security;
using DemosCommonCode.Spelling;
using DemosCommonCode.Annotation;
using DemosCommonCode.Ocr;

namespace PdfEditorDemo
{
    /// <summary>
    /// Main form of PDF Editor Demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Fields

        /// <summary>
        /// Title format string of main form.
        /// </summary>
        string _titleFormatString = "VintaSoft PDF Editor Demo v" + ImagingGlobalSettings.ProductVersion + " {0}";

        /// <summary>
        /// A value indicating whether demo shoud update UI when UpdateUI method is called.
        /// </summary>
        bool _isUpdateUIEnabled = true;

        /// <summary>
        /// Default image viewer display mode.
        /// </summary>
        ImageViewerDisplayMode _defaultImageViewerDisplayMode;

        /// <summary>
        /// Selected "View - Image scale mode" menu item.
        /// </summary>
        ToolStripMenuItem _imageScaleSelectedMenuItem;

        /// <summary>
        /// Opened PDF document.
        /// </summary>
        PdfDocument _document;
        /// <summary>
        /// The name of file, which stores a PDF document.
        /// </summary>
        string _pdfFileName;
        /// <summary>
        /// The stream, which stores a PDF document.
        /// </summary>
        Stream _pdfFileStream;

        /// <summary>
        /// The stream, where a PDF document must be saved.
        /// </summary>
        Stream _newFileStream;
        /// <summary>
        /// PDF encoder settings.
        /// </summary>
        PdfEncoderSettings _pdfEncoderSettings;
        /// <summary>
        /// A value indicating whether the encoder setting, which are specified in _pdfEncoderSettings field,
        /// must be applied to all saving images.
        /// </summary>
        bool _usePdfEncoderSettingsForAllImages = false;
        /// <summary>
        /// A value indicating whether PDF file stream must be switched to the new file stream after save.
        /// </summary>
        bool _switchPdfFileStreamToNewStream = false;

        /// <summary>
        /// Action name.
        /// </summary>
        string _actionName = "";
        /// <summary>
        /// The start time of action.
        /// </summary>
        DateTime _actionStartTime;

        /// <summary>
        /// The visual tool for searching and selecting of text on PDF page.
        /// </summary>
        TextSelectionTool _textSelectionTool;

        /// <summary>
        /// The visual tool for cropping a PDF page or an image in image viewer.
        /// </summary>
        PdfCropSelectionTool _cropSelectionTool;

        /// <summary>
        /// The visual tool for editing content of PDF page.
        /// </summary>
        PdfContentEditorTool _contentEditorTool;

        /// <summary>
        /// The composite visual tool for editing content of PDF page.
        /// </summary>
        CompositeVisualTool _contentEditorToolComposition;

        /// <summary>
        /// The visual tool for removing and blacking out content of PDF page.
        /// </summary>
        PdfRemoveContentTool _removeContentTool;

        /// <summary>
        /// The visual tool for redaction content of PDF page.
        /// </summary>
        CompositeVisualTool _redactionTool;

        /// <summary>
        /// The visual tool for viewing, filling and editing PDF annotations and PDF interactive fields.
        /// </summary>
        PdfAnnotationTool _annotationTool;

        /// <summary>
        /// The composite visual tool that combines functionality of annotation tool and
        /// text selection tool.
        /// </summary>
        CompositeVisualTool _defaultAnnotationTool;

        /// <summary>
        /// The visual tool for text markup (highlight, undeline, strikeout...).
        /// </summary>
        PdfTextMarkupTool _textMarkupTool;

        /// <summary>
        /// Size of empty PDF page.
        /// </summary>
        SizeF _emptyPageSize;
        /// <summary>
        /// Units of empty PDF page.
        /// </summary>
        UnitOfMeasure _emptyPageUnits = UnitOfMeasure.Centimeters;

        /// <summary>
        /// ThumbnailViewer print manager.
        /// </summary>
        ImageViewerPrintManager _thumbnailViewerPrintManager;

        /// <summary>
        /// The signature appearance.
        /// </summary>
        SignatureAppearanceGraphicsFigure _signatureAppearance;

        /// <summary>
        /// The redaction mark appearance.
        /// </summary>
        RedactionMarkAppearanceGraphicsFigure _redactionMarkAppearance;

        /// <summary>
        /// The PDF content custom renderer.
        /// </summary>
        CustomContentRenderer _pdfCustomContentRenderer = new CustomContentRenderer();

        /// <summary>
        /// The text encoding obfuscator.
        /// </summary>
        PdfTextEncodingObfuscator _textEncodingObfuscator = new PdfTextEncodingObfuscator();
        /// <summary>
        /// The selected PDF pages for text encoding obfuscation.
        /// </summary>
        PdfPage[] _pagesForObfuscation;

        /// <summary>
        /// The JavaScript debugger form.
        /// </summary>
        PdfJavaScriptDebuggerForm _javaScriptDebuggerForm;

        /// <summary>
        /// A value indicating whether demo must show error message with information about missing CJK font.
        /// </summary>
        bool _isCJKFontMissingErrorMessageShown = false;

        /// <summary>
        /// The comment visual tool.
        /// </summary>
#if !REMOVE_ANNOTATION_PLUGIN
        CommentVisualTool _commentTool;
#endif

#if !REMOVE_OCR_PLUGIN        
        /// <summary>
        /// The tesseract OCR.
        /// </summary>
        TesseractOcr _tesseract;

        /// <summary>
        /// Dictionary: <see cref="PdfPageCreationMode"/> => <see cref="SearchablePdfGenerator"/>.
        /// </summary>
        Dictionary<PdfPageCreationMode, SearchablePdfGenerator> _pdfPageCreationModeToGenerator =
            new Dictionary<PdfPageCreationMode, SearchablePdfGenerator>();
#endif

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            if (DesignMode || ImagingEnvironment.IsInDesignMode)
                return;

#if !REMOVE_OFFICE_PLUGIN
            PdfOfficeUIAssembly.Init();
#endif

            Jbig2AssemblyLoader.Load();
            Jpeg2000AssemblyLoader.Load();
            DocxAssemblyLoader.Load();

            ImagingTypeEditorRegistrator.Register();

            _signatureAppearance = new SignatureAppearanceGraphicsFigure();

            resolutionToolStrip1.ImageViewer = imageViewer1;

            // specify that exceptions of visual tools must be catched
            DemosTools.CatchVisualToolExceptions(imageViewer1);

            // enable PDF Password Dialog
            PdfAuthenticateTools.EnableAuthenticateRequest = true;

            // set CustomFontProgramsController for all opened documents
            CustomFontProgramsController.SetDefaultFontProgramsController();

            // generate interactive form fields appearance if need
            PdfDemosTools.NeedGenerateInteractiveFormFieldsAppearance = true;

            // init "View => Image Display Mode" menu
            singlePageToolStripMenuItem.Tag = ImageViewerDisplayMode.SinglePage;
            twoColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoColumns;
            singleContinuousRowToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousRow;
            singleContinuousColumnToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousColumn;
            twoContinuousRowsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousRows;
            twoContinuousColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousColumns;

            // init "View => Image Scale Mode" menu
            normalImageToolStripMenuItem.Tag = ImageSizeMode.Normal;
            bestFitToolStripMenuItem.Tag = ImageSizeMode.BestFit;
            fitToWidthToolStripMenuItem.Tag = ImageSizeMode.FitToWidth;
            fitToHeightToolStripMenuItem.Tag = ImageSizeMode.FitToHeight;
            pixelToPixelToolStripMenuItem.Tag = ImageSizeMode.PixelToPixel;
            scaleToolStripMenuItem.Tag = ImageSizeMode.Zoom;
            scale25ToolStripMenuItem.Tag = 25;
            scale50ToolStripMenuItem.Tag = 50;
            scale100ToolStripMenuItem.Tag = 100;
            scale200ToolStripMenuItem.Tag = 200;
            scale400ToolStripMenuItem.Tag = 400;
            _imageScaleSelectedMenuItem = normalImageToolStripMenuItem;
            _imageScaleSelectedMenuItem.Checked = true;

            // init menu
            InitMenu();

            // init dialogs
            InitDialogs();

            // init visual tools
            InitVisualTools();

            // init PDF action executors
            InitPdfActionExecutors();

#if !REMOVE_OFFICE_PLUGIN && !REMOVE_PDFVISUALEDITOR_PLUGIN
            DemosCommonCode.Office.OfficeDocumentVisualEditorForm documentVisualEditorForm = new DemosCommonCode.Office.OfficeDocumentVisualEditorForm();
            documentVisualEditorForm.Owner = this;
            documentVisualEditorForm.AddVisualTool(_contentEditorTool);
            documentVisualEditorForm.AddVisualTool(_annotationTool);
#endif

#if !REMOVE_ANNOTATION_PLUGIN
            MeasurementVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
#endif
            ZoomVisualToolActionFactory.CreateActions(visualToolsToolStrip1);

            // initialize visual tool actions
            InitializeVisualToolActions();


            // set "Pages" tab as selected tab
            toolsTabControl.SelectedTab = pagesTabPage;

            // set ThumbnailFlowStyle to SingleColumn
            thumbnailViewer1.ThumbnailFlowStyle = ThumbnailFlowStyle.SingleColumn;

            // set ThumbnailSize
            thumbnailViewer1.ThumbnailSize = new Size(128, 128);

            // set ThumbnailCaption properties
            thumbnailViewer1.ThumbnailCaption.Anchor = AnchorType.Bottom;
            thumbnailViewer1.ThumbnailCaption.CaptionFormat = "{PageLabel}";
            thumbnailViewer1.ThumbnailCaption.IsVisible = true;
            thumbnailViewer1.ThumbnailImagePadding = new PaddingF(0, 0, 0, 18);

            // subscribe to the events of image collection of image viewer
            imageViewer1.Images.ImageCollectionSavingProgress += new EventHandler<ProgressEventArgs>(Images_ImageCollectionSavingProgress);


            // create PDF rendering settings
            PdfRenderingSettings renderingSettings = new PdfRenderingSettings();
            // show all annotations
            renderingSettings.DrawPdfAnnotations = true;
            renderingSettings.DrawVintasoftAnnotations = true;
#if REMOVE_OFFICE_PLUGIN
            // set PDF rendering settings as image viewer settings
            imageViewer1.ImageRenderingSettings = renderingSettings;
#else
            imageViewer1.ImageRenderingSettings = new CompositeRenderingSettings(renderingSettings, new DocxRenderingSettings());
#endif

            // image viewer must use the image appearances in single-page and multi-page modes
            imageViewer1.UseImageAppearancesInSinglePageMode = true;

            // set ViewerBufferSize to 32 MPX
            imageViewer1.ViewerBufferSize = 32;

            // set the default image viewer display mode
            _defaultImageViewerDisplayMode = imageViewer1.DisplayMode;

            // set default params
            resolutionToolStrip1.UseDynamicRendering = true;

            // specify the default size for new (empty) page
            _emptyPageSize = new SizeF();
            _emptyPageSize.Width = PdfPage.ConvertFromUnitOfMeasureToUserUnits(210, UnitOfMeasure.Millimeters);
            _emptyPageSize.Height = PdfPage.ConvertFromUnitOfMeasureToUserUnits(297, UnitOfMeasure.Millimeters);


            // create PDF encoder settings
            _pdfEncoderSettings = new PdfEncoderSettings();


            // create the print manager
            _thumbnailViewerPrintManager = new ImageViewerPrintManager(
            thumbnailViewer1, imagePrintDocument, printDialog);
            _thumbnailViewerPrintManager.PrintDocument.UseImageAutoOrienation = true;
            _thumbnailViewerPrintManager.PrintDocument.Center = true;
            pageAutoOrientationToolStripMenuItem.Checked = _thumbnailViewerPrintManager.PrintDocument.UseImageAutoOrienation;
            centerPrintingPageToolStripMenuItem.Checked = _thumbnailViewerPrintManager.PrintDocument.Center;

#if REMOVE_ANNOTATION_PLUGIN
            toolsTabControl.TabPages.Remove(commentsTabPage);
#endif

#if REMOVE_PDFVISUALEDITOR_PLUGIN
            toolsTabControl.TabPages.Remove(contentEditorTabPage);
            addSelectedTextToRedactionMarksToolStripMenuItem.Visible = false;
#endif

            // initialize color management in viewer
            ColorManagementHelper.EnableColorManagement(imageViewer1);

            // update UI
            UpdateUI();

            imageViewer1.Focus();

            imageViewer1.Images.ImageSavingException += Images_ImageSavingException;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        /// <param name="filename">The name of file, which must be opened when form is shown.</param>
        public MainForm(string filename)
            : this()
        {
            _pdfFileName = filename;
        }

        #endregion



        #region Properties

        string _tesseractOcrDllDirectory = null;
        /// <summary>
        /// Gets a directory where Tesseract5.Vintasoft.xXX.dll is located.
        /// </summary>
        public string TesseractOcrDllDirectory
        {
            get
            {
                if (_tesseractOcrDllDirectory == null)
                {
                    // Tesseract OCR dll filename
                    string dllFilename;
                    // if is 64-bit system then
                    if (IntPtr.Size == 8)
                        dllFilename = "Tesseract5.Vintasoft.x64.dll";
                    else
                        dllFilename = "Tesseract5.Vintasoft.x86.dll";

                    string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);

                    // search directories
                    string[] directories = new string[]
                    {
                        "",
                        @"..\TesseractOCR\",
                        @"..\..\TesseractOCR\",
                        @"..\..\..\..\Bin\TesseractOCR\",
                        @"..\..\..\..\..\Bin\TesseractOCR\",
                        @"..\..\..\..\..\..\..\Bin\TesseractOCR\"
                    };

                    // search tesseract dll
                    foreach (string dir in directories)
                    {
                        string dllDirectory = Path.Combine(currentDirectory, dir);
                        if (File.Exists(Path.Combine(dllDirectory, dllFilename)))
                        {
                            _tesseractOcrDllDirectory = dllDirectory;
                            break;
                        }
                    }
                    if (_tesseractOcrDllDirectory == null)
                        _tesseractOcrDllDirectory = currentDirectory;
                    else
                        _tesseractOcrDllDirectory = Path.GetFullPath(_tesseractOcrDllDirectory);
                }
                return _tesseractOcrDllDirectory;
            }
        }

        /// <summary>
        /// Gets or sets a filename of PDF document.
        /// </summary>
        internal string Filename
        {
            get
            {
                return _pdfFileName;
            }
            set
            {
                _pdfFileName = value;
                UpdateUI();
            }
        }

        bool _isPdfFileOpening = false;
        /// <summary>
        /// Gets or sets a value indicating whether PDF document is opening.
        /// </summary>
        internal bool IsPdfFileOpening
        {
            get
            {
                return _isPdfFileOpening;
            }
            set
            {
                if (!value)
                    _isUpdateUIEnabled = true;

                _isPdfFileOpening = value;

                UpdateUI();

                if (value)
                    _isUpdateUIEnabled = false;
            }
        }

        bool _isPdfFileReadOnlyMode = false;
        /// <summary>
        /// Gets or sets a value indicating whether PDF document is opened in read-only mode.
        /// </summary>
        internal bool IsPdfFileReadOnlyMode
        {
            get
            {
                return _isPdfFileReadOnlyMode;
            }
            set
            {
                _isPdfFileReadOnlyMode = value;
                UpdateUI();
            }
        }

        /// <summary>
        /// Gets the PDF page associated with image loaded in image viewer.
        /// </summary>
        internal PdfPage FocusedPage
        {
            get
            {
                if (imageViewer1.Image == null)
                    return null;
                return PdfDocumentController.GetPageAssociatedWithImage(imageViewer1.Image);
            }
        }

        /// <summary>
        /// Gets or sets the current visual tool.
        /// </summary>
        internal VisualTool CurrentTool
        {
            get
            {
                return imageViewer1.VisualTool;
            }
            set
            {
                imageViewer1.VisualTool = value;
            }
        }

        bool _isTextSearching = false;
        /// <summary>
        /// Gets or sets a value indicating whether text search is in progress.
        /// </summary>
        internal bool IsTextSearching
        {
            get
            {
                return _isTextSearching;
            }
            set
            {
                _isTextSearching = value;
                UpdateUI();
            }
        }

        bool _isDocumentChanged = false;
        /// <summary>
        /// Gets or sets a value indicating whether PDF document is changed.
        /// </summary>
        internal bool IsDocumentChanged
        {
            get
            {
                return _isDocumentChanged;
            }
            set
            {
                _isDocumentChanged = value;
                UpdateUIAsync();
            }
        }

        bool _isPdfFileSaving = false;
        /// <summary>
        /// Gets or sets a value indicating whether PDF document is saving.
        /// </summary>
        internal bool IsPdfFileSaving
        {
            get
            {
                return _isPdfFileSaving;
            }
            set
            {
                _isPdfFileSaving = value;
                UpdateUIAsync();
            }
        }

        PdfInteractionAreaAppearanceManager _interactionAreaSettings = null;
        /// <summary>
        /// The interaction area manager.
        /// </summary>
        internal PdfInteractionAreaAppearanceManager InteractionAreaSettings
        {
            get
            {
                if (_interactionAreaSettings == null)
                    _interactionAreaSettings = new PdfInteractionAreaAppearanceManager();

                return _interactionAreaSettings;
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Raises the <see cref="Control.OnKeyDown"/> event.
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (imageViewer1.Focused)
            {
                UIAction uiAction = null;

                if (e.Modifiers == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.X:
                            uiAction = PdfDemosTools.GetUIAction<CutItemUIAction>(CurrentTool);
                            break;

                        case Keys.C:
                            uiAction = PdfDemosTools.GetUIAction<CopyItemUIAction>(CurrentTool);
                            break;

                        case Keys.V:
                            uiAction = PdfDemosTools.GetUIAction<PasteItemUIAction>(CurrentTool);
                            break;

                        case Keys.A:
                            uiAction = PdfDemosTools.GetUIAction<SelectAllItemsUIAction>(CurrentTool);
                            break;
                    }
                }
                else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Delete)
                {
                    uiAction = PdfDemosTools.GetUIAction<DeleteItemUIAction>(CurrentTool);
                }

                if (uiAction != null)
                {
                    uiAction.Execute();
                    e.Handled = true;
                }
            }

            base.OnKeyDown(e);
        }

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// <b>true</b> if the character was processed by the control; otherwise, <b>false</b>.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (imageViewer1.Focused && imageViewer1.VisualTool != null)
            {
                if (keyData == Keys.Tab)
                {
                    if (imageViewer1.VisualTool.PerformNextItemSelection(true))
                        return true;
                }
                else if (keyData == (Keys.Shift | Keys.Tab))
                {
                    if (imageViewer1.VisualTool.PerformNextItemSelection(false))
                        return true;
                }
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.Add))
            {
                RotateViewClockwise();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.Subtract))
            {
                RotateViewCounterClockwise();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Main form is closed.
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (_interactionAreaSettings != null)
                _interactionAreaSettings.Dispose();

            if (_annotationTool.SpellChecker != null)
            {
                SpellCheckManager manager = _annotationTool.SpellChecker;
                _annotationTool.SpellChecker = null;
                SpellCheckTools.DisposeSpellCheckManagerAndEngines(manager);
            }

#if !REMOVE_OCR_PLUGIN
            if (_tesseract != null)
            {
                _tesseract.Dispose();
                _tesseract = null;
            }
#endif
        }

        #endregion


        #region PRIVATE

        #region Main Form

        /// <summary>
        /// Main form is shown.
        /// </summary>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            // process command line of the application
            string[] appArgs = Environment.GetCommandLineArgs();
            if (appArgs.Length > 0)
            {
                Application.DoEvents();
                if (appArgs.Length == 2)
                {
                    try
                    {
                        OpenPdfDocument(appArgs[1]);
                    }
                    catch
                    {
                        ClosePdfDocument();
                    }
                }
            }
        }

        /// <summary>
        /// Main form is closing.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosePdfDocument();
        }

        #endregion


        #region Init

        /// <summary>
        /// Initializes the menu.
        /// </summary>
        private void InitMenu()
        {
            // add available PdfDocumentViewMode to the "Document" menu
            pageModeComboBox.Items.AddRange(Enum.GetNames(typeof(PdfDocumentViewMode)));

            // add available PdfDocumentPageLayoutMode to the "Document" menu
            viewerPageLayoutToolStripComboBox.Items.AddRange(Enum.GetNames(typeof(PdfDocumentPageLayoutMode)));
        }

        /// <summary>
        /// Initializes the dialogs.
        /// </summary>
        private void InitDialogs()
        {
            // set filters in open dialog
            CodecsFileFilters.SetOpenFileDialogFilter(openImageFileDialog);

            // set the initial directory in open dialog
            DemosTools.SetTestFilesFolder(openImageFileDialog);
            DemosTools.SetTestFilesFolder(openPdfFileDialog);

            // set filters in save dialog
            CodecsFileFilters.SetSaveFileDialogFilter(saveImageFileDialog, false, false);
        }

        /// <summary>
        /// Initializes the visual tools.
        /// </summary>
        private void InitVisualTools()
        {
            // create PdfTextSelectionTool
            _textSelectionTool = new TextSelectionTool(new SolidBrush(Color.FromArgb(56, Color.Blue)));
            _textSelectionTool.TextSearchingProgress += new EventHandler<TextSearchingProgressEventArgs>(_testSelectionTool_TextSearchingProgress);
            _textSelectionTool.SelectionChanged += new EventHandler(_textSelectionTool_SelectionChanged);
            _textSelectionTool.IsMouseSelectionEnabled = true;
            _textSelectionTool.IsKeyboardSelectionEnabled = true;
            pdfTextSelectionControl1.TextSelectionTool = _textSelectionTool;
            findTextToolStrip1.TextSelectionTool = _textSelectionTool;

            // create PdfTextMarkupTool
            _textMarkupTool = new PdfTextMarkupTool();
            _textMarkupTool.Enabled = false;
            _textMarkupTool.MarkupAnnotationCreated += TextMarkupTool_MarkupAnnotationCreated;
            _textMarkupTool.MarkupAnnotationAdded += TextMarkupTool_MarkupAnnotationAdded;

#if !REMOVE_PDFVISUALEDITOR_PLUGIN
            // create PdfContentEditorTool
            _contentEditorTool = new PdfContentEditorTool();
            _contentEditorTool.RenderFiguresWhenImageIndexChanging = false;
            _contentEditorTool.RenderFiguresWhenDeactivating = true;
            pdfContentEditorControl1.ContentEditorTool = _contentEditorTool;
            _contentEditorToolComposition = new CompositeVisualTool(
#if !REMOVE_OFFICE_PLUGIN
                new Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction.OfficeDocumentVisualEditorTextTool(),
#endif
                _contentEditorTool
            );

            // create PdfRemoveContentTool
            _removeContentTool = new PdfRemoveContentTool();
            _redactionMarkAppearance = new RedactionMarkAppearanceGraphicsFigure();
            _redactionMarkAppearance.FillColor = Color.Black;
            _redactionMarkAppearance.TextColor = Color.Red;
            _redactionMarkAppearance.AutoFontSize = true;
            _redactionMarkAppearance.Text = null;
            _removeContentTool.RedactionMarkAppearance = _redactionMarkAppearance;
            pdfRemoveContentControl1.RemoveContentTool = _removeContentTool;
            pdfRemoveContentControl1.TextSelectionTool = _textSelectionTool;
            pdfRemoveContentControl1.ThumbnailViewer = thumbnailViewer1;
            pdfRemoveContentControl1.RedactionMarkApplied += new EventHandler(pdfRemoveContentControl1_RedactionMarkApplied);
            _redactionTool = new CompositeVisualTool(_removeContentTool, _textSelectionTool);
#endif

            // create PDF annotation tool
#if !REMOVE_PDFVISUALEDITOR_PLUGIN
            _annotationTool = new PdfAnnotationTool(PdfJavaScriptManager.JsApp, true);
            _annotationTool.InteractionMode = PdfAnnotationInteractionMode.Markup;
#else
            _annotationTool = new PdfAnnotationTool(PdfJavaScriptManager.JsApp, false);
            _annotationTool.InteractionMode = PdfAnnotationInteractionMode.View;
#endif
            _annotationTool.ChangeFocusedItemBeforeInteraction = true;
            _annotationTool.HoveredAnnotationChanged += new EventHandler<PdfAnnotationEventArgs>(AnnotationTool_HoveredAnnotationChanged);
            _annotationTool.InteractiveFormEditorManager.UseUniqueAnnotationName = true;
            _annotationTool.InteractiveFormEditorManager.UseUniqueFieldName = true;
            _annotationTool.InteractionModeChanged += new PropertyChangedEventHandler<PdfAnnotationInteractionMode>(AnnotationTool_InteractionModeChanged);
            _annotationTool.ActiveInteractionControllerChanged += new PropertyChangedEventHandler<IInteractionController>(AnnotationTool_ActiveInteractionControllerChanged);
            _annotationTool.FocusedAnnotationViewChanged += new EventHandler<PdfAnnotationViewChangedEventArgs>(AnnotationTool_FocusedAnnotationViewChanged);

#if !REMOVE_ANNOTATION_PLUGIN
            // create comment visual tool
            ImageViewerCommentController commentController = new ImageViewerCommentController(new ImageCollectionPdfAnnotationCommentController());
            _commentTool = new CommentVisualTool(commentController, new CommentControlFactory());

            annotationToolControl.CommentTool = _commentTool;

            _commentTool.SelectCommentControlOnMouseDoubleClick = true;
            commentsControl.CommentController = commentController;
            commentsControl.CommentTool = _commentTool;
            commentsControl.AnnotationTool = _annotationTool;
#endif
            _annotationTool.IsNavigationLoopedOnFocusedPage = false;
            _annotationTool.SpellChecker = SpellCheckTools.CreateSpellCheckManager();
            annotationToolControl.AnnotationTool = _annotationTool;
            InteractionAreaSettings.VisualTool = _annotationTool;


#if !REMOVE_ANNOTATION_PLUGIN
            // create composite tool: Comment tool + PDF Annotation tool + Text Selection tool + PDF Text Markup Tool
            _defaultAnnotationTool = new CompositeVisualTool(_commentTool,
#if !REMOVE_OFFICE_PLUGIN
                new Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction.OfficeDocumentVisualEditorTextTool(),
#endif
                _annotationTool, _textSelectionTool, _textMarkupTool);
#else
            // create composite tool: PDF Annotation tool + Text Selection tool + PDF Text Markup Tool
            _defaultAnnotationTool = new CompositeVisualTool(
#if !REMOVE_OFFICE_PLUGIN
                new Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction.OfficeDocumentVisualEditorTextTool(),
#endif
            _annotationTool, _textSelectionTool, _textMarkupTool);
#endif

#if !REMOVE_PDFVISUALEDITOR_PLUGIN
            // create PDF crop selection tool
            _cropSelectionTool = new PdfCropSelectionTool();
            _cropSelectionTool.SelectionOnlyOnImage = false;
#endif
        }


        /// <summary>
        /// Initializes the PDF action executors.
        /// </summary>
        private void InitPdfActionExecutors()
        {
            // enable JavaScript
            PdfJavaScriptManager.IsJavaScriptEnabled = true;
            enableJavaScriptExecutingToolStripMenuItem.Checked = PdfJavaScriptManager.IsJavaScriptEnabled;
            // register image viewer in JavaScript manager
            if (PdfJavaScriptManager.JsApp != null)
                PdfJavaScriptManager.JsApp.RegisterImageViewer(imageViewer1);
            PdfJavaScriptManager.JavaScriptActionExecutor.StatusChanged +=
                new EventHandler<PdfJavaScriptActionStatusChangedEventArgs>(JavaScriptActionExecutor_StatusChanged);

            // initialize global action executor, using "Print" and "SaveAs" action handlers
            PdfActionExecutorManager.Initialize(
                imageViewer1,
                _annotationTool,
                new PdfViewerNamedAction("Print", Print),
                new PdfViewerNamedAction("SaveAs", SavePdfDocumentAs));

            PdfDocumentLevelActionsExecutor documentLevelActionsExecutor;
            if (PdfJavaScriptManager.JsApp != null)
            {
                // create document-level actions executor
                documentLevelActionsExecutor = new PdfDocumentLevelActionsExecutor(PdfJavaScriptManager.JsApp);

                // set action executor for PdfDocumentLevelActionsExecutor to application action executor
                documentLevelActionsExecutor.ActionExecutor = PdfActionExecutorManager.ApplicationActionExecutor;
            }

            // set action executor for PdfAnnotationTool to application action executor
            _annotationTool.ActionExecutor = PdfActionExecutorManager.ApplicationActionExecutor;

            // set action executor for BookmarkTreeView to application action executor
            documentBookmarks.ActionExecutor = PdfActionExecutorManager.ApplicationActionExecutor;
        }

        /// <summary>
        /// Initializes the visual tool actions.
        /// </summary>
        private void InitializeVisualToolActions()
        {
            visualToolsToolStrip1.AddAction(new SeparatorToolStripAction());

            VisualToolAction textSelectionAndFillFormsAction = new VisualToolAction(
                _defaultAnnotationTool,
                "Text Selection / Commentation / Fill Forms",
                "Text Selection, Navigation, Commentation, Fill Forms",
                DemosResourcesManager.GetResourceAsBitmap("TextSelectionFillForms.png"));
            textSelectionAndFillFormsAction.Activated += new EventHandler(TextSelectionAndFillFormsAction_Executed);
            visualToolsToolStrip1.AddAction(textSelectionAndFillFormsAction);
            textSelectionAndFillFormsAction.Activate();

            VisualToolAction textSelectionAction = new VisualToolAction(
                _textSelectionTool,
                "Text Selection",
                "Text Selection",
                DemosResourcesManager.GetResourceAsBitmap("TextExtraction.png"));
            textSelectionAction.Activated += new EventHandler(TextSelectionAction_Executed);
            visualToolsToolStrip1.AddAction(textSelectionAction);


            VisualToolAction annotationToolEditAnnotationsAction = new VisualToolAction(
                "Edit Annotations",
                "Edit Annotations",
                null,
                false);
            annotationToolEditAnnotationsAction.Clicked += new EventHandler(annotationToolEditAnnotationsAction_Clicked);
            VisualToolAction annotationToolEditFormFieldsAction = new VisualToolAction(
                "Edit Form Fields",
                "Edit Interctive Form Fields",
                null,
                false);
            annotationToolEditFormFieldsAction.Clicked += new EventHandler(annotationToolEditFormFieldsAction_Clicked);
            VisualToolAction annotationToolAction = new VisualToolAction(
                new CompositeVisualTool(
#if !REMOVE_OFFICE_PLUGIN
                new Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction.OfficeDocumentVisualEditorTextTool(),
#endif
                    _annotationTool),
                "Interactive Forms / Annotations",
                "Edit Interactive Forms and Annotations",
                DemosResourcesManager.GetResourceAsBitmap("EditInteractiveForms.png"),
                annotationToolEditAnnotationsAction,
                annotationToolEditFormFieldsAction);
            annotationToolAction.Activated += new EventHandler(AnnotationToolAction_Executed);
            visualToolsToolStrip1.AddAction(annotationToolAction);

#if !REMOVE_PDFVISUALEDITOR_PLUGIN
            VisualToolAction contentEditorToolAction = new VisualToolAction(
               _contentEditorToolComposition,
               "Content Editor",
               "Edit Page Content",
               DemosResourcesManager.GetResourceAsBitmap("ContentEditor.png"));
            contentEditorToolAction.Activated += new EventHandler(ContentEditorToolAction_Executed);
            visualToolsToolStrip1.AddAction(contentEditorToolAction);

            VisualToolAction removeContentToolAction = new VisualToolAction(
               _redactionTool,
               "Remove Content",
               "Remove Content & Black Out",
               DemosResourcesManager.GetResourceAsBitmap("RemoveContent.png"));
            removeContentToolAction.Activated += new EventHandler(RemoveContentToolAction_Executed);
            visualToolsToolStrip1.AddAction(removeContentToolAction);

            VisualToolAction cropSelectionToolAction = new VisualToolAction(
               _cropSelectionTool,
               "Crop Selection",
               "Crop Selection",
               DemosResourcesManager.GetResourceAsBitmap("CropSelection.png"));
            visualToolsToolStrip1.AddAction(cropSelectionToolAction);
#endif
            visualToolsToolStrip1.AddAction(new SeparatorToolStripAction());

            string annotationResourceNameFormatString = "{0}.png";

            VisualToolAction highlightTextToolAction = new VisualToolAction(
               _defaultAnnotationTool,
               "Highlight Text",
               "Markup text using Highlight text markup annotation",
               DemosResourcesManager.GetResourceAsBitmap(string.Format(annotationResourceNameFormatString, "Highlight")));
            visualToolsToolStrip1.AddAction(highlightTextToolAction);
            highlightTextToolAction.Activated += HighlightTextToolAction_Activated;
            highlightTextToolAction.Deactivated += TextMarkupToolAction_Deactivated;
            highlightTextToolAction.ShowSettings += MarkupTextToolAction_ShowSettings;

            VisualToolAction strikeoutTextToolAction = new VisualToolAction(
               _defaultAnnotationTool,
               "Strikeout Text",
               "Markup text using Strikeout text markup annotation",
               DemosResourcesManager.GetResourceAsBitmap(string.Format(annotationResourceNameFormatString, "Strikeout")));
            visualToolsToolStrip1.AddAction(strikeoutTextToolAction);
            strikeoutTextToolAction.Activated += StrikeoutTextToolAction_Activated;
            strikeoutTextToolAction.Deactivated += TextMarkupToolAction_Deactivated;
            strikeoutTextToolAction.ShowSettings += MarkupTextToolAction_ShowSettings;

            VisualToolAction underlineTextToolAction = new VisualToolAction(
               _defaultAnnotationTool,
               "Underline Text",
               "Markup text using Underline text markup annotation",
               DemosResourcesManager.GetResourceAsBitmap(string.Format(annotationResourceNameFormatString, "Underline")));
            visualToolsToolStrip1.AddAction(underlineTextToolAction);
            underlineTextToolAction.Activated += UnderlineTextToolAction_Activated;
            underlineTextToolAction.Deactivated += TextMarkupToolAction_Deactivated;
            underlineTextToolAction.ShowSettings += MarkupTextToolAction_ShowSettings;

            VisualToolAction squigglyTextToolAction = new VisualToolAction(
              _defaultAnnotationTool,
              "Squiggly Underline Text",
              "Markup text using Squiggly underline text markup annotation",
              DemosResourcesManager.GetResourceAsBitmap(string.Format(annotationResourceNameFormatString, "Squiggly")));
            visualToolsToolStrip1.AddAction(squigglyTextToolAction);
            squigglyTextToolAction.Activated += SquigglyTextToolAction_Activated;
            squigglyTextToolAction.Deactivated += TextMarkupToolAction_Deactivated;
            squigglyTextToolAction.ShowSettings += MarkupTextToolAction_ShowSettings;

            VisualToolAction caretTextToolAction = new VisualToolAction(
              _defaultAnnotationTool,
              "Insert Text Caret Annotation",
              "Insert Text Caret Annotation under cursor position",
              DemosResourcesManager.GetResourceAsBitmap(string.Format(annotationResourceNameFormatString, "Caret")));
            visualToolsToolStrip1.AddAction(caretTextToolAction);
            caretTextToolAction.Activated += CaretTextToolAction_Activated;
            caretTextToolAction.Deactivated += TextMarkupToolAction_Deactivated;
            caretTextToolAction.ShowSettings += MarkupTextToolAction_ShowSettings;
        }

        #endregion


        #region UI state

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            if (!_isUpdateUIEnabled)
                return;

            // get the current status of application

            bool isPdfFileOpening = IsPdfFileOpening;
            bool isPdfFileLoaded = _document != null;
            bool isPdfFileReadOnlyMode = IsPdfFileReadOnlyMode;
            bool isPdfFileEmpty = true;
            bool isDocumentChanged = IsDocumentChanged;
            if (_contentEditorTool != null)
            {
                if (_contentEditorTool.FigureViewCollection.Count > 0)
                    isDocumentChanged = true;
            }
            bool isPdfFileSaving = IsPdfFileSaving;
            bool isTextSearching = IsTextSearching;

            if (isPdfFileLoaded)
                isPdfFileEmpty = imageViewer1.Images.Count <= 0;


            // "File" menu

            fileToolStripMenuItem.Enabled = !isPdfFileOpening && !isPdfFileSaving && !isTextSearching;

            closeToolStripMenuItem.Enabled = isPdfFileLoaded;
            addImagePagesToolStripMenuItem.Enabled = isPdfFileLoaded;
            addOcrPagesToolStripMenuItem.Enabled = isPdfFileLoaded;
            addEmptyPageToolStripMenuItem.Enabled = isPdfFileLoaded;
            addPdfDocumentToolStripMenuItem.Enabled = isPdfFileLoaded;
            packToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileEmpty;
            securitySettingsToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileReadOnlyMode;
            saveToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileEmpty && !isPdfFileReadOnlyMode && isDocumentChanged;
            saveAsToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileEmpty;
            saveToToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileEmpty;
            convertToTiffToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileEmpty;
            convertToSvgToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileEmpty;
            printToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileEmpty;


            // "View" menu
            customRendererSettingsToolStripMenuItem.Enabled = useCustomRendererToolStripMenuItem.Checked;

            // update "View => Image Display Mode" menu
            singlePageToolStripMenuItem.Checked = false;
            twoColumnsToolStripMenuItem.Checked = false;
            singleContinuousRowToolStripMenuItem.Checked = false;
            singleContinuousColumnToolStripMenuItem.Checked = false;
            twoContinuousRowsToolStripMenuItem.Checked = false;
            twoContinuousColumnsToolStripMenuItem.Checked = false;
            switch (imageViewer1.DisplayMode)
            {
                case ImageViewerDisplayMode.SinglePage:
                    singlePageToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoColumns:
                    twoColumnsToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.SingleContinuousRow:
                    singleContinuousRowToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.SingleContinuousColumn:
                    singleContinuousColumnToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoContinuousRows:
                    twoContinuousRowsToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoContinuousColumns:
                    twoContinuousColumnsToolStripMenuItem.Checked = true;
                    break;
            }
            spellCheckSettingsToolStripMenuItem.Enabled = _annotationTool != null &&
                _annotationTool.SpellChecker != null;

            // "Document" menu

            documentToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileOpening && !isPdfFileSaving && !isTextSearching;
            digitalSignaturesToolStripMenuItem.Enabled = !isPdfFileEmpty;
            bookmarksToolStripMenuItem.Enabled = !isPdfFileEmpty;
            thumbnailsToolStripMenuItem.Enabled = !isPdfFileEmpty;
            viewerPreferencesToolStripMenuItem.Enabled = isPdfFileLoaded;
            removeAttachmentsToolStripMenuItem.Enabled = isPdfFileLoaded && _document.Attachments != null;
            optionalContentToolStripMenuItem.Enabled = isPdfFileLoaded && _document.OptionalContentProperties != null;
            removeLayersOptionalContentToolStripMenuItem.Enabled = isPdfFileLoaded && _document.OptionalContentProperties != null;

            // "Page" menu
            pageToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileOpening && !isPdfFileEmpty && !isPdfFileSaving && !isTextSearching;

            // "Text" menu
            UpdateTextMenuUI();


            // update the form title
            UpdateFormTitle();

            // update information about focused page
            UpdateFocusedImageInfo();


            // resolution 
            resolutionToolStrip1.Enabled = !isPdfFileOpening && !isPdfFileSaving && !isTextSearching;

            // tools tab control & image viewer
            toolsAndImageViewerPanel.Enabled = isPdfFileLoaded && !isPdfFileEmpty && !isPdfFileOpening && !IsPdfFileSaving;

            // tools tab control
            toolsTabControl.Enabled = !isTextSearching;
            // change the status of bookmark panel
            documentBookmarks.Enabled = !isPdfFileEmpty;


            // viewerToolStrip
            viewerToolStrip.Enabled = !IsPdfFileOpening && !isPdfFileSaving;
            viewerToolStrip.SaveButtonEnabled = isPdfFileLoaded && !isPdfFileEmpty && !isPdfFileReadOnlyMode && isDocumentChanged && !isTextSearching;
            viewerToolStrip.PrintButtonEnabled = isPdfFileLoaded && !isPdfFileEmpty;
        }

        /// <summary>
        /// Updates the user interface of "Text" menu.
        /// </summary>
        private void UpdateTextMenuUI()
        {
            // get the current status of application
            bool isPdfFileOpening = IsPdfFileOpening;
            bool isPdfFileLoaded = _document != null;
            bool isPdfFileEmpty = true;
            bool isPdfFileSaving = IsPdfFileSaving;
            bool isTextSelected = false;
            bool isTextSearching = IsTextSearching;

            if (_textSelectionTool != null && _textSelectionTool.ImageViewer != null)
            {
                isTextSelected = _textSelectionTool.HasSelectedText;
            }

            if (isPdfFileLoaded)
                isPdfFileEmpty = imageViewer1.Images.Count <= 0;

            textToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileOpening && !isPdfFileEmpty && !isPdfFileSaving && !isTextSearching;
            highlightSelectedTextToolStripMenuItem.Enabled = isTextSelected;
            highlightSelectedTextAnnotateToolStripMenuItem.Enabled = isTextSelected;
            strikeoutSelectedTextAnnotateToolStripMenuItem.Enabled = isTextSelected;
            underlineSelectedTextAnnotateToolStripMenuItem.Enabled = isTextSelected;
            squigglyUnderlineSelectedTextAnnotateToolStripMenuItem.Enabled = isTextSelected;
            removeSelectedTextToolStripMenuItem.Enabled = isTextSelected;
            addSelectedTextToRedactionMarksToolStripMenuItem.Enabled = isTextSelected;
        }

        /// <summary>
        /// Updates the form title.
        /// </summary>
        private void UpdateFormTitle()
        {
            bool isPdfFileLoaded = _document != null;

            if (isPdfFileLoaded && _pdfFileName != null)
            {
                string title = Path.GetFileName(_pdfFileName);
                if (_document.HasDocumentInformation && _document.DocumentInformation.Title != "")
                    title = string.Format("{0} ({1})", _document.DocumentInformation.Title, title);
                if (_document.IsEncrypted)
                    title += " (SECURED)";
                if (_isDocumentChanged)
                    title += "*";
                Text = string.Format(_titleFormatString, "- " + title);
            }
            else
            {
                Text = string.Format(_titleFormatString, "");
            }
        }

        /// <summary>
        /// Updates information about the focused image.
        /// </summary>
        private void UpdateFocusedImageInfo()
        {
            if (imageViewer1.Image == null)
            {
                pageInfoLabel.Text = "";
                return;
            }
            Resolution resolution = imageViewer1.Image.Resolution;
            string resolutionString;
            if (imageViewer1.Image.IsBad)
            {
                pageInfoLabel.Text = "Bad image!";
            }
            else
            {
                if (resolution.Horizontal == resolution.Vertical)
                    resolutionString = resolution.Horizontal.ToString();
                else
                    resolutionString = string.Format("{0}x{1}", resolution.Horizontal, resolution.Vertical);
                pageInfoLabel.Text = string.Format("Resolution: {0} DPI; Size: {1}x{2} px", resolutionString, imageViewer1.Image.Width, imageViewer1.Image.Height);
                if (imageViewer1.Image.LoadingError)
                    pageInfoLabel.Text = string.Format("[Loading error: {0}] {1}", imageViewer1.Image.LoadingErrorString, pageInfoLabel.Text);
            }
        }

        /// <summary>
        /// Updates UI safely.
        /// </summary>
        private void UpdateUIAsync()
        {
            if (InvokeRequired)
                BeginInvoke(new UpdateUIDelegate(UpdateUI));
            else
                UpdateUI();
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Creates new PDF document.
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsPdfFileOpening = true;
            try
            {
                CreateNewPdfDocument(PdfFormat.Pdf_16, null);
            }
            finally
            {
                IsPdfFileOpening = false;
            }
        }

        /// <summary>
        /// Creates a PDF portfolio.
        /// </summary>
        private void createPortfolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string documentFilename;
            IsPdfFileOpening = true;
            try
            {
                if (!CreateNewPdfDocument(PdfFormat.Pdf_17, "Save Portfolio As"))
                    return;
                documentFilename = _pdfFileName;
            }
            finally
            {
                IsPdfFileOpening = false;
            }
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            openFolder.ShowNewFolderButton = false;
            openFolder.SelectedPath = Path.GetDirectoryName(documentFilename);
            openFolder.Description = "Select root path from which files and folders will be imported to Portfolio.";
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                // add page to document
                PdfPage page = _document.Pages.Add(PaperSizeKind.A4);

                // draw text on first page
                using (PdfGraphics g = page.GetGraphics())
                {
                    TextBoxFigure textBox = new TextBoxFigure();
                    textBox.Font = _document.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);
                    textBox.FontSize = 30;
                    textBox.Location = new PointF(0, 0);
                    textBox.Size = page.MediaBox.Size;
                    textBox.TextAlignment = PdfContentAlignment.Top | PdfContentAlignment.Left | PdfContentAlignment.Right;
                    textBox.TextBrush = new PdfBrush(Color.Black);
                    textBox.Text = "This document is Portfolio\n(Attachment Collection)\nTo view Portfolio you should use PDF viewer compatible with PDF 1.7 ExtensionLevel 3.";
                    textBox.Draw(g);
                }

                // create addtachements
                _document.CreateAttachments(true);

                // set viewer settings
                _document.Attachments.View = AttachmentCollectionViewMode.TileMode;
                _document.Attachments.SplitterBar = new PdfAttachmentCollectionSplitterBar(_document);
                _document.Attachments.SplitterBar.Direction = AttachmentCollectionSplitterBarDirection.None;
                _document.DocumentViewMode = PdfDocumentViewMode.UseAttachments;

                // save changes to document stream
                _document.SaveChanges();

                // add created page to viewer
                imageViewer1.Images.Add(_pdfFileStream);

                // add files and folders to portfolio
                StatusStripActionController actionController =
                    new StatusStripActionController(mainStatusStrip, statusLabel, progressBar);
                actionController.StartAction("Add files to portfolio");
                AddPathRecursively(_document.Attachments.RootFolder, openFolder.SelectedPath, false, PdfCompression.None, actionController);
                actionController.EndAction();

                // show attachments editor
                using (AttachmentsEditorForm dialog = new AttachmentsEditorForm(_document))
                {
                    dialog.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Opens an existing PDF document.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openPdfFileDialog.ShowDialog() == DialogResult.OK)
            {
                IsPdfFileOpening = true;
                try
                {
                    OpenPdfDocument(openPdfFileDialog.FileName);
                }
                finally
                {
                    IsPdfFileOpening = false;
                }
                if (_document != null)
                {
                    if (_document.Attachments != null && _document.Attachments.View != AttachmentCollectionViewMode.Hidden)
                    {
                        using (AttachmentsEditorForm dialog = new AttachmentsEditorForm(_document))
                        {
                            dialog.ShowDialog();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Closes PDF document.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePdfDocument();
        }


        /// <summary>
        /// Adds images, as pages, to PDF document.
        /// </summary>
        private void addPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsPdfFileOpening = true;
            try
            {
                if (openImageFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StartAction("Add pages", false);
                    try
                    {
                        for (int i = 0; i < openImageFileDialog.FileNames.Length; i++)
                        {
                            try
                            {
                                imageViewer1.Images.Add(openImageFileDialog.FileNames[i]);
                                _isDocumentChanged = true;
                            }
                            catch (Exception ex)
                            {
                                DemosTools.ShowErrorMessage(ex, openImageFileDialog.FileNames[i]);
                            }
                        }
                        if (_document.Pages.Count == 0)
                            SaveChangesInPdfDocument(PdfDocumentUpdateMode.Incremental);
                    }
                    finally
                    {
                        EndAction();
                    }
                }
            }
            finally
            {
                IsPdfFileOpening = false;
            }
        }

        /// <summary>
        /// Handles the Click event of AddOcrPagesUsingImageOverTextModeToolStripMenuItem object.
        /// </summary>
        private void addOcrPagesUsingImageOverTextModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_OCR_PLUGIN
            RecognizeTextAndAddOcrResultToPdfDocument(PdfPageCreationMode.ImageOverText);
#endif
        }

        /// <summary>
        /// Handles the Click event of AddOcrPagesUsingTextOverImageModeToolStripMenuItem object.
        /// </summary>
        private void addOcrPagesUsingTextOverImageModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_OCR_PLUGIN
            RecognizeTextAndAddOcrResultToPdfDocument(PdfPageCreationMode.TextOverImage);
#endif
        }

#if !REMOVE_OCR_PLUGIN
        /// <summary>
        /// Recognizes text in images and adds result OCR pages to a searchable PDF document.
        /// </summary>
        /// <param name="pdfPageCreationMode">The mode that defines how to create PDF page.</param>
        private void RecognizeTextAndAddOcrResultToPdfDocument(PdfPageCreationMode pdfPageCreationMode)
        {
            try
            {
                // create a dialog that allows to select images from files ot TWAIN scanner
                using (AddImagesForm form = new AddImagesForm())
                {
                    // show dialog
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int existingPageCount = imageViewer1.Images.Count;

                        if (_tesseract == null)
                            // create Tesseract OCR engine
                            _tesseract = new TesseractOcr(TesseractOcrDllDirectory);

                        // searchable PDF generator
                        SearchablePdfGenerator pdfGenerator = null;
                        // if searchable PDF generator for selected PDF page creating mode does not exist
                        if (!_pdfPageCreationModeToGenerator.TryGetValue(pdfPageCreationMode, out pdfGenerator))
                        {
                            // create searchable PDF generator
                            pdfGenerator = new SearchablePdfGenerator(new OcrEngineManager(_tesseract));
                            // specify PDF page creating mode in PDF generator
                            pdfGenerator.PageCreationMode = pdfPageCreationMode;

                            // create Tesseract OCR settings
                            TesseractOcrSettings tesseractOcrSettings = new TesseractOcrSettings(OcrLanguage.English);
                            tesseractOcrSettings.RecognitionRegionType = RecognitionRegionType.RecognizePageWithPageSegmentationAndOrientationDetection;
                            if (pdfPageCreationMode == PdfPageCreationMode.TextOverImage)
                                tesseractOcrSettings.UseSymbolRegionsCorrection = true;
                            else
                                tesseractOcrSettings.UseSymbolRegionsCorrection = false;
                            // set Tesseract OCR settings in PDF generator
                            pdfGenerator.OcrEngineSettings = tesseractOcrSettings;

                            // save reference to created PDF generator
                            _pdfPageCreationModeToGenerator.Add(pdfPageCreationMode, pdfGenerator);
                        }

                        // use current PDF document format
                        pdfGenerator.PdfFormat = _document.Format;

                        // set images to process
                        pdfGenerator.SourceImages = form.Images;

                        // if source images are processed using image segmentation command
                        if (form.SegmentationResults != null && form.SegmentationResults.Count > 0)
                        {
                            // set image regions in PDF generator

                            pdfGenerator.SourceImagesRegions = new Dictionary<VintasoftImage, IEnumerable<ImageRegion>>();
                            foreach (VintasoftImage image in form.SegmentationResults.Keys)
                                pdfGenerator.SourceImagesRegions.Add(image, form.SegmentationResults[image]);
                        }
                        else
                        {
                            pdfGenerator.SourceImagesRegions = null;
                        }

                        // create a dialog that allows to view the PDF generator
                        using (ProcessingCommandForm<ImageCollection> dialog = new ProcessingCommandForm<ImageCollection>(imageViewer1.Images, pdfGenerator))
                        {
                            dialog.Text = "Add searchable PDF pages";

                            // process images (cleanup and recognize) and add results to imageViewer1.Images
                            dialog.ShowDialog();

                            // if source PDF document is empty
                            if (existingPageCount == 0 && imageViewer1.Images.Count > 0)
                            {
                                // save changes in PDF document
                                SaveChangesInPdfDocument(PdfDocumentUpdateMode.Incremental);
                            }

                            // set focused index to the first added image
                            if (existingPageCount < imageViewer1.Images.Count)
                                imageViewer1.FocusedIndex = existingPageCount;
                        }
                    }

                    // dispose source images
                    form.Images.ClearAndDisposeItems();
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }
#endif

        /// <summary>
        /// Adds an empty page to a PDF document.
        /// </summary>
        private void addEmptyPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsPdfFileOpening = true;
            try
            {
                AddEmptyPageForm addEmptyPageDialog = new AddEmptyPageForm(_emptyPageSize, _emptyPageUnits);
                if (addEmptyPageDialog.ShowDialog() == DialogResult.OK)
                {
                    _emptyPageSize = addEmptyPageDialog.PageSizeInUserUnits;
                    _emptyPageUnits = addEmptyPageDialog.Units;

                    // create temporary stream
                    Stream stream = new MemoryStream();

                    // create temporary PDF document
                    using (PdfDocument document = new PdfDocument(stream, PdfFormat.Pdf_14))
                    {
                        if (addEmptyPageDialog.PaperKind == PaperSizeKind.Custom)
                        {
                            document.Pages.Add(_emptyPageSize);
                        }
                        else
                        {
                            if (addEmptyPageDialog.Rotated)
                                document.Pages.Add(ImageSize.FromPaperKindRotated(addEmptyPageDialog.PaperKind));
                            else
                                document.Pages.Add(addEmptyPageDialog.PaperKind);
                        }
                        document.SaveChanges();
                    }

                    // add document to collection
                    imageViewer1.Images.Add(stream, true);

                    _isDocumentChanged = true;

                    if (_document.Pages.Count == 0)
                        SaveChangesInPdfDocument(PdfDocumentUpdateMode.Incremental);
                }
            }
            finally
            {
                IsPdfFileOpening = false;
            }
        }

        /// <summary>
        /// Adds a PDF document to the current PDF document.
        /// </summary>
        private void addPdfDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openPdfFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Current document will be saved automatically. Continue?", "Add PDF document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    IsPdfFileOpening = true;
                    try
                    {
                        PdfDocument sourceDocument = _document;

                        // open selected PDF document
                        using (PdfDocument tempDocument = new PdfDocument(openPdfFileDialog.FileName))
                        {
                            // create PdfDocumentCopyCommand
                            PdfDocumentCopyCommand copyDocument = new PdfDocumentCopyCommand(sourceDocument);

                            // copy selected PDF document at the end of current PDF document
                            DocumentProcessingCommandForm.ExecuteDocumentProcessing(tempDocument, copyDocument);

                            // if PDF document is loaded in image viewer
                            if (imageViewer1.Images.Count > 0)
                                // save changes in current PDF document using PdfEncoder
                                SaveChangesInPdfDocument(PdfDocumentUpdateMode.Incremental);
                            // if PDF document is NOT loaded in image viewer
                            else
                                // save changes in current PDF document using PdfDocument
                                sourceDocument.SaveChanges();
                        }

                        // reload current PDF document
                        string filename = Filename;
                        ClosePdfDocument();
                        OpenPdfDocument(filename);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                    finally
                    {
                        IsPdfFileOpening = false;
                    }
                }
            }
        }

        /// <summary>
        /// Packs PDF document.
        /// </summary>
        private void packToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SelectPdfFormatForm selectFormat = new SelectPdfFormatForm(_document.Format, _document.EncryptionSystem))
            {
                if (selectFormat.ShowDialog() == DialogResult.OK)
                {
                    bool isSaved = false;
                    OnPdfDocumentSaving();
                    try
                    {
                        isSaved = SaveAndPackPdfDocument(selectFormat.Format, selectFormat.NewEncryptionSettings);
                    }
                    finally
                    {
                        OnPdfDocumentSaved(!isSaved);
                    }
                }
            }
        }


        /// <summary>
        /// Saves changes in PDF document.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnPdfDocumentSaving();
            try
            {
                SaveChangesInPdfDocument(PdfDocumentUpdateMode.Incremental);
            }
            finally
            {
                OnPdfDocumentSaved(false);
            }
        }

        /// <summary>
        /// Saves PDF document to the new source and switches to the source.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePdfDocumentAs();
        }

        /// <summary>
        /// Saves PDF document to the new source but does not switch to the source.
        /// </summary>
        private void saveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnPdfDocumentSaving();
            bool isCanceled = true;
            try
            {
                saveFileDialog.Title = null;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    isCanceled = false;
                    try
                    {
                        SavePdfDocument(saveFileDialog.FileName, false);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
            }
            finally
            {
                OnPdfDocumentSaved(isCanceled);
            }
        }

        /// <summary>
        /// Converts PDF document to a TIFF file.
        /// </summary>
        private void convertToTiffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            convertToFileDialog.Filter = "TIFF Files|*.tif";

            if (convertToFileDialog.ShowDialog() == DialogResult.OK)
            {
                // create dialog that allows to set settings of TIFF encoder
                using (TiffEncoderSettingsForm tiffSaveSettingsDialog = new TiffEncoderSettingsForm())
                {
                    // create TIFF encoder
                    TiffEncoder tiffEncoder = new TiffEncoder(true);
                    tiffSaveSettingsDialog.EncoderSettings = tiffEncoder.Settings;
                    // set settings of TIFF encoder
                    if (tiffSaveSettingsDialog.ShowDialog() == DialogResult.OK)
                    {
                        // render the figure collection on focused PDF page
                        _contentEditorTool.RenderFiguresOnPage();

                        // specify that image collection of image viewer should not switch to the saved file
                        tiffEncoder.SaveAndSwitchSource = false;

                        // start the 'Convert to SVG" action
                        StartAction("Convert to TIFF", true);

                        // start the asynchronous saving of PDF document to a TIFF file
                        imageViewer1.Images.SaveAsync(convertToFileDialog.FileName, tiffEncoder);
                    }
                }
            }
        }

        /// <summary>
        /// Converts PDF document to the SVG files.
        /// </summary>
        private void convertToSvgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            convertToFileDialog.Filter = "SVG Files|*.svg";

            if (convertToFileDialog.ShowDialog() == DialogResult.OK)
            {
                // create dialog that allows to set settings of SVG encoder
                using (SvgEncoderSettingsForm svgEncoderSettingsDialog = new SvgEncoderSettingsForm())
                {
                    // create SVG encoder
                    SvgEncoder svgEncoder = new SvgEncoder();
                    svgEncoderSettingsDialog.EncoderSettings = svgEncoder.Settings;
                    // set settings of SVG encoder
                    if (svgEncoderSettingsDialog.ShowDialog() == DialogResult.OK)
                    {
                        // render the figure collection on focused PDF page
                        _contentEditorTool.RenderFiguresOnPage();

                        // specify that image collection of image viewer should not switch to the saved file
                        svgEncoder.SaveAndSwitchSource = false;

                        // start the 'Convert to SVG" action
                        StartAction("Convert to SVG", true);

                        // convert PDF document to SVG files in background thread
                        Thread savingThread = new Thread(new ParameterizedThreadStart(ConvertPdfDocumentToSvgFilesThread));
                        savingThread.IsBackground = true;
                        savingThread.Start(new object[] { svgEncoder, convertToFileDialog.FileName });
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of PageAutoOrientationToolStripMenuItem object.
        /// </summary>
        private void pageAutoOrientationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool value = !_thumbnailViewerPrintManager.PrintDocument.UseImageAutoOrienation;
            _thumbnailViewerPrintManager.PrintDocument.UseImageAutoOrienation = value;
            pageAutoOrientationToolStripMenuItem.Checked = value;
        }

        /// <summary>
        /// Handles the Click event of CenterPrintingPageToolStripMenuItem object.
        /// </summary>
        private void centerPrintingPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool value = !_thumbnailViewerPrintManager.PrintDocument.Center;
            _thumbnailViewerPrintManager.PrintDocument.Center = value;
            centerPrintingPageToolStripMenuItem.Checked = value;
        }

        /// <summary>
        /// Handles the Click event of PageSettingsToolStripMenuItem object.
        /// </summary>
        private void pageSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        /// <summary>
        /// Prints page(s) of PDF document.
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }


        /// <summary>
        /// Exits the application.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePdfDocument();
            Application.Exit();
        }


        /// <summary>
        /// Updates UI when "File" menu is opening.
        /// </summary>
        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateUI();
        }

        #endregion


        #region 'Edit' menu

        /// <summary>
        /// "Edit" menu is opened.
        /// </summary>
        private void editToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            UpdateEditMenuItems();
        }

        /// <summary>
        /// "Edit" menu is closed.
        /// </summary>
        private void editToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            EnableEditMenuItems();
        }


        /// <summary>
        /// Cuts selected item into clipboard.
        /// </summary>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CutItemUIAction cutUIAction = PdfDemosTools.GetUIAction<CutItemUIAction>(CurrentTool);
            if (cutUIAction != null)
                cutUIAction.Execute();
        }

        /// <summary>
        /// Copies selected item into clipboard.
        /// </summary>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CopyItemUIAction copyUIAction = PdfDemosTools.GetUIAction<CopyItemUIAction>(CurrentTool);
                if (copyUIAction != null)
                    copyUIAction.Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Pastes previously copied item from clipboard.
        /// </summary>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteItemUIAction pasteUIAction = PdfDemosTools.GetUIAction<PasteItemUIAction>(CurrentTool);
            if (pasteUIAction != null)
                pasteUIAction.Execute();
        }

        /// <summary>
        /// Deletes selected item of current visual tool.
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thumbnailViewer1.Focused)
            {
                thumbnailViewer1.DoDelete();
            }
            else
            {
                DeleteItemUIAction deleteUIAction = PdfDemosTools.GetUIAction<DeleteItemUIAction>(CurrentTool);
                if (deleteUIAction != null)
                    deleteUIAction.Execute();
            }
        }

        /// <summary>
        /// Selects all items of current visual tool.
        /// </summary>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thumbnailViewer1.Focused)
            {
                thumbnailViewer1.DoSelectAll();
            }
            else
            {
                SelectAllItemsUIAction selectAllUIAction = PdfDemosTools.GetUIAction<SelectAllItemsUIAction>(CurrentTool);
                if (selectAllUIAction != null)
                    selectAllUIAction.Execute();
            }
        }

        /// <summary>
        /// Deselects all items of current visual tool.
        /// </summary>
        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!thumbnailViewer1.Focused)
            {
                DeselectAllItemsUIAction deselectAllUIAction = PdfDemosTools.GetUIAction<DeselectAllItemsUIAction>(CurrentTool);
                if (deselectAllUIAction != null)
                    deselectAllUIAction.Execute();
            }
        }

        /// <summary>
        /// Updates the "Edit" menu items.
        /// </summary>
        private void UpdateEditMenuItems()
        {
            if (thumbnailViewer1.Focused)
            {
                UpdateEditMenuItem(cutToolStripMenuItem, null, "Cut");
                UpdateEditMenuItem(copyToolStripMenuItem, null, "Copy");
                UpdateEditMenuItem(pasteToolStripMenuItem, null, "Paste");
                deleteToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Text = "Delete Page(s)";
                selectAllToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Text = "Select All Pages";
                deselectAllToolStripMenuItem.Enabled = false;
                deselectAllToolStripMenuItem.Text = "Deselect All";
            }
            else
            {
                UpdateEditMenuItem(cutToolStripMenuItem, PdfDemosTools.GetUIAction<CutItemUIAction>(CurrentTool), "Cut");
                UpdateEditMenuItem(copyToolStripMenuItem, PdfDemosTools.GetUIAction<CopyItemUIAction>(CurrentTool), "Copy");
                UpdateEditMenuItem(pasteToolStripMenuItem, PdfDemosTools.GetUIAction<PasteItemUIAction>(CurrentTool), "Paste");
                UpdateEditMenuItem(deleteToolStripMenuItem, PdfDemosTools.GetUIAction<DeleteItemUIAction>(CurrentTool), "Delete");
                UpdateEditMenuItem(selectAllToolStripMenuItem, PdfDemosTools.GetUIAction<SelectAllItemsUIAction>(CurrentTool), "Select All");
                UpdateEditMenuItem(deselectAllToolStripMenuItem, PdfDemosTools.GetUIAction<DeselectAllItemsUIAction>(CurrentTool), "Deselect All");
            }
        }

        /// <summary>
        /// Enables the "Edit" menu items.
        /// </summary>
        private void EnableEditMenuItems()
        {
            cutToolStripMenuItem.Enabled = true;
            copyToolStripMenuItem.Enabled = true;
            pasteToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
            selectAllToolStripMenuItem.Enabled = true;
            deselectAllToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Disables the "Edit" menu items.
        /// </summary>
        private void DisableEditMenuItems()
        {
            cutToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
            deselectAllToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Updates the "Edit" menu item.
        /// </summary>
        /// <param name="menuItem">The menu item.</param>
        /// <param name="action">The action.</param>
        /// <param name="defaultText">The default text of the menu item.</param>
        private void UpdateEditMenuItem(ToolStripMenuItem menuItem, UIAction action, string defaultText)
        {
            if (action != null && action.IsEnabled)
            {
                menuItem.Enabled = true;
                menuItem.Text = action.Name;
            }
            else
            {
                menuItem.Enabled = false;
                menuItem.Text = defaultText;
            }
        }

        #endregion


        #region 'View' menu

        #region Thumbnail viewer

        /// <summary>
        /// Shows the thumbnail viewer settings. 
        /// </summary>
        private void thumbnailViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThumbnailViewerSettingsForm viewerSettingsDialog = new ThumbnailViewerSettingsForm(thumbnailViewer1);
            viewerSettingsDialog.ShowDialog();
        }

        /// <summary>
        /// Enables/disables usage of embedded thumbnails of PDF pages by thumbnail viewer.
        /// </summary>
        private void useEmbeddedThumbnailsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_document != null)
                _document.RenderingSettings.UseEmbeddedThumbnails = useEmbeddedThumbnailsToolStripMenuItem.Checked;
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Enables/disables centering of image in image viewer.
        /// </summary>
        private void centerImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (centerImageToolStripMenuItem.Checked)
            {
                imageViewer1.FocusPointAnchor = AnchorType.None;
                imageViewer1.IsFocusPointFixed = true;
                imageViewer1.ScrollToCenter();
            }
            else
            {
                imageViewer1.FocusPointAnchor = AnchorType.Left | AnchorType.Top;
                imageViewer1.IsFocusPointFixed = true;
            }
        }

        /// <summary>
        /// Changes the image display mode of image viewer.
        /// </summary>
        private void ImageDisplayMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem imageDisplayModeMenuItem = (ToolStripMenuItem)sender;
            imageViewer1.DisplayMode = (ImageViewerDisplayMode)imageDisplayModeMenuItem.Tag;
            _defaultImageViewerDisplayMode = imageViewer1.DisplayMode;
            UpdateUI();
        }

        /// <summary>
        /// Changes the image scale mode of image viewer.
        /// </summary>
        private void ImageScale_Click(object sender, EventArgs e)
        {
            _imageScaleSelectedMenuItem.Checked = false;
            _imageScaleSelectedMenuItem = (ToolStripMenuItem)sender;

            // if menu item sets ImageSizeMode
            if (_imageScaleSelectedMenuItem.Tag is ImageSizeMode)
            {
                // set size mode
                imageViewer1.SizeMode = (ImageSizeMode)_imageScaleSelectedMenuItem.Tag;
                _imageScaleSelectedMenuItem.Checked = true;
            }
            // if menu item sets zoom
            else
            {
                // get zoom value
                int zoomValue = (int)_imageScaleSelectedMenuItem.Tag;
                // set ImageSizeMode as Zoom
                imageViewer1.SizeMode = ImageSizeMode.Zoom;
                // set zoom value
                imageViewer1.Zoom = zoomValue;
                _imageScaleSelectedMenuItem = scaleToolStripMenuItem;
                _imageScaleSelectedMenuItem.Checked = true;
            }
        }

        /// <summary>
        /// Zoom of image viewer is changed.
        /// </summary>
        /// <remarks>
        /// Checks current ImageSizeMode
        /// and changes text in zoom combo box according to the current zoom.
        /// </remarks>
        private void imageViewer1_ZoomChanged(object sender, ZoomChangedEventArgs e)
        {
            _imageScaleSelectedMenuItem.Checked = false;
            switch (imageViewer1.SizeMode)
            {
                case ImageSizeMode.BestFit:
                    _imageScaleSelectedMenuItem = bestFitToolStripMenuItem;
                    break;
                case ImageSizeMode.FitToHeight:
                    _imageScaleSelectedMenuItem = fitToHeightToolStripMenuItem;
                    break;
                case ImageSizeMode.FitToWidth:
                    _imageScaleSelectedMenuItem = fitToWidthToolStripMenuItem;
                    break;
                case ImageSizeMode.Normal:
                    _imageScaleSelectedMenuItem = normalImageToolStripMenuItem;
                    break;
                case ImageSizeMode.PixelToPixel:
                    _imageScaleSelectedMenuItem = pixelToPixelToolStripMenuItem;
                    break;
                case ImageSizeMode.Zoom:
                    _imageScaleSelectedMenuItem = scaleToolStripMenuItem;
                    break;
            }

            _imageScaleSelectedMenuItem.Checked = true;
        }

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees clockwise.
        /// </summary>
        private void rotateClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewClockwise();
        }

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees counterclockwise.
        /// </summary>
        private void rotateCounterclockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewCounterClockwise();
        }

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees clockwise.
        /// </summary>
        private void RotateViewClockwise()
        {
            if (imageViewer1.ImageRotationAngle != 270)
            {
                imageViewer1.ImageRotationAngle += 90;
                thumbnailViewer1.ImageRotationAngle += 90;
            }
            else
            {
                imageViewer1.ImageRotationAngle = 0;
                thumbnailViewer1.ImageRotationAngle = 0;
            }
        }

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees counterclockwise.
        /// </summary>
        private void RotateViewCounterClockwise()
        {
            if (imageViewer1.ImageRotationAngle != 0)
            {
                imageViewer1.ImageRotationAngle -= 90;
                thumbnailViewer1.ImageRotationAngle -= 90;
            }
            else
            {
                imageViewer1.ImageRotationAngle = 270;
                thumbnailViewer1.ImageRotationAngle = 270;
            }
        }

        /// <summary>
        /// Shows the image viewer settings.
        /// </summary>
        private void imageViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageViewerSettingsForm viewerSettingsDialog = new ImageViewerSettingsForm(imageViewer1);

            // save current image viewer display mode
            ImageViewerDisplayMode displayMode = imageViewer1.DisplayMode;

            viewerSettingsDialog.ShowDialog();

            // if display mode is changed
            if (displayMode != imageViewer1.DisplayMode)
                // update the default display mode
                _defaultImageViewerDisplayMode = imageViewer1.DisplayMode;

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of ViewerRenderingSettingsToolStripMenuItem object.
        /// </summary>
        private void viewerRenderingSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CompositeRenderingSettingsForm viewerRenderingSettingsForm = new CompositeRenderingSettingsForm(imageViewer1.ImageRenderingSettings))
            {
                viewerRenderingSettingsForm.ShowDialog();
            }
            UpdateUI();
        }

        /// <summary>
        /// Shows the image magnifier settings.
        /// </summary>
        private void magnifierSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MagnifierToolAction magnifierToolAction = visualToolsToolStrip1.FindAction<MagnifierToolAction>();

            if (magnifierToolAction != null)
                magnifierToolAction.ShowVisualToolSettings();
        }

        /// <summary>
        /// Changes the rendering settings.
        /// </summary>
        private void renderingSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfRenderingSettingsForm renderingSettingsDialog =
                new PdfRenderingSettingsForm((PdfRenderingSettings)imageViewer1.ImageRenderingSettings.Clone()))
            {
                if (renderingSettingsDialog.ShowDialog() == DialogResult.OK)
                {
                    imageViewer1.ImageRenderingSettings = renderingSettingsDialog.RenderingSettings;
                }
            }
        }

        /// <summary>
        /// Edits the color management settings.
        /// </summary>
        private void colorManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorManagementSettingsForm.EditColorManagement(imageViewer1);
        }

        /// <summary>
        /// Edits the spell check settings.
        /// </summary>
        private void spellCheckSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SpellCheckManagerSettingsForm dialog = new SpellCheckManagerSettingsForm(
                _annotationTool.SpellChecker))
            {
                dialog.Owner = this;

                dialog.ShowDialog();
            }
        }

        #endregion


        #region Custom PDF content renderer

        /// <summary>
        /// Enables/disables the custom content renderer.
        /// </summary>
        private void useCustomRendererToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            PdfRenderingSettings settings;
            if (imageViewer1.ImageRenderingSettings is PdfRenderingSettings)
            {
                settings = (PdfRenderingSettings)imageViewer1.ImageRenderingSettings.Clone();
            }
            else
            {
                settings = new PdfRenderingSettings();
                if (imageViewer1.ImageRenderingSettings != null)
                {
                    settings.InterpolationMode = imageViewer1.ImageRenderingSettings.InterpolationMode;
                    settings.SmoothingMode = imageViewer1.ImageRenderingSettings.SmoothingMode;
                    settings.Resolution = imageViewer1.ImageRenderingSettings.Resolution;
                }
            }
            if (useCustomRendererToolStripMenuItem.Checked)
            {
                settings.ContentRenderer = _pdfCustomContentRenderer;
                imageViewer1.ImageRenderingSettings = settings;
            }
            else
            {
                settings.ContentRenderer = null;
                imageViewer1.ImageRenderingSettings = settings;
            }
            UpdateUI();
            ReloadImagesAsync();
        }

        /// <summary>
        /// Sets the settings of custom renderer.
        /// </summary>
        private void customRendererSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomContentRendererSettingsForm dialog = new CustomContentRendererSettingsForm(_pdfCustomContentRenderer);
            if (dialog.ShowDialog() == DialogResult.OK)
                ReloadImagesAsync();
        }


        /// <summary>
        /// Reloads the images asynchronously.
        /// </summary>
        private void ReloadImagesAsync()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(ReloadImages);
        }

        /// <summary>
        /// Reloads the images.
        /// </summary>
        private void ReloadImages(object state)
        {
            VintasoftImage currentImage = imageViewer1.Image;
            try
            {
                if (currentImage != null)
                    currentImage.Reload(true);
            }
            catch
            {
            }
            foreach (VintasoftImage image in imageViewer1.Images)
            {
                if (currentImage != image)
                {
                    try
                    {
                        image.Reload(true);
                    }
                    catch
                    {
                    }
                }
            }
        }

        #endregion


        #region PDF actions execution

        /// <summary>
        /// Enables or disables PDF actions execution.
        /// </summary>
        private void enableExecuteActionsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            PdfActionExecutorManager.ApplicationActionExecutor.IsEnabled =
                enableExecuteActionsToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Enables or disables JavaScript interpreter.
        /// </summary>
        private void enableJavaScriptExecutingToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            PdfJavaScriptManager.IsJavaScriptEnabled = enableJavaScriptExecutingToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Shows the JavaScript debugger form.
        /// </summary>
        private void debuggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_javaScriptDebuggerForm == null)
                _javaScriptDebuggerForm = new PdfJavaScriptDebuggerForm(PdfJavaScriptManager.JavaScriptActionExecutor, imageViewer1);
            _javaScriptDebuggerForm.Show();
        }

        #endregion


        /// <summary>
        /// Shows interaction area settings form for PDF annotation tool.
        /// </summary>
        private void interactionPointSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (InteractionAreaAppearanceManagerForm dialog = new InteractionAreaAppearanceManagerForm())
            {
                dialog.InteractionAreaSettings = InteractionAreaSettings;
                dialog.ShowDialog();
            }
        }


        /// <summary>
        /// Starts a process of refreshing (actualization) of PostScript names of fonts
        /// in font programs controller.
        /// </summary>
        private void refreshPostScriptFontNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FontProgramsTools.RefreshPostScriptFontNamesOfProgramsController(this) == DialogResult.OK)
            {
                if (imageViewer1.Images.Count > 0)
                    DemosTools.ShowInfoMessage("Reopen the document for using new font names.");
            }
        }

        /// <summary>
        /// Edits the spell check view settings.
        /// </summary>
        private void spellCheckViewSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SpellCheckManagerViewSettingsForm dialog = new SpellCheckManagerViewSettingsForm())
            {
                dialog.InteractionAreaSettings = InteractionAreaSettings;
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Enables/disables the spell checking of form fields.
        /// </summary>
        private void enableFormFieldsSpellCheckingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InteractionAreaSettings.IsEnabledFormFieldSpellChecking = enableFormFieldsSpellCheckingToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Enables/disables the spell checking of annotations.
        /// </summary>
        private void enableAnnotationsSpellCheckingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InteractionAreaSettings.IsEnabledAnnotationsSpellChecking = enableAnnotationsSpellCheckingToolStripMenuItem.Checked;
        }

        #endregion


        #region 'Document' menu

        #region Information about PDF document

        /// <summary>
        /// Shows information about PDF document.
        /// </summary>
        private void documentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_document != null)
            {
                PdfDemosTools.ShowDocumentInformation(_document, true, documentInfoPropertyGrid_PropertyValueChanged);
            }
        }

        /// <summary>
        /// Shows information about PDF document developer extensions.
        /// </summary>
        private void extensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message;
            if (_document.Extensions == null || _document.Extensions.Count == 0)
            {
                message = "Document does not have developer extensions.";
            }
            else
            {
                StringBuilder extensions = new StringBuilder();
                foreach (string name in _document.Extensions.Keys)
                    extensions.AppendLine(string.Format("{0}: {1}", name, _document.Extensions[name]));
                message = string.Format("Document has {0} developer extension(s):\n\n{1}", _document.Extensions.Count, extensions);
            }
            MessageBox.Show(message, "Developer extensions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// Updates UI when item in PDF document information is changed.
        /// </summary>
        private void documentInfoPropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            // update the UI
            UpdateUI();
        }

        #endregion


        #region Verification

        /// <summary>
        /// Verifies the PDF document for compatibility with PDF/A-1b format.
        /// </summary>
        private void pdfA1bVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyPdfDocumentForCompatibilityWithPdfA(new PdfA1bVerifier());
        }

        /// <summary>
        /// Verifies the PDF document for compatibility with PDF/A-2b format.
        /// </summary>
        private void pdfA2bVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyPdfDocumentForCompatibilityWithPdfA(new PdfA2bVerifier());
        }

        /// <summary>
        /// Verifies the PDF document for compatibility with PDF/A-3b format.
        /// </summary>
        private void pdfA3bVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyPdfDocumentForCompatibilityWithPdfA(new PdfA3bVerifier());
        }

        /// <summary>
        /// Verifies the PDF document for compatibility with PDF/A-1a format. 
        /// </summary>
        private void pdfA1aVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyPdfDocumentForCompatibilityWithPdfA(new PdfA1aVerifier());
        }

        /// <summary>
        /// Verifies the PDF document for compatibility with PDF/A-2a format. 
        /// </summary>
        private void pdfA2aVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyPdfDocumentForCompatibilityWithPdfA(new PdfA2aVerifier());
        }

        /// <summary>
        /// Verifies the PDF document for compatibility with PDF/A-2u format. 
        /// </summary>
        private void pdfA2uVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyPdfDocumentForCompatibilityWithPdfA(new PdfA2uVerifier());
        }

        /// <summary>
        /// Verifies the PDF document for compatibility with PDF/A-3a format. 
        /// </summary>
        private void pdfA3aVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyPdfDocumentForCompatibilityWithPdfA(new PdfA3aVerifier());
        }

        /// <summary>
        /// Verifies the PDF document for compatibility with PDF/A-3u format. 
        /// </summary>
        private void pdfA3uVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyPdfDocumentForCompatibilityWithPdfA(new PdfA3uVerifier());
        }

        /// <summary>
        /// Verifies the PDF document for compatibility with PDF/A-4 format. 
        /// </summary>
        private void pdfA4VerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyPdfDocumentForCompatibilityWithPdfA(new PdfA4Verifier());
        }

        /// <summary>
        /// Verifies the PDF document for compatibility with PDF/A-4f format. 
        /// </summary>
        private void pDFA4fVeriferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyPdfDocumentForCompatibilityWithPdfA(new PdfA4fVerifier());
        }

        /// <summary>
        /// Verifies the PDF document for compatibility with PDF/A-4f format. 
        /// </summary>
        private void pDFA4eVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyPdfDocumentForCompatibilityWithPdfA(new PdfA4eVerifier());
        }


        #endregion


        #region Conversion

        /// <summary>
        /// Converts the PDF document to the PDF/A-1b format.
        /// </summary>
        private void pdfA1bConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertPdfDocumentToPdfA(new PdfA1bConverter());
        }

        /// <summary>
        /// Converts the PDF document to the PDF/A-2b format.
        /// </summary>
        private void pdfA2bConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertPdfDocumentToPdfA(new PdfA2bConverter());
        }

        /// <summary>
        /// Converts the PDF document to the PDF/A-2u format.
        /// </summary>

        /// <summary>
        /// Handles the Click event of PdfA2uConverterToolStripMenuItem object.
        /// </summary>
        private void pdfA2uConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertPdfDocumentToPdfA(new PdfA2uConverter());
        }

        /// <summary>
        /// Converts the PDF document to the PDF/A-3b format.
        /// </summary>
        private void pdfA3bConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertPdfDocumentToPdfA(new PdfA3bConverter());
        }

        /// <summary>
        /// Converts the PDF document to the PDF/A-1a format.
        /// </summary>
        private void pdfA1aConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertPdfDocumentToPdfA(new PdfA1aConverter());
        }

        /// <summary>
        /// Converts the PDF document to the PDF/A-2a format.
        /// </summary>
        private void pdfA2aConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertPdfDocumentToPdfA(new PdfA2aConverter());
        }

        /// <summary>
        /// Converts the PDF document to the PDF/A-3a format.
        /// </summary>
        private void pdfA3aConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertPdfDocumentToPdfA(new PdfA3aConverter());
        }

        /// <summary>
        /// Converts the PDF document to the PDF/A-3u format.
        /// </summary>
        private void pdfA3uConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertPdfDocumentToPdfA(new PdfA3uConverter());
        }

        /// <summary>
        /// Converts the PDF document to the PDF/A-4 format.
        /// </summary>
        private void pdfA4ConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertPdfDocumentToPdfA(new PdfA4Converter());
        }

        /// <summary>
        /// Converts the PDF document to the PDF/A-4e format.
        /// </summary>
        private void pdfA4eConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertPdfDocumentToPdfA(new PdfA4eConverter());
        }

        /// <summary>
        /// Converts the PDF document to the PDF/A-4f format.
        /// </summary>
        private void pdfA4fConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertPdfDocumentToPdfA(new PdfA4fConverter());
        }

        /// <summary>
        /// Converts the PDF document to image-only PDF document.
        /// </summary>
        private void convertToImageonlyDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _annotationTool.CancelBuilding();

            PdfConvertToImageOnlyCommand command = new PdfConvertToImageOnlyCommand();
            if (imageViewer1.ImageDecodingSettings != null)
                command.DecodingSettings.ColorManagement = imageViewer1.ImageDecodingSettings.ColorManagement;

            ProcessingCommandForm<ImageCollection>.ExecuteProcessing(
                imageViewer1.Images,
                command,
                true);
        }

        /// <summary>
        /// Simplify content of PDF document.
        /// </summary>
        private void simplifyDocumentContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _annotationTool.CancelBuilding();

            PdfSimplifyContentCommand command = new PdfSimplifyContentCommand();
            if (imageViewer1.ImageDecodingSettings != null)
                command.ColorManagement = imageViewer1.ImageDecodingSettings.ColorManagement;

            ProcessingCommandForm<ImageCollection>.ExecuteProcessing(
                imageViewer1.Images,
                command,
                true);
        }

        #endregion


        #region Processing

        /// <summary>
        /// Determines whether document has signature fields.
        /// </summary>
        private void documentHasSignatureFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                PdfAnalyzers.DocumentHasSignatureFields,
                true);
        }

        /// <summary>
        /// Determines that a content operator uses overprint control.
        /// </summary>
        private void overprintControlIsUsedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                ProcessingHelper.CreateTriggerActivationPredicate(
                    "Overprint control is used",
                    TriggerSeverity.Important,
                    new PdfDocumentProcessingTree(PdfTriggers.ContentStreamOperatorUsesOverprintControl)
                ),
                false);
        }

        /// <summary>
        /// Returns information about PDF document conformance
        /// from the metadata identification schema.
        /// </summary>
        private void detectTheConformanceUsingTheMetadataIdentificationSchemaToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                PdfAnalyzers.DocumentConformance,
                false);
        }

        /// <summary>
        /// Determines that PDF file XREF table is corrupt.
        /// </summary>
        private void theCrossreferenceTableIsCorruptToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                PdfAnalyzers.CrossReferenceTableIsCorrupt,
                false);
        }

        /// <summary>
        /// Returns count of indirect objects in PDF document.
        /// </summary>
        private void numberOfIndirectObjectsInAPDFFileToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                PdfAnalyzers.IndirectObjectCount,
                false);
        }

        /// <summary>
        /// Determines that the cross-reference information
        /// is stored in a cross-reference stream.
        /// </summary>
        private void theCrossreferenceInformationIsStoredInACrossreferenceStreamToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                PdfAnalyzers.PdfFileUsesCrossReferenceStreams,
                false);
        }

        /// <summary>
        /// Determines that PDF file uses the compressed object streams.
        /// </summary>
        private void documentUsesTheCompressedObjectStreamsToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                PdfAnalyzers.PdfFileUsesCompressedObjectStreams,
                false);
        }

        /// <summary>
        /// Determines that PDF file occurs at offset 0 of the stream.
        /// </summary>
        private void pdfFileHeaderOccursAtByteOffset0OfTheFileToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                PdfAnalyzers.PdfFileHeaderStartsAtOffset0,
                false);
        }

        /// <summary>
        /// Determines that PDF file has linearization information.
        /// </summary>
        private void pDFFileHasTheLinearizationInfoToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                PdfAnalyzers.PdfFileHasLinearizationInfo,
                false);
        }

        /// <summary>
        /// Removes unused resources from PDF document.
        /// </summary>
        private void removeUnusedResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                 new PdfDocumentRemoveUnusedNamedResourcesCommand(),
                 true);
        }

        /// <summary>
        /// Converts TrueType fonts to the CFF fonts.
        /// </summary>
        private void convertTrueTypeFontsToCFFFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfFontProcessingCommandExecutor fontsProcessing = new PdfFontProcessingCommandExecutor("Document fonts processing",
                new TrueTypeToCffFontProgramConverter());
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                 fontsProcessing,
                 true);
        }

        /// <summary>
        /// Decompress all data streams of document.
        /// </summary>
        private void decompressDataStreamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfStreamCompressionConverter converter = new PdfStreamCompressionConverter(PdfCompression.None);
            converter.ProcessImageStreams = false;
            PdfDocumentConverter decompressor = new PdfDocumentConverter("Data resources decompressor",
                new PdfDocumentProcessingTree(converter));
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                 decompressor,
                 true);
        }

        /// <summary>
        /// Compress all data streams of document.
        /// </summary>
        private void compressDataStreamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfStreamCompressionConverter converter = new PdfStreamCompressionConverter(PdfCompression.Zip);
            converter.CompressionSettings.ZipCompressionLevel = 9;
            converter.ProcessImageStreams = false;
            PdfDocumentConverter compressor = new PdfDocumentConverter("Data resources compressor",
                new PdfDocumentProcessingTree(converter));
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                 compressor,
                 true);
        }


        /// <summary>
        /// Removes transparency from document.
        /// </summary>
        private void removeTransparencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessingCommand<PdfDocument> command = ProcessingHelper.CreateCompositeProcessing<PdfDocument>("Remove transparency from document",
                new PdfAnnotationProcessingCommandExecutor(PdfFixups.AnnotationUsesTransparencyFixup),
                new PdfPageProcessingCommandExecutor(new RemoveTransparencyFromContentStreamCommand().ConvertTarget<PdfPage>())
            );
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                command,
                true);
            DemosTools.ReloadImagesInViewer(imageViewer1);
        }

        /// <summary>
        /// Cleaups PDF document.
        /// </summary>
        private void cleanupDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IProcessingCommand<PdfDocument> command = new PdfDocumentCleanupCommand();
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                command,
                true);
        }

        /// <summary>
        /// Removes duplicate resources from document.
        /// </summary>
        private void removeDuplicateResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IProcessingCommand<PdfDocument> command = new PdfTreeRemoveDuplicateNodesCommand();
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                command,
                true);
        }

        /// <summary>
        /// Removes signature fields from PDF document.
        /// </summary>
        private void removeSignatureFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfDocumentRemoveSignatureFieldsCommand(),
                true);
            DemosTools.ReloadImagesInViewer(imageViewer1);
        }

        /// <summary>
        /// Compress PDF document image-resources.
        /// </summary>
        private void compressImageResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfCompressImageResourcesCommand command = new PdfCompressImageResourcesCommand();
            command.ImageResourceCompressionSettings.Jpeg2000Settings.CompressionType = Vintasoft.Imaging.Codecs.ImageFiles.Jpeg2000.Jpeg2000CompressionType.Lossy;
            command.ImageResourceCompressionSettings.Jpeg2000Settings.CompressionRatio = 50;
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                command,
                true);
        }

        /// <summary>
        /// Optimizes the color depth of PDF documents images.
        /// </summary>
        private void optimizeImagesColorDepthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfOptimizeImageColorDepthCommand(),
                true);
        }

        /// <summary>
        /// Optimizes the content images of PDF document.
        /// </summary>
        private void optimizeContentImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfOptimizeContentImageCommand(),
                true);
        }

        /// <summary>
        /// Removes elements from PDF document elements.
        /// </summary>
        private void discardDocumentElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfDocumentRemoveElementsCommand(),
                true);
        }

        /// <summary>
        /// Compresses PDF document.
        /// </summary>
        private void compressDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfDocumentCompressorCommand command = new PdfDocumentCompressorCommand();
            command.Started += PdfDocumentCompressorCommand_Started;
            command.Finished += PdfDocumentCompressorCommand_Finished;

            // Images

            command.DetectBlackWhiteImageResources = true;
            command.DetectBitonalImageResources = true;
            command.DetectGrayscaleImageResources = true;
            command.DetectIndexed8ImageResources = false;
            command.ColorDepthDetectionMaxInaccuracy = 5;

            command.ColorImagesCompression = PdfCompression.Jpeg;
            command.ColorImagesCompressionResolution = new Resolution(150, 150);
            command.ColorImagesCompressionMinResolution = new Resolution(188, 188);

            command.GrayscaleImagesCompression = PdfCompression.Jpeg;
            command.GrayscaleImagesCompressionResolution = new Resolution(150, 150);
            command.GrayscaleImagesCompressionMinResolution = new Resolution(188, 188);

            command.BitonalImagesCompression = PdfCompression.Jbig2;
            command.BitonalImagesCompressionResolution = new Resolution(300, 300);
            command.BitonalImagesCompressionMinResolution = new Resolution(375, 375);

            command.IndexedImagesCompression = PdfCompression.Undefined;

            command.DownscaleInterpolationMode = ImageInterpolationMode.HighQualityBicubic;


            // Resources

            command.UseFlateInsteadLzwCompression = true;
            command.UseFlateInsteadNoneCompression = true;
            command.RecompressFlateCompression = false;
            command.FlateCompressionLevel = 9;


            // Clean Up

            command.OptimizeFontSubsets = false;
            command.SubsetFonts = true;
            command.RemoveInvalidBookmarks = true;
            command.RemoveInvalidLinks = true;
            command.RemoveUnusedPages = true;
            command.RemoveUnusedNames = true;
            command.RemoveUnusedNamedResources = true;
            command.RemoveDuplicateResources = true;


            // Discard

            command.RemoveAnnotations = false;
            command.RemoveBookmarks = false;
            command.RemoveEmbeddedThumbnails = false;
            command.RemoveDocumentInformation = false;
            command.RemoveEmbeddedFiles = false;
            command.RemoveMetadata = false;


            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                command,
                true,
                true);
        }

        #endregion


        #region Annotations

        /// <summary>
        /// Handles the Click event of ImportFromXFDFToolStripMenuItem object.
        /// </summary>
        private void importFromXFDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create "Open file" dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XFDF Files|*.xfdf";

                // show dialog
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // open selected file
                        using (FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            // create PDF annotation XFDF codec
                            PdfAnnotationXfdfCodec xfdfCodec = new PdfAnnotationXfdfCodec();
                            // import annotations from file to PDF document
                            xfdfCodec.Import(_document, stream);
                        }

                        // reload images in image viewer
                        DemosTools.ReloadImagesInViewer(imageViewer1);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of ExportToXFDFToolStripMenuItem object.
        /// </summary>
        private void exportToXFDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create "Save file" dialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XFDF Files|*.xfdf";

                // show dialog
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // create new file
                        using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite))
                        {
                            // create PDF annotation XFDF codec
                            PdfAnnotationXfdfCodec xfdfCodec = new PdfAnnotationXfdfCodec();
                            // export annotations from PDF document
                            xfdfCodec.Export(_document, stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of RemoveAllAnnotationsToolStripMenuItem object.
        /// </summary>
        private void removeAllAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessingDemosTools.ExecuteProcessing<ImageCollection>(
                imageViewer1.Images, new PdfPageRemoveAnnotationsCommand(PdfPageRemoveAnnotationsCommand.AllAnnotationTypes));
        }

        /// <summary>
        /// Handles the Click event of RemoveMarkupAnnotationsToolStripMenuItem object.
        /// </summary>
        private void removeMarkupAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessingDemosTools.ExecuteProcessing<ImageCollection>(
                imageViewer1.Images, new PdfPageRemoveAnnotationsCommand(PdfPageRemoveAnnotationsCommand.MarkupAnnotationTypes));
        }

        #endregion


        #region PDF document security

        /// <summary>
        /// Shows the security properties of PDF document.
        /// </summary>
        private void securityPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SecurityPropertiesForm securityProperties = new SecurityPropertiesForm(_document))
            {
                securityProperties.ShowDialog();
            }
        }

        /// <summary>
        /// Changes the security settings of PDF document.
        /// </summary>
        private void securitySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecuritySettingsForm securitySettings = new SecuritySettingsForm(_document.EncryptionSystem);
            if (securitySettings.ShowDialog() == DialogResult.OK)
            {
                if (securitySettings.NewEncryptionSettings != _document.EncryptionSystem)
                {
                    if (imageViewer1.Images.Count > 0)
                    {
                        EncryptionSystem newEncryptionSettings = securitySettings.NewEncryptionSettings;
                        PdfFormat format = _document.Format;
                        if (newEncryptionSettings != null)
                        {
                            // RC4
                            if (newEncryptionSettings.Algorithm == EncryptionAlgorithm.RC4)
                            {
                                // 40 bits
                                if (newEncryptionSettings.KeyLength == 40)
                                {
                                    // PDF 1.1 or greater version required
                                    if (format.VersionNumber == 10)
                                        format = new PdfFormat("1.1", false, format.BinaryFormat);
                                }
                                // greater than 40 bits
                                else
                                {
                                    // PDF 1.4 or greater version required
                                    if (format.VersionNumber < 14)
                                        format = new PdfFormat("1.4", false, format.BinaryFormat);
                                }
                            }
                            // AES
                            else if (newEncryptionSettings.Algorithm == EncryptionAlgorithm.AES)
                            {
                                if (newEncryptionSettings.KeyLength == 128)
                                {
                                    // PDF 1.6 or greater version required
                                    if (format.VersionNumber < 16)
                                        format = new PdfFormat("1.6", format.CompressedCrossReferenceTable, format.BinaryFormat);
                                }
                                else if (newEncryptionSettings.KeyLength == 256)
                                {
                                    // PDF 1.7 Extension Level 3 or greater version required
                                    if (format.VersionNumber < 16)
                                        format = new PdfFormat("1.7", format.CompressedCrossReferenceTable, format.BinaryFormat);
                                }
                            }
                        }
                        SaveAndPackPdfDocument(format, newEncryptionSettings);
                    }
                }
            }
        }

        #endregion


        #region PDF document signing and signatures

        /// <summary>
        /// Shows digital signatures of PDF document.
        /// </summary>
        private void digitalSignaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (DocumentSignaturesForm dialog = new DocumentSignaturesForm(_document))
                {
                    dialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Creates signature field, adds signature field to PDF document and
        /// signs PDF document using new signature field.
        /// </summary>
        private void signDocumentUsingNewSignatureFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // check pages of PDF document
            if (!PdfDemosTools.CheckAllPagesFromDocument(imageViewer1.Images, _document))
                return;

            // if PDF document version is less than 1.3
            if (_document.Format.VersionNumber < 13)
            {
                DemosTools.ShowErrorMessage("PDF document version 1.3 or greater is required.");
            }
            // if PDF document version is equal or more than 1.3
            else
            {
                if (MessageBox.Show("Use mouse for drawing the area (left click and drag mouse cursor) where signature must appear.", "Sign Document", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    // create visual tool that will create the signature field
                    SignatureMakerTool signatureMaker = new SignatureMakerTool(imageViewer1.VisualTool, _signatureAppearance, false);
                    // add handler to the SignatureAdded event
                    signatureMaker.SignatureAdded += new EventHandler(signatureMaker_SignatureAdded);
                    // activate visual tool in image viewer
                    imageViewer1.VisualTool = signatureMaker;
                }
            }
        }

        /// <summary>
        /// Signs PDF document using the existing empty signature field.
        /// </summary>
        private void signDocumentUsingExistingEmptySignatureFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // check pages of PDF document
            if (!PdfDemosTools.CheckAllPagesFromDocument(imageViewer1.Images, _document))
                return;

            // if document does NOT have interactive form
            if (_document.InteractiveForm == null)
                return;

            // list with signature fields which do NOT have values
            List<PdfInteractiveFormSignatureField> emptySignatureFields = new List<PdfInteractiveFormSignatureField>();
            // get all signature fields of PDF document
            PdfInteractiveFormSignatureField[] signatureFields = _document.InteractiveForm.GetSignatureFields();
            // for each signature field
            foreach (PdfInteractiveFormSignatureField field in signatureFields)
            {
                // if signature field does NOT have value
                if (field.SignatureInfo == null)
                    // add signature field to the list
                    emptySignatureFields.Add(field);
            }

            // if document does NOT have empty signature fields
            if (emptySignatureFields.Count == 0)
            {
                DemosTools.ShowInfoMessage("Document does not have empty signature fields.");
            }
            // if interactive form have empty signature fields
            else
            {
                // select signtaure field from the list of fields
                PdfInteractiveFormSignatureField field = SelectSignatureField(emptySignatureFields);
                // if signature field is selected
                if (field != null)
                {
                    // create a form that allows to perform signing of PDF document
                    // using existing signature field
                    using (CreateSignatureFieldForm createSignature = new CreateSignatureFieldForm(field, _signatureAppearance))
                    {
                        // if new signature field is created
                        if (createSignature.ShowDialog() == DialogResult.OK)
                        {
                            SavePdfDocumentToSourceOrNewFile(true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds an empty signature field to PDF document.
        /// </summary>
        private void addEmptySignatureFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FocusedPage == null)
            {
                ShowMessage_CurrentImageIsNotPdfPage();
                return;
            }

            if (MessageBox.Show("Use mouse for drawing the area (left click and drag mouse cursor) where signature must appear.", "Sign Document", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                // create visual tool that will create the signature field
                SignatureMakerTool signatureMaker = new SignatureMakerTool(imageViewer1.VisualTool, _signatureAppearance, true);
                // add handler to the SignatureAdded event
                signatureMaker.SignatureAdded += new EventHandler(signatureMaker_EmptySignatureAdded);
                // activate visual tool in image viewer
                imageViewer1.VisualTool = signatureMaker;
            }
        }

        /// <summary>
        /// Clears signature value of signature field of PDF document.
        /// </summary>
        private void clearSignatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if document does NOT have interactive form
            if (_document.InteractiveForm == null)
                return;

            // list with signature fields which have values
            List<PdfInteractiveFormSignatureField> signedSignatureFields = new List<PdfInteractiveFormSignatureField>();
            // get all signature fields of PDF document
            PdfInteractiveFormSignatureField[] signatureFields = _document.InteractiveForm.GetSignatureFields();
            // for each signature field
            foreach (PdfInteractiveFormSignatureField field in signatureFields)
            {
                // if signature field has value
                if (field.SignatureInfo != null)
                    // add signature field to the list
                    signedSignatureFields.Add(field);
            }

            // if document does NOT have signed signature fields
            if (signedSignatureFields.Count == 0)
            {
                DemosTools.ShowInfoMessage("Document does NOT have signed signature fields.");
            }
            // if document has signed signature fields
            else
            {
                // select signtaure field from the list of fields
                PdfInteractiveFormSignatureField field = SelectSignatureField(signedSignatureFields);
                // if signature field is selected
                if (field != null)
                {
                    // remove signature value
                    field.SignatureInfo = null;
                    // remove signature appearance
                    field.Annotation.Appearances = null;
                    // reload image associated with field annotation page
                    ReloadImage(field.Annotation.Page);
                }
            }
        }

        /// <summary>
        /// Clears signature values of all signature fields of PDF document.
        /// </summary>
        private void clearAllSignaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if document does NOT have interactive form
            if (_document.InteractiveForm == null)
                return;

            // array with fignature fields of PDF document
            PdfInteractiveFormSignatureField[] signatureFields = null;
            // get signature fields of PDF document
            signatureFields = _document.InteractiveForm.GetSignatureFields();

            // if document has signature fields
            if (signatureFields != null && signatureFields.Length > 0)
            {
                // if signature fields must be cleared
                if (MessageBox.Show("Do you want to clear all signatures of PDF document?", "Clear all signatures", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // for each signature field
                    foreach (PdfInteractiveFormSignatureField field in signatureFields)
                    {
                        // clear the signature field
                        field.SignatureInfo = null;
                        // remove signature appearance
                        field.Annotation.Appearances = null;
                        // reload image associated with field annotation page
                        ReloadImage(field.Annotation.Page);
                    }
                }
            }
            // if document does NOT have signature fields
            else
            {
                DemosTools.ShowInfoMessage("Document does not have signature fields.");
            }
        }

        /// <summary>
        /// Removes signature field of PDF document.
        /// </summary>
        private void removeSignatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if document does NOT have interactive form
            if (_document.InteractiveForm == null)
                return;

            // list with signature fields
            List<PdfInteractiveFormSignatureField> signatureFields = new List<PdfInteractiveFormSignatureField>();
            // add all signature fields of PDF document to the list
            signatureFields.AddRange(_document.InteractiveForm.GetSignatureFields());

            // if document does NOT have signature fields
            if (signatureFields.Count == 0)
            {
                DemosTools.ShowInfoMessage("Document does not have signature fields.");
            }
            // if document has signature fields
            else
            {
                // select signtaure field from the list of fields
                PdfInteractiveFormSignatureField field = SelectSignatureField(signatureFields);
                // if signature field is selected
                if (field != null)
                {
                    PdfPage page = field.Annotation.Page;
                    // delete signature field: remove field from interactive form and 
                    // remove widget annotation from page
                    _document.InteractiveForm.RemoveField(field);
                    // reload image associated with field annotation page
                    ReloadImage(page);
                }
            }
        }

        /// <summary>
        /// Removes all signature fields from PDF document.
        /// </summary>
        private void removeAllSignaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if document does NOT have interactive form
            if (_document.InteractiveForm == null)
                return;

            // array with fignature fields of PDF document
            PdfInteractiveFormSignatureField[] signatureFields = null;
            // get signature fields of PDF document
            signatureFields = _document.InteractiveForm.GetSignatureFields();

            // if document does NOT have signature fields
            if (signatureFields == null || signatureFields.Length == 0)
            {
                DemosTools.ShowInfoMessage("PDF document does NOT have digital signatures.");
            }
            // if document has signature fields
            else
            {
                // if signatures must be removed
                if (MessageBox.Show("Do you want to remove all signatures from PDF document?", "Remove all signatures", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // for each signature field
                    foreach (PdfInteractiveFormSignatureField field in signatureFields)
                    {
                        PdfPage page = field.Annotation.Page;
                        // delete signatue field: remove fields from interactive form and 
                        // remove widget annotations from pages
                        _document.InteractiveForm.RemoveField(field);
                        // reload image associated with field annotation page
                        ReloadImage(page);
                    }

                    DemosTools.ShowInfoMessage(string.Format("{0} signatures are removed.", signatureFields.Length));
                    UpdateUI();
                }
            }
        }


        /// <summary>
        /// Reloads the image associated with PDF page.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        private void ReloadImage(PdfPage page)
        {
            VintasoftImage image = PdfDemosTools.FindImageByPage(page, imageViewer1.Images);

            if (image != null)
            {
                if (image == imageViewer1.Image)
                    imageViewer1.ReloadImage();
                else
                    image.Reload(true);
            }
        }

        #endregion


        #region PDF bookmarks

        /// <summary>
        /// Adds bookmark to PDF document.
        /// </summary>
        private void bookmarks_AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentBookmarks.Document = _document;
            if (imageViewer1.FocusedIndex >= 0)
                documentBookmarks.AddBookmark(imageViewer1.FocusedIndex);
        }

        /// <summary>
        /// Edits bookmark of PDF document.
        /// </summary>
        private void bookmarks_EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentBookmarks.Document = _document;
            documentBookmarks.EditSelectedBookmark();
        }

        /// <summary>
        /// Removes bookmark of PDF document.
        /// </summary>
        private void bookmarks_DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentBookmarks.Document = _document;
            documentBookmarks.DeleteSelectedBookmark();
        }

        #endregion


        #region Thumbnails in PDF document

        /// <summary>
        /// Removes thumbnails of all pages of PDF document.
        /// </summary>
        private void thumbnails_RemoveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartAction("Remove thumbnails", false);
            _document.Pages.RemoveThumbnails();
            EndAction();
        }

        /// <summary>
        /// Generates thumbnails for all pages of PDF document.
        /// </summary>
        private void thumbnails_GenerateAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartAction("Generate thumbnails", true);
            _document.Progress += _pdfDocument_ThumbnailGenerationProgress;
            _document.Pages.CreateThumbnails(128, 128);
            _document.Progress -= _pdfDocument_ThumbnailGenerationProgress;
            EndAction();
        }

        /// <summary>
        /// Generates thumbnails for all pages of PDF document.
        /// </summary>
        private void thumbnails_ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<PdfImageResource> thumbs = new List<PdfImageResource>();
            for (int i = 0; i < _document.Pages.Count; i++)
            {
                if (_document.Pages[i].Thumbnail != null)
                    thumbs.Add(_document.Pages[i].Thumbnail);
            }
            if (thumbs.Count > 0)
            {
                using (PdfResourcesViewerForm dlg = new PdfResourcesViewerForm(_document, thumbs.ToArray()))
                {
                    dlg.StartPosition = FormStartPosition.CenterParent;
                    dlg.Owner = this;
                    dlg.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("This PDF document does not contain thumbnails.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// PDF thumbnail generation is in progress.
        /// </summary>
        private void _pdfDocument_ThumbnailGenerationProgress(object sender, ImageFileProgressEventArgs e)
        {
            ShowProgressInfo(e.Progress);
        }

        #endregion


        #region Common parameters of PDF document

        /// <summary>
        /// PDF document view mode is changed.
        /// </summary>
        private void documentViewModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _document.DocumentViewMode = (PdfDocumentViewMode)Enum.Parse(typeof(PdfDocumentViewMode), pageModeComboBox.SelectedItem.ToString());
        }

        /// <summary>
        /// PDF page layout is changed.
        /// </summary>
        private void viewerPageLayoutToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _document.ViewerPageLayout = (PdfDocumentPageLayoutMode)Enum.Parse(
                typeof(PdfDocumentPageLayoutMode), viewerPageLayoutToolStripComboBox.SelectedItem.ToString());

            // set the display mode of image viewer
            if (_document.ViewerPageLayout == PdfDocumentPageLayoutMode.Undefined)
                imageViewer1.DisplayMode = _defaultImageViewerDisplayMode;
            else
                imageViewer1.DisplayMode = PdfDemosTools.ConvertPageLayoutModeToImageViewerDisplayMode(_document.ViewerPageLayout);
        }

        /// <summary>
        /// Shows a form that allows to view and edit viewer preferences of PDF document.
        /// </summary>
        private void viewerPreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_document.ViewerPreferences == null)
            {
                if (MessageBox.Show("Document does not have Viewer Preferences. Do you want to create Viewer Preferences properties?", "Create Viewer Preferences?",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _document.ViewerPreferences = new PdfDocumentViewerPreferences(_document);
                }
                else
                {
                    return;
                }
            }
            using (PropertyGridForm viewerPreferencesForm = new PropertyGridForm(_document.ViewerPreferences, "Viewer Preferences"))
            {
                viewerPreferencesForm.ShowDialog();
            }
        }

        /// <summary>
        /// Shows a form that allows to view and edit actions of PDF document.
        /// </summary>
        private void documentActionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfTriggersEditorForm dlg = new PdfTriggersEditorForm(_document))
            {
                dlg.Owner = this;
                dlg.StartPosition = FormStartPosition.CenterParent;

                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Shows a form that allows to edit the JavaScript of PDF document.
        /// </summary>
        private void documentLevelJavaScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_document.JavaScripts == null)
                _document.JavaScripts = new PdfJavaScriptActionDictionary(_document);

            using (PdfJavaScriptActionDictionaryEditorDialog dlg =
                new PdfJavaScriptActionDictionaryEditorDialog(_document.JavaScripts))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Owner = this;
                dlg.ShowDialog();
            }
        }

        #endregion


        #region Attachments & embedded files in PDF document

        /// <summary>
        /// Shows form that allows to view and edit attachments (portfolio) of PDF document.
        /// </summary>
        private void attachmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_document.Attachments == null)
            {
                if (MessageBox.Show("Document does not have attachments. Do you want to create attachments?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            using (AttachmentsEditorForm dialog = new AttachmentsEditorForm(_document))
            {
                dialog.ShowDialog();
            }
            UpdateUI();
        }

        /// <summary>
        /// Removes all attachments (portfolio) of PDF document.
        /// </summary>
        private void removeAttachmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to remove all attachments?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _document.RemoveAttachments(true);
                UpdateUI();
            }
        }

        /// <summary>
        /// Shows form that allows to view and edit embedded files of PDF document.
        /// </summary>
        private void embeddedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EmbeddedFilesForm dlg = new EmbeddedFilesForm())
            {
                dlg.Document = _document;
                dlg.ShowDialog();
            }
        }

        #endregion


        #region Resources in PDF document

        /// <summary>
        /// Shows a form that allows to view resources of PDF document.
        /// </summary>
        private void resourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfResourcesViewerForm dialog = new PdfResourcesViewerForm(_document))
            {
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Owner = this;
                dialog.ShowDialog();

                if (dialog.PropertyValueChanged)
                    imageViewer1.ReloadImage();
            }
        }

        /// <summary>
        /// Shows a form that allows to view image-resources of PDF document.
        /// </summary>
        private void documentImageResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartAction("Collect resources", false);
            PdfImageResource[] images = _document.GetImages();
            EndAction();
            if (images.Length > 0)
            {
                using (PdfResourcesViewerForm resourcesViewer = new PdfResourcesViewerForm(_document))
                {
                    resourcesViewer.StartPosition = FormStartPosition.CenterParent;
                    resourcesViewer.Owner = this;
                    resourcesViewer.ShowFormResources = false;
                    resourcesViewer.ShowDialog();
                    if (resourcesViewer.PropertyValueChanged)
                        imageViewer1.ReloadImage();
                }
            }
            else
            {
                MessageBox.Show("This PDF document does not contain image resources.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Removes the unused resources from PDF document.
        /// </summary>
        /// <param name="progressController">The progress controller.</param>
        private void RemoveUnusedNamedResourcesFromDocument(IActionProgressController progressController)
        {
            bool result = _document.RemoveUnusedNamedResources(progressController);

            if (result)
            {
                StringBuilder messageString = new StringBuilder();
                messageString.AppendLine("Resources will be removed from PDF document only after packing of PDF document.");
                messageString.AppendLine("Do you want to pack PDF document right now?");
                messageString.AppendLine();
                messageString.AppendLine("Click 'Yes' if you want to pack PDF document right now.");
                messageString.AppendLine();
                messageString.AppendLine("Click 'No' if you will pack PDF document later (\"File -> Pack\" menu) and now you want to work with unpacked PDF document.");

                if (MessageBox.Show(messageString.ToString(),
                                    "Pack document?",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new SaveAndPackDelegate(SaveAndPackPdfDocument));
                    }
                    else
                    {
                        SaveAndPackPdfDocument();
                    }
                }
            }
            else
            {
                MessageBox.Show("This PDF document does not have unused resources.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion


        #region Fonts in PDF document

        /// <summary>
        /// Shows form that allows to view information about fonts of PDF document.
        /// </summary>
        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // get all PDF documents loaded in image viewer
                List<PdfDocument> documents = GetPdfDocumentsAssociatedWithImageCollection(imageViewer1.Images);
                List<PdfFont> fonts = new List<PdfFont>();
                foreach (PdfDocument document in documents)
                    fonts.AddRange(document.GetFonts());

                if (fonts.Count == 0)
                {
                    MessageBox.Show("This document does not contain fonts.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ViewDocumentFontsForm viewDocumentFontsDialog = new ViewDocumentFontsForm(fonts);
                    viewDocumentFontsDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Embeds all fonts into PDF document.
        /// </summary>
        private void embedAllFontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Do you want to embed all external fonts of the document?";
            if (MessageBox.Show(message, "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    StartAction("Embed fonts", false);
                    // embed all external fonts for all PDF documents loaded in image viewer
                    foreach (PdfDocument document in GetPdfDocumentsAssociatedWithImageCollection(imageViewer1.Images))
                        document.FontManager.EmbedAllFonts();
                    EndAction();
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                    EndFailedAction();
                }
            }
        }

        /// <summary>
        /// Removes all unused characters from fonts of PDF document.
        /// </summary>
        private void subsetAllFontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Do you want to subset all fonts (remove all unused symbols from the fonts) of the document?";
            if (MessageBox.Show(message, "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    StartAction("Subset fonts", false);
                    using (ActionProgressForm progressForm = new ActionProgressForm(PackAllFonts, 2, "Subset all embedded fonts"))
                    {
                        if (progressForm.RunAndShowDialog(this) == DialogResult.OK)
                            EndAction();
                        else
                            EndCanceledAction();
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                    EndFailedAction();
                }
            }
        }

        #endregion


        #region Layers (optional content) of PDF document

        /// <summary>
        /// Shows form that allows to view setting of layers (optional content) of PDF document.
        /// </summary>
        private void optionalContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OptionalContentSettingsForm dlg = new OptionalContentSettingsForm(_document, imageViewer1))
            {
                dlg.ShowDialog();

                imageViewer1.Image.Reload(false);
            }
        }

        /// <summary>
        /// Shows form that allows to remove layers (optional conetent) of PDF document.
        /// </summary>
        private void removeOptionalContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RemoveOptionalContentForm dlg = new RemoveOptionalContentForm(_document))
            {
                dlg.ShowDialog();

                if (dlg.SelectedOptionalGroups.Count != 0)
                {
                    RemoveMarkedContentCommand command = new RemoveMarkedContentCommand();
                    command.RemovingMarkedContent = dlg.SelectedOptionalGroups.ToArray();

                    DocumentProcessingCommandForm.ExecuteDocumentProcessing(_document, command, false);

                    imageViewer1.Image.Reload(false);
                }
            }
        }

        #endregion

        #endregion


        #region 'Page' menu

        #region Processing

        /// <summary>
        /// Changes scale of PDF page.
        /// </summary>
        private void changeScaleOfPDFPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommandOnFocusedImage(new PdfPageScalingCommand(), true, true);
        }

        /// <summary>
        /// Resizes canvas of PDF page.
        /// </summary>
        private void resizeCanvasOfPDFPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommandOnFocusedImage(new PdfPageResizeCanvasCommand(), true, true);
        }

        /// <summary>
        /// Rotates PDF page by the orthogonal angle.
        /// </summary>
        private void rotatePDFPageBy90DegressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommandOnFocusedImage(new PdfPageRotateOrthogonallyCommand(90), true, false);
        }

        /// <summary>
        /// Clears the content of PDF page.
        /// </summary>
        private void clearPDFPageContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommandOnFocusedImage(new PdfPageClearContentCommand(), true, true);
        }

        /// <summary>
        /// Burns the PDF annotations on PDF page.
        /// </summary>
        private void burnThePDFAnnotationsOnPDFPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommandOnFocusedImage(new PdfPageBurnAnnotationsCommand(), true, false);
        }

        /// <summary>
        /// Removes the PDF annotations on PDF page.
        /// </summary>
        private void removePdfAnnotationsFromPDFPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommandOnFocusedImage(new PdfPageRemoveAnnotationsCommand(), true, false);
        }

        /// <summary>
        /// Blends colors in PDF page.
        /// </summary>
        private void colorBlendingTtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommandOnFocusedImage(new PdfPageColorBlendingCommand(), true, false);
        }

        /// <summary>
        /// Inverts colors in PDF page.
        /// </summary>
        private void invertPDFPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfPageColorBlendingCommand invertCommand = new PdfPageColorBlendingCommand();
            invertCommand.BackgroundColor = Color.White;
            invertCommand.BlendingColor = Color.White;
            invertCommand.BlendingMode = GraphicsStateBlendMode.Difference;
            ExecuteProcessingCommandOnFocusedImage(invertCommand, false, false);
        }

        /// <summary>
        /// Converts PDF document or PDF page to an image-only PDF document.
        /// </summary>
        private void convertToImageonlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommandOnFocusedImage(new PdfConvertToImageOnlyCommand(), true, true);
        }

        /// <summary>
        /// Simplify content of PDF page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void simplifyPageContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommandOnFocusedImage(new PdfSimplifyContentCommand(), true, true);
        }

        /// <summary>
        /// Removes unused resources from PDF page.
        /// </summary>
        private void removeUnusedResourcesFromPDFPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteProcessingCommandOnFocusedImage(new PdfPageRemoveUnusedNamedResourcesCommand(), true, false);
        }

        /// <summary>
        /// Executes the specified processing command for the focused image.
        /// </summary>
        /// <param name="command">The processing command.</param>
        /// <param name="showDialog">Indicates that the processing dialog must be shown.</param>
        /// <param name="clearTextSelection">Indicates that selected text must be cleared.</param>
        private void ExecuteProcessingCommandOnFocusedImage(
            IProcessingCommand<VintasoftImage> command,
            bool showDialog,
            bool clearTextSelection)
        {
            if (clearTextSelection &&
                !string.IsNullOrEmpty(_textSelectionTool.SelectedText))
            {
                _textSelectionTool.ClearSelection();
                _textSelectionTool.FocusedTextSymbol = null;
            }

            ProcessingCommandForm<VintasoftImage>.ExecuteProcessing(
                imageViewer1.Image, command, showDialog);
        }

        /// <summary>
        /// Handles the Click event of PageUsesTransparencyToolStripMenuItem object.
        /// </summary>
        private void pageUsesTransparencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PdfTriggers.PageUsesTransparency.Execute(FocusedPage) != null)
                MessageBox.Show("Page uses transparecy.");
            else
                MessageBox.Show("Page does not use transparecy.");
        }

        #endregion


        /// <summary>
        /// Shows properties of PDF page.
        /// </summary>
        private void pagePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FocusedPage == null)
            {
                ShowMessage_CurrentImageIsNotPdfPage();
                return;
            }
            using (PropertyGridForm propertyGridForm = new PropertyGridForm(FocusedPage, "Page properties"))
            {
                propertyGridForm.PropertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid_PropertyValueChanged);
                propertyGridForm.ShowDialog();
                propertyGridForm.PropertyGrid.PropertyValueChanged -= propertyGrid_PropertyValueChanged;
            }
        }

        /// <summary>
        /// Shows a form that allows to view and edit actions of PDF page.
        /// </summary>
        private void pageActionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfTriggersEditorForm window = new PdfTriggersEditorForm(FocusedPage))
            {
                window.Owner = this;
                window.StartPosition = FormStartPosition.CenterParent;

                window.ShowDialog();
            }
        }

        /// <summary>
        /// Shows a form that allows to view resources of PDF page.
        /// </summary>
        private void pageResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfResourcesViewerForm resourcesViewer = new PdfResourcesViewerForm(FocusedPage))
            {
                resourcesViewer.StartPosition = FormStartPosition.CenterParent;
                resourcesViewer.Owner = this;
                resourcesViewer.ShowDialog();
                if (resourcesViewer.PropertyValueChanged)
                    imageViewer1.ReloadImage();
            }
        }

        /// <summary>
        /// Shows a form that allows to view image-resources of PDF page.
        /// </summary>
        private void pageImageResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.FocusedIndex >= 0)
            {
                if (FocusedPage != null)
                {
                    IList<PdfImageResource> images = FocusedPage.GetImages();
                    if (images.Count == 0)
                    {
                        MessageBox.Show("This page does not contain image resources.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        using (PdfResourcesViewerForm resourcesViewer = new PdfResourcesViewerForm(FocusedPage))
                        {
                            resourcesViewer.ShowFormResources = false;
                            resourcesViewer.StartPosition = FormStartPosition.CenterParent;
                            resourcesViewer.Owner = this;
                            resourcesViewer.ShowDialog();
                            if (resourcesViewer.PropertyValueChanged)
                                imageViewer1.ReloadImage();
                        }
                    }
                }
                else
                {
                    ShowMessage_CurrentImageIsNotPdfPage();
                }
            }
        }


        /// <summary>
        /// Renders PDF page and saves rendered image to a file.
        /// </summary>
        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.FocusedIndex >= 0)
            {
                if (saveImageFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PdfRenderingSettings settings = (PdfRenderingSettings)CompositeRenderingSettings.GetRenderingSettings<PdfRenderingSettings>(
                        imageViewer1.ImageRenderingSettings).Clone();
                    using (CompositeRenderingSettingsForm renderingSettingsDialog = new CompositeRenderingSettingsForm(settings))
                    {

                        if (renderingSettingsDialog.ShowDialog() == DialogResult.OK)
                        {
                            StartAction("Rendering and save", false);
                            RenderingSettings currentRenderingSettings = imageViewer1.Image.RenderingSettings;
                            imageViewer1.Image.RenderingSettings = settings;
                            try
                            {
                                imageViewer1.Image.Save(saveImageFileDialog.FileName);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Image saving error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                imageViewer1.Image.RenderingSettings = currentRenderingSettings;
                            }
                            EndAction();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Updates UI when PDF page properties are changed.
        /// </summary>
        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            string propertyName = e.ChangedItem.PropertyDescriptor.Name;
            if (propertyName == "Rotate" || propertyName == "UserUnitFactor" || propertyName.EndsWith("Box"))
            {
                imageViewer1.Image.Reload(true);
                _textSelectionTool.ClearSelection();
            }
        }

        #endregion


        #region 'Text' menu

        /// <summary>
        /// "Text" menu is opened.
        /// </summary>
        private void textToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            UpdateTextMenuUI();
        }

        /// <summary>
        /// Shows form that allows to find text in PDF document.
        /// </summary>
        private void findTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsTextSearching = true;

            using (FindTextForm findTextDialog = new FindTextForm(_textSelectionTool))
            {
                TabPage selectedTab = toolsTabControl.SelectedTab;
                toolsTabControl.SelectedTab = textExtractionTabPage;

                if (_textSelectionTool.HasSelectedText)
                    findTextDialog.FindWhat = _textSelectionTool.SelectedText;

                findTextDialog.ShowDialog();

                toolsTabControl.SelectedTab = selectedTab;
            }

            IsTextSearching = false;
        }


        /// <summary>
        /// Handles the Click event of TextMarkupHighlightToolStripMenuItem object.
        /// </summary>
        private void textMarkupHighlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfTextMarkupTools.HighlightSelectedText(imageViewer1);
        }

        /// <summary>
        /// Handles the Click event of TextMarkupStrikeOutToolStripMenuItem object.
        /// </summary>
        private void textMarkupStrikeOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfTextMarkupTools.StrikeoutSelectedText(imageViewer1);
        }

        /// <summary>
        /// Handles the Click event of TextMarkupUnderlineToolStripMenuItem object.
        /// </summary>
        private void textMarkupUnderlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfTextMarkupTools.UnderlineSelectedText(imageViewer1);
        }

        /// <summary>
        /// Handles the Click event of TextMarkupSquigglyUnderlineToolStripMenuItem object.
        /// </summary>
        private void textMarkupSquigglyUnderlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfTextMarkupTools.SquigglyUnderlineSelectedText(imageViewer1);
        }

        /// <summary>
        /// Highlights selected text.
        /// </summary>
        private void highlightSelectedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfGraphics graphics = PdfGraphics.FromPage(FocusedPage))
            {
                Color brushColor = Color.FromArgb(255, 255, 0);
                PdfBrush brush = new PdfBrush(brushColor, GraphicsStateBlendMode.Multiply);
                TextRegion selectedRegion = _textSelectionTool.GetSelectedRegion(imageViewer1.Image);
                if (selectedRegion != null)
                {
                    TextRegionLine[] lines = selectedRegion.Lines;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        RegionF[] regions = lines[i].SelectionRegions;
                        for (int j = 0; j < regions.Length; j++)
                            graphics.FillPolygon(brush, regions[j].ToPolygon());
                    }
                }
            }
            imageViewer1.Image.Reload(true);
        }



        /// <summary>
        /// Removes selected text.
        /// </summary>
        private void removeSelectedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_textSelectionTool.HasSelectedText)
            {
                VintasoftImage[] imagesWithSelection = _textSelectionTool.GetSelectionImages();
                foreach (VintasoftImage image in imagesWithSelection)
                {
                    TextRegion selectedText = _textSelectionTool.GetSelectedRegion(image);
                    if (!selectedText.IsEmpty)
                    {
                        PdfPage page = PdfDocumentController.GetPageAssociatedWithImage(image);
                        page.RemoveText(selectedText);
                        image.Reload(true);
                    }
                }
                _textSelectionTool.ClearSelection();
                _textSelectionTool.FocusedTextSymbol = null;
            }
            else
            {
                MessageBox.Show("No selected text.");
            }
        }

        /// <summary>
        /// Creates redaction mark from selected text.
        /// </summary>
        private void addSelectedTextToRedactionMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_textSelectionTool.HasSelectedText)
            {
                VintasoftImage[] imagesWithSelection = _textSelectionTool.GetSelectionImages();
                foreach (VintasoftImage image in imagesWithSelection)
                {
                    TextRegion selectedText = _textSelectionTool.GetSelectedRegion(image);
                    if (!selectedText.IsEmpty)
                    {
                        _removeContentTool.Add(image, new TextRedactionMark(image, selectedText));
                    }
                }
                _textSelectionTool.ClearSelection();
                toolsTabControl.SelectedTab = removeContentTabPage;
                CurrentTool = _redactionTool;
            }
            else
            {
                MessageBox.Show("No selected text.");
            }
        }

        /// <summary>
        /// Obfuscates the text encoding of the current PDF page.
        /// </summary>
        private void currentPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Do you want to obfuscate the encoding of all text of the page?";
            if (MessageBox.Show(message, "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (ActionProgressForm progressForm = new ActionProgressForm(ObfuscateTextEncodingOfCurrentPage, 2, "Obfuscate text encoding of current page"))
                {
                    if (progressForm.RunAndShowDialog(this) == DialogResult.OK)
                        ShowPackDialogAfterTextObfuscation();
                }
            }
        }

        /// <summary>
        /// Obfuscates the text encoding of the selected PDF pages.
        /// </summary>
        private void selectedPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VintasoftImage[] selectedImages = thumbnailViewer1.GetSelectedImages();
            if (selectedImages.Length == 0)
            {
                MessageBox.Show("No selected pages.");
                return;
            }

            string message = "Do you want to obfuscate the encoding of all text of the selected pages?";
            if (MessageBox.Show(message, "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                PdfPage[] pages = new PdfPage[selectedImages.Length];
                for (int i = 0; i < selectedImages.Length; i++)
                    pages[i] = PdfDocumentController.GetPageAssociatedWithImage(selectedImages[i]);
                _pagesForObfuscation = pages;

                using (ActionProgressForm progressForm = new ActionProgressForm(ObfuscateTextEncodingOfSelectedPages, 2, "Obfuscate text encoding of selected pages"))
                {
                    if (progressForm.RunAndShowDialog(this) == DialogResult.OK)
                        ShowPackDialogAfterTextObfuscation();
                }

                _pagesForObfuscation = null;
            }
        }

        /// <summary>
        /// Obfuscates the text encoding of the PDF document.
        /// </summary>
        private void documentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string message = "Do you want to obfuscate the encoding of all text of the document?";
            if (MessageBox.Show(message, "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (ActionProgressForm progressForm = new ActionProgressForm(ObfuscateTextEncodingOfDocument, 2, "Obfuscate text encoding of document"))
                {
                    if (progressForm.RunAndShowDialog(this) == DialogResult.OK)
                        ShowPackDialogAfterTextObfuscation();
                }
            }
        }

        /// <summary>
        /// Shows the form with properties of the text encoding obfuscator.
        /// </summary>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PropertyGridForm dialog = new PropertyGridForm(_textEncodingObfuscator, "Text encoding obfuscator settings", true))
            {
                dialog.ShowDialog();
            }
        }

        #endregion


        #region 'Forms' menu

        /// <summary>
        /// "Forms" menu is opened.
        /// </summary>
        private void formsToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            bool isPdfFileOpening = IsPdfFileOpening;
            bool isPdfFileLoaded = _document != null;
            bool isPdfFileEmpty = true;
            bool isPdfFileSaving = IsPdfFileSaving;
            bool hasInteractiveForm = isPdfFileLoaded && _document.InteractiveForm != null;

            if (isPdfFileLoaded)
                isPdfFileEmpty = imageViewer1.Images.Count <= 0;


            // "Forms" menu
            importDataToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileOpening && !isPdfFileEmpty &&
                                               !isPdfFileSaving;
            exportDataToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileOpening && !isPdfFileEmpty &&
                                               !isPdfFileSaving && hasInteractiveForm;
            resetFormToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileOpening && !isPdfFileEmpty &&
                                               !isPdfFileSaving && hasInteractiveForm;
            updateAppearancesToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileOpening && !isPdfFileEmpty &&
                                               !isPdfFileSaving && hasInteractiveForm;
            calculationOrderToolStripMenuItem.Enabled = isPdfFileLoaded && !isPdfFileOpening && !isPdfFileEmpty &&
                                               !isPdfFileSaving && hasInteractiveForm;
        }

        /// <summary>
        /// Imports data of PDF interactive form.
        /// </summary>
        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_document.InteractiveForm == null)
            {
                MessageBox.Show("Data cannot be imported because PDF document does not have interactive form.",
                    "Import Form Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XFDF Files|*.xfdf";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            PdfInteractiveFormDataXfdfCodec xfdfCodec = new PdfInteractiveFormDataXfdfCodec();
                            xfdfCodec.FieldValueChanged += new EventHandler<PropertyChangedEventArgs<object>>(xfdfCodec_FieldValueChanged);
                            xfdfCodec.Import(_document.InteractiveForm, stream);
                        }

                        // reload images in image viewer
                        DemosTools.ReloadImagesInViewer(imageViewer1);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Value of PDF interactive field is changed.
        /// </summary>
        private void xfdfCodec_FieldValueChanged(object sender, PropertyChangedEventArgs<object> e)
        {
            PdfInteractiveFormField formField = sender as PdfInteractiveFormField;
            if (formField != null && formField.AppearanceDependsFromValue)
                formField.UpdateAppearance();
        }

        /// <summary>
        /// Exports data of PDF interactive form.
        /// </summary>
        private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XFDF Files|*.xfdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite))
                        {
                            PdfInteractiveFormDataXfdfCodec xfdfCodec = new PdfInteractiveFormDataXfdfCodec();
                            xfdfCodec.Export(_document.InteractiveForm, stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Resets interactive form of PDF document.
        /// </summary>
        private void resetFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // reset field values
                _document.InteractiveForm.ResetFieldValues(true);
                // reload images in image viewer
                DemosTools.ReloadImagesInViewer(imageViewer1);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Update field appearances of interactive form of PDF document.
        /// </summary>
        private void updateAppearancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // update field appearances
                _document.InteractiveForm.UpdateAppearances();
                // reload images in image viewer
                DemosTools.ReloadImagesInViewer(imageViewer1);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Shows a dialog that allows to change the calculation order of fields in interactive form.
        /// </summary>
        private void calculationOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (PdfInteractiveFormFieldCalculationOrderEditorForm dialog =
                    new PdfInteractiveFormFieldCalculationOrderEditorForm())
                {
                    dialog.Owner = this;
                    dialog.InteractiveForm = _document.InteractiveForm;
                    dialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        #endregion


        #region 'Annotations' menu

        /// <summary>
        /// "Annotations" menu is opened.
        /// </summary>
        private void annotationsToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            bool isPdfFileLoaded = _document != null;
            bool hasAnnotations = isPdfFileLoaded && FocusedPage != null &&
                FocusedPage.Annotations != null && FocusedPage.Annotations.Count > 0;
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Shows the "About" dialog.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm aboutDialog = new AboutBoxForm())
            {
                aboutDialog.ShowDialog();
            }
        }

        #endregion


        #region TextBoxContextMenuStrip

        /// <summary>
        /// Handles the FocusedAnnotationViewChanged event of the AnnotationTool.
        /// </summary>
        private void AnnotationTool_FocusedAnnotationViewChanged(object sender, PdfAnnotationViewChangedEventArgs e)
        {
            PdfTextWidgetAnnotationView textWidget = e.NewValue as PdfTextWidgetAnnotationView;
            if (textWidget != null)
            {
                TextObjectTextBoxTransformer transformer = (TextObjectTextBoxTransformer)textWidget.ViewTransformer;
                transformer.TextBox.ContextMenuStrip = textBoxContextMenuStrip;
            }
        }

        /// <summary>
        /// Handles the Click event of the textBoxCopyToolStripMenuItem control.
        /// </summary>
        private void textBoxCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = (RichTextBox)textBoxContextMenuStrip.SourceControl;
            textBox.Copy();
        }

        /// <summary>
        /// Handles the Click event of the textBoxPasteToolStripMenuItem control.
        /// </summary>
        private void textBoxPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = (RichTextBox)textBoxContextMenuStrip.SourceControl;
            textBox.Paste();
        }

        /// <summary>
        /// Handles the Opening event of the textBoxContextMenuStrip control.
        /// </summary>
        private void textBoxContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            RichTextBox textBox = (RichTextBox)textBoxContextMenuStrip.SourceControl;
            textBoxCopyToolStripMenuItem.Enabled = !string.IsNullOrEmpty(textBox.SelectedText);
            textBoxPasteToolStripMenuItem.Enabled = Clipboard.ContainsText();
        }

        #endregion


        #region Visual Tool Actions

        /// <summary>
        /// Handles the ShowSettings event of MarkupTextToolAction object.
        /// </summary>
        private void MarkupTextToolAction_ShowSettings(object sender, EventArgs e)
        {
            using (PropertyGridForm dialog = new PropertyGridForm(_textMarkupTool, "Text Markup Tool"))
                dialog.ShowDialog();
        }

        /// <summary>
        /// Handles the Activated event of HighlightTextToolAction object.
        /// </summary>
        private void HighlightTextToolAction_Activated(object sender, EventArgs e)
        {
            ActivateTextMarkupTool(PdfTextMarkupToolMode.Highlight);
        }

        /// <summary>
        /// Handles the Activated event of UnderlineTextToolAction object.
        /// </summary>
        private void UnderlineTextToolAction_Activated(object sender, EventArgs e)
        {
            ActivateTextMarkupTool(PdfTextMarkupToolMode.Underline);
        }

        /// <summary>
        /// Handles the Activated event of StrikeoutTextToolAction object.
        /// </summary>
        private void StrikeoutTextToolAction_Activated(object sender, EventArgs e)
        {
            ActivateTextMarkupTool(PdfTextMarkupToolMode.Strikeout);
        }

        /// <summary>
        /// Handles the Activated event of SquigglyTextToolAction object.
        /// </summary>
        private void SquigglyTextToolAction_Activated(object sender, EventArgs e)
        {
            ActivateTextMarkupTool(PdfTextMarkupToolMode.SquigglyUnderline);
        }

        /// <summary>
        /// Handles the Activated event of CaretTextToolAction object.
        /// </summary>
        private void CaretTextToolAction_Activated(object sender, EventArgs e)
        {
            ActivateTextMarkupTool(PdfTextMarkupToolMode.Caret);
        }

        /// <summary>
        /// Activates the text markup tool.
        /// </summary>
        /// <param name="markupMode">The markup mode.</param>
        private void ActivateTextMarkupTool(PdfTextMarkupToolMode markupMode)
        {
            _textSelectionTool.Enabled = true;
            bool restorePreviousVisualTool;
            if (markupMode == PdfTextMarkupToolMode.Caret)
            {
                restorePreviousVisualTool = _textSelectionTool.FocusedTextSymbol != null;
            }
            else
            {
                restorePreviousVisualTool = _textSelectionTool.HasSelectedText;
            }
            _defaultAnnotationTool.ActiveTool = _textSelectionTool;
            _textMarkupTool.MarkupMode = markupMode;
            _textMarkupTool.Enabled = true;
            if (restorePreviousVisualTool)
                visualToolsToolStrip1.SetPreviousAction();
        }

        /// <summary>
        /// Handles the Deactivated event of TextMarkupToolAction object.
        /// </summary>
        private void TextMarkupToolAction_Deactivated(object sender, EventArgs e)
        {
            _textMarkupTool.Enabled = false;
            _defaultAnnotationTool.ActiveTool = null;
        }


        /// <summary>
        /// Handles the Executed event of the RemoveContentToolAction.
        /// </summary>
        private void RemoveContentToolAction_Executed(object sender, EventArgs e)
        {
            toolsTabControl.SelectedTab = removeContentTabPage;
        }

        /// <summary>
        /// Handles the Executed event of the ContentEditorToolAction.
        /// </summary>
        private void ContentEditorToolAction_Executed(object sender, EventArgs e)
        {
            toolsTabControl.SelectedTab = contentEditorTabPage;
        }

        /// <summary>
        /// Handles the Executed event of the TextSelectionAction.
        /// </summary>
        private void TextSelectionAction_Executed(object sender, EventArgs e)
        {
            toolsTabControl.SelectedTab = textExtractionTabPage;
        }

        /// <summary>
        /// Handles the Executed event of the AnnotationToolAction.
        /// </summary>
        private void AnnotationToolAction_Executed(object sender, EventArgs e)
        {
#if !REMOVE_PDFVISUALEDITOR_PLUGIN
            _annotationTool.InteractionMode = PdfAnnotationInteractionMode.Edit;
#else
            _annotationTool.InteractionMode = PdfAnnotationInteractionMode.View;
#endif
            toolsTabControl.SelectedTab = annotationToolTabPage;
        }

        /// <summary>
        /// Handles the Clicked event of the annotationToolEditFormFieldsAction.
        /// </summary>
        private void annotationToolEditFormFieldsAction_Clicked(object sender, EventArgs e)
        {
            VisualToolAction action = (VisualToolAction)sender;

            if (!action.Parent.IsActivated)
                action.Parent.Activate();

            _annotationTool.InteractionMode = PdfAnnotationInteractionMode.Edit;
            toolsTabControl.SelectedTab = annotationToolTabPage;
            annotationToolControl.ShowFormFieldsTab();
        }

        /// <summary>
        /// Handles the Clicked event of the annotationToolEditAnnotationsAction.
        /// </summary>
        private void annotationToolEditAnnotationsAction_Clicked(object sender, EventArgs e)
        {
            VisualToolAction action = (VisualToolAction)sender;

            if (!action.Parent.IsActivated)
                action.Parent.Activate();

            _annotationTool.InteractionMode = PdfAnnotationInteractionMode.Edit;
            toolsTabControl.SelectedTab = annotationToolTabPage;
            annotationToolControl.ShowAnnotationsTab();
        }

        /// <summary>
        /// Handles the Executed event of the TextSelectionAndFillFormsAction.
        /// </summary>
        private void TextSelectionAndFillFormsAction_Executed(object sender, EventArgs e)
        {
            if (_annotationTool.InteractionMode != PdfAnnotationInteractionMode.View &&
                _annotationTool.InteractionMode != PdfAnnotationInteractionMode.Markup)
            {
                _annotationTool.InteractionMode = PdfAnnotationInteractionMode.Markup;
                toolsTabControl.SelectedTab = pagesTabPage;
            }
            if (_annotationTool.InteractionMode != PdfAnnotationInteractionMode.Edit)
                _textSelectionTool.Enabled = true;
        }

        #endregion


        #region Image Viewer

        /// <summary>
        /// Image is loading in image viewer.
        /// </summary>
        private void imageViewer_ImageLoading(object sender, ImageLoadingEventArgs e)
        {
            StartAction("Rendering", false);
        }

        /// <summary>
        /// Image is loaded in image viewer.
        /// </summary>
        private void imageViewer_ImageLoaded(object sender, ImageLoadedEventArgs e)
        {
            EndAction();
            UpdateUI();

            // if font missing error is not shown
            if (!_isCJKFontMissingErrorMessageShown)
            {
                // if document is not empty
                if (_document != null)
                {
                    // get all runtime messages
                    PdfRuntimeMessage[] runtimeMessages = _document.GetAllRuntimeMessages();
                    // if document has runtime messages
                    if (runtimeMessages.Length != 0)
                    {
                        // for each message
                        foreach (PdfRuntimeMessage runtimeMessage in runtimeMessages)
                        {
                            // if message is an error
                            if (runtimeMessage is PdfRuntimeError)
                            {
                                // if message about missing CJK font
                                if (runtimeMessage.InnerException is CJKFontProgramNotFoundException)
                                {
                                    // show error message
                                    DemosTools.ShowErrorMessage(runtimeMessage.Message);
                                    // specify that error message is shown
                                    _isCJKFontMissingErrorMessageShown = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Image is not loaded in image viewer because of error.
        /// </summary>
        private void imageViewer_ImageLoadingException(object sender, ExceptionEventArgs e)
        {
            EndAction();
            UpdateUI();
            MessageBox.Show(e.Exception.Message, "Image loading exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Index of focused image in viewer is changing.
        /// </summary>
        private void imageViewer_FocusedIndexChanging(object sender, FocusedIndexChangedEventArgs e)
        {
            AbortBuildFigure();
        }

        /// <summary>
        /// Index of focused image in viewer is changed.
        /// </summary>
        private void imageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            if (imageViewer1.Images.Count > 0)
                UpdateUI();
        }

        #endregion


        #region Image collection

        /// <summary>
        /// Image collection of image viewer is changed.
        /// </summary>
        private void Images_ImageCollectionChanged(object sender, ImageCollectionChangeEventArgs e)
        {
            IsDocumentChanged = true;
        }


        /// <summary>
        /// Image collection saving is in progress.
        /// </summary>
        private void Images_ImageCollectionSavingProgress(object sender, ProgressEventArgs e)
        {
            ShowProgressInfo(e.Progress);
        }

        /// <summary>
        /// Image collection is saved.
        /// </summary>
        private void OnImageCollectionSaved(bool error)
        {
            if (_switchPdfFileStreamToNewStream)
            {
                _switchPdfFileStreamToNewStream = false;
                _pdfFileStream.Close();
                _pdfFileStream.Dispose();
                _pdfFileStream = _newFileStream;

                RemoveDocumentEventHandlers();

                PdfDocumentController.CloseDocument(_document);

                _document = PdfDocumentController.OpenDocument(_newFileStream);

                if (documentBookmarks.Document != null && documentBookmarks.Document != _document)
                    documentBookmarks.Document = _document;

                AddDocumentEventHandlers();

                _newFileStream = null;
            }
        }

        #endregion


        #region Thumbnail viewer

        /// <summary>
        /// Loading of thumbnails is in progress.
        /// </summary>
        private void thumbnailViewer1_ThumbnailsLoadingProgress(
            object sender,
            ThumbnailsLoadingProgressEventArgs e)
        {
            bool progressVisible = e.Progress != 100;
            addThumbnailsProgressBar.Value = e.Progress;
            addThumbnailsProgressBar.Visible = progressVisible;
            addThumbnailsToolStripStatusLabel.Visible = progressVisible;
        }

        #endregion


        #region UI controls

        /// <summary>
        /// Tools tab is selected.
        /// </summary>
        private void toolsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolsTabControl.SelectedTab == bookmarksTabPage)
                documentBookmarks.Document = _document;

            InteractionAreaSettings.VisualTool = _annotationTool;

            if (toolsTabControl.SelectedTab == annotationToolTabPage)
            {
                if (_annotationTool.ImageViewer == null)
                    imageViewer1.VisualTool = new CompositeVisualTool(
#if !REMOVE_ANNOTATION_PLUGIN
                _commentTool,
#endif
#if !REMOVE_OFFICE_PLUGIN
                new Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction.OfficeDocumentVisualEditorTextTool(),
#endif
                _annotationTool);

                annotationToolControl.UpdateUI();
            }
            else if (toolsTabControl.SelectedTab == textExtractionTabPage)
            {
                _textSelectionTool.Enabled = true;
                imageViewer1.VisualTool = _textSelectionTool;
            }
            else if (toolsTabControl.SelectedTab == removeContentTabPage)
            {
                InteractionAreaSettings.VisualTool = _removeContentTool;
                imageViewer1.VisualTool = _redactionTool;
            }
            else if (toolsTabControl.SelectedTab == contentEditorTabPage)
            {
                InteractionAreaSettings.VisualTool = _contentEditorTool;
                imageViewer1.VisualTool = _contentEditorToolComposition;
            }
            else if (toolsTabControl.SelectedTab == commentsTabPage)
            {
                imageViewer1.VisualTool = _defaultAnnotationTool;
            }

            if (imageViewer1.Image != null &&
                PdfDocumentController.GetPageAssociatedWithImage(imageViewer1.Image) == null)
            {
                string status = string.Empty;
                if (toolsTabControl.SelectedTab != pagesTabPage &&
                    toolsTabControl.SelectedTab != bookmarksTabPage)
                    status = "Current image is not a PDF page. Save document and try again.";
                SetStatusLabelTextSafe(status);
            }

            UpdateUI();
        }

        #endregion


        #region Visual Tools

        #region Annotation Tool

        /// <summary>
        /// Handles the InteractionModeChanged event of the PDF AnnotationTool.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs{PdfAnnotationInteractionMode}"/> instance containing the event data.</param>
        private void AnnotationTool_InteractionModeChanged(object sender, PropertyChangedEventArgs<PdfAnnotationInteractionMode> e)
        {
            if (imageViewer1.VisualTool == _defaultAnnotationTool)
            {
                if (e.NewValue == PdfAnnotationInteractionMode.Edit)
                {
                    _textSelectionTool.ClearSelection();
                    _textSelectionTool.Enabled = false;
                }
                else
                {
                    _textSelectionTool.Enabled = true;
                }
            }
#if !REMOVE_ANNOTATION_PLUGIN
            if (commentsControl.IsCommentsOnViewerVisible)
                _commentTool.Enabled = e.NewValue != PdfAnnotationInteractionMode.Edit;
#endif
        }

        /// <summary>
        /// Shows information about hovered annotation.
        /// </summary>
        private void AnnotationTool_HoveredAnnotationChanged(
            object sender,
            PdfAnnotationEventArgs e)
        {
            if (e.Annotation != null)
            {
                PdfAnnotation annotation = e.Annotation;
                if (_annotationTool.InteractionMode == PdfAnnotationInteractionMode.View ||
                    _annotationTool.InteractionMode == PdfAnnotationInteractionMode.Markup)
                    statusLabel.Text = PdfActionsTools.GetActivateActionDescription(annotation);
                else if (_annotationTool.InteractionMode == PdfAnnotationInteractionMode.Edit)
                    statusLabel.Text = PdfDemosTools.GetAnnotationDescription(annotation);
            }
            else
            {
                statusLabel.Text = "";
            }
        }

        /// <summary>
        /// Changed the interaction controller of annotation tool.
        /// </summary>
        private void AnnotationTool_ActiveInteractionControllerChanged(object sender, PropertyChangedEventArgs<IInteractionController> e)
        {
            _textSelectionTool.FocusedTextSymbol = null;

            TextObjectTextBoxTransformer oldTextObjectTextBoxTransformer = GetTextObjectTextBoxTransformer(e.OldValue);
            if (oldTextObjectTextBoxTransformer != null)
            {
                oldTextObjectTextBoxTransformer.TextBoxShown -= TextObjectTextBoxTransformer_TextBoxShown;
                oldTextObjectTextBoxTransformer.TextBoxClosed -= TextObjectTextBoxTransformer_TextBoxClosed;
            }

            TextObjectTextBoxTransformer newTextObjectTextBoxTransformer = GetTextObjectTextBoxTransformer(e.NewValue);
            if (newTextObjectTextBoxTransformer != null)
            {
                newTextObjectTextBoxTransformer.TextBoxShown +=
                    new EventHandler<TextObjectTextBoxTransformerEventArgs>(TextObjectTextBoxTransformer_TextBoxShown);
                newTextObjectTextBoxTransformer.TextBoxClosed +=
                    new EventHandler<TextObjectTextBoxTransformerEventArgs>(TextObjectTextBoxTransformer_TextBoxClosed);
            }
        }

        /// <summary>
        /// Returns the <see cref="Vintasoft.Imaging.UI.VisualTools.UserInteraction.TextObjectTextBoxTransformer"/>
        /// from <see cref="IInteractionController"/>.
        /// </summary>
        /// <param name="controller">The controller.</param>
        private TextObjectTextBoxTransformer GetTextObjectTextBoxTransformer(
            IInteractionController controller)
        {
            if (controller is TextObjectTextBoxTransformer)
                return (TextObjectTextBoxTransformer)controller;

            if (controller is CompositeInteractionController)
            {
                CompositeInteractionController compositeInteractionController = (CompositeInteractionController)controller;

                foreach (IInteractionController item in compositeInteractionController.Items)
                {
                    TextObjectTextBoxTransformer transformer = GetTextObjectTextBoxTransformer(item);
                    if (transformer != null)
                        return transformer;
                }
            }

            return null;
        }

        /// <summary>
        /// Text box of focused annotation is shown.
        /// </summary>
        private void TextObjectTextBoxTransformer_TextBoxShown(object sender, TextObjectTextBoxTransformerEventArgs e)
        {
            DisableEditMenuItems();
        }

        /// <summary>
        /// Text box of focused annotation is closed.
        /// </summary>
        private void TextObjectTextBoxTransformer_TextBoxClosed(object sender, TextObjectTextBoxTransformerEventArgs e)
        {
            EnableEditMenuItems();
        }

        #endregion


        #region Text Selection Tool

        /// <summary>
        /// Text search is in progress.
        /// </summary>
        private void _testSelectionTool_TextSearchingProgress(
            object sender,
            TextSearchingProgressEventArgs e)
        {
            statusLabel.Text = string.Format("Search on page {0}...", e.ImageIndex + 1);
        }

        /// <summary>
        /// Text selection is changed.
        /// </summary>
        private void _textSelectionTool_SelectionChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        #endregion


        #region Text Markup Tool

        /// <summary>
        /// Handles the MarkupAnnotationCreated event of TextMarkupTool object.
        /// </summary>
        private void TextMarkupTool_MarkupAnnotationCreated(object sender, PdfMarkupAnnotationEventArgs e)
        {
            e.MarkupAnnotation.Title = Environment.UserName;
            e.MarkupAnnotation.CreationDate = DateTime.Now;
            switch (e.MarkupAnnotation.AnnotationType)
            {
                case PdfAnnotationType.Caret:
                    e.MarkupAnnotation.Subject = "Insert Text";
                    break;
                case PdfAnnotationType.StrikeOut:
                    e.MarkupAnnotation.Subject = "Strikethrough Text";
                    break;
                case PdfAnnotationType.Highlight:
                    e.MarkupAnnotation.Subject = "Highlighted Text";
                    break;
                case PdfAnnotationType.Squiggly:
                    e.MarkupAnnotation.Subject = "Squiggly Underlined Text";
                    break;
                case PdfAnnotationType.Underline:
                    e.MarkupAnnotation.Subject = "Underlined text";
                    break;
                default:
                    e.MarkupAnnotation.Subject = e.MarkupAnnotation.AnnotationType.ToString();
                    break;
            }

        }

        /// <summary>
        /// Handles the MarkupAnnotationAdded event of TextMarkupTool object.
        /// </summary>
        private void TextMarkupTool_MarkupAnnotationAdded(object sender, PdfMarkupAnnotationEventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            toolsTabControl.SelectedTab = commentsTabPage;
            if (commentsControl.CommentTool == null || !commentsControl.CommentTool.Enabled)
                commentsControl.OpenComment(e.MarkupAnnotation, true);
#endif
        }


        #endregion


        #region Remove Content

        /// <summary>
        /// Redaction marks are applied to the current PDF document.
        /// </summary>
        private void pdfRemoveContentControl1_RedactionMarkApplied(object sender, EventArgs e)
        {
            if (pdfRemoveContentControl1.ShowPackDialogAfterMarkApplied)
                ShowPackDialogAfterMarkIsApplied();
        }

        /// <summary>
        /// Shows the pack dialog after mark is applied.
        /// </summary>
        private void ShowPackDialogAfterMarkIsApplied()
        {
            StringBuilder messageString = new StringBuilder();
            messageString.AppendLine("Redacted content will be removed from PDF document only after packing of PDF document.");
            messageString.AppendLine("Do you want to pack PDF document right now?");
            messageString.AppendLine();
            messageString.AppendLine("Click 'Yes' if you want to pack PDF document right now.");
            messageString.AppendLine();
            messageString.AppendLine("Click 'No' if you will pack PDF document later (\"File -> Pack\" menu) and now you want to work with unpacked PDF document.");

            if (MessageBox.Show(messageString.ToString(), "Pack document?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                SaveAndPackPdfDocument();
        }

        #endregion


        #region PDF Editor Tool

        /// <summary>
        /// Handles the KeyPress event of MainForm object.
        /// </summary>
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if ESC pressed
            if (e.KeyChar == '\x1B')
            {
                AbortBuildFigure();
                e.Handled = true;
            }
            // if Enter key (13) pressed
            if (e.KeyChar == '\xD')
            {
                if (_annotationTool.IsFocusedAnnotationBuilding)
                    _annotationTool.FinishActiveInteraction();
            }
            else
            {
                e.Handled = false;
            }
        }

        /// <summary>
        /// Aborts the building of PDF figure.
        /// </summary>
        private void AbortBuildFigure()
        {
#if !REMOVE_PDFVISUALEDITOR_PLUGIN
            _contentEditorTool.AbortBuildFigure();
#endif
        }

        #endregion


        #region Comment Tool    

        /// <summary>
        /// Adds new comment to focused page.
        /// </summary>
        private void addCommentButton_Click(object sender, EventArgs e)
        {
            if (FocusedPage != null)
            {
                CurrentTool = _defaultAnnotationTool;
                annotationToolControl.AnnotationsControl.AnnotationBuilderControl.AddAndBuildTextAnnotation("Comment");
            }
        }

        /// <summary>
        /// Close all comments on focused image.
        /// </summary>
        private void closeAllCommentsButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            if (FocusedPage != null)
            {
                CommentCollection comments = _commentTool.CommentController.GetComments(imageViewer1.Image);
                if (comments != null)
                {
                    foreach (Comment comment in comments)
                        comment.IsOpen = false;
                }
            }
#endif
        }

        #endregion

        #endregion


        #region PDF document

        /// <summary>
        /// Creates new PDF document.
        /// </summary>
        private bool CreateNewPdfDocument(PdfFormat format, string saveDialogTitle)
        {
            ClosePdfDocument();

            using (SelectPdfFormatForm selectPdfFormatDialog = new SelectPdfFormatForm(format, null))
            {
                saveFileDialog.Title = saveDialogTitle;
                if (selectPdfFormatDialog.ShowDialog() == DialogResult.OK &&
                    saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog.FileName;
                    try
                    {
                        // try open in read-write mode
                        _pdfFileStream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
                    }
                    catch (IOException e)
                    {
                        DemosTools.ShowErrorMessage(e);
                        return false;
                    }
                    _document = new PdfDocument(_pdfFileStream, selectPdfFormatDialog.Format, selectPdfFormatDialog.NewEncryptionSettings, false);

                    AddDocumentEventHandlers();
                    PdfDocumentController.RegisterDocument(_pdfFileStream, _document);

                    pageModeComboBox.SelectedItem = _document.DocumentViewMode.ToString();
                    viewerPageLayoutToolStripComboBox.SelectedItem = _document.ViewerPageLayout.ToString();

                    Filename = filename;
                    IsDocumentChanged = true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Opens an existing PDF document.
        /// </summary>
        private void OpenPdfDocument(string filename)
        {
            ClosePdfDocument();

            IsPdfFileReadOnlyMode = false;
            try
            {
                // try open in read-write mode
                _pdfFileStream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (SystemException)
            {
                IsPdfFileReadOnlyMode = true;
                try
                {
                    // try open in read mode
                    _pdfFileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                }
                catch (SystemException e)
                {
                    DemosTools.ShowErrorMessage(e);
                    return;
                }
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e);
                return;
            }

            StartAction("Open document", false);
            try
            {
                _document = PdfDocumentController.OpenDocument(_pdfFileStream);
                if (_document.IsEncrypted && _document.AuthorizationResult == AuthorizationResult.IncorrectPassword)
                {
                    ClosePdfDocument();
                    return;
                }

                if (_document.Pages.Count == 0)
                {
                    DemosTools.ShowErrorMessage("PDF document does not contain pages.");
                    ClosePdfDocument();
                    return;
                }
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e);
                ClosePdfDocument();
                return;
            }
            finally
            {
                EndAction();
            }

            Filename = filename;
            AddDocumentEventHandlers();
            if (imageViewer1.ImageRenderingSettings is PdfRenderingSettings)
            {
                ((PdfRenderingSettings)imageViewer1.ImageRenderingSettings).UseEmbeddedThumbnails = useEmbeddedThumbnailsToolStripMenuItem.Checked;
                _document.RenderingSettings = (PdfRenderingSettings)imageViewer1.ImageRenderingSettings.Clone();
            }
            _document.RenderingSettings.UseEmbeddedThumbnails = useEmbeddedThumbnailsToolStripMenuItem.Checked;

            pageModeComboBox.SelectedItem = _document.DocumentViewMode.ToString();
            viewerPageLayoutToolStripComboBox.SelectedItem = _document.ViewerPageLayout.ToString();

            // set the display mode of image viewer
            if (_document.ViewerPageLayout == PdfDocumentPageLayoutMode.Undefined)
                imageViewer1.DisplayMode = _defaultImageViewerDisplayMode;
            else
                imageViewer1.DisplayMode = PdfDemosTools.ConvertPageLayoutModeToImageViewerDisplayMode(_document.ViewerPageLayout);

            if (toolsTabControl.SelectedTab == bookmarksTabPage)
                documentBookmarks.Document = _document;

            try
            {
                _pdfFileStream.Position = 0;
                imageViewer1.Images.Add(_pdfFileStream);
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e);
            }

            imageViewer1.Images.ImageCollectionChanged += Images_ImageCollectionChanged;

            _document.IsSavingRequired = false;
            IsDocumentChanged = _document.IsSavingRequired;

            imageViewer1.Focus();
        }

        /// <summary>
        /// Closes PDF document.
        /// </summary>
        private void ClosePdfDocument()
        {
            _annotationTool.CancelBuilding();
            _annotationTool.Clipboard.Clear();
            if (_document != null)
            {
                RemoveDocumentEventHandlers();

                imageViewer1.Images.ImageCollectionChanged -= Images_ImageCollectionChanged;
                imageViewer1.Images.ClearAndDisposeItems();

                PdfDocumentController.CloseDocument(_document);
                _document = null;
                _pdfFileName = "";

                documentBookmarks.Document = null;

                statusLabel.Text = "";
                pageInfoLabel.Text = "";
            }
            if (_pdfFileStream != null)
            {
                _pdfFileStream.Close();
                _pdfFileStream.Dispose();
                _pdfFileStream = null;
            }
            IsDocumentChanged = false;
            Filename = null;

            _isCJKFontMissingErrorMessageShown = false;
        }


        /// <summary>
        /// Returns all PDF documents loaded in image collection.
        /// </summary>
        /// <param name="images">The collection of images.</param>
        private static List<PdfDocument> GetPdfDocumentsAssociatedWithImageCollection(ImageCollection images)
        {
            List<PdfDocument> documents = new List<PdfDocument>();
            foreach (VintasoftImage image in images)
            {
                PdfPage page = PdfDocumentController.GetPageAssociatedWithImage(image);
                PdfDocument document = page.Document;
                if (!documents.Contains(document))
                    documents.Add(document);
            }
            return documents;
        }


        #region PDF document events

        /// <summary>
        /// Adds the event handlers to current document.
        /// </summary>
        private void AddDocumentEventHandlers()
        {
            _document.IsSavingRequiredChanged += Document_IsSavingRequiredChanged_Changed;
        }

        /// <summary>
        /// Removes the event handlers from current document.
        /// </summary>
        private void RemoveDocumentEventHandlers()
        {
            _document.IsSavingRequiredChanged -= Document_IsSavingRequiredChanged_Changed;
        }

        /// <summary>
        /// The PdfDocument.IsSavingRequiredChanged property is changed.
        /// </summary>
        private void Document_IsSavingRequiredChanged_Changed(object sender, EventArgs e)
        {
            IsDocumentChanged = _document.IsSavingRequired;
        }

        #endregion

        #endregion


        #region Verify PDF/A document

        /// <summary>
        /// Verifies PDF document for compatibility with PDF/A format.
        /// </summary>
        /// <param name="pdfAVerifier">PDF/A verifier.</param>
        private void VerifyPdfDocumentForCompatibilityWithPdfA(PdfAVerifier pdfAVerifier)
        {
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(_document, pdfAVerifier);
        }

        #endregion


        #region Sign PDF document

        /// <summary>
        /// Signature field (signature field with value) is added to PDF document.
        /// </summary>
        private void signatureMaker_SignatureAdded(object sender, EventArgs e)
        {
            // update UI
            UpdateUI();
            // sign PDF document and save it to a file
            SavePdfDocumentToSourceOrNewFile(true);
        }

        /// <summary>
        /// Empty signature field (signature field without value) is added to PDF document.
        /// </summary>
        private void signatureMaker_EmptySignatureAdded(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Selects the signature field from list of signature fields.
        /// </summary>
        /// <param name="signatureFields">The list of signature fields.</param>
        /// <returns>Selected signature field.</returns>
        private PdfInteractiveFormSignatureField SelectSignatureField(
            List<PdfInteractiveFormSignatureField> signatureFields)
        {
            // create dialog that allows to select signature field
            using (SelectSignatureFieldForm selectSignatureField = new SelectSignatureFieldForm(signatureFields.ToArray()))
            {
                // if signature field is selected
                if (selectSignatureField.ShowDialog() == DialogResult.OK)
                    // return selected field
                    return selectSignatureField.SelectedField;
            }

            return null;
        }

        #endregion


        #region Obfuscate text in PDF document

        /// <summary>
        /// Obfuscates the text encoding of current page.
        /// </summary>
        /// <param name="progressController">The progress controller.</param>
        private void ObfuscateTextEncodingOfCurrentPage(IActionProgressController progressController)
        {
            _textEncodingObfuscator.Obfuscate(progressController, this.FocusedPage);
        }

        /// <summary>
        /// Obfuscates the text encoding of selected pages.
        /// </summary>
        /// <param name="progressController">The progress controller.</param>
        private void ObfuscateTextEncodingOfSelectedPages(IActionProgressController progressController)
        {
            _textEncodingObfuscator.Obfuscate(progressController, _pagesForObfuscation);
        }

        /// <summary>
        /// Obfuscates the text encoding of document.
        /// </summary>
        /// <param name="progressController">The progress controller.</param>
        private void ObfuscateTextEncodingOfDocument(IActionProgressController progressController)
        {
            List<PdfDocument> loadedDocuments = GetPdfDocumentsAssociatedWithImageCollection(imageViewer1.Images);
            if (loadedDocuments.Count == 1)
            {
                _textEncodingObfuscator.Obfuscate(loadedDocuments[0], progressController);
            }
            else
            {
                progressController.Start("Obfuscating text of loaded documents", loadedDocuments.Count, this);
                foreach (PdfDocument document in loadedDocuments)
                {
                    progressController.Next(false);
                    _textEncodingObfuscator.Obfuscate(document);
                }
                progressController.Finish();
            }
        }

        /// <summary>
        /// Shows the dialog asking to pack PDF document after text obfuscation.
        /// </summary>
        private void ShowPackDialogAfterTextObfuscation()
        {
            StringBuilder messageString = new StringBuilder();
            messageString.AppendLine("Original fonts and content of pages will be removed from PDF document only after packing of PDF document.");
            messageString.AppendLine("Do you want to pack PDF document right now?");
            messageString.AppendLine();
            messageString.AppendLine("Click 'Yes' if you want to pack PDF document right now.");
            messageString.AppendLine();
            messageString.AppendLine("Click 'No' if you will pack PDF document later (\"File -> Pack\" menu) and now you want to work with unpacked PDF document.");

            if (MessageBox.Show(messageString.ToString(), "Pack document?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                SaveAndPackPdfDocument();
        }

        #endregion


        #region Compress PDF document

        /// <summary>
        /// PDF document compression is started.
        /// </summary>
        private void PdfDocumentCompressorCommand_Started(object sender, ProcessingEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<ProcessingEventArgs>(PdfDocumentCompressorCommand_Started), sender, e);
            }
            else
            {
                PdfDocument document = (PdfDocument)e.Target;
                string filename;
                if (document.SourceStream != null)
                    filename = ((FileStream)document.SourceStream).Name;
                else
                    filename = "document1.pdf";

                PdfDocumentCompressorCommand pdfDocumentCompressor = (PdfDocumentCompressorCommand)sender;
                if (pdfDocumentCompressor.DocumentPackOutputFilename == null)
                {
                    saveFileDialog.FileName = string.Format("{0}_Compressed.pdf",
                        Path.GetFileNameWithoutExtension(filename));
                }
                else
                {
                    saveFileDialog.FileName = pdfDocumentCompressor.DocumentPackOutputFilename;
                }

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string newFilename = Path.GetFullPath(saveFileDialog.FileName);
                    string outputFilename = null;
                    if (Path.GetFullPath(filename).ToUpperInvariant() != newFilename.ToUpperInvariant())
                        outputFilename = newFilename;

                    pdfDocumentCompressor.PackDocument = true;
                    pdfDocumentCompressor.DocumentPackFormat = document.Format;
                    pdfDocumentCompressor.DocumentPackOutputFilename = outputFilename;
                }
                else
                {
                    MessageBox.Show(
                        "This PDF document will not be packed(saved) after compression.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    pdfDocumentCompressor.PackDocument = false;
                }
            }
        }

        /// <summary>
        /// PDF document compression is finished.
        /// </summary>
        private void PdfDocumentCompressorCommand_Finished(object sender, ProcessingFinishedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<ProcessingFinishedEventArgs>(PdfDocumentCompressorCommand_Finished), sender, e);
            }
            else
            {
                PdfDocument document = (PdfDocument)e.Target;
                if (document.SourceStream != null)
                {
                    string filename = ((FileStream)document.SourceStream).Name;
                    if (filename.ToUpperInvariant() != Filename.ToUpperInvariant())
                        OpenPdfDocument(filename);
                }
            }
        }

        #endregion


        #region Pack PDF document

        /// <summary>
        /// Saves and packs PDF document.
        /// </summary>
        private bool SaveAndPackPdfDocument()
        {
            return SaveAndPackPdfDocument(_document.Format, _document.EncryptionSystem);
        }

        /// <summary>
        /// Saves and packs PDF document.
        /// </summary>
        private bool SaveAndPackPdfDocument(PdfFormat format, EncryptionSystem encryptionSystem)
        {
            saveFileDialog.Title = null;
            if (_pdfFileName != null)
                saveFileDialog.FileName = _pdfFileName;
            bool isSaved = false;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SavePdfDocument(saveFileDialog.FileName, true, PdfDocumentUpdateMode.CleanupAndPack, format, encryptionSystem);
                isSaved = true;
            }

            return isSaved;
        }

        /// <summary>
        /// Packs current PDF document.
        /// </summary>
        private void PackPdfDocument(PdfFormat format, EncryptionSystem encryptionSystem)
        {
            StartAction("Cleanup", false);
            _document.RemoveUnusedPages();
            _document.RemoveUnusedNames();
            EndAction();

            _document.Progress += _pdfDocument_PackProgress;
            StartAction("Pack", true);
            long size = _document.StreamLength;
            try
            {
                _document.Pack(format, encryptionSystem);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            EndAction();
            statusLabel.Text += string.Format(" [{0}->{1} bytes]", size, _document.StreamLength);
            _document.Progress -= _pdfDocument_PackProgress;
        }

        /// <summary>
        /// PDF document packing is in progress.
        /// </summary>
        private void _pdfDocument_PackProgress(object sender, ImageFileProgressEventArgs e)
        {
            ShowProgressInfo(e.Progress);
        }

        #endregion


        #region Save PDF document

        /// <summary>
        /// Saves PDF document to the source PDF file or new PDF file.
        /// </summary>
        private void SavePdfDocumentToSourceOrNewFile(bool incrementalUpdate)
        {
            OnPdfDocumentSaving();
            bool isCanceled = true;
            try
            {
                if (_pdfFileName != null)
                {
                    saveFileDialog.Title = null;
                    saveFileDialog.FileName = _pdfFileName;
                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    isCanceled = false;
                    PdfDocumentUpdateMode documentUpdateMode;
                    if (incrementalUpdate)
                        documentUpdateMode = PdfDocumentUpdateMode.Incremental;
                    else
                        documentUpdateMode = PdfDocumentUpdateMode.Auto;
                    SavePdfDocument(
                        saveFileDialog.FileName,
                        true,
                        documentUpdateMode,
                        _document.Format,
                        _document.EncryptionSystem);
                }
            }
            finally
            {
                OnPdfDocumentSaved(isCanceled);
            }
        }

        /// <summary>
        /// Saves changes in PDF document.
        /// </summary>
        private void SaveChangesInPdfDocument(PdfDocumentUpdateMode updateMode)
        {
            SaveChangesInPdfDocument(updateMode, _document.Format, _document.EncryptionSystem);
        }

        /// <summary>
        /// Saves changes in PDF document.
        /// </summary>
        private void SaveChangesInPdfDocument(PdfDocumentUpdateMode updateMode, PdfFormat format, EncryptionSystem encryptionSystem)
        {
            _contentEditorTool.RenderFiguresOnPage();
            if (IsDocumentChanged ||
                format != _document.Format ||
                encryptionSystem != _document.EncryptionSystem)
            {
                AbortBuildFigure();

                IsDocumentChanged = false;
                PdfEncoder encoder = CreateEncoder(format, encryptionSystem);
                encoder.SaveAndSwitchSource = true;
                encoder.Settings.UpdateMode = updateMode;
                StartAction("Save", true);
                try
                {
                    imageViewer1.Images.SaveSync(_pdfFileStream, encoder);
                    OnImageCollectionSaved(false);
                }
                catch (Exception e)
                {
                    OnImageCollectionSaved(true);
                    DemosTools.ShowErrorMessage("Saving error", e);
                }
                EndAction();
            }
        }

        /// <summary>
        /// Saves PDF document.
        /// </summary>
        private void SavePdfDocument(string filename, bool switchToSource)
        {
            SavePdfDocument(
                filename,
                switchToSource,
                PdfDocumentUpdateMode.Auto,
                _document.Format,
                _document.EncryptionSystem);
        }

        /// <summary>
        /// Saves PDF document.
        /// </summary>
        private void SavePdfDocument(
            string filename,
            bool switchToSource,
            PdfDocumentUpdateMode updateMode,
            PdfFormat format,
            EncryptionSystem encryptionSystem)
        {
            _contentEditorTool.RenderFiguresOnPage();
            _annotationTool.FocusedAnnotationView = null;

            if (filename.ToLowerInvariant() == _pdfFileName.ToLowerInvariant())
            {
                try
                {
                    SaveChangesInPdfDocument(updateMode, format, encryptionSystem);
                }
                catch (Exception e)
                {
                    DemosTools.ShowErrorMessage(e);
                }
                return;
            }

            PdfEncoder encoder = CreateEncoder(format, encryptionSystem);
            encoder.SaveAndSwitchSource = switchToSource;
            encoder.Settings.UpdateMode = updateMode;


            if (switchToSource)
            {
                AbortBuildFigure();
                try
                {
                    _newFileStream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
                }
                catch (IOException e)
                {
                    DemosTools.ShowErrorMessage(e);

                    return;
                }
                IsDocumentChanged = false;

                StartAction("Save As", true);
                _switchPdfFileStreamToNewStream = true;

                ImageCollection images = imageViewer1.Images;
                try
                {
                    images.ImageCollectionSavingProgress += new EventHandler<ProgressEventArgs>(Images_ImageCollectionSavingProgress);
                    encoder.SaveAndSwitchSource = true;
                    images.SaveSync(_newFileStream, encoder);

                    OnImageCollectionSaved(false);
                }
                catch (Exception e)
                {
                    OnImageCollectionSaved(true);
                    DemosTools.ShowErrorMessage("Saving error", e);
                }
                finally
                {
                    images.ImageCollectionSavingProgress -= new EventHandler<ProgressEventArgs>(Images_ImageCollectionSavingProgress);
                }
                Filename = filename;
                EndAction();
            }
            else
            {
                StartAction("Save To", true);
                using (Stream destStream = File.Create(filename))
                {
                    ImageCollection images = imageViewer1.Images;
                    try
                    {
                        images.ImageCollectionSavingProgress += new EventHandler<ProgressEventArgs>(Images_ImageCollectionSavingProgress);
                        encoder.SaveAndSwitchSource = false;
                        images.SaveSync(destStream, encoder);

                        OnImageCollectionSaved(false);
                    }
                    catch (Exception e)
                    {
                        OnImageCollectionSaved(true);
                        DemosTools.ShowErrorMessage("Saving error", e);
                    }
                    finally
                    {
                        images.ImageCollectionSavingProgress -= new EventHandler<ProgressEventArgs>(Images_ImageCollectionSavingProgress);
                    }
                }
                EndAction();
            }
        }

        /// <summary>
        /// Saves PDF document as new PDF document.
        /// </summary>
        private void SavePdfDocumentAs()
        {
            OnPdfDocumentSaving();
            bool isCanceled = true;
            try
            {
                saveFileDialog.Title = null;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    isCanceled = false;
                    SavePdfDocument(saveFileDialog.FileName, true);
                }
            }
            finally
            {
                OnPdfDocumentSaved(isCanceled);
            }
        }

        /// <summary>
        /// PDF document is saving.
        /// </summary>
        private void OnPdfDocumentSaving()
        {
            IsPdfFileSaving = true;
            _isUpdateUIEnabled = false;

            // execute PdfDocument.AdditionalActions.Saving action
            PdfJsDoc doc = _annotationTool.JsApp.GetDoc(_document);
            if (doc != null)
                _annotationTool.RaiseDocumentTriggerEvent(PdfJsEvent.CreateDocWillSaveEventObject(doc));
        }

        /// <summary>
        /// PDF document is saved.
        /// </summary>
        /// <param name="isCanceled">Indicates that saving of PDF document is canceled.</param>
        private void OnPdfDocumentSaved(bool isCanceled)
        {
            pdfContentEditorControl1.UpdateUI();

            if (!isCanceled)
            {
                // execute PdfDocument.AdditionalActions.Saved action
                PdfJsDoc doc = _annotationTool.JsApp.GetDoc(_document);
                if (doc != null)
                    _annotationTool.RaiseDocumentTriggerEvent(PdfJsEvent.CreateDocDidSaveEventObject(doc));
            }

            _isUpdateUIEnabled = true;
            IsPdfFileSaving = false;

            if (!isCanceled)
                IsDocumentChanged = _document.IsSavingRequired;
        }

        /// <summary>
        /// Creates new instance of PdfEncoder class.
        /// </summary>
        private PdfEncoder CreateEncoder(PdfFormat format, EncryptionSystem encryptionSystem)
        {
            _usePdfEncoderSettingsForAllImages = false;
            PdfEncoder encoder = new PdfEncoder();
            encoder.DocumentFormat = format;
            if (encryptionSystem != _document.EncryptionSystem)
                encoder.SetEncryptionSystem(encryptionSystem);
            encoder.Settings = _pdfEncoderSettings;
            encoder.ImageSaving += new EventHandler<ImageSavingEventArgs>(encoder_ImageSaving);
            return encoder;
        }

        /// <summary>
        /// Image (PDF page) is saving.
        /// </summary>
        private void encoder_ImageSaving(object sender, ImageSavingEventArgs e)
        {
            if (_usePdfEncoderSettingsForAllImages)
                return;
            if (PdfDocumentController.GetPageAssociatedWithImage(e.Image) != null)
                // this is PdfPage, not image!
                return;

            int index = imageViewer1.Images.IndexOf(e.Image);
            using (SetCompressionParamsForm setCompressionParamsDialog = new SetCompressionParamsForm(index, e.Image, _pdfEncoderSettings))
            {
                if (setCompressionParamsDialog.ShowDialog() == DialogResult.OK)
                    _usePdfEncoderSettingsForAllImages = setCompressionParamsDialog.UseCompressionForAllImages;
            }
        }

        /// <summary>
        /// Handles the ImageSavingException event of the imageViewer1.Images control.
        /// </summary>
        private void Images_ImageSavingException(object sender, ExceptionEventArgs e)
        {
            DemosTools.ShowErrorMessage(e.Exception);
        }

        #endregion


        #region Convert PDF document to PDF/A document

        /// <summary>
        /// Converts PDF document to PDF/A.
        /// </summary>
        /// <param name="pdfAConverter">PDF/A converter.</param>
        private void ConvertPdfDocumentToPdfA(PdfDocumentConverter pdfAConverter)
        {
            pdfAConverter.Started += new EventHandler<ProcessingEventArgs>(PdfAConverter_Started);
            pdfAConverter.Finished += new EventHandler<ProcessingFinishedEventArgs>(PdfAConverter_Finished);

            // convert PDF document to the PDF/A-1b format
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(_document, pdfAConverter);
        }

        /// <summary>
        /// PDF document conversion is started.
        /// </summary>
        private void PdfAConverter_Started(object sender, ProcessingEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<ProcessingEventArgs>(PdfAConverter_Started), sender, e);
            }
            else
            {
                PdfDocument document = (PdfDocument)e.Target;
                string filename;
                if (document.SourceStream != null)
                    filename = ((FileStream)document.SourceStream).Name;
                else
                    filename = "document1.pdf";

                PdfAConverter pdfAConverter = (PdfAConverter)sender;
                if (pdfAConverter.OutputFilename == null)
                {
                    saveFileDialog.FileName = string.Format("{0}_Converted.pdf", Path.GetFileNameWithoutExtension(filename));
                }
                else
                {
                    saveFileDialog.FileName = pdfAConverter.OutputFilename;
                }

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string newFilename = Path.GetFullPath(saveFileDialog.FileName);
                    string outputFilename = null;
                    if (Path.GetFullPath(filename).ToUpperInvariant() != newFilename.ToUpperInvariant())
                        outputFilename = newFilename;
                    pdfAConverter.OutputFilename = outputFilename;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// PDF document conversion is finished.
        /// </summary>
        private void PdfAConverter_Finished(object sender, ProcessingFinishedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<ProcessingFinishedEventArgs>(PdfAConverter_Finished), sender, e);
            }
            else
            {
                PdfDocument document = (PdfDocument)e.Target;
                if (document.SourceStream != null)
                {
                    string filename = ((FileStream)document.SourceStream).Name;
                    if (filename.ToUpperInvariant() != Filename.ToUpperInvariant())
                        OpenPdfDocument(filename);
                }
            }
        }

        #endregion


        #region Convert PDF document to SVG

        /// <summary>
        /// Converts PDF document to the SVG files.
        /// </summary>
        /// <param name="obj">An array that contains SVG encoder and file path.</param>
        private void ConvertPdfDocumentToSvgFilesThread(object obj)
        {
            object[] paramsArray = (object[])obj;
            EncoderBase svgEncoder = paramsArray[0] as EncoderBase;
            string filePath = paramsArray[1] as string;

            // create action progress controller to track saving progress
            ActionProgressController progressController = new ActionProgressController(ActionProgressHandlers.CreateActionProgressHandler(Images_ImageCollectionSavingProgress));

            // start progress controller
            progressController.Start("Converting to SVG", imageViewer1.Images.Count, this);

            try
            {
                // if image collection contains 1 image
                if (imageViewer1.Images.Count == 1)
                {
                    // increase progress value
                    progressController.Next(false);

                    imageViewer1.Image.Save(filePath, svgEncoder);
                }
                // if image collection contains several image
                else
                {
                    // create file name template with page number
                    string dirPath = Path.GetDirectoryName(filePath);
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string pageNameTemplate = Path.Combine(dirPath, fileName + "_PAGE_{0}.svg");

                    // for each image in image collection
                    for (int i = 0; i < imageViewer1.Images.Count; i++)
                    {
                        // increase progress value
                        progressController.Next(false);

                        // create file path
                        filePath = string.Format(pageNameTemplate, i + 1);
                        // save image to SVG file
                        imageViewer1.Images[i].Save(filePath, svgEncoder);
                    }
                }
            }
            finally
            {
                svgEncoder.Dispose();
            }

            progressController.Finish();

            EndAction();
        }

        #endregion


        #region Utils

        /// <summary>
        /// Prints page(s) of PDF document.
        /// </summary>
        private void Print()
        {
            PdfJsDoc doc = _annotationTool.JsApp.GetDoc(_document);

            // execute PdfDocument.AdditionalActions.Printing action
            if (doc != null)
                _annotationTool.RaiseDocumentTriggerEvent(PdfJsEvent.CreateDocWillPrintEventObject(doc));

            _thumbnailViewerPrintManager.Print();

            // execute PdfDocument.AdditionalActions.Printed action                
            if (doc != null)
                _annotationTool.RaiseDocumentTriggerEvent(PdfJsEvent.CreateDocDidPrintEventObject(doc));
        }


        /// <summary>
        /// Packs all fonts of loaded PDF documents.
        /// </summary>
        /// <param name="progressController">Progress controller.</param>
        private void PackAllFonts(IActionProgressController progressController)
        {
            List<PdfDocument> loadedDocuments = GetPdfDocumentsAssociatedWithImageCollection(imageViewer1.Images);
            if (loadedDocuments.Count == 1)
            {
                // pack all fonts of PDF document loaded in image viewer
                loadedDocuments[0].FontManager.PackAllFonts(progressController);
            }
            else
            {
                progressController.Start("Packing fonts of loaded documents", loadedDocuments.Count, this);
                // pack all fonts of all PDF documents loaded in image viewer
                foreach (PdfDocument document in loadedDocuments)
                {
                    progressController.Next(false);
                    document.FontManager.PackAllFonts();
                }
                progressController.Finish();
            }
        }

        /// <summary>
        /// Handles the StatusChanged event of the JavaScriptActionExecutor.
        /// </summary>
        private void JavaScriptActionExecutor_StatusChanged(
            object sender,
            PdfJavaScriptActionStatusChangedEventArgs e)
        {
            SetStatusLabelTextSafe(e.Status);
        }


        /// <summary>
        /// Shows a message box with error information.
        /// </summary>
        private void ShowMessage_CurrentImageIsNotPdfPage()
        {
            MessageBox.Show("Current image is not a PDF page. Save document and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// Shows progress information.
        /// </summary>
        private void ShowProgressInfo(int progress)
        {
            if (InvokeRequired)
            {
                Invoke(new ShowProgressInfoDelegate(ShowProgressInfo), progress);
            }
            else
            {
                bool progressVisible = progress != 100;
                progressBar.Value = progress;
                progressBar.Visible = progressVisible;
                if (!progressVisible)
                    EndAction();
            }
        }

        /// <summary>
        /// Sets text of status label (thread-safe).
        /// </summary>
        private void SetStatusLabelTextSafe(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new SetStatusLabelTextDelegate(SetStatusLabelTextSafe), text);
            }
            else
            {
                statusLabel.Text = text;
                mainStatusStrip.Refresh();
            }
        }


        /// <summary>
        /// Adds the path (all files and sub folders) to specified folder.
        /// </summary>
        /// <param name="folder">The portfolio folder.</param>
        /// <param name="path">The path that should be added to the portfolio.</param>
        /// <param name="addPathAsFolder">Determines that portfolio must contain folder with the path filename.</param>
        /// <param name="compression">The compression that should be applied to files and folders.</param>
        /// <param name="actionController">The action controller.</param>
        /// <returns>Added folder.</returns>
        private static PdfAttachmentFolder AddPathRecursively(
            PdfAttachmentFolder folder,
            string path,
            bool addPathAsFolder,
            PdfCompression compression,
            StatusStripActionController actionController)
        {
            // folder to which path must be added
            PdfAttachmentFolder currentFolder;
            // if portfolio must contain folder with the path filename
            if (addPathAsFolder)
            {
                // add new folder to portfolio folder and use it as current folder
                currentFolder = folder.AddFolder(Path.GetFileName(path));
                currentFolder.CreationDate = DateTime.Now;
            }
            else
            {
                // use root folder as current folder
                currentFolder = folder;
                folder.ModificationDate = DateTime.Now;
            }

            // get files in the specified path
            string[] files = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);
            // if files are found
            if (files.Length > 0)
            {
                // for each file
                foreach (string filename in files)
                {
                    try
                    {
                        // if file is not hidden
                        if ((File.GetAttributes(filename) & FileAttributes.Hidden) == 0)
                        {
                            // add file
                            actionController.NextSubAction(Path.GetFileName(filename));
                            PdfEmbeddedFileSpecification file = currentFolder.AddFile(filename, compression);
                            file.EmbeddedFile.CreationDate = DateTime.Now;
                        }
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(string.Format("{0}: {1}", filename, ex.Message));
                    }
                }
                currentFolder.ModificationDate = DateTime.Now;
            }

            // get directories in the specified path
            string[] paths = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
            // for each directory
            foreach (string subPath in paths)
            {
                try
                {
                    // if directory is no thidden
                    if ((File.GetAttributes(subPath) & FileAttributes.Hidden) != 0)
                    {
                        // add the directory (all files and sub folders) to current portfolio folder
                        AddPathRecursively(currentFolder, subPath, true, compression, actionController);
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(string.Format("{0}: {1}", currentFolder, ex.Message));
                }
            }

            return currentFolder;
        }


        /// <summary>
        /// Returns the document processing target.
        /// </summary>
        private PdfDocument GetDocumentProcessingTarget()
        {
            if (GetDocumentStructureIsChanged(imageViewer1.Images, _document))
            {
                DemosTools.ShowInfoMessage("PDF Document Processing", "Current document has not saved structural changes, please save or pack document first.");
                return null;
            }
            return _document;
        }

        /// <summary>
        /// Determines that PDF document structure is changed.
        /// </summary>
        /// <param name="documentPages">The document pages.</param>
        /// <param name="document">The document.</param>
        private static bool GetDocumentStructureIsChanged(
            ImageCollection documentPages,
            PdfDocument document)
        {
            if (documentPages.Count != document.Pages.Count)
                return true;
            for (int i = 0; i < documentPages.Count; i++)
                if (PdfDocumentController.GetPageAssociatedWithImage(documentPages[i]) != document.Pages[i])
                    return true;
            return false;
        }


        #region Action

        /// <summary>
        /// Saves the start time of the action.
        /// </summary>
        private void StartAction(string actionName, bool progress)
        {
            _actionStartTime = DateTime.Now;
            _actionName = actionName;

            if (progress)
                actionName += ":";
            else
                actionName += "...";

            SetStatusLabelTextSafe(actionName);
        }

        /// <summary>
        /// Does the tasks when action is finished.
        /// </summary>
        private void EndAction()
        {
            if (_actionName != "")
            {
                double ms = (DateTime.Now - _actionStartTime).TotalMilliseconds;
                string msString;
                if (ms < 1)
                    msString = "<1";
                else
                    msString = ms.ToString();
                SetStatusLabelTextSafe(string.Format("{0}: {1} ms", _actionName, msString));
                _actionName = "";
            }
        }

        /// <summary>
        /// Does the tasks when action is canceled.
        /// </summary>
        private void EndCanceledAction()
        {
            if (_actionName != "")
            {
                SetStatusLabelTextSafe(string.Format("{0}: canceled", _actionName));
                _actionName = "";
            }
        }

        /// <summary>
        /// Does the tasks when action is failed.
        /// </summary>
        private void EndFailedAction()
        {
            SetStatusLabelTextSafe("");
            _actionName = "";
        }

        #endregion

        #endregion

        #endregion

        #endregion



        #region Delegates

        delegate void UpdateUIDelegate();

        delegate void CloseDocumentDelegate();

        delegate void ShowProgressInfoDelegate(int progress);

        delegate void SetStatusLabelTextDelegate(string text);

        delegate bool SaveAndPackDelegate();

















        #endregion


    }
}
