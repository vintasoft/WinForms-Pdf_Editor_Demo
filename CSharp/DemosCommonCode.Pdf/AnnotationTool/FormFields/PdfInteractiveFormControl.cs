using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;
using Vintasoft.Imaging.Pdf.UI.Annotations;
using Vintasoft.Imaging.UI.VisualTools;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit the PDF interactive form of PDF document.
    /// </summary>
    public partial class PdfInteractiveFormControl : UserControl
    {

        #region Fields

        /// <summary>
        /// An array of copied PDF interactive form fields.
        /// </summary>
        PdfInteractiveFormField[] _fieldClipboard;

        /// <summary>
        /// Indicates that CUT operation is active.
        /// </summary>
        bool _cutOperation = false;

        /// <summary>
        /// Dictionary: the tool strip menu item => interactive form field type.
        /// </summary>
        Dictionary<ToolStripMenuItem, InteractiveFormFieldType> _toolStripMenuItemToInteractiveFormFieldType =
            new Dictionary<ToolStripMenuItem, InteractiveFormFieldType>();

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfInteractiveFormControl"/> class.
        /// </summary>
        public PdfInteractiveFormControl()
        {
            InitializeComponent();

            InitializeToolStripMenuItems();
        }

        #endregion



        #region Properties


        PdfAnnotationTool _annotationTool;
        /// <summary>
        /// Gets or sets the PDF annotation tool.
        /// </summary>
        [DefaultValue((object)null)]
        public PdfAnnotationTool AnnotationTool
        {
            get
            {
                return _annotationTool;
            }
            set
            {
                if (_annotationTool != value)
                {
                    if (_annotationTool != null)
                        UnsubscribeFromAnnotationToolEvents(_annotationTool);

                    _annotationTool = value;
                    InteractiveFormFieldBuilder.AnnotationTool = value;
                    interactiveFormFieldTree.AnnotationTool = value;

                    if (_annotationTool != null)
                    {
                        SubscribeToAnnotationToolEvents(_annotationTool);
                        mainPanel.Enabled = _annotationTool.ImageViewer != null;
                    }
                    UpdateUI();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the control can delete field.
        /// </summary>
        public bool CanDeleteField
        {
            get
            {
                return AnnotationTool != null && interactiveFormFieldTree.SelectedField != null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the control can copy field.
        /// </summary>
        public bool CanCopyField
        {
            get
            {
                return AnnotationTool != null && interactiveFormFieldTree.SelectedField != null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the control can paste field.
        /// </summary>
        public bool CanPasteField
        {
            get
            {
                return AnnotationTool.FocusedPage != null && AnnotationTool.FocusedPage != null && _fieldClipboard != null;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Gets the appearance generator for specified annotation view.
        /// </summary>
        /// <param name="view">The annotation view.</param>
        public PdfAnnotationAppearanceGenerator GetAppearanceGenerator(PdfAnnotationView view)
        {
            return InteractiveFormFieldBuilder.AnnotationAppearanceGeneratorController.GetAppearanceGenerator(view);
        }

        /// <summary>
        /// Copies the field that selected in interactive form field tree.
        /// </summary>
        public void CopyField()
        {
            try
            {
                _cutOperation = false;
                if (CanCopyField)
                {
                    _fieldClipboard = new PdfInteractiveFormField[] { interactiveFormFieldTree.SelectedField };
                    AnnotationTool.Clipboard.Clear();
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Cuts the field that selected on interactive form field tree.
        /// </summary>
        public void CutField()
        {
            CopyField();
            _cutOperation = true;
            DeleteField();
        }

        /// <summary>
        /// Pastes the field into field selected in interactive form field tree.
        /// </summary>
        public void PasteField()
        {
            try
            {
                if (CanPasteField)
                {
                    for (int i = 0; i < _fieldClipboard.Length; i++)
                    {
                        PdfInteractiveFormFieldList targetList = GetFieldList(AnnotationTool.FocusedField, _fieldClipboard[i]);
                        if (!_cutOperation || _fieldClipboard[i].Document != targetList.Document)
                        {
                            _fieldClipboard[i] = AnnotationTool.InteractiveFormEditorManager.AddCopy(
                                targetList, AnnotationTool.AnnotationCollection, _fieldClipboard[i], 10, -10);
                        }
                        else
                        {
                            AnnotationTool.InteractiveFormEditorManager.Add(
                                targetList, AnnotationTool.AnnotationCollection, _fieldClipboard[i], 10, -10);
                        }
                        if (AnnotationTool.AllowMultipleSelection)
                        {
                            AnnotationTool.SelectedAnnotationViewCollection.Clear();
                            foreach (PdfInteractiveFormField field in _fieldClipboard)
                                AddToSelection(field.GetAnnotations());
                        }
                        PdfAnnotation[] annotations = _fieldClipboard[0].GetAnnotations();
                        if (annotations != null && annotations.Length > 0)
                            AnnotationTool.FocusedAnnotationView = AnnotationTool.GetAnnotationViewAssociatedWith(annotations[0]);
                    }
                }
                _cutOperation = false;
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Adds annotations to selection.
        /// </summary>
        /// <param name="annotations">The annotations.</param>
        private void AddToSelection(IEnumerable<PdfAnnotation> annotations)
        {
            foreach (PdfAnnotation annotation in annotations)
            {
                PdfAnnotationView view = AnnotationTool.GetAnnotationViewAssociatedWith(annotation);
                if (view != null)
                    AnnotationTool.SelectedAnnotationViewCollection.Add(view);
            }
        }

        /// <summary>
        /// Deletes the field that selected in interactive form field tree.
        /// </summary>
        public void DeleteField()
        {
            try
            {
                if (interactiveFormFieldTree.SelectedField != null)
                    AnnotationTool.InteractiveFormEditorManager.Remove(interactiveFormFieldTree.SelectedField);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }


        /// <summary>
        /// Updates the User Interface.
        /// </summary>
        public void UpdateUI()
        {
            if (_annotationTool != null)
            {
                mainPanel.Enabled = true;
                showFieldNamesCheckBox.Checked = _annotationTool.ShowFieldNames;
            }
            else
            {
                mainPanel.Enabled = false;
            }

            InteractiveFormFieldBuilder.UpdateUI();
        }

        /// <summary>
        /// Updates the field.
        /// </summary>
        /// <param name="field">The field.</param>
        public void UpdateField(PdfInteractiveFormField field)
        {
            interactiveFormFieldTree.UpdateField(field);
        }

        /// <summary>
        /// Refreshes the interactive form tree.
        /// </summary>
        public void RefreshInteractiveFormTree()
        {
            interactiveFormFieldTree.RefreshInteractiveFormTree();
        }

        #endregion


        #region PRIVATE

        #region UI

        #region Checkboxes

        /// <summary>
        /// Handles the CheckedChanged event of showFieldNamesCheckBox object.
        /// </summary>
        private void showFieldNamesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if field name must be shown
            if (showFieldNamesCheckBox.Checked)
                AnnotationTool.ShowFieldNames = true;
            else
                AnnotationTool.ShowFieldNames = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of groupFormFieldsByPagesCheckBox object.
        /// </summary>
        private void groupFormFieldsByPagesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if form fields must be grouped by page
            if (groupFormFieldsByPagesCheckBox.Checked)
                interactiveFormFieldTree.GroupFormFieldsByPages = true;
            else
                interactiveFormFieldTree.GroupFormFieldsByPages = false;
        }

        #endregion


        #region InteractiveFormFieldTree

        /// <summary>
        /// Handles the MouseDoubleClick event of interactiveFormFieldTree object.
        /// </summary>
        private void interactiveFormFieldTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // if annotation is focused
            if (AnnotationTool.FocusedAnnotationView != null)
            {
                PdfAnnotationView view = AnnotationTool.FocusedAnnotationView;
                // create annotation properties dialog
                using (PdfAnnotationPropertiesForm annotationProperties = new PdfAnnotationPropertiesForm(view))
                {
                    annotationProperties.ShowDialog();
                    if (view.Figure is PdfWidgetAnnotationGraphicsFigure)
                        interactiveFormFieldTree.UpdateField(((PdfWidgetAnnotationGraphicsFigure)view.Figure).Field);
                }
            }
        }

        #endregion


        #region FieldContextMenuStrip

        /// <summary>
        /// Handles the Opening event of fieldContextMenuStrip object.
        /// </summary>
        private void fieldContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // if field content menu opened on form field tree
            if (fieldContextMenuStrip.SourceControl == interactiveFormFieldTree)
            {
                cutFieldToolStripMenuItem.Enabled = CanCopyField;
                copyFieldToolStripMenuItem.Enabled = CanCopyField;
                pasteAnnotationOrFieldToolStripMenuItem.Enabled = CanPasteField;
                deleteFieldToolStripMenuItem.Enabled = CanDeleteField;
                propertiesToolStripMenuItem1.Enabled = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Handles the Click event of cutFieldToolStripMenuItem object.
        /// </summary>
        private void cutFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // cut field
            CutField();
        }

        /// <summary>
        /// Handles the Click event of copyFieldToolStripMenuItem object.
        /// </summary>
        private void copyFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // copy field
            CopyField();
        }

        /// <summary>
        /// Handles the Click event of deleteFieldToolStripMenuItem object.
        /// </summary>
        private void deleteFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // delete field
            DeleteField();
        }

        /// <summary>
        /// Handles the Click event of pasteAnnotationOrFieldToolStripMenuItem object.
        /// </summary>
        private void pasteAnnotationOrFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // paste field
            PasteField();
        }

        /// <summary>
        /// Handles the Click event of addInteractiveFormFieldToolStripMenuItem object.
        /// </summary>
        private void addInteractiveFormFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            // get interactive form field type
            InteractiveFormFieldType interactiveFormFieldType =
                _toolStripMenuItemToInteractiveFormFieldType[toolStripMenuItem];
            // get paret field
            PdfInteractiveFormField parentField = GetFocusedNonTerminalField();
            // build interactive form field
            InteractiveFormFieldBuilder.AddAndBuildInteractiveFormField(
                interactiveFormFieldType, parentField);
        }

        /// <summary>
        /// Handles the Click event of fieldPropertiesToolStripMenuItem object.
        /// </summary>
        private void fieldPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfAnnotationPropertiesForm annotationProperties = null;
            // get selected field
            PdfInteractiveFormField field = interactiveFormFieldTree.SelectedField;
            // if selected field exists
            if (field != null)
            {
                PdfAnnotationView view = null;

                // if field has annotation
                if (field.Annotation != null)
                {
                    // find field view
                    foreach (PdfAnnotationView annoView in AnnotationTool.AnnotationViewCollection)
                    {
                        if (annoView.Annotation == field.Annotation)
                        {
                            view = annoView;
                            break;
                        }
                    }
                }

                // if field annotation exists
                if (view != null)
                    annotationProperties = new PdfAnnotationPropertiesForm(view);
                else
                    annotationProperties = new PdfAnnotationPropertiesForm(field);
            }

            if (annotationProperties != null)
            {
                annotationProperties.ShowDialog();
                annotationProperties.Dispose();
                interactiveFormFieldTree.UpdateField(field);
            }
        }

        #endregion 

        #endregion


        #region PDF annotation tool

        /// <summary>
        /// Subscribes to the PDF annotation tool events.
        /// </summary>
        /// <param name="annotationTool">The annotation tool.</param>
        private void SubscribeToAnnotationToolEvents(PdfAnnotationTool annotationTool)
        {
            annotationTool.FocusedFieldChanged += new PropertyChangedEventHandler<PdfInteractiveFormField>(annotationTool_FocusedFieldChanged);
            annotationTool.AnnotationMouseButtonDown += annotationTool_MouseDown;
            annotationTool.Activated += new EventHandler(annotationTool_Activated);
            annotationTool.Deactivated += new EventHandler(annotationTool_Deactivated);
            annotationTool.BuildingStarted += new EventHandler<PdfAnnotationViewEventArgs>(annotationTool_BuildingStarted);
            annotationTool.BuildingFinished += new EventHandler<PdfAnnotationViewEventArgs>(annotationTool_BuildingFinished);
            annotationTool.BuildingCanceled += new EventHandler<PdfAnnotationViewEventArgs>(annotationTool_BuildingCanceled);
        }

        /// <summary>
        /// Unsubsribes from the PDF annotation tool events.
        /// </summary>
        /// <param name="annotationTool">The annotation tool.</param>
        private void UnsubscribeFromAnnotationToolEvents(PdfAnnotationTool annotationTool)
        {
            annotationTool.FocusedFieldChanged -= new PropertyChangedEventHandler<PdfInteractiveFormField>(annotationTool_FocusedFieldChanged);
            annotationTool.AnnotationMouseButtonDown -= annotationTool_MouseDown;
            annotationTool.Activated -= new EventHandler(annotationTool_Activated);
            annotationTool.Deactivated -= new EventHandler(annotationTool_Deactivated);
            annotationTool.BuildingStarted -= annotationTool_BuildingStarted;
            annotationTool.BuildingFinished -= annotationTool_BuildingFinished;
            annotationTool.BuildingCanceled -= annotationTool_BuildingCanceled;
        }

        /// <summary>
        /// Annotation building is started.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PdfAnnotationViewEventArgs"/> instance containing the event data.</param>
        private void annotationTool_BuildingStarted(object sender, PdfAnnotationViewEventArgs e)
        {
            interactiveFormFieldTree.Enabled = false;
        }

        /// <summary>
        /// Annotation building is canceled.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PdfAnnotationViewEventArgs"/> instance containing the event data.</param>
        private void annotationTool_BuildingCanceled(object sender, PdfAnnotationViewEventArgs e)
        {
            interactiveFormFieldTree.Enabled = true;
        }

        /// <summary>
        /// Annotation building is finished.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PdfAnnotationViewEventArgs"/> instance containing the event data.</param>
        private void annotationTool_BuildingFinished(object sender, PdfAnnotationViewEventArgs e)
        {
            if (!AnnotationTool.IsFocusedAnnotationBuilding)
                interactiveFormFieldTree.Enabled = true;
        }

        /// <summary>
        /// PDF annotation tool is activated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void annotationTool_Activated(object sender, EventArgs e)
        {
            mainPanel.Enabled = true;
        }

        /// <summary>
        /// PDF annotation tool is deactivated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void annotationTool_Deactivated(object sender, EventArgs e)
        {
            mainPanel.Enabled = false;
        }

        /// <summary>
        /// The mouse is down.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisualToolMouseEventArgs"/> instance containing the event data.</param>
        private void annotationTool_MouseDown(object sender, PdfAnnotationViewMouseEventArgs e)
        {
            // if left mouse button is down
            if (e.MouseEventArgs.Button == MouseButtons.Left)
            {
                // if focused annotation view is Signature Field
                if (e.AnnotationView is PdfSignatureWidgetAnnotationView)
                {
                    InteractiveFormFieldBuilder.ShowSignatureDialog((PdfSignatureWidgetAnnotationView)e.AnnotationView);
                }
            }
        }

        /// <summary>
        /// Focused field is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs{PdfInteractiveFormField}"/> instance containing the event data.</param>
        private void annotationTool_FocusedFieldChanged(
            object sender,
            PropertyChangedEventArgs<PdfInteractiveFormField> e)
        {
            if (e.NewValue != null)
                interactiveFormFieldTree.SelectedField = e.NewValue;
        }

        #endregion


        /// <summary>
        /// Initializes the tool strip menu items.
        /// </summary>
        private void InitializeToolStripMenuItems()
        {
            _toolStripMenuItemToInteractiveFormFieldType.Add(
                addTextFieldToolStripMenuItem, InteractiveFormFieldType.TextField);

            _toolStripMenuItemToInteractiveFormFieldType.Add(
                addCheckBoxToolStripMenuItem, InteractiveFormFieldType.CheckBox);

            _toolStripMenuItemToInteractiveFormFieldType.Add(
                addButtonToolStripMenuItem, InteractiveFormFieldType.PushButton);

            _toolStripMenuItemToInteractiveFormFieldType.Add(
                addListBoxToolStripMenuItem, InteractiveFormFieldType.ListBox);

            _toolStripMenuItemToInteractiveFormFieldType.Add(
                addComboBoxToolStripMenuItem, InteractiveFormFieldType.ComboBox);

            _toolStripMenuItemToInteractiveFormFieldType.Add(
                addRadioButtonToolStripMenuItem, InteractiveFormFieldType.RadioButton);

            _toolStripMenuItemToInteractiveFormFieldType.Add(
                addBarcodeToolStripMenuItem, InteractiveFormFieldType.BarcodeField);

            _toolStripMenuItemToInteractiveFormFieldType.Add(
                addDigitalSignatureToolStripMenuItem, InteractiveFormFieldType.SignatureField);
        }

        /// <summary>
        /// Returns the field list for paste operation.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="targetField">The target field.</param>
        /// <returns>The field list for paste operation.</returns>
        private PdfInteractiveFormFieldList GetFieldList(
            PdfInteractiveFormField field,
            PdfInteractiveFormField targetField)
        {
            if (field == null)
                return targetField.Document.InteractiveForm.Fields;
            if (field.Kids != null)
            {
                if (field is PdfInteractiveFormCheckBoxGroupField &&
                    targetField is PdfInteractiveFormCheckBoxField)
                    return field.Kids;
                if (field is PdfInteractiveFormRadioButtonGroupField &&
                    targetField is PdfInteractiveFormRadioButtonField)
                    return field.Kids;
                if (!(field is PdfInteractiveFormSwitchableButtonGroupField))
                    return field.Kids;
            }
            if (field.Parent == null)
                return targetField.Document.InteractiveForm.Fields;
            return GetFieldList(field.Parent, targetField);
        }

        /// <summary>
        /// Returns the focused non-terminal field.
        /// </summary>
        /// <returns>The focused non-terminal field.</returns>
        private PdfInteractiveFormField GetFocusedNonTerminalField()
        {
            PdfInteractiveFormField field = interactiveFormFieldTree.SelectedField;
            if (field != null && !field.IsTerminalField)
                return field;
            return null;
        }

        #endregion

        #endregion


    }
}
