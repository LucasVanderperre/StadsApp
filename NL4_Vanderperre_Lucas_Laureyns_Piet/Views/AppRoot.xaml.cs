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
                    case "winkel":
                        ContentFrame.Navigate(typeof(ContentListPage));
                        NavView.Header = "Winkels";
                        break;
                    case "cafe":
                        ContentFrame.Navigate(typeof(ContentListPage));
                        NavView.Header = "Cafés";
                        break;
                    case "restaurant":
                        ContentFrame.Navigate(typeof(ContentListPage));
                        NavView.Header = "Restaurants";
                        break;
                    case "about":
                        ContentFrame.Navigate(typeof(ContentListPage));
                        NavView.Header = "About";
                        break;
                }
            }
        }
    }
}
