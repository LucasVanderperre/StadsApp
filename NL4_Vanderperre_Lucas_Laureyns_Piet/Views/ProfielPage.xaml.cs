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
    public sealed partial class ProfielPage : Page
    {
        public ProfielPageViewModel ViewModel { get; set; } = new ProfielPageViewModel();

        public ProfielPage()
        {
            this.InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs args)
        {
            ViewModel.LogOut();
            Frame parentFrame = Window.Current.Content as Frame;
            //parentFrame.Navigate(typeof(MainPage));
            AppRoot root = parentFrame.Content as AppRoot;
            //root.Nav
            root.NavigateLogin();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            progressring.IsActive = true;
            txtLaden.Visibility = Visibility.Visible;

            await ViewModel.getAbonnementen();
            List<Notificatie> lijst = ViewModel.Notificaties.Keys.ToList();
            listview.ItemsSource = lijst;
            ondernemingen_listview.ItemsSource = ViewModel.klant.Abonnementen;

            progressring.IsActive = false;
            txtLaden.Visibility = Visibility.Collapsed;
            if (ViewModel.klant.Abonnementen.Count() == 0)
            {
                txtGeenGevonden.Visibility = Visibility.Visible;
            }
        }


        private void Onderneming_Click(object sender, RoutedEventArgs args)
        {
            Frame parentFrame = Window.Current.Content as Frame;
            //parentFrame.Navigate(typeof(MainPage));
            AppRoot root = parentFrame.Content as AppRoot;
            //root.Nav
            root.NavigateOndernemingFrame(((Abonnement)ondernemingen_listview.SelectedItem).Onderneming);
        }


        private void Notificaite_Click(object sender, RoutedEventArgs args)
        {
            Frame parentFrame = Window.Current.Content as Frame;
            //parentFrame.Navigate(typeof(MainPage));
            AppRoot root = parentFrame.Content as AppRoot;
            //root.Nav
            Onderneming onderneming = ViewModel.Notificaties[(Notificatie)listview.SelectedItem];
            root.NavigateOndernemingFrame(onderneming);
        }

    }
}
