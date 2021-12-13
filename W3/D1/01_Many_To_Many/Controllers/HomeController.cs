using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _01_Many_To_Many.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _01_Many_To_Many.Controllers
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
                AllTrainers = _context.Trainers
                    .Include(train => train.PokemonCaught)
                    .ToList(),
                AllMoves = _context.Moves
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
                AvailableTrainers = _context.Trainers.ToList()
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

        [HttpGet("pokemon/{pokemonId}")]
        public IActionResult PokemonInfo(int pokemonId)
        {
            // I want to to query for a single pokemon
            // With their Trainer's information
            // And the moves they know
            Pokemon toRender = _context.Pokemon
                // FOR ONE TO MANY
                .Include(p => p.CaughtBy) // this includes the trainer's info (aka join)
                // FOR MANY TO MANY
                .Include(p => p.MovesKnown) // Include the middle table
                    .ThenInclude(m => m.MoveKnownByPokemon) // Then from the middle table, include the other side of the relationship
                // Finally, the query for the single pokemon itself
                .FirstOrDefault(p => p.PokemonId == pokemonId);

            if(toRender == null) 
            {
                return RedirectToAction("Index");
            }

            return View(toRender);
        }

        [HttpGet("move/new")]
        public ViewResult NewMove()
        {
            return View("NewMove");
        }

        [HttpPost("move/new")]
        public IActionResult CreateMove(Move fromForm)
        {
            if(ModelState.IsValid)
            {
                _context.Add(fromForm);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else 
            {
                return NewMove();
            }
        }

        [HttpGet("move/{moveId}")]
        public IActionResult MoveInfo(int moveId)
        {
            MoveInfoView ViewModel = new MoveInfoView()
            {
                ToRender = _context.Moves
                    .Include(m => m.PokemonThatLearnMove) // but this is a middle table, so
                        .ThenInclude(plm => plm.PokemonWithMove)
                    .FirstOrDefault(m => m.MoveId == moveId),
                // List of Pokemon that this move has not already been taught to
                ToTeachTo = _context.Pokemon
                    .Include(p => p.MovesKnown) 
                    .Where(p => !p.MovesKnown.Any(mk => mk.MoveId == moveId))
                    .ToList()
            };
            
            return View("MoveInfo", ViewModel);
        }

        [HttpPost("move/{moveId}/teach")]
        public IActionResult TeachMove(int moveId, MoveInfoView viewModel)
        {
            if(ModelState.IsValid)
            {
                PokemonHasMove fromForm = viewModel.TeachForm;
                _context.Add(fromForm);
                _context.SaveChanges();

                return RedirectToAction("MoveInfo", new { moveId = moveId });
            }
            else 
            {
                return MoveInfo(moveId);
            }
        }
    }
}