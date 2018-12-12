using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class ContentListPage : Page
    {
        //public ObservableCollection<Onderneming> ondernemingen { get; set; } = new ObservableCollection<Onderneming>();
        public ContentListPageViewModel viewModel { get; set; } = new ContentListPageViewModel();


        public ContentListPage()
        {
            this.InitializeComponent();

        }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            progressring.IsActive = true;
            txtLaden.Visibility = Visibility.Visible;
            Frame parentFrame = Window.Current.Content as Frame;
            //parentFrame.Navigate(typeof(MainPage));
            AppRoot root = parentFrame.Content as AppRoot;
            await viewModel.LoadData(root.categorie);
            gridview.ItemsSource = viewModel.ondernemingen.ondernemingen;
            progressring.IsActive = false;
            txtLaden.Visibility = Visibility.Collapsed;
            if(viewModel.ondernemingen.ondernemingen.Count() == 0)
            {
                txtGeenGevonden.Visibility = Visibility.Visible;
            }


        }


    }
}
