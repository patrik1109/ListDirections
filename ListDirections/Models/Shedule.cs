using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListDirections.Models
{
    public class Schedule
    {
        public int ID { get; set; }

        [Index]
        public int ProcessID { get; set;}
        
        public int? DayOfWeek { get; set; }

        public int? DayOfMonth { get; set; }
        
        public int Hour { get; set; }
        
        public int Minute { get; set; }
    }
}