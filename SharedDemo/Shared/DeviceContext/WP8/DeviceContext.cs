using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;


namespace Shared.DeviceContext
{
    public partial class DeviceContext
    {

        partial void InternalRunOnForeground(Action action)
        {
            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(action);
        }

        partial void InternalRunOnBackground(Action action)
        {
            Task.Run(action);
        }
    }
}