using Hotel_Web_app_Projet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Web_app_Projet.Controllers
{
    public class UserController : Controller
    {
        HotelWebsiteContext context = new();

        public override ViewResult View()
        {
            ViewBag.RoomTypes = context.RoomTypes.ToList();
            return base.View();
        }

        public IActionResult UserDetails(int UserID)
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                TempData["user"] = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
            }
           
            ViewBag.UserDetails = context.Users.Find(UserID);
            //Boolean a = ViewBag.UserDetails.Gender;
            return View();
        }

    }
}
