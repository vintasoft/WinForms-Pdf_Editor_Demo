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
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard2 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings2 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.redactionMarkEditor = new Vintasoft.Imaging.UI.ImageViewer();
            this.buttonOk = new System.Windows.Forms.Button();
            this.isFillColorEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.overlayTextGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.alignmentComboBox = new System.Windows.Forms.ComboBox();
            this.overlayTextBox = new System.Windows.Forms.TextBox();
            this.fontColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.fontButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fontSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.autoFontSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fillColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.fillColorGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fillColorLabel = new System.Windows.Forms.Label();
            this.borderPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.borderColorLabel = new System.Windows.Forms.Label();
            this.borderWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.borderColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.borderWidthLabel = new System.Windows.Forms.Label();
            this.isBorderPropertiesEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4.SuspendLayout();
            this.overlayTextGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).BeginInit();
            this.fillColorGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.borderPropertiesGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.redactionMarkEditor.Clipboard = winFormsSystemClipboard2;
            this.redactionMarkEditor.ImageRenderingSettings = renderingSettings2;
            this.redactionMarkEditor.ImageRotationAngle = 0;
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
            this.overlayTextGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.overlayTextGroupBox.Controls.Add(this.label3);
            this.overlayTextGroupBox.Location = new System.Drawing.Point(3, 83);
            this.overlayTextGroupBox.Name = "overlayTextGroupBox";
            this.overlayTextGroupBox.Size = new System.Drawing.Size(540, 78);
            this.overlayTextGroupBox.TabIndex = 14;
            this.overlayTextGroupBox.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.overlayTextBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.fontColorPanelControl, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.alignmentComboBox, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.fontButton, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.fontSizeNumericUpDown, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.autoFontSizeCheckBox, 3, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(534, 59);
            this.tableLayoutPanel3.TabIndex = 27;
            // 
            // alignmentComboBox
            // 
            this.alignmentComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.alignmentComboBox, 2);
            this.alignmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alignmentComboBox.FormattingEnabled = true;
            this.alignmentComboBox.Location = new System.Drawing.Point(305, 4);
            this.alignmentComboBox.Name = "alignmentComboBox";
            this.alignmentComboBox.Size = new System.Drawing.Size(226, 21);
            this.alignmentComboBox.TabIndex = 25;
            this.alignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.alignmentComboBox_SelectedIndexChanged);
            // 
            // overlayTextBox
            // 
            this.overlayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.overlayTextBox, 4);
            this.overlayTextBox.Location = new System.Drawing.Point(3, 4);
            this.overlayTextBox.Multiline = true;
            this.overlayTextBox.Name = "overlayTextBox";
            this.overlayTextBox.Size = new System.Drawing.Size(296, 20);
            this.overlayTextBox.TabIndex = 14;
            this.overlayTextBox.TextChanged += new System.EventHandler(this.overlayTextBox_TextChanged);
            // 
            // fontColorPanelControl
            // 
            this.fontColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fontColorPanelControl.Color = System.Drawing.SystemColors.Control;
            this.fontColorPanelControl.ColorButtonMargin = 6;
            this.fontColorPanelControl.ColorButtonWidth = 38;
            this.fontColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.fontColorPanelControl.Location = new System.Drawing.Point(366, 33);
            this.fontColorPanelControl.Name = "fontColorPanelControl";
            this.fontColorPanelControl.Size = new System.Drawing.Size(165, 22);
            this.fontColorPanelControl.TabIndex = 4;
            this.fontColorPanelControl.ColorChanged += new System.EventHandler(this.fontColorPanelControl_ColorChanged);
            // 
            // fontButton
            // 
            this.fontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fontButton.AutoSize = true;
            this.fontButton.Location = new System.Drawing.Point(3, 32);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(75, 23);
            this.fontButton.TabIndex = 15;
            resources.ApplyResources(this.fontButton, "fontButton");
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 17;
            resources.ApplyResources(this.label1, "label1");
            // 
            // fontSizeNumericUpDown
            // 
            this.fontSizeNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fontSizeNumericUpDown.Location = new System.Drawing.Point(141, 34);
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
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 21;
            resources.ApplyResources(this.label2, "label2");
            // 
            // autoFontSizeCheckBox
            // 
            this.autoFontSizeCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.autoFontSizeCheckBox.AutoSize = true;
            this.autoFontSizeCheckBox.Location = new System.Drawing.Point(204, 35);
            this.autoFontSizeCheckBox.Name = "autoFontSizeCheckBox";
            this.autoFontSizeCheckBox.Size = new System.Drawing.Size(95, 17);
            this.autoFontSizeCheckBox.TabIndex = 18;
            resources.ApplyResources(this.autoFontSizeCheckBox, "autoFontSizeCheckBox");
            this.autoFontSizeCheckBox.UseVisualStyleBackColor = true;
            this.autoFontSizeCheckBox.CheckedChanged += new System.EventHandler(this.autoFontSizeCheckBox_CheckedChanged);
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
            // fillColorPanelControl
            // 
            this.fillColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fillColorPanelControl.Color = System.Drawing.SystemColors.Control;
            this.fillColorPanelControl.ColorButtonMargin = 6;
            this.fillColorPanelControl.ColorButtonWidth = 40;
            this.fillColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.fillColorPanelControl.Location = new System.Drawing.Point(40, 11);
            this.fillColorPanelControl.Name = "fillColorPanelControl";
            this.fillColorPanelControl.Size = new System.Drawing.Size(218, 19);
            this.fillColorPanelControl.TabIndex = 15;
            this.fillColorPanelControl.ColorChanged += new System.EventHandler(this.fillColorPanelControl_ColorChanged);
            // 
            // fillColorGroupBox
            // 
            this.fillColorGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.fillColorGroupBox.Location = new System.Drawing.Point(3, 10);
            this.fillColorGroupBox.Name = "fillColorGroupBox";
            this.fillColorGroupBox.Size = new System.Drawing.Size(267, 60);
            this.fillColorGroupBox.TabIndex = 16;
            this.fillColorGroupBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.fillColorLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fillColorPanelControl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(261, 41);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // fillColorLabel
            // 
            this.fillColorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fillColorLabel.AutoSize = true;
            this.fillColorLabel.Location = new System.Drawing.Point(3, 14);
            this.fillColorLabel.Name = "fillColorLabel";
            this.fillColorLabel.Size = new System.Drawing.Size(31, 13);
            this.fillColorLabel.TabIndex = 16;
            resources.ApplyResources(this.fillColorLabel, "fillColorLabel");
            // 
            // borderPropertiesGroupBox
            // 
            this.borderPropertiesGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.borderPropertiesGroupBox.Location = new System.Drawing.Point(276, 10);
            this.borderPropertiesGroupBox.Name = "borderPropertiesGroupBox";
            this.borderPropertiesGroupBox.Size = new System.Drawing.Size(267, 60);
            this.borderPropertiesGroupBox.TabIndex = 16;
            this.borderPropertiesGroupBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.borderColorLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.borderWidthNumericUpDown, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.borderColorPanelControl, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.borderWidthLabel, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(261, 41);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // borderColorLabel
            // 
            this.borderColorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.borderColorLabel.AutoSize = true;
            this.borderColorLabel.Location = new System.Drawing.Point(3, 14);
            this.borderColorLabel.Name = "borderColorLabel";
            this.borderColorLabel.Size = new System.Drawing.Size(31, 13);
            this.borderColorLabel.TabIndex = 0;
            resources.ApplyResources(this.borderColorLabel, "borderColorLabel");
            // 
            // borderWidthNumericUpDown
            // 
            this.borderWidthNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.borderWidthNumericUpDown.Location = new System.Drawing.Point(210, 10);
            this.borderWidthNumericUpDown.Name = "borderWidthNumericUpDown";
            this.borderWidthNumericUpDown.Size = new System.Drawing.Size(48, 20);
            this.borderWidthNumericUpDown.TabIndex = 3;
            this.borderWidthNumericUpDown.ValueChanged += new System.EventHandler(this.borderWidthNumericUpDown_ValueChanged);
            // 
            // borderColorPanelControl
            // 
            this.borderColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.borderColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.borderColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.borderColorPanelControl.Location = new System.Drawing.Point(40, 11);
            this.borderColorPanelControl.Name = "borderColorPanelControl";
            this.borderColorPanelControl.Size = new System.Drawing.Size(123, 19);
            this.borderColorPanelControl.TabIndex = 1;
            this.borderColorPanelControl.ColorChanged += new System.EventHandler(this.borderColorPanelControl_ColorChanged);
            // 
            // borderWidthLabel
            // 
            this.borderWidthLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.borderWidthLabel.AutoSize = true;
            this.borderWidthLabel.Location = new System.Drawing.Point(169, 14);
            this.borderWidthLabel.Name = "borderWidthLabel";
            this.borderWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.borderWidthLabel.TabIndex = 2;
            resources.ApplyResources(this.borderWidthLabel, "borderWidthLabel");
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
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).EndInit();
            this.fillColorGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.borderPropertiesGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}