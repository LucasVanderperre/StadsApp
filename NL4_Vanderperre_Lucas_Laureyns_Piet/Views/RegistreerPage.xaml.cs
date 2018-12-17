using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
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
    public sealed partial class RegistreerPage : Page
    {
        public RegistreerPageViewModel ViewModel { get; set; } = new RegistreerPageViewModel();

        public RegistreerPage()
        {
            this.InitializeComponent();
        }

        // past het ondernemingspaneel aan bij het aanvinken van de checkbox
        private void CheckBox_Click(object sender, RoutedEventArgs args)
        {

            if (Ondernemer_Checkbox.IsChecked == true)
            {
                OndernemerPanel.Visibility = Visibility.Visible;
                registreerKlantBtn.Visibility = Visibility.Collapsed;
                registreerOndernemerBtn.Visibility = Visibility.Visible;
            }
            else
            {
                OndernemerPanel.Visibility = Visibility.Collapsed;
                registreerKlantBtn.Visibility = Visibility.Visible;
                registreerOndernemerBtn.Visibility = Visibility.Collapsed;
            }
        }

        //submit knop van de form
        private async void RegistreerKlant(object sender, RoutedEventArgs args)
        {
            try
            {
                    await ViewModel.Registreer(false, Categorie.Winkel);
                    Frame parentFrame = Window.Current.Content as Frame;
                    AppRoot root = parentFrame.Content as AppRoot;
                    root.NavigateProfiel();
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }

        }

        private async void RegistreerOndernemer(object sender, RoutedEventArgs args)
        {
            try
            {
                await ViewModel.Registreer(true, (Categorie)categorie.SelectedItem);
                Frame parentFrame = Window.Current.Content as Frame;
                AppRoot root = parentFrame.Content as AppRoot;
                root.NavigateProfiel();
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }

        }

    }
}
