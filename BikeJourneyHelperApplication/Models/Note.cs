using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeJourneyHelperApplication.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public string Tittle { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
  
    }
}