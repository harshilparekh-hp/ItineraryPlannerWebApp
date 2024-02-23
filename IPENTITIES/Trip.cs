using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPENTITIES
{
    /// <summary>
    /// Trip is responsible for managing upcoming trips/travels.
    /// </summary>
    public class Trip
    {
        public int TripId { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
    }
}
