using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SharedDemos.wp8.ViewModels;

namespace SharedDemos.wp8
{
    public partial class EventDetails : PhoneApplicationPage
    {
        EventDetailsViewModel _viewModel = null;
        public EventDetails()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (_viewModel == null)
                _viewModel = new EventDetailsViewModel();

            _viewModel.refreshSessions();
            this.DataContext = _viewModel;
        }
    }
}