using NL4_Vanderperre_Lucas_Laureyns_Piet.Data;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
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
    public sealed partial class HomePage : Page
    {
        // public DataController repo { get; set; }
        // public Dictionary<string,List<Onderneming>> data { get; set; }

        public HomePageViewModel viewModel { get; set; }


        public HomePage()
        {
            this.InitializeComponent();
            this.viewModel = new HomePageViewModel();

            /* foreach (var item in System.Enum.GetNames(typeof(Categorie)))
             {
                 categories.Add(item.ToString());
             }*/
           
            




        }
    }
}
