﻿using Newtonsoft.Json;
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
        private readonly string baseUrl = "http://localhost:51155/api";
        //public ObservableCollection<Onderneming> Ondernemingen { get; set; } = new ObservableCollection<Onderneming>();

        public async Task <List<OndernemingList>> GetOndernemingenAsync()
        {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(new Uri("http://localhost:51155/api/Ondernemings"));
                var lst = JsonConvert.DeserializeObject<List<OndernemingList>>(json);
                return lst;
            


        }

        public async Task<List<OndernemingList>> GetOndernemingenAsync(Categorie cat)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:51155/api/Ondernemings"));
            var lst = JsonConvert.DeserializeObject<List<OndernemingList>>(json);
            return lst;



        }

    }
}
