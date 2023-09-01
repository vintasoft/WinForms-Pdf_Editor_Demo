namespace DemosCommonCode.Pdf.Security
{
    partial class RedactionMarkAppearanceEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedactionMarkAppearanceEditor));
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard1 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings1 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.redactionMarkEditor = new Vintasoft.Imaging.UI.ImageViewer();
            this.buttonOk = new System.Windows.Forms.Button();
            this.isFillColorEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.overlayTextGroupBox = new System.Windows.Forms.GroupBox();
            this.fontColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.alignmentComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.autoFontSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fontSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.fontButton = new System.Windows.Forms.Button();
            this.overlayTextBox = new System.Windows.Forms.TextBox();
            this.fillColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.fillColorGroupBox = new System.Windows.Forms.GroupBox();
            this.fillColorLabel = new System.Windows.Forms.Label();
            this.borderPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.borderWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.borderWidthLabel = new System.Windows.Forms.Label();
            this.borderColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.borderColorLabel = new System.Windows.Forms.Label();
            this.isBorderPropertiesEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4.SuspendLayout();
            this.overlayTextGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).BeginInit();
            this.fillColorGroupBox.SuspendLayout();
            this.borderPropertiesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.redactionMarkEditor);
            this.groupBox4.Location = new System.Drawing.Point(3, 167);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(540, 300);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            resources.ApplyResources(this.groupBox4, "groupBox4");
            // 
            // redactionMarkEditor
            // 
            this.redactionMarkEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.redactionMarkEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redactionMarkEditor.Clipboard = winFormsSystemClipboard1;
            this.redactionMarkEditor.ImageRenderingSettings = renderingSettings1;
            this.redactionMarkEditor.Location = new System.Drawing.Point(6, 19);
            this.redactionMarkEditor.Name = "redactionMarkEditor";
            this.redactionMarkEditor.Size = new System.Drawing.Size(528, 275);
            this.redactionMarkEditor.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.redactionMarkEditor.TabIndex = 3;
            this.redactionMarkEditor.Text = "imageViewer1";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(468, 473);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // isFillColorEnabledCheckBox
            // 
            this.isFillColorEnabledCheckBox.AutoSize = true;
            this.isFillColorEnabledCheckBox.Location = new System.Drawing.Point(15, 9);
            this.isFillColorEnabledCheckBox.Name = "isFillColorEnabledCheckBox";
            this.isFillColorEnabledCheckBox.Size = new System.Drawing.Size(38, 17);
            this.isFillColorEnabledCheckBox.TabIndex = 10;
            resources.ApplyResources(this.isFillColorEnabledCheckBox, "isFillColorEnabledCheckBox");
            this.isFillColorEnabledCheckBox.UseVisualStyleBackColor = true;
            this.isFillColorEnabledCheckBox.CheckedChanged += new System.EventHandler(this.isFillColorEnabledCheckBox_CheckedChanged);
            // 
            // overlayTextGroupBox
            // 
            this.overlayTextGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overlayTextGroupBox.Controls.Add(this.fontColorPanelControl);
            this.overlayTextGroupBox.Controls.Add(this.label3);
            this.overlayTextGroupBox.Controls.Add(this.alignmentComboBox);
            this.overlayTextGroupBox.Controls.Add(this.label2);
            this.overlayTextGroupBox.Controls.Add(this.autoFontSizeCheckBox);
            this.overlayTextGroupBox.Controls.Add(this.label1);
            this.overlayTextGroupBox.Controls.Add(this.fontSizeNumericUpDown);
            this.overlayTextGroupBox.Controls.Add(this.fontButton);
            this.overlayTextGroupBox.Controls.Add(this.overlayTextBox);
            this.overlayTextGroupBox.Location = new System.Drawing.Point(3, 83);
            this.overlayTextGroupBox.Name = "overlayTextGroupBox";
            this.overlayTextGroupBox.Size = new System.Drawing.Size(540, 78);
            this.overlayTextGroupBox.TabIndex = 14;
            this.overlayTextGroupBox.TabStop = false;
            // 
            // fontColorPanelControl
            // 
            this.fontColorPanelControl.Color = System.Drawing.SystemColors.Control;
            this.fontColorPanelControl.ColorButtonMargin = 6;
            this.fontColorPanelControl.ColorButtonWidth = 38;
            this.fontColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.fontColorPanelControl.Location = new System.Drawing.Point(448, 43);
            this.fontColorPanelControl.Name = "fontColorPanelControl";
            this.fontColorPanelControl.Size = new System.Drawing.Size(85, 22);
            this.fontColorPanelControl.TabIndex = 4;
            this.fontColorPanelControl.ColorChanged += new System.EventHandler(this.fontColorPanelControl_ColorChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 26;
            resources.ApplyResources(this.label3, "label3");
            // 
            // alignmentComboBox
            // 
            this.alignmentComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alignmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alignmentComboBox.FormattingEnabled = true;
            this.alignmentComboBox.Location = new System.Drawing.Point(390, 18);
            this.alignmentComboBox.Name = "alignmentComboBox";
            this.alignmentComboBox.Size = new System.Drawing.Size(143, 21);
            this.alignmentComboBox.TabIndex = 25;
            this.alignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.alignmentComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 21;
            resources.ApplyResources(this.label2, "label2");
            // 
            // autoFontSizeCheckBox
            // 
            this.autoFontSizeCheckBox.AutoSize = true;
            this.autoFontSizeCheckBox.Location = new System.Drawing.Point(213, 48);
            this.autoFontSizeCheckBox.Name = "autoFontSizeCheckBox";
            this.autoFontSizeCheckBox.Size = new System.Drawing.Size(95, 17);
            this.autoFontSizeCheckBox.TabIndex = 18;
            resources.ApplyResources(this.autoFontSizeCheckBox, "autoFontSizeCheckBox");
            this.autoFontSizeCheckBox.UseVisualStyleBackColor = true;
            this.autoFontSizeCheckBox.CheckedChanged += new System.EventHandler(this.autoFontSizeCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 17;
            resources.ApplyResources(this.label1, "label1");
            // 
            // fontSizeNumericUpDown
            // 
            this.fontSizeNumericUpDown.Location = new System.Drawing.Point(145, 46);
            this.fontSizeNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.fontSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontSizeNumericUpDown.Name = "fontSizeNumericUpDown";
            this.fontSizeNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.fontSizeNumericUpDown.TabIndex = 16;
            this.fontSizeNumericUpDown.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.fontSizeNumericUpDown.ValueChanged += new System.EventHandler(this.fontSizeNumericUpDown_ValueChanged);
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(6, 44);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(75, 23);
            this.fontButton.TabIndex = 15;
            resources.ApplyResources(this.fontButton, "fontButton");
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // overlayTextBox
            // 
            this.overlayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overlayTextBox.Location = new System.Drawing.Point(6, 19);
            this.overlayTextBox.Multiline = true;
            this.overlayTextBox.Name = "overlayTextBox";
            this.overlayTextBox.Size = new System.Drawing.Size(378, 20);
            this.overlayTextBox.TabIndex = 14;
            this.overlayTextBox.TextChanged += new System.EventHandler(this.overlayTextBox_TextChanged);
            // 
            // fillColorPanelControl
            // 
            this.fillColorPanelControl.Color = System.Drawing.SystemColors.Control;
            this.fillColorPanelControl.ColorButtonMargin = 6;
            this.fillColorPanelControl.ColorButtonWidth = 40;
            this.fillColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.fillColorPanelControl.Location = new System.Drawing.Point(49, 26);
            this.fillColorPanelControl.Name = "fillColorPanelControl";
            this.fillColorPanelControl.Size = new System.Drawing.Size(195, 19);
            this.fillColorPanelControl.TabIndex = 15;
            this.fillColorPanelControl.ColorChanged += new System.EventHandler(this.fillColorPanelControl_ColorChanged);
            // 
            // fillColorGroupBox
            // 
            this.fillColorGroupBox.Controls.Add(this.fillColorLabel);
            this.fillColorGroupBox.Controls.Add(this.fillColorPanelControl);
            this.fillColorGroupBox.Location = new System.Drawing.Point(3, 10);
            this.fillColorGroupBox.Name = "fillColorGroupBox";
            this.fillColorGroupBox.Size = new System.Drawing.Size(267, 60);
            this.fillColorGroupBox.TabIndex = 16;
            this.fillColorGroupBox.TabStop = false;
            // 
            // fillColorLabel
            // 
            this.fillColorLabel.AutoSize = true;
            this.fillColorLabel.Location = new System.Drawing.Point(12, 28);
            this.fillColorLabel.Name = "fillColorLabel";
            this.fillColorLabel.Size = new System.Drawing.Size(31, 13);
            this.fillColorLabel.TabIndex = 16;
            resources.ApplyResources(this.fillColorLabel, "fillColorLabel");
            // 
            // borderPropertiesGroupBox
            // 
            this.borderPropertiesGroupBox.Controls.Add(this.borderWidthNumericUpDown);
            this.borderPropertiesGroupBox.Controls.Add(this.borderWidthLabel);
            this.borderPropertiesGroupBox.Controls.Add(this.borderColorPanelControl);
            this.borderPropertiesGroupBox.Controls.Add(this.borderColorLabel);
            this.borderPropertiesGroupBox.Location = new System.Drawing.Point(276, 10);
            this.borderPropertiesGroupBox.Name = "borderPropertiesGroupBox";
            this.borderPropertiesGroupBox.Size = new System.Drawing.Size(267, 60);
            this.borderPropertiesGroupBox.TabIndex = 16;
            this.borderPropertiesGroupBox.TabStop = false;
            // 
            // borderWidthNumericUpDown
            // 
            this.borderWidthNumericUpDown.Location = new System.Drawing.Point(212, 25);
            this.borderWidthNumericUpDown.Name = "borderWidthNumericUpDown";
            this.borderWidthNumericUpDown.Size = new System.Drawing.Size(48, 20);
            this.borderWidthNumericUpDown.TabIndex = 3;
            this.borderWidthNumericUpDown.ValueChanged += new System.EventHandler(this.borderWidthNumericUpDown_ValueChanged);
            // 
            // borderWidthLabel
            // 
            this.borderWidthLabel.AutoSize = true;
            this.borderWidthLabel.Location = new System.Drawing.Point(171, 28);
            this.borderWidthLabel.Name = "borderWidthLabel";
            this.borderWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.borderWidthLabel.TabIndex = 2;
            resources.ApplyResources(this.borderWidthLabel, "borderWidthLabel");
            // 
            // borderColorPanelControl
            // 
            this.borderColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.borderColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.borderColorPanelControl.Location = new System.Drawing.Point(49, 26);
            this.borderColorPanelControl.Name = "borderColorPanelControl";
            this.borderColorPanelControl.Size = new System.Drawing.Size(95, 19);
            this.borderColorPanelControl.TabIndex = 1;
            this.borderColorPanelControl.ColorChanged += new System.EventHandler(this.borderColorPanelControl_ColorChanged);
            // 
            // borderColorLabel
            // 
            this.borderColorLabel.AutoSize = true;
            this.borderColorLabel.Location = new System.Drawing.Point(12, 28);
            this.borderColorLabel.Name = "borderColorLabel";
            this.borderColorLabel.Size = new System.Drawing.Size(31, 13);
            this.borderColorLabel.TabIndex = 0;
            resources.ApplyResources(this.borderColorLabel, "borderColorLabel");
            // 
            // isBorderPropertiesEnabledCheckBox
            // 
            this.isBorderPropertiesEnabledCheckBox.AutoSize = true;
            this.isBorderPropertiesEnabledCheckBox.Location = new System.Drawing.Point(291, 9);
            this.isBorderPropertiesEnabledCheckBox.Name = "isBorderPropertiesEnabledCheckBox";
            this.isBorderPropertiesEnabledCheckBox.Size = new System.Drawing.Size(57, 17);
            this.isBorderPropertiesEnabledCheckBox.TabIndex = 4;
            resources.ApplyResources(this.isBorderPropertiesEnabledCheckBox, "isBorderPropertiesEnabledCheckBox");
            this.isBorderPropertiesEnabledCheckBox.UseVisualStyleBackColor = true;
            this.isBorderPropertiesEnabledCheckBox.CheckedChanged += new System.EventHandler(this.isBorderPropertiesEnabledCheckBox_CheckedChanged);
            // 
            // RedactionMarkAppearanceEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 507);
            this.Controls.Add(this.isBorderPropertiesEnabledCheckBox);
            this.Controls.Add(this.borderPropertiesGroupBox);
            this.Controls.Add(this.isFillColorEnabledCheckBox);
            this.Controls.Add(this.fillColorGroupBox);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.overlayTextGroupBox);
            this.Name = "RedactionMarkAppearanceEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            resources.ApplyResources(this, "$this");
            this.groupBox4.ResumeLayout(false);
            this.overlayTextGroupBox.ResumeLayout(false);
            this.overlayTextGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).EndInit();
            this.fillColorGroupBox.ResumeLayout(false);
            this.fillColorGroupBox.PerformLayout();
            this.borderPropertiesGroupBox.ResumeLayout(false);
            this.borderPropertiesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private Vintasoft.Imaging.UI.ImageViewer redactionMarkEditor;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox isFillColorEnabledCheckBox;
        private System.Windows.Forms.GroupBox overlayTextGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox autoFontSizeCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown fontSizeNumericUpDown;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.TextBox overlayTextBox;
        private System.Windows.Forms.ComboBox alignmentComboBox;
        private System.Windows.Forms.Label label3;
        private DemosCommonCode.CustomControls.ColorPanelControl fillColorPanelControl;
        private DemosCommonCode.CustomControls.ColorPanelControl fontColorPanelControl;
        private System.Windows.Forms.GroupBox fillColorGroupBox;
        private System.Windows.Forms.Label fillColorLabel;
        private System.Windows.Forms.GroupBox borderPropertiesGroupBox;
        private System.Windows.Forms.NumericUpDown borderWidthNumericUpDown;
        private System.Windows.Forms.Label borderWidthLabel;
        private CustomControls.ColorPanelControl borderColorPanelControl;
        private System.Windows.Forms.Label borderColorLabel;
        private System.Windows.Forms.CheckBox isBorderPropertiesEnabledCheckBox;
    }
}