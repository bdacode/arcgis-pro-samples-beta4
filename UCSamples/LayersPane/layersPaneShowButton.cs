using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace UCSamples.LayersPane
{
    internal class LayersPaneShowButton : Button
    {
        protected override void OnClick()
        {
            LayersPaneUtils.OpenPaneView(LayersPaneViewModel.ViewPaneID);
        }
    }
}



