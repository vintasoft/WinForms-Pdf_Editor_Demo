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
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard1 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings1 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.originalImageRadioButton = new System.Windows.Forms.RadioButton();
            this.transformedImageRadioButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageViewer = new Vintasoft.Imaging.UI.ImageViewer();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.viewResourceButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.regionGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.RTlabel = new System.Windows.Forms.Label();
            this.LBlabel = new System.Windows.Forms.Label();
            this.RBlabel = new System.Windows.Forms.Label();
            this.LTlabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.originalSizeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.compressionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.compressedSizeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.regionGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 78);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // originalImageRadioButton
            // 
            this.originalImageRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.originalImageRadioButton.AutoSize = true;
            this.originalImageRadioButton.Location = new System.Drawing.Point(3, 3);
            this.originalImageRadioButton.Name = "originalImageRadioButton";
            this.originalImageRadioButton.Size = new System.Drawing.Size(60, 17);
            this.originalImageRadioButton.TabIndex = 1;
            resources.ApplyResources(this.originalImageRadioButton, "originalImageRadioButton");
            this.originalImageRadioButton.UseVisualStyleBackColor = true;
            this.originalImageRadioButton.CheckedChanged += new System.EventHandler(this.viewImageRadioButton_CheckedChanged);
            // 
            // transformedImageRadioButton
            // 
            this.transformedImageRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.transformedImageRadioButton.AutoSize = true;
            this.transformedImageRadioButton.Checked = true;
            this.transformedImageRadioButton.Location = new System.Drawing.Point(3, 26);
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
            this.imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer.Clipboard = winFormsSystemClipboard1;
            this.imageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer.ImageRenderingSettings = renderingSettings1;
            this.imageViewer.ImageRotationAngle = 0;
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
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.originalImageRadioButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.transformedImageRadioButton, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(90, 46);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(695, 78);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // viewResourceButton
            // 
            this.viewResourceButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.viewResourceButton.AutoSize = true;
            this.viewResourceButton.Location = new System.Drawing.Point(3, 47);
            this.viewResourceButton.Name = "viewResourceButton";
            this.viewResourceButton.Size = new System.Drawing.Size(93, 23);
            this.viewResourceButton.TabIndex = 3;
            resources.ApplyResources(this.viewResourceButton, "viewResourceButton");
            this.viewResourceButton.UseVisualStyleBackColor = true;
            this.viewResourceButton.Click += new System.EventHandler(this.viewResourceButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveAsButton.AutoSize = true;
            this.saveAsButton.Location = new System.Drawing.Point(3, 8);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(67, 23);
            this.saveAsButton.TabIndex = 1;
            resources.ApplyResources(this.saveAsButton, "saveAsButton");
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.saveAsButton, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.viewResourceButton, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(524, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(171, 78);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.regionGroupBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 13);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(410, 56);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // regionGroupBox
            // 
            this.regionGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.regionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regionGroupBox.Location = new System.Drawing.Point(142, 0);
            this.regionGroupBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.regionGroupBox.MinimumSize = new System.Drawing.Size(265, 0);
            this.regionGroupBox.Name = "regionGroupBox";
            this.regionGroupBox.Size = new System.Drawing.Size(265, 53);
            this.regionGroupBox.TabIndex = 3;
            this.regionGroupBox.TabStop = false;
            resources.ApplyResources(this.regionGroupBox, "regionGroupBox");
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.LTlabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.RBlabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.LBlabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.RTlabel, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(259, 34);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // RTlabel
            // 
            this.RTlabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RTlabel.AutoSize = true;
            this.RTlabel.Location = new System.Drawing.Point(132, 2);
            this.RTlabel.Name = "RTlabel";
            this.RTlabel.Size = new System.Drawing.Size(28, 13);
            this.RTlabel.TabIndex = 4;
            this.RTlabel.Text = "(0;0)";
            // 
            // LBlabel
            // 
            this.LBlabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LBlabel.AutoSize = true;
            this.LBlabel.Location = new System.Drawing.Point(3, 19);
            this.LBlabel.Name = "LBlabel";
            this.LBlabel.Size = new System.Drawing.Size(28, 13);
            this.LBlabel.TabIndex = 3;
            this.LBlabel.Text = "(0;0)";
            // 
            // RBlabel
            // 
            this.RBlabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RBlabel.AutoSize = true;
            this.RBlabel.Location = new System.Drawing.Point(132, 19);
            this.RBlabel.Name = "RBlabel";
            this.RBlabel.Size = new System.Drawing.Size(28, 13);
            this.RBlabel.TabIndex = 5;
            this.RBlabel.Text = "(0;0)";
            // 
            // LTlabel
            // 
            this.LTlabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LTlabel.AutoSize = true;
            this.LTlabel.Location = new System.Drawing.Point(3, 2);
            this.LTlabel.Name = "LTlabel";
            this.LTlabel.Size = new System.Drawing.Size(28, 13);
            this.LTlabel.TabIndex = 2;
            this.LTlabel.Text = "(0;0)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.compressedSizeLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.compressionLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.originalSizeLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(139, 53);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // originalSizeLabel
            // 
            this.originalSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.originalSizeLabel.AutoSize = true;
            this.originalSizeLabel.Location = new System.Drawing.Point(95, 2);
            this.originalSizeLabel.Name = "originalSizeLabel";
            this.originalSizeLabel.Size = new System.Drawing.Size(38, 13);
            this.originalSizeLabel.TabIndex = 4;
            this.originalSizeLabel.Text = "0x0 px";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            resources.ApplyResources(this.label3, "label3");
            // 
            // compressionLabel
            // 
            this.compressionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.compressionLabel.AutoSize = true;
            this.compressionLabel.Location = new System.Drawing.Point(95, 19);
            this.compressionLabel.Name = "compressionLabel";
            this.compressionLabel.Size = new System.Drawing.Size(10, 13);
            this.compressionLabel.TabIndex = 5;
            this.compressionLabel.Text = "-";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            resources.ApplyResources(this.label2, "label2");
            // 
            // compressedSizeLabel
            // 
            this.compressedSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.compressedSizeLabel.AutoSize = true;
            this.compressedSizeLabel.Location = new System.Drawing.Point(95, 37);
            this.compressedSizeLabel.Name = "compressedSizeLabel";
            this.compressedSizeLabel.Size = new System.Drawing.Size(41, 13);
            this.compressedSizeLabel.TabIndex = 6;
            resources.ApplyResources(this.compressedSizeLabel, "compressedSizeLabel");
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            resources.ApplyResources(this.label1, "label1");
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(105, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(416, 72);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            resources.ApplyResources(this.groupBox2, "groupBox2");
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
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.regionGroupBox.ResumeLayout(false);
            this.regionGroupBox.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton originalImageRadioButton;
        private System.Windows.Forms.RadioButton transformedImageRadioButton;
        private System.Windows.Forms.Panel panel2;
        private Vintasoft.Imaging.UI.ImageViewer imageViewer;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.Button viewResourceButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label compressedSizeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label compressionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label originalSizeLabel;
        private System.Windows.Forms.GroupBox regionGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label LTlabel;
        private System.Windows.Forms.Label RBlabel;
        private System.Windows.Forms.Label LBlabel;
        private System.Windows.Forms.Label RTlabel;
    }
}