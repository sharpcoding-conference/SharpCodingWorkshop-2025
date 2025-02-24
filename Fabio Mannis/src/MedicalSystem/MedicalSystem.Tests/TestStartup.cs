using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MedicalSystem.Infrastructure.Persistence;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace MedicalSystem.API.IntegrationTests
{
    public class TestStartup : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove existing database context
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add In-Memory Database for Testing
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("MedicalSystemTestDB");
                });

                // Build the service provider
                var sp = services.BuildServiceProvider();

                // Create a scope to get the database context
                using (var scope = sp.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    db.Database.EnsureCreated(); // Ensure database is created for testing
                }
            });
        }
    }
}