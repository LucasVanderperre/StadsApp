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
    public class EventController
    {
        public async Task<Event> CreateEvent(Event Event, int ondernemingsId)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(new Uri("http://localhost:51155/api/Events/"+ondernemingsId), Event);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Event>();
            return result;
        }

        public async Task<Event> DeleteEvent(Event Event)
        {
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync("http://localhost:51155/api/Events/"+ Event.EventId);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Event>();
            return result;
        }

        public async Task<Event> UpdateEvent(Event Event)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync(new Uri("http://localhost:51155/api/Events/" + Event.EventId), Event);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Event>();
            return result;
        }
    }
}
