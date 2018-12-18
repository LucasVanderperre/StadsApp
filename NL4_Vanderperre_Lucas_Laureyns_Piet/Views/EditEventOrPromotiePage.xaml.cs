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
    public sealed partial class EditEventOrPromotiePage : Page
    {
        public EditEventOrPromotiePageViewModel ViewModel { get; set; } = new EditEventOrPromotiePageViewModel();
        public EditEventOrPromotiePage()
        {
            this.InitializeComponent();
        }

        public async void eventWijzigClick(object sender, RoutedEventArgs args)
        {
            try
            {
                if (datePicker1.Date > datePicker2.Date)
                {
                    ErrorMessage.Text = "De Einddatum moet na de Startdatum komen.";
                }
                else
                {
                    await ViewModel.eventWijzigen(datePicker1.Date.UtcDateTime, datePicker2.Date.UtcDateTime);
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

        public async void promotieWijzigClick(object sender, RoutedEventArgs args)
        {
            try
            {
                if (datePicker3.Date > datePicker4.Date)
                {
                    ErrorMessage.Text = "De Einddatum moet na de Startdatum komen.";
                }
                else
                {
                    await ViewModel.promotieWijzigen(datePicker3.Date.UtcDateTime, datePicker4.Date.UtcDateTime);
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
            ViewModel = (EditEventOrPromotiePageViewModel)e.Parameter;
        }
    }
}
