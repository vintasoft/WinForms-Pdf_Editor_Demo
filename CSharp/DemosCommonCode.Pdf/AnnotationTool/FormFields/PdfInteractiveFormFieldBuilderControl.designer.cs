namespace DemosCommonCode.Pdf
{
    partial class PdfInteractiveFormFieldBuilderControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfInteractiveFormFieldBuilderControl));
            this.textFieldToolStripSplitButton = new DemosCommonCode.CustomControls.CheckedToolStripSplitButton();
            this.textFieldNoBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFieldSingleBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textField3DBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.textFieldPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxToolStripSplitButton = new DemosCommonCode.CustomControls.CheckedToolStripSplitButton();
            this.checkBoxStandardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxSimpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxSymbolVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxSymbolXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonToolStripSplitButton = new DemosCommonCode.CustomControls.CheckedToolStripSplitButton();
            this.buttonFlatBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonBorder3DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxToolStripSplitButton = new DemosCommonCode.CustomControls.CheckedToolStripSplitButton();
            this.listBoxNoBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxToolStripSplitButton = new DemosCommonCode.CustomControls.CheckedToolStripSplitButton();
            this.comboBoxNoBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxSingleBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox3dBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButtonToolStripSplitButton = new DemosCommonCode.CustomControls.CheckedToolStripSplitButton();
            this.radioButtonStandardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButtonSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.barcodeToolStripSplitButton = new DemosCommonCode.CustomControls.CheckedToolStripSplitButton();
            this.barcodePdf417ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barcodeDataMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barcodeQrCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vintasoftBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.signatureToolStripSplitButton = new DemosCommonCode.CustomControls.CheckedToolStripSplitButton();
            this.signatureDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textFieldToolStripSplitButton
            // 
            this.textFieldToolStripSplitButton.Checked = false;
            this.textFieldToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textFieldNoBorderToolStripMenuItem,
            this.textFieldSingleBorderToolStripMenuItem,
            this.textField3DBorderToolStripMenuItem,
            this.toolStripSeparator1,
            this.textFieldPropertiesToolStripMenuItem});
            this.textFieldToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textFieldToolStripSplitButton.Name = "textFieldToolStripSplitButton";
            this.textFieldToolStripSplitButton.Size = new System.Drawing.Size(73, 19);
            this.textFieldToolStripSplitButton.Text = "Text Field";
            this.textFieldToolStripSplitButton.ButtonClick += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // textFieldNoBorderToolStripMenuItem
            // 
            this.textFieldNoBorderToolStripMenuItem.Name = "textFieldNoBorderToolStripMenuItem";
            this.textFieldNoBorderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.textFieldNoBorderToolStripMenuItem, "textFieldNoBorderToolStripMenuItem");
            this.textFieldNoBorderToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.textFieldNoBorderToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // textFieldSingleBorderToolStripMenuItem
            // 
            this.textFieldSingleBorderToolStripMenuItem.Name = "textFieldSingleBorderToolStripMenuItem";
            this.textFieldSingleBorderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.textFieldSingleBorderToolStripMenuItem, "textFieldSingleBorderToolStripMenuItem");
            this.textFieldSingleBorderToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.textFieldSingleBorderToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // textField3DBorderToolStripMenuItem
            // 
            this.textField3DBorderToolStripMenuItem.Name = "textField3DBorderToolStripMenuItem";
            this.textField3DBorderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.textField3DBorderToolStripMenuItem, "textField3DBorderToolStripMenuItem");
            this.textField3DBorderToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.textField3DBorderToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // textFieldPropertiesToolStripMenuItem
            // 
            this.textFieldPropertiesToolStripMenuItem.Name = "textFieldPropertiesToolStripMenuItem";
            this.textFieldPropertiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.textFieldPropertiesToolStripMenuItem, "textFieldPropertiesToolStripMenuItem");
            this.textFieldPropertiesToolStripMenuItem.Click += new System.EventHandler(this.fieldAppearanceGeneratorPropertiesToolStripMenuItem_Click);
            // 
            // checkBoxToolStripSplitButton
            // 
            this.checkBoxToolStripSplitButton.Checked = false;
            this.checkBoxToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkBoxStandardToolStripMenuItem,
            this.checkBoxSimpleToolStripMenuItem,
            this.checkBoxSymbolVToolStripMenuItem,
            this.checkBoxSymbolXToolStripMenuItem,
            this.toolStripSeparator2,
            this.propertiesToolStripMenuItem1});
            this.checkBoxToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxToolStripSplitButton.Name = "checkBoxToolStripSplitButton";
            this.checkBoxToolStripSplitButton.Size = new System.Drawing.Size(78, 19);
            this.checkBoxToolStripSplitButton.Text = "Check Box";
            this.checkBoxToolStripSplitButton.ButtonClick += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // checkBoxStandardToolStripMenuItem
            // 
            this.checkBoxStandardToolStripMenuItem.Name = "checkBoxStandardToolStripMenuItem";
            this.checkBoxStandardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.checkBoxStandardToolStripMenuItem, "checkBoxStandardToolStripMenuItem");
            this.checkBoxStandardToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.checkBoxStandardToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // checkBoxSimpleToolStripMenuItem
            // 
            this.checkBoxSimpleToolStripMenuItem.Name = "checkBoxSimpleToolStripMenuItem";
            this.checkBoxSimpleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.checkBoxSimpleToolStripMenuItem, "checkBoxSimpleToolStripMenuItem");
            this.checkBoxSimpleToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.checkBoxSimpleToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // checkBoxSymbolVToolStripMenuItem
            // 
            this.checkBoxSymbolVToolStripMenuItem.Name = "checkBoxSymbolVToolStripMenuItem";
            this.checkBoxSymbolVToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.checkBoxSymbolVToolStripMenuItem.Text = "Symbol \"V\"";
            this.checkBoxSymbolVToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.checkBoxSymbolVToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // checkBoxSymbolXToolStripMenuItem
            // 
            this.checkBoxSymbolXToolStripMenuItem.Name = "checkBoxSymbolXToolStripMenuItem";
            this.checkBoxSymbolXToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.checkBoxSymbolXToolStripMenuItem.Text = "Symbol \"X\"";
            this.checkBoxSymbolXToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.checkBoxSymbolXToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // propertiesToolStripMenuItem1
            // 
            this.propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.propertiesToolStripMenuItem1, "propertiesToolStripMenuItem1");
            this.propertiesToolStripMenuItem1.Click += new System.EventHandler(this.fieldAppearanceGeneratorPropertiesToolStripMenuItem_Click);
            // 
            // buttonToolStripSplitButton
            // 
            this.buttonToolStripSplitButton.Checked = false;
            this.buttonToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonFlatBorderToolStripMenuItem,
            this.buttonBorder3DToolStripMenuItem,
            this.toolStripSeparator3,
            this.propertiesToolStripMenuItem});
            this.buttonToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToolStripSplitButton.Name = "buttonToolStripSplitButton";
            this.buttonToolStripSplitButton.Size = new System.Drawing.Size(59, 19);
            this.buttonToolStripSplitButton.Text = "Button";
            this.buttonToolStripSplitButton.ButtonClick += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // buttonFlatBorderToolStripMenuItem
            // 
            this.buttonFlatBorderToolStripMenuItem.Name = "buttonFlatBorderToolStripMenuItem";
            this.buttonFlatBorderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.buttonFlatBorderToolStripMenuItem, "buttonFlatBorderToolStripMenuItem");
            this.buttonFlatBorderToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.buttonFlatBorderToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // buttonBorder3DToolStripMenuItem
            // 
            this.buttonBorder3DToolStripMenuItem.Name = "buttonBorder3DToolStripMenuItem";
            this.buttonBorder3DToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.buttonBorder3DToolStripMenuItem, "buttonBorder3DToolStripMenuItem");
            this.buttonBorder3DToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.buttonBorder3DToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.propertiesToolStripMenuItem, "propertiesToolStripMenuItem");
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.fieldAppearanceGeneratorPropertiesToolStripMenuItem_Click);
            // 
            // listBoxToolStripSplitButton
            // 
            this.listBoxToolStripSplitButton.Checked = false;
            this.listBoxToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listBoxNoBorderToolStripMenuItem,
            this.toolStripSeparator4,
            this.propertiesToolStripMenuItem2});
            this.listBoxToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.listBoxToolStripSplitButton.Name = "listBoxToolStripSplitButton";
            this.listBoxToolStripSplitButton.Size = new System.Drawing.Size(63, 19);
            this.listBoxToolStripSplitButton.Text = "List Box";
            this.listBoxToolStripSplitButton.ButtonClick += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // listBoxNoBorderToolStripMenuItem
            // 
            this.listBoxNoBorderToolStripMenuItem.Name = "listBoxNoBorderToolStripMenuItem";
            this.listBoxNoBorderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.listBoxNoBorderToolStripMenuItem, "listBoxNoBorderToolStripMenuItem");
            this.listBoxNoBorderToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.listBoxNoBorderToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // propertiesToolStripMenuItem2
            // 
            this.propertiesToolStripMenuItem2.Name = "propertiesToolStripMenuItem2";
            this.propertiesToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.propertiesToolStripMenuItem2, "propertiesToolStripMenuItem2");
            this.propertiesToolStripMenuItem2.Click += new System.EventHandler(this.fieldAppearanceGeneratorPropertiesToolStripMenuItem_Click);
            // 
            // comboBoxToolStripSplitButton
            // 
            this.comboBoxToolStripSplitButton.Checked = false;
            this.comboBoxToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboBoxNoBorderToolStripMenuItem,
            this.comboBoxSingleBorderToolStripMenuItem,
            this.comboBox3dBorderToolStripMenuItem,
            this.toolStripSeparator5,
            this.toolStripMenuItem2});
            this.comboBoxToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.comboBoxToolStripSplitButton.Name = "comboBoxToolStripSplitButton";
            this.comboBoxToolStripSplitButton.Size = new System.Drawing.Size(85, 19);
            this.comboBoxToolStripSplitButton.Text = "Combo Box";
            this.comboBoxToolStripSplitButton.ButtonClick += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // comboBoxNoBorderToolStripMenuItem
            // 
            this.comboBoxNoBorderToolStripMenuItem.Name = "comboBoxNoBorderToolStripMenuItem";
            this.comboBoxNoBorderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.comboBoxNoBorderToolStripMenuItem, "comboBoxNoBorderToolStripMenuItem");
            this.comboBoxNoBorderToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.comboBoxNoBorderToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // comboBoxSingleBorderToolStripMenuItem
            // 
            this.comboBoxSingleBorderToolStripMenuItem.Name = "comboBoxSingleBorderToolStripMenuItem";
            this.comboBoxSingleBorderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.comboBoxSingleBorderToolStripMenuItem, "comboBoxSingleBorderToolStripMenuItem");
            this.comboBoxSingleBorderToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.comboBoxSingleBorderToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // comboBox3dBorderToolStripMenuItem
            // 
            this.comboBox3dBorderToolStripMenuItem.Name = "comboBox3dBorderToolStripMenuItem";
            this.comboBox3dBorderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.comboBox3dBorderToolStripMenuItem, "comboBox3dBorderToolStripMenuItem");
            this.comboBox3dBorderToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.comboBox3dBorderToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Click += new System.EventHandler(this.fieldAppearanceGeneratorPropertiesToolStripMenuItem_Click);
            // 
            // radioButtonToolStripSplitButton
            // 
            this.radioButtonToolStripSplitButton.Checked = false;
            this.radioButtonToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.radioButtonStandardToolStripMenuItem,
            this.radioButtonSymbolToolStripMenuItem,
            this.toolStripSeparator6,
            this.propertiesToolStripMenuItem3});
            this.radioButtonToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.radioButtonToolStripSplitButton.Name = "radioButtonToolStripSplitButton";
            this.radioButtonToolStripSplitButton.Size = new System.Drawing.Size(92, 19);
            this.radioButtonToolStripSplitButton.Text = "Radio Button";
            this.radioButtonToolStripSplitButton.ButtonClick += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // radioButtonStandardToolStripMenuItem
            // 
            this.radioButtonStandardToolStripMenuItem.Name = "radioButtonStandardToolStripMenuItem";
            this.radioButtonStandardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.radioButtonStandardToolStripMenuItem, "radioButtonStandardToolStripMenuItem");
            this.radioButtonStandardToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.radioButtonStandardToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // radioButtonSymbolToolStripMenuItem
            // 
            this.radioButtonSymbolToolStripMenuItem.Name = "radioButtonSymbolToolStripMenuItem";
            this.radioButtonSymbolToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.radioButtonSymbolToolStripMenuItem, "radioButtonSymbolToolStripMenuItem");
            this.radioButtonSymbolToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.radioButtonSymbolToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(149, 6);
            // 
            // propertiesToolStripMenuItem3
            // 
            this.propertiesToolStripMenuItem3.Name = "propertiesToolStripMenuItem3";
            this.propertiesToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.propertiesToolStripMenuItem3, "propertiesToolStripMenuItem3");
            this.propertiesToolStripMenuItem3.Click += new System.EventHandler(this.fieldAppearanceGeneratorPropertiesToolStripMenuItem_Click);
            // 
            // barcodeToolStripSplitButton
            // 
            this.barcodeToolStripSplitButton.Checked = false;
            this.barcodeToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barcodePdf417ToolStripMenuItem,
            this.barcodeDataMatrixToolStripMenuItem,
            this.barcodeQrCodeToolStripMenuItem,
            this.vintasoftBarcodeToolStripMenuItem,
            this.toolStripSeparator7,
            this.propertiesToolStripMenuItem4});
            this.barcodeToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barcodeToolStripSplitButton.Name = "barcodeToolStripSplitButton";
            this.barcodeToolStripSplitButton.Size = new System.Drawing.Size(66, 19);
            this.barcodeToolStripSplitButton.Text = "Barcode";
            this.barcodeToolStripSplitButton.ButtonClick += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // barcodePdf417ToolStripMenuItem
            // 
            this.barcodePdf417ToolStripMenuItem.Name = "barcodePdf417ToolStripMenuItem";
            this.barcodePdf417ToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.barcodePdf417ToolStripMenuItem.Text = "PDF417";
            this.barcodePdf417ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.barcodePdf417ToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // barcodeDataMatrixToolStripMenuItem
            // 
            this.barcodeDataMatrixToolStripMenuItem.Name = "barcodeDataMatrixToolStripMenuItem";
            this.barcodeDataMatrixToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.barcodeDataMatrixToolStripMenuItem.Text = "DataMatrix";
            this.barcodeDataMatrixToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.barcodeDataMatrixToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // barcodeQrCodeToolStripMenuItem
            // 
            this.barcodeQrCodeToolStripMenuItem.Name = "barcodeQrCodeToolStripMenuItem";
            this.barcodeQrCodeToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.barcodeQrCodeToolStripMenuItem.Text = "QR Code";
            this.barcodeQrCodeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.barcodeQrCodeToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // vintasoftBarcodeToolStripMenuItem
            // 
            this.vintasoftBarcodeToolStripMenuItem.Name = "vintasoftBarcodeToolStripMenuItem";
            this.vintasoftBarcodeToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            resources.ApplyResources(this.vintasoftBarcodeToolStripMenuItem, "vintasoftBarcodeToolStripMenuItem");
            this.vintasoftBarcodeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.vintasoftBarcodeToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(273, 6);
            // 
            // propertiesToolStripMenuItem4
            // 
            this.propertiesToolStripMenuItem4.Name = "propertiesToolStripMenuItem4";
            this.propertiesToolStripMenuItem4.Size = new System.Drawing.Size(276, 22);
            resources.ApplyResources(this.propertiesToolStripMenuItem4, "propertiesToolStripMenuItem4");
            this.propertiesToolStripMenuItem4.Click += new System.EventHandler(this.fieldAppearanceGeneratorPropertiesToolStripMenuItem_Click);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.AutoSize = false;
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textFieldToolStripSplitButton,
            this.checkBoxToolStripSplitButton,
            this.buttonToolStripSplitButton,
            this.listBoxToolStripSplitButton,
            this.comboBoxToolStripSplitButton,
            this.radioButtonToolStripSplitButton,
            this.barcodeToolStripSplitButton,
            this.signatureToolStripSplitButton});
            this.mainToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.mainToolStrip.Size = new System.Drawing.Size(212, 223);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // signatureToolStripSplitButton
            // 
            this.signatureToolStripSplitButton.Checked = false;
            this.signatureToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signatureDefaultToolStripMenuItem,
            this.toolStripSeparator8,
            this.propertiesToolStripMenuItem5});
            this.signatureToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.signatureToolStripSplitButton.Name = "signatureToolStripSplitButton";
            this.signatureToolStripSplitButton.Size = new System.Drawing.Size(110, 19);
            this.signatureToolStripSplitButton.Text = "Digital Signature";
            this.signatureToolStripSplitButton.ButtonClick += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // signatureDefaultToolStripMenuItem
            // 
            this.signatureDefaultToolStripMenuItem.Name = "signatureDefaultToolStripMenuItem";
            this.signatureDefaultToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.signatureDefaultToolStripMenuItem, "signatureDefaultToolStripMenuItem");
            this.signatureDefaultToolStripMenuItem.CheckedChanged += new System.EventHandler(this.appearanceToolStripMenuItem_CheckedChanged);
            this.signatureDefaultToolStripMenuItem.Click += new System.EventHandler(this.addAndBuildInteractiveFormFieldToolStripButton_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(149, 6);
            // 
            // propertiesToolStripMenuItem5
            // 
            this.propertiesToolStripMenuItem5.Name = "propertiesToolStripMenuItem5";
            this.propertiesToolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            resources.ApplyResources(this.propertiesToolStripMenuItem5, "propertiesToolStripMenuItem5");
            this.propertiesToolStripMenuItem5.Click += new System.EventHandler(this.fieldAppearanceGeneratorPropertiesToolStripMenuItem_Click);
            // 
            // PdfInteractiveFormFieldBuilderControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainToolStrip);
            this.Name = "PdfInteractiveFormFieldBuilderControl";
            this.Size = new System.Drawing.Size(212, 223);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DemosCommonCode.CustomControls.CheckedToolStripSplitButton textFieldToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem textFieldNoBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textFieldSingleBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textField3DBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem textFieldPropertiesToolStripMenuItem;
        private DemosCommonCode.CustomControls.CheckedToolStripSplitButton checkBoxToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem checkBoxSimpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkBoxSymbolVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkBoxSymbolXToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem1;
        private DemosCommonCode.CustomControls.CheckedToolStripSplitButton buttonToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem buttonFlatBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonBorder3DToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private DemosCommonCode.CustomControls.CheckedToolStripSplitButton listBoxToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem listBoxNoBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem2;
        private DemosCommonCode.CustomControls.CheckedToolStripSplitButton comboBoxToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem comboBoxNoBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private DemosCommonCode.CustomControls.CheckedToolStripSplitButton radioButtonToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem radioButtonSymbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem3;
        private DemosCommonCode.CustomControls.CheckedToolStripSplitButton barcodeToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem barcodePdf417ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barcodeDataMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barcodeQrCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem4;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private DemosCommonCode.CustomControls.CheckedToolStripSplitButton signatureToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem signatureDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem comboBoxSingleBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comboBox3dBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vintasoftBarcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radioButtonStandardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkBoxStandardToolStripMenuItem;


    }
}