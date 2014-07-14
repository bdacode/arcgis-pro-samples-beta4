using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace UCSamples.DockPaneDemo
{
    /// <summary>
    /// Represents the button that opens the Dockpane.
    /// </summary>
    public class DockpaneButton : Button
    {
        private bool _isBusy = false;

        protected override void OnClick()
        {
            if (_isBusy)
                return;
            _isBusy = true;
            try
            {
                DockpaneUtils.ShowDockPane();
            }
            finally
            {
                _isBusy = false;
            }
        }
    }
}
