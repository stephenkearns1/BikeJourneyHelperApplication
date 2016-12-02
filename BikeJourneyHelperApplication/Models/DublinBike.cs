using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeJourneyHelperApplication.Models
{
    public class DublinBike
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DublinBikeID { get; set; }
        public string Location { get; set; }
        public int Available { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}