using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
   public class Adres
    {
        public string Straat { get; set; }
        public int Nummer { get; set; }
        public int Postcode { get; set; }
        public string Stad { get; set; }
        public string Land { get; set; }
        public string adresStraat
        {
            get { return Straat + " " + Nummer; }
        }
        public string adresStad
        {
            get { return Postcode + " " + Stad; }
        }

        public Adres(string straat, int nummer, int postcode, string stad, string land)
        {
            Straat = straat;
            Nummer = nummer;
            Postcode = postcode;
            Stad = stad;
            Land = land;
        }
    }
}
