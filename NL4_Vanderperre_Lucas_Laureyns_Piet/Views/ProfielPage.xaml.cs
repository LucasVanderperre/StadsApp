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
            AppRoot root = parentFrame.Content as AppRoot;
            root.NavigateLogin();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            progressring.IsActive = true;
            txtLaden.Visibility = Visibility.Visible;

            await ViewModel.getAbonnementen();
            List<Notificatie> lijst = ViewModel.Notificaties.Keys.ToList();
            if(lijst.Count == 0)
            {
                notificatieHeader.Visibility = Visibility.Collapsed;
                notificaties_listview.ItemsSource = lijst;
            }
            else
            {
                notificaties_listview.ItemsSource = lijst;
            }
            ondernemingen_listview.ItemsSource = ViewModel.klant.Abonnementen;
            username.Text = ViewModel.klant.username;
            voornaam.Text = ViewModel.klant.voornaam;
            familienaam.Text = ViewModel.klant.naam;
            email.Text = ViewModel.klant.Email;

            if (ViewModel.klant.Abonnementen.Count() == 0)
            {
                txtGeenGevonden.Visibility = Visibility.Visible;
                listviews.Visibility = Visibility.Collapsed;
            }

            progressring.IsActive = false;
            txtLaden.Visibility = Visibility.Collapsed;
        }

        //navigeert naar een geabonneerde onderneming die wordt geselecteerd
        private void Onderneming_Click(object sender, RoutedEventArgs args)
        {
            Frame parentFrame = Window.Current.Content as Frame;
            AppRoot root = parentFrame.Content as AppRoot;
            root.NavigateOndernemingFrame(((Abonnement)ondernemingen_listview.SelectedItem).Onderneming);
        }


        //navigeert naar de onderneming die bij de notificatie hoort
        private async void Notificatie_Click(object sender, RoutedEventArgs args)
        {
            Frame parentFrame = Window.Current.Content as Frame;
            AppRoot root = parentFrame.Content as AppRoot;
            Onderneming onderneming = ViewModel.Notificaties[(Notificatie)notificaties_listview.SelectedItem];
            
            root.NavigateOndernemingFrame(onderneming);
            await ViewModel.NotificatieGelezen((Notificatie)notificaties_listview.SelectedItem);
        }

    }
}
