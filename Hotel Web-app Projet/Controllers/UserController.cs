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

        public IActionResult UserDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult update(String name, String phone, bool gender)
        {
            
            

            Account account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
            var data = context.Users.FirstOrDefault(x => x.UserId == user.UserId);
            data.Name = name;
            data.Phone = phone;
            data.Gender = gender;


            context.SaveChanges();
            user = context.Users.Where(u => u.AccountId == account.AccountId).FirstOrDefault();

            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
            return RedirectToAction("UserDetails", "User");

            
        }

        public IActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost] 
        public IActionResult changePass(string pass, string newPass, string reNewPass)
        {
            Account account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
            var data = context.Accounts.FirstOrDefault(x => x.AccountId == user.AccountId);

            if(data.Password != pass)
            {
                ViewBag.error = "Wrong password!";
                
                return RedirectToAction("ChangePassword", "User");
            } 
            if(newPass != reNewPass)
            {
                ViewBag.error = "Check repass again!";
                
                return RedirectToAction("ChangePassword", "User");
            }

            
            return RedirectToAction("ChangePassword", "User");
        }
    }
}
