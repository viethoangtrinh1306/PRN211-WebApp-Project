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
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            Account account = new Account();
            return View(account);
        }

        [HttpPost]
        public IActionResult Login(String username , String password)
        {
            HotelWebsiteContext context = new HotelWebsiteContext();
            var accounts = context.Accounts.ToList();
            if (ModelState.IsValid)
            {
                Account account = (from a in accounts where a.Username.Equals(username) && a.Password.Equals(password) select a).Single();
                if (account != null)
                {
                    //add session
                    HttpContext.Session.SetString("user",JsonConvert.SerializeObject(account));
                    return RedirectToAction("Index", "home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return Redirect("home");
        }

        public IActionResult Signup()
        {
            return View();
        }
    }   
}
