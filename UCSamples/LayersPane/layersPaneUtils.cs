using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Framework;

namespace UCSamples.LayersPane
{
    internal static class LayersPaneUtils
    {
        private static readonly object _lockObject = new object();
        private static WeakReference<LayersPaneViewModel> _viewPane = null;

        public static LayersPaneViewModel OpenPaneView(string id)
        {
            LayersPaneViewModel vm = null;
            bool created = false;
            lock (_lockObject)
            {
                vm = FindPane();

                if (vm == null)
                {
                    //it has not been made yet
                    var view = LayersPaneViewModel.CreatePane();
                    vm = FrameworkApplication.Panes.Create(id, new object[] { view }) as LayersPaneViewModel;
                    created = true;
                }
            }

            //if we did not create it, then activate it
            if (!created)
            {
                vm.Activate();
            }
            ProjectModule.CurrentProject.State = ProjectState.Dirty;
            return vm;
        }

        private static LayersPaneViewModel FindPane()
        {
            if (_viewPane != null)
            {
                LayersPaneViewModel vm = null;
                _viewPane.TryGetTarget(out vm);
                if (vm != null)
                    return (LayersPaneViewModel)FrameworkApplication.Panes.FindPane(vm.InstanceID);
            }
            return null;
        }


        internal static void PaneCreated(LayersPaneViewModel pane)
        {
            // When opening a project, the workflow pane can be created directly so we need to be able to notify the module it was created
            _viewPane = new WeakReference<LayersPaneViewModel>(pane);
        }
    }
}
