namespace DemosCommonCode.Pdf
{
    partial class PdfAnnotationBorderStyleControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfAnnotationBorderStyleControl));
            this.widthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.styleTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dashPatternComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.mainPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // widthNumericUpDown
            // 
            this.widthNumericUpDown.DecimalPlaces = 1;
            this.widthNumericUpDown.Location = new System.Drawing.Point(43, 5);
            this.widthNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.widthNumericUpDown.Name = "widthNumericUpDown";
            this.widthNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.widthNumericUpDown.TabIndex = 5;
            this.widthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumericUpDown.ValueChanged += new System.EventHandler(this.widthNumericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            resources.ApplyResources(this.label5, "label5");
            // 
            // styleTypeComboBox
            // 
            this.styleTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleTypeComboBox.FormattingEnabled = true;
            this.styleTypeComboBox.Location = new System.Drawing.Point(43, 32);
            this.styleTypeComboBox.Name = "styleTypeComboBox";
            this.styleTypeComboBox.Size = new System.Drawing.Size(85, 21);
            this.styleTypeComboBox.TabIndex = 4;
            this.styleTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.styleTypeComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 3;
            resources.ApplyResources(this.label7, "label7");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(134, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 1;
            resources.ApplyResources(this.label6, "label6");
            // 
            // dashPatternComboBox
            // 
            this.dashPatternComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dashPatternComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dashPatternComboBox.Enabled = false;
            this.dashPatternComboBox.FormattingEnabled = true;
            this.dashPatternComboBox.Location = new System.Drawing.Point(209, 32);
            this.dashPatternComboBox.Name = "dashPatternComboBox";
            this.dashPatternComboBox.Size = new System.Drawing.Size(99, 21);
            this.dashPatternComboBox.TabIndex = 22;
            this.dashPatternComboBox.SelectedIndexChanged += new System.EventHandler(this.dashPatternComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 21;
            resources.ApplyResources(this.label2, "label2");
            // 
            // colorPanelControl
            // 
            this.colorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorPanelControl.CanEditAlphaChannel = false;
            this.colorPanelControl.CanSetDefaultColor = true;
            this.colorPanelControl.Color = System.Drawing.Color.Transparent;
            this.colorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.colorPanelControl.Location = new System.Drawing.Point(209, 3);
            this.colorPanelControl.Name = "colorPanelControl";
            this.colorPanelControl.Size = new System.Drawing.Size(99, 21);
            this.colorPanelControl.TabIndex = 6;
            this.colorPanelControl.ColorChanged += new System.EventHandler(this.colorPanelControl_ColorChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.colorPanelControl);
            this.mainPanel.Controls.Add(this.dashPatternComboBox);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.widthNumericUpDown);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.styleTypeComboBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Enabled = false;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(311, 58);
            this.mainPanel.TabIndex = 23;
            // 
            // PdfAnnotationBorderStyleControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "PdfAnnotationBorderStyleControl";
            this.Size = new System.Drawing.Size(311, 58);
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown widthNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox styleTypeComboBox;
        private System.Windows.Forms.Label label7;
        private DemosCommonCode.CustomControls.ColorPanelControl colorPanelControl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox dashPatternComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel mainPanel;
    }
}