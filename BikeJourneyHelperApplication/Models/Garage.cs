using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeJourneyHelperApplication.Models
{
    public class Garage
    {
        public int GarageID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OpeningHours { get; set; }
        public string PumpsAvailable { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
    }
}