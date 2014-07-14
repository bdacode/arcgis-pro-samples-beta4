using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace UCSamples.FrameworkState
{
    /// <summary>
    /// Toggle the application state. Activating or Deactivating a state called
    /// <b>example_state</b>. State is referred to in the DAML via a condition named <b>example_state_condition</b>.
    /// The condition is set <b>True</b> by the Framework when its underlying state is activated and
    /// <b>False</b> when its underlying state is deactivated. Multiple states can be combined into a
    /// condition using AND, OR, XOR combinations.
    /// </summary>
    internal class ToggleStateButton : Button
    {
        public const string MyStateID = "example_state";

        protected override void OnClick()
        {
            ForTheUcModule.ToggleState(MyStateID);
        }
    }
}
