using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SharedDemos.wp8.Resources;
using SharedDemos.wp8.ViewModels;
using Shared.Model;

namespace SharedDemos.wp8
{
    public partial class MainPage : PhoneApplicationPage
    {
        MainViewModel _viewModel = null;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            lstEvents.SelectionChanged += lstEvents_SelectionChanged;
        }

        void lstEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedEvent = (Event)lstEvents.SelectedItem;
            EventsModel.Current.SelectedEventID = selectedEvent.EventId;
            NavigationService.Navigate(new Uri("/EventDetails.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (_viewModel == null)
                _viewModel = new MainViewModel();
            
            this.DataContext = _viewModel;
        }

    }
}