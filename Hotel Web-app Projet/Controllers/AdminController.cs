using Hotel_Web_app_Projet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Web_app_Projet.Controllers
{
    public class AdminController : Controller
    {
        HotelWebsiteContext context = new();
        public override ViewResult View()
        {
            ViewBag.RoomTypes = context.RoomTypes.ToList();
            return base.View();
        }
        public IActionResult UserManagement()
        {
            ViewBag.UserList = context.Users.ToList();
            return View();
        }
        public IActionResult RoomManagement()
        {
            ViewBag.RoomList = context.Rooms.ToList();
            return View();
        }
        public IActionResult BookingManagement()
        {
            ViewBag.BookingList = context.Bookings.ToList();
            return View();
        }
    }
}
