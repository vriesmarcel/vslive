using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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


    public List<Session> GetSessionsForEvent(int eventId, Action<object> OnSuccess, Action<Exception> OnFail)
    {
      var sessions = from session in EventsModel.Current.Sessions
                     where session.EventId == eventId
                     select session;

      List<Session> resultList = null;
      // push some work to the background thread and then dispatch it again on the main thread
      // just to show the proofpoint of device abstraction layer
      DeviceContext.DeviceContext.Current.RunOnBackground(() =>
      {
        // you can see that this is run on the background since the UI will not lockup and
        // keeps responsive for the five seconds delay
        int x = 0;
        while (x < 1000000)
          x++;
        // now we want to signal back the success we acieved
        DeviceContext.DeviceContext.Current.RunOnForeground(() =>
        {
          resultList = sessions.ToList();
          OnSuccess(resultList);
        });
      });

      return resultList;
    }

  }
}
