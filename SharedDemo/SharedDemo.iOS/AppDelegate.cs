using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SharedDemo.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;
    

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);
            UINavigationController controller = new UINavigationController(new MainViewController());
            
            window.RootViewController = controller;

            window.MakeKeyAndVisible();

            return true;
        }
    }
}

