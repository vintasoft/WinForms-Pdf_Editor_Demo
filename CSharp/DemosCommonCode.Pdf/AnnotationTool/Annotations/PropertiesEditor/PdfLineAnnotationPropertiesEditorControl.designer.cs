namespace DemosCommonCode.Pdf
{
    partial class PdfLineAnnotationPropertiesEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfLineAnnotationPropertiesEditorControl));
            this.label1 = new System.Windows.Forms.Label();
            this.startPointLineEndingStyleComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.endPointLineEndingStyleComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.interiorColorColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            resources.ApplyResources(this.label1, "label1");
            // 
            // startPointLineEndingStyleComboBox
            // 
            this.startPointLineEndingStyleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.startPointLineEndingStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startPointLineEndingStyleComboBox.FormattingEnabled = true;
            this.startPointLineEndingStyleComboBox.Location = new System.Drawing.Point(148, 3);
            this.startPointLineEndingStyleComboBox.Name = "startPointLineEndingStyleComboBox";
            this.startPointLineEndingStyleComboBox.Size = new System.Drawing.Size(128, 21);
            this.startPointLineEndingStyleComboBox.TabIndex = 1;
            this.startPointLineEndingStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.StartPointLineEndingStyleComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 2;
            resources.ApplyResources(this.label2, "label2");
            // 
            // endPointLineEndingStyleComboBox
            // 
            this.endPointLineEndingStyleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.endPointLineEndingStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endPointLineEndingStyleComboBox.FormattingEnabled = true;
            this.endPointLineEndingStyleComboBox.Location = new System.Drawing.Point(148, 30);
            this.endPointLineEndingStyleComboBox.Name = "endPointLineEndingStyleComboBox";
            this.endPointLineEndingStyleComboBox.Size = new System.Drawing.Size(128, 21);
            this.endPointLineEndingStyleComboBox.TabIndex = 3;
            this.endPointLineEndingStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.EndPointLineEndingStyleComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            resources.ApplyResources(this.label3, "label3");
            // 
            // interiorColorColorPanelControl
            // 
            this.interiorColorColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.interiorColorColorPanelControl.CanSetDefaultColor = true;
            this.interiorColorColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.interiorColorColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.interiorColorColorPanelControl.Location = new System.Drawing.Point(148, 57);
            this.interiorColorColorPanelControl.Name = "interiorColorColorPanelControl";
            this.interiorColorColorPanelControl.Size = new System.Drawing.Size(128, 21);
            this.interiorColorColorPanelControl.TabIndex = 5;
            this.interiorColorColorPanelControl.ColorChanged += new System.EventHandler(this.InteriorColorColorPanelControl_ColorChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.startPointLineEndingStyleComboBox);
            this.mainPanel.Controls.Add(this.interiorColorColorPanelControl);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.endPointLineEndingStyleComboBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(279, 84);
            this.mainPanel.TabIndex = 6;
            // 
            // PdfLineAnnotationPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(240, 84);
            this.Name = "PdfLineAnnotationPropertiesEditorControl";
            this.Size = new System.Drawing.Size(279, 84);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox startPointLineEndingStyleComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox endPointLineEndingStyleComboBox;
        private System.Windows.Forms.Label label3;
        private DemosCommonCode.CustomControls.ColorPanelControl interiorColorColorPanelControl;
        private System.Windows.Forms.Panel mainPanel;
    }
}