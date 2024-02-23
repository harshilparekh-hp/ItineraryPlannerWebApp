using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPENTITIES
{
    /// <summary>
    /// TripTask is responsible for managing tasks for the particular trip.
    /// </summary>
    public class TripTask
    {
        public int TripTaskId { get; set; }
        public int TripId { get; set; }
        public string TaskName { get; set;}
        public string TaskDescription { get; set;}
        public DateTime TaskDueDate { get; set;}

    }
}
