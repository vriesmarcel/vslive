using Android.App;
using Android.Content;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Shared.DeviceContext
{
    public partial class DeviceContext
    {
        Handler _uiThreadHandler = null;
        Context _applicationContext = null;

        partial void InitializeDeviceSpecific()
        {
            // Initialize a bunch of Android specific components

            _applicationContext = Application.Context;

            // Initialize a bunch of Android specific components
            _uiThreadHandler = new Handler(_applicationContext.MainLooper);
        }

        partial void InternalRunOnForeground(Action action)
        {
            _uiThreadHandler.Post(action);
        }

        partial void InternalRunOnBackground(Action action)
        {
            action.BeginInvoke(null, null);
        }
    }
}