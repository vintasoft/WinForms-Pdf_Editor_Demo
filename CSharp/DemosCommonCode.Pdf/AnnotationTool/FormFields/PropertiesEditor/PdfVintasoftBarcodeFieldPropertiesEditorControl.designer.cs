namespace DemosCommonCode.Pdf
{
    partial class PdfVintasoftBarcodeFieldPropertiesEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfVintasoftBarcodeFieldPropertiesEditorControl));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.valueTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.paddingPanelControl1 = new DemosCommonCode.CustomControls.PaddingFEditorControl();
            this.fitBarcodeToAppearanceRectCheckBox = new System.Windows.Forms.CheckBox();
            this.foregroundColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.label7 = new System.Windows.Forms.Label();
            this.moduleWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.moduleWidthLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.defaultValueTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.errorCorrectionCoefficientComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.barcodeSymbologyComboBox = new System.Windows.Forms.ComboBox();
            this.dataPreparationStepsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.calculateTabPage = new System.Windows.Forms.TabPage();
            this.calculateActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainTabControl.SuspendLayout();
            this.valueTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moduleWidthNumericUpDown)).BeginInit();
            this.calculateTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.valueTabPage);
            this.mainTabControl.Controls.Add(this.calculateTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(429, 267);
            this.mainTabControl.TabIndex = 9;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // valueTabPage
            // 
            this.valueTabPage.Controls.Add(this.tableLayoutPanel1);
            this.valueTabPage.Location = new System.Drawing.Point(4, 22);
            this.valueTabPage.Name = "valueTabPage";
            this.valueTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.valueTabPage.Size = new System.Drawing.Size(421, 241);
            this.valueTabPage.TabIndex = 0;
            resources.ApplyResources(this.valueTabPage, "valueTabPage");
            this.valueTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.paddingPanelControl1);
            this.groupBox1.Location = new System.Drawing.Point(274, 136);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 4);
            this.groupBox1.Size = new System.Drawing.Size(138, 96);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // paddingPanelControl1
            // 
            this.paddingPanelControl1.Location = new System.Drawing.Point(7, 15);
            this.paddingPanelControl1.MaximumSize = new System.Drawing.Size(128, 75);
            this.paddingPanelControl1.MinimumSize = new System.Drawing.Size(128, 75);
            this.paddingPanelControl1.Name = "paddingPanelControl1";
            this.paddingPanelControl1.PaddingValue = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            this.paddingPanelControl1.Size = new System.Drawing.Size(128, 75);
            this.paddingPanelControl1.TabIndex = 0;
            this.paddingPanelControl1.PaddingValueChanged += new System.EventHandler(this.paddingPanelControl1_PaddingValueChanged);
            // 
            // fitBarcodeToAppearanceRectCheckBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.fitBarcodeToAppearanceRectCheckBox, 2);
            this.fitBarcodeToAppearanceRectCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fitBarcodeToAppearanceRectCheckBox.Location = new System.Drawing.Point(3, 162);
            this.fitBarcodeToAppearanceRectCheckBox.Name = "fitBarcodeToAppearanceRectCheckBox";
            this.fitBarcodeToAppearanceRectCheckBox.Size = new System.Drawing.Size(265, 17);
            this.fitBarcodeToAppearanceRectCheckBox.TabIndex = 20;
            resources.ApplyResources(this.fitBarcodeToAppearanceRectCheckBox, "fitBarcodeToAppearanceRectCheckBox");
            this.fitBarcodeToAppearanceRectCheckBox.UseVisualStyleBackColor = true;
            this.fitBarcodeToAppearanceRectCheckBox.CheckedChanged += new System.EventHandler(this.fitBarcodeToAppearanceRectCheckBox_CheckedChanged);
            // 
            // foregroundColorPanelControl
            // 
            this.foregroundColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.foregroundColorPanelControl.CanEditAlphaChannel = false;
            this.foregroundColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.foregroundColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.foregroundColorPanelControl.Location = new System.Drawing.Point(142, 185);
            this.foregroundColorPanelControl.Name = "foregroundColorPanelControl";
            this.foregroundColorPanelControl.Size = new System.Drawing.Size(126, 21);
            this.foregroundColorPanelControl.TabIndex = 17;
            this.foregroundColorPanelControl.ColorChanged += new System.EventHandler(this.foregroundColorPanelControl_ColorChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 16;
            resources.ApplyResources(this.label7, "label7");
            // 
            // moduleWidthNumericUpDown
            // 
            this.moduleWidthNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.moduleWidthNumericUpDown.Location = new System.Drawing.Point(142, 136);
            this.moduleWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moduleWidthNumericUpDown.Name = "moduleWidthNumericUpDown";
            this.moduleWidthNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.moduleWidthNumericUpDown.TabIndex = 15;
            this.moduleWidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moduleWidthNumericUpDown.ValueChanged += new System.EventHandler(this.moduleWidthNumericUpDown_ValueChanged);
            // 
            // moduleWidthLabel
            // 
            this.moduleWidthLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.moduleWidthLabel.AutoSize = true;
            this.moduleWidthLabel.Location = new System.Drawing.Point(3, 139);
            this.moduleWidthLabel.Name = "moduleWidthLabel";
            this.moduleWidthLabel.Size = new System.Drawing.Size(73, 13);
            this.moduleWidthLabel.TabIndex = 14;
            resources.ApplyResources(this.moduleWidthLabel, "moduleWidthLabel");
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            resources.ApplyResources(this.label2, "label2");
            // 
            // defaultValueTextBox
            // 
            this.defaultValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.defaultValueTextBox, 2);
            this.defaultValueTextBox.Location = new System.Drawing.Point(142, 29);
            this.defaultValueTextBox.Name = "defaultValueTextBox";
            this.defaultValueTextBox.Size = new System.Drawing.Size(270, 20);
            this.defaultValueTextBox.TabIndex = 13;
            this.defaultValueTextBox.TextChanged += new System.EventHandler(this.defaultValueTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 11;
            resources.ApplyResources(this.label3, "label3");
            // 
            // valueTextBox
            // 
            this.valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.valueTextBox, 2);
            this.valueTextBox.Location = new System.Drawing.Point(142, 3);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(270, 20);
            this.valueTextBox.TabIndex = 12;
            this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
            // 
            // errorCorrectionCoefficientComboBox
            // 
            this.errorCorrectionCoefficientComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.errorCorrectionCoefficientComboBox, 2);
            this.errorCorrectionCoefficientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.errorCorrectionCoefficientComboBox.Enabled = false;
            this.errorCorrectionCoefficientComboBox.FormattingEnabled = true;
            this.errorCorrectionCoefficientComboBox.Location = new System.Drawing.Point(142, 82);
            this.errorCorrectionCoefficientComboBox.Name = "errorCorrectionCoefficientComboBox";
            this.errorCorrectionCoefficientComboBox.Size = new System.Drawing.Size(270, 21);
            this.errorCorrectionCoefficientComboBox.TabIndex = 9;
            this.errorCorrectionCoefficientComboBox.SelectedIndexChanged += new System.EventHandler(this.errorCorrectionCoefficientComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 8;
            resources.ApplyResources(this.label5, "label5");
            // 
            // barcodeSymbologyComboBox
            // 
            this.barcodeSymbologyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.barcodeSymbologyComboBox, 2);
            this.barcodeSymbologyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.barcodeSymbologyComboBox.FormattingEnabled = true;
            this.barcodeSymbologyComboBox.Location = new System.Drawing.Point(142, 55);
            this.barcodeSymbologyComboBox.Name = "barcodeSymbologyComboBox";
            this.barcodeSymbologyComboBox.Size = new System.Drawing.Size(270, 21);
            this.barcodeSymbologyComboBox.Sorted = true;
            this.barcodeSymbologyComboBox.TabIndex = 0;
            this.barcodeSymbologyComboBox.SelectedIndexChanged += new System.EventHandler(this.barcodeSymbologyComboBox_SelectedIndexChanged);
            // 
            // dataPreparationStepsComboBox
            // 
            this.dataPreparationStepsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.dataPreparationStepsComboBox, 2);
            this.dataPreparationStepsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataPreparationStepsComboBox.FormattingEnabled = true;
            this.dataPreparationStepsComboBox.Location = new System.Drawing.Point(142, 109);
            this.dataPreparationStepsComboBox.Name = "dataPreparationStepsComboBox";
            this.dataPreparationStepsComboBox.Size = new System.Drawing.Size(270, 21);
            this.dataPreparationStepsComboBox.TabIndex = 7;
            this.dataPreparationStepsComboBox.SelectedIndexChanged += new System.EventHandler(this.dataPreparationStepsComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            resources.ApplyResources(this.label1, "label1");
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 6;
            resources.ApplyResources(this.label4, "label4");
            // 
            // calculateTabPage
            // 
            this.calculateTabPage.Controls.Add(this.calculateActionEditorControl);
            this.calculateTabPage.Location = new System.Drawing.Point(4, 22);
            this.calculateTabPage.Name = "calculateTabPage";
            this.calculateTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.calculateTabPage.Size = new System.Drawing.Size(421, 241);
            this.calculateTabPage.TabIndex = 1;
            resources.ApplyResources(this.calculateTabPage, "calculateTabPage");
            this.calculateTabPage.UseVisualStyleBackColor = true;
            // 
            // calculateActionEditorControl
            // 
            this.calculateActionEditorControl.Action = null;
            this.calculateActionEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calculateActionEditorControl.Document = null;
            this.calculateActionEditorControl.ImageCollection = null;
            this.calculateActionEditorControl.Location = new System.Drawing.Point(3, 3);
            this.calculateActionEditorControl.MinimumSize = new System.Drawing.Size(165, 138);
            this.calculateActionEditorControl.Name = "calculateActionEditorControl";
            this.calculateActionEditorControl.Size = new System.Drawing.Size(415, 235);
            this.calculateActionEditorControl.TabIndex = 0;
            this.calculateActionEditorControl.ActionChanged += new System.EventHandler(this.calculateActionEditorControl_ActionChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.foregroundColorPanelControl, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.fitBarcodeToAppearanceRectCheckBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.valueTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.defaultValueTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.moduleWidthLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.moduleWidthNumericUpDown, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.barcodeSymbologyComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataPreparationStepsComboBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.errorCorrectionCoefficientComboBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(415, 235);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // PdfVintasoftBarcodeFieldPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTabControl);
            this.MinimumSize = new System.Drawing.Size(250, 175);
            this.Name = "PdfVintasoftBarcodeFieldPropertiesEditorControl";
            this.Size = new System.Drawing.Size(429, 267);
            this.mainTabControl.ResumeLayout(false);
            this.valueTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moduleWidthNumericUpDown)).EndInit();
            this.calculateTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage valueTabPage;
        private System.Windows.Forms.NumericUpDown moduleWidthNumericUpDown;
        private System.Windows.Forms.Label moduleWidthLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox defaultValueTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.ComboBox errorCorrectionCoefficientComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox barcodeSymbologyComboBox;
        private System.Windows.Forms.ComboBox dataPreparationStepsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage calculateTabPage;
        private PdfActionEditorControl calculateActionEditorControl;
        private DemosCommonCode.CustomControls.ColorPanelControl foregroundColorPanelControl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox fitBarcodeToAppearanceRectCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private DemosCommonCode.CustomControls.PaddingFEditorControl paddingPanelControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}