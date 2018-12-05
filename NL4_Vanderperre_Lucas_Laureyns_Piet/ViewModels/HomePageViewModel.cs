using NL4_Vanderperre_Lucas_Laureyns_Piet.Data;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class HomePageViewModel
    {
        public DataController data { get; set; }

        public List<OndernemingList> Ondernemingen { get; set; }


        public OndernemingList Winkels { get; set; }
        public OndernemingList Cafés { get; set; }
        public OndernemingList Restaurants { get; set; }
        public OndernemingList Scholen { get; set; }


        public HomePageViewModel()
        {
           data = new DataController();

            Ondernemingen = new List<OndernemingList>();
            Winkels = new OndernemingList("Winkels");
            Cafés = new OndernemingList("Cafés");
            Restaurants = new OndernemingList("Restaurants");
            Scholen = new OndernemingList("Scholen");

            foreach (Onderneming item in data.Ondernemingen)
            {
                Winkels.ondernemingen.Add(item);
                Cafés.ondernemingen.Add(item);
                Restaurants.ondernemingen.Add(item);
                Scholen.ondernemingen.Add(item);
            }
            Ondernemingen.Add(Winkels);
            Ondernemingen.Add(Cafés);
            Ondernemingen.Add(Restaurants);
            Ondernemingen.Add(Scholen);

            /*
            repo = new DataController();
            data.Add(categories.ElementAt(0), repo.Ondernemingen);
            data.Add(categories.ElementAt(1), repo.Ondernemingen);
            data.Add(categories.ElementAt(2), repo.Ondernemingen);
            */
        }
    }
}
