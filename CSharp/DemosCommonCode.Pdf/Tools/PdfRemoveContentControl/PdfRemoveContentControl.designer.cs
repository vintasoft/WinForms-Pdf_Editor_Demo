namespace DemosCommonCode.Pdf
{
    partial class PdfRemoveContentControl
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
            RemoveContentTool = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfRemoveContentControl));
            this.addRedactionMarkGroupBox = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.removeAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeRasterGraphicsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeTextToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeVectorGraphicsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeAnnotationsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeSelectedPageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.redactionMarksListBox = new System.Windows.Forms.ListBox();
            this.redactionMarkContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.showPackDialogAfterMarkAppliesCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.applyRedactionMarksToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.markSelectedPagesFrmRedactionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteSelectedRedactionMarkToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.redactionMarkAppearancePropertiesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.imageViewerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageViewerPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewerRemoveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRedactionMarkGroupBox.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.redactionMarkContextMenuStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.imageViewerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // addRedactionMarkGroupBox
            // 
            this.addRedactionMarkGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addRedactionMarkGroupBox.Controls.Add(this.toolStrip2);
            this.addRedactionMarkGroupBox.Location = new System.Drawing.Point(3, 125);
            this.addRedactionMarkGroupBox.Name = "addRedactionMarkGroupBox";
            this.addRedactionMarkGroupBox.Size = new System.Drawing.Size(246, 155);
            this.addRedactionMarkGroupBox.TabIndex = 1;
            this.addRedactionMarkGroupBox.TabStop = false;
            resources.ApplyResources(this.addRedactionMarkGroupBox, "addRedactionMarkGroupBox");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAllToolStripButton,
            this.removeRasterGraphicsToolStripButton,
            this.removeTextToolStripButton,
            this.removeVectorGraphicsToolStripButton,
            this.removeAnnotationsToolStripButton,
            this.removeSelectedPageToolStripButton});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(240, 136);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // removeAllToolStripButton
            // 
            this.removeAllToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeAllToolStripButton.Image")));
            this.removeAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeAllToolStripButton.Name = "removeAllToolStripButton";
            this.removeAllToolStripButton.Size = new System.Drawing.Size(87, 20);
            resources.ApplyResources(this.removeAllToolStripButton, "removeAllToolStripButton");
            this.removeAllToolStripButton.Click += new System.EventHandler(this.AddRedactionMarkButton_Click);
            // 
            // removeRasterGraphicsToolStripButton
            // 
            this.removeRasterGraphicsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeRasterGraphicsToolStripButton.Image")));
            this.removeRasterGraphicsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeRasterGraphicsToolStripButton.Name = "removeRasterGraphicsToolStripButton";
            this.removeRasterGraphicsToolStripButton.Size = new System.Drawing.Size(154, 20);
            resources.ApplyResources(this.removeRasterGraphicsToolStripButton, "removeRasterGraphicsToolStripButton");
            this.removeRasterGraphicsToolStripButton.Click += new System.EventHandler(this.AddRedactionMarkButton_Click);
            // 
            // removeTextToolStripButton
            // 
            this.removeTextToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeTextToolStripButton.Image")));
            this.removeTextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeTextToolStripButton.Name = "removeTextToolStripButton";
            this.removeTextToolStripButton.Size = new System.Drawing.Size(94, 20);
            resources.ApplyResources(this.removeTextToolStripButton, "removeTextToolStripButton");
            this.removeTextToolStripButton.Click += new System.EventHandler(this.AddRedactionMarkButton_Click);
            // 
            // removeVectorGraphicsToolStripButton
            // 
            this.removeVectorGraphicsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeVectorGraphicsToolStripButton.Image")));
            this.removeVectorGraphicsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeVectorGraphicsToolStripButton.Name = "removeVectorGraphicsToolStripButton";
            this.removeVectorGraphicsToolStripButton.Size = new System.Drawing.Size(155, 20);
            resources.ApplyResources(this.removeVectorGraphicsToolStripButton, "removeVectorGraphicsToolStripButton");
            this.removeVectorGraphicsToolStripButton.Click += new System.EventHandler(this.AddRedactionMarkButton_Click);
            // 
            // removeAnnotationsToolStripButton
            // 
            this.removeAnnotationsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeAnnotationsToolStripButton.Image")));
            this.removeAnnotationsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeAnnotationsToolStripButton.Name = "removeAnnotationsToolStripButton";
            this.removeAnnotationsToolStripButton.Size = new System.Drawing.Size(138, 20);
            resources.ApplyResources(this.removeAnnotationsToolStripButton, "removeAnnotationsToolStripButton");
            this.removeAnnotationsToolStripButton.Click += new System.EventHandler(this.AddRedactionMarkButton_Click);
            // 
            // removeSelectedPageToolStripButton
            // 
            this.removeSelectedPageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeSelectedPageToolStripButton.Image")));
            this.removeSelectedPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeSelectedPageToolStripButton.Name = "removeSelectedPageToolStripButton";
            this.removeSelectedPageToolStripButton.Size = new System.Drawing.Size(146, 20);
            resources.ApplyResources(this.removeSelectedPageToolStripButton, "removeSelectedPageToolStripButton");
            this.removeSelectedPageToolStripButton.Click += new System.EventHandler(this.removeSelectedPageToolStripButton_Click);
            // 
            // redactionMarksListBox
            // 
            this.redactionMarksListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.redactionMarksListBox.FormattingEnabled = true;
            this.redactionMarksListBox.Location = new System.Drawing.Point(3, 281);
            this.redactionMarksListBox.Name = "redactionMarksListBox";
            this.redactionMarksListBox.Size = new System.Drawing.Size(246, 134);
            this.redactionMarksListBox.TabIndex = 2;
            this.redactionMarksListBox.SelectedIndexChanged += new System.EventHandler(this.redactionMarksListBox_SelectedIndexChanged);
            // 
            // redactionMarkContextMenuStrip
            // 
            this.redactionMarkContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem});
            this.redactionMarkContextMenuStrip.Name = "redactionMarkContextMenuStrip";
            this.redactionMarkContextMenuStrip.Size = new System.Drawing.Size(108, 98);
            this.redactionMarkContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.redactionMarkContextMenuStrip_Opening);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            resources.ApplyResources(this.cutToolStripMenuItem, "cutToolStripMenuItem");
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            resources.ApplyResources(this.pasteToolStripMenuItem, "pasteToolStripMenuItem");
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.showPackDialogAfterMarkAppliesCheckBox);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.redactionMarksListBox);
            this.mainPanel.Controls.Add(this.addRedactionMarkGroupBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Enabled = false;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(252, 428);
            this.mainPanel.TabIndex = 3;
            // 
            // showPackDialogAfterMarkAppliesCheckBox
            // 
            this.showPackDialogAfterMarkAppliesCheckBox.AutoSize = true;
            this.showPackDialogAfterMarkAppliesCheckBox.Checked = true;
            this.showPackDialogAfterMarkAppliesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPackDialogAfterMarkAppliesCheckBox.Location = new System.Drawing.Point(6, 102);
            this.showPackDialogAfterMarkAppliesCheckBox.Name = "showPackDialogAfterMarkAppliesCheckBox";
            this.showPackDialogAfterMarkAppliesCheckBox.Size = new System.Drawing.Size(203, 17);
            this.showPackDialogAfterMarkAppliesCheckBox.TabIndex = 4;
            resources.ApplyResources(this.showPackDialogAfterMarkAppliesCheckBox, "showPackDialogAfterMarkAppliesCheckBox");
            this.showPackDialogAfterMarkAppliesCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 96);
            this.panel1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applyRedactionMarksToolStripButton,
            this.markSelectedPagesFrmRedactionToolStripButton,
            this.deleteSelectedRedactionMarkToolStripButton,
            this.redactionMarkAppearancePropertiesToolStripButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(246, 96);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // applyRedactionMarksToolStripButton
            // 
            this.applyRedactionMarksToolStripButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.applyRedactionMarksToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("applyRedactionMarksToolStripButton.Image")));
            this.applyRedactionMarksToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.applyRedactionMarksToolStripButton.Name = "applyRedactionMarksToolStripButton";
            this.applyRedactionMarksToolStripButton.Size = new System.Drawing.Size(154, 20);
            resources.ApplyResources(this.applyRedactionMarksToolStripButton, "applyRedactionMarksToolStripButton");
            this.applyRedactionMarksToolStripButton.Click += new System.EventHandler(this.applyRedactionMarksToolStripButton_Click);
            // 
            // markSelectedPagesFrmRedactionToolStripButton
            // 
            this.markSelectedPagesFrmRedactionToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("markSelectedPagesFrmRedactionToolStripButton.Image")));
            this.markSelectedPagesFrmRedactionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.markSelectedPagesFrmRedactionToolStripButton.Name = "markSelectedPagesFrmRedactionToolStripButton";
            this.markSelectedPagesFrmRedactionToolStripButton.Size = new System.Drawing.Size(209, 20);
            resources.ApplyResources(this.markSelectedPagesFrmRedactionToolStripButton, "markSelectedPagesFrmRedactionToolStripButton");
            this.markSelectedPagesFrmRedactionToolStripButton.Visible = false;
            this.markSelectedPagesFrmRedactionToolStripButton.Click += new System.EventHandler(this.markSelectedPagesFrmRedactionToolStripButton_Click);
            // 
            // deleteSelectedRedactionMarkToolStripButton
            // 
            this.deleteSelectedRedactionMarkToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteSelectedRedactionMarkToolStripButton.Image")));
            this.deleteSelectedRedactionMarkToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteSelectedRedactionMarkToolStripButton.Name = "deleteSelectedRedactionMarkToolStripButton";
            this.deleteSelectedRedactionMarkToolStripButton.Size = new System.Drawing.Size(193, 20);
            resources.ApplyResources(this.deleteSelectedRedactionMarkToolStripButton, "deleteSelectedRedactionMarkToolStripButton");
            this.deleteSelectedRedactionMarkToolStripButton.Click += new System.EventHandler(this.deleteSelectedRedactionMarkToolStripButton_Click);
            // 
            // redactionMarkAppearancePropertiesToolStripButton
            // 
            this.redactionMarkAppearancePropertiesToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("redactionMarkAppearancePropertiesToolStripButton.Image")));
            this.redactionMarkAppearancePropertiesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redactionMarkAppearancePropertiesToolStripButton.Name = "redactionMarkAppearancePropertiesToolStripButton";
            this.redactionMarkAppearancePropertiesToolStripButton.Size = new System.Drawing.Size(185, 20);
            resources.ApplyResources(this.redactionMarkAppearancePropertiesToolStripButton, "redactionMarkAppearancePropertiesToolStripButton");
            this.redactionMarkAppearancePropertiesToolStripButton.Click += new System.EventHandler(this.redactionMarkAppearancePropertiesToolStripButton_Click);
            // 
            // imageViewerContextMenuStrip
            // 
            this.imageViewerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageViewerPasteToolStripMenuItem,
            this.imageViewerRemoveAllToolStripMenuItem});
            this.imageViewerContextMenuStrip.Name = "imageViewerContextMenuStrip";
            this.imageViewerContextMenuStrip.Size = new System.Drawing.Size(135, 48);
            this.imageViewerContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.imageViewerContextMenuStrip_Opening);
            // 
            // imageViewerPasteToolStripMenuItem
            // 
            this.imageViewerPasteToolStripMenuItem.Name = "imageViewerPasteToolStripMenuItem";
            this.imageViewerPasteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            resources.ApplyResources(this.imageViewerPasteToolStripMenuItem, "imageViewerPasteToolStripMenuItem");
            this.imageViewerPasteToolStripMenuItem.Click += new System.EventHandler(this.imageViewerPasteToolStripMenuItem_Click);
            // 
            // imageViewerRemoveAllToolStripMenuItem
            // 
            this.imageViewerRemoveAllToolStripMenuItem.Name = "imageViewerRemoveAllToolStripMenuItem";
            this.imageViewerRemoveAllToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            resources.ApplyResources(this.imageViewerRemoveAllToolStripMenuItem, "imageViewerRemoveAllToolStripMenuItem");
            this.imageViewerRemoveAllToolStripMenuItem.Click += new System.EventHandler(this.imageViewerRemoveAllToolStripMenuItem_Click);
            // 
            // PdfRemoveContentControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(168, 340);
            this.Name = "PdfRemoveContentControl";
            this.Size = new System.Drawing.Size(252, 428);
            this.addRedactionMarkGroupBox.ResumeLayout(false);
            this.addRedactionMarkGroupBox.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.redactionMarkContextMenuStrip.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.imageViewerContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox addRedactionMarkGroupBox;
        private System.Windows.Forms.ListBox redactionMarksListBox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ContextMenuStrip redactionMarkContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip imageViewerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imageViewerPasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewerRemoveAllToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton removeAllToolStripButton;
        private System.Windows.Forms.ToolStripButton removeRasterGraphicsToolStripButton;
        private System.Windows.Forms.ToolStripButton removeTextToolStripButton;
        private System.Windows.Forms.ToolStripButton removeVectorGraphicsToolStripButton;
        private System.Windows.Forms.ToolStripButton removeAnnotationsToolStripButton;
        private System.Windows.Forms.ToolStripButton applyRedactionMarksToolStripButton;
        private System.Windows.Forms.ToolStripButton markSelectedPagesFrmRedactionToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteSelectedRedactionMarkToolStripButton;
        private System.Windows.Forms.ToolStripButton redactionMarkAppearancePropertiesToolStripButton;
        private System.Windows.Forms.ToolStripButton removeSelectedPageToolStripButton;
        private System.Windows.Forms.CheckBox showPackDialogAfterMarkAppliesCheckBox;

    }
}