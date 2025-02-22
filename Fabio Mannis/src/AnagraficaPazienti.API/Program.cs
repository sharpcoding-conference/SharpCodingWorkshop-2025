using AnagraficaPazienti.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configura Identity e JWT con InMemory DB
builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Anagrafica Pazienti API", Version = "v1" });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AnagraficaPazientiContext>();
    context.Database.EnsureCreated(); // Crea il database in memoria

    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // Crea ruoli di default
    if (!roleManager.RoleExistsAsync("Admin").Result)
    {
        roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
        roleManager.CreateAsync(new IdentityRole("User")).Wait();
    }

    // Crea un utente Admin di test
    if (userManager.FindByEmailAsync("admin@example.com").Result == null)
    {
        var user = new IdentityUser
        {
            UserName = "admin@example.com",
            Email = "admin@example.com"
        };

        var result = userManager.CreateAsync(user, "Password123!").Result;

        if (result.Succeeded)
        {
            userManager.AddToRoleAsync(user, "Admin").Wait();
        }
    }
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Anagrafica Pazienti API v1"));

app.Run();