using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ListDirections.Models
{
    public class ContextProcess : DbContext
    {
        private static ContextProcess _instance = null;
        public static ContextProcess Object
        {
            get
            {
                if (_instance == null) _instance = new ContextProcess();
                return _instance;
            }
        }

        public DbSet<MainProcess> MainProceses { get; set; }
        public DbSet<History> Historys { get; set; }
        public DbSet<AccessRights> Acceses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<PreRequisite> PreRequisites { get; set; }
    }
}