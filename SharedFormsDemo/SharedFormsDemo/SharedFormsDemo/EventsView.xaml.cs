using Shared.Controller;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Shared
{
	public partial class EventsView
	{
		public EventsView ()
		{
			InitializeComponent ();
		}

    public async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
      var item = e.SelectedItem as Event;
      if (item != null)
      {
        var sessions = await EventsController.Current.GetSessionsForEvent(item.EventId);
        var page = new EventDetail();
        page.BindingContext = sessions;
        await Navigation.PushAsync(page);
      }
    }
	}
}
