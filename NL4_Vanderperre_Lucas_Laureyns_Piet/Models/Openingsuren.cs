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
        public string HoursOfOperation
        {
            get { return string.Format("{0}: {1} - {2}", getDayOfWeek(), OpenTime, CloseTime); }
        }


        public Openingsuren(DayOfWeek theDay, string startTime, string endTime)
        {
            
            Day = theDay;
            OpenTime = startTime ?? "0000";
            CloseTime = endTime ?? "0000";
        }

        public string getDayOfWeek()
        {
            switch (Day)
            {
                case DayOfWeek.Monday: return "ma";
                case DayOfWeek.Tuesday: return "di";
                case DayOfWeek.Wednesday: return "wo";
                case DayOfWeek.Thursday: return "do";
                case DayOfWeek.Friday: return "vr";
                case DayOfWeek.Saturday: return "za";
                case DayOfWeek.Sunday: return "zo";
                default: return "";
            }

        }
    }
}
