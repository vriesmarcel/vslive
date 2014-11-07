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
    public class SessionAdapter : BaseAdapter
    {
        List<Session> _sessionList;
        Activity _activity;

        public SessionAdapter(Activity activity, List<Session> events)
        {
            _activity = activity;
            _sessionList = events;
        }

        public override int Count
        {
            get
            {
                if (_sessionList != null)
                {
                    return _sessionList.Count;
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
            return _sessionList[position].EventId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _activity.LayoutInflater.Inflate(
                Resource.Layout.SessionListItem, parent, false);

            var SessionTitle = view.FindViewById<TextView>(Resource.Id.SessionTitle);
            var Sessiondescription = view.FindViewById<TextView>(Resource.Id.SessionDescription);

            SessionTitle.Text = _sessionList[position].Title;
            Sessiondescription.Text = _sessionList[position].Abstract;

            return view;
        }
    }
}
