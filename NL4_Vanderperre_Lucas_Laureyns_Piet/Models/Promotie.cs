using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public class Promotie
    {
        public string Naam { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public string Beschrijving { get; set; }
        public string Barcode { get; set; }
        public string datum{
            get{
                return Startdatum.ToString("dd/MM/yy") + " - " + Einddatum.ToString("dd/MM/yy");
            }
        }

    }
}
