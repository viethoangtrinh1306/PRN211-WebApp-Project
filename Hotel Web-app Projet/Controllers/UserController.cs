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

        public IActionResult UserDetails(int UserID)
        {
            ViewBag.UserDetails = context.Users.Find(UserID);
            return View();
        }

    }
}
