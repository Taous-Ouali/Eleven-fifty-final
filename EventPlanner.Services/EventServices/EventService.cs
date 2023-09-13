using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventPlanner.Data.Context;
using EventPlanner.Data.Entities;
using EventPlanner.Models.EventModels;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Services.EventServices
{
    public class EventService : IEventService
    {
        private IMapper _mapper;
        public ApplicationDbContext _context;

        public EventService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateEvent(EventCreate model)
        {
            var eventEntity = _mapper.Map<Event>(model);
            await _context.Events.AddAsync(eventEntity);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteEvent(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity is null) return false;
            else 
            {
                _context.Events.Remove(eventEntity);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<EventDetail> GetEventById(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity is null) return new EventDetail();

            return _mapper.Map<EventDetail>(eventEntity);
        }

        public async Task<List<EventListItem>> GetEvents()
        {
            var conversion = await _context.Events.ToListAsync();
           return _mapper.Map<List<EventListItem>>(conversion);
        }

        public async Task<bool> UpdateEvent(EventEdit model)
        {
            var eventEntity = await _context.Events.FindAsync(model.Id);
            if (eventEntity is null) return false;
            else
            {
                eventEntity.Id = model.Id;
                eventEntity.EventName = model.EventName;
                eventEntity.Date = model.Date;
                eventEntity.Location = model.Location;

                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}