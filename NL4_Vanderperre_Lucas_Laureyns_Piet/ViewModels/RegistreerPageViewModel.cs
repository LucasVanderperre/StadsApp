using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class RegistreerPageViewModel
    {
        public Gebruiker gebruiker { get; set; }
        public Onderneming onderneming { get; set; }
        public string categorie { get; set; }
        public string naam { get; set; }
        public string voornaam { get; set; }
        public string username { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public Adres adres { get; set; }

        private GebruikerController GebController { get; set; } = new GebruikerController();
        private LoginController LogController { get; set; } = new LoginController();

        public RegistreerPageViewModel()
        {
            onderneming = new Onderneming();
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Monday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Tuesday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Wednesday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Thursday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Friday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Saturday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Sunday, "00:00", "00:00"));
            adres = new Adres();
        }

        public async Task Registreer(bool boolean)
        {
            if (naam == null || username == null || password == null || voornaam == null || Email == null)
            {
                throw new Exception("Alle velden zijn verplicht");
            }


            if (boolean)
            {
                Ondernemer ondernemer = new Ondernemer(naam,voornaam,username,Email);
                onderneming.Adressen.Add(adres);
                Categorie myCategorie;
                System.Enum.TryParse(categorie, out myCategorie);
                onderneming.Categorie = myCategorie;
                ondernemer.Ondernemingen.Add(onderneming);
                //Toevoegen aan de databank
                gebruiker = await GebController.CreateOndernemer(ondernemer);

            }
            else
            {
                Klant klant = new Klant(naam, voornaam, username, Email);
                klant.Password = password;

                //Toevoegen aan de databank
                gebruiker = await GebController.CreateKlant(klant);
            }
           
            //login hier doorvoeren
            LogController.LoginNieuweGebruiker(gebruiker, password);

            //navigate naar homeview

        }
    }
}
