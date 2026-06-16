namespace CommonCode.Pdf
{
    partial class EditPdfFontSymbolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPdfFontSymbolForm));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.unicodeSymbolLabel = new System.Windows.Forms.Label();
            this.unicodeSymbolTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(71, 422);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(152, 422);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // unicodeSymbolLabel
            // 
            this.unicodeSymbolLabel.AutoSize = true;
            this.unicodeSymbolLabel.Location = new System.Drawing.Point(11, 13);
            this.unicodeSymbolLabel.Name = "unicodeSymbolLabel";
            this.unicodeSymbolLabel.Size = new System.Drawing.Size(85, 13);
            this.unicodeSymbolLabel.TabIndex = 2;
            resources.ApplyResources(this.unicodeSymbolLabel, "unicodeSymbolLabel");
            // 
            // unicodeSymbolTextBox
            // 
            this.unicodeSymbolTextBox.Location = new System.Drawing.Point(102, 10);
            this.unicodeSymbolTextBox.Name = "unicodeSymbolTextBox";
            this.unicodeSymbolTextBox.Size = new System.Drawing.Size(194, 20);
            this.unicodeSymbolTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            resources.ApplyResources(this.label1, "label1");
            // 
            // EditPdfFontSymbolForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(307, 457);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unicodeSymbolTextBox);
            this.Controls.Add(this.unicodeSymbolLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPdfFontSymbolForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label unicodeSymbolLabel;
        private System.Windows.Forms.TextBox unicodeSymbolTextBox;
        private System.Windows.Forms.Label label1;
    }
}