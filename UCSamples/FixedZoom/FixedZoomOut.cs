using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Core.CIM;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Internal.Mapping;
using ArcGIS.Desktop.Mapping;

namespace UCSamples.FixedZoom
{
    /// <summary>
    /// The button shows zoom-out functionality by manipulating the camera.
    /// In 2D view mode we are changing the scale property whereas in 3D the z-value
    /// of the observer (eye).
    /// </summary>
    internal class FixedZoomOut : Button {

        private static readonly double MaximumScale = 1000000000.0;
        private static readonly double MaximumElevation = MaximumScale;

        protected override async void OnClick() {
            Camera camera = ForTheUcModule.ActiveMapView.Camera;
            if (ForTheUcModule.ActiveMapView.Is2D) {
                double scale = camera.Scale * 1.25;
                camera.Scale = scale < MaximumScale ? scale : MaximumScale;
            }
            else {
                double z = camera.EyeXYZ.Z*1.25;
                camera.EyeXYZ.Z = z < MaximumScale ? z : MaximumScale;
            }

            ForTheUcModule.ActiveMapView.Camera = camera;
        }
    }
}
