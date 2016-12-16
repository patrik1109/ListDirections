using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ListDirections.Models
{
    public class ContextProcess : DbContext
    {
        public DbSet<MainProcess> MainProceses { get; set; }
        public DbSet<History> Historys { get; set; }
        public DbSet<AccessRights> Acceses { get; set; }
        public DbSet<Shedule> Sheduls { get; set; }
        public DbSet<PreRequisite> PreRequisites { get; set; }
    }
}