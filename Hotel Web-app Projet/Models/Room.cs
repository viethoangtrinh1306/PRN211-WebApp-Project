using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Web_app_Projet.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int TypeId { get; set; }
        public string Image { get; set; }

        public virtual RoomType Type { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
