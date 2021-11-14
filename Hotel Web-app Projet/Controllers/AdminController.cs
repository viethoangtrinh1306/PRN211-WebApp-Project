using Hotel_Web_app_Projet.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using X.PagedList;

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
            //Pagination
            int pageSize = 10;
            decimal pageNumber = Math.Ceiling((decimal)context.Users.ToList().Count / pageSize);

            if (page <= 1)
            {
                page = 1;
            }
            else if (page >= pageNumber)
            {
                page = (int)pageNumber;
            }
            ViewBag.UserList = context.Users.ToPagedList(page, pageSize);
            ViewBag.Pages = pageNumber;
            ViewBag.CurrentPage = page;
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

        public IActionResult RoomManagement(int page)
        {
            //Pagination
            int pageSize = 10;
            decimal pageNumber = Math.Ceiling((decimal)context.Rooms.ToList().Count / pageSize);

            if (page <= 1)
            {
                page = 1;
            }
            else if (page >= pageNumber)
            {
                page = (int)pageNumber;
            }
            ViewBag.RoomList = context.Rooms.ToPagedList(page, pageSize);
            ViewBag.Pages = pageNumber;
            ViewBag.CurrentPage = page;
            return View();
        }
        public IActionResult BookingManagement(int page)
        {
            //Pagination
            int pageSize = 10;
            decimal pageNumber = Math.Ceiling((decimal)context.Bookings.ToList().Count / pageSize);

            if (page <= 1)
            {
                page = 1;
            }
            else if (page >= pageNumber)
            {
                page = (int)pageNumber;
            }
            ViewBag.BookingList = context.Bookings.ToPagedList(page, pageSize);
            ViewBag.Pages = pageNumber;
            ViewBag.CurrentPage = page;
            return View();
        }
    }
}
