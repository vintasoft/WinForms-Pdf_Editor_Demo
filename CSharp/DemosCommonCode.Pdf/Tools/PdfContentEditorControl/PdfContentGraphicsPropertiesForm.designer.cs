
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.strokeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthNumericUpDown)).BeginInit();
            this.fillGroupBox.SuspendLayout();
            this.textPropertiesGroupBox.SuspendLayout();
            this.colorBlendingGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // strokeGroupBox
            // 
            this.strokeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.strokeGroupBox.AutoSize = true;
            this.strokeGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.strokeGroupBox.Enabled = false;
            this.strokeGroupBox.Location = new System.Drawing.Point(3, 108);
            this.strokeGroupBox.Name = "strokeGroupBox";
            this.strokeGroupBox.Size = new System.Drawing.Size(255, 75);
            this.strokeGroupBox.TabIndex = 2;
            this.strokeGroupBox.TabStop = false;
            resources.ApplyResources(this.strokeGroupBox, "strokeGroupBox");
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            resources.ApplyResources(this.label3, "label3");
            // 
            // lineWidthNumericUpDown
            // 
            this.lineWidthNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lineWidthNumericUpDown.Location = new System.Drawing.Point(125, 32);
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
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            resources.ApplyResources(this.label1, "label1");
            // 
            // strokeColorPanelControl
            // 
            this.strokeColorPanelControl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.strokeColorPanelControl.Color = System.Drawing.Color.Black;
            this.strokeColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.strokeColorPanelControl.Location = new System.Drawing.Point(125, 3);
            this.strokeColorPanelControl.Name = "strokeColorPanelControl";
            this.strokeColorPanelControl.Size = new System.Drawing.Size(121, 22);
            this.strokeColorPanelControl.TabIndex = 0;
            // 
            // strokePropertiesCheckBox
            // 
            this.strokePropertiesCheckBox.AutoSize = true;
            this.strokePropertiesCheckBox.Location = new System.Drawing.Point(3, 85);
            this.strokePropertiesCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
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
            this.fillPropertiesCheckBox.Location = new System.Drawing.Point(3, 6);
            this.fillPropertiesCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
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
            this.fillGroupBox.AutoSize = true;
            this.fillGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.fillGroupBox.Enabled = false;
            this.fillGroupBox.Location = new System.Drawing.Point(3, 29);
            this.fillGroupBox.Name = "fillGroupBox";
            this.fillGroupBox.Size = new System.Drawing.Size(255, 47);
            this.fillGroupBox.TabIndex = 3;
            this.fillGroupBox.TabStop = false;
            resources.ApplyResources(this.fillGroupBox, "fillGroupBox");
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            resources.ApplyResources(this.label2, "label2");
            // 
            // fillColorPanelControl
            // 
            this.fillColorPanelControl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.fillColorPanelControl.Color = System.Drawing.Color.Black;
            this.fillColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.fillColorPanelControl.Location = new System.Drawing.Point(125, 3);
            this.fillColorPanelControl.Name = "fillColorPanelControl";
            this.fillColorPanelControl.Size = new System.Drawing.Size(121, 22);
            this.fillColorPanelControl.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(114, 364);
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
            this.buttonCancel.Location = new System.Drawing.Point(195, 364);
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
            this.textPropertiesCheckBox.Location = new System.Drawing.Point(3, 270);
            this.textPropertiesCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
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
            this.textPropertiesGroupBox.AutoSize = true;
            this.textPropertiesGroupBox.Controls.Add(this.tableLayoutPanel4);
            this.textPropertiesGroupBox.Enabled = false;
            this.textPropertiesGroupBox.Location = new System.Drawing.Point(3, 293);
            this.textPropertiesGroupBox.Name = "textPropertiesGroupBox";
            this.textPropertiesGroupBox.Size = new System.Drawing.Size(255, 46);
            this.textPropertiesGroupBox.TabIndex = 4;
            this.textPropertiesGroupBox.TabStop = false;
            resources.ApplyResources(this.textPropertiesGroupBox, "textPropertiesGroupBox");
            // 
            // textRenderingModeComboBox
            // 
            this.textRenderingModeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textRenderingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textRenderingModeComboBox.FormattingEnabled = true;
            this.textRenderingModeComboBox.Location = new System.Drawing.Point(125, 3);
            this.textRenderingModeComboBox.Name = "textRenderingModeComboBox";
            this.textRenderingModeComboBox.Size = new System.Drawing.Size(121, 21);
            this.textRenderingModeComboBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 2;
            resources.ApplyResources(this.label4, "label4");
            // 
            // colorBlendingCheckBox
            // 
            this.colorBlendingCheckBox.AutoSize = true;
            this.colorBlendingCheckBox.Location = new System.Drawing.Point(3, 192);
            this.colorBlendingCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
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
            this.colorBlendingGroupBox.AutoSize = true;
            this.colorBlendingGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.colorBlendingGroupBox.Enabled = false;
            this.colorBlendingGroupBox.Location = new System.Drawing.Point(3, 215);
            this.colorBlendingGroupBox.Name = "colorBlendingGroupBox";
            this.colorBlendingGroupBox.Size = new System.Drawing.Size(255, 46);
            this.colorBlendingGroupBox.TabIndex = 5;
            this.colorBlendingGroupBox.TabStop = false;
            resources.ApplyResources(this.colorBlendingGroupBox, "colorBlendingGroupBox");
            // 
            // colorBlendingComboBox
            // 
            this.colorBlendingComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.colorBlendingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorBlendingComboBox.FormattingEnabled = true;
            this.colorBlendingComboBox.Location = new System.Drawing.Point(125, 3);
            this.colorBlendingComboBox.Name = "colorBlendingComboBox";
            this.colorBlendingComboBox.Size = new System.Drawing.Size(121, 21);
            this.colorBlendingComboBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 2;
            resources.ApplyResources(this.label5, "label5");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.fillColorPanelControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(249, 28);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lineWidthNumericUpDown, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.strokeColorPanelControl, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(249, 56);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.colorBlendingComboBox, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(249, 27);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.textRenderingModeComboBox, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(249, 27);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.fillPropertiesCheckBox, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.textPropertiesGroupBox, 0, 7);
            this.tableLayoutPanel5.Controls.Add(this.colorBlendingGroupBox, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.textPropertiesCheckBox, 0, 6);
            this.tableLayoutPanel5.Controls.Add(this.fillGroupBox, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.colorBlendingCheckBox, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.strokePropertiesCheckBox, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.strokeGroupBox, 0, 3);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 8;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(261, 342);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // PdfContentGraphicsPropertiesForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(279, 399);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}