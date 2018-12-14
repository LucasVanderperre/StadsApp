using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class LoginPageViewModel
    {
        private LoginController LogController { get; set; } = new LoginController();

        public string username { get; set; }
        public string password { get; set; }

        public void Login()
        {
            Gebruiker gb = new Klant("","",username, "");
            LogController.Login(gb, password);

        }
    }
}
