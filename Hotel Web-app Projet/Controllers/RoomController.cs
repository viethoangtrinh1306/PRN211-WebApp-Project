using Hotel_Web_app_Projet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PagedList;
using System;
using System.Collections.Generic;

namespace Hotel_Web_app_Projet.Controllers
{
    public class RoomController : Controller
    {
        HotelWebsiteContext context = new();

        public override ViewResult View()
        {
            ViewBag.RoomTypes = context.RoomTypes.ToList();
            return base.View();
        }

        public IActionResult Index(int Page, int TypeId)
        {
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
            ViewBag.RoomDetails = context.Rooms.Find(RoomId);
            return View();
        }
    }
}
