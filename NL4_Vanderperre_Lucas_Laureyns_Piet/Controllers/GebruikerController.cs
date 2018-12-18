using Newtonsoft.Json;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers
{
    public class GebruikerController
    {

        public async Task<Ondernemer> CreateOndernemer(Ondernemer gebruiker)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync("http://localhost:51155/api/Gebruikers/Ondernemer", gebruiker);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Ondernemer>();
            // return URI of the created resource.
            return result;
        }




        public async Task<Klant> CreateKlant(Klant gebruiker)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync("http://localhost:51155/api/Klants", gebruiker);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Klant>();
            // return URI of the created resource.
            return result;
        }

        public async Task<Klant> GetAbonnementen(string gebruiker)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:51155/api/Klants/" + gebruiker));
            var lst = JsonConvert.DeserializeObject<Klant>(json);
            return lst;

        }
        public async Task CheckAbonnement(string gebruiker, Onderneming onderneming)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync("http://localhost:51155/api/Klants/Abonnement/" + gebruiker, onderneming);
            response.EnsureSuccessStatusCode();

        }


        public async Task Abonneer(Onderneming onderneming)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync("http://localhost:51155/api/Klants/VoegAboToe/" + User.Username, onderneming);
            response.EnsureSuccessStatusCode();
           
        }

        public async Task SchrijfUit(Onderneming onderneming)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync("http://localhost:51155/api/Klants/SchrijfUit/" + User.Username, onderneming);
            response.EnsureSuccessStatusCode();

        }

        public async Task<Ondernemer> GetOndernemer(string username)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:51155/api/Ondernemers/" + username));
            var ondernemer = JsonConvert.DeserializeObject<Ondernemer>(json);
            return ondernemer;
        }


        public async Task<bool> GetGebruikerIsKlant(string username)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:51155/api/Gebruikers/isKlant/" + username));
            bool isKlant = Boolean.Parse(json);
            return isKlant;
        }


        public async Task NotificatieGelezen(Notificatie notificatie)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync("http://localhost:51155/api/Notificaties/"+notificatie.NotificatieId, notificatie);
            response.EnsureSuccessStatusCode();
        }
    }
}

