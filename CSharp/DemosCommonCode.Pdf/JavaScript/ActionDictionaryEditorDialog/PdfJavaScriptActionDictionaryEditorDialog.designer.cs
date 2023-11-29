namespace DemosCommonCode.Pdf.JavaScript
{
    partial class PdfJavaScriptActionDictionaryEditorDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfJavaScriptActionDictionaryEditorDialog));
            this.javaScripActionsListBox = new System.Windows.Forms.ListBox();
            this.javaScriptTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton1 = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.wordWrapCheckBox = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // javaScripActionsListBox
            // 
            this.javaScripActionsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.javaScripActionsListBox.FormattingEnabled = true;
            this.javaScripActionsListBox.HorizontalScrollbar = true;
            this.javaScripActionsListBox.Location = new System.Drawing.Point(3, 4);
            this.javaScripActionsListBox.Name = "javaScripActionsListBox";
            this.javaScripActionsListBox.Size = new System.Drawing.Size(341, 433);
            this.javaScripActionsListBox.TabIndex = 0;
            this.javaScripActionsListBox.SelectedIndexChanged += new System.EventHandler(this.javaScripActionsListBox_SelectedIndexChanged);
            // 
            // javaScriptTextBox
            // 
            this.javaScriptTextBox.AcceptsReturn = true;
            this.javaScriptTextBox.AcceptsTab = true;
            this.javaScriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.javaScriptTextBox.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.javaScriptTextBox.Location = new System.Drawing.Point(0, 4);
            this.javaScriptTextBox.Multiline = true;
            this.javaScriptTextBox.Name = "javaScriptTextBox";
            this.javaScriptTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.javaScriptTextBox.Size = new System.Drawing.Size(350, 433);
            this.javaScriptTextBox.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.AutoSize = true;
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(108, 23);
            this.addButton.TabIndex = 2;
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.renameButton.AutoSize = true;
            this.renameButton.Location = new System.Drawing.Point(117, 3);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(111, 23);
            this.renameButton.TabIndex = 3;
            resources.ApplyResources(this.renameButton, "renameButton");
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.AutoSize = true;
            this.removeButton.Location = new System.Drawing.Point(234, 3);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(109, 23);
            this.removeButton.TabIndex = 4;
            resources.ApplyResources(this.removeButton, "removeButton");
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.javaScripActionsListBox);
            this.splitContainer1.Panel1MinSize = 240;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cancelButton1);
            this.splitContainer1.Panel2.Controls.Add(this.okButton);
            this.splitContainer1.Panel2.Controls.Add(this.wordWrapCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this.javaScriptTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(703, 479);
            this.splitContainer1.SplitterDistance = 346;
            this.splitContainer1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Controls.Add(this.addButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.removeButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.renameButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 450);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(346, 29);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // cancelButton1
            // 
            this.cancelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton1.Location = new System.Drawing.Point(266, 449);
            this.cancelButton1.Name = "cancelButton1";
            this.cancelButton1.Size = new System.Drawing.Size(75, 23);
            this.cancelButton1.TabIndex = 4;
            resources.ApplyResources(this.cancelButton1, "cancelButton1");
            this.cancelButton1.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(185, 449);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // wordWrapCheckBox
            // 
            this.wordWrapCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wordWrapCheckBox.AutoSize = true;
            this.wordWrapCheckBox.Location = new System.Drawing.Point(98, 453);
            this.wordWrapCheckBox.Name = "wordWrapCheckBox";
            this.wordWrapCheckBox.Size = new System.Drawing.Size(81, 17);
            this.wordWrapCheckBox.TabIndex = 2;
            resources.ApplyResources(this.wordWrapCheckBox, "wordWrapCheckBox");
            this.wordWrapCheckBox.UseVisualStyleBackColor = true;
            this.wordWrapCheckBox.CheckedChanged += new System.EventHandler(this.wordWrapCheckBox_CheckedChanged);
            // 
            // PdfJavaScriptActionDictionaryEditorDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 479);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(430, 138);
            this.Name = "PdfJavaScriptActionDictionaryEditorDialog";
            resources.ApplyResources(this, "$this");
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox javaScripActionsListBox;
        private System.Windows.Forms.TextBox javaScriptTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox wordWrapCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}