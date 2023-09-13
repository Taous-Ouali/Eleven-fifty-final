using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Models.GuestModels;

namespace EventPlanner.Services.GuestServices
{
    public interface IGuestService
    {
        Task<bool> CreateGuest(GuestCreate model);
        Task<bool> UpdateGuest(GuestEdit model);
        Task<bool> DeleteGuest(int id);
        Task<GuestDetail> GetGuestById(int id);
        Task<List<GuestListItem>> GetGuests();
    }
}