
namespace DemosCommonCode.Pdf
{
    partial class PdfResourceGraphicsPropertiesForm
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.colorBlendingCheckBox = new System.Windows.Forms.CheckBox();
            this.colorBlendingGroupBox = new System.Windows.Forms.GroupBox();
            this.colorBlendingComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.alphaConstantCheckBox = new System.Windows.Forms.CheckBox();
            this.alphaConstantValueEditor = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.colorBlendingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(116, 192);
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
            this.buttonCancel.Location = new System.Drawing.Point(197, 192);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // colorBlendingCheckBox
            // 
            this.colorBlendingCheckBox.AutoSize = true;
            this.colorBlendingCheckBox.Location = new System.Drawing.Point(12, 116);
            this.colorBlendingCheckBox.Name = "colorBlendingCheckBox";
            this.colorBlendingCheckBox.Size = new System.Drawing.Size(113, 17);
            this.colorBlendingCheckBox.TabIndex = 8;
            this.colorBlendingCheckBox.Text = "Set Color Blending";
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
            this.colorBlendingGroupBox.Location = new System.Drawing.Point(12, 138);
            this.colorBlendingGroupBox.Name = "colorBlendingGroupBox";
            this.colorBlendingGroupBox.Size = new System.Drawing.Size(260, 48);
            this.colorBlendingGroupBox.TabIndex = 5;
            this.colorBlendingGroupBox.TabStop = false;
            this.colorBlendingGroupBox.Text = "Color Blending";
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
            this.label5.Text = "Color Blending Mode";
            // 
            // alphaConstantCheckBox
            // 
            this.alphaConstantCheckBox.AutoSize = true;
            this.alphaConstantCheckBox.Location = new System.Drawing.Point(12, 12);
            this.alphaConstantCheckBox.Name = "alphaConstantCheckBox";
            this.alphaConstantCheckBox.Size = new System.Drawing.Size(117, 17);
            this.alphaConstantCheckBox.TabIndex = 9;
            this.alphaConstantCheckBox.Text = "Set Alpha Constant";
            this.alphaConstantCheckBox.UseVisualStyleBackColor = true;
            this.alphaConstantCheckBox.CheckedChanged += new System.EventHandler(this.alphaConstantCheckBox_CheckedChanged);
            // 
            // alphaConstantValueEditor
            // 
            this.alphaConstantValueEditor.DefaultValue = 255F;
            this.alphaConstantValueEditor.Enabled = false;
            this.alphaConstantValueEditor.Location = new System.Drawing.Point(12, 31);
            this.alphaConstantValueEditor.MaxValue = 255F;
            this.alphaConstantValueEditor.Name = "alphaConstantValueEditor";
            this.alphaConstantValueEditor.Size = new System.Drawing.Size(260, 72);
            this.alphaConstantValueEditor.TabIndex = 0;
            this.alphaConstantValueEditor.Value = 255F;
            this.alphaConstantValueEditor.ValueName = "Alpha Contant";
            this.alphaConstantValueEditor.ValueUnitOfMeasure = "";
            // 
            // PdfResourceGraphicsPropertiesForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 224);
            this.Controls.Add(this.alphaConstantValueEditor);
            this.Controls.Add(this.alphaConstantCheckBox);
            this.Controls.Add(this.colorBlendingGroupBox);
            this.Controls.Add(this.colorBlendingCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PdfResourceGraphicsPropertiesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Content Graphics Properties";
            this.colorBlendingGroupBox.ResumeLayout(false);
            this.colorBlendingGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox colorBlendingCheckBox;
        private System.Windows.Forms.GroupBox colorBlendingGroupBox;
        private System.Windows.Forms.ComboBox colorBlendingComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox alphaConstantCheckBox;
        private CustomControls.ValueEditorControl alphaConstantValueEditor;
    }
}