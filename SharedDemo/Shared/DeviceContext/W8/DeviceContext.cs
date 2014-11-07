using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;


namespace Shared.DeviceContext
{
    public partial class DeviceContext
    {
        private CoreDispatcher _dispatcher = null;

        public DeviceContext(CoreDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            _instance = this;
        }

        partial void InternalRunOnForeground(Action action)
        {
            if (_dispatcher == null)
                throw new InvalidOperationException("You need to initialize the current dispatched, since on windows 8 we can not get the dispatcher from a non-UI thread. call the constructor in the OnLaunched event in the App Class");
            // assign to variable to get rid of compiler warning
            var result = _dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new DispatchedHandler(action));
        }
        

        partial void InternalRunOnBackground(Action action)
        {
            Task.Run(action);
        }
    }
}