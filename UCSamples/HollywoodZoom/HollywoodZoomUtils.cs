using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSamples.HollywoodZoom {
    internal class HollywoodZoomUtils {

        public static double StepHeading(double currentHeading, double stepSize) {
            double heading = currentHeading + stepSize;

            // ensure that we are in the <360 range
            heading = heading > 360 ? heading % 360 : heading;

            // transform the 0-360 range into the heading property ranging from -180 - 180
            heading = heading > 180 ? heading - 360 : heading;

            return heading;
        }
    }
}
