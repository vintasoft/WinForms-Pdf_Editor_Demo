namespace DemosCommonCode.Pdf
{
    partial class PdfNamedActionEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfNamedActionEditorForm));
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            resources.ApplyResources(this.label1, "label1");
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(163, 66);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(244, 66);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // nameComboBox
            // 
            this.nameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Items.AddRange(new object[] {
            resources.GetString("nameComboBox.Items"),
            resources.GetString("nameComboBox.Items1"),
            resources.GetString("nameComboBox.Items2"),
            resources.GetString("nameComboBox.Items3")});
            this.nameComboBox.Location = new System.Drawing.Point(12, 31);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(307, 21);
            this.nameComboBox.TabIndex = 4;
            this.nameComboBox.TextChanged += new System.EventHandler(this.nameComboBox_TextChanged);
            // 
            // PdfNamedActionEditorForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(331, 99);
            this.Controls.Add(this.nameComboBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PdfNamedActionEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox nameComboBox;
    }
}