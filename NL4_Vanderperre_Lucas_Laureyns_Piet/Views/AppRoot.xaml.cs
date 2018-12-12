using NL4_Vanderperre_Lucas_Laureyns_Piet.Assets;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Data;
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
        public Categorie categorie { get; set; }

        public AppRoot()
        {
            this.InitializeComponent();
            Symbols syms = new Symbols();

            NavigationViewItem nit = new NavigationViewItem();
            nit.Content = "Home";
            nit.Tag = "home";
            nit.Icon = new SymbolIcon(Symbol.Home);
            NavView.MenuItems.Add(nit);
            NavigationViewItemHeader hdr = new NavigationViewItemHeader();
            hdr.Content = "Ondernemingen";
            NavView.MenuItems.Add(hdr);
            foreach (Categorie item in System.Enum.GetValues(typeof(Categorie)).Cast<Categorie>())
            {

                NavigationViewItem ni = new NavigationViewItem();
                ni.Content = item.ToString();
                ni.Tag = item.ToString();
                ni.Icon = new SymbolIcon(Symbol.Home);
               // ni.Icon = (FontIcon)(syms.symbolen.First().Value);
                NavView.MenuItems.Add(ni);
            }
            hdr = new NavigationViewItemHeader();
            hdr.Content = "Info";
            NavView.MenuItems.Add(hdr);
            nit = new NavigationViewItem();
            nit.Content = "About";
            nit.Tag = "about";
            nit.Icon = new SymbolIcon((Symbol)0xE946);
            NavView.MenuItems.Add(nit);

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
                       // ContentListPage page = (ContentListPage)ContentFrame.Content;
                        Categorie myCategorie;
                        System.Enum.TryParse(item.Tag.ToString(), out myCategorie);
                        categorie = myCategorie;
                        ContentFrame.Navigate(typeof(ContentListPage));
                        NavView.Header = item.Tag.ToString();
                        break;
                }
            }
        }

        public void NavigateContentFrame(OndernemingList ondernemingen)
        {
            int index = System.Enum.GetValues(typeof(Categorie)).Cast<Categorie>().ToList().IndexOf(ondernemingen.categorie);

            NavView.SelectedItem = NavView.MenuItems.ElementAt(index+3);

            ContentFrame.Navigate(typeof(ContentListPage));
            //ContentListPage page = (ContentListPage)ContentFrame.Content;
            //page.viewModel.ondernemingen = ondernemingen;
            NavView.Header = ondernemingen.categorie.ToString();
        }

        public void NavigateOndernemingFrame(Onderneming onderneming)
        {
            ContentFrame.Navigate(typeof(OndernemingPage));
            OndernemingPage page = (OndernemingPage)ContentFrame.Content;
            page.viewModel.onderneming = onderneming;
            //page.viewModel.ondernemingen = ondernemingen;
            NavView.Header = onderneming.Naam;
        }
    }
}
