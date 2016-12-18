using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListDirections.Models
{
    public class AccessRights
    {
        public int ID { get; set; }
        
        [Index]
        public int ProcessID { get; set; }

        [MaxLength(50), Index]
        public string UserName { get; set; }

        public bool ReadOnly { get; set; }
    }
}