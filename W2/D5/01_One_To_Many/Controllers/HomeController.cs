using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _01_One_To_Many.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _01_One_To_Many.Controllers
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
            IndexView ViewModel = new IndexView()
            {
                AllPokemon = _context.Pokemon
                    .Include(poke => poke.CaughtBy)
                    .ToList(),
                AllTrainers = _context.Trainer
                    .Include(train => train.PokemonCaught)
                    .ToList()
            };
            return View(ViewModel);
        }

        [HttpGet("trainer/new")]
        public IActionResult NewTrainer()
        {
            return View();
        }

        [HttpGet("pokemon/new")]
        public IActionResult NewPokemon()
        {
            // NewPokemonView ViewModel = new NewPokemonView()
            // {
            //     AvailableTrainers = _context.Trainer.ToList()
            // };
            Pokemon Form = new Pokemon()
            {
                AvailableTrainers = _context.Trainer.ToList()
            };
            return View(Form);
        }

        [HttpPost("trainer/create")]
        public IActionResult CreateTrainer(Trainer fromForm)
        {   
            if(ModelState.IsValid)
            {
                _context.Add(fromForm);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else 
            {
                return View("Index");
            }
        }
        [HttpPost("pokemon/create")]
        public IActionResult CreatePokemon(Pokemon fromForm)
        {   
            if(ModelState.IsValid)
            {
                _context.Add(fromForm);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else 
            {
                return View("Index");
            }
        }
    }
}