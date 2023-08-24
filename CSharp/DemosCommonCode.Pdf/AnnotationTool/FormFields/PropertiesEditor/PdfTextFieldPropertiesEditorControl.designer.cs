namespace DemosCommonCode.Pdf
{
    partial class PdfTextFieldPropertiesEditorControl
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.actionsTabControl = new System.Windows.Forms.TabControl();
            this.valueTabPage = new System.Windows.Forms.TabPage();
            this.spellCheckCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordCheckBox = new System.Windows.Forms.CheckBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.defaultValueTextBox = new System.Windows.Forms.TextBox();
            this.textQuaddingComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.multilineCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.calculateActionTabPage = new System.Windows.Forms.TabPage();
            this.calculatePdfActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.validateActionTabPage = new System.Windows.Forms.TabPage();
            this.validatePdfActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.formatActionTabPage = new System.Windows.Forms.TabPage();
            this.formatPdfActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.keystrokeActionTabPage = new System.Windows.Forms.TabPage();
            this.keystrokePdfActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.mainPanel.SuspendLayout();
            this.actionsTabControl.SuspendLayout();
            this.valueTabPage.SuspendLayout();
            this.calculateActionTabPage.SuspendLayout();
            this.validateActionTabPage.SuspendLayout();
            this.formatActionTabPage.SuspendLayout();
            this.keystrokeActionTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.actionsTabControl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(311, 229);
            this.mainPanel.TabIndex = 0;
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
            this.actionsTabControl.Size = new System.Drawing.Size(311, 229);
            this.actionsTabControl.TabIndex = 18;
            this.actionsTabControl.SelectedIndexChanged += new System.EventHandler(this.actionsTabControl_SelectedIndexChanged);
            // 
            // valueTabPage
            // 
            this.valueTabPage.Controls.Add(this.spellCheckCheckBox);
            this.valueTabPage.Controls.Add(this.passwordCheckBox);
            this.valueTabPage.Controls.Add(this.valueTextBox);
            this.valueTabPage.Controls.Add(this.label3);
            this.valueTabPage.Controls.Add(this.defaultValueTextBox);
            this.valueTabPage.Controls.Add(this.textQuaddingComboBox);
            this.valueTabPage.Controls.Add(this.label1);
            this.valueTabPage.Controls.Add(this.multilineCheckBox);
            this.valueTabPage.Controls.Add(this.label2);
            this.valueTabPage.Location = new System.Drawing.Point(4, 22);
            this.valueTabPage.Name = "valueTabPage";
            this.valueTabPage.Size = new System.Drawing.Size(303, 203);
            this.valueTabPage.TabIndex = 2;
            this.valueTabPage.Text = "Value";
            this.valueTabPage.UseVisualStyleBackColor = true;
            // 
            // spellCheckCheckBox
            // 
            this.spellCheckCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spellCheckCheckBox.AutoSize = true;
            this.spellCheckCheckBox.Location = new System.Drawing.Point(224, 151);
            this.spellCheckCheckBox.Name = "spellCheckCheckBox";
            this.spellCheckCheckBox.Size = new System.Drawing.Size(83, 17);
            this.spellCheckCheckBox.TabIndex = 19;
            this.spellCheckCheckBox.Text = "Spell Check";
            this.spellCheckCheckBox.UseVisualStyleBackColor = true;
            this.spellCheckCheckBox.CheckedChanged += new System.EventHandler(this.spellCheckCheckBox_CheckedChanged);
            // 
            // passwordCheckBox
            // 
            this.passwordCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.passwordCheckBox.AutoSize = true;
            this.passwordCheckBox.Location = new System.Drawing.Point(151, 151);
            this.passwordCheckBox.Name = "passwordCheckBox";
            this.passwordCheckBox.Size = new System.Drawing.Size(72, 17);
            this.passwordCheckBox.TabIndex = 18;
            this.passwordCheckBox.Text = "Password";
            this.passwordCheckBox.UseVisualStyleBackColor = true;
            this.passwordCheckBox.CheckedChanged += new System.EventHandler(this.passwordCheckBox_CheckedChanged);
            // 
            // valueTextBox
            // 
            this.valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTextBox.Location = new System.Drawing.Point(86, 3);
            this.valueTextBox.Multiline = true;
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.valueTextBox.ShortcutsEnabled = false;
            this.valueTextBox.Size = new System.Drawing.Size(214, 86);
            this.valueTextBox.TabIndex = 11;
            this.valueTextBox.WordWrap = false;
            this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
            this.valueTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Text Quadding";
            // 
            // defaultValueTextBox
            // 
            this.defaultValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultValueTextBox.Location = new System.Drawing.Point(86, 95);
            this.defaultValueTextBox.Multiline = true;
            this.defaultValueTextBox.Name = "defaultValueTextBox";
            this.defaultValueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.defaultValueTextBox.ShortcutsEnabled = false;
            this.defaultValueTextBox.Size = new System.Drawing.Size(214, 50);
            this.defaultValueTextBox.TabIndex = 12;
            this.defaultValueTextBox.WordWrap = false;
            this.defaultValueTextBox.TextChanged += new System.EventHandler(this.defaultValueTextBox_TextChanged);
            this.defaultValueTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // textQuaddingComboBox
            // 
            this.textQuaddingComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textQuaddingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textQuaddingComboBox.FormattingEnabled = true;
            this.textQuaddingComboBox.Location = new System.Drawing.Point(86, 174);
            this.textQuaddingComboBox.Name = "textQuaddingComboBox";
            this.textQuaddingComboBox.Size = new System.Drawing.Size(214, 21);
            this.textQuaddingComboBox.TabIndex = 16;
            this.textQuaddingComboBox.SelectedIndexChanged += new System.EventHandler(this.textQuaddingComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Value";
            // 
            // multilineCheckBox
            // 
            this.multilineCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.multilineCheckBox.AutoSize = true;
            this.multilineCheckBox.Location = new System.Drawing.Point(86, 151);
            this.multilineCheckBox.Name = "multilineCheckBox";
            this.multilineCheckBox.Size = new System.Drawing.Size(64, 17);
            this.multilineCheckBox.TabIndex = 15;
            this.multilineCheckBox.Text = "Multiline";
            this.multilineCheckBox.UseVisualStyleBackColor = true;
            this.multilineCheckBox.CheckedChanged += new System.EventHandler(this.multilineCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Default Value";
            // 
            // calculateActionTabPage
            // 
            this.calculateActionTabPage.Controls.Add(this.calculatePdfActionEditorControl);
            this.calculateActionTabPage.Location = new System.Drawing.Point(4, 22);
            this.calculateActionTabPage.Name = "calculateActionTabPage";
            this.calculateActionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.calculateActionTabPage.Size = new System.Drawing.Size(303, 203);
            this.calculateActionTabPage.TabIndex = 0;
            this.calculateActionTabPage.Text = "Calculate Action";
            this.calculateActionTabPage.UseVisualStyleBackColor = true;
            // 
            // calculatePdfActionEditorControl
            // 
            this.calculatePdfActionEditorControl.Action = null;
            this.calculatePdfActionEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calculatePdfActionEditorControl.Document = null;
            this.calculatePdfActionEditorControl.ImageCollection = null;
            this.calculatePdfActionEditorControl.Location = new System.Drawing.Point(3, 3);
            this.calculatePdfActionEditorControl.MinimumSize = new System.Drawing.Size(165, 138);
            this.calculatePdfActionEditorControl.Name = "calculatePdfActionEditorControl";
            this.calculatePdfActionEditorControl.Size = new System.Drawing.Size(297, 197);
            this.calculatePdfActionEditorControl.TabIndex = 0;
            this.calculatePdfActionEditorControl.ActionChanged += new System.EventHandler(this.calculatePdfActionEditorControl_ActionChanged);
            // 
            // validateActionTabPage
            // 
            this.validateActionTabPage.Controls.Add(this.validatePdfActionEditorControl);
            this.validateActionTabPage.Location = new System.Drawing.Point(4, 22);
            this.validateActionTabPage.Name = "validateActionTabPage";
            this.validateActionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.validateActionTabPage.Size = new System.Drawing.Size(303, 203);
            this.validateActionTabPage.TabIndex = 1;
            this.validateActionTabPage.Text = "Validate Action";
            this.validateActionTabPage.UseVisualStyleBackColor = true;
            // 
            // validatePdfActionEditorControl
            // 
            this.validatePdfActionEditorControl.Action = null;
            this.validatePdfActionEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.validatePdfActionEditorControl.Document = null;
            this.validatePdfActionEditorControl.ImageCollection = null;
            this.validatePdfActionEditorControl.Location = new System.Drawing.Point(3, 3);
            this.validatePdfActionEditorControl.MinimumSize = new System.Drawing.Size(165, 138);
            this.validatePdfActionEditorControl.Name = "validatePdfActionEditorControl";
            this.validatePdfActionEditorControl.Size = new System.Drawing.Size(297, 197);
            this.validatePdfActionEditorControl.TabIndex = 0;
            this.validatePdfActionEditorControl.ActionChanged += new System.EventHandler(this.validatePdfActionEditorControl_ActionChanged);
            // 
            // formatActionTabPage
            // 
            this.formatActionTabPage.Controls.Add(this.formatPdfActionEditorControl);
            this.formatActionTabPage.Location = new System.Drawing.Point(4, 22);
            this.formatActionTabPage.Name = "formatActionTabPage";
            this.formatActionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.formatActionTabPage.Size = new System.Drawing.Size(303, 203);
            this.formatActionTabPage.TabIndex = 3;
            this.formatActionTabPage.Text = "Format Action";
            this.formatActionTabPage.UseVisualStyleBackColor = true;
            // 
            // formatPdfActionEditorControl
            // 
            this.formatPdfActionEditorControl.Action = null;
            this.formatPdfActionEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formatPdfActionEditorControl.Document = null;
            this.formatPdfActionEditorControl.ImageCollection = null;
            this.formatPdfActionEditorControl.Location = new System.Drawing.Point(3, 3);
            this.formatPdfActionEditorControl.MinimumSize = new System.Drawing.Size(165, 138);
            this.formatPdfActionEditorControl.Name = "formatPdfActionEditorControl";
            this.formatPdfActionEditorControl.Size = new System.Drawing.Size(297, 197);
            this.formatPdfActionEditorControl.TabIndex = 1;
            this.formatPdfActionEditorControl.ActionChanged += new System.EventHandler(this.formatPdfActionEditorControl_ActionChanged);
            // 
            // keystrokeActionTabPage
            // 
            this.keystrokeActionTabPage.Controls.Add(this.keystrokePdfActionEditorControl);
            this.keystrokeActionTabPage.Location = new System.Drawing.Point(4, 22);
            this.keystrokeActionTabPage.Name = "keystrokeActionTabPage";
            this.keystrokeActionTabPage.Size = new System.Drawing.Size(303, 203);
            this.keystrokeActionTabPage.TabIndex = 4;
            this.keystrokeActionTabPage.Text = "Keystroke Action";
            this.keystrokeActionTabPage.UseVisualStyleBackColor = true;
            // 
            // keystrokePdfActionEditorControl
            // 
            this.keystrokePdfActionEditorControl.Action = null;
            this.keystrokePdfActionEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.keystrokePdfActionEditorControl.Document = null;
            this.keystrokePdfActionEditorControl.ImageCollection = null;
            this.keystrokePdfActionEditorControl.Location = new System.Drawing.Point(3, 3);
            this.keystrokePdfActionEditorControl.MinimumSize = new System.Drawing.Size(165, 138);
            this.keystrokePdfActionEditorControl.Name = "keystrokePdfActionEditorControl";
            this.keystrokePdfActionEditorControl.Size = new System.Drawing.Size(297, 197);
            this.keystrokePdfActionEditorControl.TabIndex = 2;
            this.keystrokePdfActionEditorControl.ActionChanged += new System.EventHandler(this.keystrokePdfActionEditorControl_ActionChanged);
            // 
            // PdfTextFieldPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(238, 170);
            this.Name = "PdfTextFieldPropertiesEditorControl";
            this.Size = new System.Drawing.Size(311, 229);
            this.mainPanel.ResumeLayout(false);
            this.actionsTabControl.ResumeLayout(false);
            this.valueTabPage.ResumeLayout(false);
            this.valueTabPage.PerformLayout();
            this.calculateActionTabPage.ResumeLayout(false);
            this.validateActionTabPage.ResumeLayout(false);
            this.formatActionTabPage.ResumeLayout(false);
            this.keystrokeActionTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox textQuaddingComboBox;
        private System.Windows.Forms.CheckBox multilineCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox defaultValueTextBox;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.TabControl actionsTabControl;
        private System.Windows.Forms.TabPage calculateActionTabPage;
        private PdfActionEditorControl calculatePdfActionEditorControl;
        private System.Windows.Forms.TabPage validateActionTabPage;
        private PdfActionEditorControl validatePdfActionEditorControl;
        private System.Windows.Forms.TabPage valueTabPage;
        private System.Windows.Forms.CheckBox passwordCheckBox;
        private System.Windows.Forms.TabPage formatActionTabPage;
        private System.Windows.Forms.TabPage keystrokeActionTabPage;
        private PdfActionEditorControl formatPdfActionEditorControl;
        private PdfActionEditorControl keystrokePdfActionEditorControl;
        private System.Windows.Forms.CheckBox spellCheckCheckBox;

    }
}