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
    public class PromotieController
    {
        public async Task<Promotie> CreatePromotie(Promotie promotie, int ondernemingsId)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(new Uri("http://localhost:51155/api/Promoties/" + ondernemingsId), promotie);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Promotie>();
            return result;
        }

        public async Task<Promotie> DeletePromotie(Promotie promotie)
        {
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync("http://localhost:51155/api/Promoties/" + promotie.PromotieId);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Promotie>();
            return result;
        }

        public async Task<Promotie> UpdatePromotie(Promotie promotie)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync(new Uri("http://localhost:51155/api/Promoties/" + promotie.PromotieId), promotie);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Promotie>();
            return result;
        }

        public async Task<List<Promotie>> getPromoties()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:51155/api/Promoties"));
            var lst = JsonConvert.DeserializeObject<List<Promotie>>(json);
            return lst;
        }

    }
}
