using System;
using MonoTouch.UIKit;
using System.Drawing;
using SharedDemo.iOS.TableSources;
using Shared.Controller;

namespace SharedDemo.iOS
{
    public class MainViewController : UITableViewController
    {
        

        public MainViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            this.TableView.Source = new EventUITableSource(this, EventsController.Current.GetEvents());            
        }

    }
}

