using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListDirections.Models
{
    public class PreRequisite
    {
        public int ID { get; set; }
        public int ProcessID { get; set; }
        public string Name { get; set; }
        public virtual bool Chek() { return false; }
    }
}