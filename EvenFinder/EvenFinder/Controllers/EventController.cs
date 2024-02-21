using EvenFinder.Data;
using EvenFinder.Data2.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EvenFinder.Controllers
{
    public class EventController : Controller
    {

        private readonly IEventRepository _eventRepository;
        private readonly DataContext _context;
        public EventController(IEventRepository eventRepository, DataContext context)
        {
            _eventRepository = eventRepository;
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_eventRepository.Events.ToList());
        }

        public IActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Event model)
        {
            //_context.Events.Add(model);
            //await _context.SaveChangesAsync();
            _eventRepository.CreateEvent(
                new Event
                {
                    EventName = model.EventName,
                    Description = model.Description,
                    EventLocation = model.EventLocation,
                    EventImage = model.EventImage,
                    EventDate = model.EventDate,
                    IsActive = model.IsActive,
                }
                );
            return RedirectToAction("Index", "Home");
        }

        public IActionResult List()
        {
            //return View(await _context.Events.ToListAsync());
            return View(_eventRepository.Events.ToList());
        }


        public async Task<IActionResult> Details(int? id)
        {
            return View(await _eventRepository.Events.FirstOrDefaultAsync(e => e.EventId == id));
        }
    }
}

