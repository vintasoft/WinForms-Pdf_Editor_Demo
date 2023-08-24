namespace DemosCommonCode.Pdf
{
    partial class PdfListBoxPropertiesEditorControl
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
            this.multiselectCheckBox = new System.Windows.Forms.CheckBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.selectionBrushColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.pdfInteractiveFormChoiceFieldEditorControl = new DemosCommonCode.Pdf.PdfInteractiveFormChoiceFieldEditorControl();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // multiselectCheckBox
            // 
            this.multiselectCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.multiselectCheckBox.AutoSize = true;
            this.multiselectCheckBox.Location = new System.Drawing.Point(251, 3);
            this.multiselectCheckBox.Name = "multiselectCheckBox";
            this.multiselectCheckBox.Size = new System.Drawing.Size(76, 17);
            this.multiselectCheckBox.TabIndex = 1;
            this.multiselectCheckBox.Text = "Multiselect";
            this.multiselectCheckBox.UseVisualStyleBackColor = true;
            this.multiselectCheckBox.CheckedChanged += new System.EventHandler(this.multiselectCheckBox_CheckedChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.selectionBrushColorPanelControl);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.multiselectCheckBox);
            this.mainPanel.Controls.Add(this.pdfInteractiveFormChoiceFieldEditorControl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(339, 259);
            this.mainPanel.TabIndex = 2;
            // 
            // selectionBrushColorPanelControl
            // 
            this.selectionBrushColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionBrushColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.selectionBrushColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.selectionBrushColorPanelControl.Location = new System.Drawing.Point(91, 0);
            this.selectionBrushColorPanelControl.Name = "selectionBrushColorPanelControl";
            this.selectionBrushColorPanelControl.Size = new System.Drawing.Size(154, 21);
            this.selectionBrushColorPanelControl.TabIndex = 3;
            this.selectionBrushColorPanelControl.ColorChanged += new System.EventHandler(this.selectionBrushColorPanelControl_ColorChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selection Brush";
            // 
            // pdfInteractiveFormChoiceFieldEditorControl
            // 
            this.pdfInteractiveFormChoiceFieldEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfInteractiveFormChoiceFieldEditorControl.Field = null;
            this.pdfInteractiveFormChoiceFieldEditorControl.Location = new System.Drawing.Point(0, 26);
            this.pdfInteractiveFormChoiceFieldEditorControl.MinimumSize = new System.Drawing.Size(190, 230);
            this.pdfInteractiveFormChoiceFieldEditorControl.Name = "pdfInteractiveFormChoiceFieldEditorControl";
            this.pdfInteractiveFormChoiceFieldEditorControl.Size = new System.Drawing.Size(339, 233);
            this.pdfInteractiveFormChoiceFieldEditorControl.TabIndex = 0;
            this.pdfInteractiveFormChoiceFieldEditorControl.PropertyValueChanged += new System.EventHandler(this.pdfInteractiveFormChoiceFieldEditorControl_PropertyValueChanged);
            // 
            // PdfListBoxPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(235, 259);
            this.Name = "PdfListBoxPropertiesEditorControl";
            this.Size = new System.Drawing.Size(339, 259);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PdfInteractiveFormChoiceFieldEditorControl pdfInteractiveFormChoiceFieldEditorControl;
        private System.Windows.Forms.CheckBox multiselectCheckBox;
        private System.Windows.Forms.Panel mainPanel;
        private DemosCommonCode.CustomControls.ColorPanelControl selectionBrushColorPanelControl;
        private System.Windows.Forms.Label label1;
    }
}