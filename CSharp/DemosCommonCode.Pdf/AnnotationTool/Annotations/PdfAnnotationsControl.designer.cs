namespace DemosCommonCode.Pdf
{
    partial class PdfAnnotationsControl
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AnnotationBuilderControl = new DemosCommonCode.Pdf.PdfAnnotationBuilderControl();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pdfAnnotationToolAnnotationsControl = new DemosCommonCode.Pdf.PdfAnnotationToolAnnotationsControl();
            this.groupBox1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.AnnotationBuilderControl);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 344);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Annotation";
            // 
            // AnnotationBuilderControl
            // 
            this.AnnotationBuilderControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnnotationBuilderControl.Location = new System.Drawing.Point(3, 16);
            this.AnnotationBuilderControl.MinimumSize = new System.Drawing.Size(71, 150);
            this.AnnotationBuilderControl.Name = "AnnotationBuilderControl";
            this.AnnotationBuilderControl.NeedBuildAnnotationsContinuously = false;
            this.AnnotationBuilderControl.Size = new System.Drawing.Size(203, 325);
            this.AnnotationBuilderControl.TabIndex = 8;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.pdfAnnotationToolAnnotationsControl);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Enabled = false;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(215, 475);
            this.mainPanel.TabIndex = 11;
            // 
            // pdfAnnotationToolAnnotationsControl
            // 
            this.pdfAnnotationToolAnnotationsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfAnnotationToolAnnotationsControl.AnnotationList = null;
            this.pdfAnnotationToolAnnotationsControl.AnnotationTool = null;
            this.pdfAnnotationToolAnnotationsControl.FullRowSelect = true;
            this.pdfAnnotationToolAnnotationsControl.GridLines = true;
            this.pdfAnnotationToolAnnotationsControl.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.pdfAnnotationToolAnnotationsControl.HideSelection = false;
            this.pdfAnnotationToolAnnotationsControl.Location = new System.Drawing.Point(3, 350);
            this.pdfAnnotationToolAnnotationsControl.MultiSelect = false;
            this.pdfAnnotationToolAnnotationsControl.Name = "pdfAnnotationToolAnnotationsControl";
            this.pdfAnnotationToolAnnotationsControl.SelectedAnnotation = null;
            this.pdfAnnotationToolAnnotationsControl.Size = new System.Drawing.Size(209, 122);
            this.pdfAnnotationToolAnnotationsControl.TabIndex = 10;
            this.pdfAnnotationToolAnnotationsControl.UseCompatibleStateImageBehavior = false;
            this.pdfAnnotationToolAnnotationsControl.View = System.Windows.Forms.View.Details;
            this.pdfAnnotationToolAnnotationsControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pdfAnnotationToolAnnotationsControl_MouseDoubleClick);
            // 
            // PdfAnnotationsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(160, 306);
            this.Name = "PdfAnnotationsControl";
            this.Size = new System.Drawing.Size(215, 475);
            this.groupBox1.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public PdfAnnotationBuilderControl AnnotationBuilderControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private PdfAnnotationToolAnnotationsControl pdfAnnotationToolAnnotationsControl;
        private System.Windows.Forms.Panel mainPanel;
    }
}