using Hotel_Web_app_Projet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PagedList;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace Hotel_Web_app_Projet.Controllers
{
    public class RoomController : Controller
    {
        HotelWebsiteContext context = new();
        public void getSession()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                TempData["user"] = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("user"));
                User person = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("person"));
                TempData["person"] = person;
            }
        }
        public override ViewResult View()
        {
            getSession();
            ViewBag.RoomTypes = context.RoomTypes.ToList();
            return base.View();
        }

        public IActionResult Index(int Page, int TypeId)
        {
            getSession();
            List<Room> rooms = new List<Room>();
            if (TypeId == 0)
            {
                rooms = context.Rooms.ToList();
            }
            else
            {
                rooms = context.Rooms.Where(p => p.TypeId == TypeId).ToList();
            }
            int pageSize = 6;
            decimal pageNumber = Math.Ceiling((decimal)rooms.Count / pageSize);

            if (Page <= 0)
            {
                Page = 1;
            } else if (Page > pageNumber)
            {
                Page = (int)pageNumber;
            }

            ViewBag.TypeId = TypeId;
            ViewBag.Rooms = rooms.ToPagedList(Page, pageSize);
            ViewBag.Pages = pageNumber;
            ViewBag.CurrentPage = Page;
            return View();
        }

        public IActionResult RoomDetails(int RoomId)
        {
            getSession();
            ViewBag.RoomDetails = context.Rooms.Find(RoomId);
            return View();
        }
        [HttpPost]
        public IActionResult Check()
        {

            int roomID = int.Parse(Request.Form["roomID"]);
            
            DateTime dateIn = DateTime.Parse(String.Format("{0}", Request.Form["dateIn"]));
            DateTime dateOut = DateTime.Parse(String.Format("{0}", Request.Form["dateOut"]));
                
            if ((dateIn.CompareTo(dateOut)) > 0)
            {
                TempData["Error"] = "Check Out date must greater than Check In date";
               
            }
            else
            {
                TempData["Message"] = "Available room!";
                
            }
            return RedirectToAction("RoomDetails", "room", new { roomId = roomID });

        }
        [HttpGet]
        public IActionResult Booking(int RoomId)
        {
            getSession();
            ViewBag.RoomDetails = context.Rooms.Find(RoomId);
            return View();  
        }

        [HttpPost]
        public IActionResult Booking()
        {
            getSession();
            return View();
        }

    }
}
