using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Core.Data;
using ArcGIS.Desktop.Mapping;

namespace UCSamples.LayersPane.Extensions {
    static class ExtendsLayer {

        /// <summary>
        /// Returns the feature class associated with layer.
        /// </summary>
        /// <param name="layer">The input layer.</param>
        /// <returns>The table or the feature class associated with the layer.</returns>
        public static async Task<Table> getFeatureClass(this Layer layer) {
            // get the feature class associated with the layer
            return await ArcGIS.Desktop.Internal.Editing.EditingModuleInternal.GetTableAsync(layer);
        }
    }
}
