using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ArcGIS.Core.CIM;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Extensions;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Internal.Mapping;
using ArcGIS.Desktop.Mapping;

namespace UCSamples.Geocode
{
    internal class GeocodeButton : Button {

        GeocodeTextWindow _dlg = null;

        protected override async void OnClick() {
            if (_dlg != null)
                return;//already shown
            _dlg = new GeocodeTextWindow();
            _dlg.Closed += dlg_Closed;
            _dlg.Show();
        }

        void dlg_Closed(object sender, EventArgs e) {
            //try and clean up
            GeocodeUtils.RemoveFromMapOverlay(ForTheUcModule.ActiveMapView);
            //geocode dialog was closed
            _dlg.Closed -= dlg_Closed;
            _dlg = null;
        }
    }
}
