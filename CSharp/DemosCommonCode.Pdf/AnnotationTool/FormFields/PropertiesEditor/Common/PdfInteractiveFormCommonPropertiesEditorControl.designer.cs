namespace DemosCommonCode.Pdf
{
    partial class PdfInteractiveFormCommonPropertiesEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfInteractiveFormCommonPropertiesEditorControl));
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.fontGroupBox = new System.Windows.Forms.GroupBox();
            this.autoFontSizeMaxValueComboBox = new System.Windows.Forms.ComboBox();
            this.autoFontSizeMinValueComboBox = new System.Windows.Forms.ComboBox();
            this.fontSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pdfFontPanelControl = new DemosCommonCode.CustomControls.PdfFontPanelControl();
            this.fontColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.borderGroupBox = new System.Windows.Forms.GroupBox();
            this.borderStyleControl = new DemosCommonCode.Pdf.PdfWidgetAnnotationBorderStyleControl();
            this.label7 = new System.Windows.Forms.Label();
            this.requiredCheckBox = new System.Windows.Forms.CheckBox();
            this.readOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.noExportCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.backgroundColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.fontGroupBox.SuspendLayout();
            this.borderGroupBox.SuspendLayout();
            this.backgroundPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            resources.ApplyResources(this.label1, "label1");
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(87, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(295, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // fontGroupBox
            // 
            this.fontGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontGroupBox.Controls.Add(this.autoFontSizeMaxValueComboBox);
            this.fontGroupBox.Controls.Add(this.autoFontSizeMinValueComboBox);
            this.fontGroupBox.Controls.Add(this.fontSizeComboBox);
            this.fontGroupBox.Controls.Add(this.label5);
            this.fontGroupBox.Controls.Add(this.label2);
            this.fontGroupBox.Controls.Add(this.pdfFontPanelControl);
            this.fontGroupBox.Controls.Add(this.fontColorPanelControl);
            this.fontGroupBox.Controls.Add(this.label4);
            this.fontGroupBox.Controls.Add(this.label3);
            this.fontGroupBox.Controls.Add(this.label8);
            this.fontGroupBox.Location = new System.Drawing.Point(6, 29);
            this.fontGroupBox.Name = "fontGroupBox";
            this.fontGroupBox.Size = new System.Drawing.Size(383, 77);
            this.fontGroupBox.TabIndex = 2;
            this.fontGroupBox.TabStop = false;
            resources.ApplyResources(this.fontGroupBox, "fontGroupBox");
            // 
            // autoFontSizeMaxValueComboBox
            // 
            this.autoFontSizeMaxValueComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoFontSizeMaxValueComboBox.FormattingEnabled = true;
            this.autoFontSizeMaxValueComboBox.Location = new System.Drawing.Point(289, 49);
            this.autoFontSizeMaxValueComboBox.Name = "autoFontSizeMaxValueComboBox";
            this.autoFontSizeMaxValueComboBox.Size = new System.Drawing.Size(87, 21);
            this.autoFontSizeMaxValueComboBox.TabIndex = 25;
            this.autoFontSizeMaxValueComboBox.SelectedIndexChanged += new System.EventHandler(this.autoFontSizeMaxValueComboBox_ValueUpdate);
            this.autoFontSizeMaxValueComboBox.TextUpdate += new System.EventHandler(this.autoFontSizeMaxValueComboBox_ValueUpdate);
            // 
            // autoFontSizeMinValueComboBox
            // 
            this.autoFontSizeMinValueComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoFontSizeMinValueComboBox.FormattingEnabled = true;
            this.autoFontSizeMinValueComboBox.Location = new System.Drawing.Point(164, 49);
            this.autoFontSizeMinValueComboBox.Name = "autoFontSizeMinValueComboBox";
            this.autoFontSizeMinValueComboBox.Size = new System.Drawing.Size(86, 21);
            this.autoFontSizeMinValueComboBox.TabIndex = 24;
            this.autoFontSizeMinValueComboBox.SelectedIndexChanged += new System.EventHandler(this.autoFontSizeMinValueComboBox_ValueUpdate);
            this.autoFontSizeMinValueComboBox.TextUpdate += new System.EventHandler(this.autoFontSizeMinValueComboBox_ValueUpdate);
            // 
            // fontSizeComboBox
            // 
            this.fontSizeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontSizeComboBox.FormattingEnabled = true;
            this.fontSizeComboBox.Location = new System.Drawing.Point(81, 49);
            this.fontSizeComboBox.Name = "fontSizeComboBox";
            this.fontSizeComboBox.Size = new System.Drawing.Size(47, 21);
            this.fontSizeComboBox.TabIndex = 23;
            this.fontSizeComboBox.Text = "Auto";
            this.fontSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.fontSizeComboBox_ValueUpdate);
            this.fontSizeComboBox.TextUpdate += new System.EventHandler(this.fontSizeComboBox_ValueUpdate);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Min";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Max";
            // 
            // pdfFontPanelControl
            // 
            this.pdfFontPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfFontPanelControl.Location = new System.Drawing.Point(81, 19);
            this.pdfFontPanelControl.Margin = new System.Windows.Forms.Padding(0);
            this.pdfFontPanelControl.MinimumSize = new System.Drawing.Size(91, 22);
            this.pdfFontPanelControl.Name = "pdfFontPanelControl";
            this.pdfFontPanelControl.PdfDocument = null;
            this.pdfFontPanelControl.PdfFont = null;
            this.pdfFontPanelControl.Size = new System.Drawing.Size(162, 22);
            this.pdfFontPanelControl.TabIndex = 18;
            this.pdfFontPanelControl.PdfFontChanged += new System.EventHandler(this.pdfFontPanelControl_PdfFontChanged);
            // 
            // fontColorPanelControl
            // 
            this.fontColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fontColorPanelControl.CanEditAlphaChannel = false;
            this.fontColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.fontColorPanelControl.ColorButtonMargin = 6;
            this.fontColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.fontColorPanelControl.Location = new System.Drawing.Point(286, 19);
            this.fontColorPanelControl.Name = "fontColorPanelControl";
            this.fontColorPanelControl.Size = new System.Drawing.Size(90, 23);
            this.fontColorPanelControl.TabIndex = 17;
            this.fontColorPanelControl.ColorChanged += new System.EventHandler(this.fontColorPanelControl_ColorChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 2;
            resources.ApplyResources(this.label4, "label4");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 1;
            resources.ApplyResources(this.label3, "label3");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 0;
            resources.ApplyResources(this.label8, "label8");
            // 
            // borderGroupBox
            // 
            this.borderGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderGroupBox.Controls.Add(this.borderStyleControl);
            this.borderGroupBox.Location = new System.Drawing.Point(6, 112);
            this.borderGroupBox.Name = "borderGroupBox";
            this.borderGroupBox.Size = new System.Drawing.Size(383, 77);
            this.borderGroupBox.TabIndex = 3;
            this.borderGroupBox.TabStop = false;
            resources.ApplyResources(this.borderGroupBox, "borderGroupBox");
            // 
            // borderStyleControl
            // 
            this.borderStyleControl.Annotation = null;
            this.borderStyleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderStyleControl.Location = new System.Drawing.Point(3, 16);
            this.borderStyleControl.Name = "borderStyleControl";
            this.borderStyleControl.Size = new System.Drawing.Size(377, 58);
            this.borderStyleControl.TabIndex = 0;
            this.borderStyleControl.PropertyValueChanged += new System.EventHandler(this.borderStyleControl_PropertyValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 10;
            resources.ApplyResources(this.label7, "label7");
            // 
            // requiredCheckBox
            // 
            this.requiredCheckBox.AutoSize = true;
            this.requiredCheckBox.Location = new System.Drawing.Point(87, 232);
            this.requiredCheckBox.Name = "requiredCheckBox";
            this.requiredCheckBox.Size = new System.Drawing.Size(69, 17);
            this.requiredCheckBox.TabIndex = 13;
            resources.ApplyResources(this.requiredCheckBox, "requiredCheckBox");
            this.requiredCheckBox.UseVisualStyleBackColor = true;
            this.requiredCheckBox.CheckedChanged += new System.EventHandler(this.requiredCheckBox_CheckedChanged);
            // 
            // readOnlyCheckBox
            // 
            this.readOnlyCheckBox.AutoSize = true;
            this.readOnlyCheckBox.Location = new System.Drawing.Point(162, 232);
            this.readOnlyCheckBox.Name = "readOnlyCheckBox";
            this.readOnlyCheckBox.Size = new System.Drawing.Size(73, 17);
            this.readOnlyCheckBox.TabIndex = 14;
            resources.ApplyResources(this.readOnlyCheckBox, "readOnlyCheckBox");
            this.readOnlyCheckBox.UseVisualStyleBackColor = true;
            this.readOnlyCheckBox.CheckedChanged += new System.EventHandler(this.readOnlyCheckBox_CheckedChanged);
            // 
            // noExportCheckBox
            // 
            this.noExportCheckBox.AutoSize = true;
            this.noExportCheckBox.Location = new System.Drawing.Point(234, 232);
            this.noExportCheckBox.Name = "noExportCheckBox";
            this.noExportCheckBox.Size = new System.Drawing.Size(70, 17);
            this.noExportCheckBox.TabIndex = 15;
            this.noExportCheckBox.Text = "NoExport";
            this.noExportCheckBox.UseVisualStyleBackColor = true;
            this.noExportCheckBox.CheckedChanged += new System.EventHandler(this.noExportCheckBox_CheckedChanged);
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroundPanel.Controls.Add(this.backgroundColorPanelControl);
            this.backgroundPanel.Controls.Add(this.label7);
            this.backgroundPanel.Location = new System.Drawing.Point(0, 195);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(392, 31);
            this.backgroundPanel.TabIndex = 16;
            // 
            // backgroundColorPanelControl
            // 
            this.backgroundColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroundColorPanelControl.CanEditAlphaChannel = false;
            this.backgroundColorPanelControl.CanSetDefaultColor = true;
            this.backgroundColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.backgroundColorPanelControl.ColorButtonMargin = 6;
            this.backgroundColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.backgroundColorPanelControl.Location = new System.Drawing.Point(87, 3);
            this.backgroundColorPanelControl.Name = "backgroundColorPanelControl";
            this.backgroundColorPanelControl.Size = new System.Drawing.Size(295, 23);
            this.backgroundColorPanelControl.TabIndex = 19;
            this.backgroundColorPanelControl.ColorChanged += new System.EventHandler(this.backgroundColorPanelControl_ColorChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.nameTextBox);
            this.mainPanel.Controls.Add(this.requiredCheckBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.backgroundPanel);
            this.mainPanel.Controls.Add(this.fontGroupBox);
            this.mainPanel.Controls.Add(this.noExportCheckBox);
            this.mainPanel.Controls.Add(this.borderGroupBox);
            this.mainPanel.Controls.Add(this.readOnlyCheckBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(392, 253);
            this.mainPanel.TabIndex = 17;
            // 
            // PdfInteractiveFormCommonPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(257, 241);
            this.Name = "PdfInteractiveFormCommonPropertiesEditorControl";
            this.Size = new System.Drawing.Size(392, 253);
            this.fontGroupBox.ResumeLayout(false);
            this.fontGroupBox.PerformLayout();
            this.borderGroupBox.ResumeLayout(false);
            this.backgroundPanel.ResumeLayout(false);
            this.backgroundPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.GroupBox fontGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox borderGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox requiredCheckBox;
        private System.Windows.Forms.CheckBox readOnlyCheckBox;
        private System.Windows.Forms.CheckBox noExportCheckBox;
        private System.Windows.Forms.Panel backgroundPanel;
        private DemosCommonCode.CustomControls.ColorPanelControl fontColorPanelControl;
        private DemosCommonCode.CustomControls.ColorPanelControl backgroundColorPanelControl;
        private System.Windows.Forms.Panel mainPanel;
        private PdfWidgetAnnotationBorderStyleControl borderStyleControl;
        private DemosCommonCode.CustomControls.PdfFontPanelControl pdfFontPanelControl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fontSizeComboBox;
        private System.Windows.Forms.ComboBox autoFontSizeMinValueComboBox;
        private System.Windows.Forms.ComboBox autoFontSizeMaxValueComboBox;
    }
}