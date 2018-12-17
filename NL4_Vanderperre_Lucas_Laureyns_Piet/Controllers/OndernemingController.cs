using Newtonsoft.Json;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Data
{
    public class OndernemingController
    {
        //private readonly string baseUrl = "http://localhost:51155/api";
        //public ObservableCollection<Onderneming> Ondernemingen { get; set; } = new ObservableCollection<Onderneming>();

        public async Task <List<OndernemingList>> GetOndernemingenAsync()
        {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(new Uri("http://localhost:51155/api/Ondernemings"));
                var lst = JsonConvert.DeserializeObject<List<OndernemingList>>(json);
                return lst;
        }


        public async Task<OndernemingList> GetOndernemingenAsync(Categorie cat)
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("http://localhost:51155/api/Ondernemings/categorie/" + cat.ToString());
            var json = await client.GetStringAsync(uri);
            var lst = JsonConvert.DeserializeObject<OndernemingList>(json);
            return lst;
        }

        public async Task<Onderneming> UpdateOnderneming(Onderneming onderneming)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync(new Uri("http://localhost:51155/api/Ondernemings/" + onderneming.OndenemingId), onderneming);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Onderneming>();
            return result;
        }

        public async Task UpdateOpeningsuren(Openingsuren openingsuren)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync(new Uri("http://localhost:51155/api/Openingsuren/" + openingsuren.OpeningsurenId), openingsuren);
            response.EnsureSuccessStatusCode();
        }

        public async Task<OndernemingList> ZoekOndernemingenAsync(string naam)
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("http://localhost:51155/api/Ondernemings/Zoek/" + naam.ToString().ToLower());
            var json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<OndernemingList>(json);
            return result;



        }
    }
}
