using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class EditEventOrPromotiePageViewModel
    {

        public bool isEvent { get; set; }
        public bool isPromotie { get; set; }

        public Event Event { get;set; }
        public Promotie Promotie { get; set; }

        public EventController eventController { get; set; } = new EventController();
        public PromotieController promotieController { get; set; } = new PromotieController();

        public EditEventOrPromotiePageViewModel()
        {

        }

        public async Task eventWijzigen(DateTime date1, DateTime date2)
        {
            if (Event.Naam != "" || Event.Beschrijving != "")
            {
                Event.Startdatum = date1;
                Event.Einddatum = date2;
                await eventController.UpdateEvent(Event);
            }
            else
            {
                throw new Exception("Alle velden zijn verplicht.");
            }
        }

        public async Task promotieWijzigen(DateTime date1, DateTime date2)
        {
            if (Promotie.Naam != "" || Promotie.Beschrijving != "")
            {
                Promotie.Startdatum = date1;
                Promotie.Einddatum = date2;
                await promotieController.UpdatePromotie(Promotie);
            }
            else
            {
                throw new Exception("Alle velden zijn verplicht.");
            }
        }

    }
}
