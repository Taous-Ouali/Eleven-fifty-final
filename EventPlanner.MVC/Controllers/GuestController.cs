using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Models.GuestModels;
using EventPlanner.Services.GuestServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventPlanner.MVC.Controllers
{
    public class GuestController : Controller
    {
        private readonly ILogger<GuestController> _logger;
        private readonly IGuestService _guestService;
        public GuestController(ILogger<GuestController> logger, IGuestService guestService)
        {
            _logger = logger;
            _guestService = guestService;
        }

        public async Task<IActionResult> Index() // ()needs to be reviewed 
        {
            var guests = await _guestService.GetGuests(); // () needs to be checked
            return View(guests);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var guest = await _guestService.GetGuestById(id);
            return View(guest);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> CreateGuest(GuestCreate model)
        {
            if(ModelState.IsValid == true)
            {
                if(await _guestService.CreateGuest(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ModelState);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var guest = await _guestService.GetGuestById(id);
            var guestEdit = new GuestEdit
            {
                Id = guest.Id,
                Name = guest.Name,
                Email = guest.Email,
            };
            return View(guestEdit);
        }

        public async Task<IActionResult> EditGuest(GuestEdit model)
        {
            if(ModelState.IsValid == true)
            {
                if(await _guestService.UpdateGuest(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ModelState);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var guest = await _guestService.GetGuestById(id);
            
            return View(guest);
        }

        public async Task<IActionResult> DeleteGuest(int id)
        {
                if(await _guestService.DeleteGuest(id))
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