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
    public sealed partial class PromotiesPage : Page
    {
        public PromotiesPageViewModel ViewModel { get; set; } = new PromotiesPageViewModel();

        public PromotiesPage()
        {
            this.InitializeComponent();
        }

        private async void PromotieClick(object sender, RoutedEventArgs e)
        {
            
            int ondernemingsId = ViewModel.getOndernemingIdOfPromotie(((Promotie)promoties.SelectedItem).PromotieId);
            Onderneming onderneming = await ViewModel.getOndernemingWithId(ondernemingsId);
            Frame parentFrame = Window.Current.Content as Frame;
            AppRoot root = parentFrame.Content as AppRoot;
            root.NavigateOndernemingFrame(onderneming);
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = (PromotiesPageViewModel)e.Parameter;

            progressring.IsActive = true;
            txtLaden.Visibility = Visibility.Visible;
            await ViewModel.getPromoties();
            promoties.ItemsSource = ViewModel.Promoties;
            progressring.IsActive = false;
            txtLaden.Visibility = Visibility.Collapsed;

        }
    }
}
