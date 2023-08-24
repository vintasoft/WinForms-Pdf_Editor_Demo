namespace DemosCommonCode.Pdf
{
    partial class PdfInteractiveFormControl
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InteractiveFormFieldBuilder = new DemosCommonCode.Pdf.PdfInteractiveFormFieldBuilderControl();
            this.fieldContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteAnnotationOrFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addTextFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCheckBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addListBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addComboBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRadioButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupFormFieldsByPagesCheckBox = new System.Windows.Forms.CheckBox();
            this.showFieldNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.interactiveFormFieldTree = new DemosCommonCode.Pdf.PdfInteractiveFormFieldTree();
            this.addBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDigitalSignatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.fieldContextMenuStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.InteractiveFormFieldBuilder);
            this.groupBox1.Location = new System.Drawing.Point(3, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 206);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Form Fields";
            // 
            // InteractiveFormFieldBuilder
            // 
            this.InteractiveFormFieldBuilder.AddRadioButtonToFocusedGroup = true;
            this.InteractiveFormFieldBuilder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InteractiveFormFieldBuilder.NeedBuildFormFieldsContinuously = false;
            this.InteractiveFormFieldBuilder.Location = new System.Drawing.Point(3, 16);
            this.InteractiveFormFieldBuilder.Name = "InteractiveFormFieldBuilder";
            this.InteractiveFormFieldBuilder.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.InteractiveFormFieldBuilder.Size = new System.Drawing.Size(188, 187);
            this.InteractiveFormFieldBuilder.TabIndex = 1;
            // 
            // fieldContextMenuStrip
            // 
            this.fieldContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutFieldToolStripMenuItem,
            this.copyFieldToolStripMenuItem,
            this.pasteAnnotationOrFieldToolStripMenuItem,
            this.deleteFieldToolStripMenuItem,
            this.toolStripSeparator2,
            this.addTextFieldToolStripMenuItem,
            this.addCheckBoxToolStripMenuItem,
            this.addButtonToolStripMenuItem,
            this.addListBoxToolStripMenuItem,
            this.addComboBoxToolStripMenuItem,
            this.addRadioButtonToolStripMenuItem,
            this.addBarcodeToolStripMenuItem,
            this.addDigitalSignatureToolStripMenuItem,
            this.toolStripSeparator3,
            this.propertiesToolStripMenuItem1});
            this.fieldContextMenuStrip.Name = "viewerContextMenuStrip";
            this.fieldContextMenuStrip.Size = new System.Drawing.Size(187, 324);
            this.fieldContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.fieldContextMenuStrip_Opening);
            // 
            // cutFieldToolStripMenuItem
            // 
            this.cutFieldToolStripMenuItem.Name = "cutFieldToolStripMenuItem";
            this.cutFieldToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cutFieldToolStripMenuItem.Text = "Cut";
            this.cutFieldToolStripMenuItem.Click += new System.EventHandler(this.cutFieldToolStripMenuItem_Click);
            // 
            // copyFieldToolStripMenuItem
            // 
            this.copyFieldToolStripMenuItem.Name = "copyFieldToolStripMenuItem";
            this.copyFieldToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.copyFieldToolStripMenuItem.Text = "Copy";
            this.copyFieldToolStripMenuItem.Click += new System.EventHandler(this.copyFieldToolStripMenuItem_Click);
            // 
            // pasteAnnotationOrFieldToolStripMenuItem
            // 
            this.pasteAnnotationOrFieldToolStripMenuItem.Name = "pasteAnnotationOrFieldToolStripMenuItem";
            this.pasteAnnotationOrFieldToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.pasteAnnotationOrFieldToolStripMenuItem.Text = "Paste";
            this.pasteAnnotationOrFieldToolStripMenuItem.Click += new System.EventHandler(this.pasteAnnotationOrFieldToolStripMenuItem_Click);
            // 
            // deleteFieldToolStripMenuItem
            // 
            this.deleteFieldToolStripMenuItem.Name = "deleteFieldToolStripMenuItem";
            this.deleteFieldToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.deleteFieldToolStripMenuItem.Text = "Delete";
            this.deleteFieldToolStripMenuItem.Click += new System.EventHandler(this.deleteFieldToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // addTextFieldToolStripMenuItem
            // 
            this.addTextFieldToolStripMenuItem.Name = "addTextFieldToolStripMenuItem";
            this.addTextFieldToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addTextFieldToolStripMenuItem.Text = "Add Text Field";
            this.addTextFieldToolStripMenuItem.Click += new System.EventHandler(this.addInteractiveFormFieldToolStripMenuItem_Click);
            // 
            // addCheckBoxToolStripMenuItem
            // 
            this.addCheckBoxToolStripMenuItem.Name = "addCheckBoxToolStripMenuItem";
            this.addCheckBoxToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addCheckBoxToolStripMenuItem.Text = "Add Check Box";
            this.addCheckBoxToolStripMenuItem.Click += new System.EventHandler(this.addInteractiveFormFieldToolStripMenuItem_Click);
            // 
            // addButtonToolStripMenuItem
            // 
            this.addButtonToolStripMenuItem.Name = "addButtonToolStripMenuItem";
            this.addButtonToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addButtonToolStripMenuItem.Text = "Add Button";
            this.addButtonToolStripMenuItem.Click += new System.EventHandler(this.addInteractiveFormFieldToolStripMenuItem_Click);
            // 
            // addListBoxToolStripMenuItem
            // 
            this.addListBoxToolStripMenuItem.Name = "addListBoxToolStripMenuItem";
            this.addListBoxToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addListBoxToolStripMenuItem.Text = "Add List Box";
            this.addListBoxToolStripMenuItem.Click += new System.EventHandler(this.addInteractiveFormFieldToolStripMenuItem_Click);
            // 
            // addComboBoxToolStripMenuItem
            // 
            this.addComboBoxToolStripMenuItem.Name = "addComboBoxToolStripMenuItem";
            this.addComboBoxToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addComboBoxToolStripMenuItem.Text = "Add Combo Box";
            this.addComboBoxToolStripMenuItem.Click += new System.EventHandler(this.addInteractiveFormFieldToolStripMenuItem_Click);
            // 
            // addRadioButtonToolStripMenuItem
            // 
            this.addRadioButtonToolStripMenuItem.Name = "addRadioButtonToolStripMenuItem";
            this.addRadioButtonToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addRadioButtonToolStripMenuItem.Text = "Add Radio Button";
            this.addRadioButtonToolStripMenuItem.Click += new System.EventHandler(this.addInteractiveFormFieldToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // propertiesToolStripMenuItem1
            // 
            this.propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.propertiesToolStripMenuItem1.Text = "Properties...";
            this.propertiesToolStripMenuItem1.Click += new System.EventHandler(this.fieldPropertiesToolStripMenuItem_Click);
            // 
            // groupFormFieldsByPagesCheckBox
            // 
            this.groupFormFieldsByPagesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupFormFieldsByPagesCheckBox.AutoSize = true;
            this.groupFormFieldsByPagesCheckBox.Location = new System.Drawing.Point(3, 405);
            this.groupFormFieldsByPagesCheckBox.Name = "groupFormFieldsByPagesCheckBox";
            this.groupFormFieldsByPagesCheckBox.Size = new System.Drawing.Size(158, 17);
            this.groupFormFieldsByPagesCheckBox.TabIndex = 7;
            this.groupFormFieldsByPagesCheckBox.Text = "Group Form Fields by Pages";
            this.groupFormFieldsByPagesCheckBox.UseVisualStyleBackColor = true;
            this.groupFormFieldsByPagesCheckBox.CheckedChanged += new System.EventHandler(this.groupFormFieldsByPagesCheckBox_CheckedChanged);
            // 
            // showFieldNamesCheckBox
            // 
            this.showFieldNamesCheckBox.AutoSize = true;
            this.showFieldNamesCheckBox.Location = new System.Drawing.Point(3, 4);
            this.showFieldNamesCheckBox.Name = "showFieldNamesCheckBox";
            this.showFieldNamesCheckBox.Size = new System.Drawing.Size(114, 17);
            this.showFieldNamesCheckBox.TabIndex = 8;
            this.showFieldNamesCheckBox.Text = "Show Field Names";
            this.showFieldNamesCheckBox.UseVisualStyleBackColor = true;
            this.showFieldNamesCheckBox.CheckedChanged += new System.EventHandler(this.showFieldNamesCheckBox_CheckedChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.showFieldNamesCheckBox);
            this.mainPanel.Controls.Add(this.groupFormFieldsByPagesCheckBox);
            this.mainPanel.Controls.Add(this.interactiveFormFieldTree);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Enabled = false;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(200, 422);
            this.mainPanel.TabIndex = 10;
            // 
            // interactiveFormFieldTree
            // 
            this.interactiveFormFieldTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.interactiveFormFieldTree.ContextMenuStrip = this.fieldContextMenuStrip;
            this.interactiveFormFieldTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.interactiveFormFieldTree.GroupFormFieldsByPages = false;
            this.interactiveFormFieldTree.HideSelection = false;
            this.interactiveFormFieldTree.ImageIndex = 0;
            this.interactiveFormFieldTree.InteractiveForm = null;
            this.interactiveFormFieldTree.Location = new System.Drawing.Point(3, 236);
            this.interactiveFormFieldTree.Name = "interactiveFormFieldTree";
            this.interactiveFormFieldTree.SelectedField = null;
            this.interactiveFormFieldTree.SelectedImageIndex = 0;
            this.interactiveFormFieldTree.Size = new System.Drawing.Size(194, 163);
            this.interactiveFormFieldTree.TabIndex = 0;
            this.interactiveFormFieldTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.interactiveFormFieldTree_MouseDoubleClick);
            // 
            // addBarcodeToolStripMenuItem
            // 
            this.addBarcodeToolStripMenuItem.Name = "addBarcodeToolStripMenuItem";
            this.addBarcodeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addBarcodeToolStripMenuItem.Text = "Add Barcode";
            this.addBarcodeToolStripMenuItem.Click += new System.EventHandler(this.addInteractiveFormFieldToolStripMenuItem_Click);
            // 
            // addDigitalSignatureToolStripMenuItem
            // 
            this.addDigitalSignatureToolStripMenuItem.Name = "addDigitalSignatureToolStripMenuItem";
            this.addDigitalSignatureToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addDigitalSignatureToolStripMenuItem.Text = "Add Digital Signature";
            this.addDigitalSignatureToolStripMenuItem.Click += new System.EventHandler(this.addInteractiveFormFieldToolStripMenuItem_Click);
            // 
            // PdfInteractiveFormControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "PdfInteractiveFormControl";
            this.Size = new System.Drawing.Size(200, 422);
            this.groupBox1.ResumeLayout(false);
            this.fieldContextMenuStrip.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PdfInteractiveFormFieldTree interactiveFormFieldTree;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip fieldContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addTextFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCheckBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addButtonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addListBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addComboBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRadioButtonToolStripMenuItem;
        public PdfInteractiveFormFieldBuilderControl InteractiveFormFieldBuilder;
        private System.Windows.Forms.CheckBox groupFormFieldsByPagesCheckBox;
        private System.Windows.Forms.CheckBox showFieldNamesCheckBox;
        private System.Windows.Forms.ToolStripMenuItem pasteAnnotationOrFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cutFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripMenuItem addBarcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDigitalSignatureToolStripMenuItem;

    }
}