using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListDirections.Models
{
    public class MainProcess
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string WorkingDir { get; set; }
        public string FinalScript { get; set; }
    }
}