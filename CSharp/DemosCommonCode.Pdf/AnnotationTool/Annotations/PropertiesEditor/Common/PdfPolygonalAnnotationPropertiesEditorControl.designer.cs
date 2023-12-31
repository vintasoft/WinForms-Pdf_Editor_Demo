namespace DemosCommonCode.Pdf
{
    partial class PdfPolygonalAnnotationPropertiesEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfPolygonalAnnotationPropertiesEditorControl));
            this.label1 = new System.Windows.Forms.Label();
            this.interiorColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pdfAnnotationBorderEffectEditorControl1 = new DemosCommonCode.CustomControls.PdfAnnotationBorderEffectEditorControl();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            resources.ApplyResources(this.label1, "label1");
            // 
            // interiorColorPanelControl
            // 
            this.interiorColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.interiorColorPanelControl.CanSetDefaultColor = true;
            this.interiorColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.interiorColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.interiorColorPanelControl.Location = new System.Drawing.Point(75, 3);
            this.interiorColorPanelControl.Name = "interiorColorPanelControl";
            this.interiorColorPanelControl.Size = new System.Drawing.Size(109, 21);
            this.interiorColorPanelControl.TabIndex = 1;
            this.interiorColorPanelControl.ColorChanged += new System.EventHandler(this.interiorColorPanelControl_ColorChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(187, 56);
            this.mainPanel.TabIndex = 2;
            // 
            // pdfAnnotationBorderEffectEditorControl1
            // 
            this.pdfAnnotationBorderEffectEditorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfAnnotationBorderEffectEditorControl1.Annotation = null;
            this.pdfAnnotationBorderEffectEditorControl1.Location = new System.Drawing.Point(75, 31);
            this.pdfAnnotationBorderEffectEditorControl1.MaximumSize = new System.Drawing.Size(9999999, 21);
            this.pdfAnnotationBorderEffectEditorControl1.MinimumSize = new System.Drawing.Size(0, 21);
            this.pdfAnnotationBorderEffectEditorControl1.Name = "pdfAnnotationBorderEffectEditorControl1";
            this.pdfAnnotationBorderEffectEditorControl1.Size = new System.Drawing.Size(109, 21);
            this.pdfAnnotationBorderEffectEditorControl1.TabIndex = 3;
            this.pdfAnnotationBorderEffectEditorControl1.PropertyValueChanged += new System.EventHandler(this.pdfAnnotationBorderEffectEditorControl1_PropertyValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            resources.ApplyResources(this.label2, "label2");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.interiorColorPanelControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pdfAnnotationBorderEffectEditorControl1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(187, 56);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // PdfPolygonalAnnotationPropertiesEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "PdfPolygonalAnnotationPropertiesEditorControl";
            this.Size = new System.Drawing.Size(187, 56);
            this.mainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DemosCommonCode.CustomControls.ColorPanelControl interiorColorPanelControl;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label2;
        private DemosCommonCode.CustomControls.PdfAnnotationBorderEffectEditorControl pdfAnnotationBorderEffectEditorControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}