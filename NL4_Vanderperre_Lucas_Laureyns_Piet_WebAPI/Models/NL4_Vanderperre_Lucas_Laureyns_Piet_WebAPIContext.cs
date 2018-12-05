using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models
{
    public class NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext() : base("name=NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext")
        {
        }

        public System.Data.Entity.DbSet<NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models.Onderneming> Ondernemings { get; set; }
        public System.Data.Entity.DbSet<NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models.Abonnement> Abonnements { get; set; }
        public System.Data.Entity.DbSet<NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models.Adres> Adress { get; set; }
        public System.Data.Entity.DbSet<NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models.Event> Events { get; set; }
        public System.Data.Entity.DbSet<NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models.Gebruiker> Gebruikers { get; set; }
        public System.Data.Entity.DbSet<NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models.Klant> Klants { get; set; }
        public System.Data.Entity.DbSet<NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models.Ondernemer> Ondernemers { get; set; }
        public System.Data.Entity.DbSet<NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models.Openingsuren> Openingsurens { get; set; }
        public System.Data.Entity.DbSet<NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models.Promotie> Promoties { get; set; }

    }
}
