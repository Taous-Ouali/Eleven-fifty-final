using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Data.Entities;
using EventPlanner.Models.EventModels;
using EventPlanner.Models.GuestModels;

namespace EventPlanner.Models.TableModels
{
    public class TableDetail
    {
        public int Id { get; set; }
        public int AmountOfChairs { get; set; }
        public int Price { get; set; }
        public GuestListItem? Guest { get; set; }
        public EventListItem Event { get; set; } = null!;
    }
}