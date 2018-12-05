using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models
{
    [Table("Adres")]
    public class Adres
    {
        [Key]
        public int AdresId { get; set; }
        public string Straat { get; set; }
        public int Nummer { get; set; }
        public int Postcode { get; set; }
        public string Stad { get; set; }
        public string Land { get; set; }
    }
}