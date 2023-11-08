using System;
using System.Collections.Generic;

namespace airdbMVCtry.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Bookings = new HashSet<Booking>();
        }

        public int FlightId { get; set; }
        public string Source { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public string? Class { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
