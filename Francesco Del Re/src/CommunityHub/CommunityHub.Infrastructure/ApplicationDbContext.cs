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

        // Override di SaveChanges per intercettare nuove prenotazioni
        // e aggiornare il numero di posti disponibili del relativo Webinar
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Booking>())
            {
                var webinar = await Webinars.FindAsync([entry.Entity.WebinarId], cancellationToken);

                if (entry.State == EntityState.Added)
                {
                    webinar?.ReserveSeat();
                }
                else if (entry.State == EntityState.Deleted)
                {
                    webinar?.CancelSeatReservation();
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
