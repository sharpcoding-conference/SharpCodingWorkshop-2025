using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurazione autenticazione JWT
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        // Impostiamo l'Authority (il nostro AuthServer)
        options.Authority = "https://localhost:5001";
        // Indicare la audience, deve corrispondere a quella definita in AuthServer
        options.Audience = "resource_server_unique_name";
        // Se il server non usa HTTPS in dev, puoi disabilitare RequireHttpsMetadata
        options.RequireHttpsMetadata = false;
    });

// 2. Aggiungiamo i controller e lo swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Abilitiamo il middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();