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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.pixelFormatLabel = new System.Windows.Forms.Label();
            this.imageNumberLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.jpeg2000CompressionGroupBox = new System.Windows.Forms.GroupBox();
            this.jpeg200SettingsButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.jpegParamsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityNumericUpDown)).BeginInit();
            this.jbig2ParamsGroupBox.SuspendLayout();
            this.jpeg2000CompressionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sizeLabel);
            this.groupBox1.Controls.Add(this.pixelFormatLabel);
            this.groupBox1.Controls.Add(this.imageNumberLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image info";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(83, 68);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(14, 13);
            this.sizeLabel.TabIndex = 5;
            this.sizeLabel.Text = "X";
            // 
            // pixelFormatLabel
            // 
            this.pixelFormatLabel.AutoSize = true;
            this.pixelFormatLabel.Location = new System.Drawing.Point(83, 44);
            this.pixelFormatLabel.Name = "pixelFormatLabel";
            this.pixelFormatLabel.Size = new System.Drawing.Size(14, 13);
            this.pixelFormatLabel.TabIndex = 4;
            this.pixelFormatLabel.Text = "X";
            // 
            // imageNumberLabel
            // 
            this.imageNumberLabel.AutoSize = true;
            this.imageNumberLabel.Location = new System.Drawing.Point(83, 20);
            this.imageNumberLabel.Name = "imageNumberLabel";
            this.imageNumberLabel.Size = new System.Drawing.Size(14, 13);
            this.imageNumberLabel.TabIndex = 3;
            this.imageNumberLabel.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pixel Format";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.jpeg2000CompressionGroupBox);
            this.groupBox2.Controls.Add(this.compressionComboBox);
            this.groupBox2.Controls.Add(this.jpegParamsGroupBox);
            this.groupBox2.Controls.Add(this.jbig2ParamsGroupBox);
            this.groupBox2.Location = new System.Drawing.Point(219, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 117);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compression";
            // 
            // compressionComboBox
            // 
            this.compressionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compressionComboBox.FormattingEnabled = true;
            this.compressionComboBox.Location = new System.Drawing.Point(9, 19);
            this.compressionComboBox.Name = "compressionComboBox";
            this.compressionComboBox.Size = new System.Drawing.Size(181, 21);
            this.compressionComboBox.TabIndex = 0;
            this.compressionComboBox.SelectedIndexChanged += new System.EventHandler(this.compressionComboBox_SelectedIndexChanged);
            // 
            // jpegParamsGroupBox
            // 
            this.jpegParamsGroupBox.Controls.Add(this.jpegGrayscaleCheckBox);
            this.jpegParamsGroupBox.Controls.Add(this.label4);
            this.jpegParamsGroupBox.Controls.Add(this.jpegQualityNumericUpDown);
            this.jpegParamsGroupBox.Location = new System.Drawing.Point(11, 46);
            this.jpegParamsGroupBox.Name = "jpegParamsGroupBox";
            this.jpegParamsGroupBox.Size = new System.Drawing.Size(179, 64);
            this.jpegParamsGroupBox.TabIndex = 1;
            this.jpegParamsGroupBox.TabStop = false;
            this.jpegParamsGroupBox.Text = "JPEG";
            // 
            // jpegGrayscaleCheckBox
            // 
            this.jpegGrayscaleCheckBox.AutoSize = true;
            this.jpegGrayscaleCheckBox.Location = new System.Drawing.Point(83, 42);
            this.jpegGrayscaleCheckBox.Name = "jpegGrayscaleCheckBox";
            this.jpegGrayscaleCheckBox.Size = new System.Drawing.Size(73, 17);
            this.jpegGrayscaleCheckBox.TabIndex = 2;
            this.jpegGrayscaleCheckBox.Text = "Grayscale";
            this.jpegGrayscaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Quality";
            // 
            // jpegQualityNumericUpDown
            // 
            this.jpegQualityNumericUpDown.Location = new System.Drawing.Point(83, 15);
            this.jpegQualityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.jpegQualityNumericUpDown.Name = "jpegQualityNumericUpDown";
            this.jpegQualityNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.jpegQualityNumericUpDown.TabIndex = 0;
            this.jpegQualityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // jbig2ParamsGroupBox
            // 
            this.jbig2ParamsGroupBox.Controls.Add(this.jbig2UseGlobalsCheckBox);
            this.jbig2ParamsGroupBox.Controls.Add(this.jbig2LossyCheckBox);
            this.jbig2ParamsGroupBox.Location = new System.Drawing.Point(11, 46);
            this.jbig2ParamsGroupBox.Name = "jbig2ParamsGroupBox";
            this.jbig2ParamsGroupBox.Size = new System.Drawing.Size(179, 64);
            this.jbig2ParamsGroupBox.TabIndex = 2;
            this.jbig2ParamsGroupBox.TabStop = false;
            this.jbig2ParamsGroupBox.Text = "JBIG2";
            // 
            // jbig2UseGlobalsCheckBox
            // 
            this.jbig2UseGlobalsCheckBox.AutoSize = true;
            this.jbig2UseGlobalsCheckBox.Location = new System.Drawing.Point(9, 41);
            this.jbig2UseGlobalsCheckBox.Name = "jbig2UseGlobalsCheckBox";
            this.jbig2UseGlobalsCheckBox.Size = new System.Drawing.Size(83, 17);
            this.jbig2UseGlobalsCheckBox.TabIndex = 1;
            this.jbig2UseGlobalsCheckBox.Text = "Use Globals";
            this.jbig2UseGlobalsCheckBox.UseVisualStyleBackColor = true;
            // 
            // jbig2LossyCheckBox
            // 
            this.jbig2LossyCheckBox.AutoSize = true;
            this.jbig2LossyCheckBox.Location = new System.Drawing.Point(9, 19);
            this.jbig2LossyCheckBox.Name = "jbig2LossyCheckBox";
            this.jbig2LossyCheckBox.Size = new System.Drawing.Size(89, 17);
            this.jbig2LossyCheckBox.TabIndex = 0;
            this.jbig2LossyCheckBox.Text = "Lossy Coding";
            this.jbig2LossyCheckBox.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(264, 127);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // forAllButton
            // 
            this.forAllButton.Location = new System.Drawing.Point(345, 127);
            this.forAllButton.Name = "forAllButton";
            this.forAllButton.Size = new System.Drawing.Size(75, 23);
            this.forAllButton.TabIndex = 3;
            this.forAllButton.Text = "Use For All";
            this.forAllButton.UseVisualStyleBackColor = true;
            this.forAllButton.Click += new System.EventHandler(this.forAllButton_Click);
            // 
            // jpeg2000CompressionGroupBox
            // 
            this.jpeg2000CompressionGroupBox.Controls.Add(this.jpeg200SettingsButton);
            this.jpeg2000CompressionGroupBox.Location = new System.Drawing.Point(11, 46);
            this.jpeg2000CompressionGroupBox.Name = "jpeg2000CompressionGroupBox";
            this.jpeg2000CompressionGroupBox.Size = new System.Drawing.Size(179, 64);
            this.jpeg2000CompressionGroupBox.TabIndex = 12;
            this.jpeg2000CompressionGroupBox.TabStop = false;
            this.jpeg2000CompressionGroupBox.Text = "JPEG 2000";
            this.jpeg2000CompressionGroupBox.Visible = false;
            // 
            // jpeg200SettingsButton
            // 
            this.jpeg200SettingsButton.Location = new System.Drawing.Point(9, 22);
            this.jpeg200SettingsButton.Name = "jpeg200SettingsButton";
            this.jpeg200SettingsButton.Size = new System.Drawing.Size(108, 23);
            this.jpeg200SettingsButton.TabIndex = 0;
            this.jpeg200SettingsButton.Text = "Settings...";
            this.jpeg200SettingsButton.UseVisualStyleBackColor = true;
            this.jpeg200SettingsButton.Click += new System.EventHandler(this.jpeg2000SettingsButton_Click);
            // 
            // SetCompressionParamsDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 158);
            this.Controls.Add(this.forAllButton);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetCompressionParamsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Image Compression";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.jpegParamsGroupBox.ResumeLayout(false);
            this.jpegParamsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityNumericUpDown)).EndInit();
            this.jbig2ParamsGroupBox.ResumeLayout(false);
            this.jbig2ParamsGroupBox.PerformLayout();
            this.jpeg2000CompressionGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}