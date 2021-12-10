using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _01_Two_Forms_One_Page.Models;
using Microsoft.AspNetCore.Http; // This is where session comes from
using System.Linq;

namespace _01_Two_Forms_One_Page.Controllers
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

                return RedirectToAction("DucksAndGeese");
            }
            else 
            {
                return View("Index");
            }
        }
        [HttpPost("goose/create")]
        public IActionResult NewGoose(Goose fromForm)
        {   
            if(ModelState.IsValid)
            {
                // Add our Duck to the database
                _context.Add(fromForm);
                _context.SaveChanges();
                // Wanna know something neat?
                System.Console.WriteLine(fromForm.GooseId);

                return RedirectToAction("DucksAndGeese");
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

        [HttpGet("duck/edit/{duckId}")]
        public IActionResult EditDuck(int duckId)
        {
            Duck toEdit = _context.Ducks.FirstOrDefault(duck => duck.DuckId == duckId);

            if(toEdit == null)
            {
                return RedirectToAction("Index");
            }

            return View("EditDuck", toEdit);
        }

        [HttpPost("duck/update/{duckId}")]
        public IActionResult UpdateDuck(int duckId, Duck fromForm)
        {
            if(ModelState.IsValid)
            {
                Duck inDb = _context.Ducks.FirstOrDefault(duck => duck.DuckId == duckId);

                inDb.DuckName = fromForm.DuckName;
                inDb.Quackifications = fromForm.Quackifications;
                inDb.BillLength = fromForm.BillLength;
                inDb.UpdatedAt = DateTime.Now;

                _context.SaveChanges();

                return RedirectToAction("DuckInfo", new { duckId = duckId });
            }
            else 
            {
                return EditDuck(duckId);
            }
        }

        [HttpGet("ducks/geese")]
        public ViewResult DucksAndGeese()
        {
            List<Duck> AllDucks = _context.Ducks.ToList();
            List<Goose> AllGeese = _context.Geese.ToList();

            DucksAndGeeseView ViewModel = new DucksAndGeeseView()
            {
                Ducks = AllDucks,
                Geese = AllGeese
            };

            return View(ViewModel);
        }
    }
}