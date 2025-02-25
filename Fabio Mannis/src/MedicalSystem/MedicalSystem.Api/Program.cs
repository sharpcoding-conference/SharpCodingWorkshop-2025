using MedicalSystem.Application;
using MedicalSystem.Infrastructure;
using MedicalSystem.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Check if the application is running in development mode
var useInMemoryDatabase = builder.Environment.IsDevelopment();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin();
        corsPolicyBuilder.AllowAnyMethod();
        corsPolicyBuilder.AllowAnyHeader();
    });
});

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructure(builder.Configuration, useInMemoryDatabase);

var app = builder.Build();

// Popola il database solo se è in-memory
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (useInMemoryDatabase)
    {
        context.Database.EnsureCreated();
        ApplicationDbContext.SeedData(context); // ✅ Popola i dati solo se è in-memory
    }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();