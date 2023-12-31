namespace DemosCommonCode.Imaging.ColorManagement
{
    partial class ColorManagementSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorManagementSettingsForm));
            this.inputProfilesGroupBox = new System.Windows.Forms.GroupBox();
            this.removeInputGrayscaleButton = new System.Windows.Forms.Button();
            this.removeInputRgbButton = new System.Windows.Forms.Button();
            this.removeInputCmykButton = new System.Windows.Forms.Button();
            this.inputGrayscaleTextBox = new System.Windows.Forms.TextBox();
            this.useEmbeddedProfilesCheckBox = new System.Windows.Forms.CheckBox();
            this.inputRgbTextBox = new System.Windows.Forms.TextBox();
            this.inputCmykTextBox = new System.Windows.Forms.TextBox();
            this.inputGrayscaleLabel = new System.Windows.Forms.Label();
            this.inputRgbLabel = new System.Windows.Forms.Label();
            this.inputCmykLabel = new System.Windows.Forms.Label();
            this.setInputProfileButton = new System.Windows.Forms.Button();
            this.editColorTransformsButton = new System.Windows.Forms.Button();
            this.enableColorManagementCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.outputProfilesGroupBox = new System.Windows.Forms.GroupBox();
            this.removeOutputGrayscaleButton = new System.Windows.Forms.Button();
            this.removeOutputRgbButton = new System.Windows.Forms.Button();
            this.outputGrayscaleTextBox = new System.Windows.Forms.TextBox();
            this.outputRgbTextBox = new System.Windows.Forms.TextBox();
            this.outputGrayscaleLabel = new System.Windows.Forms.Label();
            this.outputRgbLabel = new System.Windows.Forms.Label();
            this.setOutputProfileButton = new System.Windows.Forms.Button();
            this.intentComboBox = new System.Windows.Forms.ComboBox();
            this.intentLabel = new System.Windows.Forms.Label();
            this.blackPointCompensationCheckBox = new System.Windows.Forms.CheckBox();
            this.decodingSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inputProfilesGroupBox.SuspendLayout();
            this.outputProfilesGroupBox.SuspendLayout();
            this.decodingSettingsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputProfilesGroupBox
            // 
            this.inputProfilesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputProfilesGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.inputProfilesGroupBox.Controls.Add(this.removeInputGrayscaleButton);
            this.inputProfilesGroupBox.Controls.Add(this.removeInputRgbButton);
            this.inputProfilesGroupBox.Controls.Add(this.removeInputCmykButton);
            this.inputProfilesGroupBox.Controls.Add(this.inputGrayscaleTextBox);
            this.inputProfilesGroupBox.Controls.Add(this.inputRgbTextBox);
            this.inputProfilesGroupBox.Controls.Add(this.inputCmykTextBox);
            this.inputProfilesGroupBox.Controls.Add(this.inputGrayscaleLabel);
            this.inputProfilesGroupBox.Controls.Add(this.inputRgbLabel);
            this.inputProfilesGroupBox.Controls.Add(this.inputCmykLabel);
            this.inputProfilesGroupBox.Location = new System.Drawing.Point(6, 19);
            this.inputProfilesGroupBox.Name = "inputProfilesGroupBox";
            this.inputProfilesGroupBox.Size = new System.Drawing.Size(573, 121);
            this.inputProfilesGroupBox.TabIndex = 0;
            this.inputProfilesGroupBox.TabStop = false;
            resources.ApplyResources(this.inputProfilesGroupBox, "inputProfilesGroupBox");
            // 
            // removeInputGrayscaleButton
            // 
            this.removeInputGrayscaleButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeInputGrayscaleButton.Location = new System.Drawing.Point(547, 95);
            this.removeInputGrayscaleButton.Name = "removeInputGrayscaleButton";
            this.removeInputGrayscaleButton.Size = new System.Drawing.Size(20, 20);
            this.removeInputGrayscaleButton.TabIndex = 14;
            this.removeInputGrayscaleButton.Text = "X";
            this.removeInputGrayscaleButton.UseVisualStyleBackColor = true;
            this.removeInputGrayscaleButton.Click += new System.EventHandler(this.removeInputGrayscaleButton_Click);
            // 
            // removeInputRgbButton
            // 
            this.removeInputRgbButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeInputRgbButton.Location = new System.Drawing.Point(547, 72);
            this.removeInputRgbButton.Name = "removeInputRgbButton";
            this.removeInputRgbButton.Size = new System.Drawing.Size(20, 20);
            this.removeInputRgbButton.TabIndex = 13;
            this.removeInputRgbButton.Text = "X";
            this.removeInputRgbButton.UseVisualStyleBackColor = true;
            this.removeInputRgbButton.Click += new System.EventHandler(this.removeInputRgbButton_Click);
            // 
            // removeInputCmykButton
            // 
            this.removeInputCmykButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeInputCmykButton.Location = new System.Drawing.Point(547, 49);
            this.removeInputCmykButton.Name = "removeInputCmykButton";
            this.removeInputCmykButton.Size = new System.Drawing.Size(20, 20);
            this.removeInputCmykButton.TabIndex = 12;
            this.removeInputCmykButton.Text = "X";
            this.removeInputCmykButton.UseVisualStyleBackColor = true;
            this.removeInputCmykButton.Click += new System.EventHandler(this.removeInputCmykButton_Click);
            // 
            // inputGrayscaleTextBox
            // 
            this.inputGrayscaleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputGrayscaleTextBox.Location = new System.Drawing.Point(97, 95);
            this.inputGrayscaleTextBox.Name = "inputGrayscaleTextBox";
            this.inputGrayscaleTextBox.ReadOnly = true;
            this.inputGrayscaleTextBox.Size = new System.Drawing.Size(444, 20);
            this.inputGrayscaleTextBox.TabIndex = 11;
            // 
            // useEmbeddedProfilesCheckBox
            // 
            this.useEmbeddedProfilesCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.useEmbeddedProfilesCheckBox.AutoSize = true;
            this.useEmbeddedProfilesCheckBox.Location = new System.Drawing.Point(167, 6);
            this.useEmbeddedProfilesCheckBox.Name = "useEmbeddedProfilesCheckBox";
            this.useEmbeddedProfilesCheckBox.Size = new System.Drawing.Size(155, 17);
            this.useEmbeddedProfilesCheckBox.TabIndex = 5;
            resources.ApplyResources(this.useEmbeddedProfilesCheckBox, "useEmbeddedProfilesCheckBox");
            this.useEmbeddedProfilesCheckBox.UseVisualStyleBackColor = true;
            // 
            // inputRgbTextBox
            // 
            this.inputRgbTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputRgbTextBox.Location = new System.Drawing.Point(97, 72);
            this.inputRgbTextBox.Name = "inputRgbTextBox";
            this.inputRgbTextBox.ReadOnly = true;
            this.inputRgbTextBox.Size = new System.Drawing.Size(444, 20);
            this.inputRgbTextBox.TabIndex = 10;
            // 
            // inputCmykTextBox
            // 
            this.inputCmykTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputCmykTextBox.Location = new System.Drawing.Point(97, 49);
            this.inputCmykTextBox.Name = "inputCmykTextBox";
            this.inputCmykTextBox.ReadOnly = true;
            this.inputCmykTextBox.Size = new System.Drawing.Size(444, 20);
            this.inputCmykTextBox.TabIndex = 9;
            // 
            // inputGrayscaleLabel
            // 
            this.inputGrayscaleLabel.AutoSize = true;
            this.inputGrayscaleLabel.Location = new System.Drawing.Point(7, 98);
            this.inputGrayscaleLabel.Name = "inputGrayscaleLabel";
            this.inputGrayscaleLabel.Size = new System.Drawing.Size(54, 13);
            this.inputGrayscaleLabel.TabIndex = 8;
            this.inputGrayscaleLabel.Text = "Grayscale";
            // 
            // inputRgbLabel
            // 
            this.inputRgbLabel.AutoSize = true;
            this.inputRgbLabel.Location = new System.Drawing.Point(7, 75);
            this.inputRgbLabel.Name = "inputRgbLabel";
            this.inputRgbLabel.Size = new System.Drawing.Size(30, 13);
            this.inputRgbLabel.TabIndex = 7;
            this.inputRgbLabel.Text = "RGB";
            // 
            // inputCmykLabel
            // 
            this.inputCmykLabel.AutoSize = true;
            this.inputCmykLabel.Location = new System.Drawing.Point(7, 52);
            this.inputCmykLabel.Name = "inputCmykLabel";
            this.inputCmykLabel.Size = new System.Drawing.Size(37, 13);
            this.inputCmykLabel.TabIndex = 6;
            this.inputCmykLabel.Text = "CMYK";
            // 
            // setInputProfileButton
            // 
            this.setInputProfileButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.setInputProfileButton.AutoSize = true;
            this.setInputProfileButton.Location = new System.Drawing.Point(3, 3);
            this.setInputProfileButton.Name = "setInputProfileButton";
            this.setInputProfileButton.Size = new System.Drawing.Size(158, 23);
            this.setInputProfileButton.TabIndex = 4;
            resources.ApplyResources(this.setInputProfileButton, "setInputProfileButton");
            this.setInputProfileButton.UseVisualStyleBackColor = true;
            this.setInputProfileButton.Click += new System.EventHandler(this.setInputProfileButton_Click);
            // 
            // editColorTransformsButton
            // 
            this.editColorTransformsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.editColorTransformsButton.AutoSize = true;
            this.editColorTransformsButton.Location = new System.Drawing.Point(6, 19);
            this.editColorTransformsButton.Name = "editColorTransformsButton";
            this.editColorTransformsButton.Size = new System.Drawing.Size(188, 23);
            this.editColorTransformsButton.TabIndex = 3;
            resources.ApplyResources(this.editColorTransformsButton, "editColorTransformsButton");
            this.editColorTransformsButton.UseVisualStyleBackColor = true;
            this.editColorTransformsButton.Click += new System.EventHandler(this.editColorTransformsButton_Click);
            // 
            // enableColorManagementCheckBox
            // 
            this.enableColorManagementCheckBox.AutoSize = true;
            this.enableColorManagementCheckBox.Location = new System.Drawing.Point(9, 6);
            this.enableColorManagementCheckBox.Name = "enableColorManagementCheckBox";
            this.enableColorManagementCheckBox.Size = new System.Drawing.Size(149, 17);
            this.enableColorManagementCheckBox.TabIndex = 0;
            resources.ApplyResources(this.enableColorManagementCheckBox, "enableColorManagementCheckBox");
            this.enableColorManagementCheckBox.UseVisualStyleBackColor = true;
            this.enableColorManagementCheckBox.CheckedChanged += new System.EventHandler(this.enableColorManagementCheckBox_CheckedChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(221, 371);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(305, 371);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // outputProfilesGroupBox
            // 
            this.outputProfilesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputProfilesGroupBox.Controls.Add(this.removeOutputGrayscaleButton);
            this.outputProfilesGroupBox.Controls.Add(this.removeOutputRgbButton);
            this.outputProfilesGroupBox.Controls.Add(this.outputGrayscaleTextBox);
            this.outputProfilesGroupBox.Controls.Add(this.outputRgbTextBox);
            this.outputProfilesGroupBox.Controls.Add(this.outputGrayscaleLabel);
            this.outputProfilesGroupBox.Controls.Add(this.outputRgbLabel);
            this.outputProfilesGroupBox.Controls.Add(this.setOutputProfileButton);
            this.outputProfilesGroupBox.Location = new System.Drawing.Point(6, 146);
            this.outputProfilesGroupBox.Name = "outputProfilesGroupBox";
            this.outputProfilesGroupBox.Size = new System.Drawing.Size(573, 96);
            this.outputProfilesGroupBox.TabIndex = 12;
            this.outputProfilesGroupBox.TabStop = false;
            resources.ApplyResources(this.outputProfilesGroupBox, "outputProfilesGroupBox");
            // 
            // removeOutputGrayscaleButton
            // 
            this.removeOutputGrayscaleButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeOutputGrayscaleButton.Location = new System.Drawing.Point(547, 69);
            this.removeOutputGrayscaleButton.Name = "removeOutputGrayscaleButton";
            this.removeOutputGrayscaleButton.Size = new System.Drawing.Size(20, 20);
            this.removeOutputGrayscaleButton.TabIndex = 16;
            this.removeOutputGrayscaleButton.Text = "X";
            this.removeOutputGrayscaleButton.UseVisualStyleBackColor = true;
            this.removeOutputGrayscaleButton.Click += new System.EventHandler(this.removeOutputGrayscaleButton_Click);
            // 
            // removeOutputRgbButton
            // 
            this.removeOutputRgbButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeOutputRgbButton.Location = new System.Drawing.Point(547, 46);
            this.removeOutputRgbButton.Name = "removeOutputRgbButton";
            this.removeOutputRgbButton.Size = new System.Drawing.Size(20, 20);
            this.removeOutputRgbButton.TabIndex = 15;
            this.removeOutputRgbButton.Text = "X";
            this.removeOutputRgbButton.UseVisualStyleBackColor = true;
            this.removeOutputRgbButton.Click += new System.EventHandler(this.removeOutputRgbButton_Click);
            // 
            // outputGrayscaleTextBox
            // 
            this.outputGrayscaleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputGrayscaleTextBox.Location = new System.Drawing.Point(97, 69);
            this.outputGrayscaleTextBox.Name = "outputGrayscaleTextBox";
            this.outputGrayscaleTextBox.ReadOnly = true;
            this.outputGrayscaleTextBox.Size = new System.Drawing.Size(444, 20);
            this.outputGrayscaleTextBox.TabIndex = 11;
            // 
            // outputRgbTextBox
            // 
            this.outputRgbTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputRgbTextBox.Location = new System.Drawing.Point(97, 46);
            this.outputRgbTextBox.Name = "outputRgbTextBox";
            this.outputRgbTextBox.ReadOnly = true;
            this.outputRgbTextBox.Size = new System.Drawing.Size(444, 20);
            this.outputRgbTextBox.TabIndex = 10;
            // 
            // outputGrayscaleLabel
            // 
            this.outputGrayscaleLabel.AutoSize = true;
            this.outputGrayscaleLabel.Location = new System.Drawing.Point(7, 71);
            this.outputGrayscaleLabel.Name = "outputGrayscaleLabel";
            this.outputGrayscaleLabel.Size = new System.Drawing.Size(54, 13);
            this.outputGrayscaleLabel.TabIndex = 8;
            this.outputGrayscaleLabel.Text = "Grayscale";
            // 
            // outputRgbLabel
            // 
            this.outputRgbLabel.AutoSize = true;
            this.outputRgbLabel.Location = new System.Drawing.Point(7, 48);
            this.outputRgbLabel.Name = "outputRgbLabel";
            this.outputRgbLabel.Size = new System.Drawing.Size(30, 13);
            this.outputRgbLabel.TabIndex = 7;
            this.outputRgbLabel.Text = "RGB";
            // 
            // setOutputProfileButton
            // 
            this.setOutputProfileButton.AutoSize = true;
            this.setOutputProfileButton.Location = new System.Drawing.Point(96, 19);
            this.setOutputProfileButton.Name = "setOutputProfileButton";
            this.setOutputProfileButton.Size = new System.Drawing.Size(159, 23);
            this.setOutputProfileButton.TabIndex = 4;
            resources.ApplyResources(this.setOutputProfileButton, "setOutputProfileButton");
            this.setOutputProfileButton.UseVisualStyleBackColor = true;
            this.setOutputProfileButton.Click += new System.EventHandler(this.setOutputProfileButton_Click);
            // 
            // intentComboBox
            // 
            this.intentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intentComboBox.FormattingEnabled = true;
            this.intentComboBox.Location = new System.Drawing.Point(14, 272);
            this.intentComboBox.Name = "intentComboBox";
            this.intentComboBox.Size = new System.Drawing.Size(158, 21);
            this.intentComboBox.TabIndex = 13;
            // 
            // intentLabel
            // 
            this.intentLabel.AutoSize = true;
            this.intentLabel.Location = new System.Drawing.Point(11, 256);
            this.intentLabel.Name = "intentLabel";
            this.intentLabel.Size = new System.Drawing.Size(85, 13);
            this.intentLabel.TabIndex = 14;
            resources.ApplyResources(this.intentLabel, "intentLabel");
            // 
            // blackPointCompensationCheckBox
            // 
            this.blackPointCompensationCheckBox.AutoSize = true;
            this.blackPointCompensationCheckBox.Location = new System.Drawing.Point(14, 299);
            this.blackPointCompensationCheckBox.Name = "blackPointCompensationCheckBox";
            this.blackPointCompensationCheckBox.Size = new System.Drawing.Size(169, 17);
            this.blackPointCompensationCheckBox.TabIndex = 15;
            resources.ApplyResources(this.blackPointCompensationCheckBox, "blackPointCompensationCheckBox");
            this.blackPointCompensationCheckBox.UseVisualStyleBackColor = true;
            // 
            // decodingSettingsGroupBox
            // 
            this.decodingSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.decodingSettingsGroupBox.Controls.Add(this.groupBox1);
            this.decodingSettingsGroupBox.Controls.Add(this.inputProfilesGroupBox);
            this.decodingSettingsGroupBox.Controls.Add(this.blackPointCompensationCheckBox);
            this.decodingSettingsGroupBox.Controls.Add(this.intentLabel);
            this.decodingSettingsGroupBox.Controls.Add(this.outputProfilesGroupBox);
            this.decodingSettingsGroupBox.Controls.Add(this.intentComboBox);
            this.decodingSettingsGroupBox.Enabled = false;
            this.decodingSettingsGroupBox.Location = new System.Drawing.Point(9, 29);
            this.decodingSettingsGroupBox.Name = "decodingSettingsGroupBox";
            this.decodingSettingsGroupBox.Size = new System.Drawing.Size(585, 328);
            this.decodingSettingsGroupBox.TabIndex = 16;
            this.decodingSettingsGroupBox.TabStop = false;
            resources.ApplyResources(this.decodingSettingsGroupBox, "decodingSettingsGroupBox");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.editColorTransformsButton);
            this.groupBox1.Location = new System.Drawing.Point(379, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 61);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.useEmbeddedProfilesCheckBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.setInputProfileButton, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(96, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 30);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // ColorManagementSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(606, 401);
            this.Controls.Add(this.decodingSettingsGroupBox);
            this.Controls.Add(this.enableColorManagementCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorManagementSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            resources.ApplyResources(this, "$this");
            this.inputProfilesGroupBox.ResumeLayout(false);
            this.inputProfilesGroupBox.PerformLayout();
            this.outputProfilesGroupBox.ResumeLayout(false);
            this.outputProfilesGroupBox.PerformLayout();
            this.decodingSettingsGroupBox.ResumeLayout(false);
            this.decodingSettingsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox inputProfilesGroupBox;
        private System.Windows.Forms.CheckBox enableColorManagementCheckBox;
        private System.Windows.Forms.Button editColorTransformsButton;
        private System.Windows.Forms.Button setInputProfileButton;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox useEmbeddedProfilesCheckBox;
        private System.Windows.Forms.Label inputCmykLabel;
        private System.Windows.Forms.TextBox inputGrayscaleTextBox;
        private System.Windows.Forms.TextBox inputRgbTextBox;
        private System.Windows.Forms.TextBox inputCmykTextBox;
        private System.Windows.Forms.Label inputGrayscaleLabel;
        private System.Windows.Forms.Label inputRgbLabel;
        private System.Windows.Forms.GroupBox outputProfilesGroupBox;
        private System.Windows.Forms.TextBox outputGrayscaleTextBox;
        private System.Windows.Forms.TextBox outputRgbTextBox;
        private System.Windows.Forms.Label outputGrayscaleLabel;
        private System.Windows.Forms.Label outputRgbLabel;
        private System.Windows.Forms.Button setOutputProfileButton;
        private System.Windows.Forms.ComboBox intentComboBox;
        private System.Windows.Forms.Label intentLabel;
        private System.Windows.Forms.CheckBox blackPointCompensationCheckBox;
        private System.Windows.Forms.GroupBox decodingSettingsGroupBox;
        private System.Windows.Forms.Button removeInputCmykButton;
        private System.Windows.Forms.Button removeInputGrayscaleButton;
        private System.Windows.Forms.Button removeInputRgbButton;
        private System.Windows.Forms.Button removeOutputGrayscaleButton;
        private System.Windows.Forms.Button removeOutputRgbButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}