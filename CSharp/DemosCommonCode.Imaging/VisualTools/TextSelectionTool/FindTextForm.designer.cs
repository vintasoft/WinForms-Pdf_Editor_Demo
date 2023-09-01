namespace DemosCommonCode.Imaging
{
    partial class FindTextForm
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
            if (_viewerTool != null)
            {
                _viewerTool.TextSearchingProgress -= viewerTool_FindTextAtPage;
                _viewerTool.TextSearched -= viewerTool_TextSearched;
            }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindTextForm));
            this.findWhatLabel = new System.Windows.Forms.Label();
            this.findWhatComboBox = new System.Windows.Forms.ComboBox();
            this.lookInLabel = new System.Windows.Forms.Label();
            this.lookInComboBox = new System.Windows.Forms.ComboBox();
            this.findOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.regexCheckBox = new System.Windows.Forms.CheckBox();
            this.searchUpCheckBox = new System.Windows.Forms.CheckBox();
            this.matchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.findNextButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.findOptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // findWhatLabel
            // 
            this.findWhatLabel.AutoSize = true;
            this.findWhatLabel.Location = new System.Drawing.Point(9, 9);
            this.findWhatLabel.Name = "findWhatLabel";
            this.findWhatLabel.Size = new System.Drawing.Size(62, 15);
            this.findWhatLabel.TabIndex = 0;
            resources.ApplyResources(this.findWhatLabel, "findWhatLabel");
            // 
            // findWhatComboBox
            // 
            this.findWhatComboBox.FormattingEnabled = true;
            this.findWhatComboBox.Location = new System.Drawing.Point(12, 25);
            this.findWhatComboBox.Name = "findWhatComboBox";
            this.findWhatComboBox.Size = new System.Drawing.Size(294, 23);
            this.findWhatComboBox.TabIndex = 1;
            this.findWhatComboBox.TextChanged += new System.EventHandler(this.findWhatComboBox_TextChanged);
            // 
            // lookInLabel
            // 
            this.lookInLabel.AutoSize = true;
            this.lookInLabel.Location = new System.Drawing.Point(9, 49);
            this.lookInLabel.Name = "lookInLabel";
            this.lookInLabel.Size = new System.Drawing.Size(49, 15);
            this.lookInLabel.TabIndex = 2;
            resources.ApplyResources(this.lookInLabel, "lookInLabel");
            // 
            // lookInComboBox
            // 
            this.lookInComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lookInComboBox.FormattingEnabled = true;
            this.lookInComboBox.Items.AddRange(new object[] {
            resources.GetString("lookInComboBox.Items"),
            resources.GetString("lookInComboBox.Items1")});
            this.lookInComboBox.Location = new System.Drawing.Point(12, 65);
            this.lookInComboBox.Name = "lookInComboBox";
            this.lookInComboBox.Size = new System.Drawing.Size(294, 23);
            this.lookInComboBox.TabIndex = 3;
            // 
            // findOptionsGroupBox
            // 
            this.findOptionsGroupBox.Controls.Add(this.regexCheckBox);
            this.findOptionsGroupBox.Controls.Add(this.searchUpCheckBox);
            this.findOptionsGroupBox.Controls.Add(this.matchCaseCheckBox);
            this.findOptionsGroupBox.Location = new System.Drawing.Point(12, 92);
            this.findOptionsGroupBox.Name = "findOptionsGroupBox";
            this.findOptionsGroupBox.Size = new System.Drawing.Size(294, 88);
            this.findOptionsGroupBox.TabIndex = 4;
            this.findOptionsGroupBox.TabStop = false;
            resources.ApplyResources(this.findOptionsGroupBox, "findOptionsGroupBox");
            // 
            // regexCheckBox
            // 
            this.regexCheckBox.AutoSize = true;
            this.regexCheckBox.Location = new System.Drawing.Point(15, 65);
            this.regexCheckBox.Name = "regexCheckBox";
            this.regexCheckBox.Size = new System.Drawing.Size(149, 19);
            this.regexCheckBox.TabIndex = 2;
            resources.ApplyResources(this.regexCheckBox, "regexCheckBox");
            this.regexCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchUpCheckBox
            // 
            this.searchUpCheckBox.AutoSize = true;
            this.searchUpCheckBox.Location = new System.Drawing.Point(15, 43);
            this.searchUpCheckBox.Name = "searchUpCheckBox";
            this.searchUpCheckBox.Size = new System.Drawing.Size(78, 19);
            this.searchUpCheckBox.TabIndex = 1;
            resources.ApplyResources(this.searchUpCheckBox, "searchUpCheckBox");
            this.searchUpCheckBox.UseVisualStyleBackColor = true;
            this.searchUpCheckBox.CheckedChanged += new System.EventHandler(this.searchUpCheckBox_CheckedChanged);
            // 
            // matchCaseCheckBox
            // 
            this.matchCaseCheckBox.AutoSize = true;
            this.matchCaseCheckBox.Location = new System.Drawing.Point(15, 20);
            this.matchCaseCheckBox.Name = "matchCaseCheckBox";
            this.matchCaseCheckBox.Size = new System.Drawing.Size(86, 19);
            this.matchCaseCheckBox.TabIndex = 0;
            resources.ApplyResources(this.matchCaseCheckBox, "matchCaseCheckBox");
            this.matchCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // findNextButton
            // 
            this.findNextButton.Enabled = false;
            this.findNextButton.Location = new System.Drawing.Point(211, 186);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(95, 23);
            this.findNextButton.TabIndex = 5;
            resources.ApplyResources(this.findNextButton, "findNextButton");
            this.findNextButton.UseVisualStyleBackColor = true;
            this.findNextButton.Click += new System.EventHandler(this.findNextButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(211, 186);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(95, 23);
            this.stopButton.TabIndex = 6;
            resources.ApplyResources(this.stopButton, "stopButton");
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // FindTextForm
            // 
            this.AcceptButton = this.findNextButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(318, 219);
            this.Controls.Add(this.findOptionsGroupBox);
            this.Controls.Add(this.lookInComboBox);
            this.Controls.Add(this.lookInLabel);
            this.Controls.Add(this.findWhatComboBox);
            this.Controls.Add(this.findWhatLabel);
            this.Controls.Add(this.findNextButton);
            this.Controls.Add(this.stopButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindTextForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            resources.ApplyResources(this, "$this");
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindTextDialog_FormClosing);
            this.Shown += new System.EventHandler(this.FindTextDialog_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindTextDialog_KeyDown);
            this.findOptionsGroupBox.ResumeLayout(false);
            this.findOptionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label findWhatLabel;
        private System.Windows.Forms.ComboBox findWhatComboBox;
        private System.Windows.Forms.Label lookInLabel;
        private System.Windows.Forms.ComboBox lookInComboBox;
        private System.Windows.Forms.GroupBox findOptionsGroupBox;
        private System.Windows.Forms.CheckBox searchUpCheckBox;
        private System.Windows.Forms.CheckBox matchCaseCheckBox;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.CheckBox regexCheckBox;
    }
}