using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListDirections.Models
{
    public class History
    {
        public int ID { get; set; }
        public int SessionID { get; set;}
        public int ProcessID { get; set; }
        public int EventID { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeFinish { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }


}