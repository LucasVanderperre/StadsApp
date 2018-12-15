using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public class Abonnement
    {
        public Onderneming Onderneming { get; set; }
        public List<Notificatie> Notificaties { get; set; }
    }
}
