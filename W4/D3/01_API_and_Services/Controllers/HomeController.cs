using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using _01_API_and_Services.Models;
using _01_API_and_Services.Services;
using System.Threading.Tasks;

namespace _01_API_and_Services.Controllers
{
    public class HomeController : Controller 
    {
        private int UserId { get; } = 1;
        private MyContext _context { get; }
        private IApiService _apiService { get; }
        private IDbService _dbService { get; }

        public HomeController(MyContext context, IApiService apiService, IDbService dbService)
        {
            _context = context;
            _apiService = apiService;
            _dbService = dbService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index", new APISearch());
        }

        [HttpGet("{thingId}/favorite")]
        public IActionResult AddFavorite(int thingId)
        {
            int newlyCreatedFavorite = _dbService.UserFavoriteThing(UserId, thingId);
            if(newlyCreatedFavorite < 0)
            {
                // Based on what we return from the service, -1 returned means didn't add it
                return Index();
            }
            else 
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("search")]
        public async Task<IActionResult> CallApi(APISearch fromForm)
        {
            if(ModelState.IsValid)
            {
                object fromApi = await _apiService.GetDataFromApi(fromForm);

                return RedirectToAction("Index");
            }
            else 
            {
                return Index();
            }
        }

        // Method that will allow me to make an api call, then take the resulting object, and connect it
        // to a user in the database
        [HttpPost("search/favorite")]
        public async Task<IActionResult> CallApiForItemAndFavorite(APISearch fromForm)
        {
            // Step 1: Get the data from the api
            if(ModelState.IsValid)
            {
                object fromApi = await _apiService.GetDataFromApi(fromForm);

                string url = ((Character)fromApi).url;
                // Step 2: Take that data, and add it to the database (if it's not already there)
                StarWarsThing fromDb = _dbService.GetThingByUrl(url);

                int? newItemInDb;

                if(fromDb == null) 
                {
                    newItemInDb = _dbService.AddThingToDb(url);
                }
                else 
                {
                    newItemInDb = fromDb.StarWarsThingId;
                }

                // Step 3: With that newly created database entry, link it to the current user
                _dbService.UserFavoriteThing(UserId, (int)newItemInDb);
                
                return RedirectToAction("Index");
            }
            else 
            {
                return Index();
            }

        }
    }
}