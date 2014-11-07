using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Shared.DeviceContext
{

    public partial class DeviceContext
    {
        partial void InternalRunOnForeground(Action action);
        partial void InitializeDeviceSpecific();
        private static DeviceContext _instance = null;
        private DeviceContext() { }

        public static DeviceContext Current {
            get
            {
                if (_instance == null)
                {
                    _instance = new DeviceContext();
                    _instance.InitializeDeviceSpecific();
                }
                return _instance;
            }
        }

        public void RunOnForeground(Action action)
        {
            InternalRunOnForeground(action);
        }

        partial void InternalRunOnBackground(Action action);

        public void RunOnBackground(Action action)
        {
            InternalRunOnBackground(action);
        }
    }
}