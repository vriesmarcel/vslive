using Shared.Controller;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDemos.wp8.ViewModels
{
    public class EventDetailsViewModel : INotifyPropertyChanged
    {
        public string _resultMessage;
        private List<Session> _sessions;
        public List<Session> Sessions
        {
            get
            {
                return _sessions;
            }
            set
            {
                _sessions = value;
                NotifyPropertyChanged("Sessions");
            }
        }

        public void refreshSessions()
        {
            int eventId = EventsModel.Current.SelectedEventID;
            
            EventsController.Current.GetSessionsForEvent(eventId,
                                OnSuccess, OnFail);
        }


        public string ResultMessage
        {
            get{
                return _resultMessage;
            }
            set{

                _resultMessage = value;
                NotifyPropertyChanged("ResultMessage");
            }
        }
        
        private void OnSuccess(object obj)
        {
            Sessions = obj as List<Session>;
            ResultMessage = "Call succeeded!";
        }

        private void OnFail(Exception obj)
        {
            ResultMessage = "Call failed!";
        }

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
