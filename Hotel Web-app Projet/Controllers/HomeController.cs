using Hotel_Web_app_Projet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Web_app_Projet.Controllers
{
    public class HomeController : Controller
    {
        HotelWebsiteContext context = new();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public void getSession()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                TempData["user"] = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("user"));
                User person = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("person"));
                TempData["person"] = person;
            }
        }

        public IActionResult Index()
        {
            getSession();
            ViewBag.RoomTypes = context.RoomTypes.ToList();
            return View();
        }

        public IActionResult About()
        {
            getSession();
            return View();
        }

        public IActionResult Contact()
        {
            getSession();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
