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
        public List<Openingsuren> Openingsuren { get; set; } = new List<Openingsuren>(7);
        public string Facebook { get; set; }
        public BitmapImage Image { get; set; } = new BitmapImage();
        public List<Promotie> Promoties { get; set; } = new List<Promotie>();
        public List<Event> Events { get; set; } = new List<Event>();

        public Onderneming()
        {
            Openingsuren.Add(new Openingsuren(DayOfWeek.Monday, "00:00", "00:00"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Tuesday, "00:00", "00:00"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Wednesday, "00:00", "00:00"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Thursday, "00:00", "00:00"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Friday, "00:00", "00:00"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Saturday, "00:00", "00:00"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Sunday, "00:00", "00:00"));
        }

        public Onderneming(string naam, Categorie categorie, Adres adres)
        {
            Naam = naam;
            Categorie = categorie;
            Adressen.Add(adres);
            Image = new BitmapImage(new Uri("ms-appx:///NL4_Vanderperre_Lucas_Laureyns_Piet/Assets/Square44x44Logo.scale-200.png"));
            BitmapImage bi = new BitmapImage();
            Openingsuren.Add(new Openingsuren(DayOfWeek.Monday, "0000", "0000"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Tuesday, "0000", "0000"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Wednesday, "0000", "0000"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Thursday, "0000", "0000"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Friday, "0000", "0000"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Saturday, "0000", "0000"));
            Openingsuren.Add(new Openingsuren(DayOfWeek.Sunday, "0000", "0000"));


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
