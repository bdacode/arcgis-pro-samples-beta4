using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace UCSamples.FrameworkState
{
    internal class RespondToStateButton : Button
    {
        protected override void OnClick()
        {
            ArcGIS.Desktop.Internal.Framework.Metro.MessageBox.Show(string.Format("From {0} : {1}", this.GetType().ToString(), DateTime.Now.ToString("G")));
        }
    }
}
