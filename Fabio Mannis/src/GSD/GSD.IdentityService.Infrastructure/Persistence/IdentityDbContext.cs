using GSD.IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace GSD.IdentityService.Infrastructure.Persistence;
public class IdentityDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}
