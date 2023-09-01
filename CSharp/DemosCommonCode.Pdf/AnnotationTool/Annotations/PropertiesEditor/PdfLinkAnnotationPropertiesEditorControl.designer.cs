namespace DemosCommonCode.Pdf
{
    partial class PdfLinkAnnotationPropertiesEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfLinkAnnotationPropertiesEditorControl));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.highlightingModeComboBox = new System.Windows.Forms.ComboBox();
            this.actionGroupBox = new System.Windows.Forms.GroupBox();
            this.pdfActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.mainPanel.SuspendLayout();
            this.actionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.actionGroupBox);
            this.mainPanel.Controls.Add(this.highlightingModeComboBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(374, 231);
            this.mainPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            resources.ApplyResources(this.label1, "label1");
            // 
            // highlightingModeComboBox
            // 
            this.highlightingModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.highlightingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.highlightingModeComboBox.FormattingEnabled = true;
            this.highlightingModeComboBox.Location = new System.Drawing.Point(101, 3);
            this.highlightingModeComboBox.Name = "highlightingModeComboBox";
            this.highlightingModeComboBox.Size = new System.Drawing.Size(270, 21);
            this.highlightingModeComboBox.TabIndex = 1;
            this.highlightingModeComboBox.SelectedIndexChanged += new System.EventHandler(this.highlightingModeComboBox_SelectedIndexChanged);
            // 
            // actionGroupBox
            // 
            this.actionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.actionGroupBox.Controls.Add(this.pdfActionEditorControl);
            this.actionGroupBox.Location = new System.Drawing.Point(6, 30);
            this.actionGroupBox.Name = "actionGroupBox";
            this.actionGroupBox.Size = new System.Drawing.Size(365, 198);
            this.actionGroupBox.TabIndex = 3;
            this.actionGroupBox.TabStop = false;
            resources.ApplyResources(this.actionGroupBox, "actionGroupBox");
            // 
            // pdfActionEditorControl
            // 
            this.pdfActionEditorControl.Action = null;
            this.pdfActionEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfActionEditorControl.Document = null;
            this.pdfActionEditorControl.ImageCollection = null;
            this.pdfActionEditorControl.Location = new System.Drawing.Point(3, 16);
            this.pdfActionEditorControl.MinimumSize = new System.Drawing.Size(165, 138);
            this.pdfActionEditorControl.Name = "pdfActionEditorControl";
            this.pdfActionEditorControl.Size = new System.Drawing.Size(359, 179);
            this.pdfActionEditorControl.TabIndex = 0;
            this.pdfActionEditorControl.ActionChanged += new System.EventHandler(this.pdfActionEditorControl_ActionChanged);
            // 
            // PdfLinkAnnotationPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(213, 193);
            this.Name = "PdfLinkAnnotationPropertiesEditorControl";
            this.Size = new System.Drawing.Size(374, 231);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.actionGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ComboBox highlightingModeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox actionGroupBox;
        private PdfActionEditorControl pdfActionEditorControl;
    }
}