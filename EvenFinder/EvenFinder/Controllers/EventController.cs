using EvenFinder.Data;
using EvenFinder.Data2.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EvenFinder.Controllers
{
    public class EventController : Controller
    {

        private readonly IEventRepository _repository;
        public EventController(IEventRepository repository)
        {
            _repository = repository;
        }


        //private readonly DataContext _context;
        //public EventController(DataContext context)
        //{
        //    _context = context;
        //}

        public IActionResult List()
        {
            return View(_repository.Events.ToList());
        }

        public IActionResult Create() 
        {
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> Create(Event model)
        //{
        //    _context.Events.Add(model);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index","Home");
        //}

        //public async Task<IActionResult> List()
        //{
        //    return View(await _context.Events.ToListAsync());
        //}
    }
}

