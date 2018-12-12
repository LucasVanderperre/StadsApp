using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models
{
    [Table("Onderneming")]
    public class Onderneming
    {
        [Key]
        public int OndenemingId { get; set; }
        public string Naam { get; set; }
        public CategorieEnum Categorie { get; set; }
        public string Soort { get; set; }
        public List<Adres> Adressen { get; set; } = new List<Adres>();
        public List<Openingsuren> Openingsuren { get; set; } = new List<Openingsuren>();
        public string Facebook { get; set; }
        public List<Promotie> Promoties { get; set; }
        public List<Event> Events { get; set; }
    }
}