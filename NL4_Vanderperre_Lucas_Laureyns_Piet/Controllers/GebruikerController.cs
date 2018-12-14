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

        public async Task<Ondernemer> CreateOndernemer(Gebruiker gebruiker)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync("http://localhost:51155/api/Ondernemings", gebruiker);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Ondernemer>();
            // return URI of the created resource.
            return result;
        }

        public async Task<Klant> CreateKlant(Gebruiker gebruiker)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync("http://localhost:51155/api/Gebruikers", gebruiker);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Klant>();
            // return URI of the created resource.
            return result;
        }
    }
}
