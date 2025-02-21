using AnagraficaPazienti.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnagraficaPazienti.Infrastructure.Persistence
{
    public class AnagraficaPazientiContext : IdentityDbContext
    {
        public AnagraficaPazientiContext(DbContextOptions<AnagraficaPazientiContext> options)
            : base(options) { }

        public DbSet<Paziente> Pazienti { get; set; }
    }
}