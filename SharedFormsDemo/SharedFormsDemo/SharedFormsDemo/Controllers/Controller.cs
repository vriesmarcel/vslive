using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Controller
{
  public class EventsController
  {
    static EventsController _instance = null;
    public static EventsController Current
    {
      get
      {
        if (_instance == null)
        {
          _instance = new EventsController();
        }
        return _instance;
      }
    }


    public List<Event> GetEvents()
    {
      return EventsModel.Current.Events;
    }


    public async Task<List<Session>> GetSessionsForEvent(int eventId)
    {
      var sessions = from session in EventsModel.Current.Sessions
                     where session.EventId == eventId
                     select session;

      List<Session> resultList = null;

      // push some work to the background thread and then dispatch it again on the main thread
      // just to show the proofpoint of device abstraction layer
      resultList = await Task.Run<List<Session>>(async () =>
        {
          await Task.Delay(2000);
          return sessions.ToList();
        });

      return resultList;
    }

  }
}
