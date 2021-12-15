using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BeltPrep.Models;

namespace BeltPrep.Controllers
{
    [Route("shows")]
    public class TVShowController : Controller 
    {
        private MyContext _context { get; }

        public TVShowController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Dashboard()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index", "LogReg");
            }

            DashboardView ViewModel = new DashboardView
            {
                UserName = _context.Users.FirstOrDefault(u => u.UserId == (int)UserId).Name,
                AllShows = _context.Shows
                    .Include(s => s.Ratings)
                    .ToList()
            };

            return View(ViewModel);
        }

        [HttpGet("{showId}")]
        public IActionResult ShowInfo(int showId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index", "LogReg");
            }

            ShowInfoView ViewModel = new ShowInfoView
            {
                LoggedUserId = (int)UserId,
                Show = _context.Shows
                    .Include(s => s.Ratings)
                    .ThenInclude(r => r.RatedBy)
                    .FirstOrDefault(s => s.TVShowId == showId)
            };

            if(ViewModel.Show == null)
            {
                return RedirectToAction("Dashboard");
            }

            return View("ShowInfo", ViewModel);
        }

        [HttpGet("new")]
        public IActionResult NewShow()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index", "LogReg");
            }

            return View("NewShow");
        }

        [HttpPost("create")]
        public IActionResult CreateShow(TVShow fromForm)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index", "LogReg");
            }

            if(ModelState.IsValid)
            {
                if(_context.Shows.Any(show => show.Name == fromForm.Name))
                {
                    ModelState.AddModelError("Name", "A TV Show with that title already exists!");
                    return NewShow();
                }

                fromForm.UserId = (int)UserId;

                _context.Add(fromForm);
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }
            else
            {
                return NewShow();
            }
        }

        [HttpGet("{showId}/edit")]
        public IActionResult EditShow(int showId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index", "LogReg");
            }
            
            TVShow toEdit = _context.Shows.FirstOrDefault(show => show.TVShowId == showId);

            if(toEdit == null)
            {
                return RedirectToAction("Dashboard");
            } 
            else if((int)UserId != toEdit.UserId)
            {
                return RedirectToAction("ShowInfo", new { showId = showId});
            }

            return View("EditShow", toEdit);
        }

        [HttpPost("{showId}/update")]
        public IActionResult UpdateShow(int showId, TVShow fromForm)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index", "LogReg");
            }

            TVShow toEdit = _context.Shows.FirstOrDefault(s => s.TVShowId == showId);

            // Did we create this? If not, begone!
            if(toEdit.UserId != (int)UserId)
            {
                return RedirectToAction("ShowInfo", new { showId = showId});
            }
            else if(ModelState.IsValid)
            {
                // Does another show already have this title??
                TVShow showWithThisName = _context.Shows.FirstOrDefault(s => s.Name == fromForm.Name);
                if(showWithThisName != null && showWithThisName.TVShowId != showId)
                {
                    ModelState.AddModelError("Name", "A show with that title already exists.");
                    return EditShow(showId);
                }

                toEdit.Name = fromForm.Name;
                toEdit.Network = fromForm.Network;
                toEdit.UpdatedAt = DateTime.Now;

                _context.SaveChanges();
                return RedirectToAction("ShowInfo", new { showId = showId });
            }
            else 
            {
                return EditShow(showId);
            }
        }

        [HttpPost("{showId}/rate")]
        public IActionResult LeaveRating(int showId, ShowInfoView viewModel)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index", "LogReg");
            }
            else if(!_context.Shows.Any(s => s.TVShowId == showId))
            {
                return RedirectToAction("Dashboard");
            }

            if(ModelState.IsValid)
            {
                // If this user has already rated this show
                if(_context.Ratings.Any(r => r.TVShowId == showId && r.UserId == (int)UserId))
                {
                    // Don't let them
                    ModelState.AddModelError("Form.StarRating", "You've already left a rating on this show.");
                    return ShowInfo(showId);
                }

                Rating fromForm = viewModel.Form;

                fromForm.UserId = (int)UserId;
                fromForm.TVShowId = showId;

                _context.Add(fromForm);
                _context.SaveChanges();

                return RedirectToAction("ShowInfo", new { showId = showId });
            }
            else 
            {
                return ShowInfo(showId);
            }
        }

        [HttpGet("{showId}/delete")]
        public RedirectToActionResult DeleteShow(int showId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index", "LogReg");
            }

            TVShow toDelete = _context.Shows.FirstOrDefault(s => s.TVShowId == showId);

            if((int)UserId != toDelete.UserId)
            {
                return RedirectToAction("Dashboard");
            }


            _context.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}

