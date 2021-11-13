﻿using Hotel_Web_app_Projet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using X.PagedList;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Index(int page, int roomType, string sortByPrice, int price, int guest)
        {
            IQueryable<Room> rooms = context.Rooms.AsQueryable();
            string query = null;

            // Room Types
            if (roomType != 0)
            {
                rooms = context.Rooms.Where(p => p.TypeId == roomType);
                query += $"&roomType={roomType}";
            }

            // Sorting
            if (sortByPrice == "asc")
            {
                rooms = rooms.OrderBy(r => r.Type.Price);
                query += $"&sortByPrice={sortByPrice}";
            }
            else if (sortByPrice == "desc")
            {
                rooms = rooms.OrderByDescending(r => r.Type.Price);
                query += $"&sortByPrice={sortByPrice}";
            }

            // Prices & Guests
            if (price != 0 || guest != 0)
            {
                rooms = context.Rooms.Where(p => p.Type.Price <= price && p.Type.Capacity >= guest);
                query += $"&price={price}&guest={guest}";
            }

            //Pagination
            int pageSize = 6;
            decimal pageNumber = Math.Ceiling((decimal)rooms.ToList().Count / pageSize);

            if (page <= 1)
            {
                page = 1;
            } else if (page >= pageNumber)
            {
                page = (int)pageNumber;
            }

            ViewBag.query = query;
            ViewBag.sortByPrice = sortByPrice;
            ViewBag.TypeId = roomType;
            ViewBag.Price = price;
            ViewBag.Guest = guest;
            ViewBag.Rooms = rooms.ToPagedList(page, pageSize);
            ViewBag.Pages = pageNumber;
            ViewBag.CurrentPage = page;
            ViewBag.RoomTypes = context.RoomTypes.ToList();
            return View();
        }

        public IActionResult RoomDetails(int roomId)
        {
            getSession();
            Room r = context.Rooms.Find(roomId);
            ViewBag.RoomDetails = r;
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
                var bookList = (from b in context.Bookings
                                where b.RoomId == 1
                                && ((b.DateFrom < dateIn && dateIn < b.DateFrom)
                                || (dateIn <= b.DateFrom && b.DateTo <= dateOut)
                                || (b.DateFrom <= dateOut && b.DateTo > dateOut))
                                select b ).ToList();
                if (bookList.Count == 0)
                {
                    TempData["Message"] = "Available room!";
                    
                }
                else
                {
                    TempData["Message"] = "Room not available!";

                }

            }
            return RedirectToAction("RoomDetails", "room", new { roomId = roomID });
        }

        [HttpGet]
        public IActionResult Booking(int roomId)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return RedirectToAction("login", "account");
            }
            else
            {
                getSession();
            }
            ViewBag.RoomDetails = context.Rooms.Find(roomId);
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
