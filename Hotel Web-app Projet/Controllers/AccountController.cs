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
        HotelWebsiteContext context = new HotelWebsiteContext();
        [HttpGet]
        public IActionResult Login()
        {
            Account account = new Account();
            return View(account);
        }

        [HttpPost]
        public IActionResult Login(String username , String password)
        {
            
            var accounts = context.Accounts.ToList();
           
            if (ModelState.IsValid)
            {
                var query = (from a in accounts where a.Username.Equals(username) && a.Password.Equals(password) select a).FirstOrDefault();
                Account account = query==null?null: (from a in accounts where a.Username.Equals(username) && a.Password.Equals(password) select a).Single();
                if (account != null)
                {
                    //add session
                    User user = (from u in context.Users.ToList() where u.Account == account select u).Single();
                    
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(account));
                    HttpContext.Session.SetString("person", JsonConvert.SerializeObject(user));
                    return RedirectToAction("Index", "home");
                }
                else
                {
                    ViewBag.Error = "Login failed! Please check your username/password!";
                    return Login();
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "home");

        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(String username, String password,String rePassword, String name, DateTime dob, String gender,String phone,String email)
        {
            if (ModelState.IsValid)
            {
                var check = context.Accounts.FirstOrDefault(s => s.Username == username);
                if (check != null)
                {
                    ViewBag.error = "Account exsited";
                    return Signup();
                }
                else if (!password.Equals(rePassword))
                {
                    ViewBag.error = "Check your confirm password";
                    return Signup();
                }
                else
                {
                    Account account = new Account { Username = username, Password = password, Status = true, AuthorId = 1 };
                    context.Accounts.Add(account);
                    context.SaveChanges();
                    var newAccount = context.Accounts.OrderBy(x=> x.AccountId).LastOrDefault();
                    User user = new User { Name = name, Gender = gender.Equals("male") ? true : false, Dob = dob, Email = email, Phone = phone, AccountId = newAccount.AccountId};
                    context.Users.Add(user);
                    context.SaveChanges();
                    return Redirect("login");
                }
            }
            return View();
        }
    }   
}
