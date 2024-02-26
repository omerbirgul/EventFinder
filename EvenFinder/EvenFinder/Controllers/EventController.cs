﻿using EvenFinder.Data;
using EvenFinder.Data2.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace EvenFinder.Controllers
{
    public class EventController : Controller
    {

        private ICommentRepository _commentRepository;
        private IEventRepository _eventRepository;
        private IRegistrationRepository _registrationRepository;
        public EventController(IEventRepository eventRepository, ICommentRepository commentRepository, IRegistrationRepository registrationRepository)
        {
            _eventRepository = eventRepository;
            _commentRepository = commentRepository;
            _registrationRepository = registrationRepository;
        }


        public IActionResult Index()
        {

            var claims = User.Claims;
            return View(_eventRepository.Events.ToList());
        }

        [Authorize]
        public IActionResult Create() 
        {
            if(User.Identity!.IsAuthenticated)
            {
            return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }


        [HttpPost]
        [Authorize]
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
            return View(await _eventRepository.Events
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(e => e.EventId == id));
        }


        [HttpPost]
        public IActionResult AddComment(int EventId,  string Text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);

            var entity = new Comment
            {
                Text = Text,
                PublishedOn = DateTime.Now,
                EventId = EventId,
                UserId = int.Parse(userId ?? "")
            };

            _commentRepository.CreateComment(entity);
            return Redirect($"/event/details/{EventId}");

        }



        [HttpPost]
        public IActionResult RegisterForEvent( int id)
        {
            if(User.Identity!.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var entity = new Registration
                {
                    EventId = id,
                    RegisterTime = DateTime.Now,
                    UserId = int.Parse(userId ?? "")
                };
                _registrationRepository.RegisterToEvent(entity);



                //var user = _registrationRepository.Registries
                //    .Include(x => x.User).ThenInclude(x => x.UserId)
                //    .Include(x => x.Event).ThenInclude(x => x.EventId)
                //    .FirstOrDefault(x => x.EventId == id);

                //_registrationRepository.RegisterToEvent(new Registration
                //{
                //    UserId = model.User.UserId,
                //    EventId = model.EventId,
                //    RegisterTime = DateTime.Now
                //});

                return RedirectToAction("List", "Event");
            }
            return RedirectToAction("Login", "User");
        }

    }
}

