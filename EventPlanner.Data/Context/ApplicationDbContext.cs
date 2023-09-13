using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base (options) { }
        public DbSet<Event> Events {get; set;}  
        public DbSet<Guest> Guests {get; set;} 
        public DbSet<Table> Tables {get; set;} 
        
    }
}