using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Models
{
    public class Openingsuren
    {
        public int OpeningsurenId { get; set; }
        public DayOfWeek Day { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string HoursOfOperation
        {
            get {
                if(OpenTime == "00:00" && CloseTime == "00:00")
                {
                    return string.Format("{0}: gesloten", getDayOfWeek());
                }
                else
                {
                    return string.Format("{0}: {1} - {2}", getDayOfWeek(), OpenTime, CloseTime);
                }
            }
        }


        public Openingsuren(DayOfWeek theDay, string startTime, string endTime)
        {
            
            Day = theDay;
            OpenTime = startTime ?? "00:00";
            CloseTime = endTime ?? "00:00";
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
