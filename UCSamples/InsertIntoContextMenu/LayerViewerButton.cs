using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Core.CIM;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Mapping;
using System.Collections.ObjectModel;

namespace UCSamples.InsertIntoContextMenu
{
    internal class LayerViewerButton : Button
    {
        // respond to click event
        protected override async void OnClick()
        {
            string xml = "";
            var toc = MappingModule.ActiveTOC;
            if (toc != null)
            {
                // get toc highlighted layers
                var selLayers = toc.SelectedLayers;
                // retrieve the first one
                Layer layer = selLayers.FirstOrDefault();
                if (layer != null)
                {
                    // find the CIM and serialize it
                    CIMBaseLayer cim = await layer.QueryLayerDefinitionAsync();
                    xml = XmlUtil.SerializeCartoXObject(cim);
                }
            }

            if (string.IsNullOrEmpty(xml))
                return;

            // show it
            CIMViewerViewModel vm = new CIMViewerViewModel();
            vm.Xml = xml;

            ArcGIS.Desktop.Internal.Framework.DialogManager.ShowDialog(vm, null);
        }
    }
}
