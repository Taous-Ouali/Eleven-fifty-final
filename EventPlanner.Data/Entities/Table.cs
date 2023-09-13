using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanner.Data.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int AmountOfChairs { get; set; }
        public int Price { get; set; }
        public int? GuestId { get; set; } 
        public Guest? Guest { get; set; }
        public int EventId { get; set; } 
        public Event Event { get; set; } = null!;
    }
}