using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers
{
    public class EventController
    {
        public async Task<Event> CreateEvent(Event Event, int ondernemingsId)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(new Uri("http://localhost:51155/api/Events/"+ondernemingsId), Event);
            //response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Event>();
            return result;
        }

        //public async Task<Klant> DeleteEvent(Klant gebruiker)
        //{
        //    HttpClient client = new HttpClient();
        //    var response = await client.PostAsJsonAsync("http://localhost:51155/api/Gebruikers", gebruiker);
        //    response.EnsureSuccessStatusCode();
        //    var result = await response.Content.ReadAsAsync<Klant>();
        //    // return URI of the created resource.
        //    return result;
        //}

        //public async Task<List<Abonnement>> UpdateEvent(string gebruiker)
        //{
        //    HttpClient client = new HttpClient();
        //    var json = await client.GetStringAsync(new Uri("http://localhost:51155/api/Gebruikers/" + gebruiker));
        //    var lst = JsonConvert.DeserializeObject<Klant>(json);
        //    return lst.Abonnementen;

        //}
    }
}
