using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListDirections.Models
{
    public class AccessRights
    {
        public int ID { get; set; }
        public int ProcessID { get; set; }
        public string UserName { get; set; }
        public bool ReadOnly { get; set; }
    }
}