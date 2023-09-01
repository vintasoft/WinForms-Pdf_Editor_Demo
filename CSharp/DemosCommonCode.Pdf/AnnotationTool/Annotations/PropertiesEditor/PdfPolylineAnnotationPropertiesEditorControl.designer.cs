namespace DemosCommonCode.Pdf
{
    partial class PdfPolylineAnnotationPropertiesEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfPolylineAnnotationPropertiesEditorControl));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startPointLineEndingStyleComboBox = new System.Windows.Forms.ComboBox();
            this.endPointLineEndingStyleComboBox = new System.Windows.Forms.ComboBox();
            this.pdfPolygonalAnnotationPropertiesEditorControl = new DemosCommonCode.Pdf.PdfPolygonalAnnotationPropertiesEditorControl();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.endPointLineEndingStyleComboBox);
            this.mainPanel.Controls.Add(this.startPointLineEndingStyleComboBox);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.pdfPolygonalAnnotationPropertiesEditorControl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(395, 89);
            this.mainPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 1;
            resources.ApplyResources(this.label1, "label1");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 2;
            resources.ApplyResources(this.label2, "label2");
            // 
            // startPointLineEndingStyleComboBox
            // 
            this.startPointLineEndingStyleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.startPointLineEndingStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startPointLineEndingStyleComboBox.FormattingEnabled = true;
            this.startPointLineEndingStyleComboBox.Location = new System.Drawing.Point(150, 3);
            this.startPointLineEndingStyleComboBox.Name = "startPointLineEndingStyleComboBox";
            this.startPointLineEndingStyleComboBox.Size = new System.Drawing.Size(236, 21);
            this.startPointLineEndingStyleComboBox.TabIndex = 3;
            this.startPointLineEndingStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.startPointLineEndingStyleComboBox_SelectedIndexChanged);
            // 
            // endPointLineEndingStyleComboBox
            // 
            this.endPointLineEndingStyleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.endPointLineEndingStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endPointLineEndingStyleComboBox.FormattingEnabled = true;
            this.endPointLineEndingStyleComboBox.Location = new System.Drawing.Point(150, 30);
            this.endPointLineEndingStyleComboBox.Name = "endPointLineEndingStyleComboBox";
            this.endPointLineEndingStyleComboBox.Size = new System.Drawing.Size(236, 21);
            this.endPointLineEndingStyleComboBox.TabIndex = 4;
            this.endPointLineEndingStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.endPointLineEndingStyleComboBox_SelectedIndexChanged);
            // 
            // pdfPolygonalAnnotationPropertiesEditorControl
            // 
            this.pdfPolygonalAnnotationPropertiesEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfPolygonalAnnotationPropertiesEditorControl.Annotation = null;
            this.pdfPolygonalAnnotationPropertiesEditorControl.Location = new System.Drawing.Point(3, 57);
            this.pdfPolygonalAnnotationPropertiesEditorControl.Name = "pdfPolygonalAnnotationPropertiesEditorControl";
            this.pdfPolygonalAnnotationPropertiesEditorControl.Size = new System.Drawing.Size(389, 30);
            this.pdfPolygonalAnnotationPropertiesEditorControl.TabIndex = 0;
            this.pdfPolygonalAnnotationPropertiesEditorControl.PropertyValueChanged += new System.EventHandler(this.pdfPolygonalAnnotationPropertiesEditorControl_PropertyValueChanged);
            // 
            // PdfPolylineAnnotationPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "PdfPolylineAnnotationPropertiesEditorControl";
            this.Size = new System.Drawing.Size(395, 89);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private global::DemosCommonCode.Pdf.PdfPolygonalAnnotationPropertiesEditorControl pdfPolygonalAnnotationPropertiesEditorControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox startPointLineEndingStyleComboBox;
        private System.Windows.Forms.ComboBox endPointLineEndingStyleComboBox;
    }
}