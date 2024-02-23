using IPDAL;
using IPENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBLL
{
    /// <summary>
    /// TripService is responsible to invoke Repository and managing business logic.
    /// </summary>
    public class TripService
    {
        public List<Trip> GetTrips()
        {
            List<Trip> trips = new List<Trip>();
            TripRepository tr = new TripRepository();
            
            trips = tr.GetTrips();

            return trips;
        }

        public bool AddTripService(Trip trip)
        {
            TripRepository tr = new TripRepository();
            return tr.AddTrip(trip);
        }

        public bool UpdateTripService(Trip trip)
        {
            TripRepository tr = new TripRepository();
            return tr.UpdateTrip(trip);
        }

        public bool DeleteTripService(int tripId) 
        {
            TripRepository tr = new TripRepository();
            return tr.DeleteTrip(tripId);
        }

    }
}
