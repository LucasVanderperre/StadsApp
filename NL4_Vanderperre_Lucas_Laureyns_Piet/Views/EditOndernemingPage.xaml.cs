using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditOndernemingPage : Page
    {
        public EditOndernemingPageViewModel ViewModel { get; set; } = new EditOndernemingPageViewModel();


        public EditOndernemingPage()
        {
            this.InitializeComponent();
        }

        private void addPromotieClick(object sender, RoutedEventArgs args)
        {
            Frame parentFrame = Window.Current.Content as Frame;
            AppRoot root = parentFrame.Content as AppRoot;
            root.NavigateAddEventOrPromotieFrame(false, ViewModel.onderneming.OndenemingId);
        }

        private void addEventClick(object sender, RoutedEventArgs e)
        {
            Frame parentFrame = Window.Current.Content as Frame;
            AppRoot root = parentFrame.Content as AppRoot;
            root.NavigateAddEventOrPromotieFrame(true, ViewModel.onderneming.OndenemingId);
        }

        private void wijzigPromotieClick(object sender, RoutedEventArgs e)
        {
            Frame parentFrame = Window.Current.Content as Frame;
            AppRoot root = parentFrame.Content as AppRoot;
            int id = (int)((Button)sender).Tag;
            root.NavigateEditEventOrPromotieFrame(null, ViewModel.onderneming.Promoties.Find(o => o.PromotieId == id));
        }

        private void wijzigEventClick(object sender, RoutedEventArgs e)
        {
            Frame parentFrame = Window.Current.Content as Frame;
            AppRoot root = parentFrame.Content as AppRoot;
            int id = (int)((Button)sender).Tag;
            root.NavigateEditEventOrPromotieFrame(ViewModel.onderneming.Events.Find(o => o.EventId == id),null);
        }

        private async void deletePromotieClick(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            await ViewModel.deletePromotie(id);
            promoties.ItemsSource = null;
            promoties.ItemsSource = ViewModel.onderneming.Promoties;
        }

        private async void deleteEventClick(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            await ViewModel.deleteEvent(id);
            events.ItemsSource = null;
            events.ItemsSource = ViewModel.onderneming.Events;
        }

        private void SaveOndernmingClick(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = (EditOndernemingPageViewModel) e.Parameter;
        }
    }
}
