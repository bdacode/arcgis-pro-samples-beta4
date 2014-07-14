using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Events;

namespace UCSamples.SubscribeEvents {

    public class CustomEventArgs : EventArgs {
        public string Tag { get; set; }
    }

    public class CustomEventChanged : CompositePresentationEvent<CustomEventArgs> {
        public static void Publish(string tag) {
            FrameworkApplication.EventAggregator.GetEvent<CustomEventChanged>().Publish(
                new CustomEventArgs {
                    Tag = tag
                });
        }
    }

    internal class PublishEventButton : Button {

        private bool _initialized = false;

        protected override void OnClick() {
            if (!_initialized) {
                _initialized = true;
                ForTheUcModule.SubscribeToEvent(evt => {
                    MessageBox.Show(evt.Tag, "Event Received");
                });
            }
            string time = DateTime.Now.ToString("G");
            CustomEventChanged.Publish(string.Format("From {0} : {1}",
                this.GetType().ToString(), time));
        }
    }
}
