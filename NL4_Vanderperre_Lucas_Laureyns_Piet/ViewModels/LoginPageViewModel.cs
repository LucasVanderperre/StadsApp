using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
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
 
                LogController.Login(username, password);
           
        }
    }
}
