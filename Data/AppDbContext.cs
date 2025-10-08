using EventManagementAPIEvaluationTask.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EventManagementAPIEvaluationTask.Data
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext // Application Database Context
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
     new Event
     {
         EventId = 1,
         Title = "Tech Conference",
         Description = "AI & Robotics",
         Date = new DateTime(2025, 11, 2),
         Location = "Muscat",
         MaxAttendees = 200
     },
     new Event
     {
         EventId = 2,
         Title = "Startup Pitch",
         Description = "New Startups",
         Date = new DateTime(2025, 12, 12),
         Location = "Dubai",
         MaxAttendees = 100
     }
 );

        }
    }
}

