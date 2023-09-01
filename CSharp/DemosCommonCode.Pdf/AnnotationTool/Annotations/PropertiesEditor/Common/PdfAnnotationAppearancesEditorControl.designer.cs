namespace DemosCommonCode.Pdf
{
    partial class PdfAnnotationAppearancesEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfAnnotationAppearancesEditorControl));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.removeAppearanceButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.appearanceStateNameComboBox = new System.Windows.Forms.ComboBox();
            this.changeAppearanceButton = new System.Windows.Forms.Button();
            this.pdfResourceViewerControl = new DemosCommonCode.Pdf.PdfResourceViewerControl();
            this.label1 = new System.Windows.Forms.Label();
            this.appearanceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.removeAppearanceButton);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.appearanceStateNameComboBox);
            this.mainPanel.Controls.Add(this.changeAppearanceButton);
            this.mainPanel.Controls.Add(this.pdfResourceViewerControl);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.appearanceTypeComboBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(251, 168);
            this.mainPanel.TabIndex = 0;
            // 
            // removeAppearanceButton
            // 
            this.removeAppearanceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeAppearanceButton.Enabled = false;
            this.removeAppearanceButton.Location = new System.Drawing.Point(173, 142);
            this.removeAppearanceButton.Name = "removeAppearanceButton";
            this.removeAppearanceButton.Size = new System.Drawing.Size(75, 23);
            this.removeAppearanceButton.TabIndex = 6;
            resources.ApplyResources(this.removeAppearanceButton, "removeAppearanceButton");
            this.removeAppearanceButton.UseVisualStyleBackColor = true;
            this.removeAppearanceButton.Click += new System.EventHandler(this.removeAppearanceButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 5;
            resources.ApplyResources(this.label2, "label2");
            // 
            // appearanceStateNameComboBox
            // 
            this.appearanceStateNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.appearanceStateNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appearanceStateNameComboBox.FormattingEnabled = true;
            this.appearanceStateNameComboBox.Location = new System.Drawing.Point(133, 3);
            this.appearanceStateNameComboBox.Name = "appearanceStateNameComboBox";
            this.appearanceStateNameComboBox.Size = new System.Drawing.Size(112, 21);
            this.appearanceStateNameComboBox.TabIndex = 4;
            this.appearanceStateNameComboBox.SelectedIndexChanged += new System.EventHandler(this.appearanceStateNameComboBox_SelectedIndexChanged);
            // 
            // changeAppearanceButton
            // 
            this.changeAppearanceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.changeAppearanceButton.Location = new System.Drawing.Point(92, 142);
            this.changeAppearanceButton.Name = "changeAppearanceButton";
            this.changeAppearanceButton.Size = new System.Drawing.Size(75, 23);
            this.changeAppearanceButton.TabIndex = 3;
            resources.ApplyResources(this.changeAppearanceButton, "changeAppearanceButton");
            this.changeAppearanceButton.UseVisualStyleBackColor = true;
            this.changeAppearanceButton.Click += new System.EventHandler(this.changeAppearanceButton_Click);
            // 
            // pdfResourceViewerControl
            // 
            this.pdfResourceViewerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfResourceViewerControl.ImageViewerAvailableZoomValues = new int[] {
        25,
        50,
        100,
        200,
        400};
            this.pdfResourceViewerControl.Location = new System.Drawing.Point(6, 57);
            this.pdfResourceViewerControl.MinimumSize = new System.Drawing.Size(120, 65);
            this.pdfResourceViewerControl.Name = "pdfResourceViewerControl";
            this.pdfResourceViewerControl.Resource = null;
            this.pdfResourceViewerControl.Size = new System.Drawing.Size(242, 79);
            this.pdfResourceViewerControl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            resources.ApplyResources(this.label1, "label1");
            // 
            // appearanceTypeComboBox
            // 
            this.appearanceTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.appearanceTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appearanceTypeComboBox.FormattingEnabled = true;
            this.appearanceTypeComboBox.Location = new System.Drawing.Point(133, 30);
            this.appearanceTypeComboBox.Name = "appearanceTypeComboBox";
            this.appearanceTypeComboBox.Size = new System.Drawing.Size(112, 21);
            this.appearanceTypeComboBox.TabIndex = 0;
            this.appearanceTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.appearanceTypeComboBox_SelectedIndexChanged);
            // 
            // PdfAnnotationAppearancesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(191, 148);
            this.Name = "PdfAnnotationAppearancesEditorControl";
            this.Size = new System.Drawing.Size(251, 168);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox appearanceTypeComboBox;
        private PdfResourceViewerControl pdfResourceViewerControl;
        private System.Windows.Forms.Button changeAppearanceButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox appearanceStateNameComboBox;
        private System.Windows.Forms.Button removeAppearanceButton;
    }
}