using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public class OndernemingList
    {
        public string categorie { get; set; }
        public List<Onderneming> ondernemingen { get; set; }

        public OndernemingList(string cat)
        {
            categorie = cat;
            ondernemingen = new List<Onderneming>();
        }
    }
}
