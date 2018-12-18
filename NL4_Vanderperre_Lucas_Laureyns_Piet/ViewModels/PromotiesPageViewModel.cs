using NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Data;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class PromotiesPageViewModel
    {
        public List<Promotie> Promoties { get; set; } = new List<Promotie>();
        public PromotieController promotieController { get; set; } = new PromotieController();
        public OndernemingController ondernemingController { get; set; } = new OndernemingController();
        public Dictionary<int, int> promotieOndernemingIds { get; set; } = new Dictionary<int, int>();

        public PromotiesPageViewModel()
        {

        }

        public async Task getPromoties()
        {
            List<OndernemingList> lists = await ondernemingController.GetOndernemingenAsync();
            lists.ForEach(list =>
            {
                list.ondernemingen.ToList().ForEach(onderneming =>
                {
                    onderneming.Promoties.ForEach(promotie =>
                    {
                        promotieOndernemingIds.Add(promotie.PromotieId, onderneming.OndenemingId);
                        Promoties.Add(promotie);
                    });
                });
            });
        }

        public int getOndernemingIdOfPromotie(int promotieId)
        {
            return promotieOndernemingIds[promotieId];
        }

        public async Task<Onderneming> getOndernemingWithId(int ondernemingId)
        {
            return await ondernemingController.GetOnderneming(ondernemingId);
        }

    }
}
