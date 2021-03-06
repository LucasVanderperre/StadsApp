﻿using NL4_Vanderperre_Lucas_Laureyns_Piet.Data;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class ContentListPageViewModel
    {

        private OndernemingController controller { get; set; } = new OndernemingController();
        public OndernemingList ondernemingen { get; set; } = new OndernemingList(Categorie.Winkel);
        public bool zoekfunctie { get; set; } = false;
        public string zoekterm { get; set; } = "";


        public ContentListPageViewModel()
        {

        }

        public async Task LoadData()
        {
            if (zoekfunctie)
            {
                ondernemingen = await controller.ZoekOndernemingenAsync(zoekterm);
            }
            else
            {
                ondernemingen = await controller.GetOndernemingenAsync(ondernemingen.categorie);
            }
        }
    }
}
