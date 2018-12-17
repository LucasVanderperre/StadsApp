using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class EditOndernemingPageViewModel
    {
        public Onderneming onderneming { get; set; }
        public EventController eventController { get; set; } = new EventController();
        public PromotieController promotieController { get; set; } = new PromotieController();
        public Categorie[] categories { get; set; }

        public EditOndernemingPageViewModel()
        {
            categories = (Categorie[]) System.Enum.GetValues(typeof(Categorie));
        }

        public async Task wijzigPromotie(int id)
        {
            var index = this.onderneming.Promoties.FindIndex(p => p.PromotieId == id);
            if (index != -1)
            {
                Promotie updatedPromotie = await this.promotieController.UpdatePromotie(this.onderneming.Promoties.ElementAt(index));
                onderneming.Promoties.RemoveAt(index);
                onderneming.Promoties.Add(updatedPromotie);
            }
        }

        public void setOpeningsUren()
        {
            if(onderneming.Openingsuren.Count < 7)
            {
                onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Monday, "00:00", "00:00"));
                onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Tuesday, "00:00", "00:00"));
                onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Wednesday, "00:00", "00:00"));
                onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Thursday, "00:00", "00:00"));
                onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Friday, "00:00", "00:00"));
                onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Saturday, "00:00", "00:00"));
                onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Sunday, "00:00", "00:00"));
            }
        }

        public async Task wijzigEvent(int id)
        {
            var index = this.onderneming.Promoties.FindIndex(p => p.PromotieId == id);
            if (index != -1)
            {
                await this.promotieController.DeletePromotie(this.onderneming.Promoties.ElementAt(index));
                this.onderneming.Promoties.RemoveAt(index);
            }
        }


        public async Task deletePromotie(int id)
        {
            var index = this.onderneming.Promoties.FindIndex(p => p.PromotieId == id);
            if(index != -1)
            {
                await this.promotieController.DeletePromotie(this.onderneming.Promoties.ElementAt(index));
                this.onderneming.Promoties.RemoveAt(index);
            }
        }

        public async Task deleteEvent(int id)
        {
            var index = this.onderneming.Events.FindIndex(p => p.EventId == id);
            if (index != -1)
            {
                await this.eventController.DeleteEvent(this.onderneming.Events.ElementAt(index));
                this.onderneming.Events.RemoveAt(index);
            }
        }
    }
}
