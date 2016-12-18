using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListDirections.Models
{
    /// <summary>
    /// This class is not stored in database. And there can be only one visitor - current windows user.
    /// </summary>
    public class Visitor
    {
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