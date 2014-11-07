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
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _resultMessage;

        public void RefreshSessions()
        {
            EventsController.Current.GetSessionsForEvent(SelectedSession, OnSuccess, OnFail);
        }
        
        public List<Event> Events
        {
            get
            {
                return EventsController.Current.GetEvents();
            }
        }

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

        public string ResultMessage
        {
            get
            {
                return _resultMessage;
            }
            set
            {

                _resultMessage = value;
                NotifyPropertyChanged("ResultMessage");
            }
        }

        private void OnSuccess(object obj)
        {
            ResultMessage = "Call succeeded!";
            Sessions = obj as List<Session>;
        }

        private void OnFail(Exception obj)
        {
            ResultMessage = "Call failed!";
        }


        private int _selectedSession;
        public int SelectedSession
        {
            get
            { 
                return _selectedSession; 
            }
            set
            {
                _selectedSession = value;

                RefreshSessions();
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
