using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Data.Entities;

namespace EventPlanner.Models.EventModels
{
    public class EventCreate
    {
        [Required]
        public string EventName { get; set; } = null;
        [Required]
        public DateTime Date { get; set; } 
        // public string Time { get; set; } 
        [Required]
        public string Location { get; set; } 
        [Required]
        public string Description { get; set; } 

    }
}