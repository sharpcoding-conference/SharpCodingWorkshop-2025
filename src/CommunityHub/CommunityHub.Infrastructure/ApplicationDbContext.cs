using CommunityHub.Domain.Entities;
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
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Webinar>().HasKey(e => e.Id);
            modelBuilder.Entity<Booking>().HasKey(b => b.Id);
        }
    }
}
