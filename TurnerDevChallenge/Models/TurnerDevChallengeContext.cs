using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TurnerDevChallenge.Models
{
    public class TurnerDevChallengeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TurnerDevChallengeContext() : base("name=TurnerDevChallengeContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //THIS IS THE MOST ANNOYING THING IN THE WORLD WHY ON EARTH DOES IT DO THIS INSTEAD OF WHAT I'M EXPLICITLY TELLING IT TO DO
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<TurnerDevChallenge.Models.Title> Titles { get; set; }
    }
}
