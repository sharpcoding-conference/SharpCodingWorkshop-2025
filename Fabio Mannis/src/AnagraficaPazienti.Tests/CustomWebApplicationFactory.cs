using AnagraficaPazienti.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Rimuove il DbContext esistente
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AnagraficaPazientiContext>));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Aggiunge un nuovo DbContext InMemory
            services.AddDbContext<AnagraficaPazientiContext>(options =>
            {
                options.UseInMemoryDatabase("TestDb");
            });

            // Crea il database di test
            using var scope = services.BuildServiceProvider().CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<AnagraficaPazientiContext>();
            db.Database.EnsureCreated();
        });
    }
}