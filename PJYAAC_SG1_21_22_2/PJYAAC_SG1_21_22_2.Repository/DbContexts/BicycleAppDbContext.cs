using System;
using Microsoft.EntityFrameworkCore;
using PJYAAC_SG1_21_22_2.Models.Entities;

namespace PJYAAC_SG1_21_22_2.Repository.DbContexts
{
    public class BicycleAppDbContext: DbContext
    {
        public BicycleAppDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BicycleAppDb.mdf;Integrated Security=true;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var bike1 = new Bicycle()
            {
                Id = 1
                , Color = "white"
                , DateOfPurchase = DateTime.Now
                , IsElectric = false
                , IsFullSuspension = false
                , Model = "Specialized"
                , Price = 100000
                , Type = "Trekking"
            };
            var bike2 = new Bicycle()
            {
                Id = 2
                , Color = "red"
                , DateOfPurchase = DateTime.Now
                , IsElectric = false
                , IsFullSuspension = false
                , Model = "Cube"
                , Price = 200000
                , Type = "Mountain Bike"
            };
            var bike3 = new Bicycle()
            {
                Id = 3
                , Color = "red"
                , DateOfPurchase = DateTime.Now
                , IsElectric = true
                , IsFullSuspension = true
                , Model = "Santa Cruz"
                , Price = 800000
                , Type = "Mountain Bike"
            };
            var bike4 = new Bicycle()
            {
                Id = 4
                , Color = "yellow"
                , DateOfPurchase = DateTime.Now
                , IsElectric = false
                , IsFullSuspension = true
                , Model = "Giant"
                , Price = 400000
                , Type = "Road bike"
            };
            var bike5 = new Bicycle()
            {
                Id = 5
                , Color = "black"
                , DateOfPurchase = DateTime.Now
                , IsElectric = true
                , IsFullSuspension = false
                , Model = "KTM"
                , Price = 500000
                , Type = "Mountain bike"
            };

            modelBuilder.Entity<Bicycle>().HasData(bike1, bike2, bike3, bike4, bike5);
        }

    }
}
