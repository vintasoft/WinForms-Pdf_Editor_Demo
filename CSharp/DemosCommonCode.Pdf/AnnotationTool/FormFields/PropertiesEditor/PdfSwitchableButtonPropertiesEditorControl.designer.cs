namespace DemosCommonCode.Pdf
{
    partial class PdfSwitchableButtonPropertiesEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfSwitchableButtonPropertiesEditorControl));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pdfAnnotationAppearancesEditorControl = new DemosCommonCode.Pdf.PdfAnnotationAppearancesEditorControl();
            this.currentAppearanceStateComboBox = new System.Windows.Forms.ComboBox();
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
            this.mainPanel.Size = new System.Drawing.Size(250, 210);
            this.mainPanel.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pdfAnnotationAppearancesEditorControl);
            this.groupBox1.Location = new System.Drawing.Point(0, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 174);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // pdfAnnotationAppearancesEditorControl
            // 
            this.pdfAnnotationAppearancesEditorControl.Annotation = null;
            this.pdfAnnotationAppearancesEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfAnnotationAppearancesEditorControl.Location = new System.Drawing.Point(3, 16);
            this.pdfAnnotationAppearancesEditorControl.MinimumSize = new System.Drawing.Size(191, 148);
            this.pdfAnnotationAppearancesEditorControl.Name = "pdfAnnotationAppearancesEditorControl";
            this.pdfAnnotationAppearancesEditorControl.Size = new System.Drawing.Size(244, 155);
            this.pdfAnnotationAppearancesEditorControl.TabIndex = 0;
            this.pdfAnnotationAppearancesEditorControl.AppearanceChanged += new System.EventHandler(this.pdfAnnotationAppearancesEditorControl_AppearanceChanged);
            // 
            // currentAppearanceStateComboBox
            // 
            this.currentAppearanceStateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.currentAppearanceStateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentAppearanceStateComboBox.FormattingEnabled = true;
            this.currentAppearanceStateComboBox.Location = new System.Drawing.Point(48, 3);
            this.currentAppearanceStateComboBox.Name = "currentAppearanceStateComboBox";
            this.currentAppearanceStateComboBox.Size = new System.Drawing.Size(193, 21);
            this.currentAppearanceStateComboBox.TabIndex = 2;
            this.currentAppearanceStateComboBox.SelectedIndexChanged += new System.EventHandler(this.currentAppearanceStateComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            resources.ApplyResources(this.label1, "label1");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.currentAppearanceStateComboBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 27);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // PdfSwitchableButtonPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(198, 154);
            this.Name = "PdfSwitchableButtonPropertiesEditorControl";
            this.Size = new System.Drawing.Size(250, 210);
            this.mainPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private PdfAnnotationAppearancesEditorControl pdfAnnotationAppearancesEditorControl;
        private System.Windows.Forms.ComboBox currentAppearanceStateComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}