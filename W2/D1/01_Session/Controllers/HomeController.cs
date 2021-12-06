using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _01_Session.Models;
using Microsoft.AspNetCore.Http; // This is where session comes from

namespace _01_Session.Controllers
{
    public class HomeController : Controller 
    {
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
                // STORING DATA FROM A FORM INTO SESSION
                HttpContext.Session.SetString("DuckName", fromForm.DuckName);
                HttpContext.Session.SetString("Quackifications", fromForm.Quackifications);
                HttpContext.Session.SetInt32("BillLength", (int)fromForm.BillLength);

                return RedirectToAction("DuckInfo");
            }
            else 
            {
                return View("Index");
            }
        }

        [HttpGet("duck/info")]
        public IActionResult DuckInfo()
        {
            // If there's no duck in session
            if(HttpContext.Session.GetString("DuckName") == null)
            {
                return RedirectToAction("Index");
            }

            Duck toRenderInfoOf = new Duck()
            {
                // PULLING THE DATA BACK OUT OF SESSION
                DuckName = HttpContext.Session.GetString("DuckName"), // MAKE SURE you are using the correct data type and key name
                Quackifications = HttpContext.Session.GetString("Quackifications"),
                BillLength = HttpContext.Session.GetInt32("BillLength") // NOTE: This worked without casting Session as an int because BillLength is already an int?
            };

            return View(toRenderInfoOf);
        }

        [HttpGet("duck/delete")]
        public RedirectToActionResult DeleteDuckFromSession()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}