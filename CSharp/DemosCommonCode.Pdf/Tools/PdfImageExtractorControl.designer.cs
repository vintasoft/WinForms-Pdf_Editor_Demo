namespace DemosCommonCode.Pdf
{
    partial class PdfImageExtractorControl
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
            ImageExtractorTool = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfImageExtractorControl));
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.viewContentImageButton = new System.Windows.Forms.Button();
            this.saveGroupBox = new System.Windows.Forms.GroupBox();
            this.saveImageResourceButton = new System.Windows.Forms.Button();
            this.saveTransformedImageButton = new System.Windows.Forms.Button();
            this.imageResourcesListBox = new System.Windows.Forms.ListBox();
            this.ImageSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ImageExtractorContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewContentImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveImageResourceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTransformedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyImageToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel.SuspendLayout();
            this.saveGroupBox.SuspendLayout();
            this.ImageExtractorContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.viewContentImageButton);
            this.mainPanel.Controls.Add(this.saveGroupBox);
            this.mainPanel.Controls.Add(this.imageResourcesListBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Enabled = false;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(193, 274);
            this.mainPanel.TabIndex = 0;
            // 
            // viewContentImageButton
            // 
            this.viewContentImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.viewContentImageButton.Enabled = false;
            this.viewContentImageButton.Location = new System.Drawing.Point(9, 165);
            this.viewContentImageButton.Name = "viewContentImageButton";
            this.viewContentImageButton.Size = new System.Drawing.Size(175, 23);
            this.viewContentImageButton.TabIndex = 4;
            resources.ApplyResources(this.viewContentImageButton, "viewContentImageButton");
            this.viewContentImageButton.UseVisualStyleBackColor = true;
            this.viewContentImageButton.Click += new System.EventHandler(this.viewContentImageButton_Click);
            // 
            // saveGroupBox
            // 
            this.saveGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.saveGroupBox.Controls.Add(this.saveImageResourceButton);
            this.saveGroupBox.Controls.Add(this.saveTransformedImageButton);
            this.saveGroupBox.Enabled = false;
            this.saveGroupBox.Location = new System.Drawing.Point(3, 194);
            this.saveGroupBox.Name = "saveGroupBox";
            this.saveGroupBox.Size = new System.Drawing.Size(187, 77);
            this.saveGroupBox.TabIndex = 3;
            this.saveGroupBox.TabStop = false;
            resources.ApplyResources(this.saveGroupBox, "saveGroupBox");
            // 
            // saveImageResourceButton
            // 
            this.saveImageResourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveImageResourceButton.Location = new System.Drawing.Point(6, 19);
            this.saveImageResourceButton.Name = "saveImageResourceButton";
            this.saveImageResourceButton.Size = new System.Drawing.Size(175, 23);
            this.saveImageResourceButton.TabIndex = 1;
            resources.ApplyResources(this.saveImageResourceButton, "saveImageResourceButton");
            this.saveImageResourceButton.UseVisualStyleBackColor = true;
            this.saveImageResourceButton.Click += new System.EventHandler(this.saveImageResourceButton_Click);
            // 
            // saveTransformedImageButton
            // 
            this.saveTransformedImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTransformedImageButton.Location = new System.Drawing.Point(6, 48);
            this.saveTransformedImageButton.Name = "saveTransformedImageButton";
            this.saveTransformedImageButton.Size = new System.Drawing.Size(175, 23);
            this.saveTransformedImageButton.TabIndex = 2;
            resources.ApplyResources(this.saveTransformedImageButton, "saveTransformedImageButton");
            this.saveTransformedImageButton.UseVisualStyleBackColor = true;
            this.saveTransformedImageButton.Click += new System.EventHandler(this.saveTransformedImageButton_Click);
            // 
            // imageResourcesListBox
            // 
            this.imageResourcesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageResourcesListBox.FormattingEnabled = true;
            this.imageResourcesListBox.HorizontalScrollbar = true;
            this.imageResourcesListBox.Location = new System.Drawing.Point(3, 3);
            this.imageResourcesListBox.Name = "imageResourcesListBox";
            this.imageResourcesListBox.Size = new System.Drawing.Size(187, 147);
            this.imageResourcesListBox.TabIndex = 0;
            this.imageResourcesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageResourcesListBox_MouseDoubleClick);
            this.imageResourcesListBox.SelectedIndexChanged += new System.EventHandler(this.imageResourcesListBox_SelectedIndexChanged);
            // 
            // ImageExtractorContextMenuStrip
            // 
            this.ImageExtractorContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewContentImageToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveImageResourceToolStripMenuItem1,
            this.saveTransformedImageToolStripMenuItem,
            this.copyImageToClipboardToolStripMenuItem});
            this.ImageExtractorContextMenuStrip.Name = "ImageExtractorContextMenuStrip";
            this.ImageExtractorContextMenuStrip.Size = new System.Drawing.Size(215, 120);
            this.ImageExtractorContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ImageExtractorContextMenuStrip_Opening);
            // 
            // viewContentImageToolStripMenuItem
            // 
            this.viewContentImageToolStripMenuItem.Name = "viewContentImageToolStripMenuItem";
            this.viewContentImageToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            resources.ApplyResources(this.viewContentImageToolStripMenuItem, "viewContentImageToolStripMenuItem");
            this.viewContentImageToolStripMenuItem.Click += new System.EventHandler(this.viewContentImageButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // saveImageResourceToolStripMenuItem1
            // 
            this.saveImageResourceToolStripMenuItem1.Name = "saveImageResourceToolStripMenuItem1";
            this.saveImageResourceToolStripMenuItem1.Size = new System.Drawing.Size(214, 22);
            resources.ApplyResources(this.saveImageResourceToolStripMenuItem1, "saveImageResourceToolStripMenuItem1");
            this.saveImageResourceToolStripMenuItem1.Click += new System.EventHandler(this.saveImageResourceButton_Click);
            // 
            // saveTransformedImageToolStripMenuItem
            // 
            this.saveTransformedImageToolStripMenuItem.Name = "saveTransformedImageToolStripMenuItem";
            this.saveTransformedImageToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            resources.ApplyResources(this.saveTransformedImageToolStripMenuItem, "saveTransformedImageToolStripMenuItem");
            this.saveTransformedImageToolStripMenuItem.Click += new System.EventHandler(this.saveTransformedImageButton_Click);
            // 
            // copyImageToClipboardToolStripMenuItem
            // 
            this.copyImageToClipboardToolStripMenuItem.Name = "copyImageToClipboardToolStripMenuItem";
            this.copyImageToClipboardToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            resources.ApplyResources(this.copyImageToClipboardToolStripMenuItem, "copyImageToClipboardToolStripMenuItem");
            this.copyImageToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyImageToClipboardToolStripMenuItem_Click);
            // 
            // PdfImageExtractorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(162, 180);
            this.Name = "PdfImageExtractorControl";
            this.Size = new System.Drawing.Size(193, 274);
            this.mainPanel.ResumeLayout(false);
            this.saveGroupBox.ResumeLayout(false);
            this.ImageExtractorContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button saveTransformedImageButton;
        private System.Windows.Forms.Button saveImageResourceButton;
        private System.Windows.Forms.ListBox imageResourcesListBox;
        private System.Windows.Forms.SaveFileDialog ImageSaveFileDialog;
        private System.Windows.Forms.Button viewContentImageButton;
        private System.Windows.Forms.GroupBox saveGroupBox;
        private System.Windows.Forms.ContextMenuStrip ImageExtractorContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewContentImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveImageResourceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveTransformedImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyImageToClipboardToolStripMenuItem;
    }
}