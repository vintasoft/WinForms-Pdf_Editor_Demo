namespace DemosCommonCode.Pdf
{
    partial class ViewContentImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewContentImageForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewResourceButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.compressedSizeLabel = new System.Windows.Forms.Label();
            this.compressionLabel = new System.Windows.Forms.Label();
            this.originalSizeLabel = new System.Windows.Forms.Label();
            this.regionGroupBox = new System.Windows.Forms.GroupBox();
            this.RBlabel = new System.Windows.Forms.Label();
            this.RTlabel = new System.Windows.Forms.Label();
            this.LBlabel = new System.Windows.Forms.Label();
            this.LTlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.originalImageRadioButton = new System.Windows.Forms.RadioButton();
            this.transformedImageRadioButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageViewer = new Vintasoft.Imaging.UI.ImageViewer();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.regionGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.viewResourceButton);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.saveAsButton);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 78);
            this.panel1.TabIndex = 0;
            // 
            // viewResourceButton
            // 
            this.viewResourceButton.Location = new System.Drawing.Point(581, 42);
            this.viewResourceButton.Name = "viewResourceButton";
            this.viewResourceButton.Size = new System.Drawing.Size(107, 23);
            this.viewResourceButton.TabIndex = 3;
            resources.ApplyResources(this.viewResourceButton, "viewResourceButton");
            this.viewResourceButton.UseVisualStyleBackColor = true;
            this.viewResourceButton.Click += new System.EventHandler(this.viewResourceButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.compressedSizeLabel);
            this.groupBox2.Controls.Add(this.compressionLabel);
            this.groupBox2.Controls.Add(this.originalSizeLabel);
            this.groupBox2.Controls.Add(this.regionGroupBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(115, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 72);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            // 
            // compressedSizeLabel
            // 
            this.compressedSizeLabel.AutoSize = true;
            this.compressedSizeLabel.Location = new System.Drawing.Point(103, 49);
            this.compressedSizeLabel.Name = "compressedSizeLabel";
            this.compressedSizeLabel.Size = new System.Drawing.Size(41, 13);
            this.compressedSizeLabel.TabIndex = 6;
            resources.ApplyResources(this.compressedSizeLabel, "compressedSizeLabel");
            // 
            // compressionLabel
            // 
            this.compressionLabel.AutoSize = true;
            this.compressionLabel.Location = new System.Drawing.Point(103, 32);
            this.compressionLabel.Name = "compressionLabel";
            this.compressionLabel.Size = new System.Drawing.Size(10, 13);
            this.compressionLabel.TabIndex = 5;
            this.compressionLabel.Text = "-";
            // 
            // originalSizeLabel
            // 
            this.originalSizeLabel.AutoSize = true;
            this.originalSizeLabel.Location = new System.Drawing.Point(103, 16);
            this.originalSizeLabel.Name = "originalSizeLabel";
            this.originalSizeLabel.Size = new System.Drawing.Size(38, 13);
            this.originalSizeLabel.TabIndex = 4;
            this.originalSizeLabel.Text = "0x0 px";
            // 
            // regionGroupBox
            // 
            this.regionGroupBox.Controls.Add(this.RBlabel);
            this.regionGroupBox.Controls.Add(this.RTlabel);
            this.regionGroupBox.Controls.Add(this.LBlabel);
            this.regionGroupBox.Controls.Add(this.LTlabel);
            this.regionGroupBox.Location = new System.Drawing.Point(192, 9);
            this.regionGroupBox.Name = "regionGroupBox";
            this.regionGroupBox.Size = new System.Drawing.Size(262, 57);
            this.regionGroupBox.TabIndex = 3;
            this.regionGroupBox.TabStop = false;
            resources.ApplyResources(this.regionGroupBox, "regionGroupBox");
            // 
            // RBlabel
            // 
            this.RBlabel.AutoSize = true;
            this.RBlabel.Location = new System.Drawing.Point(128, 37);
            this.RBlabel.Name = "RBlabel";
            this.RBlabel.Size = new System.Drawing.Size(28, 13);
            this.RBlabel.TabIndex = 5;
            this.RBlabel.Text = "(0;0)";
            // 
            // RTlabel
            // 
            this.RTlabel.AutoSize = true;
            this.RTlabel.Location = new System.Drawing.Point(128, 17);
            this.RTlabel.Name = "RTlabel";
            this.RTlabel.Size = new System.Drawing.Size(28, 13);
            this.RTlabel.TabIndex = 4;
            this.RTlabel.Text = "(0;0)";
            // 
            // LBlabel
            // 
            this.LBlabel.AutoSize = true;
            this.LBlabel.Location = new System.Drawing.Point(6, 37);
            this.LBlabel.Name = "LBlabel";
            this.LBlabel.Size = new System.Drawing.Size(28, 13);
            this.LBlabel.TabIndex = 3;
            this.LBlabel.Text = "(0;0)";
            // 
            // LTlabel
            // 
            this.LTlabel.AutoSize = true;
            this.LTlabel.Location = new System.Drawing.Point(6, 17);
            this.LTlabel.Name = "LTlabel";
            this.LTlabel.Size = new System.Drawing.Size(28, 13);
            this.LTlabel.TabIndex = 2;
            this.LTlabel.Text = "(0;0)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            resources.ApplyResources(this.label3, "label3");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            resources.ApplyResources(this.label2, "label2");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            resources.ApplyResources(this.label1, "label1");
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(581, 15);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(107, 23);
            this.saveAsButton.TabIndex = 1;
            resources.ApplyResources(this.saveAsButton, "saveAsButton");
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.originalImageRadioButton);
            this.groupBox1.Controls.Add(this.transformedImageRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // originalImageRadioButton
            // 
            this.originalImageRadioButton.AutoSize = true;
            this.originalImageRadioButton.Location = new System.Drawing.Point(6, 18);
            this.originalImageRadioButton.Name = "originalImageRadioButton";
            this.originalImageRadioButton.Size = new System.Drawing.Size(60, 17);
            this.originalImageRadioButton.TabIndex = 1;
            resources.ApplyResources(this.originalImageRadioButton, "originalImageRadioButton");
            this.originalImageRadioButton.UseVisualStyleBackColor = true;
            this.originalImageRadioButton.CheckedChanged += new System.EventHandler(this.viewImageRadioButton_CheckedChanged);
            // 
            // transformedImageRadioButton
            // 
            this.transformedImageRadioButton.AutoSize = true;
            this.transformedImageRadioButton.Checked = true;
            this.transformedImageRadioButton.Location = new System.Drawing.Point(6, 42);
            this.transformedImageRadioButton.Name = "transformedImageRadioButton";
            this.transformedImageRadioButton.Size = new System.Drawing.Size(84, 17);
            this.transformedImageRadioButton.TabIndex = 0;
            this.transformedImageRadioButton.TabStop = true;
            resources.ApplyResources(this.transformedImageRadioButton, "transformedImageRadioButton");
            this.transformedImageRadioButton.UseVisualStyleBackColor = true;
            this.transformedImageRadioButton.CheckedChanged += new System.EventHandler(this.viewImageRadioButton_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.imageViewer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 394);
            this.panel2.TabIndex = 1;
            // 
            // imageViewer
            // 
            this.imageViewer.AutoScroll = true;
            this.imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer.Location = new System.Drawing.Point(0, 0);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(695, 394);
            this.imageViewer.TabIndex = 0;
            this.imageViewer.Text = "imageViewer1";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "png";
            this.saveFileDialog.Filter = "PNG files|*.png";
            // 
            // ViewContentImageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 472);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(711, 200);
            this.Name = "ViewContentImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            resources.ApplyResources(this, "$this");
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.regionGroupBox.ResumeLayout(false);
            this.regionGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton originalImageRadioButton;
        private System.Windows.Forms.RadioButton transformedImageRadioButton;
        private System.Windows.Forms.Panel panel2;
        private Vintasoft.Imaging.UI.ImageViewer imageViewer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox regionGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label compressedSizeLabel;
        private System.Windows.Forms.Label compressionLabel;
        private System.Windows.Forms.Label originalSizeLabel;
        private System.Windows.Forms.Label LBlabel;
        private System.Windows.Forms.Label LTlabel;
        private System.Windows.Forms.Label RBlabel;
        private System.Windows.Forms.Label RTlabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button viewResourceButton;
    }
}