using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Web_app_Projet.Models
{
    public partial class Account
    {
        public Account()
        {
            Users = new HashSet<User>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AuthorId { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
