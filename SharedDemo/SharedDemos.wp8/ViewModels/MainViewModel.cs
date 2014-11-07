using Shared.Controller;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDemos.wp8.ViewModels
{
    public class MainViewModel
    {
        public List<Event> Events
        {
            get {
                return EventsController.Current.GetEvents();
            }
        }
    }
}
