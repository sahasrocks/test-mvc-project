using System;
using System.Collections.Generic;

namespace airdbMVCtry.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public string? UserId { get; set; }
        public int? FlightId { get; set; }
        public int NoOfPassengers { get; set; }
        public string? Status { get; set; }
        public int? Price { get; set; }

        public virtual Flight? Flight { get; set; }
        public virtual User? User { get; set; }
    }
}
