using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _01_Models_Intro.Models;

namespace _01_Models_Intro.Controllers
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

            string someKindOfMessage = "lorem ipsum dolores di amet";

            return View("Index", someKindOfMessage);
        }

        [HttpGet("somethingelse")]
        public ViewResult OtherPage()
        {
            return View();
        }

        [HttpPost("some/page")]
        public ViewResult NewDuck(Duck fromForm)
        {   
            // ViewBag.DuckName = name;
            // ViewBag.Quackifications = quackifications;
            // ViewBag.BillLength = billLength;
            // Duck duckToShow = new Duck(name, quackifications, billLength);


            return View(fromForm);
        }
    }
}