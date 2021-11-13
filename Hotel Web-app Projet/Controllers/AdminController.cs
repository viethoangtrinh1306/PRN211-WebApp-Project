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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminRoomManagement()
        {
            ViewBag.RoomList = context.Rooms.ToList();
            return View();
        }
        public IActionResult AdminUserManagement()
        {
            ViewBag.UserList = context.Users.ToList();
            return View();
        }

        public IActionResult AdminBookingListManagement()
        {
            ViewBag.BookingList = context.Bookings.ToList();
            return View();
        }
    }

}
