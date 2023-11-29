namespace DemosCommonCode.Pdf
{
    partial class PdfFileAttachmentAnnotationPropertiesEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfFileAttachmentAnnotationPropertiesEditorControl));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.embeddedFileSpecificationViewer = new DemosCommonCode.Pdf.EmbeddedFileSpecificationPropertiesEditor();
            this.iconComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(439, 184);
            this.mainPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.embeddedFileSpecificationViewer);
            this.groupBox1.Location = new System.Drawing.Point(3, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 151);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // embeddedFileSpecificationViewer
            // 
            this.embeddedFileSpecificationViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.embeddedFileSpecificationViewer.EmbeddedFileSpecification = null;
            this.embeddedFileSpecificationViewer.Location = new System.Drawing.Point(3, 16);
            this.embeddedFileSpecificationViewer.MinimumSize = new System.Drawing.Size(251, 107);
            this.embeddedFileSpecificationViewer.Name = "embeddedFileSpecificationViewer";
            this.embeddedFileSpecificationViewer.Size = new System.Drawing.Size(427, 132);
            this.embeddedFileSpecificationViewer.TabIndex = 2;
            // 
            // iconComboBox
            // 
            this.iconComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconComboBox.FormattingEnabled = true;
            this.iconComboBox.Location = new System.Drawing.Point(37, 3);
            this.iconComboBox.Name = "iconComboBox";
            this.iconComboBox.Size = new System.Drawing.Size(390, 21);
            this.iconComboBox.TabIndex = 1;
            this.iconComboBox.TextChanged += new System.EventHandler(this.iconComboBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            resources.ApplyResources(this.label1, "label1");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.iconComboBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(430, 27);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // PdfFileAttachmentAnnotationPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(267, 166);
            this.Name = "PdfFileAttachmentAnnotationPropertiesEditorControl";
            this.Size = new System.Drawing.Size(439, 184);
            this.mainPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ComboBox iconComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private EmbeddedFileSpecificationPropertiesEditor embeddedFileSpecificationViewer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}