namespace BikeJourneyHelperApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BikeJourneyHelperApplication.Models;
    using System.Collections.Generic;


    internal sealed class Configuration : DbMigrationsConfiguration<BikeJourneyHelperApplication.DAL.BikeJourneyHelperContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BikeJourneyHelperApplication.DAL.BikeJourneyHelperContext context)
        {
            var shops = new List<Shop>
            {
                new Shop { ShopID = 1, ShopName="MikesBikes", Address = "Dun Laoghaire", OpeningHours = "9:00 - 19:00", Lat = 53.2766f, Lng = -6.14302f},
                new Shop {ShopID = 2, ShopName="Halfords", Address = "Dun Laoghaire", OpeningHours = "9:00 - 19:00", Lat = 52.2766f, Lng = -6.14302f},
                new Shop { ShopID =3, ShopName="Smiths", Address = "Dun Laoghaire", OpeningHours = "9:00 - 19:00", Lat = 53.2766f, Lng = -6.14302f},
                new Shop {ShopID = 4, ShopName="Spokes man", Address = "Dun Laoghaire", OpeningHours = "9:00 - 19:00", Lat = 54.2766F, Lng = -6.14302f}

            };

            shops.ForEach(s => context.Shops.AddOrUpdate(shop => shop.ShopName, s));
            context.SaveChanges();

            var garages = new List<Garage>
            {
                new Garage { Name = "Texaco", Address = "1 Tallaght road",OpeningHours = "09:00 - 18:00", PumpsAvailable = "Yes" ,  Lat =53.340962f, Lng = -6.262287f },
                new Garage { Name = "Maxoil", Address = "65 Sallynoggin road",OpeningHours = "09:00 - 18:00", PumpsAvailable = "Yes" ,  Lat =53.340962f, Lng = -6.262287f },
                new Garage { Name = "On the run", Address = "89 Ballyogan road",OpeningHours = "09:00 - 18:00", PumpsAvailable = "Yes" ,  Lat =53.340962f, Lng = -6.262287f }

            };

            garages.ForEach(garage => context.Garages.AddOrUpdate(g => g.Address, garage));
            context.SaveChanges();

            var bikeRepairShops = new List<BikeRepairShop>
            {
                new BikeRepairShop {ShopName ="MikesBikes", Address = " 1Sallynoggin road", Number = "01234356", OpeningHours = "9:00 - 19:00" , Lat = 53.2919, Lng = -6.1366 },
                new BikeRepairShop {ShopName ="BikesRus", Address = " 9 Dun Laoghaire road",Number = "012564736", OpeningHours = "9:00 - 19:00" , Lat = 53.55632, Lng = -6.85757 },
                new BikeRepairShop {ShopName ="Halfords", Address = " 8 Ballyogan road",Number = "01348546", OpeningHours = "9:00 - 19:00" , Lat = 53.2512, Lng = -6.1868},
                new BikeRepairShop {ShopName ="RepairsOnWheels", Address = "7 Tallaght square", Number = "01232356", OpeningHours = "9:00 - 19:00" , Lat = 53.2919, Lng = -6.1366 },
                new BikeRepairShop {ShopName ="Fixes", Address = "3 Dun Laoghaire harbour road",Number = "012564746", OpeningHours = "9:00 - 19:00" , Lat = 53.55632, Lng = -6.85757 },
                new BikeRepairShop {ShopName ="Commute", Address = "123 Dun Laoghaire square",Number = "01348546", OpeningHours = "9:00 - 19:00" , Lat = 53.2512, Lng = -6.1868}


            };

            bikeRepairShops.ForEach(repairShop => context.BikeRepairShop.AddOrUpdate(s => s.Address, repairShop));
            context.SaveChanges();

            var dublinbikes = new List<DublinBike>
            {
                new DublinBike { DublinBikeID = 1, Location = "CHATHAM STREET", Lat = 53.340962, Lng = -6.262287},
                new DublinBike { DublinBikeID  = 2, Location = "BLESSINGTON STREET",  Lat = 53.356769, Lng = -6.26814},
                new DublinBike { DublinBikeID  = 3, Location = "BOLTON STREET",  Lat = 53.351182, Lng = -6.269859},
                new DublinBike { DublinBikeID  = 4, Location = "GREEK STREET",  Lat = 53.340962, Lng = -6.262287},
                new DublinBike { DublinBikeID  = 5, Location = "CHARLEMONT PLACE",  Lat = 53.340962, Lng = -6.262287}
              

            };

            dublinbikes.ForEach(dublinbike => context.DublinBikes.AddOrUpdate(station => station.DublinBikeID, dublinbike));
            context.SaveChanges();


            var notes = new List<Note>
            {
                new Note {Tittle = "My Journay to day", Content = "i enjoy my cycle today along the coast road", Date = DateTime.Parse("2016-07-01") },
                new Note {Tittle = "New route to work", Content = "I have stumbled upon a new route while communting to work, which I quite enjoy", Date = DateTime.Parse("2016-07-01") },
                new Note {Tittle = "Tighten breakes", Content = "Breaks are not stopping in a good time, need to give them a tighten", Date = DateTime.Parse("2016-07-01") },
                new Note {Tittle = "Saving for a new bike", Content = "Have started to save for a new bike", Date = DateTime.Parse("2016-07-01") }
            };

            notes.ForEach(note => context.Notes.AddOrUpdate(n => n.Tittle,note));
            context.SaveChanges();
        }
    }
}
