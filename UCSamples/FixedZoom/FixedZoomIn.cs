using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace UCSamples.FixedZoom
{
    /// <summary>
    /// The button shows zoom-in functionality by manipulating the camera.
    /// In 2D view mode we are changing the scale property whereas in 3D the z-value
    /// of the observer (eye).
    /// </summary>
    internal class FixedZoomIn : Button {

        private static readonly double MinimumScale = 10000.0;
        private static readonly double MinimumElevation = 1000;

        protected override void OnClick() {
            MapView activeMapView = ForTheUcModule.ActiveMapView;
            Camera camera = activeMapView.Camera;

            if (activeMapView.Is2D) {
                double scale = camera.Scale * 0.75;
                camera.Scale = scale > MinimumScale ? scale : MinimumScale;
            }
            else {
                double z = camera.EyeXYZ.Z * 0.75;
                camera.EyeXYZ.Z = z > MinimumElevation ? z : MinimumElevation;
            }
            activeMapView.Camera = camera;
        }
    }
}
