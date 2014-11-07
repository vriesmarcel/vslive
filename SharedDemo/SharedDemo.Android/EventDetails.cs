using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Shared.Controller;
using Shared.Model;


namespace CodeShareDemo
{
    [Activity(Label = "Sessions")]
    public class EventDetails : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.EventDetails);
            // init an async call and the success will handle the binding of the results to the adapter
            var sessions = EventsController.Current.GetSessionsForEvent(EventsModel.Current.SelectedEventID, 
                                    OnSuccess, OnFail);
        }

        public void OnSuccess(object result)
        {
            var toast = Toast.MakeText(this, "On Success Called", ToastLength.Long);
            toast.Show();

            ListView sessionList = FindViewById<ListView>(Resource.Id.SessionListView);
            sessionList.Adapter = new SessionAdapter(this, result as List<Session>);
        }

        public void OnFail(Exception e)
        {
            var toast = Toast.MakeText(this, "On failed Called", ToastLength.Long);
            toast.Show();
        }
    }
}