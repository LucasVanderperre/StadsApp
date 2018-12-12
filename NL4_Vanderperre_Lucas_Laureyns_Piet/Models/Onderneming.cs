using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Drawing;
using System.ComponentModel;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public class Onderneming
    {
        public string Naam { get; set; }
        public Categorie Categorie { get; set; }
        public string Soort { get; set; }
        public List<Adres> Adressen { get; set; } = new List<Adres>();
        public List<Openingsuren> Openingsuren { get; set; }
        public string Facebook { get; set; }
        public BitmapImage Image { get; set; } = new BitmapImage();
        public List<Promotie> Promoties { get; set; }
        public List<Event> Events { get; set; }
        public string ImageUrl { get; set; }
        public string FacebookUrl { get { return "https://" + Facebook; }  }
        public bool hasEvents { get { return Events.Count > 0; } }
        public bool hasPromoties { get { return Promoties.Count > 0; } }

        public Onderneming(string naam, Categorie categorie, Adres adres, List<Openingsuren> openingsuren)
        {
            Naam = naam;
            Categorie = categorie;
            Openingsuren = openingsuren;
            Adressen.Add(adres);
            switch (categorie) // ImageUrl zal nog als string moeten opgeslaan worden in db + mss nog wat extra fotos opzoeken.
            {
                case Categorie.Winkel:
                    ImageUrl = "/Assets/winkel_icon.png";
                    break;
                case Categorie.Café:
                    ImageUrl = "/Assets/cafe_icon.png";
                    break;
                case Categorie.Restaurant:
                    ImageUrl = "/Assets/restaurant_icon.png";
                    break;
                case Categorie.School:
                    ImageUrl = "/Assets/school_icon.png";
                    break;
                default:
                    ImageUrl = "/Assets/Square44x44Logo.scale-200.png";
                    break;
            }
        }

        public string OpeningsurenToString
        {
            get { 
                StringBuilder me = new StringBuilder();

                foreach (Openingsuren openTime in Openingsuren)
                    me.AppendLine(openTime.HoursOfOperation);

                return me.ToString();
            }
        }
    }
}
