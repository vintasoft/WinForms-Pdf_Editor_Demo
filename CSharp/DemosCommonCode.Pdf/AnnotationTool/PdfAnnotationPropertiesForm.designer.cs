namespace DemosCommonCode.Pdf
{
    partial class PdfAnnotationPropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfAnnotationPropertiesForm));
            this.closeButton = new System.Windows.Forms.Button();
            this.advancedTabControl = new System.Windows.Forms.TabControl();
            this.fieldTabPage = new System.Windows.Forms.TabPage();
            this.fieldPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.fieldFontButton = new System.Windows.Forms.Button();
            this.fieldTabControl = new System.Windows.Forms.TabControl();
            this.fieldPropertiesTabPage = new System.Windows.Forms.TabPage();
            this.fieldPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.fieldTriggersTtabPage = new System.Windows.Forms.TabPage();
            this.fieldTriggersEditorControl = new DemosCommonCode.Pdf.PdfTriggersEditorControl();
            this.annotationTabPage = new System.Windows.Forms.TabPage();
            this.annotationPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.annotationFontButton = new System.Windows.Forms.Button();
            this.annotationTabControl = new System.Windows.Forms.TabControl();
            this.annotationPropertiesTabPage = new System.Windows.Forms.TabPage();
            this.annotationPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.annotationsTriggersTabPage = new System.Windows.Forms.TabPage();
            this.annotationTriggersEditorControl = new DemosCommonCode.Pdf.PdfTriggersEditorControl();
            this.appearanceGeneratorTabPage = new System.Windows.Forms.TabPage();
            this.appearanceGeneratorGroupBox = new System.Windows.Forms.GroupBox();
            this.appearanceGeneratorFontButton = new System.Windows.Forms.Button();
            this.appearanceGeneratorPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.customPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.commonPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.updateAnnotationAppearanceCheckBox = new System.Windows.Forms.CheckBox();
            this.refreshAnnotationCheckBox = new System.Windows.Forms.CheckBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.propertiesTabPage = new System.Windows.Forms.TabPage();
            this.advancedTabPage = new System.Windows.Forms.TabPage();
            this.advancedTabControl.SuspendLayout();
            this.fieldTabPage.SuspendLayout();
            this.fieldPropertiesGroupBox.SuspendLayout();
            this.fieldTabControl.SuspendLayout();
            this.fieldPropertiesTabPage.SuspendLayout();
            this.fieldTriggersTtabPage.SuspendLayout();
            this.annotationTabPage.SuspendLayout();
            this.annotationPropertiesGroupBox.SuspendLayout();
            this.annotationTabControl.SuspendLayout();
            this.annotationPropertiesTabPage.SuspendLayout();
            this.annotationsTriggersTabPage.SuspendLayout();
            this.appearanceGeneratorTabPage.SuspendLayout();
            this.appearanceGeneratorGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.propertiesTabPage.SuspendLayout();
            this.advancedTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(407, 721);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // advancedTabControl
            // 
            this.advancedTabControl.Controls.Add(this.fieldTabPage);
            this.advancedTabControl.Controls.Add(this.annotationTabPage);
            this.advancedTabControl.Controls.Add(this.appearanceGeneratorTabPage);
            this.advancedTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedTabControl.Location = new System.Drawing.Point(3, 3);
            this.advancedTabControl.Name = "advancedTabControl";
            this.advancedTabControl.SelectedIndex = 0;
            this.advancedTabControl.Size = new System.Drawing.Size(436, 558);
            this.advancedTabControl.TabIndex = 1;
            this.advancedTabControl.SelectedIndexChanged += new System.EventHandler(this.advancedTabControl_SelectedIndexChanged);
            // 
            // fieldTabPage
            // 
            this.fieldTabPage.Controls.Add(this.fieldPropertiesGroupBox);
            this.fieldTabPage.Location = new System.Drawing.Point(4, 22);
            this.fieldTabPage.Name = "fieldTabPage";
            this.fieldTabPage.Size = new System.Drawing.Size(428, 532);
            this.fieldTabPage.TabIndex = 4;
            resources.ApplyResources(this.fieldTabPage, "fieldTabPage");
            this.fieldTabPage.UseVisualStyleBackColor = true;
            // 
            // fieldPropertiesGroupBox
            // 
            this.fieldPropertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldPropertiesGroupBox.Controls.Add(this.fieldFontButton);
            this.fieldPropertiesGroupBox.Controls.Add(this.fieldTabControl);
            this.fieldPropertiesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.fieldPropertiesGroupBox.Name = "fieldPropertiesGroupBox";
            this.fieldPropertiesGroupBox.Size = new System.Drawing.Size(422, 526);
            this.fieldPropertiesGroupBox.TabIndex = 2;
            this.fieldPropertiesGroupBox.TabStop = false;
            // 
            // fieldFontButton
            // 
            this.fieldFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fieldFontButton.AutoSize = true;
            this.fieldFontButton.Location = new System.Drawing.Point(3, 497);
            this.fieldFontButton.Name = "fieldFontButton";
            this.fieldFontButton.Size = new System.Drawing.Size(75, 23);
            this.fieldFontButton.TabIndex = 6;
            resources.ApplyResources(this.fieldFontButton, "fieldFontButton");
            this.fieldFontButton.UseVisualStyleBackColor = true;
            this.fieldFontButton.Click += new System.EventHandler(this.fieldFontButton_Click);
            // 
            // fieldTabControl
            // 
            this.fieldTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldTabControl.Controls.Add(this.fieldPropertiesTabPage);
            this.fieldTabControl.Controls.Add(this.fieldTriggersTtabPage);
            this.fieldTabControl.Location = new System.Drawing.Point(3, 16);
            this.fieldTabControl.Name = "fieldTabControl";
            this.fieldTabControl.SelectedIndex = 0;
            this.fieldTabControl.Size = new System.Drawing.Size(416, 475);
            this.fieldTabControl.TabIndex = 3;
            this.fieldTabControl.SelectedIndexChanged += new System.EventHandler(this.fieldTabControl_SelectedIndexChanged);
            // 
            // fieldPropertiesTabPage
            // 
            this.fieldPropertiesTabPage.Controls.Add(this.fieldPropertyGrid);
            this.fieldPropertiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.fieldPropertiesTabPage.Name = "fieldPropertiesTabPage";
            this.fieldPropertiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.fieldPropertiesTabPage.Size = new System.Drawing.Size(408, 449);
            this.fieldPropertiesTabPage.TabIndex = 0;
            resources.ApplyResources(this.fieldPropertiesTabPage, "fieldPropertiesTabPage");
            this.fieldPropertiesTabPage.UseVisualStyleBackColor = true;
            // 
            // fieldPropertyGrid
            // 
            this.fieldPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.fieldPropertyGrid.Name = "fieldPropertyGrid";
            this.fieldPropertyGrid.Size = new System.Drawing.Size(402, 443);
            this.fieldPropertyGrid.TabIndex = 1;
            this.fieldPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.fieldPropertyGrid_PropertyValueChanged);
            // 
            // fieldTriggersTtabPage
            // 
            this.fieldTriggersTtabPage.Controls.Add(this.fieldTriggersEditorControl);
            this.fieldTriggersTtabPage.Location = new System.Drawing.Point(4, 22);
            this.fieldTriggersTtabPage.Name = "fieldTriggersTtabPage";
            this.fieldTriggersTtabPage.Padding = new System.Windows.Forms.Padding(3);
            this.fieldTriggersTtabPage.Size = new System.Drawing.Size(408, 449);
            this.fieldTriggersTtabPage.TabIndex = 1;
            resources.ApplyResources(this.fieldTriggersTtabPage, "fieldTriggersTtabPage");
            this.fieldTriggersTtabPage.UseVisualStyleBackColor = true;
            // 
            // fieldTriggersEditorControl
            // 
            this.fieldTriggersEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldTriggersEditorControl.Location = new System.Drawing.Point(3, 3);
            this.fieldTriggersEditorControl.MinimumSize = new System.Drawing.Size(200, 275);
            this.fieldTriggersEditorControl.Name = "fieldTriggersEditorControl";
            this.fieldTriggersEditorControl.Size = new System.Drawing.Size(402, 443);
            this.fieldTriggersEditorControl.TabIndex = 0;
            this.fieldTriggersEditorControl.TreeNode = null;
            // 
            // annotationTabPage
            // 
            this.annotationTabPage.Controls.Add(this.annotationPropertiesGroupBox);
            this.annotationTabPage.Location = new System.Drawing.Point(4, 22);
            this.annotationTabPage.Name = "annotationTabPage";
            this.annotationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.annotationTabPage.Size = new System.Drawing.Size(428, 532);
            this.annotationTabPage.TabIndex = 0;
            resources.ApplyResources(this.annotationTabPage, "annotationTabPage");
            this.annotationTabPage.UseVisualStyleBackColor = true;
            // 
            // annotationPropertiesGroupBox
            // 
            this.annotationPropertiesGroupBox.Controls.Add(this.annotationFontButton);
            this.annotationPropertiesGroupBox.Controls.Add(this.annotationTabControl);
            this.annotationPropertiesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annotationPropertiesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.annotationPropertiesGroupBox.Name = "annotationPropertiesGroupBox";
            this.annotationPropertiesGroupBox.Size = new System.Drawing.Size(422, 526);
            this.annotationPropertiesGroupBox.TabIndex = 1;
            this.annotationPropertiesGroupBox.TabStop = false;
            // 
            // annotationFontButton
            // 
            this.annotationFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.annotationFontButton.AutoSize = true;
            this.annotationFontButton.Location = new System.Drawing.Point(3, 497);
            this.annotationFontButton.Name = "annotationFontButton";
            this.annotationFontButton.Size = new System.Drawing.Size(75, 23);
            this.annotationFontButton.TabIndex = 5;
            resources.ApplyResources(this.annotationFontButton, "annotationFontButton");
            this.annotationFontButton.UseVisualStyleBackColor = true;
            this.annotationFontButton.Click += new System.EventHandler(this.annotationFontButton_Click);
            // 
            // annotationTabControl
            // 
            this.annotationTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.annotationTabControl.Controls.Add(this.annotationPropertiesTabPage);
            this.annotationTabControl.Controls.Add(this.annotationsTriggersTabPage);
            this.annotationTabControl.Location = new System.Drawing.Point(3, 16);
            this.annotationTabControl.Name = "annotationTabControl";
            this.annotationTabControl.SelectedIndex = 0;
            this.annotationTabControl.Size = new System.Drawing.Size(416, 475);
            this.annotationTabControl.TabIndex = 4;
            this.annotationTabControl.SelectedIndexChanged += new System.EventHandler(this.annotationTabControl_SelectedIndexChanged);
            // 
            // annotationPropertiesTabPage
            // 
            this.annotationPropertiesTabPage.Controls.Add(this.annotationPropertyGrid);
            this.annotationPropertiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.annotationPropertiesTabPage.Name = "annotationPropertiesTabPage";
            this.annotationPropertiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.annotationPropertiesTabPage.Size = new System.Drawing.Size(408, 449);
            this.annotationPropertiesTabPage.TabIndex = 0;
            resources.ApplyResources(this.annotationPropertiesTabPage, "annotationPropertiesTabPage");
            this.annotationPropertiesTabPage.UseVisualStyleBackColor = true;
            // 
            // annotationPropertyGrid
            // 
            this.annotationPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annotationPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.annotationPropertyGrid.Name = "annotationPropertyGrid";
            this.annotationPropertyGrid.Size = new System.Drawing.Size(402, 443);
            this.annotationPropertyGrid.TabIndex = 1;
            this.annotationPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.annotationPropertyGrid_PropertyValueChanged);
            // 
            // annotationsTriggersTabPage
            // 
            this.annotationsTriggersTabPage.Controls.Add(this.annotationTriggersEditorControl);
            this.annotationsTriggersTabPage.Location = new System.Drawing.Point(4, 22);
            this.annotationsTriggersTabPage.Name = "annotationsTriggersTabPage";
            this.annotationsTriggersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.annotationsTriggersTabPage.Size = new System.Drawing.Size(408, 449);
            this.annotationsTriggersTabPage.TabIndex = 1;
            resources.ApplyResources(this.annotationsTriggersTabPage, "annotationsTriggersTabPage");
            this.annotationsTriggersTabPage.UseVisualStyleBackColor = true;
            // 
            // annotationTriggersEditorControl
            // 
            this.annotationTriggersEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annotationTriggersEditorControl.Location = new System.Drawing.Point(3, 3);
            this.annotationTriggersEditorControl.MinimumSize = new System.Drawing.Size(200, 275);
            this.annotationTriggersEditorControl.Name = "annotationTriggersEditorControl";
            this.annotationTriggersEditorControl.Size = new System.Drawing.Size(402, 443);
            this.annotationTriggersEditorControl.TabIndex = 0;
            this.annotationTriggersEditorControl.TreeNode = null;
            // 
            // appearanceGeneratorTabPage
            // 
            this.appearanceGeneratorTabPage.Controls.Add(this.appearanceGeneratorGroupBox);
            this.appearanceGeneratorTabPage.Location = new System.Drawing.Point(4, 22);
            this.appearanceGeneratorTabPage.Name = "appearanceGeneratorTabPage";
            this.appearanceGeneratorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.appearanceGeneratorTabPage.Size = new System.Drawing.Size(428, 532);
            this.appearanceGeneratorTabPage.TabIndex = 1;
            resources.ApplyResources(this.appearanceGeneratorTabPage, "appearanceGeneratorTabPage");
            this.appearanceGeneratorTabPage.UseVisualStyleBackColor = true;
            // 
            // appearanceGeneratorGroupBox
            // 
            this.appearanceGeneratorGroupBox.Controls.Add(this.appearanceGeneratorFontButton);
            this.appearanceGeneratorGroupBox.Controls.Add(this.appearanceGeneratorPropertyGrid);
            this.appearanceGeneratorGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appearanceGeneratorGroupBox.Location = new System.Drawing.Point(3, 3);
            this.appearanceGeneratorGroupBox.Name = "appearanceGeneratorGroupBox";
            this.appearanceGeneratorGroupBox.Size = new System.Drawing.Size(422, 526);
            this.appearanceGeneratorGroupBox.TabIndex = 2;
            this.appearanceGeneratorGroupBox.TabStop = false;
            this.appearanceGeneratorGroupBox.Text = "<TEXT>";
            // 
            // appearanceGeneratorFontButton
            // 
            this.appearanceGeneratorFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.appearanceGeneratorFontButton.AutoSize = true;
            this.appearanceGeneratorFontButton.Location = new System.Drawing.Point(3, 497);
            this.appearanceGeneratorFontButton.Name = "appearanceGeneratorFontButton";
            this.appearanceGeneratorFontButton.Size = new System.Drawing.Size(75, 23);
            this.appearanceGeneratorFontButton.TabIndex = 3;
            resources.ApplyResources(this.appearanceGeneratorFontButton, "appearanceGeneratorFontButton");
            this.appearanceGeneratorFontButton.UseVisualStyleBackColor = true;
            this.appearanceGeneratorFontButton.Click += new System.EventHandler(this.setFontButton_Click);
            // 
            // appearanceGeneratorPropertyGrid
            // 
            this.appearanceGeneratorPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appearanceGeneratorPropertyGrid.Location = new System.Drawing.Point(3, 16);
            this.appearanceGeneratorPropertyGrid.Name = "appearanceGeneratorPropertyGrid";
            this.appearanceGeneratorPropertyGrid.Size = new System.Drawing.Size(416, 471);
            this.appearanceGeneratorPropertyGrid.TabIndex = 1;
            this.appearanceGeneratorPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.appearanceGeneratorPropertyGrid_PropertyValueChanged);
            // 
            // customPropertiesGroupBox
            // 
            this.customPropertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPropertiesGroupBox.Location = new System.Drawing.Point(6, 285);
            this.customPropertiesGroupBox.Name = "customPropertiesGroupBox";
            this.customPropertiesGroupBox.Size = new System.Drawing.Size(469, 348);
            this.customPropertiesGroupBox.TabIndex = 1;
            this.customPropertiesGroupBox.TabStop = false;
            // 
            // commonPropertiesGroupBox
            // 
            this.commonPropertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commonPropertiesGroupBox.Location = new System.Drawing.Point(6, 6);
            this.commonPropertiesGroupBox.Name = "commonPropertiesGroupBox";
            this.commonPropertiesGroupBox.Size = new System.Drawing.Size(469, 273);
            this.commonPropertiesGroupBox.TabIndex = 0;
            this.commonPropertiesGroupBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(1, 665);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 42);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.updateAnnotationAppearanceCheckBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.refreshAnnotationCheckBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(479, 23);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // updateAnnotationAppearanceCheckBox
            // 
            this.updateAnnotationAppearanceCheckBox.AutoSize = true;
            this.updateAnnotationAppearanceCheckBox.Checked = true;
            this.updateAnnotationAppearanceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.updateAnnotationAppearanceCheckBox.Location = new System.Drawing.Point(126, 3);
            this.updateAnnotationAppearanceCheckBox.Name = "updateAnnotationAppearanceCheckBox";
            this.updateAnnotationAppearanceCheckBox.Size = new System.Drawing.Size(176, 17);
            this.updateAnnotationAppearanceCheckBox.TabIndex = 8;
            resources.ApplyResources(this.updateAnnotationAppearanceCheckBox, "updateAnnotationAppearanceCheckBox");
            this.updateAnnotationAppearanceCheckBox.UseVisualStyleBackColor = true;
            // 
            // refreshAnnotationCheckBox
            // 
            this.refreshAnnotationCheckBox.AutoSize = true;
            this.refreshAnnotationCheckBox.Checked = true;
            this.refreshAnnotationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.refreshAnnotationCheckBox.Location = new System.Drawing.Point(3, 3);
            this.refreshAnnotationCheckBox.Name = "refreshAnnotationCheckBox";
            this.refreshAnnotationCheckBox.Size = new System.Drawing.Size(117, 17);
            this.refreshAnnotationCheckBox.TabIndex = 7;
            resources.ApplyResources(this.refreshAnnotationCheckBox, "refreshAnnotationCheckBox");
            this.refreshAnnotationCheckBox.UseVisualStyleBackColor = true;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.propertiesTabPage);
            this.mainTabControl.Controls.Add(this.advancedTabPage);
            this.mainTabControl.Location = new System.Drawing.Point(1, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(489, 659);
            this.mainTabControl.TabIndex = 10;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // propertiesTabPage
            // 
            this.propertiesTabPage.Controls.Add(this.customPropertiesGroupBox);
            this.propertiesTabPage.Controls.Add(this.commonPropertiesGroupBox);
            this.propertiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.propertiesTabPage.Name = "propertiesTabPage";
            this.propertiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.propertiesTabPage.Size = new System.Drawing.Size(481, 633);
            this.propertiesTabPage.TabIndex = 0;
            resources.ApplyResources(this.propertiesTabPage, "propertiesTabPage");
            this.propertiesTabPage.UseVisualStyleBackColor = true;
            // 
            // advancedTabPage
            // 
            this.advancedTabPage.Controls.Add(this.advancedTabControl);
            this.advancedTabPage.Location = new System.Drawing.Point(4, 22);
            this.advancedTabPage.Name = "advancedTabPage";
            this.advancedTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.advancedTabPage.Size = new System.Drawing.Size(442, 564);
            this.advancedTabPage.TabIndex = 1;
            resources.ApplyResources(this.advancedTabPage, "advancedTabPage");
            this.advancedTabPage.UseVisualStyleBackColor = true;
            // 
            // PdfAnnotationPropertiesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 753);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.closeButton);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(467, 712);
            this.Name = "PdfAnnotationPropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            resources.ApplyResources(this, "$this");
            this.advancedTabControl.ResumeLayout(false);
            this.fieldTabPage.ResumeLayout(false);
            this.fieldPropertiesGroupBox.ResumeLayout(false);
            this.fieldPropertiesGroupBox.PerformLayout();
            this.fieldTabControl.ResumeLayout(false);
            this.fieldPropertiesTabPage.ResumeLayout(false);
            this.fieldTriggersTtabPage.ResumeLayout(false);
            this.annotationTabPage.ResumeLayout(false);
            this.annotationPropertiesGroupBox.ResumeLayout(false);
            this.annotationPropertiesGroupBox.PerformLayout();
            this.annotationTabControl.ResumeLayout(false);
            this.annotationPropertiesTabPage.ResumeLayout(false);
            this.annotationsTriggersTabPage.ResumeLayout(false);
            this.appearanceGeneratorTabPage.ResumeLayout(false);
            this.appearanceGeneratorGroupBox.ResumeLayout(false);
            this.appearanceGeneratorGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.propertiesTabPage.ResumeLayout(false);
            this.advancedTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TabControl advancedTabControl;
        private System.Windows.Forms.TabPage appearanceGeneratorTabPage;
        private System.Windows.Forms.TabPage annotationTabPage;
        private System.Windows.Forms.TabPage fieldTabPage;
        private System.Windows.Forms.PropertyGrid fieldPropertyGrid;
        private System.Windows.Forms.PropertyGrid appearanceGeneratorPropertyGrid;
        private System.Windows.Forms.GroupBox fieldPropertiesGroupBox;
        private System.Windows.Forms.GroupBox annotationPropertiesGroupBox;
        private System.Windows.Forms.TabControl fieldTabControl;
        private System.Windows.Forms.TabPage fieldPropertiesTabPage;
        private System.Windows.Forms.TabPage fieldTriggersTtabPage;
        private System.Windows.Forms.TabControl annotationTabControl;
        private System.Windows.Forms.TabPage annotationPropertiesTabPage;
        private System.Windows.Forms.PropertyGrid annotationPropertyGrid;
        private System.Windows.Forms.TabPage annotationsTriggersTabPage;
        private System.Windows.Forms.GroupBox appearanceGeneratorGroupBox;
        private PdfTriggersEditorControl fieldTriggersEditorControl;
        private PdfTriggersEditorControl annotationTriggersEditorControl;
        private System.Windows.Forms.Button appearanceGeneratorFontButton;
        private System.Windows.Forms.Button annotationFontButton;
        private System.Windows.Forms.Button fieldFontButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox updateAnnotationAppearanceCheckBox;
        private System.Windows.Forms.CheckBox refreshAnnotationCheckBox;
        private System.Windows.Forms.GroupBox customPropertiesGroupBox;
        private System.Windows.Forms.GroupBox commonPropertiesGroupBox;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage propertiesTabPage;
        private System.Windows.Forms.TabPage advancedTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}