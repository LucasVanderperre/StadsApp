using NL4_Vanderperre_Lucas_Laureyns_Piet.Data;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.ViewModels
{
    public class ContentListPageViewModel
    {

        private OndernemingController controller { get; set; } = new OndernemingController();

        public OndernemingList ondernemingen { get; set; }

        public ContentListPageViewModel()
        {

        }

        public async Task LoadData(Categorie cat)
        {
            ondernemingen = await controller.GetOndernemingenAsync(cat);

        }
    }
}
