using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanner.Models.EventModels
{
    public class EventListItem
    {
        public int Id { get; set; } 
        public string EventName { get; set; } = null;
        public DateTime Date { get; set; } 
      // public string Time { get; set; } 
        public string Location { get; set; } 
        
    }
}