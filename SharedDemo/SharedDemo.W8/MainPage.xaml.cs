using Shared.Model;
using SharedDemos.wp8.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SharedDemo.W8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        MainViewModel _viewModel = null;
        public MainPage()
        {
            this.InitializeComponent();
            lstEvents.SelectionChanged += lstEvents_SelectionChanged;
        }

        void lstEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.SelectedSession = ((Event)lstEvents.SelectedItem).EventId;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (_viewModel == null)
                _viewModel = new MainViewModel();

            this.DataContext = _viewModel;
        }
    }
}
