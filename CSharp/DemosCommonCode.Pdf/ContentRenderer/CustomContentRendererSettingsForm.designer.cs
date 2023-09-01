namespace DemosCommonCode.Pdf
{
    partial class CustomContentRendererSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomContentRendererSettingsForm));
            this.fillPathsCheckBox = new System.Windows.Forms.CheckBox();
            this.useTilingPatternsCheckBox = new System.Windows.Forms.CheckBox();
            this.useShadingPatternsCheckBox = new System.Windows.Forms.CheckBox();
            this.drawPathsCheckBox = new System.Windows.Forms.CheckBox();
            this.linesWeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fillAreaUseShadigPatternsCheckBox = new System.Windows.Forms.CheckBox();
            this.useClipPathsCheckBox = new System.Windows.Forms.CheckBox();
            this.imagesGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.autoContrastCheckBox = new System.Windows.Forms.CheckBox();
            this.autoLevelsCheckBox = new System.Windows.Forms.CheckBox();
            this.autoColorsCheckBox = new System.Windows.Forms.CheckBox();
            this.convertToGrayscaleCheckBox = new System.Windows.Forms.CheckBox();
            this.drawInlineImagesCheckBox = new System.Windows.Forms.CheckBox();
            this.drawImageResourcesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.drawAnnotationsCheckBox = new System.Windows.Forms.CheckBox();
            this.drawFormsCheckBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.drawInvisibleTextCheckBox = new System.Windows.Forms.CheckBox();
            this.drawTextCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.linesWeightNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.imagesGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // fillPathsCheckBox
            // 
            this.fillPathsCheckBox.AutoSize = true;
            this.fillPathsCheckBox.Location = new System.Drawing.Point(6, 42);
            this.fillPathsCheckBox.Name = "fillPathsCheckBox";
            this.fillPathsCheckBox.Size = new System.Drawing.Size(68, 17);
            this.fillPathsCheckBox.TabIndex = 0;
            resources.ApplyResources(this.fillPathsCheckBox, "fillPathsCheckBox");
            this.fillPathsCheckBox.UseVisualStyleBackColor = true;
            // 
            // useTilingPatternsCheckBox
            // 
            this.useTilingPatternsCheckBox.AutoSize = true;
            this.useTilingPatternsCheckBox.Location = new System.Drawing.Point(6, 65);
            this.useTilingPatternsCheckBox.Name = "useTilingPatternsCheckBox";
            this.useTilingPatternsCheckBox.Size = new System.Drawing.Size(166, 17);
            this.useTilingPatternsCheckBox.TabIndex = 1;
            resources.ApplyResources(this.useTilingPatternsCheckBox, "useTilingPatternsCheckBox");
            this.useTilingPatternsCheckBox.UseVisualStyleBackColor = true;
            // 
            // useShadingPatternsCheckBox
            // 
            this.useShadingPatternsCheckBox.AutoSize = true;
            this.useShadingPatternsCheckBox.Location = new System.Drawing.Point(6, 88);
            this.useShadingPatternsCheckBox.Name = "useShadingPatternsCheckBox";
            this.useShadingPatternsCheckBox.Size = new System.Drawing.Size(180, 17);
            this.useShadingPatternsCheckBox.TabIndex = 10;
            resources.ApplyResources(this.useShadingPatternsCheckBox, "useShadingPatternsCheckBox");
            this.useShadingPatternsCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawPathsCheckBox
            // 
            this.drawPathsCheckBox.AutoSize = true;
            this.drawPathsCheckBox.Location = new System.Drawing.Point(6, 19);
            this.drawPathsCheckBox.Name = "drawPathsCheckBox";
            this.drawPathsCheckBox.Size = new System.Drawing.Size(81, 17);
            this.drawPathsCheckBox.TabIndex = 11;
            resources.ApplyResources(this.drawPathsCheckBox, "drawPathsCheckBox");
            this.drawPathsCheckBox.UseVisualStyleBackColor = true;
            // 
            // linesWeightNumericUpDown
            // 
            this.linesWeightNumericUpDown.Location = new System.Drawing.Point(96, 157);
            this.linesWeightNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.linesWeightNumericUpDown.Name = "linesWeightNumericUpDown";
            this.linesWeightNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.linesWeightNumericUpDown.TabIndex = 12;
            this.linesWeightNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 13;
            resources.ApplyResources(this.label1, "label1");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fillAreaUseShadigPatternsCheckBox);
            this.groupBox1.Controls.Add(this.useClipPathsCheckBox);
            this.groupBox1.Controls.Add(this.fillPathsCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.useTilingPatternsCheckBox);
            this.groupBox1.Controls.Add(this.linesWeightNumericUpDown);
            this.groupBox1.Controls.Add(this.useShadingPatternsCheckBox);
            this.groupBox1.Controls.Add(this.drawPathsCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 184);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // fillAreaUseShadigPatternsCheckBox
            // 
            this.fillAreaUseShadigPatternsCheckBox.AutoSize = true;
            this.fillAreaUseShadigPatternsCheckBox.Location = new System.Drawing.Point(6, 111);
            this.fillAreaUseShadigPatternsCheckBox.Name = "fillAreaUseShadigPatternsCheckBox";
            this.fillAreaUseShadigPatternsCheckBox.Size = new System.Drawing.Size(175, 17);
            this.fillAreaUseShadigPatternsCheckBox.TabIndex = 15;
            resources.ApplyResources(this.fillAreaUseShadigPatternsCheckBox, "fillAreaUseShadigPatternsCheckBox");
            this.fillAreaUseShadigPatternsCheckBox.UseVisualStyleBackColor = true;
            // 
            // useClipPathsCheckBox
            // 
            this.useClipPathsCheckBox.AutoSize = true;
            this.useClipPathsCheckBox.Location = new System.Drawing.Point(6, 134);
            this.useClipPathsCheckBox.Name = "useClipPathsCheckBox";
            this.useClipPathsCheckBox.Size = new System.Drawing.Size(95, 17);
            this.useClipPathsCheckBox.TabIndex = 14;
            resources.ApplyResources(this.useClipPathsCheckBox, "useClipPathsCheckBox");
            this.useClipPathsCheckBox.UseVisualStyleBackColor = true;
            // 
            // imagesGroupBox
            // 
            this.imagesGroupBox.Controls.Add(this.groupBox2);
            this.imagesGroupBox.Controls.Add(this.drawInlineImagesCheckBox);
            this.imagesGroupBox.Controls.Add(this.drawImageResourcesCheckBox);
            this.imagesGroupBox.Location = new System.Drawing.Point(207, 6);
            this.imagesGroupBox.Name = "imagesGroupBox";
            this.imagesGroupBox.Size = new System.Drawing.Size(182, 184);
            this.imagesGroupBox.TabIndex = 15;
            this.imagesGroupBox.TabStop = false;
            resources.ApplyResources(this.imagesGroupBox, "imagesGroupBox");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.autoContrastCheckBox);
            this.groupBox2.Controls.Add(this.autoLevelsCheckBox);
            this.groupBox2.Controls.Add(this.autoColorsCheckBox);
            this.groupBox2.Controls.Add(this.convertToGrayscaleCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 108);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            // 
            // autoContrastCheckBox
            // 
            this.autoContrastCheckBox.AutoSize = true;
            this.autoContrastCheckBox.Location = new System.Drawing.Point(10, 86);
            this.autoContrastCheckBox.Name = "autoContrastCheckBox";
            this.autoContrastCheckBox.Size = new System.Drawing.Size(90, 17);
            this.autoContrastCheckBox.TabIndex = 4;
            resources.ApplyResources(this.autoContrastCheckBox, "autoContrastCheckBox");
            this.autoContrastCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoLevelsCheckBox
            // 
            this.autoLevelsCheckBox.AutoSize = true;
            this.autoLevelsCheckBox.Location = new System.Drawing.Point(10, 63);
            this.autoLevelsCheckBox.Name = "autoLevelsCheckBox";
            this.autoLevelsCheckBox.Size = new System.Drawing.Size(82, 17);
            this.autoLevelsCheckBox.TabIndex = 3;
            resources.ApplyResources(this.autoLevelsCheckBox, "autoLevelsCheckBox");
            this.autoLevelsCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoColorsCheckBox
            // 
            this.autoColorsCheckBox.AutoSize = true;
            this.autoColorsCheckBox.Location = new System.Drawing.Point(10, 40);
            this.autoColorsCheckBox.Name = "autoColorsCheckBox";
            this.autoColorsCheckBox.Size = new System.Drawing.Size(80, 17);
            this.autoColorsCheckBox.TabIndex = 2;
            resources.ApplyResources(this.autoColorsCheckBox, "autoColorsCheckBox");
            this.autoColorsCheckBox.UseVisualStyleBackColor = true;
            // 
            // convertToGrayscaleCheckBox
            // 
            this.convertToGrayscaleCheckBox.AutoSize = true;
            this.convertToGrayscaleCheckBox.Location = new System.Drawing.Point(10, 19);
            this.convertToGrayscaleCheckBox.Name = "convertToGrayscaleCheckBox";
            this.convertToGrayscaleCheckBox.Size = new System.Drawing.Size(125, 17);
            this.convertToGrayscaleCheckBox.TabIndex = 0;
            resources.ApplyResources(this.convertToGrayscaleCheckBox, "convertToGrayscaleCheckBox");
            this.convertToGrayscaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawInlineImagesCheckBox
            // 
            this.drawInlineImagesCheckBox.AutoSize = true;
            this.drawInlineImagesCheckBox.Location = new System.Drawing.Point(6, 42);
            this.drawInlineImagesCheckBox.Name = "drawInlineImagesCheckBox";
            this.drawInlineImagesCheckBox.Size = new System.Drawing.Size(116, 17);
            this.drawInlineImagesCheckBox.TabIndex = 1;
            resources.ApplyResources(this.drawInlineImagesCheckBox, "drawInlineImagesCheckBox");
            this.drawInlineImagesCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawImageResourcesCheckBox
            // 
            this.drawImageResourcesCheckBox.AutoSize = true;
            this.drawImageResourcesCheckBox.Location = new System.Drawing.Point(6, 19);
            this.drawImageResourcesCheckBox.Name = "drawImageResourcesCheckBox";
            this.drawImageResourcesCheckBox.Size = new System.Drawing.Size(88, 17);
            this.drawImageResourcesCheckBox.TabIndex = 0;
            resources.ApplyResources(this.drawImageResourcesCheckBox, "drawImageResourcesCheckBox");
            this.drawImageResourcesCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.drawAnnotationsCheckBox);
            this.groupBox3.Controls.Add(this.drawFormsCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(206, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 62);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            resources.ApplyResources(this.groupBox3, "groupBox3");
            // 
            // drawAnnotationsCheckBox
            // 
            this.drawAnnotationsCheckBox.AutoSize = true;
            this.drawAnnotationsCheckBox.Location = new System.Drawing.Point(6, 41);
            this.drawAnnotationsCheckBox.Name = "drawAnnotationsCheckBox";
            this.drawAnnotationsCheckBox.Size = new System.Drawing.Size(110, 17);
            this.drawAnnotationsCheckBox.TabIndex = 6;
            resources.ApplyResources(this.drawAnnotationsCheckBox, "drawAnnotationsCheckBox");
            this.drawAnnotationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawFormsCheckBox
            // 
            this.drawFormsCheckBox.AutoSize = true;
            this.drawFormsCheckBox.Location = new System.Drawing.Point(6, 19);
            this.drawFormsCheckBox.Name = "drawFormsCheckBox";
            this.drawFormsCheckBox.Size = new System.Drawing.Size(82, 17);
            this.drawFormsCheckBox.TabIndex = 5;
            resources.ApplyResources(this.drawFormsCheckBox, "drawFormsCheckBox");
            this.drawFormsCheckBox.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(120, 257);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 17;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(203, 257);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 18;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.drawInvisibleTextCheckBox);
            this.groupBox4.Controls.Add(this.drawTextCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(9, 191);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(191, 62);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Text";
            // 
            // drawInvisibleTextCheckBox
            // 
            this.drawInvisibleTextCheckBox.AutoSize = true;
            this.drawInvisibleTextCheckBox.Location = new System.Drawing.Point(6, 41);
            this.drawInvisibleTextCheckBox.Name = "drawInvisibleTextCheckBox";
            this.drawInvisibleTextCheckBox.Size = new System.Drawing.Size(116, 17);
            this.drawInvisibleTextCheckBox.TabIndex = 6;
            resources.ApplyResources(this.drawInvisibleTextCheckBox, "drawInvisibleTextCheckBox");
            this.drawInvisibleTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawTextCheckBox
            // 
            this.drawTextCheckBox.AutoSize = true;
            this.drawTextCheckBox.Location = new System.Drawing.Point(6, 19);
            this.drawTextCheckBox.Name = "drawTextCheckBox";
            this.drawTextCheckBox.Size = new System.Drawing.Size(75, 17);
            this.drawTextCheckBox.TabIndex = 5;
            resources.ApplyResources(this.drawTextCheckBox, "drawTextCheckBox");
            this.drawTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // CustomContentRendererSettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(398, 288);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.imagesGroupBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomContentRendererSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.linesWeightNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.imagesGroupBox.ResumeLayout(false);
            this.imagesGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox fillPathsCheckBox;
        private System.Windows.Forms.CheckBox useTilingPatternsCheckBox;
        private System.Windows.Forms.CheckBox useShadingPatternsCheckBox;
        private System.Windows.Forms.CheckBox drawPathsCheckBox;
        private System.Windows.Forms.NumericUpDown linesWeightNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox useClipPathsCheckBox;
        private System.Windows.Forms.GroupBox imagesGroupBox;
        private System.Windows.Forms.CheckBox drawInlineImagesCheckBox;
        private System.Windows.Forms.CheckBox drawImageResourcesCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox convertToGrayscaleCheckBox;
        private System.Windows.Forms.CheckBox autoContrastCheckBox;
        private System.Windows.Forms.CheckBox autoLevelsCheckBox;
        private System.Windows.Forms.CheckBox autoColorsCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox drawFormsCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox fillAreaUseShadigPatternsCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox drawInvisibleTextCheckBox;
        private System.Windows.Forms.CheckBox drawTextCheckBox;
        private System.Windows.Forms.CheckBox drawAnnotationsCheckBox;
    }
}