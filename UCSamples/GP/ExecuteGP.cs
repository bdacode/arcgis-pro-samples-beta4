using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;

namespace UCSamples.GP
{
    internal class ExecuteGP : Button {

        private static readonly CancelationSource withCancelProgressor = CancelationSource.withCancelableProgressor;
        private static readonly CancelationSource withCancelToken = CancelationSource.withCancelationToken;

        protected override async void OnClick() {

            GPHelper.ExecuteBufferGP(withCancelProgressor);
        }
    }
}
