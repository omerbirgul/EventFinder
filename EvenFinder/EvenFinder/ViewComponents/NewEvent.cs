using EvenFinder.Data2.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EvenFinder.ViewComponents
{
    public class NewEvent  : ViewComponent
    {
        private IEventRepository _eventRepository;
        public NewEvent(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }


        public IViewComponentResult Invoke()
        {
            return View(_eventRepository.Events
                .OrderByDescending(p => p.EventDate)
                .ToList());
        }
    }
}
