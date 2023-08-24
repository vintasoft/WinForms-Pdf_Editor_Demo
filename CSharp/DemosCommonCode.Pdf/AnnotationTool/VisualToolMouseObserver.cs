using System;
using System.Drawing;

using Vintasoft.Imaging.UI.VisualTools;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// Observes mouse focus and mouse location in visual tool.
    /// </summary>
    public class VisualToolMouseObserver
    {

        #region Properties

        VisualTool _visualTool;
        /// <summary>
        /// Gets or sets the visual tool, which is monitored.
        /// </summary>
        public VisualTool VisualTool
        {
            get
            {
                return _visualTool;
            }
            set
            {
                if (_visualTool != value)
                {
                    if (_visualTool != null)
                    {
                        _visualTool.MouseEnter -= new EventHandler(visualTool_MouseEnter);
                        _visualTool.MouseLeave -= new EventHandler(visualTool_MouseLeave);
                        _visualTool.MouseMove -= new VisualToolMouseEventHandler(visualTool_MouseMove);
                    }

                    _visualTool = value;
                    
                    if (_visualTool != null)
                    {
                        _visualTool.MouseEnter += new EventHandler(visualTool_MouseEnter);
                        _visualTool.MouseLeave += new EventHandler(visualTool_MouseLeave);
                        _visualTool.MouseMove += new VisualToolMouseEventHandler(visualTool_MouseMove);
                    }
                }
            }
        }

        Point _visualToolMouseLocation;
        /// <summary>
        /// Gets the mouse location in visual tool.
        /// </summary>
        public Point VisualToolMouseLocation
        {
            get
            {
                return _visualToolMouseLocation;
            }
        }

        bool _visualToolHasMouseFocus;
        /// <summary>
        /// Gets a value indicating whether the visual tool has mouse focus.
        /// </summary>
        public bool VisualToolHasMouseFocus
        {
            get
            {
                return _visualToolHasMouseFocus;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the MouseMove event of the VisualTool.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisualToolMouseEventArgs"/> instance containing the event data.</param>
        private void visualTool_MouseMove(object sender, VisualToolMouseEventArgs e)
        {
            _visualToolMouseLocation = new Point(e.X, e.Y);
        }

        /// <summary>
        /// Handles the MouseLeave event of the VisualTool.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void visualTool_MouseLeave(object sender, EventArgs e)
        {
            _visualToolHasMouseFocus = false;
        }

        /// <summary>
        /// Handles the MouseEnter event of the VisualTool.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void visualTool_MouseEnter(object sender, EventArgs e)
        {
            _visualToolHasMouseFocus = true;
        }

        #endregion

    }
}
