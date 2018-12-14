using NL4_Vanderperre_Lucas_Laureyns_Piet.Assets;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Data;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections;
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

        public Stack<string> queue { get; set; } = new Stack<string>();

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
            NavView.IsBackEnabled = true;

            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(SettingPage));
                NavView.Header = "Settings";
                queue.Push("settings");
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                navigate(item.Tag.ToString());
            }
        }

        public void NavigateHome()
        {
            NavView.SelectedItem = NavView.MenuItems.ElementAt(2);
        }

        public void NavigateRegistreer()
        {
            ContentFrame.Navigate(typeof(RegistreerPage));
        }


        public void NavigateContentFrame(OndernemingList ondernemingen)
        {
            NavView.IsBackEnabled = true;

            int index = System.Enum.GetValues(typeof(Categorie)).Cast<Categorie>().ToList().IndexOf(ondernemingen.categorie);

            NavView.SelectedItem = NavView.MenuItems.ElementAt(index + 4);

            //ContentFrame.Navigate(typeof(ContentListPage));
            //ContentListPage page = (ContentListPage)ContentFrame.Content;
            //page.viewModel.ondernemingen = ondernemingen;
            //NavView.Header = ondernemingen.categorie.ToString();
            // queue.Push(ondernemingen.categorie.ToString());

        }

        private void navigate(string tag)
        {
            NavView.IsBackEnabled = true;
            switch (tag)
            {
                case "settings":
                    ContentFrame.Navigate(typeof(SettingPage));
                    NavView.Header = "Settings";
                    queue.Push("settings");
                    break;
                case "home":
                    NavView.Header = "Home";
                    ContentFrame.Navigate(typeof(HomePage));
                    queue.Push(tag);
                    break;
                case "profiel":
                    if (User.Username != null && User.Username != "")
                    {
                        ContentFrame.Navigate(typeof(ProfielPage));
                        NavView.Header = "Profiel";
                    }
                    else
                    {
                        ContentFrame.Navigate(typeof(LoginPage));
                        NavView.Header = "Profiel";
                    }
                    queue.Push(tag);
                    break;
                case "about":
                    ContentFrame.Navigate(typeof(RegistreerPage));
                    NavView.Header = "About";
                    queue.Push(tag);
                    break;
                default:
                    // ContentListPage page = (ContentListPage)ContentFrame.Content;
                    Categorie myCategorie;
                    System.Enum.TryParse(tag, out myCategorie);
                    categorie = myCategorie;
                    ContentFrame.Navigate(typeof(ContentListPage));
                    NavView.Header = tag;
                    queue.Push(tag);
                    break;
            }
        }


        public void NavView_Back(NavigationView sender, NavigationViewBackRequestedEventArgs e)
        {
            if (queue.Count() == 0 || queue.Count() == 1)
            {
                NavView.IsBackEnabled = false;
            }
            else
            {
                queue.Pop();
                string tag = queue.Pop();
                //navigate(tag);


                switch (tag)
                {
                    case "settings":
                        NavView.SelectedItem = NavView.SettingsItem;
                        break;
                    case "home":
                        NavView.SelectedItem = NavView.MenuItems.ElementAt(2);
                        break;
                    case "about":
                        NavView.SelectedItem = NavView.MenuItems.ElementAt(System.Enum.GetValues(typeof(Categorie)).Cast<Categorie>().ToList().Count() + 5);
                        break;
                    case "profiel":
                        NavView.SelectedItem = NavView.MenuItems.ElementAt(1);
                        break;
                    default:
                        Categorie myCategorie;
                        System.Enum.TryParse(tag, out myCategorie);
                        int index = System.Enum.GetValues(typeof(Categorie)).Cast<Categorie>().ToList().IndexOf(myCategorie);

                        NavView.SelectedItem = NavView.MenuItems.ElementAt(index + 4);
                        break;
                }
                if (queue.Count() == 1)
                {
                    NavView.IsBackEnabled = false;
                }

            }


        }
    }
}
