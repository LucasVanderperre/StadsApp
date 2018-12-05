using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public class Openingsuren
    {
        public DayOfWeek Day { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }


        public Openingsuren(DayOfWeek theDay, string startTime, string endTime)
        {
            Day = theDay;
            OpenTime = startTime ?? "0000";
            CloseTime = endTime ?? "0000";
        }

        public string HoursOfOperation()
        {
            return String.Format("{0} : {1} tot {2}", Day, OpenTime, CloseTime);
        }


    }
}
