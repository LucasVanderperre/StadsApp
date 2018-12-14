using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
using NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class OndernemingPage : Page
    {
        public OndernemingPageViewModel viewModel { get; set; } = new OndernemingPageViewModel();

        public OndernemingPage()
        {
            this.InitializeComponent();
            if (User.isKlant == true)
            {
                btnAbonneer.Visibility = Visibility.Visible;
            }
            else
            {
                btnAbonneer.Visibility = Visibility.Collapsed;
            }
        }


        public async Task AbonneeCheck()
        {
            if (User.isKlant == true)
            {
                btnAbonneer.Visibility = Visibility.Visible;

                if (await viewModel.checkAbonnee())
                {
                    btnAbonneer.Content = "Uitschrijven";
                    txtBevestiging.Text = "Zeker dat je wil uitschrijven";
                }
                else
                {
                    btnAbonneer.Content = "Abonneer";
                    txtBevestiging.Text = "Zeker dat je wil abonneren?";
                }
            }
        }

        private async void Abonneer_Click(object sender, RoutedEventArgs args)
        {
            btnAbonneer.Visibility = Visibility.Collapsed;
            try
            {
                if (btnAbonneer.Content.ToString() == "Uitschrijven")
                {
                    await viewModel.schrijfUit();
                }
                else
                {
                    await viewModel.abonneer();

                }
                await AbonneeCheck();
            }
            catch (Exception e)
            {

            }
            btnAbonneer.Visibility = Visibility.Visible;
        }
    }
}
