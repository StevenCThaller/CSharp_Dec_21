using Microsoft.EntityFrameworkCore;
using _01_API_and_Services.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace _01_API_and_Services.Services
{
    public interface IApiService
    {
        Task<object> GetDataFromApi(APISearch form);
    }

    public class ApiService : IApiService 
    {
        private MyContext _context { get; }

        public ApiService(MyContext context)
        {
            _context = context;
        }

        public async Task<object> GetDataFromApi(APISearch form)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync($"https://swapi.dev/api/{form.Category}/{form.SearchId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return DeserializeFromJson(apiResponse, form);
                    // toReturn = JsonConvert.DeserializeObject<Character>(apiResponse);
                }
            }
        }

        private object DeserializeFromJson(string apiResponse, APISearch form)
        {
            switch(form.Category)
            {
                case "people":
                    Character character = JsonConvert.DeserializeObject<Character>(apiResponse);
                    character.characterId = (int)form.SearchId;
                    return character;
                case "starships":
                    Starship starship = JsonConvert.DeserializeObject<Starship>(apiResponse);
                    starship.starshipId = (int)form.SearchId;
                    return starship;
                case "planets":
                    Planet planet = JsonConvert.DeserializeObject<Planet>(apiResponse);
                    planet.planetId = (int)form.SearchId;
                    return planet;
                default:
                    return null;
            }
        }



        
    }
}