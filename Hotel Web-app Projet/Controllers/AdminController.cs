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
            ViewBag.Accounts = context.Accounts.ToList();
            return base.View();
        }
        public IActionResult UserManagement()
        {
            ViewBag.UserList = context.Users.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult ChangeAccountStatus()
        {
            int accountId = int.Parse(Request.Form["accountId"]);
            ViewBag.Status = Request.Form["status"];
            bool status;
            if (Request.Form["status"].ToString() == "on")
            {
                status = true;
            }
            else
            {
                status = false;
            }
            var account = context.Accounts.SingleOrDefault(c => c.AccountId == accountId);
            if (account != null)
            {
                account.Status = status;
                context.SaveChanges();
            }
            ViewBag.UserList = context.Users.ToList();
            return RedirectToAction("UserManagement","Admin");
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
