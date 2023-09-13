using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanner.Models.TableModels
{
    public class TableEdit
    {
       [Required]
        public int Id { get; set; }
       [Required]
        public int AmountOfChairs { get; set; }
        [Required]
        public int Price { get; set; }
        public int? GuestId { get; set; }
        [Required]
        public int EventId { get; set; }
    }
}