using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace UCSamples.DockPaneDemo {
    public static class DockpaneUtils {

        /// <summary>
        /// ID of the dockpane
        /// </summary>
        public const string DockPaneID = "UCSamples_Dockpane_id";

        /// <summary>
        /// Shows the dock pane
        /// </summary>
        /// <param name="damlID">Dockpane ID</param>
        public static async void ShowDockPane(string damlID = DockPaneID) {
            var pane = FindDockPane(damlID);
            if (pane == null)
                return;
            if (!pane.IsVisible) {
                pane.Activate();

            }
            if (!((DockpaneViewModel)pane).HasBookmarksLoaded) {
                await ((DockpaneViewModel)pane).LoadBookmarks();
            }
        }
        /// <summary>
        /// Finds the dockpane using the dockpane ID
        /// </summary>
        /// <param name="damlID">Dockpane ID</param>
        /// <param name="createIfNeeded"></param>
        /// <returns></returns>
        public static DockPane FindDockPane(string damlID = DockPaneID, bool createIfNeeded = true) {
            if (!createIfNeeded && !FrameworkApplication.IsDockPaneCreated(damlID))
                return null;
            return FrameworkApplication.FindDockPane(damlID);
        }


    }
}
