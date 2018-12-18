using NL4_Vanderperre_Lucas_Laureyns_Piet.Data;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class AddOndernemingPageViewModel
    {
        public Onderneming onderneming { get; set; }
        public OndernemingController ondernemingController { get; set; } = new OndernemingController();
        public Categorie[] categories { get; set; }
        public Adres adres { get; set; }
        public int ondernemerId { get; set; }

        public AddOndernemingPageViewModel()
        {
            categories = (Categorie[])System.Enum.GetValues(typeof(Categorie));

            onderneming = new Onderneming();
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Monday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Tuesday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Wednesday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Thursday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Friday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Saturday, "00:00", "00:00"));
            onderneming.Openingsuren.Add(new Openingsuren(DayOfWeek.Sunday, "00:00", "00:00"));
            adres = new Adres();
            onderneming.Categorie = Categorie.Winkel;
        }

        public async Task CreateOnderneming(Categorie categorie)
        {
            if (onderneming.Naam == null || onderneming.Soort == null || adres.Land == null || adres.Stad == null || adres.Straat == null)
            {
                throw new Exception("Gelieve alle velden in te vullen.");
            }
            else
            {
                this.onderneming.Openingsuren.ForEach(o =>
                {
                    if (!IsValidTimeFormat(o.CloseTime) || !IsValidTimeFormat(o.OpenTime))
                    {
                        throw new Exception("De openingsuren zijn niet correct ingegeven, gelieve het correcte formaat(vb. 19:30) te gebruiken.");
                    }
                });
                onderneming.Adressen.Add(adres);
                onderneming.Categorie = categorie;
                await ondernemingController.CreateOnderneming(onderneming, ondernemerId);
            }
        }

        public bool IsValidTimeFormat(string input)
        {
            TimeSpan dummyOutput;
            return TimeSpan.TryParse(input, out dummyOutput);
        }
    }
}
