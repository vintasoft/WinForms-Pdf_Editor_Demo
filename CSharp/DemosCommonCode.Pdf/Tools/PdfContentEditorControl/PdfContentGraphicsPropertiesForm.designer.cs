
namespace DemosCommonCode.Pdf
{
    partial class PdfContentGraphicsPropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfContentGraphicsPropertiesForm));
            this.strokeGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lineWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.strokeColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.strokePropertiesCheckBox = new System.Windows.Forms.CheckBox();
            this.fillPropertiesCheckBox = new System.Windows.Forms.CheckBox();
            this.fillGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fillColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textPropertiesCheckBox = new System.Windows.Forms.CheckBox();
            this.textPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.textRenderingModeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.colorBlendingCheckBox = new System.Windows.Forms.CheckBox();
            this.colorBlendingGroupBox = new System.Windows.Forms.GroupBox();
            this.colorBlendingComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.strokeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthNumericUpDown)).BeginInit();
            this.fillGroupBox.SuspendLayout();
            this.textPropertiesGroupBox.SuspendLayout();
            this.colorBlendingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // strokeGroupBox
            // 
            this.strokeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.strokeGroupBox.Controls.Add(this.label3);
            this.strokeGroupBox.Controls.Add(this.lineWidthNumericUpDown);
            this.strokeGroupBox.Controls.Add(this.label1);
            this.strokeGroupBox.Controls.Add(this.strokeColorPanelControl);
            this.strokeGroupBox.Enabled = false;
            this.strokeGroupBox.Location = new System.Drawing.Point(12, 116);
            this.strokeGroupBox.Name = "strokeGroupBox";
            this.strokeGroupBox.Size = new System.Drawing.Size(260, 80);
            this.strokeGroupBox.TabIndex = 2;
            this.strokeGroupBox.TabStop = false;
            resources.ApplyResources(this.strokeGroupBox, "strokeGroupBox");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            resources.ApplyResources(this.label3, "label3");
            // 
            // lineWidthNumericUpDown
            // 
            this.lineWidthNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineWidthNumericUpDown.Location = new System.Drawing.Point(133, 47);
            this.lineWidthNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineWidthNumericUpDown.Name = "lineWidthNumericUpDown";
            this.lineWidthNumericUpDown.Size = new System.Drawing.Size(121, 20);
            this.lineWidthNumericUpDown.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            resources.ApplyResources(this.label1, "label1");
            // 
            // strokeColorPanelControl
            // 
            this.strokeColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.strokeColorPanelControl.Color = System.Drawing.Color.Black;
            this.strokeColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.strokeColorPanelControl.Location = new System.Drawing.Point(133, 19);
            this.strokeColorPanelControl.Name = "strokeColorPanelControl";
            this.strokeColorPanelControl.Size = new System.Drawing.Size(121, 22);
            this.strokeColorPanelControl.TabIndex = 0;
            // 
            // strokePropertiesCheckBox
            // 
            this.strokePropertiesCheckBox.AutoSize = true;
            this.strokePropertiesCheckBox.Location = new System.Drawing.Point(12, 97);
            this.strokePropertiesCheckBox.Name = "strokePropertiesCheckBox";
            this.strokePropertiesCheckBox.Size = new System.Drawing.Size(126, 17);
            this.strokePropertiesCheckBox.TabIndex = 3;
            resources.ApplyResources(this.strokePropertiesCheckBox, "strokePropertiesCheckBox");
            this.strokePropertiesCheckBox.UseVisualStyleBackColor = true;
            this.strokePropertiesCheckBox.CheckedChanged += new System.EventHandler(this.strokePropertiesCheckBox_CheckedChanged);
            // 
            // fillPropertiesCheckBox
            // 
            this.fillPropertiesCheckBox.AutoSize = true;
            this.fillPropertiesCheckBox.Location = new System.Drawing.Point(12, 16);
            this.fillPropertiesCheckBox.Name = "fillPropertiesCheckBox";
            this.fillPropertiesCheckBox.Size = new System.Drawing.Size(107, 17);
            this.fillPropertiesCheckBox.TabIndex = 4;
            resources.ApplyResources(this.fillPropertiesCheckBox, "fillPropertiesCheckBox");
            this.fillPropertiesCheckBox.UseVisualStyleBackColor = true;
            this.fillPropertiesCheckBox.CheckedChanged += new System.EventHandler(this.fillPropertiesCheckBox_CheckedChanged);
            // 
            // fillGroupBox
            // 
            this.fillGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fillGroupBox.Controls.Add(this.label2);
            this.fillGroupBox.Controls.Add(this.fillColorPanelControl);
            this.fillGroupBox.Enabled = false;
            this.fillGroupBox.Location = new System.Drawing.Point(12, 35);
            this.fillGroupBox.Name = "fillGroupBox";
            this.fillGroupBox.Size = new System.Drawing.Size(260, 52);
            this.fillGroupBox.TabIndex = 3;
            this.fillGroupBox.TabStop = false;
            resources.ApplyResources(this.fillGroupBox, "fillGroupBox");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            resources.ApplyResources(this.label2, "label2");
            // 
            // fillColorPanelControl
            // 
            this.fillColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fillColorPanelControl.Color = System.Drawing.Color.Black;
            this.fillColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.fillColorPanelControl.Location = new System.Drawing.Point(133, 19);
            this.fillColorPanelControl.Name = "fillColorPanelControl";
            this.fillColorPanelControl.Size = new System.Drawing.Size(121, 22);
            this.fillColorPanelControl.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(116, 355);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(197, 355);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textPropertiesCheckBox
            // 
            this.textPropertiesCheckBox.AutoSize = true;
            this.textPropertiesCheckBox.Location = new System.Drawing.Point(12, 280);
            this.textPropertiesCheckBox.Name = "textPropertiesCheckBox";
            this.textPropertiesCheckBox.Size = new System.Drawing.Size(116, 17);
            this.textPropertiesCheckBox.TabIndex = 7;
            resources.ApplyResources(this.textPropertiesCheckBox, "textPropertiesCheckBox");
            this.textPropertiesCheckBox.UseVisualStyleBackColor = true;
            this.textPropertiesCheckBox.CheckedChanged += new System.EventHandler(this.textPropertiesCheckBox_CheckedChanged);
            // 
            // textPropertiesGroupBox
            // 
            this.textPropertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPropertiesGroupBox.Controls.Add(this.textRenderingModeComboBox);
            this.textPropertiesGroupBox.Controls.Add(this.label4);
            this.textPropertiesGroupBox.Enabled = false;
            this.textPropertiesGroupBox.Location = new System.Drawing.Point(12, 299);
            this.textPropertiesGroupBox.Name = "textPropertiesGroupBox";
            this.textPropertiesGroupBox.Size = new System.Drawing.Size(260, 48);
            this.textPropertiesGroupBox.TabIndex = 4;
            this.textPropertiesGroupBox.TabStop = false;
            resources.ApplyResources(this.textPropertiesGroupBox, "textPropertiesGroupBox");
            // 
            // textRenderingModeComboBox
            // 
            this.textRenderingModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textRenderingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textRenderingModeComboBox.FormattingEnabled = true;
            this.textRenderingModeComboBox.Location = new System.Drawing.Point(133, 19);
            this.textRenderingModeComboBox.Name = "textRenderingModeComboBox";
            this.textRenderingModeComboBox.Size = new System.Drawing.Size(121, 21);
            this.textRenderingModeComboBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 2;
            resources.ApplyResources(this.label4, "label4");
            // 
            // colorBlendingCheckBox
            // 
            this.colorBlendingCheckBox.AutoSize = true;
            this.colorBlendingCheckBox.Location = new System.Drawing.Point(12, 202);
            this.colorBlendingCheckBox.Name = "colorBlendingCheckBox";
            this.colorBlendingCheckBox.Size = new System.Drawing.Size(113, 17);
            this.colorBlendingCheckBox.TabIndex = 8;
            resources.ApplyResources(this.colorBlendingCheckBox, "colorBlendingCheckBox");
            this.colorBlendingCheckBox.UseVisualStyleBackColor = true;
            this.colorBlendingCheckBox.CheckedChanged += new System.EventHandler(this.colorBlendingCheckBox_CheckedChanged);
            // 
            // colorBlendingGroupBox
            // 
            this.colorBlendingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorBlendingGroupBox.Controls.Add(this.colorBlendingComboBox);
            this.colorBlendingGroupBox.Controls.Add(this.label5);
            this.colorBlendingGroupBox.Enabled = false;
            this.colorBlendingGroupBox.Location = new System.Drawing.Point(12, 224);
            this.colorBlendingGroupBox.Name = "colorBlendingGroupBox";
            this.colorBlendingGroupBox.Size = new System.Drawing.Size(260, 48);
            this.colorBlendingGroupBox.TabIndex = 5;
            this.colorBlendingGroupBox.TabStop = false;
            resources.ApplyResources(this.colorBlendingGroupBox, "colorBlendingGroupBox");
            // 
            // colorBlendingComboBox
            // 
            this.colorBlendingComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colorBlendingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorBlendingComboBox.FormattingEnabled = true;
            this.colorBlendingComboBox.Location = new System.Drawing.Point(133, 19);
            this.colorBlendingComboBox.Name = "colorBlendingComboBox";
            this.colorBlendingComboBox.Size = new System.Drawing.Size(121, 21);
            this.colorBlendingComboBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 2;
            resources.ApplyResources(this.label5, "label5");
            // 
            // PdfContentGraphicsPropertiesForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 389);
            this.Controls.Add(this.colorBlendingGroupBox);
            this.Controls.Add(this.colorBlendingCheckBox);
            this.Controls.Add(this.textPropertiesGroupBox);
            this.Controls.Add(this.textPropertiesCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.fillGroupBox);
            this.Controls.Add(this.fillPropertiesCheckBox);
            this.Controls.Add(this.strokePropertiesCheckBox);
            this.Controls.Add(this.strokeGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PdfContentGraphicsPropertiesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            resources.ApplyResources(this, "$this");
            this.strokeGroupBox.ResumeLayout(false);
            this.strokeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthNumericUpDown)).EndInit();
            this.fillGroupBox.ResumeLayout(false);
            this.fillGroupBox.PerformLayout();
            this.textPropertiesGroupBox.ResumeLayout(false);
            this.textPropertiesGroupBox.PerformLayout();
            this.colorBlendingGroupBox.ResumeLayout(false);
            this.colorBlendingGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DemosCommonCode.CustomControls.ColorPanelControl strokeColorPanelControl;
        private System.Windows.Forms.GroupBox strokeGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown lineWidthNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox strokePropertiesCheckBox;
        private System.Windows.Forms.CheckBox fillPropertiesCheckBox;
        private System.Windows.Forms.GroupBox fillGroupBox;
        private System.Windows.Forms.Label label2;
        private DemosCommonCode.CustomControls.ColorPanelControl fillColorPanelControl;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox textPropertiesCheckBox;
        private System.Windows.Forms.GroupBox textPropertiesGroupBox;
        private System.Windows.Forms.ComboBox textRenderingModeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox colorBlendingCheckBox;
        private System.Windows.Forms.GroupBox colorBlendingGroupBox;
        private System.Windows.Forms.ComboBox colorBlendingComboBox;
        private System.Windows.Forms.Label label5;
    }
}