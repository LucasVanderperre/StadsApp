using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class ProfielOndernemerPageViewModel
    {
        private LoginController LogController { get; set; } = new LoginController();
        public Ondernemer ondernemer { get; set; }
        public GebruikerController GebrController { get; set; } = new GebruikerController();


        public ProfielOndernemerPageViewModel()
        {

        }

        public void LogOut()
        {
            LogController.LogOut();
        }

        public async Task getOndernemer()
        {
            ondernemer = await GebrController.GetOndernemer(User.Username);
        }
    }
}
