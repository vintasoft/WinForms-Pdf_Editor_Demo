namespace DemosCommonCode.Pdf
{
    partial class PdfInteractiveFormChoiceFieldEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfInteractiveFormChoiceFieldEditorControl));
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.displayedValueTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.valueComboBox = new System.Windows.Forms.ComboBox();
            this.defaultValueComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.textQuaddingComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.exportedValueTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemsListBox
            // 
            this.tableLayoutPanel8.SetColumnSpan(this.itemsListBox, 2);
            this.itemsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.Location = new System.Drawing.Point(3, 61);
            this.itemsListBox.Name = "itemsListBox";
            this.tableLayoutPanel8.SetRowSpan(this.itemsListBox, 3);
            this.itemsListBox.Size = new System.Drawing.Size(236, 59);
            this.itemsListBox.TabIndex = 0;
            this.itemsListBox.SelectedIndexChanged += new System.EventHandler(this.itemsListBox_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.AutoSize = true;
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(245, 3);
            this.addButton.MinimumSize = new System.Drawing.Size(75, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpButton.AutoSize = true;
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Location = new System.Drawing.Point(245, 32);
            this.moveUpButton.MinimumSize = new System.Drawing.Size(75, 0);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(75, 23);
            this.moveUpButton.TabIndex = 2;
            resources.ApplyResources(this.moveUpButton, "moveUpButton");
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownButton.AutoSize = true;
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Location = new System.Drawing.Point(245, 61);
            this.moveDownButton.MinimumSize = new System.Drawing.Size(75, 0);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(75, 23);
            this.moveDownButton.TabIndex = 3;
            resources.ApplyResources(this.moveDownButton, "moveDownButton");
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // displayedValueTextBox
            // 
            this.displayedValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.displayedValueTextBox.Location = new System.Drawing.Point(92, 4);
            this.displayedValueTextBox.Name = "displayedValueTextBox";
            this.displayedValueTextBox.Size = new System.Drawing.Size(147, 20);
            this.displayedValueTextBox.TabIndex = 4;
            this.displayedValueTextBox.TextChanged += new System.EventHandler(this.diplayedValueTextBox_TextChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.AutoSize = true;
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(245, 90);
            this.deleteButton.MinimumSize = new System.Drawing.Size(75, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 5;
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tableLayoutPanel7);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Enabled = false;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(335, 230);
            this.mainPanel.TabIndex = 6;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(335, 230);
            this.tableLayoutPanel7.TabIndex = 19;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.valueComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.defaultValueComboBox, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(329, 53);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 10;
            resources.ApplyResources(this.label1, "label1");
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 11;
            resources.ApplyResources(this.label2, "label2");
            // 
            // valueComboBox
            // 
            this.valueComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.valueComboBox.FormattingEnabled = true;
            this.valueComboBox.Location = new System.Drawing.Point(80, 3);
            this.valueComboBox.Name = "valueComboBox";
            this.valueComboBox.Size = new System.Drawing.Size(246, 21);
            this.valueComboBox.TabIndex = 12;
            this.valueComboBox.SelectedIndexChanged += new System.EventHandler(this.valueComboBox_SelectedIndexChanged);
            this.valueComboBox.TextUpdate += new System.EventHandler(this.valueComboBox_TextUpdate);
            // 
            // defaultValueComboBox
            // 
            this.defaultValueComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultValueComboBox.FormattingEnabled = true;
            this.defaultValueComboBox.Location = new System.Drawing.Point(80, 29);
            this.defaultValueComboBox.Name = "defaultValueComboBox";
            this.defaultValueComboBox.Size = new System.Drawing.Size(246, 21);
            this.defaultValueComboBox.TabIndex = 13;
            this.defaultValueComboBox.SelectedIndexChanged += new System.EventHandler(this.defaultValueComboBox_SelectedIndexChanged);
            this.defaultValueComboBox.TextUpdate += new System.EventHandler(this.defaultValueComboBox_TextUpdate);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textQuaddingComboBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 201);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(335, 29);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 16;
            resources.ApplyResources(this.label3, "label3");
            // 
            // textQuaddingComboBox
            // 
            this.textQuaddingComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textQuaddingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textQuaddingComboBox.FormattingEnabled = true;
            this.textQuaddingComboBox.Location = new System.Drawing.Point(86, 4);
            this.textQuaddingComboBox.Name = "textQuaddingComboBox";
            this.textQuaddingComboBox.Size = new System.Drawing.Size(246, 21);
            this.textQuaddingComboBox.TabIndex = 15;
            this.textQuaddingComboBox.SelectedIndexChanged += new System.EventHandler(this.textQuaddingComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel8);
            this.groupBox1.Location = new System.Drawing.Point(3, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 142);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 8;
            resources.ApplyResources(this.label5, "label5");
            // 
            // exportedValueTextBox
            // 
            this.exportedValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.exportedValueTextBox.Location = new System.Drawing.Point(92, 33);
            this.exportedValueTextBox.Name = "exportedValueTextBox";
            this.exportedValueTextBox.Size = new System.Drawing.Size(147, 20);
            this.exportedValueTextBox.TabIndex = 7;
            this.exportedValueTextBox.TextChanged += new System.EventHandler(this.exportedValueTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            resources.ApplyResources(this.label4, "label4");
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.Controls.Add(this.deleteButton, 2, 3);
            this.tableLayoutPanel8.Controls.Add(this.itemsListBox, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.moveUpButton, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.moveDownButton, 2, 2);
            this.tableLayoutPanel8.Controls.Add(this.addButton, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.exportedValueTextBox, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.displayedValueTextBox, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 5;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(323, 123);
            this.tableLayoutPanel8.TabIndex = 22;
            // 
            // PdfInteractiveFormChoiceFieldEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(220, 230);
            this.Name = "PdfInteractiveFormChoiceFieldEditorControl";
            this.Size = new System.Drawing.Size(335, 230);
            this.mainPanel.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.TextBox displayedValueTextBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox valueComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox defaultValueComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox textQuaddingComboBox;
        private System.Windows.Forms.TextBox exportedValueTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
    }
}