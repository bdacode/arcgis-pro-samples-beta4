using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ArcGIS.Core.CIM;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Events;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Internal.Core.Geoprocessing;
using ArcGIS.Desktop.Internal.Mapping;
using ArcGIS.Desktop.Mapping;
using UCSamples.GP;
using UCSamples.SubscribeEvents;
using Module = ArcGIS.Desktop.Framework.Contracts.Module;

namespace UCSamples
{

    internal class ForTheUcModule : Module
    {
        private static ForTheUcModule _this = null;
        private GPHelper _gpHelper = null;

        /// <summary>
        /// Retrieve the singleton instance to this module here
        /// </summary>
        public static ForTheUcModule Current
        {
            get
            {
                return _this ?? (_this = (ForTheUcModule)FrameworkApplication.FindModule("UCSamples_Module1_id"));
            }
        }

        public static MapView ActiveMapView {
            get {
                var activePane = FrameworkApplication.Panes.ActivePane as ViewerPaneViewModel;
                if ((activePane == null) || !activePane.IsViewerPaneInitialized)
                    return null;
                return activePane.GetActiveView() as MapView;
            }
        }

        /// <summary>
        /// Gets the GP Helper
        /// </summary>
        public GPHelper GPHelper {
            get {
                if (_gpHelper == null)
                    _gpHelper = new GPHelper();
                return _gpHelper;
            }
        }

        #region Toggle State
        /// <summary>
        /// Activate or Deactivate the specified state. State is identified via
        /// its name. Listen for state changes via the DAML <b>condition</b> attribute
        /// </summary>
        /// <param name="stateID"></param>
        public static void ToggleState(string stateID) {
            if (FrameworkApplication.State.Contains(stateID)) {
                FrameworkApplication.State.Deactivate(stateID);
            }
            else {
                FrameworkApplication.State.Activate(stateID);
            }
        }

        #endregion Toggle State

        #region For the Custom Event

        public static SubscriptionToken SubscribeToEvent(Action<CustomEventArgs> action) {
             return FrameworkApplication.EventAggregator.GetEvent<CustomEventChanged>().Subscribe(action);
        }

        public static void UnsubscribeToEvent(SubscriptionToken token) {
            FrameworkApplication.EventAggregator.GetEvent<CustomEventChanged>().Unsubscribe(token);
        }

        #endregion For the Custom Event

    }
}
