using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BikeJourneyHelperApplication.Models;

namespace BikeJourneyHelperApplication.DAL
{
    public class BikeJourneyHelperContext : DbContext
    {
        public BikeJourneyHelperContext() : base("BikeJourneyHelperContext")
        {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<DublinBike> DublinBikes { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<BikeRepairShop> BikeRepairShop { get; set; }
        public DbSet<Note> Notes { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}