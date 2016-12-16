using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListDirections.Models
{
    public class Visitor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }

        public AccessRights [] ProcesesID_Read
        {
            get
            {
                ContextProcess db = new ContextProcess();
                AccessRights[] result = db.Acceses.Where(s => s.UserName  == Login && s.ReadOnly == true).ToArray();
                return result;
            }
        }
    }
}