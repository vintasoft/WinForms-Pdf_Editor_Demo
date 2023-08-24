namespace DemosCommonCode.Pdf
{
    partial class PdfAnnotationCommonPropertiesEditorControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lockedCheckBox = new System.Windows.Forms.CheckBox();
            this.printableCheckBox = new System.Windows.Forms.CheckBox();
            this.readOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.borderStyleControl = new DemosCommonCode.Pdf.PdfAnnotationBorderStyleControl();
            this.opacityPanel = new System.Windows.Forms.Panel();
            this.opacityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.opacityTrackBar = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.opacityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(70, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(305, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subject";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Title";
            // 
            // lockedCheckBox
            // 
            this.lockedCheckBox.AutoSize = true;
            this.lockedCheckBox.Location = new System.Drawing.Point(70, 82);
            this.lockedCheckBox.Name = "lockedCheckBox";
            this.lockedCheckBox.Size = new System.Drawing.Size(62, 17);
            this.lockedCheckBox.TabIndex = 4;
            this.lockedCheckBox.Text = "Locked";
            this.lockedCheckBox.UseVisualStyleBackColor = true;
            this.lockedCheckBox.CheckedChanged += new System.EventHandler(this.lockedCheckBox_CheckedChanged);
            // 
            // printableCheckBox
            // 
            this.printableCheckBox.AutoSize = true;
            this.printableCheckBox.Location = new System.Drawing.Point(138, 82);
            this.printableCheckBox.Name = "printableCheckBox";
            this.printableCheckBox.Size = new System.Drawing.Size(67, 17);
            this.printableCheckBox.TabIndex = 5;
            this.printableCheckBox.Text = "Printable";
            this.printableCheckBox.UseVisualStyleBackColor = true;
            this.printableCheckBox.CheckedChanged += new System.EventHandler(this.printableCheckBox_CheckedChanged);
            // 
            // readOnlyCheckBox
            // 
            this.readOnlyCheckBox.AutoSize = true;
            this.readOnlyCheckBox.Location = new System.Drawing.Point(211, 82);
            this.readOnlyCheckBox.Name = "readOnlyCheckBox";
            this.readOnlyCheckBox.Size = new System.Drawing.Size(73, 17);
            this.readOnlyCheckBox.TabIndex = 6;
            this.readOnlyCheckBox.Text = "ReadOnly";
            this.readOnlyCheckBox.UseVisualStyleBackColor = true;
            this.readOnlyCheckBox.CheckedChanged += new System.EventHandler(this.readOnlyCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.borderStyleControl);
            this.groupBox1.Location = new System.Drawing.Point(3, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 79);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Outline";
            // 
            // borderStyleControl
            // 
            this.borderStyleControl.Annotation = null;
            this.borderStyleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderStyleControl.Location = new System.Drawing.Point(3, 16);
            this.borderStyleControl.Name = "borderStyleControl";
            this.borderStyleControl.Size = new System.Drawing.Size(375, 60);
            this.borderStyleControl.TabIndex = 0;
            this.borderStyleControl.PropertyValueChanged += new System.EventHandler(this.borderStyleControl_PropertyValueChanged);
            // 
            // opacityPanel
            // 
            this.opacityPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.opacityPanel.Controls.Add(this.opacityNumericUpDown);
            this.opacityPanel.Controls.Add(this.opacityTrackBar);
            this.opacityPanel.Controls.Add(this.label8);
            this.opacityPanel.Location = new System.Drawing.Point(0, 187);
            this.opacityPanel.Name = "opacityPanel";
            this.opacityPanel.Size = new System.Drawing.Size(387, 47);
            this.opacityPanel.TabIndex = 10;
            // 
            // opacityNumericUpDown
            // 
            this.opacityNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.opacityNumericUpDown.Location = new System.Drawing.Point(335, 17);
            this.opacityNumericUpDown.Name = "opacityNumericUpDown";
            this.opacityNumericUpDown.Size = new System.Drawing.Size(40, 20);
            this.opacityNumericUpDown.TabIndex = 2;
            this.opacityNumericUpDown.ValueChanged += new System.EventHandler(this.opacityNumericUpDown_ValueChanged);
            // 
            // opacityTrackBar
            // 
            this.opacityTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.opacityTrackBar.LargeChange = 10;
            this.opacityTrackBar.Location = new System.Drawing.Point(70, 3);
            this.opacityTrackBar.Maximum = 100;
            this.opacityTrackBar.Name = "opacityTrackBar";
            this.opacityTrackBar.Size = new System.Drawing.Size(259, 45);
            this.opacityTrackBar.TabIndex = 1;
            this.opacityTrackBar.Scroll += new System.EventHandler(this.opacityTrackBar_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Opacity";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectTextBox.Location = new System.Drawing.Point(70, 30);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(305, 20);
            this.subjectTextBox.TabIndex = 11;
            this.subjectTextBox.TextChanged += new System.EventHandler(this.subjectTextBox_TextChanged);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(70, 56);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(305, 20);
            this.titleTextBox.TabIndex = 12;
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.titleTextBox);
            this.mainPanel.Controls.Add(this.nameTextBox);
            this.mainPanel.Controls.Add(this.subjectTextBox);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.opacityPanel);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Controls.Add(this.lockedCheckBox);
            this.mainPanel.Controls.Add(this.printableCheckBox);
            this.mainPanel.Controls.Add(this.readOnlyCheckBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(387, 237);
            this.mainPanel.TabIndex = 13;
            // 
            // PdfAnnotationCommonPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "PdfAnnotationCommonPropertiesEditorControl";
            this.Size = new System.Drawing.Size(387, 237);
            this.groupBox1.ResumeLayout(false);
            this.opacityPanel.ResumeLayout(false);
            this.opacityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox lockedCheckBox;
        private System.Windows.Forms.CheckBox printableCheckBox;
        private System.Windows.Forms.CheckBox readOnlyCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel opacityPanel;
        private System.Windows.Forms.TrackBar opacityTrackBar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.NumericUpDown opacityNumericUpDown;
        private PdfAnnotationBorderStyleControl borderStyleControl;

    }
}