namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Migrations
{
    using NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models.NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models.NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPIContext context)
        {

            context.Adress.AddOrUpdate(x => x.AdresId,
                new Adres() { AdresId = 1, Land = "België", Nummer = 44, Postcode = 9000, Stad = "Gent", Straat = "Populierstraat" },
                new Adres() { AdresId = 2, Straat = "Kazernelaan", Nummer = 800, Postcode = 9000, Stad = "Gent", Land = "België" },
                new Adres() { AdresId = 3, Straat = "Veldstraat", Nummer = 1, Postcode = 9000, Stad = "Gent", Land = "België" });
            

            context.Openingsurens.AddOrUpdate(x => x.OpeningsurenId,
                new Openingsuren() { OpeningsurenId = 1, Day = DayOfWeek.Monday, OpenTime = "09:00", CloseTime = "18:00" },
                new Openingsuren() { OpeningsurenId = 2, Day = DayOfWeek.Tuesday, OpenTime = "09:00", CloseTime = "18:00" },
                new Openingsuren() { OpeningsurenId = 3, Day = DayOfWeek.Wednesday, OpenTime = "09:00", CloseTime = "18:00" },
                new Openingsuren() { OpeningsurenId = 4, Day = DayOfWeek.Thursday, OpenTime = "09:00", CloseTime = "18:00" },
                new Openingsuren() { OpeningsurenId = 5, Day = DayOfWeek.Friday, OpenTime = "09:00", CloseTime = "18:00" },
                new Openingsuren() { OpeningsurenId = 6, Day = DayOfWeek.Saturday, OpenTime = "09:00", CloseTime = "18:00" },
                new Openingsuren() { OpeningsurenId = 7, Day = DayOfWeek.Sunday, OpenTime = "09:00", CloseTime = "18:00" });

            context.Promoties.AddOrUpdate(x => x.PromotieId,
                new Promotie() { PromotieId = 1, Naam = "1+1 Gratis", Startdatum = new DateTime(2018, 12, 12), Einddatum = new DateTime(2018, 12, 13), Beschrijving = "Bij aankoop van 1 artikel een tweede gratis", Barcode = "ABCD1234" });

            context.Events.AddOrUpdate(x => x.EventId,
                new Event() { EventId = 1, Naam = "Opendeurdag", Startdatum = new DateTime(2018, 12, 12), Einddatum = new DateTime(2018, 12, 13), Beschrijving = "Vandaag staan onze deuren open voor bezoek!!"});

            context.SaveChanges();

            List<Adres> adressen1 = new List<Adres>();
            adressen1.Add(context.Adress.OrderBy(x => x.AdresId).Skip(0).First());

            List<Adres> adressen2 = new List<Adres>();
            adressen2.Add(context.Adress.OrderBy(x => x.AdresId).Skip(1).First());

            List<Adres> adressen3 = new List<Adres>();
            adressen3.Add(context.Adress.OrderBy(x => x.AdresId).Skip(2).First());

            List<Openingsuren> openingsuren1 = new List<Openingsuren>();
            openingsuren1.Add(context.Openingsurens.OrderBy(x => x.OpeningsurenId).Skip(0).First());
            openingsuren1.Add(context.Openingsurens.OrderBy(x => x.OpeningsurenId).Skip(1).First());
            openingsuren1.Add(context.Openingsurens.OrderBy(x => x.OpeningsurenId).Skip(2).First());
            openingsuren1.Add(context.Openingsurens.OrderBy(x => x.OpeningsurenId).Skip(3).First());
            openingsuren1.Add(context.Openingsurens.OrderBy(x => x.OpeningsurenId).Skip(4).First());
            openingsuren1.Add(context.Openingsurens.OrderBy(x => x.OpeningsurenId).Skip(5).First());
            openingsuren1.Add(context.Openingsurens.OrderBy(x => x.OpeningsurenId).Skip(6).First());

            List<Promotie> promoties1 = new List<Promotie>();
            promoties1.Add(context.Promoties.OrderBy(x => x.PromotieId).Skip(0).First());

            List<Event> events1 = new List<Event>();
            events1.Add(context.Events.OrderBy(x => x.EventId).Skip(0).First());

            context.Ondernemings.AddOrUpdate(x => x.OndenemingId,
            new Onderneming()
            {
                OndenemingId = 1,
                Naam = "Schoenen Luc",
                Categorie = CategorieEnum.Winkel,
                Adressen = adressen1.ToList(),
                Facebook = "www.facebook.com/SchoenenLuc",
                Soort = "Schoenenwinkel",
                Openingsuren = openingsuren1.ToList(),
                Events = events1.ToList(),
                Promoties = promoties1.ToList()
            },
             new Onderneming()
             {
                 OndenemingId = 2,
                 Naam = "McDo",
                 Categorie = CategorieEnum.Restaurant,
                 Adressen = adressen2.ToList(),
                 Facebook = "www.facebook.com/McDo",
                 Soort = "Fast Food",
                 Openingsuren = openingsuren1.ToList(),
                 Events = events1.ToList()
             },
              new Onderneming()
              {
                  OndenemingId = 3,
                  Naam = "HoGent",
                  Categorie = CategorieEnum.School,
                  Adressen = adressen3.ToList(),
                  Facebook = "www.facebook.com/HoGent",
                  Soort = "Hogeschool",
                  Openingsuren = openingsuren1.ToList(),
                  Events = events1.ToList()
              });

            context.SaveChanges();

            List<Onderneming> ondernemingen1 = new List<Onderneming>();
            ondernemingen1.Add(context.Ondernemings.OrderBy(x => x.OndenemingId).Skip(0).First());

            List<Onderneming> ondernemingen2 = new List<Onderneming>();
            ondernemingen2.Add(context.Ondernemings.OrderBy(x => x.OndenemingId).Skip(1).First());
            ondernemingen2.Add(context.Ondernemings.OrderBy(x => x.OndenemingId).Skip(2).First());

            context.Gebruikers.AddOrUpdate(x => x.GebruikerId,
            new Ondernemer()
            {
                GebruikerId = 1,
                username = "Luc Devroe",
                password = "rootpassword",
                voornaam = "Luc",
                naam = "Devroe",
                Email = "ld@gmail.com",
                Ondernemingen = ondernemingen1
            },
            new Ondernemer()
            {
                GebruikerId = 2,
                username = "Piet Vanderperre",
                password = "rootpassword",
                voornaam = "Piet",
                naam = "Vanderperre",
                Email = "pv@gmail.com",
                Ondernemingen = ondernemingen2
            });


            context.SaveChanges();




            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
