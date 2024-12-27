using CommunityHub.Domain.Entities;
using CommunityHub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CommunityHub.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Webinar> Webinars { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasConversion(
                    v => v.ToString(),   // Convert to string for storage
                    v => new Email(v)    // Convert back to Email type
                );
            modelBuilder.Entity<Webinar>().HasKey(e => e.Id);
            modelBuilder.Entity<Booking>().HasKey(b => b.Id);
            modelBuilder.Entity<WebinarDateRange>().HasKey(w => w.Id);
        }
    }
}
