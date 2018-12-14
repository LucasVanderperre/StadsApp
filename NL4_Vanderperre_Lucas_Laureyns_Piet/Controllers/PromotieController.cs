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
            var result = await response.Content.ReadAsAsync<Promotie>();
            return result;
        }

    }
}
