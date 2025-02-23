using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using AnagraficaMedica.Infrastructure.Persistence;
using AnagraficaMedica.Infrastructure.Repositories;
using AnagraficaMedica.Application.Services;
using AnagraficaMedica.Application.Interfaces;
using AnagraficaMedica.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin() // Permette qualsiasi origine
            .AllowAnyMethod() // Permette qualsiasi metodo HTTP
            .AllowAnyHeader(); // Permette qualsiasi intestazione
    });
});

// Configura il database in-memory
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("PatientDb"));

// Registra i servizi
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Anagrafica Pazienti API", Version = "v1" });
});

var app = builder.Build();

// Inizializza il database con dati di test
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated(); // Assicura la creazione del database in-memory
    DbInitializer.Seed(context); // Popola con dati di test
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Anagrafica Pazienti API v1"));
}
app.UseAuthorization();
app.UseCors("AllowAllOrigins");
app.MapControllers();
app.Run();