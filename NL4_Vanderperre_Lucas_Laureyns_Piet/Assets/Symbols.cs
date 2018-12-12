using NL4_Vanderperre_Lucas_Laureyns_Piet.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Assets
{
    public class Symbols
    {
        public Dictionary<Categorie, FontIcon> symbolen { get; set; } = new Dictionary<Categorie, FontIcon>();

        public Symbols()
        {
            FontIcon icon = new FontIcon();
            FontFamily fam = new FontFamily("Segoe MDL2 Assets");
            icon.FontFamily = fam;
            icon.Glyph = "\uED56;";
            symbolen.Add(Categorie.Restaurant, icon);
            symbolen.Add(Categorie.Winkel, icon);
            symbolen.Add(Categorie.Café, icon);
            symbolen.Add(Categorie.School, icon);
/*
            icon.Glyph = "\uE7BF;";
            symbolen.Add(Categorie.Winkel, icon);
            icon.Glyph = "\uEC32;";
            symbolen.Add(Categorie.Café, icon);
            icon.Glyph = "\uF180;";
            symbolen.Add(Categorie.School, icon);
            */
        }
        //https://www.fileformat.info/info/unicode/font/segoe_ui_symbol/index.htm
    }
}
