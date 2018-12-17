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

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Views
{
    public sealed partial class AddEventOrPromotiePage : Page
    {
        public AddEventOrPromotiePageViewModel viewModel = new AddEventOrPromotiePageViewModel();

        public AddEventOrPromotiePage()
        {
            this.InitializeComponent();
        }

        public async void eventAanmaakClick(object sender, RoutedEventArgs args)
        {
            try
            {
                if(datePicker1.Date > datePicker2.Date)
                {
                    ErrorMessage.Text = "De Einddatum moet na de Startdatum komen.";
                }
                else
                {
                    await viewModel.eventAanmaken(datePicker1.Date.UtcDateTime, datePicker2.Date.UtcDateTime);
                    Frame parentFrame = Window.Current.Content as Frame;
                    AppRoot root = parentFrame.Content as AppRoot;
                    root.NavigateProfiel();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }  
        }

        public async void promotieAanmaakClick(object sender, RoutedEventArgs args)
        {
            try
            {
                if (datePicker1.Date > datePicker2.Date)
                {
                    ErrorMessage.Text = "De Einddatum moet na de Startdatum komen.";
                }
                else
                {
                    await viewModel.promotieAanmaken(datePicker1.Date.UtcDateTime, datePicker2.Date.UtcDateTime);
                    Frame parentFrame = Window.Current.Content as Frame;
                    AppRoot root = parentFrame.Content as AppRoot;
                    root.NavigateProfiel();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = (AddEventOrPromotiePageViewModel)e.Parameter;
        }
    }
}
