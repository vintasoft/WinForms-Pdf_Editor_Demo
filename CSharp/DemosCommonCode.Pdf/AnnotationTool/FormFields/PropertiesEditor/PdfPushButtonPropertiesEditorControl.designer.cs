namespace DemosCommonCode.Pdf
{
    partial class PdfPushButtonPropertiesEditorControl
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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.valueTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStateTabControl = new System.Windows.Forms.TabControl();
            this.normalStateTabPage = new System.Windows.Forms.TabPage();
            this.normalIconChangeButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.normalCaptionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rolloverStateTabPage = new System.Windows.Forms.TabPage();
            this.rolloverIconChangeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rolloverCaptionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.downStateTabPage = new System.Windows.Forms.TabPage();
            this.downIconChangeButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.downCaptionTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.captionIconRelationComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.highlightingModeComboBox = new System.Windows.Forms.ComboBox();
            this.activateActionTabPage = new System.Windows.Forms.TabPage();
            this.normalIconPdfResourceViewerControl = new DemosCommonCode.Pdf.PdfResourceViewerControl();
            this.rolloverIconPdfResourceViewerControl = new DemosCommonCode.Pdf.PdfResourceViewerControl();
            this.downIconPdfResourceViewerControl = new DemosCommonCode.Pdf.PdfResourceViewerControl();
            this.pdfActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.mainTabControl.SuspendLayout();
            this.valueTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.buttonStateTabControl.SuspendLayout();
            this.normalStateTabPage.SuspendLayout();
            this.rolloverStateTabPage.SuspendLayout();
            this.downStateTabPage.SuspendLayout();
            this.activateActionTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.valueTabPage);
            this.mainTabControl.Controls.Add(this.activateActionTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(287, 322);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // valueTabPage
            // 
            this.valueTabPage.Controls.Add(this.groupBox1);
            this.valueTabPage.Controls.Add(this.captionIconRelationComboBox);
            this.valueTabPage.Controls.Add(this.label2);
            this.valueTabPage.Controls.Add(this.label1);
            this.valueTabPage.Controls.Add(this.highlightingModeComboBox);
            this.valueTabPage.Location = new System.Drawing.Point(4, 22);
            this.valueTabPage.Name = "valueTabPage";
            this.valueTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.valueTabPage.Size = new System.Drawing.Size(279, 296);
            this.valueTabPage.TabIndex = 0;
            this.valueTabPage.Text = "Value";
            this.valueTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonStateTabControl);
            this.groupBox1.Location = new System.Drawing.Point(6, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 230);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Button Appearance Characteristics";
            // 
            // buttonStateTabControl
            // 
            this.buttonStateTabControl.Controls.Add(this.normalStateTabPage);
            this.buttonStateTabControl.Controls.Add(this.rolloverStateTabPage);
            this.buttonStateTabControl.Controls.Add(this.downStateTabPage);
            this.buttonStateTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStateTabControl.Location = new System.Drawing.Point(3, 16);
            this.buttonStateTabControl.Name = "buttonStateTabControl";
            this.buttonStateTabControl.SelectedIndex = 0;
            this.buttonStateTabControl.Size = new System.Drawing.Size(261, 211);
            this.buttonStateTabControl.TabIndex = 4;
            this.buttonStateTabControl.SelectedIndexChanged += new System.EventHandler(this.buttonStateTabControl_SelectedIndexChanged);
            // 
            // normalStateTabPage
            // 
            this.normalStateTabPage.Controls.Add(this.normalIconPdfResourceViewerControl);
            this.normalStateTabPage.Controls.Add(this.normalIconChangeButton);
            this.normalStateTabPage.Controls.Add(this.label4);
            this.normalStateTabPage.Controls.Add(this.normalCaptionTextBox);
            this.normalStateTabPage.Controls.Add(this.label3);
            this.normalStateTabPage.Location = new System.Drawing.Point(4, 22);
            this.normalStateTabPage.Name = "normalStateTabPage";
            this.normalStateTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.normalStateTabPage.Size = new System.Drawing.Size(253, 185);
            this.normalStateTabPage.TabIndex = 0;
            this.normalStateTabPage.Text = "Normal";
            this.normalStateTabPage.UseVisualStyleBackColor = true;
            // 
            // normalIconChangeButton
            // 
            this.normalIconChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.normalIconChangeButton.Location = new System.Drawing.Point(175, 156);
            this.normalIconChangeButton.Name = "normalIconChangeButton";
            this.normalIconChangeButton.Size = new System.Drawing.Size(72, 23);
            this.normalIconChangeButton.TabIndex = 3;
            this.normalIconChangeButton.Text = "Change...";
            this.normalIconChangeButton.UseVisualStyleBackColor = true;
            this.normalIconChangeButton.Click += new System.EventHandler(this.normalIconChangeButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Icon";
            // 
            // normalCaptionTextBox
            // 
            this.normalCaptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.normalCaptionTextBox.Location = new System.Drawing.Point(55, 6);
            this.normalCaptionTextBox.Name = "normalCaptionTextBox";
            this.normalCaptionTextBox.Size = new System.Drawing.Size(192, 20);
            this.normalCaptionTextBox.TabIndex = 1;
            this.normalCaptionTextBox.TextChanged += new System.EventHandler(this.normalCaptionTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Caption";
            // 
            // rolloverStateTabPage
            // 
            this.rolloverStateTabPage.Controls.Add(this.rolloverIconPdfResourceViewerControl);
            this.rolloverStateTabPage.Controls.Add(this.rolloverIconChangeButton);
            this.rolloverStateTabPage.Controls.Add(this.label5);
            this.rolloverStateTabPage.Controls.Add(this.rolloverCaptionTextBox);
            this.rolloverStateTabPage.Controls.Add(this.label6);
            this.rolloverStateTabPage.Location = new System.Drawing.Point(4, 22);
            this.rolloverStateTabPage.Name = "rolloverStateTabPage";
            this.rolloverStateTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.rolloverStateTabPage.Size = new System.Drawing.Size(253, 185);
            this.rolloverStateTabPage.TabIndex = 1;
            this.rolloverStateTabPage.Text = "Rollover";
            this.rolloverStateTabPage.UseVisualStyleBackColor = true;
            // 
            // rolloverIconChangeButton
            // 
            this.rolloverIconChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rolloverIconChangeButton.Location = new System.Drawing.Point(175, 156);
            this.rolloverIconChangeButton.Name = "rolloverIconChangeButton";
            this.rolloverIconChangeButton.Size = new System.Drawing.Size(72, 23);
            this.rolloverIconChangeButton.TabIndex = 8;
            this.rolloverIconChangeButton.Text = "Change...";
            this.rolloverIconChangeButton.UseVisualStyleBackColor = true;
            this.rolloverIconChangeButton.Click += new System.EventHandler(this.rolloverIconChangeButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Icon";
            // 
            // rolloverCaptionTextBox
            // 
            this.rolloverCaptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rolloverCaptionTextBox.Location = new System.Drawing.Point(55, 6);
            this.rolloverCaptionTextBox.Name = "rolloverCaptionTextBox";
            this.rolloverCaptionTextBox.Size = new System.Drawing.Size(192, 20);
            this.rolloverCaptionTextBox.TabIndex = 6;
            this.rolloverCaptionTextBox.TextChanged += new System.EventHandler(this.rolloverCaptionTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Caption";
            // 
            // downStateTabPage
            // 
            this.downStateTabPage.Controls.Add(this.downIconPdfResourceViewerControl);
            this.downStateTabPage.Controls.Add(this.downIconChangeButton);
            this.downStateTabPage.Controls.Add(this.label7);
            this.downStateTabPage.Controls.Add(this.downCaptionTextBox);
            this.downStateTabPage.Controls.Add(this.label8);
            this.downStateTabPage.Location = new System.Drawing.Point(4, 22);
            this.downStateTabPage.Name = "downStateTabPage";
            this.downStateTabPage.Size = new System.Drawing.Size(253, 185);
            this.downStateTabPage.TabIndex = 2;
            this.downStateTabPage.Text = "Down";
            this.downStateTabPage.UseVisualStyleBackColor = true;
            // 
            // downIconChangeButton
            // 
            this.downIconChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downIconChangeButton.Location = new System.Drawing.Point(175, 156);
            this.downIconChangeButton.Name = "downIconChangeButton";
            this.downIconChangeButton.Size = new System.Drawing.Size(72, 23);
            this.downIconChangeButton.TabIndex = 8;
            this.downIconChangeButton.Text = "Change...";
            this.downIconChangeButton.UseVisualStyleBackColor = true;
            this.downIconChangeButton.Click += new System.EventHandler(this.downIconChangeButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Icon";
            // 
            // downCaptionTextBox
            // 
            this.downCaptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.downCaptionTextBox.Location = new System.Drawing.Point(55, 6);
            this.downCaptionTextBox.Name = "downCaptionTextBox";
            this.downCaptionTextBox.Size = new System.Drawing.Size(192, 20);
            this.downCaptionTextBox.TabIndex = 6;
            this.downCaptionTextBox.TextChanged += new System.EventHandler(this.downCaptionTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Caption";
            // 
            // captionIconRelationComboBox
            // 
            this.captionIconRelationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.captionIconRelationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.captionIconRelationComboBox.FormattingEnabled = true;
            this.captionIconRelationComboBox.Location = new System.Drawing.Point(118, 33);
            this.captionIconRelationComboBox.Name = "captionIconRelationComboBox";
            this.captionIconRelationComboBox.Size = new System.Drawing.Size(142, 21);
            this.captionIconRelationComboBox.TabIndex = 9;
            this.captionIconRelationComboBox.SelectedIndexChanged += new System.EventHandler(this.captionIconRelationComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Caption Icon Relation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Highlighting Mode";
            // 
            // highlightingModeComboBox
            // 
            this.highlightingModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.highlightingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.highlightingModeComboBox.FormattingEnabled = true;
            this.highlightingModeComboBox.Location = new System.Drawing.Point(118, 6);
            this.highlightingModeComboBox.Name = "highlightingModeComboBox";
            this.highlightingModeComboBox.Size = new System.Drawing.Size(142, 21);
            this.highlightingModeComboBox.TabIndex = 6;
            this.highlightingModeComboBox.SelectedIndexChanged += new System.EventHandler(this.highlightingModeComboBox_SelectedIndexChanged);
            // 
            // activateActionTabPage
            // 
            this.activateActionTabPage.Controls.Add(this.pdfActionEditorControl);
            this.activateActionTabPage.Location = new System.Drawing.Point(4, 22);
            this.activateActionTabPage.Name = "activateActionTabPage";
            this.activateActionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.activateActionTabPage.Size = new System.Drawing.Size(279, 296);
            this.activateActionTabPage.TabIndex = 1;
            this.activateActionTabPage.Text = "Activate Action";
            this.activateActionTabPage.UseVisualStyleBackColor = true;
            // 
            // normalIconPdfResourceViewerControl
            // 
            this.normalIconPdfResourceViewerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.normalIconPdfResourceViewerControl.BackColor = System.Drawing.Color.White;
            this.normalIconPdfResourceViewerControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.normalIconPdfResourceViewerControl.ImageViewerAvailableZoomValues = new int[] {
        25,
        50,
        100,
        200,
        400};
            this.normalIconPdfResourceViewerControl.ImageViewerBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.normalIconPdfResourceViewerControl.ImageViewerSizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.normalIconPdfResourceViewerControl.Location = new System.Drawing.Point(55, 37);
            this.normalIconPdfResourceViewerControl.MinimumSize = new System.Drawing.Size(120, 56);
            this.normalIconPdfResourceViewerControl.Name = "normalIconPdfResourceViewerControl";
            this.normalIconPdfResourceViewerControl.Resource = null;
            this.normalIconPdfResourceViewerControl.ShowSizeModeComboBox = false;
            this.normalIconPdfResourceViewerControl.Size = new System.Drawing.Size(192, 113);
            this.normalIconPdfResourceViewerControl.TabIndex = 4;
            // 
            // rolloverIconPdfResourceViewerControl
            // 
            this.rolloverIconPdfResourceViewerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rolloverIconPdfResourceViewerControl.BackColor = System.Drawing.Color.White;
            this.rolloverIconPdfResourceViewerControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rolloverIconPdfResourceViewerControl.ImageViewerAvailableZoomValues = new int[] {
        25,
        50,
        100,
        200,
        400};
            this.rolloverIconPdfResourceViewerControl.ImageViewerBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rolloverIconPdfResourceViewerControl.ImageViewerSizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.rolloverIconPdfResourceViewerControl.Location = new System.Drawing.Point(55, 37);
            this.rolloverIconPdfResourceViewerControl.MinimumSize = new System.Drawing.Size(120, 56);
            this.rolloverIconPdfResourceViewerControl.Name = "rolloverIconPdfResourceViewerControl";
            this.rolloverIconPdfResourceViewerControl.Resource = null;
            this.rolloverIconPdfResourceViewerControl.ShowSizeModeComboBox = false;
            this.rolloverIconPdfResourceViewerControl.Size = new System.Drawing.Size(192, 113);
            this.rolloverIconPdfResourceViewerControl.TabIndex = 9;
            // 
            // downIconPdfResourceViewerControl
            // 
            this.downIconPdfResourceViewerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.downIconPdfResourceViewerControl.BackColor = System.Drawing.Color.White;
            this.downIconPdfResourceViewerControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.downIconPdfResourceViewerControl.ImageViewerAvailableZoomValues = new int[] {
        25,
        50,
        100,
        200,
        400};
            this.downIconPdfResourceViewerControl.ImageViewerBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.downIconPdfResourceViewerControl.ImageViewerSizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.downIconPdfResourceViewerControl.Location = new System.Drawing.Point(55, 37);
            this.downIconPdfResourceViewerControl.MinimumSize = new System.Drawing.Size(120, 56);
            this.downIconPdfResourceViewerControl.Name = "downIconPdfResourceViewerControl";
            this.downIconPdfResourceViewerControl.Resource = null;
            this.downIconPdfResourceViewerControl.ShowSizeModeComboBox = false;
            this.downIconPdfResourceViewerControl.Size = new System.Drawing.Size(192, 113);
            this.downIconPdfResourceViewerControl.TabIndex = 9;
            // 
            // pdfActionEditorControl
            // 
            this.pdfActionEditorControl.Action = null;
            this.pdfActionEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfActionEditorControl.Document = null;
            this.pdfActionEditorControl.ImageCollection = null;
            this.pdfActionEditorControl.Location = new System.Drawing.Point(3, 3);
            this.pdfActionEditorControl.MinimumSize = new System.Drawing.Size(165, 138);
            this.pdfActionEditorControl.Name = "pdfActionEditorControl";
            this.pdfActionEditorControl.Size = new System.Drawing.Size(273, 290);
            this.pdfActionEditorControl.TabIndex = 0;
            this.pdfActionEditorControl.ActionChanged += new System.EventHandler(this.pdfActionEditorControl_ActionChanged);
            // 
            // PdfPushButtonPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTabControl);
            this.MinimumSize = new System.Drawing.Size(213, 240);
            this.Name = "PdfPushButtonPropertiesEditorControl";
            this.Size = new System.Drawing.Size(287, 322);
            this.mainTabControl.ResumeLayout(false);
            this.valueTabPage.ResumeLayout(false);
            this.valueTabPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.buttonStateTabControl.ResumeLayout(false);
            this.normalStateTabPage.ResumeLayout(false);
            this.normalStateTabPage.PerformLayout();
            this.rolloverStateTabPage.ResumeLayout(false);
            this.rolloverStateTabPage.PerformLayout();
            this.downStateTabPage.ResumeLayout(false);
            this.downStateTabPage.PerformLayout();
            this.activateActionTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage valueTabPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl buttonStateTabControl;
        private System.Windows.Forms.TabPage normalStateTabPage;
        private System.Windows.Forms.Button normalIconChangeButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox normalCaptionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage rolloverStateTabPage;
        private System.Windows.Forms.TabPage downStateTabPage;
        private System.Windows.Forms.ComboBox captionIconRelationComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox highlightingModeComboBox;
        private System.Windows.Forms.TabPage activateActionTabPage;
        private PdfActionEditorControl pdfActionEditorControl;
        private System.Windows.Forms.Button rolloverIconChangeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rolloverCaptionTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button downIconChangeButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox downCaptionTextBox;
        private System.Windows.Forms.Label label8;
        private PdfResourceViewerControl normalIconPdfResourceViewerControl;
        private PdfResourceViewerControl rolloverIconPdfResourceViewerControl;
        private PdfResourceViewerControl downIconPdfResourceViewerControl;
    }
}