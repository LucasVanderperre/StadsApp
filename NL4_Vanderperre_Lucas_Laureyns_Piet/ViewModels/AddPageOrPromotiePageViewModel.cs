using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class AddPageOrPromotiePageViewModel
    {
        public bool isEvent { get; set; }
        public bool isPromotie { get; set; }
        public string naam { get; set; }
        public string beschrijving { get; set; }
        public DateTimeOffset startDatum { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset eindDatum { get; set; } = DateTimeOffset.Now;
        public int ondernemingsId { get; set; }


        public EventController eventController { get; set; } = new EventController();
        public PromotieController promotieController { get; set; } = new PromotieController();


        public AddPageOrPromotiePageViewModel()
        {

        }

        public async Task eventAanmaken(DateTime date1, DateTime date2)
        {
            if (this.checkRequired())
            {
                await eventController.CreateEvent(new Event(naam, beschrijving, date1, date2),ondernemingsId);
            }
            else
            {
                throw new Exception("Alle velden zijn verplicht.");
            }
        }

        public async Task promotieAanmaken(DateTime date1, DateTime date2)
        {
            if (this.checkRequired())
            {
                await promotieController.CreatePromotie(new Promotie(naam, beschrijving, date1, date2, "Barcode"), ondernemingsId);
            }
            else
            {
                throw new Exception("Alle velden zijn verplicht.");
            }
        }

        private bool checkRequired()
        {
            return (naam != null || beschrijving != null);
        }


    }
}
