using Newtonsoft.Json;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Data;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
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
    public sealed partial class HomePage : Page
    {
        // public DataController repo { get; set; }
        // public Dictionary<string,List<Onderneming>> data { get; set; }

        public HomePageViewModel viewModel { get; set; }

        public HomePage()
        {
            this.viewModel = new HomePageViewModel();
            this.InitializeComponent();

            /* foreach (var item in System.Enum.GetNames(typeof(Categorie)))
             {
                 categories.Add(item.ToString());
             }*/

        }
        
        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            progressring.IsActive = true;
            txtLaden.Visibility = Visibility.Visible;
            await viewModel.LoadData();
            lv.ItemsSource = viewModel.OndernemingenPerCategorie;
            progressring.IsActive = false;
            txtLaden.Visibility = Visibility.Collapsed;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lv.SelectedItem != null)
            {
                Frame parentFrame = Window.Current.Content as Frame;
                AppRoot root = parentFrame.Content as AppRoot;
                root.NavigateContentFrame((OndernemingList)lv.SelectedItem);
            }
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridView grid = (GridView)sender;

            if (grid.SelectedItem != null)
            {
                Frame parentFrame = Window.Current.Content as Frame;
                AppRoot root = parentFrame.Content as AppRoot;
                root.NavigateOndernemingFrame((Onderneming)grid.SelectedItem);
            }
        }

    }
}
