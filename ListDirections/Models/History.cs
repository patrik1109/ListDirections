﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListDirections.Models
{
    public class History
    {
        public int SessionID { get; set;}
        public int ProcessID { get; set; }
        public int EventID { get; set; }
        public DateTime Time { get; set; }
    }
}