﻿using Hotel_Web_app_Projet.Models;
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
            ViewBag.Rooms = context.Rooms.ToList();
            return base.View();
        }
        public IActionResult UserDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult update(String name, String phone, bool gender, DateTime dob)
        {
            Account account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
            var data = context.Users.FirstOrDefault(x => x.UserId == user.UserId);
            data.Name = name;
            data.Phone = phone;
            data.Gender = gender;
            data.Dob = dob;

            context.SaveChanges();
            user = context.Users.Where(u => u.AccountId == account.AccountId).FirstOrDefault();

            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
            TempData["mess"] = "Changed success!!!";
            return RedirectToAction("UserDetails", "User", new { user.UserId});
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult ChangePassword(string newPass)
        {
            Account account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
            var data = context.Accounts.FirstOrDefault(x => x.AccountId == user.AccountId);

            data.Password = newPass;
            context.SaveChanges();
            user = context.Users.Where(u => u.AccountId == account.AccountId).FirstOrDefault();
            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
            ViewBag.error = "Changed password success!!!";
            return ChangePassword();
        }

        public IActionResult UserBookingList()
        {
            Account account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));

            ViewBag.BookingList = context.Bookings.Where(b => b.UserId == user.UserId).ToList();
            return View();
        }
    }
}
