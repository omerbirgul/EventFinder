using EvenFinder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EvenFinder.Controllers
{
    public class EventController : Controller
    {

        private readonly DataContext _context;
        public EventController(DataContext context)
        {
            _context = context;
        }

        //*************************************
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Event model)
        {
            _context.Events.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> List()
        {
            return View(await _context.Events.ToListAsync());
        }
    }
}
