using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models
{
    public class OndernemingList
    {
        public CategorieEnum categorie { get; set; }
        public List<Onderneming> ondernemingen { get; set; } = new List<Onderneming>();

        public OndernemingList(CategorieEnum categorie)
        {
            this.categorie = categorie;
        }
    }
}