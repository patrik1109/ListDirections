using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListDirections.Models
{
    public class PreRequisite
    {
        public int ID { get; set; }

        [Index]
        public int ProcessID { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }
        
        public bool Check() { return true; }
    }
}