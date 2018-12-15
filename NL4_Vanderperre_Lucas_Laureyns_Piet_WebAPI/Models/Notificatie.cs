using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models
{
    [Table("Notificatie")]
    public class Notificatie
    {
        [Key]
        public int NotificatieId { get; set; }
        public string Titel { get; set; }
        public DateTime Toegevoegd { get; set; }
        public DateTime StartDatum { get; set; }
        public bool Gelezen { get; set; } = false;
    }
}