using MonoTouch.UIKit;
using Shared.Controller;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedDemo.iOS.TableSources
{
    public class EventDetailsViewController : UITableViewController
    {
        public EventDetailsViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // call the load data, thsi will result async and onsuccess will be called
            // on the UI thread, so there we bind to the data source
            EventsController.Current.GetSessionsForEvent(EventsModel.Current.SelectedEventID,
                                    OnSuccess, OnFail);
        }


        private void OnSuccess(object obj)
        {
   
            this.TableView.Source = new SessionUITableSource(this, obj as List<Session>);
            ShowMessage("Call result", "Success!");
        }

        private void OnFail(Exception obj)
        {
            ShowMessage("Call result", "Failed!");
        }

        private void ShowMessage(string title, string message)
        {
            UIAlertView view = new UIAlertView(title, message, null, "OK");
            UIApplication.SharedApplication.InvokeOnMainThread(
                () => view.Show());
        }
    }
}
