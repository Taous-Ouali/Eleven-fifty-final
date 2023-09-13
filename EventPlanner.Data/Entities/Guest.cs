using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EventPlanner.Data.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<Table>? PurchasedTables { get; set; }
        public decimal GrandTotal { get{
            return PurchasedTables.Sum(p=>p.Price);
        } }


    }
}