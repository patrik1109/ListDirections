using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListDirections.Models
{
    /// <summary>
    /// This class is not stored in database.
    /// </summary>
    public class Visitor
    {
        private string _login;

        public Visitor() { _login = HttpContext.Current.User.Identity.Name; }

        public Visitor(string login) { _login = login; }

        private Tuple<MainProcess, bool>[] _processes = null;
        public Tuple<MainProcess, bool>[] User_Processes
        {
            get
            {
                if (_processes == null) _processes = ContextProcess.Object.Acceses.Where(a => a.UserName == _login)
                    .Select(a => Tuple.Create<MainProcess, bool>(ContextProcess.Object.MainProceses.Find(a.ProcessID), a.ReadOnly)).ToArray();
                return _processes;
            }
        }
    }
}