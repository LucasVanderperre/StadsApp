using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public class Promotie
    {
        public int PromotieId { get; set; }
        public string Naam { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public string Beschrijving { get; set; }
        public string Barcode { get; set; }

        public Promotie()
        {

        }

        public Promotie(string naam, string beschrijving, DateTime startdatum, DateTime einddatum, string barcode)
        {
            this.Naam = naam;
            this.Startdatum = startdatum;
            this.Einddatum = einddatum;
            this.Beschrijving = beschrijving;
            this.Barcode = RandomString(8);
        }
        public string datum{
            get{
                return Startdatum.ToString("dd/MM/yy") + " - " + Einddatum.ToString("dd/MM/yy");
            }
        }

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
