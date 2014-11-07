using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Model
{
    public class Session
    {
        public int SessionId { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool Attended { get; set; } // did you attend the session?
    }

}