using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Shared.Model;
using Shared.Controller;

namespace CodeShareDemo
{
    [Activity(Label = "Events", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            ListView eventsList = FindViewById<ListView>(Resource.Id.EventsListView);
            // get a list of events from my controller....
            var events = EventsController.Current.GetEvents();
            eventsList.Adapter = new EventAdapter(this, events);
            eventsList.ItemClick += eventsList_ItemClick;
        }

        void eventsList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            EventsModel.Current.SelectedEventID = Convert.ToInt32(e.Id);
            StartActivity(typeof(EventDetails));
        }

        
    }
}

