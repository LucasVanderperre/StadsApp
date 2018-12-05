using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Models
{
    [Table("Openingsuren")]
    public class Openingsuren
    {
        [Key]
        public int OpeningsurenId { get; set; }
        public DayOfWeek Day { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }

        

    }
}
