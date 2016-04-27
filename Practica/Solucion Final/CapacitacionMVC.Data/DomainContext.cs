using CapacitacionMVC.Data.Migrations;
using CapacitacionMVC.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacitacionMVC.Data
{
    public class DomainContext : DbContext
    {
        public DomainContext() : base("DomainContext")
        {
            Database.SetInitializer<DomainContext>(new MigrateDatabaseToLatestVersion<DomainContext, Configuration>());
        }

        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Movie> Movies { get; set; }
    }
}
