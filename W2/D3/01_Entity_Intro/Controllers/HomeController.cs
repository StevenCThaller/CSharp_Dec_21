using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _01_Entity_Intro.Models;
using Microsoft.AspNetCore.Http; // This is where session comes from
using System.Linq;

namespace _01_Entity_Intro.Controllers
{
    public class HomeController : Controller 
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("duck/create")]
        public IActionResult NewDuck(Duck fromForm)
        {   
            if(ModelState.IsValid)
            {
                // Add our Duck to the database
                _context.Add(fromForm);
                _context.SaveChanges();
                // Wanna know something neat?
                System.Console.WriteLine(fromForm.DuckId);

                return RedirectToAction("DuckInfo", new { duckId = fromForm.DuckId });
            }
            else 
            {
                return View("Index");
            }
        }

        [HttpGet("duck/info/{duckId}")]
        public IActionResult DuckInfo(int duckId)
        {
            // How do we pull a single duck from the database?
            // Let's think back to yesterday, with our LINQ queries.
            // If _context.Ducks is a collection of all ducks in our database,
            // what LINQ query can we use to pull the one duck with an id matching
            // our route parameter?
            Duck toRender = _context.Ducks.FirstOrDefault(duck => duck.DuckId == duckId);
            

            return View(toRender);
        }

        [HttpGet("duck/delete/{duckId}")]
        public RedirectToActionResult DeleteDuckFromSession(int duckId)
        {
            Duck toDelete = _context.Ducks.FirstOrDefault(duck => duck.DuckId == duckId);

            _context.Ducks.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}