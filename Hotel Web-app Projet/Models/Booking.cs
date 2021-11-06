using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Web_app_Projet.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int People { get; set; }
        public double Total { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
