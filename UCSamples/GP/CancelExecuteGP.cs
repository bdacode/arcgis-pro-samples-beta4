using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace UCSamples.GP
{
    public class CancelExecuteGP : Button
    {
        protected override void OnClick()
        {
            //This calls cancel on the cancelationTokenSource associated with the
            //current operation. If none is associated it is, effectively, a no-op
            ForTheUcModule.Current.GPHelper.CallCancel();
        }
    }
}
