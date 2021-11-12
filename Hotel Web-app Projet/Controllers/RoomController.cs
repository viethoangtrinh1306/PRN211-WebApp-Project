using Hotel_Web_app_Projet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using X.PagedList;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Web_app_Projet.Controllers
{
    public class RoomController : Controller
    {
        HotelWebsiteContext context = new();

        public IActionResult Index(int page, string sortByPrice, int roomType, int price, int guest)
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
            ViewBag.RoomDetails = context.Rooms.Find(roomId);
            return View();
        }
        
    }
}
