using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Model
{

    
    
    public class EventsModel
    {
        private List<Session> _sessions = null;
        private List<Event> _events = null;

        public List<Event> Events
        {
            get
            {
                if (_events == null)
                {
                    _events = new List<Event>(){
                new Event() { EventId = 1, Name = "Visual studio Live! New York", Description = "Description1" },
                new Event() { EventId = 2, Name = "Visual studio Live! Redmond", Description = "Description2" },
                new Event() { EventId = 3, Name = "Visual studio Live! Orlando", Description = "Description3" }
                };
                }

                return _events;

            }
        }

        public List<Session> Sessions
        {
            get
            {
                if (_sessions == null)
                {
                    _sessions
                        = new List<Session>(){
                        new Session() { SessionId = 1, Abstract = "Abstract 1", Event = Events[0], EventId=1, Title = "HTML5/jQuery On-Ramp" },
                        new Session() { SessionId = 2, Abstract = "Abstract 2", Event = Events[0], EventId=1, Title = "Upgrade Your Website to HTML5" },
                        new Session() { SessionId = 3, Abstract = "Abstract 3", Event = Events[0], EventId=1, Title = "Building Single Page Web applications with HTML5, ASP.NET MVC4, Upshot.js and Web API" },
                        new Session() { SessionId = 4, Abstract = "Abstract 4", Event = Events[1], EventId=2, Title = "ASP.NET and Visual Studio vNext" },
                        new Session() { SessionId = 5, Abstract = "Abstract 5", Event = Events[1], EventId=2, Title = "Using jQuery to Replace the Ajax Control Toolkit" },
                        new Session() { SessionId = 6, Abstract = "Abstract 6", Event = Events[2], EventId=3, Title = "Improving Web Site Performance and Scalability While Saving Money" },
                        new Session() { SessionId = 7, Abstract = "Abstract 7", Event = Events[2], EventId=3, Title = "Fast, Faster ... Async ASP.NET" },
                        new Session() { SessionId = 8, Abstract = "Abstract 8", Event = Events[2], EventId=3, Title = "ASP.NET MVC, Beyond the Basics" },
                        new Session() { SessionId = 9, Abstract = "Abstract 9", Event = Events[2], EventId=3, Title = "Creating a Data Driven Web Site Using WebMatrix and ASP.NET Razor" }
                        };
                }
                return _sessions;
            }
        }

        private static EventsModel _instance = null;
        public static EventsModel Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventsModel();
                }
                return _instance;
            }
        }

        public int SelectedEventID { get; set; }
    }
}