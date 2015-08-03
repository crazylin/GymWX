using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GymModel
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class GymContext : DbContext
    {
         public GymContext()
             : base("name=GymConnStr")
         {
         }

         public virtual DbSet<GymClub> GymClubs { set; get; }
         public virtual DbSet<Area> Areas { set; get; }
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
         }
    }
}
