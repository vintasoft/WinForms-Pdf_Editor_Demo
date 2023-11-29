namespace PdfEditorDemo
{
    partial class SetCompressionParamsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetCompressionParamsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.imageNumberLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pixelFormatLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jpeg2000CompressionGroupBox = new System.Windows.Forms.GroupBox();
            this.jpeg200SettingsButton = new System.Windows.Forms.Button();
            this.compressionComboBox = new System.Windows.Forms.ComboBox();
            this.jpegParamsGroupBox = new System.Windows.Forms.GroupBox();
            this.jpegGrayscaleCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.jpegQualityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.jbig2ParamsGroupBox = new System.Windows.Forms.GroupBox();
            this.jbig2UseGlobalsCheckBox = new System.Windows.Forms.CheckBox();
            this.jbig2LossyCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.forAllButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.jpeg2000CompressionGroupBox.SuspendLayout();
            this.jpegParamsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityNumericUpDown)).BeginInit();
            this.jbig2ParamsGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sizeLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.imageNumberLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pixelFormatLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(208, 98);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            resources.ApplyResources(this.label1, "label1");
            // 
            // sizeLabel
            // 
            this.sizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(73, 74);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(14, 13);
            this.sizeLabel.TabIndex = 5;
            this.sizeLabel.Text = "X";
            // 
            // imageNumberLabel
            // 
            this.imageNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.imageNumberLabel.AutoSize = true;
            this.imageNumberLabel.Location = new System.Drawing.Point(73, 9);
            this.imageNumberLabel.Name = "imageNumberLabel";
            this.imageNumberLabel.Size = new System.Drawing.Size(14, 13);
            this.imageNumberLabel.TabIndex = 3;
            this.imageNumberLabel.Text = "X";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            resources.ApplyResources(this.label3, "label3");
            // 
            // pixelFormatLabel
            // 
            this.pixelFormatLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pixelFormatLabel.AutoSize = true;
            this.pixelFormatLabel.Location = new System.Drawing.Point(73, 41);
            this.pixelFormatLabel.Name = "pixelFormatLabel";
            this.pixelFormatLabel.Size = new System.Drawing.Size(14, 13);
            this.pixelFormatLabel.TabIndex = 4;
            this.pixelFormatLabel.Text = "X";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            resources.ApplyResources(this.label2, "label2");
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.compressionComboBox);
            this.groupBox2.Controls.Add(this.jpeg2000CompressionGroupBox);
            this.groupBox2.Controls.Add(this.jpegParamsGroupBox);
            this.groupBox2.Controls.Add(this.jbig2ParamsGroupBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 136);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            // 
            // jpeg2000CompressionGroupBox
            // 
            this.jpeg2000CompressionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jpeg2000CompressionGroupBox.Controls.Add(this.jpeg200SettingsButton);
            this.jpeg2000CompressionGroupBox.Location = new System.Drawing.Point(11, 46);
            this.jpeg2000CompressionGroupBox.Name = "jpeg2000CompressionGroupBox";
            this.jpeg2000CompressionGroupBox.Size = new System.Drawing.Size(197, 71);
            this.jpeg2000CompressionGroupBox.TabIndex = 12;
            this.jpeg2000CompressionGroupBox.TabStop = false;
            this.jpeg2000CompressionGroupBox.Text = "JPEG 2000";
            this.jpeg2000CompressionGroupBox.Visible = false;
            // 
            // jpeg200SettingsButton
            // 
            this.jpeg200SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.jpeg200SettingsButton.Location = new System.Drawing.Point(9, 23);
            this.jpeg200SettingsButton.Name = "jpeg200SettingsButton";
            this.jpeg200SettingsButton.Size = new System.Drawing.Size(182, 23);
            this.jpeg200SettingsButton.TabIndex = 0;
            resources.ApplyResources(this.jpeg200SettingsButton, "jpeg200SettingsButton");
            this.jpeg200SettingsButton.UseVisualStyleBackColor = true;
            this.jpeg200SettingsButton.Click += new System.EventHandler(this.jpeg2000SettingsButton_Click);
            // 
            // compressionComboBox
            // 
            this.compressionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.compressionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compressionComboBox.FormattingEnabled = true;
            this.compressionComboBox.Location = new System.Drawing.Point(9, 19);
            this.compressionComboBox.Name = "compressionComboBox";
            this.compressionComboBox.Size = new System.Drawing.Size(199, 21);
            this.compressionComboBox.TabIndex = 0;
            this.compressionComboBox.SelectedIndexChanged += new System.EventHandler(this.compressionComboBox_SelectedIndexChanged);
            // 
            // jpegParamsGroupBox
            // 
            this.jpegParamsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jpegParamsGroupBox.AutoSize = true;
            this.jpegParamsGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.jpegParamsGroupBox.Location = new System.Drawing.Point(11, 46);
            this.jpegParamsGroupBox.Name = "jpegParamsGroupBox";
            this.jpegParamsGroupBox.Size = new System.Drawing.Size(197, 71);
            this.jpegParamsGroupBox.TabIndex = 1;
            this.jpegParamsGroupBox.TabStop = false;
            this.jpegParamsGroupBox.Text = "JPEG";
            // 
            // jpegGrayscaleCheckBox
            // 
            this.jpegGrayscaleCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.jpegGrayscaleCheckBox.AutoSize = true;
            this.jpegGrayscaleCheckBox.Location = new System.Drawing.Point(48, 30);
            this.jpegGrayscaleCheckBox.Name = "jpegGrayscaleCheckBox";
            this.jpegGrayscaleCheckBox.Size = new System.Drawing.Size(73, 17);
            this.jpegGrayscaleCheckBox.TabIndex = 2;
            this.jpegGrayscaleCheckBox.Text = "Grayscale";
            this.jpegGrayscaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 1;
            resources.ApplyResources(this.label4, "label4");
            // 
            // jpegQualityNumericUpDown
            // 
            this.jpegQualityNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.jpegQualityNumericUpDown.Location = new System.Drawing.Point(48, 3);
            this.jpegQualityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.jpegQualityNumericUpDown.Name = "jpegQualityNumericUpDown";
            this.jpegQualityNumericUpDown.Size = new System.Drawing.Size(71, 20);
            this.jpegQualityNumericUpDown.TabIndex = 0;
            this.jpegQualityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // jbig2ParamsGroupBox
            // 
            this.jbig2ParamsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jbig2ParamsGroupBox.AutoSize = true;
            this.jbig2ParamsGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.jbig2ParamsGroupBox.Location = new System.Drawing.Point(11, 46);
            this.jbig2ParamsGroupBox.Name = "jbig2ParamsGroupBox";
            this.jbig2ParamsGroupBox.Size = new System.Drawing.Size(197, 71);
            this.jbig2ParamsGroupBox.TabIndex = 2;
            this.jbig2ParamsGroupBox.TabStop = false;
            this.jbig2ParamsGroupBox.Text = "JBIG2";
            // 
            // jbig2UseGlobalsCheckBox
            // 
            this.jbig2UseGlobalsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.jbig2UseGlobalsCheckBox.AutoSize = true;
            this.jbig2UseGlobalsCheckBox.Location = new System.Drawing.Point(3, 30);
            this.jbig2UseGlobalsCheckBox.Name = "jbig2UseGlobalsCheckBox";
            this.jbig2UseGlobalsCheckBox.Size = new System.Drawing.Size(83, 17);
            this.jbig2UseGlobalsCheckBox.TabIndex = 1;
            resources.ApplyResources(this.jbig2UseGlobalsCheckBox, "jbig2UseGlobalsCheckBox");
            this.jbig2UseGlobalsCheckBox.UseVisualStyleBackColor = true;
            // 
            // jbig2LossyCheckBox
            // 
            this.jbig2LossyCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.jbig2LossyCheckBox.AutoSize = true;
            this.jbig2LossyCheckBox.Location = new System.Drawing.Point(3, 4);
            this.jbig2LossyCheckBox.Name = "jbig2LossyCheckBox";
            this.jbig2LossyCheckBox.Size = new System.Drawing.Size(89, 17);
            this.jbig2LossyCheckBox.TabIndex = 0;
            resources.ApplyResources(this.jbig2LossyCheckBox, "jbig2LossyCheckBox");
            this.jbig2LossyCheckBox.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(70, 272);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // forAllButton
            // 
            this.forAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.forAllButton.Location = new System.Drawing.Point(151, 272);
            this.forAllButton.Name = "forAllButton";
            this.forAllButton.Size = new System.Drawing.Size(75, 23);
            this.forAllButton.TabIndex = 3;
            resources.ApplyResources(this.forAllButton, "forAllButton");
            this.forAllButton.UseVisualStyleBackColor = true;
            this.forAllButton.Click += new System.EventHandler(this.forAllButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.jpegGrayscaleCheckBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.jpegQualityNumericUpDown, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(191, 52);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.jbig2UseGlobalsCheckBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.jbig2LossyCheckBox, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(191, 52);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // SetCompressionParamsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(238, 307);
            this.Controls.Add(this.forAllButton);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetCompressionParamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            resources.ApplyResources(this, "$this");
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.jpeg2000CompressionGroupBox.ResumeLayout(false);
            this.jpegParamsGroupBox.ResumeLayout(false);
            this.jpegParamsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityNumericUpDown)).EndInit();
            this.jbig2ParamsGroupBox.ResumeLayout(false);
            this.jbig2ParamsGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label pixelFormatLabel;
        private System.Windows.Forms.Label imageNumberLabel;
        private System.Windows.Forms.ComboBox compressionComboBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button forAllButton;
        private System.Windows.Forms.GroupBox jpegParamsGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown jpegQualityNumericUpDown;
        private System.Windows.Forms.GroupBox jbig2ParamsGroupBox;
        private System.Windows.Forms.CheckBox jbig2UseGlobalsCheckBox;
        private System.Windows.Forms.CheckBox jbig2LossyCheckBox;
        private System.Windows.Forms.CheckBox jpegGrayscaleCheckBox;
        private System.Windows.Forms.GroupBox jpeg2000CompressionGroupBox;
        private System.Windows.Forms.Button jpeg200SettingsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}