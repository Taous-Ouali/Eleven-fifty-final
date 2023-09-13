using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanner.Models.EventModels
{
    public class EventEdit
    {
        [Required]
        public int Id { get; set; } 
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