using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeJourneyHelperApplication.Models
{
    public class BikeRepairShop
    {
        public int BikeRepairShopID { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string OpeningHours { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}