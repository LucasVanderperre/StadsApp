using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class ProfielPageViewModel
    {
        private LoginController LogController { get; set; } = new LoginController();
        public Klant klant { get; set; }
        public Dictionary<Notificatie, Onderneming> Notificaties { get; set; } = new Dictionary<Notificatie, Onderneming>();
        public GebruikerController GebrController { get; set; } = new GebruikerController();

        public ProfielPageViewModel()
        {
           
        }

        public void LogOut()
        {
            LogController.LogOut();
        }

        public async Task getAbonnementen()
        {
            klant = await GebrController.GetAbonnementen(User.Username);
            foreach(var item in klant.Abonnementen)
            {
                foreach(var not in item.Notificaties)
                {
                    Notificaties.Add(not, item.Onderneming);

                }
            }
            Notificaties.OrderBy(o => o.Key.Toegevoegd);

        }

        public async Task NotificatieGelezen(Notificatie notificatie)
        {
            await GebrController.NotificatieGelezen(notificatie);
        }
    }
}
