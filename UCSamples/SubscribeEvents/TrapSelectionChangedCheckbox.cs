using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Internal.Mapping;
using ArcGIS.Desktop.Internal.Mapping.Table;
using ArcGIS.Desktop.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSamples.SubscribeEvents
{
    class TrapSelectionChangedCheckbox : ArcGIS.Desktop.Framework.Contracts.CheckBox
    {
        public TrapSelectionChangedCheckbox() : base() 
        {
        }

        ~TrapSelectionChangedCheckbox()
        {
          // make sure unsubscribe occurs  
          FrameworkApplication.EventAggregator.GetEvent<MapSelectionChanged>().Unsubscribe(OnMapSelectionChanged);
        }

        /// <summary>
        /// checkbox click event.  Subscribe or Unsubscribe to the MapSelectionChanged event according to the checkbox value
        /// </summary>
        protected override void OnClick()
        {
            if (IsChecked == true)
                FrameworkApplication.EventAggregator.GetEvent<MapSelectionChanged>().Subscribe(OnMapSelectionChanged);
            else if (IsChecked == false)
            {
                FrameworkApplication.EventAggregator.GetEvent<MapSelectionChanged>().Unsubscribe(OnMapSelectionChanged);
                ITablePane tbl = TableManager.ActiveTablePane;
                while (tbl != null)
                {
                    ((Pane)tbl).Close();
                    tbl = TableManager.ActiveTablePane;
                }
            }
        }

        private async void OnMapSelectionChanged(ViewEventArgs obj)
        {
            MapView view = obj.View as MapView;
            if (view == null)
                return;

            // retrieve the selection set
            var allSelectedFeatures = await SelectionSet.QuerySelection(view.Map);
            // loop through the layer, OID sets
            foreach (var layerOIDSetPair in allSelectedFeatures.GetSelection())
            {
                var layer = layerOIDSetPair.Item1;
                var oids = layerOIDSetPair.Item2;

                // open the table view showing only selected records
                if (layer != null)
                    TableManager.OpenTablePane(layer, TableViewMode.eSelectedRecords);
            }
        }
    }
}
