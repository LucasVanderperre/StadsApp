using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Data
{
    public class DataController
    {
        public List<Onderneming> Ondernemingen { get; set; }

        public DataController()
        {
            Ondernemingen = new List<Onderneming>();
            Onderneming ondernenming1 = new Onderneming("Schoenen Luc", Enum.Categorie.Winkel, new Adres("Populierstraat", 44, 9000, "Gent", "België"));
            Onderneming ondernenming2 = new Onderneming("HoGent", Enum.Categorie.School, new Adres("Kazernelaan", 800, 9000, "Gent", "België"));
            Onderneming ondernenming3 = new Onderneming("McDo", Enum.Categorie.Winkel, new Adres("Veldstraat", 1, 9000, "Gent", "België"));

            Ondernemingen.Add(ondernenming1);
            Ondernemingen.Add(ondernenming2);
            Ondernemingen.Add(ondernenming3);
        }
    }
}
