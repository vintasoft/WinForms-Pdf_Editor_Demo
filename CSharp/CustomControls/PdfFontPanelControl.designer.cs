namespace DemosCommonCode.CustomControls
{
    partial class PdfFontPanelControl
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
            this.components = new System.ComponentModel.Container();
            this.fontNameButton = new System.Windows.Forms.Button();
            this.fontNameTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fontNameButton
            // 
            this.fontNameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fontNameButton.Location = new System.Drawing.Point(66, 0);
            this.fontNameButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.fontNameButton.Name = "fontNameButton";
            this.fontNameButton.Size = new System.Drawing.Size(25, 22);
            this.fontNameButton.TabIndex = 0;
            this.fontNameButton.Text = "...";
            this.fontNameButton.UseVisualStyleBackColor = true;
            this.fontNameButton.Click += new System.EventHandler(this.fontNameButton_Click);
            // 
            // fontNameTextBox
            // 
            this.fontNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fontNameTextBox.Location = new System.Drawing.Point(0, 1);
            this.fontNameTextBox.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.fontNameTextBox.Name = "fontNameTextBox";
            this.fontNameTextBox.ReadOnly = true;
            this.fontNameTextBox.Size = new System.Drawing.Size(63, 20);
            this.fontNameTextBox.TabIndex = 1;
            this.fontNameTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fontNameTextBox_MouseDoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.fontNameTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fontNameButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(91, 22);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // PdfFontPanelControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(91, 22);
            this.Name = "PdfFontPanelControl";
            this.Size = new System.Drawing.Size(91, 22);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fontNameButton;
        private System.Windows.Forms.TextBox fontNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}