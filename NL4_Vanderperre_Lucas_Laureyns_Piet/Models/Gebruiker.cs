using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public abstract class Gebruiker
    {
        public string naam { get; set; }
        public string voornaam { get; set; }
        public string username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int id { get; set; }

        public Gebruiker()
        {
         
        }

        protected Gebruiker(string naam, string voornaam, string username, string email)
        {
            this.naam = naam;
            this.voornaam = voornaam;
            this.username = username;
            Email = email;
        }
    }
}
