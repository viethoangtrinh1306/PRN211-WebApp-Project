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
                Account account = context.Accounts.Where(a => a.Username == username && a.Password == password).FirstOrDefault();
                if (account != null && account.AuthorId == 1)
                {
                    if (account.Status)
                    {
                        //add session
                        User user = context.Users.Where(u => u.AccountId == account.AccountId).FirstOrDefault();
                        HttpContext.Session.SetString("account", JsonConvert.SerializeObject(account));
                        HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = "Your account is blocked!";
                        return Login();
                    }
                }
                else if (account != null && account.AuthorId == 2)
                {
                    //add session
                    User user = context.Users.Where(u => u.AccountId == account.AccountId).FirstOrDefault();
                    HttpContext.Session.SetString("account", JsonConvert.SerializeObject(account));
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                    return RedirectToAction("AdminDashboard", "Admin");
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
            HttpContext.Session.Remove("account");
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
