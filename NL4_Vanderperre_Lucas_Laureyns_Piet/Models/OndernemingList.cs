using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public class OndernemingList
    {
        public Categorie categorie { get; set; }
        public string catString { get; set; }
        public ObservableCollection<Onderneming> ondernemingen { get; set; } = new ObservableCollection<Onderneming>();

        public OndernemingList(Categorie cat)
        {
            categorie = cat;
            catString = categorie.ToString();
        }
    }
}
