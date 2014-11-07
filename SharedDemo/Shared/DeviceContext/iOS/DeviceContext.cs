using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared.DeviceContext
{
    public partial class DeviceContext
    {

        partial void InternalRunOnForeground(Action action)
        {
            UIApplication.SharedApplication.BeginInvokeOnMainThread(() => action());
        }

        partial void InternalRunOnBackground(Action action)
        {
            Task.Factory.StartNew(() =>
            {
                action();
            });			

        }
    }
}