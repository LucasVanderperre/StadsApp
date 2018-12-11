using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
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
    public sealed partial class AppRoot : Page
    {
        public AppRoot()
        {
            this.InitializeComponent();
            foreach (Categorie item in System.Enum.GetValues(typeof(Categorie)).Cast<Categorie>())
            {
                NavigationViewItem ni = new NavigationViewItem();
                ni.Content = item.ToString();
                ni.Tag = item.ToString();
                NavView.MenuItems.Add(ni);
            }

        }


        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(SettingPage));
                NavView.Header = "Settings";
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "home":
                        NavView.Header = "Home";
                        ContentFrame.Navigate(typeof(HomePage));
                        break;
                    case "about":
                        ContentFrame.Navigate(typeof(ContentListPage));
                        NavView.Header = "About";
                        break;
                    default:
                        ContentFrame.Navigate(typeof(ContentListPage));
                        ContentListPage page = (ContentListPage)ContentFrame.Content;
                        // page.viewModel.ondernemingen = ondernemingen;
                        NavView.Header = item.Tag.ToString();
                        break;
                }
            }
        }

        public void NavigateContentFrame(OndernemingList ondernemingen)
        {
            ContentFrame.Navigate(typeof(ContentListPage));
            ContentListPage page = (ContentListPage)ContentFrame.Content;
            page.viewModel.ondernemingen = ondernemingen;
            NavView.Header = ondernemingen.categorie.ToString();
        }
    }
}
