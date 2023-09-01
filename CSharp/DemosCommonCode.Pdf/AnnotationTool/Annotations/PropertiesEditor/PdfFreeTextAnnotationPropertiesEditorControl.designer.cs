namespace DemosCommonCode.Pdf
{
    partial class PdfFreeTextAnnotationPropertiesEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfFreeTextAnnotationPropertiesEditorControl));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pdfAnnotationBorderEffectEditorControl1 = new DemosCommonCode.CustomControls.PdfAnnotationBorderEffectEditorControl();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lineEndingStyleComboBox = new System.Windows.Forms.ComboBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pdfFontPanelControl1 = new DemosCommonCode.CustomControls.PdfFontPanelControl();
            this.fontSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.textQuaddingComboBox = new System.Windows.Forms.ComboBox();
            this.mainPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.pdfAnnotationBorderEffectEditorControl1);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.lineEndingStyleComboBox);
            this.mainPanel.Controls.Add(this.textBox);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.backColorPanelControl);
            this.mainPanel.Controls.Add(this.textQuaddingComboBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(357, 252);
            this.mainPanel.TabIndex = 11;
            // 
            // pdfAnnotationBorderEffectEditorControl1
            // 
            this.pdfAnnotationBorderEffectEditorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfAnnotationBorderEffectEditorControl1.Annotation = null;
            this.pdfAnnotationBorderEffectEditorControl1.Location = new System.Drawing.Point(104, 225);
            this.pdfAnnotationBorderEffectEditorControl1.MaximumSize = new System.Drawing.Size(9999999, 21);
            this.pdfAnnotationBorderEffectEditorControl1.MinimumSize = new System.Drawing.Size(0, 21);
            this.pdfAnnotationBorderEffectEditorControl1.Name = "pdfAnnotationBorderEffectEditorControl1";
            this.pdfAnnotationBorderEffectEditorControl1.Size = new System.Drawing.Size(250, 21);
            this.pdfAnnotationBorderEffectEditorControl1.TabIndex = 19;
            this.pdfAnnotationBorderEffectEditorControl1.PropertyValueChanged += new System.EventHandler(this.pdfAnnotationBorderEffectEditorControl1_PropertyValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 18;
            resources.ApplyResources(this.label7, "label7");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Text";
            // 
            // lineEndingStyleComboBox
            // 
            this.lineEndingStyleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineEndingStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lineEndingStyleComboBox.FormattingEnabled = true;
            this.lineEndingStyleComboBox.Location = new System.Drawing.Point(104, 198);
            this.lineEndingStyleComboBox.Name = "lineEndingStyleComboBox";
            this.lineEndingStyleComboBox.Size = new System.Drawing.Size(250, 21);
            this.lineEndingStyleComboBox.TabIndex = 17;
            this.lineEndingStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.lineEndingStyleComboBox_SelectedIndexChanged);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(104, 3);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(250, 58);
            this.textBox.TabIndex = 10;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 16;
            resources.ApplyResources(this.label6, "label6");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 11;
            resources.ApplyResources(this.label2, "label2");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pdfFontPanelControl1);
            this.groupBox1.Controls.Add(this.fontSizeNumericUpDown);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(3, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 74);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // pdfFontPanelControl1
            // 
            this.pdfFontPanelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfFontPanelControl1.Location = new System.Drawing.Point(101, 16);
            this.pdfFontPanelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.pdfFontPanelControl1.MinimumSize = new System.Drawing.Size(91, 22);
            this.pdfFontPanelControl1.Name = "pdfFontPanelControl1";
            this.pdfFontPanelControl1.PdfDocument = null;
            this.pdfFontPanelControl1.PdfFont = null;
            this.pdfFontPanelControl1.Size = new System.Drawing.Size(250, 22);
            this.pdfFontPanelControl1.TabIndex = 4;
            this.pdfFontPanelControl1.PdfFontChanged += new System.EventHandler(this.pdfFontPanelControl1_PdfFontChanged);
            // 
            // fontSizeNumericUpDown
            // 
            this.fontSizeNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontSizeNumericUpDown.Location = new System.Drawing.Point(101, 45);
            this.fontSizeNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.fontSizeNumericUpDown.Name = "fontSizeNumericUpDown";
            this.fontSizeNumericUpDown.Size = new System.Drawing.Size(250, 20);
            this.fontSizeNumericUpDown.TabIndex = 3;
            this.fontSizeNumericUpDown.ValueChanged += new System.EventHandler(this.fontSizeNumericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 2;
            resources.ApplyResources(this.label5, "label5");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 0;
            resources.ApplyResources(this.label4, "label4");
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 12;
            resources.ApplyResources(this.label3, "label3");
            // 
            // backColorPanelControl
            // 
            this.backColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backColorPanelControl.CanEditAlphaChannel = false;
            this.backColorPanelControl.CanSetDefaultColor = true;
            this.backColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.backColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.backColorPanelControl.Location = new System.Drawing.Point(104, 91);
            this.backColorPanelControl.Name = "backColorPanelControl";
            this.backColorPanelControl.Size = new System.Drawing.Size(250, 21);
            this.backColorPanelControl.TabIndex = 14;
            this.backColorPanelControl.ColorChanged += new System.EventHandler(this.backColorPanelControl_ColorChanged);
            // 
            // textQuaddingComboBox
            // 
            this.textQuaddingComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textQuaddingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textQuaddingComboBox.FormattingEnabled = true;
            this.textQuaddingComboBox.Location = new System.Drawing.Point(104, 67);
            this.textQuaddingComboBox.Name = "textQuaddingComboBox";
            this.textQuaddingComboBox.Size = new System.Drawing.Size(250, 21);
            this.textQuaddingComboBox.TabIndex = 13;
            this.textQuaddingComboBox.SelectedIndexChanged += new System.EventHandler(this.textQuaddingComboBox_SelectedIndexChanged);
            // 
            // PdfFreeTextAnnotationPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(231, 201);
            this.Name = "PdfFreeTextAnnotationPropertiesEditorControl";
            this.Size = new System.Drawing.Size(357, 252);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox lineEndingStyleComboBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown fontSizeNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DemosCommonCode.CustomControls.ColorPanelControl backColorPanelControl;
        private System.Windows.Forms.ComboBox textQuaddingComboBox;
        private DemosCommonCode.CustomControls.PdfFontPanelControl pdfFontPanelControl1;
        private DemosCommonCode.CustomControls.PdfAnnotationBorderEffectEditorControl pdfAnnotationBorderEffectEditorControl1;
        private System.Windows.Forms.Label label7;
    }
}