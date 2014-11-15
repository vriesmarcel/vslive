using Shared.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Shared
{
	public class App
	{
		public static Page GetMainPage()
		{
      //return new ContentPage
      //{
      //  Content = new Label {
      //    Text = "Hello, Forms !",
      //    VerticalOptions = LayoutOptions.CenterAndExpand,
      //    HorizontalOptions = LayoutOptions.CenterAndExpand,
      //  },
      //};
      var page = new EventsView();
      var events = EventsController.Current.GetEvents();
      page.BindingContext = events;

      return page;
		}
	}
}
