using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventPlanner.Data.Context;
using EventPlanner.Data.Entities;
using EventPlanner.Models.GuestModels;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Services.GuestServices
{
    public class GuestService : IGuestService
    {
            private IMapper _mapper;
            public ApplicationDbContext _context;

            public GuestService(IMapper mapper, ApplicationDbContext context)
            {
                _mapper = mapper;
                _context = context;
            }
        public async Task<bool> CreateGuest(GuestCreate model)
        {
            var guest = _mapper.Map<Guest>(model);
            await _context.Guests.AddAsync(guest);
            return await _context.SaveChangesAsync()>0;
        }

        public async  Task<bool> DeleteGuest(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest is null) return false;
            else 
            {
                _context.Guests.Remove(guest);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<GuestDetail> GetGuestById(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest is null) return new GuestDetail();

            return _mapper.Map<GuestDetail>(guest);
        }

        public async Task<List<GuestListItem>> GetGuests()
        {
            var conversion = await _context.Guests.ToListAsync();
            return _mapper.Map<List<GuestListItem>>(conversion);
        }

        public async Task<bool> UpdateGuest(GuestEdit model)
        {
            var guest = await _context.Guests.FindAsync(model.Id);
            if (guest is null) return false;
            else
            {
                guest.Id = model.Id;
                guest.Name = model.Name;
                guest.Email = model.Email;

                await _context.SaveChangesAsync();
                return true;

            }
        }
    }
}