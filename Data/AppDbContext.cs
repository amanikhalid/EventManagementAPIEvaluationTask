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
            modelBuilder.Entity<Attendee>()
                .HasIndex(a => a.Email)
                .IsUnique();

            // Optional: seed sample events here
            modelBuilder.Entity<Event>().HasData(
                new Event { EventId = 1, Title = "Tech Conference", Description = "AI & Robotics", Date = DateTime.UtcNow.AddDays(10), Location = "Muscat", MaxAttendees = 200 },
                new Event { EventId = 2, Title = "Startup Pitch", Description = "New Startups", Date = DateTime.UtcNow.AddDays(20), Location = "Dubai", MaxAttendees = 100 }
            );
        }
    }
}

