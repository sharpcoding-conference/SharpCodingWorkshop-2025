using GSD.OpenIddictAuthServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

var builder = WebApplication.CreateBuilder(args);

// 1. Configura DbContext
builder.Services.AddDbContext<OpenIddictDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    // Registra le entità OpenIddict tramite EF
    options.UseOpenIddict();
});

// 2. Configura Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    // Configurazioni password, lockout, ecc.
})
    .AddEntityFrameworkStores<OpenIddictDbContext>()
    .AddDefaultTokenProviders();

// 3. Configura OpenIddict
builder.Services.AddOpenIddict()
    .AddCore(options =>
    {
        // Registra il nostro DbContext e le entità OpenIddict
        options.UseEntityFrameworkCore()
               .UseDbContext<OpenIddictDbContext>();
    })
    .AddServer(options =>
    {
        // Abilita i flussi (password, auth code, refresh token, ecc.)
        options.AllowPasswordFlow();
        options.AllowRefreshTokenFlow();

        // Imposta l'endpoint
        options.SetTokenEndpointUris("/connect/token");

        // Registriamo la firma e la crittografia (in produzione useresti chiavi asimmetriche)
        options.AddDevelopmentEncryptionCertificate()
               .AddDevelopmentSigningCertificate();

        // Access token in formato JWT
        options.UseAspNetCore()
               .EnableTokenEndpointPassthrough();

        // Convalida i permessi
        options.RegisterScopes(Scopes.OpenId, Scopes.Profile, Scopes.Email, "api");
    })
    .AddValidation(options =>
    {
        // Convalida JWT
        options.UseLocalServer();
        options.UseAspNetCore();
    });

// 4. Aggiungi i servizi controller
builder.Services.AddControllers();

var app = builder.Build();

// 5. Inizializziamo OpenIddict (ricetta consigliata)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<OpenIddictDbContext>();
    context.Database.EnsureCreated();

    // Creiamo un client di esempio in DB
    var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();
    if (await manager.FindByClientIdAsync("GSD.IdentityService") is null)
    {
        await manager.CreateAsync(new OpenIddictApplicationDescriptor
        {
            ClientId = "GSD.IdentityService",
            ClientSecret = "super_secret",
            Permissions =
            {
                Permissions.Endpoints.Token,
                Permissions.GrantTypes.Password,
                Permissions.GrantTypes.RefreshToken
            }
        });
    }
}

app.UseRouting();

// 6. Attiva Identity & OpenIddict
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
