using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Models.EventModels;
using EventPlanner.Services.EventServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace EventPlanner.MVC.Controllers
{
    
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        private readonly IEventService _eventService;
        public EventController(ILogger<EventController> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetEvents();
            return View(events);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var eventEntity = await _eventService.GetEventById(id);
            return View(eventEntity);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> CreateEvent(EventCreate model)
        {
            if(ModelState.IsValid == true)
            {
                if(await _eventService.CreateEvent(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ModelState);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var eventEntity = await _eventService.GetEventById(id);
            var eventEdit = new EventEdit
            {
                Id = eventEntity.Id,
                EventName = eventEntity.EventName,
                Date = eventEntity.Date,
                Location = eventEntity.Location
            };
            return View(eventEdit);
        }

        public async Task<IActionResult> EditEvent(EventEdit model)
        {
            if(ModelState.IsValid == true)
            {
                if(await _eventService.UpdateEvent(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ModelState);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var eventEntity = await _eventService.GetEventById(id);
            
            return View(eventEntity);
        }

        public async Task<IActionResult> DeleteEvent(int id)
        {
                if(await _eventService.DeleteEvent(id))
                {
                    return RedirectToAction(nameof(Index));
                }
            
            return BadRequest("Invalid Id.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}