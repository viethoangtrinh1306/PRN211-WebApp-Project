using Hotel_Web_app_Projet.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

        public bool IsAdmin()
        {
            Account account = new Account();
            if (HttpContext.Session.GetString("account") != null)
            {
                account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
            }
            if (account.AuthorId != 2)
            {
                return false;
            }
            else { return true; }
        }
        public IActionResult UserManagement()
        {
            if (IsAdmin())
            {
                ViewBag.UserList = context.Users.ToList();
                return View();
            }
            else return RedirectToAction("Error404", "admin");
        }
        public IActionResult RoomManagement()
        {
            if (IsAdmin())
            {
                ViewBag.RoomList = context.Rooms.ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Error404", "admin");
            }
            
        }
        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult BookingManagement()
        {
            if (IsAdmin())
            {
                ViewBag.BookingList = context.Bookings.ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Error404", "admin");
            }
           
        }
    }
}
