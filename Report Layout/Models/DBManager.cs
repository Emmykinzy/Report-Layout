using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report_Layout.Models
{
    public class DBManager
    {
        public void Add(Trip p)
        {
           
            Database.tripList.Add(p);

        }

        public List<Trip> GetDetailReport()
        {
            List<Trip> detailReport = new List<Trip>();
            foreach (Trip trip in Database.tripList)
            {
                Trip temp = new Trip();

                temp.DriverNumber = trip.DriverNumber;
                temp.CoDriverNumber = trip.CoDriverNumber;
                temp.TruckNumber = trip.TruckNumber;
                temp.DateDeparted = trip.DateDeparted;
                temp.DateReturned = trip.DateReturned;
                temp.MilesDriven = trip.MilesDriven;
                temp.GallonsPurchased = trip.GallonsPurchased;

                detailReport.Add(temp);
            }

            return detailReport;
        }

        public IEnumerable<Trip> GetExceptionReport(string exception, int value, bool GreaterThan)
        {
                if(exception == "Miles")
                {
                    if(GreaterThan)
                    {
                        return TripMilesGreaterThan(value);
                    }
                    else
                    {
                        return TripMilesLessThan(value);
                    }

                }
                else if(exception == "Gallons")
                {
                    if (GreaterThan)
                    {
                        return TripGallonsGreaterThan(value);
                    }
                    else
                    {
                        return TripGallonsLessThan(value);
                    }
                }
                else if(exception == "Return")
                {
                    DateTime dt = DateTime.Parse(value.ToString());

                    if (GreaterThan)
                    {
                        return TripReturnDateAfter(dt);
                    }
                    else
                    {
                        return TripReturnDateBefore(dt);
                    }
                }
                else if(exception == "Depart")
                {
                    DateTime dt = DateTime.Parse(value.ToString());
                    if (GreaterThan)
                    {
                        return TripDepartDateAfter(dt);
                    }
                    else
                    {
                        return TripDepartDateBefore(dt);
                    }
                }
                else
                {
                    return null;
                }        
          
        }

        public List<Trip> GetSummaryReport()
        {
            return Database.tripList;
        }

        public IEnumerable<Trip> TripMilesGreaterThan(int miles)
        {
            return Database.tripList.Where(x => x.MilesDriven >= miles);
        }

        public IEnumerable<Trip> TripMilesLessThan(int miles)
        {
            return Database.tripList.Where(x => x.MilesDriven <= miles);
        }

        public IEnumerable<Trip> TripGallonsGreaterThan(int gal)
        {
            return Database.tripList.Where(x => x.GallonsPurchased >= gal);
        }

        public IEnumerable<Trip> TripGallonsLessThan(int gal)
        {
            return Database.tripList.Where(x => x.GallonsPurchased <= gal);
        }

        public IEnumerable<Trip> TripReturnDateBefore(DateTime date)
        {
            return Database.tripList.Where(x => x.DateReturned >= date);
        }

        public IEnumerable<Trip> TripReturnDateAfter(DateTime date)
        {
            return Database.tripList.Where(x => x.DateReturned <= date);
        }

        public IEnumerable<Trip> TripDepartDateBefore(DateTime date)
        {
            return Database.tripList.Where(x => x.DateDeparted >= date);
        }

        public IEnumerable<Trip> TripDepartDateAfter(DateTime date)
        {
            return Database.tripList.Where(x => x.DateDeparted <= date);
        }
    }
}