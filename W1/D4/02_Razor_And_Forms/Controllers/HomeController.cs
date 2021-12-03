using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace _02_Razor_And_Forms.Controllers
{
    public class HomeController : Controller 
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            ViewBag.MyName = "Cody";
            ViewBag.FavoriteVegetable = "Brussel Sprouts";

            ViewBag.x = 5;
            ViewBag.y = 2;

            ViewBag.ListOfNames = new List<string>()
            {
                "James",
                "Roscoe",
                "Jonathan",
                "Kyle",
                "Giles"
            };

            return View();
        }

        [HttpGet("somethingelse")]
        public ViewResult OtherPage()
        {
            return View();
        }

        [HttpPost("some/page")]
        public ViewResult NewDuck(string name, string quackifications, int billLength)
        {   
            ViewBag.DuckName = name;
            ViewBag.Quackifications = quackifications;
            ViewBag.BillLength = billLength;
            return View();
        }
    }
}