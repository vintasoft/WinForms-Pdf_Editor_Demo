namespace DemosCommonCode.Pdf
{
    partial class PdfComboBoxPropertiesEditorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

         #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfComboBoxPropertiesEditorControl));
            this.editableCheckBox = new System.Windows.Forms.CheckBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.actionsTabControl = new System.Windows.Forms.TabControl();
            this.valueTabPage = new System.Windows.Forms.TabPage();
            this.spellCheckCheckBox = new System.Windows.Forms.CheckBox();
            this.pdfInteractiveFormChoiceFieldEditorControl = new DemosCommonCode.Pdf.PdfChoiceFieldEditorControl();
            this.calculateActionTabPage = new System.Windows.Forms.TabPage();
            this.calculatePdfActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.validateActionTabPage = new System.Windows.Forms.TabPage();
            this.validatePdfActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.formatActionTabPage = new System.Windows.Forms.TabPage();
            this.formatPdfActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.keystrokeActionTabPage = new System.Windows.Forms.TabPage();
            this.keystrokePdfActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel.SuspendLayout();
            this.actionsTabControl.SuspendLayout();
            this.valueTabPage.SuspendLayout();
            this.calculateActionTabPage.SuspendLayout();
            this.validateActionTabPage.SuspendLayout();
            this.formatActionTabPage.SuspendLayout();
            this.keystrokeActionTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editableCheckBox
            // 
            this.editableCheckBox.AutoSize = true;
            this.editableCheckBox.Location = new System.Drawing.Point(77, 3);
            this.editableCheckBox.Name = "editableCheckBox";
            this.editableCheckBox.Size = new System.Drawing.Size(64, 17);
            this.editableCheckBox.TabIndex = 9;
            resources.ApplyResources(this.editableCheckBox, "editableCheckBox");
            this.editableCheckBox.UseVisualStyleBackColor = true;
            this.editableCheckBox.CheckedChanged += new System.EventHandler(this.editableCheckBox_CheckedChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.actionsTabControl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Enabled = false;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(315, 316);
            this.mainPanel.TabIndex = 13;
            // 
            // actionsTabControl
            // 
            this.actionsTabControl.Controls.Add(this.valueTabPage);
            this.actionsTabControl.Controls.Add(this.calculateActionTabPage);
            this.actionsTabControl.Controls.Add(this.validateActionTabPage);
            this.actionsTabControl.Controls.Add(this.formatActionTabPage);
            this.actionsTabControl.Controls.Add(this.keystrokeActionTabPage);
            this.actionsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.actionsTabControl.Name = "actionsTabControl";
            this.actionsTabControl.SelectedIndex = 0;
            this.actionsTabControl.Size = new System.Drawing.Size(315, 316);
            this.actionsTabControl.TabIndex = 12;
            this.actionsTabControl.SelectedIndexChanged += new System.EventHandler(this.actionsTabControl_SelectedIndexChanged);
            // 
            // valueTabPage
            // 
            this.valueTabPage.Controls.Add(this.tableLayoutPanel1);
            this.valueTabPage.Controls.Add(this.pdfInteractiveFormChoiceFieldEditorControl);
            this.valueTabPage.Location = new System.Drawing.Point(4, 22);
            this.valueTabPage.Name = "valueTabPage";
            this.valueTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.valueTabPage.Size = new System.Drawing.Size(307, 290);
            this.valueTabPage.TabIndex = 0;
            resources.ApplyResources(this.valueTabPage, "valueTabPage");
            this.valueTabPage.UseVisualStyleBackColor = true;
            // 
            // spellCheckCheckBox
            // 
            this.spellCheckCheckBox.AutoSize = true;
            this.spellCheckCheckBox.Location = new System.Drawing.Point(147, 3);
            this.spellCheckCheckBox.Name = "spellCheckCheckBox";
            this.spellCheckCheckBox.Size = new System.Drawing.Size(83, 17);
            this.spellCheckCheckBox.TabIndex = 12;
            resources.ApplyResources(this.spellCheckCheckBox, "spellCheckCheckBox");
            this.spellCheckCheckBox.UseVisualStyleBackColor = true;
            this.spellCheckCheckBox.CheckedChanged += new System.EventHandler(this.spellCheckCheckBox_CheckedChanged);
            // 
            // pdfInteractiveFormChoiceFieldEditorControl
            // 
            this.pdfInteractiveFormChoiceFieldEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfInteractiveFormChoiceFieldEditorControl.Field = null;
            this.pdfInteractiveFormChoiceFieldEditorControl.Location = new System.Drawing.Point(0, 24);
            this.pdfInteractiveFormChoiceFieldEditorControl.MinimumSize = new System.Drawing.Size(182, 120);
            this.pdfInteractiveFormChoiceFieldEditorControl.Name = "pdfInteractiveFormChoiceFieldEditorControl";
            this.pdfInteractiveFormChoiceFieldEditorControl.Size = new System.Drawing.Size(307, 266);
            this.pdfInteractiveFormChoiceFieldEditorControl.TabIndex = 11;
            this.pdfInteractiveFormChoiceFieldEditorControl.PropertyValueChanged += new System.EventHandler(this.pdfInteractiveFormChoiceFieldEditorControl_PropertyValueChanged);
            // 
            // calculateActionTabPage
            // 
            this.calculateActionTabPage.Controls.Add(this.calculatePdfActionEditorControl);
            this.calculateActionTabPage.Location = new System.Drawing.Point(4, 22);
            this.calculateActionTabPage.Name = "calculateActionTabPage";
            this.calculateActionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.calculateActionTabPage.Size = new System.Drawing.Size(307, 290);
            this.calculateActionTabPage.TabIndex = 1;
            resources.ApplyResources(this.calculateActionTabPage, "calculateActionTabPage");
            this.calculateActionTabPage.UseVisualStyleBackColor = true;
            // 
            // calculatePdfActionEditorControl
            // 
            this.calculatePdfActionEditorControl.Action = null;
            this.calculatePdfActionEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calculatePdfActionEditorControl.AutoSize = true;
            this.calculatePdfActionEditorControl.Document = null;
            this.calculatePdfActionEditorControl.ImageCollection = null;
            this.calculatePdfActionEditorControl.Location = new System.Drawing.Point(3, 3);
            this.calculatePdfActionEditorControl.MinimumSize = new System.Drawing.Size(165, 138);
            this.calculatePdfActionEditorControl.Name = "calculatePdfActionEditorControl";
            this.calculatePdfActionEditorControl.Size = new System.Drawing.Size(301, 284);
            this.calculatePdfActionEditorControl.TabIndex = 1;
            this.calculatePdfActionEditorControl.ActionChanged += new System.EventHandler(this.calculatePdfActionEditorControl_ActionChanged);
            // 
            // validateActionTabPage
            // 
            this.validateActionTabPage.Controls.Add(this.validatePdfActionEditorControl);
            this.validateActionTabPage.Location = new System.Drawing.Point(4, 22);
            this.validateActionTabPage.Name = "validateActionTabPage";
            this.validateActionTabPage.Size = new System.Drawing.Size(307, 290);
            this.validateActionTabPage.TabIndex = 2;
            resources.ApplyResources(this.validateActionTabPage, "validateActionTabPage");
            this.validateActionTabPage.UseVisualStyleBackColor = true;
            // 
            // validatePdfActionEditorControl
            // 
            this.validatePdfActionEditorControl.Action = null;
            this.validatePdfActionEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.validatePdfActionEditorControl.AutoSize = true;
            this.validatePdfActionEditorControl.Document = null;
            this.validatePdfActionEditorControl.ImageCollection = null;
            this.validatePdfActionEditorControl.Location = new System.Drawing.Point(3, 3);
            this.validatePdfActionEditorControl.MinimumSize = new System.Drawing.Size(165, 138);
            this.validatePdfActionEditorControl.Name = "validatePdfActionEditorControl";
            this.validatePdfActionEditorControl.Size = new System.Drawing.Size(301, 284);
            this.validatePdfActionEditorControl.TabIndex = 1;
            this.validatePdfActionEditorControl.ActionChanged += new System.EventHandler(this.validatePdfActionEditorControl_ActionChanged);
            // 
            // formatActionTabPage
            // 
            this.formatActionTabPage.Controls.Add(this.formatPdfActionEditorControl);
            this.formatActionTabPage.Location = new System.Drawing.Point(4, 22);
            this.formatActionTabPage.Name = "formatActionTabPage";
            this.formatActionTabPage.Size = new System.Drawing.Size(307, 290);
            this.formatActionTabPage.TabIndex = 3;
            resources.ApplyResources(this.formatActionTabPage, "formatActionTabPage");
            this.formatActionTabPage.UseVisualStyleBackColor = true;
            // 
            // formatPdfActionEditorControl
            // 
            this.formatPdfActionEditorControl.Action = null;
            this.formatPdfActionEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formatPdfActionEditorControl.AutoSize = true;
            this.formatPdfActionEditorControl.Document = null;
            this.formatPdfActionEditorControl.ImageCollection = null;
            this.formatPdfActionEditorControl.Location = new System.Drawing.Point(3, 3);
            this.formatPdfActionEditorControl.MinimumSize = new System.Drawing.Size(165, 138);
            this.formatPdfActionEditorControl.Name = "formatPdfActionEditorControl";
            this.formatPdfActionEditorControl.Size = new System.Drawing.Size(301, 284);
            this.formatPdfActionEditorControl.TabIndex = 2;
            this.formatPdfActionEditorControl.ActionChanged += new System.EventHandler(this.formatPdfActionEditorControl_ActionChanged);
            // 
            // keystrokeActionTabPage
            // 
            this.keystrokeActionTabPage.Controls.Add(this.keystrokePdfActionEditorControl);
            this.keystrokeActionTabPage.Location = new System.Drawing.Point(4, 22);
            this.keystrokeActionTabPage.Name = "keystrokeActionTabPage";
            this.keystrokeActionTabPage.Size = new System.Drawing.Size(307, 290);
            this.keystrokeActionTabPage.TabIndex = 4;
            resources.ApplyResources(this.keystrokeActionTabPage, "keystrokeActionTabPage");
            this.keystrokeActionTabPage.UseVisualStyleBackColor = true;
            // 
            // keystrokePdfActionEditorControl
            // 
            this.keystrokePdfActionEditorControl.Action = null;
            this.keystrokePdfActionEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keystrokePdfActionEditorControl.AutoSize = true;
            this.keystrokePdfActionEditorControl.Document = null;
            this.keystrokePdfActionEditorControl.ImageCollection = null;
            this.keystrokePdfActionEditorControl.Location = new System.Drawing.Point(3, 3);
            this.keystrokePdfActionEditorControl.MinimumSize = new System.Drawing.Size(165, 138);
            this.keystrokePdfActionEditorControl.Name = "keystrokePdfActionEditorControl";
            this.keystrokePdfActionEditorControl.Size = new System.Drawing.Size(301, 284);
            this.keystrokePdfActionEditorControl.TabIndex = 3;
            this.keystrokePdfActionEditorControl.ActionChanged += new System.EventHandler(this.keystrokePdfActionEditorControl_ActionChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.editableCheckBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.spellCheckCheckBox, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 24);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // PdfComboBoxPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(202, 259);
            this.Name = "PdfComboBoxPropertiesEditorControl";
            this.Size = new System.Drawing.Size(315, 316);
            this.mainPanel.ResumeLayout(false);
            this.actionsTabControl.ResumeLayout(false);
            this.valueTabPage.ResumeLayout(false);
            this.calculateActionTabPage.ResumeLayout(false);
            this.calculateActionTabPage.PerformLayout();
            this.validateActionTabPage.ResumeLayout(false);
            this.validateActionTabPage.PerformLayout();
            this.formatActionTabPage.ResumeLayout(false);
            this.formatActionTabPage.PerformLayout();
            this.keystrokeActionTabPage.ResumeLayout(false);
            this.keystrokeActionTabPage.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox editableCheckBox;
        private System.Windows.Forms.Panel mainPanel;
        private PdfChoiceFieldEditorControl pdfInteractiveFormChoiceFieldEditorControl;
        private System.Windows.Forms.TabControl actionsTabControl;
        private System.Windows.Forms.TabPage valueTabPage;
        private System.Windows.Forms.TabPage calculateActionTabPage;
        private System.Windows.Forms.TabPage validateActionTabPage;
        private System.Windows.Forms.TabPage formatActionTabPage;
        private System.Windows.Forms.TabPage keystrokeActionTabPage;
        private PdfActionEditorControl calculatePdfActionEditorControl;
        private PdfActionEditorControl validatePdfActionEditorControl;
        private PdfActionEditorControl formatPdfActionEditorControl;
        private PdfActionEditorControl keystrokePdfActionEditorControl;
        private System.Windows.Forms.CheckBox spellCheckCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}