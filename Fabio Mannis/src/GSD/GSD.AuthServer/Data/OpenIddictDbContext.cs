using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenIddict.EntityFrameworkCore.Models;

namespace GSD.OpenIddictAuthServer.Data;

public class OpenIddictDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public OpenIddictDbContext(DbContextOptions<OpenIddictDbContext> options)
        : base(options) { }

    // Tabelle OpenIddict (client, scope, token, ecc.)
    public DbSet<OpenIddictEntityFrameworkCoreApplication> OpenIddictApplications { get; set; }
    public DbSet<OpenIddictEntityFrameworkCoreAuthorization> OpenIddictAuthorizations { get; set; }
    public DbSet<OpenIddictEntityFrameworkCoreScope> OpenIddictScopes { get; set; }
    public DbSet<OpenIddictEntityFrameworkCoreToken> OpenIddictTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configurazione OpenIddict EF
        builder.UseOpenIddict();
    }
}

// Esempio di entity Identity (puoi personalizzarla):
public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
}

public class ApplicationRole : IdentityRole
{
}