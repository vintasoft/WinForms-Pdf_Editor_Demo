namespace DemosCommonCode.Pdf
{
    partial class PdfCheckBoxPropertiesEditorControl
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
            this.pdfInteractiveFormSwitchableButtonPropertiesEditorControl = new DemosCommonCode.Pdf.PdfSwitchableButtonPropertiesEditorControl();
            this.SuspendLayout();
            // 
            // pdfInteractiveFormSwitchableButtonPropertiesEditorControl
            // 
            this.pdfInteractiveFormSwitchableButtonPropertiesEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfInteractiveFormSwitchableButtonPropertiesEditorControl.Field = null;
            this.pdfInteractiveFormSwitchableButtonPropertiesEditorControl.Location = new System.Drawing.Point(0, 0);
            this.pdfInteractiveFormSwitchableButtonPropertiesEditorControl.MinimumSize = new System.Drawing.Size(198, 154);
            this.pdfInteractiveFormSwitchableButtonPropertiesEditorControl.Name = "pdfInteractiveFormSwitchableButtonPropertiesEditorControl";
            this.pdfInteractiveFormSwitchableButtonPropertiesEditorControl.Size = new System.Drawing.Size(256, 220);
            this.pdfInteractiveFormSwitchableButtonPropertiesEditorControl.TabIndex = 0;
            this.pdfInteractiveFormSwitchableButtonPropertiesEditorControl.PropertyValueChanged += new System.EventHandler(this.pdfInteractiveFormSwitchableButtonPropertiesEditorControl_PropertyValueChanged);
            // 
            // PdfCheckBoxPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pdfInteractiveFormSwitchableButtonPropertiesEditorControl);
            this.MinimumSize = new System.Drawing.Size(198, 154);
            this.Name = "PdfCheckBoxPropertiesEditorControl";
            this.Size = new System.Drawing.Size(256, 220);
            this.ResumeLayout(false);

        }

        #endregion

        private PdfSwitchableButtonPropertiesEditorControl pdfInteractiveFormSwitchableButtonPropertiesEditorControl;

    }
}