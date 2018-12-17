using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Naam { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public string Beschrijving { get; set; }

        public Event()
        {

        }

        public Event(string naam, string beschrijving, DateTime startdatum, DateTime einddatum)
        {
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Startdatum = startdatum;
            this.Einddatum = einddatum;
        }

        public string datum { get
            {
                return Startdatum.ToString("dd/MM/yy") + " - " + Einddatum.ToString("dd/MM/yy");
            }
        }
    }
}
