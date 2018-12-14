﻿using NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels;
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
    public sealed partial class LoginPage : Page
    {
        public LoginPageViewModel ViewModel { get; set; } = new LoginPageViewModel();


        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void PassportSignInButton_Click(object sender, RoutedEventArgs args){
            try
            {
                ViewModel.Login();
                Frame parentFrame = Window.Current.Content as Frame;
                //parentFrame.Navigate(typeof(MainPage));
                AppRoot root = parentFrame.Content as AppRoot;
                //root.Nav
                root.NavigateHome();
            }
            catch(Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
            

        }
        private void RegisterButtonTextBlock_OnPointerPressed(object sender, RoutedEventArgs args)
        {
            Frame parentFrame = Window.Current.Content as Frame;
            //parentFrame.Navigate(typeof(MainPage));
            AppRoot root = parentFrame.Content as AppRoot;
            //root.Nav
            root.NavigateRegistreer();
        }
    }
}
