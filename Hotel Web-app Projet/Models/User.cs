using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Web_app_Projet.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
