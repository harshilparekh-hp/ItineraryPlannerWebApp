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
    /// TripTaskService is responsible to invoke Repository and managing business logic.
    /// </summary>
    public class TripTaskService
    {
        public List<TripTask> GetTripTasks(int tripId)
        {
            List<TripTask> triptasks = new List<TripTask>();
            TripTaskRepository ttr = new TripTaskRepository();

            triptasks = ttr.GetTripTasks(tripId);

            return triptasks;
        }

    }
}
