using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Core.CIM;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Mapping;
using ArcGIS.Desktop.Internal.Mapping;


namespace UCSamples.DockPaneDemo
{
    
    /// <summary>
    /// Represents the Pan button
    /// </summary>
    public class ButtonPanToButton : Button
    {
        private static int _index = 0;

        protected override void OnUpdate()
        {
            if (this.Enabled)
                return;
            DockpaneViewModel dvm = DockpaneUtils.FindDockPane() as DockpaneViewModel;
            this.Enabled = (dvm != null);
        }
        protected override async void OnClick()
        {
            DockpaneViewModel dvm = DockpaneUtils.FindDockPane() as DockpaneViewModel;
            if (dvm == null)
            {
                this.Enabled = false;
                return;
            }
            if (!dvm.HasBookmarksLoaded)
            {
                await dvm.LoadBookmarks();
            }
            if (dvm.Cities == null || dvm.Cities.Count() == 0)
                return;

            if (_index >= dvm.Cities.Count())
                _index = 0;

            dvm.Cities[_index++].ZoomTo();
        }
    }
}
