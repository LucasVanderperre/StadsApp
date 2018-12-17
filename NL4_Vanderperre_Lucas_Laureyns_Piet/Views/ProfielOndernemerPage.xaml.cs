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
    public sealed partial class ProfielOndernemerPage : Page
    {

        public ProfielOndernemerPageViewModel ViewModel { get; set; } = new ProfielOndernemerPageViewModel();

        public ProfielOndernemerPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            progressring.IsActive = true;
            txtLaden.Visibility = Visibility.Visible;

            await ViewModel.getOndernemer();
            List<Onderneming> lijst = ViewModel.ondernemer.Ondernemingen.ToList();
            listview.ItemsSource = lijst;
            username.Text = ViewModel.ondernemer.username;
            voornaam.Text = ViewModel.ondernemer.voornaam;
            familienaam.Text = ViewModel.ondernemer.naam;
            email.Text = ViewModel.ondernemer.Email;


            progressring.IsActive = false;
            txtLaden.Visibility = Visibility.Collapsed;
        }

        private void Logout_Click(object sender, RoutedEventArgs args)
        {
            ViewModel.LogOut();
            Frame parentFrame = Window.Current.Content as Frame;
            AppRoot root = parentFrame.Content as AppRoot;
            root.NavigateLogin();
        }

        private void OndernemingClicked(object sender, RoutedEventArgs args)
        {
            Frame parentFrame = Window.Current.Content as Frame;
            AppRoot root = parentFrame.Content as AppRoot;
            root.NavigateOndernemingFrame((Onderneming)listview.SelectedItem);
        }

        private void OndernemingWijzigClicked(object sender, RoutedEventArgs args)
        {
            int id = (int) ((Button)sender).Tag;
            Frame parentFrame = Window.Current.Content as Frame;
            AppRoot root = parentFrame.Content as AppRoot;
            root.NavigateEditOndernemingFrame(ViewModel.ondernemer.Ondernemingen.Find(o => o.OndenemingId == id));
        }
    }
}
