namespace DemosCommonCode.CustomControls
{
    partial class PdfAnnotationBorderEffectEditorControl
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

         #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // styleComboBox
            // 
            this.styleComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(0, 0);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(100, 21);
            this.styleComboBox.TabIndex = 0;
            this.styleComboBox.SelectedIndexChanged += new System.EventHandler(this.styleComboBox_SelectedIndexChanged);
            // 
            // PdfAnnotationBorderEffectEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.styleComboBox);
            this.MaximumSize = new System.Drawing.Size(9999999, 21);
            this.MinimumSize = new System.Drawing.Size(0, 21);
            this.Name = "PdfAnnotationBorderEffectEditorControl";
            this.Size = new System.Drawing.Size(100, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox styleComboBox;
    }
}