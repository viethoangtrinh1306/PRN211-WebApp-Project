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
        public IActionResult UserManagement(int page)
        {
            if (IsAdmin())
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
            else
            {
                return RedirectToAction("Error404", "Admin");
            }
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

        [HttpGet]
        public IActionResult RoomManagement(int page)
        {
            if (IsAdmin())
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
                ViewBag.RoomTypes = context.RoomTypes.ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Error404", "Admin");
            }
        }

        [HttpPost]
        public IActionResult RoomManagement(string action)
        {
            if (IsAdmin())
            {
                if (action == "add")
                {
                    string name = Request.Form["name"];
                    Room room = new Room
                    {
                        Name = Request.Form["name"],
                        Position = Request.Form["position"],
                        TypeId = int.Parse(Request.Form["roomType"]),
                        Image = Request.Form["image"]
                    };
                    context.Rooms.Add(room);
                    context.SaveChanges();
                    TempData["message"] = "Add successfully!";
                }
                else if(action == "edit")
                {
                    int roomId = int.Parse(Request.Form["roomId"]);
                    Room room = context.Rooms.SingleOrDefault(c => c.RoomId == roomId);
                    if (room != null)
                    {
                        room.Name = Request.Form["name"];
                        room.Position = Request.Form["position"];
                        room.TypeId = int.Parse(Request.Form["roomType"]);
                        room.Image = Request.Form["image"];
                        context.SaveChanges();
                        TempData["message"] = "Edit successfully!";
                    }
                }
                else if(action == "delete")
                {
                    int roomId = int.Parse(Request.Form["roomId"]);
                    Room room = context.Rooms.SingleOrDefault(c => c.RoomId == roomId);
                    if (room != null)
                    {
                        context.Rooms.Remove(room);
                        context.SaveChanges();
                        TempData["message"] = "Delete successfully!";
                    }
                }
                return RedirectToAction("RoomManagement", "Admin");
            }
            else
            {
                return RedirectToAction("Error404", "Admin");
            }
        }

        public IActionResult BookingManagement(int page)
        {
            if (IsAdmin())
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
            else
            {
                return RedirectToAction("Error404", "Admin");
            }
        }
        public IActionResult Error404()
        {
            return View();
        }
    }
}
