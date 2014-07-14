using ArcGIS.Desktop.Framework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Internal.Mapping;
using ArcGIS.Desktop.Framework;

namespace UCSamples.CameraHeading
{
    /// <summary>
    /// View model for manipulating the camera heading based on the custom user control
    /// </summary>
    class HeadingViewModel : CustomControl
    {
        private double _headingValue;

        public HeadingViewModel()
        {

            MapView activeMapView = ForTheUcModule.ActiveMapView;
            _headingValue = activeMapView.Camera.Heading;

            FrameworkApplication.EventAggregator.GetEvent<ViewerExtentChanged>().Subscribe(CameraChanged);
        }

        ~HeadingViewModel()
        {
            FrameworkApplication.EventAggregator.GetEvent<ViewerExtentChanged>().Unsubscribe(CameraChanged);
        }

        public double CurrentHeadingValue
        {
            get 
            {
                return _headingValue;
                
            }
            set 
            {
                double cameraHeading = value > 180 ? value - 360 : value;

                MapView activeMapView = ForTheUcModule.ActiveMapView;

                Camera camera = ForTheUcModule.ActiveMapView.Camera;
                camera.Heading = cameraHeading;

                activeMapView.Camera = camera;

                _headingValue = value;
            }
        }

        private void CameraChanged(ViewEventArgs e)
        {
            double viewHeading = e.View.AutomationCamera.Heading < 0 ? 360 + e.View.AutomationCamera.Heading : e.View.AutomationCamera.Heading;

            SetProperty(ref _headingValue, viewHeading, () => CurrentHeadingValue);
        }
    }
}
