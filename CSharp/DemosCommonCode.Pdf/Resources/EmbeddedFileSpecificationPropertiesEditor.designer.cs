namespace DemosCommonCode.Pdf
{
    partial class EmbeddedFileSpecificationPropertiesEditor
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
            this.label5 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.compressedSizeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uncompressedSizeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.compressionComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filenameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Location = new System.Drawing.Point(96, 29);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(316, 20);
            this.descriptionTextBox.TabIndex = 19;
            this.descriptionTextBox.TextChanged += new System.EventHandler(this.descriptionTextBox_TextChanged);
            // 
            // compressedSizeTextBox
            // 
            this.compressedSizeTextBox.Location = new System.Drawing.Point(96, 107);
            this.compressedSizeTextBox.Name = "compressedSizeTextBox";
            this.compressedSizeTextBox.ReadOnly = true;
            this.compressedSizeTextBox.Size = new System.Drawing.Size(151, 20);
            this.compressedSizeTextBox.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Compressed Size";
            // 
            // uncompressedSizeTextBox
            // 
            this.uncompressedSizeTextBox.Location = new System.Drawing.Point(96, 56);
            this.uncompressedSizeTextBox.Name = "uncompressedSizeTextBox";
            this.uncompressedSizeTextBox.ReadOnly = true;
            this.uncompressedSizeTextBox.Size = new System.Drawing.Size(151, 20);
            this.uncompressedSizeTextBox.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "File Size";
            // 
            // compressionComboBox
            // 
            this.compressionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compressionComboBox.FormattingEnabled = true;
            this.compressionComboBox.Location = new System.Drawing.Point(96, 81);
            this.compressionComboBox.Name = "compressionComboBox";
            this.compressionComboBox.Size = new System.Drawing.Size(151, 21);
            this.compressionComboBox.TabIndex = 14;
            this.compressionComboBox.SelectedIndexChanged += new System.EventHandler(this.compressionComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Compression";
            // 
            // filenameTextBox
            // 
            this.filenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameTextBox.Location = new System.Drawing.Point(96, 3);
            this.filenameTextBox.Name = "filenameTextBox";
            this.filenameTextBox.Size = new System.Drawing.Size(316, 20);
            this.filenameTextBox.TabIndex = 21;
            this.filenameTextBox.TextChanged += new System.EventHandler(this.filenameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Filename";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.filenameTextBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.compressionComboBox);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.descriptionTextBox);
            this.mainPanel.Controls.Add(this.uncompressedSizeTextBox);
            this.mainPanel.Controls.Add(this.compressedSizeTextBox);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(415, 130);
            this.mainPanel.TabIndex = 23;
            // 
            // EmbeddedFileSpecificationPropertiesEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(251, 107);
            this.Name = "EmbeddedFileSpecificationPropertiesEditor";
            this.Size = new System.Drawing.Size(415, 130);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox compressedSizeTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uncompressedSizeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox compressionComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filenameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel mainPanel;
    }
}