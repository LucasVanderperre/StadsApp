using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class OndernemingPageViewModel
    {
        public Onderneming onderneming { get; set; }
        GebruikerController controller { get; set; } = new GebruikerController();

        public OndernemingPageViewModel()
        {


        }

        public async Task<bool> checkAbonnee()
        {
            var abon = await controller.GetAbonnementen(User.Username);
            foreach (var item in abon)
            {
                if(item.Onderneming == onderneming)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
