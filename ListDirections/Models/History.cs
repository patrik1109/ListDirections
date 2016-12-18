using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListDirections.Models
{
    public class History
    {
        public int ID { get; set; }

        [Index]
        public int SessionID { get; set;}
        
        [Index]
        public int ProcessID { get; set; }
        
        [Index]
        public int EventID { get; set; }

        [Index]
        public DateTime TimeStart { get; set; }
        
        public DateTime? TimeFinish { get; set; }
        
        public bool? Success { get; set; }
        
        public string ErrorMessage { get; set; }
    }


}