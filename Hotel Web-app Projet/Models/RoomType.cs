using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Web_app_Projet.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }
        public int Acreage { get; set; }
        public int Beds { get; set; }
        public int Bathrooms { get; set; }
        public int Capacity { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
