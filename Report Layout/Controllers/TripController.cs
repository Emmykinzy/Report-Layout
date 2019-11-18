using Report_Layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Report_Layout.Controllers
{
    public class TripController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {

            // new trip class object 
            Trip trip = new Trip();

            // Retrieve data from Form 

            trip.TruckNumber = collection["truckNum"];

            trip.DriverNumber = collection["driverNum"];

            trip.CoDriverNumber = collection["co-driverNum"];

            trip.TripNumber = collection["tripNum"];

            trip.DateDeparted = Convert.ToDateTime(collection["dateDeparted"]);

            trip.DateReturned = Convert.ToDateTime(collection["dateReturn"]);

            trip.StateCode = collection["state"];

            trip.MilesDriven = Convert.ToInt32(collection["milesDriven"]);

            trip.ReceiptNumber = collection["receiptNum"];

            trip.GallonsPurchased = Convert.ToDouble(collection["gallonsPurchased"]);

            trip.TaxesPaid = Convert.ToDouble(collection["taxesPaid"]);

            trip.StationName = collection["stationName"];

            trip.Location = collection["stationLocation"];


            // Manipulation 
            Database.tripList.Add(trip);

            // Return Report? 
            //  ViewBag or Session? 

            //Session["trip"] = trip;

            // retreieve the trip class object in report or elsewhere 


            return RedirectToAction("Success");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}