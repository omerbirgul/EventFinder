using Microsoft.AspNetCore.Mvc;

namespace EvenFinder.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() 
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
