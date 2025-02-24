using Microsoft.EntityFrameworkCore;
using AnagraficaMedica.Domain.Entities;

namespace AnagraficaMedica.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; } // Aggiungi DbSet per i medici

        public DbSet<HealthcareFacility> HealthcareFacilities { get; set; }
    }
}