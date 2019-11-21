using Report_Layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Report_Layout.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if(Session["new"] == null)
            {
                Database.tripList = new List<Trip>()
                {
                    new Trip() { TruckNumber = "1234", DriverNumber = "123456789", CoDriverNumber = "987654321", TripNumber = "123", DateDeparted = new DateTime(2019, 01, 25), DateReturned = new DateTime(2019, 02, 2), StateCode = "QC", MilesDriven = 200, ReceiptNumber = "132435", GallonsPurchased = 40, TaxesPaid = 10, StationName = "SHELL MONT", Location = "Montreal" },
                    new Trip() { TruckNumber = "9876", DriverNumber = "987654321", CoDriverNumber = "123456789", TripNumber = "125", DateDeparted = new DateTime(2019, 02, 5), DateReturned = new DateTime(2019, 02, 10), StateCode = "QC", MilesDriven = 500, ReceiptNumber = "315375", GallonsPurchased = 100, TaxesPaid = 15, StationName = "DEPT MONT", Location = "Longeuil" },
                    new Trip() { TruckNumber = "3142", DriverNumber = "132435467", CoDriverNumber = "978675645", TripNumber = "126", DateDeparted = new DateTime(2019, 02, 11), DateReturned = new DateTime(2019, 02, 18), StateCode = "QC", MilesDriven = 600, ReceiptNumber = "019283412", GallonsPurchased = 125, TaxesPaid = 20, StationName = "DEPT LAV", Location = "Laval" },
                    new Trip() { TruckNumber = "5647", DriverNumber = "574839273", CoDriverNumber = "132435467", TripNumber = "128", DateDeparted = new DateTime(2019, 02, 21), DateReturned = new DateTime(2019, 02, 28), StateCode = "ON", MilesDriven = 150, ReceiptNumber = "00339012", GallonsPurchased = 75, TaxesPaid = 12.5, StationName = "STA ONT", Location = "Ottawa" },
                    new Trip() { TruckNumber = "1029", DriverNumber = "978675645", CoDriverNumber = "574839273", TripNumber = "130", DateDeparted = new DateTime(2019, 03, 01), DateReturned = new DateTime(2019, 03, 04), StateCode = "QC", MilesDriven = 60, ReceiptNumber = "99037562", GallonsPurchased = 20, TaxesPaid = 5, StationName = "SHELL SALLE", Location = "LaSalle" },
                    new Trip() { TruckNumber = "9876", DriverNumber = "132435467", CoDriverNumber = "582449610", TripNumber = "131", DateDeparted = new DateTime(2019, 03, 06), DateReturned = new DateTime(2019, 03, 12), StateCode = "ON", MilesDriven = 350, ReceiptNumber = "07770243", GallonsPurchased = 50, TaxesPaid = 11, StationName = "SHELL OTTA", Location = "Burlington" },

                };
                Session["new"] = Database.tripList;
            }
            return View();
        }
    }
}