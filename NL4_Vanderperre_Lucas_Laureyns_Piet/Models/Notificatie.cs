using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public class Notificatie
    {
        public int NotificatieId { get; set; }
        public string Titel { get; set; }
        public DateTime Toegevoegd { get; set; }
        public DateTime StartDatum { get; set; }
        public bool Gelezen { get; set; }
    }
}
