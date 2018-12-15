using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models
{
    [Table("Abonnement")]
    public class Abonnement
    {
        [Key]
        public int AbonnementId { get; set; }
        public Onderneming Onderneming { get; set; }
        public List<Notificatie> Notificaties { get; set; } = new List<Notificatie>();

        public Abonnement()
        {
        }

        public Abonnement(Onderneming onderneming)
        {
            Onderneming = onderneming;
        }
    }
}
