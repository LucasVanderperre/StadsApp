using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models
{
    [Table("Gebruiker")]
    public class Gebruiker
    {
        [Key]
        public int GebruikerId { get; set; }
        public string naam { get; set; }
        public string voornaam { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
    }
}