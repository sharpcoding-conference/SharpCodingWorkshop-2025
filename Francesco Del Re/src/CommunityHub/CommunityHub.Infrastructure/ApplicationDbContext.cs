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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

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

            // Relazione Booking -> Webinar (molti a uno)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Webinar)
                .WithMany(w => w.Bookings)
                .HasForeignKey(b => b.WebinarId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relazione Booking -> User (molti a uno)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
