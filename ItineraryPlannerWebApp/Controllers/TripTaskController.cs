using IPBLL;
using IPENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItineraryPlannerWebApp.Controllers
{
    public class TripTaskController : Controller
    {
        // GET: TripTask
        public ActionResult Index(int tripId)
        {
            TripTaskService tts = new TripTaskService();
            var tripTasks = tts.GetTripTasks(tripId);

            TempData["tripId"] = tripId;


            return View(tripTasks);
        }

        public ActionResult CreateTripTask()
        {
            TripTask tripTask = null; // Here, its a reference of TripTask

            int tripId = (int)TempData["tripId"];

            if (tripId != 0)
                tripTask = new TripTask() { TripId = tripId }; // Here, the reference is becoming an object.

            return View(tripTask);
        }

        [HttpPost]
        public ActionResult CreateTripTask(TripTask tripTask)
        {
            return null;
            // call business logic layer AddTripTask()
        }
       
    }
}