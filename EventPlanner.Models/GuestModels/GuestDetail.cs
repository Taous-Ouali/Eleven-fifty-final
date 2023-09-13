using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Data.Entities;
using EventPlanner.Models.TableModels;

namespace EventPlanner.Models.GuestModels
{
    public class GuestDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<TableListItem>? PurchasedTables { get; set; }
        public decimal GrandTotal { get{
            return PurchasedTables.Sum(p=>p.Price);
        } }
    }
}