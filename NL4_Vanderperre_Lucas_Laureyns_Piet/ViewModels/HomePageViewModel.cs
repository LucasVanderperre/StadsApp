using NL4_Vanderperre_Lucas_Laureyns_Piet.Data;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class HomePageViewModel
    {
      //  public DataController data { get; set; }

        private OndernemingController controller { get; set; } = new OndernemingController();
        public ObservableCollection<OndernemingList> OndernemingenPerCategorie { get; set; }

        public OndernemingList Winkels { get; set; }
        public OndernemingList Cafés { get; set; }
        public OndernemingList Restaurants { get; set; }
        public OndernemingList Scholen { get; set; }


        public HomePageViewModel()
        {
           //data = new DataController();



            OndernemingenPerCategorie = new ObservableCollection<OndernemingList>();




            /*
             *             Winkels = new OndernemingList("Winkels");
            Cafés = new OndernemingList("Cafés");
            Restaurants = new OndernemingList("Restaurants");
            Scholen = new OndernemingList("Scholen");
            Cafés.ondernemingen.Add(data.Ondernemingen.First());
            Winkels.ondernemingen.Add(data.Ondernemingen.First());

            Restaurants.ondernemingen.Add(data.Ondernemingen.First());
            Scholen.ondernemingen.Add(data.Ondernemingen.First());

            foreach (Onderneming item in data.Ondernemingen)
            {
                Winkels.ondernemingen.Add(item);
                Cafés.ondernemingen.Add(item);
                Restaurants.ondernemingen.Add(item);
                Scholen.ondernemingen.Add(item);
            }
            
            OndernemingenPerCategorie.Add(Winkels);
            OndernemingenPerCategorie.Add(Cafés);
            OndernemingenPerCategorie.Add(Restaurants);
            OndernemingenPerCategorie.Add(Scholen);
            
            /*
            repo = new DataController();
            data.Add(categories.ElementAt(0), repo.Ondernemingen);
            data.Add(categories.ElementAt(1), repo.Ondernemingen);
            data.Add(categories.ElementAt(2), repo.Ondernemingen);
            */
        }

        public async Task LoadData()
        {
            /*
            List<Onderneming> ondernemingen = new List<Onderneming>();

            ondernemingen = await controller.GetOndernemingenAsync();

            foreach (Onderneming item in ondernemingen)
            {
                switch (item.Categorie)
                {
                    case Enum.Categorie.Winkel:
                        Winkels.ondernemingen.Add(item);
                        break;
                    case Enum.Categorie.Café:
                        Cafés.ondernemingen.Add(item);
                        break;
                    case Enum.Categorie.Restaurant:
                        Restaurants.ondernemingen.Add(item);
                        break;
                    case Enum.Categorie.School:
                        Scholen.ondernemingen.Add(item);
                        break;
                }
            }
             List<int> index = new List<int>();
            int i = 0;
            foreach(OndernemingList item in OndernemingenPerCategorie)
            {
                if(item.ondernemingen.Count == 0)
                {
                    index.Add(i);
                }
                i++;
            }
            foreach(int x in index)
            {
                OndernemingenPerCategorie.RemoveAt(x);
            }
            */
            foreach (var item in (await controller.GetOndernemingenAsync()))
            {
                if(item.ondernemingen.Count != 0)
                {
                    OndernemingenPerCategorie.Add(item);
                }
                
            }

           
        }
    }
}
