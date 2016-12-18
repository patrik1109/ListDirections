using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ListDirections.Models
{
    public class MainProcess 
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        
        public string WorkingDir { get; set; }
        
        public string FinalScript { get; set; }

        public Shedule[] Process_Shedule
        {
            get
            {
                ContextProcess db = new ContextProcess();
                Shedule[] result = db.Sheduls.Where(s => s.ProcessID == ID).ToArray();
                return result;
            }
        }

       public History Process_History
        {
            get
            {
                ContextProcess db = new ContextProcess();
                History result = db.Historys.Where(s => s.ProcessID == ID).SingleOrDefault();
                return result;
            }
        }                  
        

    }


}