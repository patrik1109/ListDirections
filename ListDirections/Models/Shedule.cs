using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListDirections.Models
{
    public class Shedule
    {
        public int ID { get; set; }
        public int ProcessID { get; set;}
        public int DayOfWeek { get; set; }
        public int DayOfMonth { get; set; }
        public DateTime TimeToRun { get; set; }
    }
}