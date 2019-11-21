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
                temp.TruckNumber = trip.TruckNumber;
                temp.DateDeparted = trip.DateDeparted;
                temp.DateReturned = trip.DateReturned;
                temp.MilesDriven = trip.MilesDriven;
                temp.GallonsPurchased = trip.GallonsPurchased;
                temp.TripNumber = trip.TripNumber;
                temp.StateCode = trip.StateCode;
                temp.Location = trip.Location;
               
                detailReport.Add(temp);
            }

            return detailReport;
        }

        public IEnumerable<Trip> GetExceptionReport(Except exception, Inequality inequality, string value)
        {
                if(exception == Except.Miles)
                {
                     int val = Int32.Parse(value);
                    if (inequality == Inequality.Greater_Than)
                    {
                        return TripMilesGreaterThan(val);
                    }
                    else
                    {
                        return TripMilesLessThan(val);
                    }

                }
                else if(exception == Except.Gallons)
                {
                    int val = Int32.Parse(value);
                    if (inequality == Inequality.Greater_Than)
                    {
                        return TripGallonsGreaterThan(val);
                    }
                    else
                    {
                        return TripGallonsLessThan(val);
                    }
                }
                else if(exception == Except.Return)
                {
                    DateTime dt = DateTime.Parse(value.ToString());

                    if (inequality == Inequality.Greater_Than)
                    {
                        return TripReturnDateAfter(dt);
                    }
                    else
                    {
                        return TripReturnDateBefore(dt);
                    }
                }
                else if(exception == Except.Depart)
                {
                    DateTime dt = DateTime.Parse(value.ToString());
                    if (inequality == Inequality.Greater_Than)
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
            List<Trip> summary = new List<Trip>();
            foreach (Trip trip in Database.tripList)
            {
                Trip temp = new Trip();

                temp.MilesDriven = trip.MilesDriven;
                temp.GallonsPurchased = trip.GallonsPurchased;
                temp.TripNumber = trip.TripNumber;
                temp.TaxesPaid = trip.TaxesPaid;

                summary.Add(temp);
            }

            return summary;
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
            return Database.tripList.Where(x => x.DateReturned <= date);
        }

        public IEnumerable<Trip> TripReturnDateAfter(DateTime date)
        {
            return Database.tripList.Where(x => x.DateReturned >= date);
        }

        public IEnumerable<Trip> TripDepartDateBefore(DateTime date)
        {
            return Database.tripList.Where(x => x.DateDeparted <= date);
        }

        public IEnumerable<Trip> TripDepartDateAfter(DateTime date)
        {
            return Database.tripList.Where(x => x.DateDeparted <= date);
        }
    }
}