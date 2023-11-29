namespace DemosCommonCode.Pdf
{
    partial class PdfBarcodeFieldPropertiesEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfBarcodeFieldPropertiesEditorControl));
            this.barcodeSymbologyComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataPreparationStepsComboBox = new System.Windows.Forms.ComboBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.valueTabPage = new System.Windows.Forms.TabPage();
            this.moduleWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.defaultValueTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.errorCorrectionCoefficientComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.calculateTabPage = new System.Windows.Forms.TabPage();
            this.calculateActionEditorControl = new DemosCommonCode.Pdf.PdfActionEditorControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainTabControl.SuspendLayout();
            this.valueTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moduleWidthNumericUpDown)).BeginInit();
            this.calculateTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barcodeSymbologyComboBox
            // 
            this.barcodeSymbologyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.barcodeSymbologyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.barcodeSymbologyComboBox.FormattingEnabled = true;
            this.barcodeSymbologyComboBox.Location = new System.Drawing.Point(142, 55);
            this.barcodeSymbologyComboBox.Name = "barcodeSymbologyComboBox";
            this.barcodeSymbologyComboBox.Size = new System.Drawing.Size(270, 21);
            this.barcodeSymbologyComboBox.TabIndex = 0;
            this.barcodeSymbologyComboBox.SelectedIndexChanged += new System.EventHandler(this.barcodeSymbologyComboBox_SelectedIndexChanged);
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
            // dataPreparationStepsComboBox
            // 
            this.dataPreparationStepsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPreparationStepsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataPreparationStepsComboBox.FormattingEnabled = true;
            this.dataPreparationStepsComboBox.Location = new System.Drawing.Point(142, 109);
            this.dataPreparationStepsComboBox.Name = "dataPreparationStepsComboBox";
            this.dataPreparationStepsComboBox.Size = new System.Drawing.Size(270, 21);
            this.dataPreparationStepsComboBox.TabIndex = 7;
            this.dataPreparationStepsComboBox.SelectedIndexChanged += new System.EventHandler(this.dataPreparationStepsComboBox_SelectedIndexChanged);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.valueTabPage);
            this.mainTabControl.Controls.Add(this.calculateTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(429, 230);
            this.mainTabControl.TabIndex = 8;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // valueTabPage
            // 
            this.valueTabPage.Controls.Add(this.tableLayoutPanel1);
            this.valueTabPage.Location = new System.Drawing.Point(4, 22);
            this.valueTabPage.Name = "valueTabPage";
            this.valueTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.valueTabPage.Size = new System.Drawing.Size(421, 204);
            this.valueTabPage.TabIndex = 0;
            resources.ApplyResources(this.valueTabPage, "valueTabPage");
            this.valueTabPage.UseVisualStyleBackColor = true;
            // 
            // moduleWidthNumericUpDown
            // 
            this.moduleWidthNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.moduleWidthNumericUpDown.DecimalPlaces = 2;
            this.moduleWidthNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moduleWidthNumericUpDown.Location = new System.Drawing.Point(142, 136);
            this.moduleWidthNumericUpDown.Name = "moduleWidthNumericUpDown";
            this.moduleWidthNumericUpDown.Size = new System.Drawing.Size(270, 20);
            this.moduleWidthNumericUpDown.TabIndex = 15;
            this.moduleWidthNumericUpDown.ValueChanged += new System.EventHandler(this.moduleWidthNumericUpDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 14;
            resources.ApplyResources(this.label6, "label6");
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
            this.valueTextBox.Location = new System.Drawing.Point(142, 3);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(270, 20);
            this.valueTextBox.TabIndex = 12;
            this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
            // 
            // errorCorrectionCoefficientComboBox
            // 
            this.errorCorrectionCoefficientComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
            // calculateTabPage
            // 
            this.calculateTabPage.Controls.Add(this.calculateActionEditorControl);
            this.calculateTabPage.Location = new System.Drawing.Point(4, 22);
            this.calculateTabPage.Name = "calculateTabPage";
            this.calculateTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.calculateTabPage.Size = new System.Drawing.Size(421, 204);
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
            this.calculateActionEditorControl.Size = new System.Drawing.Size(415, 198);
            this.calculateActionEditorControl.TabIndex = 0;
            this.calculateActionEditorControl.ActionChanged += new System.EventHandler(this.calculateActionEditorControl_ActionChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.moduleWidthNumericUpDown, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.valueTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataPreparationStepsComboBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.errorCorrectionCoefficientComboBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.defaultValueTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.barcodeSymbologyComboBox, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(415, 198);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // PdfBarcodeFieldPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTabControl);
            this.MinimumSize = new System.Drawing.Size(250, 175);
            this.Name = "PdfBarcodeFieldPropertiesEditorControl";
            this.Size = new System.Drawing.Size(429, 230);
            this.mainTabControl.ResumeLayout(false);
            this.valueTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moduleWidthNumericUpDown)).EndInit();
            this.calculateTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox barcodeSymbologyComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dataPreparationStepsComboBox;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage valueTabPage;
        private System.Windows.Forms.TabPage calculateTabPage;
        private PdfActionEditorControl calculateActionEditorControl;
        private System.Windows.Forms.ComboBox errorCorrectionCoefficientComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox defaultValueTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.NumericUpDown moduleWidthNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}