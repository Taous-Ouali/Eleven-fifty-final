using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Models.EventModels;

namespace EventPlanner.Services.EventServices
{
    public interface IEventService
    {
        Task<bool> CreateEvent(EventCreate model);
        Task<bool> UpdateEvent(EventEdit model);
        Task<bool> DeleteEvent(int id);
        Task<EventDetail> GetEventById(int id);
        Task<List<EventListItem>> GetEvents();
    }
}