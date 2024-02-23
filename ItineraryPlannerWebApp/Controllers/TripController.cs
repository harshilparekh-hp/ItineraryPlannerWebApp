using IPBLL;
using IPENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItineraryPlannerWebApp.Controllers
{
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult Index()
        {
            TripService ts = new TripService();
            var trips = ts.GetTrips();
            return View(trips);
        }

        public ActionResult CreateTripView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTripView(Trip trip)
        {
            TripService ts = new TripService();
            if(ts.AddTripService(trip))
            {
                ViewBag.Message = "Trip is added Successfully";
            }
        
            return View();
        }

        /// <summary>
        /// EditTripView is used to return View with record based on TripId
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public ActionResult EditTripView(int tripId)
        {
            TripService ts = new TripService();
            return View(ts.GetTrips().Find(x => x.TripId == tripId));
        }

        /// <summary>
        /// EditTripView is used to update the record and pass that to Service and Repository.
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="trip"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTripView(Trip trip) 
        {
            TripService ts = new TripService();
            if (ts.UpdateTripService(trip))
            {
                ViewBag.Message = "Trip is updated successfully";
            }

            return View();
        }

        public ActionResult DeleteTrip(int tripId)
        {
            TripService ts = new TripService();
            if (ts.DeleteTripService(tripId))
            {
                return RedirectToAction("Index");
            }
            return null;
        }



    }
}