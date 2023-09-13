using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanner.Models.GuestModels
{
    public class GuestCreate
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}