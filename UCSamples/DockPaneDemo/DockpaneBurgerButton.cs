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
    /// Represnts the context menu for the Burger button that displays the bookmarks in a gallery
    /// </summary>
    internal class DockpaneBurgerButton_button1 : Button
    {
        protected override void OnClick()
        {
            // TODO : Add implementation here
            DockpaneViewModel dvm = DockpaneUtils.FindDockPane() as DockpaneViewModel;
            dvm.IsPaletteSupport = true;
            dvm.IsBasicSupport = false;
        }
    }
    /// <summary>
    /// Represnts the context menu for the Burger button that displays the bookmarks in a list view
    /// </summary>
    internal class DockpaneBurgerButton_button2 : Button
    {
        protected override void OnClick()
        {
            // TODO : Add implementation here
            DockpaneViewModel dvm = DockpaneUtils.FindDockPane() as DockpaneViewModel;
            dvm.IsPaletteSupport = false;
            dvm.IsBasicSupport = true;
        }
    }
}
