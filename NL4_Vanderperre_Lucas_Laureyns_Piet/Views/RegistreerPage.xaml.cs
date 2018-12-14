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

            cmbCategorie.ItemsSource = System.Enum.GetValues(typeof(Categorie)).Cast<Categorie>().ToList();
        }


        private void CheckBox_Click(object sender, RoutedEventArgs args)
        {

            if (Ondernemer_Checkbox.IsChecked == true)
            {
                OndernemerPanel.Visibility = Visibility.Visible;
            }
            else
            {
                OndernemerPanel.Visibility = Visibility.Collapsed;

            }
        }

        private async void Registreer_Click(object sender, RoutedEventArgs args)
        {
            try
            {

                if (Ondernemer_Checkbox.IsChecked == true)
                {
                    await ViewModel.Registreer(true);
                    Frame parentFrame = Window.Current.Content as Frame;
                    //parentFrame.Navigate(typeof(MainPage));
                    AppRoot root = parentFrame.Content as AppRoot;
                    //root.Nav
                    root.NavigateHome();
                }
                else
                {
                    await ViewModel.Registreer(false);
                    Frame parentFrame = Window.Current.Content as Frame;
                    //parentFrame.Navigate(typeof(MainPage));
                    AppRoot root = parentFrame.Content as AppRoot;
                    //root.Nav
                    root.NavigateHome();
                }

            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }

        }

    }
}
