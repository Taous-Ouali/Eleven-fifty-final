using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Data.Entities;
using EventPlanner.Models.TableModels;

namespace EventPlanner.Models.EventModels
{
    public class EventDetail
    {
        public int Id { get; set; } 
        public string EventName { get; set; } = null;
        public DateTime Date { get; set; } 
      // public string Time { get; set; } 
        public string Location { get; set; } 
        public string Description { get; set; } 

        public List<TableListItem>? Tables { get; set; }
    }
}