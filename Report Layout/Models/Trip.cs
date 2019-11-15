using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report_Layout.Models
{
    public class Trip
    {
        public string TruckNumber { get; set; }
        public string DriverNumber { get; set; }
        public string CoDriverNumber { get; set; }
        public string TripNumber { get; set; }
        public DateTime DateDeparted { get; set; }
        public DateTime DateReturned { get; set; }
        public string StateCode { get; set; }
        public int MilesDriven { get; set; }
        public string ReceiptNumber { get; set; }
        public double GallonsPurchased { get; set; }
        public double TaxesPaid { get; set; }
        public string StationName { get; set; }
        public string Location { get; set; }
    }
}