using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeJourneyHelperApplication.Models
{
    public class Shop
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string OpeningHours { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
    }
}