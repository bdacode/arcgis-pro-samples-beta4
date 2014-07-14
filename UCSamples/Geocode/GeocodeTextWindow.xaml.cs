using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ArcGIS.Desktop.Internal.Mapping;


namespace UCSamples.Geocode {
    /// <summary>
    /// Interaction logic for GeocodeTextWindow.xaml
    /// </summary>
    public partial class GeocodeTextWindow : Window {
        public GeocodeTextWindow() {
            InitializeComponent();
            // fill in a default address
            this.SearchText.Text = "1401 SW Naito Parkway, Portland, Oregon, 97201";
        }
         private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // get the current module to access helper method
            ForTheUcModule module = ForTheUcModule.Current;

            // remove any existing graphics
             MapView mapView = ForTheUcModule.ActiveMapView;
            GeocodeUtils.RemoveFromMapOverlay(mapView);

            try
            {
                // initiate the search
                CandidateResponse results = GeocodeUtils.SearchFor(this.SearchText.Text, 1);
                if (results.OrderedResults.Count > 0)
                {
                    // add a point graphic overlay
                    GeocodeUtils.UpdateMapOverlay(results.OrderedResults[0].ToPointN(), mapView);
                    // zoom to the location
                    await GeocodeUtils.ZoomToLocation(results.OrderedResults[0].Extent);
                    // add the search results to the dialog window
                    this.LastSearch.Text = string.Format("Last Match: {0}", results.OrderedResults[0].CandidateDetails);
                }
                else
                {

                    ArcGIS.Desktop.Internal.Framework.DialogManager.ShowMessageBox(
                        string.Format("No results returned for {0}", this.SearchText.Text), "GeocodeExample");
                }
            }
            catch (Exception ex)
            {
                string errorName = "Search Error";
                System.Diagnostics.Trace.WriteLine(string.Format("{0}: {1}", errorName, ex.ToString()));
                ArcGIS.Desktop.Internal.Framework.DialogManager.ShowMessageBox(errorName, this.SearchText.Text);
            }
        }
    }
}
