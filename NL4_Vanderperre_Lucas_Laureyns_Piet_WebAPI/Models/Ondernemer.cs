using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models
{
    [Table("Ondernemer")]
    public class Ondernemer : Gebruiker
    {
        public List<Onderneming> Ondernemingen { get; set; }
    }
}