using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeJourneyHelperApplication.Models;

namespace BikeJourneyHelperApplication.DAL
{
    public class BikeJourneyHelperInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BikeJourneyHelperContext>
    {
        protected override void Seed(BikeJourneyHelperContext context)
        {
            var shops = new List<Shop>
            {
                new Shop { ShopID = 1, ShopName="MikesBikes", Address = "Dun Laoghaire", OpeningHours = "9:00 - 19:00", Lat = 53.2766f, Lng = -6.14302f},
                new Shop {ShopID = 2, ShopName="Halfords", Address = "Dun Laoghaire", OpeningHours = "9:00 - 19:00", Lat = 52.2766f, Lng = -6.14302f},
                new Shop { ShopID =3, ShopName="Smiths", Address = "Dun Laoghaire", OpeningHours = "9:00 - 19:00", Lat = 53.2766f, Lng = -6.14302f},
                new Shop {ShopID = 4, ShopName="Spokes man", Address = "Dun Laoghaire", OpeningHours = "9:00 - 19:00", Lat = 54.2766F, Lng = -6.14302f}

            };

            shops.ForEach(shop => context.Shops.Add(shop));
            context.SaveChanges();

            var garages = new List<Garage>
            {
                new Garage { Name = "Texaco", Address = "Ballyogan road",OpeningHours = "09:00 - 18:00", PumpsAvailable = "Yes" ,  Lat =53.340962f, Lng = -6.262287f },
                new Garage { Name = "Maxoil", Address = "Sallynoggin road",OpeningHours = "09:00 - 18:00", PumpsAvailable = "Yes" ,  Lat =53.340962f, Lng = -6.262287f },
                new Garage { Name = "On the run", Address = "Ballyogan road",OpeningHours = "09:00 - 18:00", PumpsAvailable = "Yes" ,  Lat =53.340962f, Lng = -6.262287f }

            };

            garages.ForEach(garage => context.Garages.Add(garage));
            context.SaveChanges();

            var bikeRepairShops = new List<BikeRepairShop>
            {
                new BikeRepairShop {ShopName ="MikesBikes", Address = "Dun Laoghaire", OpeningHours = "9:00 - 19:00" , Lat = 53.55632, Lng = -6.85757 },
                new BikeRepairShop {ShopName ="BikesRus", Address = "Dun Laoghaire", OpeningHours = "9:00 - 19:00" , Lat = 53.55632, Lng = -6.85757 },
                new BikeRepairShop {ShopName ="Bikes", Address = "Dun Laoghaire", OpeningHours = "9:00 - 19:00" , Lat = 53.55632, Lng = -6.85757},


            };

            bikeRepairShops.ForEach(repairShop => context.BikeRepairShop.Add(repairShop));
            context.SaveChanges();

            var dublinbikes = new List<DublinBike>
            {
                new DublinBike { DublinBikeID = 1, Location = "CHATHAM STREET", Lat = 53.340962, Lng = -6.262287},
                new DublinBike { DublinBikeID  = 2, Location = "BLESSINGTON STREET",  Lat = 53.356769, Lng = -6.26814},
                new DublinBike { DublinBikeID  = 3, Location = "CHATHAM STREET",  Lat = 53.340962, Lng = -6.262287},
                new DublinBike { DublinBikeID  = 4, Location = "CHATHAM STREET",  Lat = 53.340962, Lng = -6.262287},
                new DublinBike { DublinBikeID  = 5, Location = "CHATHAM STREET",  Lat = 53.340962, Lng = -6.262287},
                new DublinBike { DublinBikeID  = 6, Location = "CHATHAM STREET",  Lat = 53.340962, Lng = -6.262287},

            };

            dublinbikes.ForEach(dublinbike => context.DublinBikes.Add(dublinbike));
            context.SaveChanges();


            var notes = new List<Note>
            {
                new Note {Tittle = "My Journay to day", Content = "i enjoy my cycle today along the coast road", Date = DateTime.Parse("2016-07-01") },
                new Note {Tittle = "New route to work", Content = "I have stumbled upon a new route while communting to work, which I quite enjoy", Date = DateTime.Parse("2016-07-01") },
                new Note {Tittle = "Tighten breakes", Content = "Breaks are not stopping in a good time, need to give them a tighten", Date = DateTime.Parse("2016-07-01") },
                new Note {Tittle = "Saving for a new bike", Content = "Have started to save for a new bike", Date = DateTime.Parse("2016-07-01") }
            };

            notes.ForEach(note => context.Notes.Add(note));
            context.SaveChanges();


            /*

            var cargarages = new List<CarGarages>
            {
                new CarGarages{ Name = "Texaco", Address = "Ballyogan road", OpeningHours = "09:00 - 18:00", PumpsAvailable = "Yes" ,  Lat =53.340962, Lng = -6.262287 },
                new CarGarages{ Name = "Maxoil", Address = "Sallynoggin road",OpeningHours = "09:00 - 18:00", PumpsAvailable = "Yes" ,   Lat =53.340962, Lng = -6.262287 },
                new CarGarages { Name = "On the run", Address = "Ballyogan road",OpeningHours = "09:00 - 18:00", PumpsAvailable = "Yes" ,   Lat =53.340962, Lng = -6.262287 }

            };

            cargarages.ForEach(garage => context.CarGarages.Add(garage));
            context.SaveChanges();

    */
        }
    }
}