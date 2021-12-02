using Microsoft.AspNetCore.Mvc;

namespace _01_Intro_To_ASP.Controllers
{
    public class HomeController : Controller
    {
        // Let's condense this:
        // [HttpGet]
        // [Route("")]
        // Into this:
        [HttpGet("")]
        public ViewResult Index() // ViewResult means we will always render on this route
        {
            return View();
        }

        [HttpGet("hello/{name}")]
        public string HelloThere(string name)
        {
            return $"Hello there, {name}! Welcome to my dinky little website!";
        }

        //Redirecting directly to URL
        [HttpPost("someroute")]
        public RedirectResult RedirectToRoute()
        {
            string somethinghere = "Bologna";
            return Redirect($"some/url/here/with/{somethinghere}");
        }

        // Redirecting based on the method itself
        [HttpPost("someroute")]
        public RedirectToActionResult RedirectToMethod()
        {
            // Without a route parameter, nice and simple:
            return RedirectToAction("NameOfMethod");
            // How do we use RedirectToAction if we're redirecting somewhere with a route parameter?
            return RedirectToAction("NameOfMethod", new { someParameter = "Bologna" });
        }

        [HttpGet("some/url/here/with/{someParameter}")]
        public ViewResult NameOfMethod(string someParameter)
        {
            return View();
        }

        // A method that either redirects OR renders?? YEAH!
        [HttpGet("hello/{name}/{quest}/{average_air_velocity_of_an_african_swallow}")]
        public IActionResult TimsRiddle(string name, string quest, int average_air_velocity_of_an_african_swallow)
        {
            if(average_air_velocity_of_an_african_swallow == 0)
            {
                return RedirectToAction("TimSaysYoureWrong");
            }

            return View();
            // return $"Hello {name}, I'm pleased to hear that you're on a quest to {quest}, but I don't get why you're telling me that a bird can fly {average_air_velocity_of_an_african_swallow} knots. I'm just an accountant";
        }

        [HttpGet("no")]
        public ViewResult TimSaysYoureWrong()
        {
            return View();
        }

        [HttpGet("error")]
        public ViewResult Error()
        {
            return View("Error");
        }
    }
}