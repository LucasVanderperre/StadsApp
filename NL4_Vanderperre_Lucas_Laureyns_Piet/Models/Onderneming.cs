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

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public class Onderneming
    {
        public string Naam { get; set; }
        public Categorie Categorie { get; set; }
        public string Soort { get; set; }
        public List<Adres> Adressen { get; set; } = new List<Adres>();
        public List<Openingsuren> Openingsuren { get; private set; } = new List<Openingsuren>(7);
        public string Facebook { get; set; }
        public BitmapImage Image { get; set; } = new BitmapImage();
        public List<Promotie> Promoties { get; set; }
        public List<Event> Events { get; set; }

        public Onderneming(string naam, Categorie categorie, Adres adres)
        {
            Naam = naam;
            Categorie = categorie;
            Adressen.Add(adres);
            Image = new BitmapImage(new Uri("ms-appx:///NL4_Vanderperre_Lucas_Laureyns_Piet/Assets/Square44x44Logo.scale-200.png"));
            BitmapImage bi = new BitmapImage();

        }

        public override string ToString()
        {
            StringBuilder me = new StringBuilder();

            foreach (Openingsuren openTime in Openingsuren)
                me.AppendLine(openTime.HoursOfOperation());

            return me.ToString();
        }
    }
}
