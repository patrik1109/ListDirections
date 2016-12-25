using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListDirections.Models
{
    public class History
    {
        public History()
        {
            UserName = System.Web.HttpContext.Current.User.Identity.Name;
        }

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

        [MaxLength(50)]
        public string UserName { get; set; }

        private PreRequisite _preRequisite = null;
        public PreRequisite PreRequisite
        {
            get
            {
                if (EventID > 0)
                {
                    if (_preRequisite == null) _preRequisite = ContextProcess.Object.PreRequisites.Find(EventID);
                    return _preRequisite;
                }
                return null;
            }
        }
    }
}