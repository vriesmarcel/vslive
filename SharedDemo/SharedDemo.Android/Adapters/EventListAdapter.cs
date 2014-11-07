using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Object = Java.Lang.Object;
using Android.App;
using Shared.Model;
using CodeShareDemo;

namespace CodeShareDemo
{
    public class EventAdapter : BaseAdapter
    {
        List<Event> _eventsList;
        Activity _activity;

        public EventAdapter(Activity activity, List<Event> events)
        {
            _activity = activity;
            _eventsList = events;
        }

        public override int Count
        {
            get
            {
                if (_eventsList != null)
                {
                    return _eventsList.Count;
                }
                else
                    return 0;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            // could wrap a Contact in a Java.Lang.Object 
            // to return it here if needed
            return null;
        }

        public override long GetItemId(int position)
        {
            return _eventsList[position].EventId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _activity.LayoutInflater.Inflate(
                Resource.Layout.EventListItem, parent, false);

            var EventName = view.FindViewById<TextView>(Resource.Id.EventName);
            var Eventdescription = view.FindViewById<TextView>(Resource.Id.EventDescription);

            EventName.Text = _eventsList[position].Name;
            Eventdescription.Text = _eventsList[position].Description;

            return view;
        }
    }
}
