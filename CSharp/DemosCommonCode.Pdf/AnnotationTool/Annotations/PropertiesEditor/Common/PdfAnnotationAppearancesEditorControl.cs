using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to view and edit properties of
    /// the <see cref="PdfAnnotationAppearances"/>.
    /// </summary>
    [DefaultEvent("AppearanceChanged")]
    public partial class PdfAnnotationAppearancesEditorControl : UserControl
    {

        #region Nested Enum

        /// <summary>
        /// Determines available types of appearances.
        /// </summary>
        private enum AppearanceType
        {
            /// <summary>
            /// The normal type.
            /// </summary>
            Normal,

            /// <summary>
            /// The rollover type.
            /// </summary>
            Rollover,

            /// <summary>
            /// Down type.
            /// </summary>
            Down
        }

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of
        /// the <see cref="PdfAnnotationAppearancesEditorControl"/> class.
        /// </summary>
        public PdfAnnotationAppearancesEditorControl()
        {
            InitializeComponent();

            foreach (AppearanceType type in Enum.GetValues(typeof(AppearanceType)))
                appearanceTypeComboBox.Items.Add(type);
            appearanceTypeComboBox.SelectedItem = AppearanceType.Normal;

            Annotation = null;
        }

        #endregion



        #region Properties

        PdfAnnotation _annotation = null;
        /// <summary>
        /// Gets or sets the annotation.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public PdfAnnotation Annotation
        {
            get
            {
                return _annotation;
            }
            set
            {
                if (_annotation != value)
                {
                    _annotation = value;

                    mainPanel.Enabled = _annotation != null;

                    if (_annotation != null && _annotation.Appearances == null)
                        _annotation.Appearances = new PdfAnnotationAppearances(_annotation.Document);

                    UpdateAppearance();
                }
            }
        }

        /// <summary>
        /// Gets or sets the annotation appearances.
        /// </summary>
        private PdfAnnotationAppearances Appearances
        {
            get
            {
                if (_annotation == null)
                    return null;

                return _annotation.Appearances;
            }
        }

        /// <summary>
        /// Gets or sets the selected annotation appearance.
        /// </summary>
        private PdfFormXObjectResource SelectedAppearance
        {
            get
            {
                if (Appearances == null || appearanceStateNameComboBox.SelectedItem == null)
                    return null;

                PdfFormXObjectResourceDictionary resourceDictionary = null;
                AppearanceType appearanceType = (AppearanceType)appearanceTypeComboBox.SelectedItem;
                switch (appearanceType)
                {
                    case AppearanceType.Normal:
                        resourceDictionary = Appearances.NormalStates;
                        break;

                    case AppearanceType.Rollover:
                        resourceDictionary = Appearances.RolloverStates;
                        break;

                    case AppearanceType.Down:
                        resourceDictionary = Appearances.DownStates;
                        break;
                }

                string appearanceStateName = appearanceStateNameComboBox.SelectedItem.ToString();
                if (resourceDictionary == null || !resourceDictionary.Keys.Contains(appearanceStateName))
                    return null;
                else
                    return resourceDictionary[appearanceStateName];
            }
            set
            {
                if (_annotation == null || appearanceStateNameComboBox.SelectedItem == null)
                    return;

                PdfFormXObjectResourceDictionary resourceDictionary = null;
                AppearanceType appearanceType = (AppearanceType)appearanceTypeComboBox.SelectedItem;
                switch (appearanceType)
                {
                    case AppearanceType.Normal:
                        if (Appearances.NormalStates == null && value != null)
                            Appearances.NormalStates = new PdfFormXObjectResourceDictionary(Annotation.Document);
                        resourceDictionary = Appearances.NormalStates;
                        break;

                    case AppearanceType.Rollover:
                        if (Appearances.RolloverStates == null && value != null)
                            Appearances.RolloverStates = new PdfFormXObjectResourceDictionary(Annotation.Document);
                        resourceDictionary = Appearances.RolloverStates;
                        break;

                    case AppearanceType.Down:
                        if (Appearances.DownStates == null && value != null)
                            Appearances.DownStates = new PdfFormXObjectResourceDictionary(Annotation.Document);
                        resourceDictionary = Appearances.DownStates;
                        break;
                }

                if (resourceDictionary == null)
                    return;

                string appearanceStateName = appearanceStateNameComboBox.SelectedItem.ToString();
                resourceDictionary[appearanceStateName] = value;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the SelectedIndexChanged event of appearanceStateNameComboBox object.
        /// </summary>
        private void appearanceStateNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update current resource
            pdfResourceViewerControl.Resource = SelectedAppearance;
            // update user interface
            UpdateUI();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of appearanceTypeComboBox object.
        /// </summary>
        private void appearanceTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update current resource
            pdfResourceViewerControl.Resource = SelectedAppearance;
            // update user interface
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of changeAppearanceButton object.
        /// </summary>
        private void changeAppearanceButton_Click(object sender, EventArgs e)
        {
            // if appearance generator is created
            if (Annotation.AppearanceGenerator != null)
            {
                string message = "The annotation appearance is generated using the appearance generator." +
                    " Do you want to disable the appearance generator?";
                // if appearance generator must be removed
                if (MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Annotation.AppearanceGenerator = null;
                else
                    return;
            }

            // create PDF resource viewer form
            using (PdfResourcesViewerForm dialog = new PdfResourcesViewerForm(Annotation.Document, true))
            {
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Owner = this.ParentForm;

                // if PDF resource is selected
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PdfFormXObjectResource resource = null;
                    // if selected is form XObject resource
                    if (dialog.SelectedResource is PdfFormXObjectResource)
                        resource = (PdfFormXObjectResource)dialog.SelectedResource;
                    // if selected the image resource
                    else if (dialog.SelectedResource is PdfImageResource)
                    {
                        // get image resource
                        PdfImageResource imageResource = (PdfImageResource)dialog.SelectedResource;
                        // create form XObject resource
                        resource = new PdfFormXObjectResource(Annotation.Document, imageResource);
                    }

                    // update current appearance
                    SelectedAppearance = resource;
                    // update current resource
                    pdfResourceViewerControl.Resource = resource;

                    // update user interface
                    UpdateUI();

                    OnAppearanceChanged();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of removeAppearanceButton object.
        /// </summary>
        private void removeAppearanceButton_Click(object sender, EventArgs e)
        {
            // remove current appearance
            SelectedAppearance = null;
            // remove current resource
            pdfResourceViewerControl.Resource = null;

            UpdateUI();

            OnAppearanceChanged();
        }

        #endregion


        /// <summary>
        /// Updates the appearance.
        /// </summary>
        public void UpdateAppearance()
        {
            if (Annotation == null)
                return;

            string[] appearanceStateNames = new string[Appearances.NormalStates.Keys.Count];
            Appearances.NormalStates.Keys.CopyTo(appearanceStateNames, 0);

            string selectedItem = string.Empty;
            if (appearanceStateNameComboBox.SelectedItem != null)
                selectedItem = appearanceStateNameComboBox.SelectedItem.ToString();

            appearanceStateNameComboBox.BeginUpdate();
            appearanceStateNameComboBox.Items.Clear();
            appearanceStateNameComboBox.Items.AddRange(appearanceStateNames);
            if (string.IsNullOrEmpty(selectedItem))
            {
                if (appearanceStateNames.Length > 0)
                    appearanceStateNameComboBox.SelectedItem = appearanceStateNames[0];
            }
            else
                appearanceStateNameComboBox.SelectedItem = selectedItem;
            appearanceStateNameComboBox.EndUpdate();

            pdfResourceViewerControl.Resource = SelectedAppearance;
        }

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            AppearanceType appearanceType = (AppearanceType)appearanceTypeComboBox.SelectedItem;
            removeAppearanceButton.Enabled = appearanceType != AppearanceType.Normal && SelectedAppearance != null;
        }

        /// <summary>
        /// Raises the AppearanceChanged event.
        /// </summary>
        private void OnAppearanceChanged()
        {
            if (AppearanceChanged != null)
                AppearanceChanged(this, EventArgs.Empty);
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when appearance is changed.
        /// </summary>
        public event EventHandler AppearanceChanged;

        #endregion

    }
}
