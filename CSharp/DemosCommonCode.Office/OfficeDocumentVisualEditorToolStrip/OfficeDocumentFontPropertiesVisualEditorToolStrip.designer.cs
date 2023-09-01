
namespace DemosCommonCode.Office
{
    partial class OfficeDocumentFontPropertiesVisualEditorToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfficeDocumentFontPropertiesVisualEditorToolStrip));
            this.fontNameComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.fontSizeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.SuspendLayout();
            // 
            // fontNameComboBox
            // 
            this.fontNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontNameComboBox.Name = "fontNameComboBox";
            this.fontNameComboBox.Size = new System.Drawing.Size(165, 23);
            this.fontNameComboBox.Sorted = true;
            resources.ApplyResources(this.fontNameComboBox, "fontNameComboBox");
            // 
            // fontSizeComboBox
            // 
            this.fontSizeComboBox.DropDownWidth = 50;
            this.fontSizeComboBox.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "28",
            "36",
            "48",
            "72"});
            this.fontSizeComboBox.Name = "fontSizeComboBox";
            this.fontSizeComboBox.Size = new System.Drawing.Size(75, 23);
            resources.ApplyResources(this.fontSizeComboBox, "fontSizeComboBox");
            // 
            // OfficeDocumentFontPropertiesVisualEditorToolStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontNameComboBox,
            this.fontSizeComboBox});
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripComboBox fontNameComboBox;
        private System.Windows.Forms.ToolStripComboBox fontSizeComboBox;
    }
}
