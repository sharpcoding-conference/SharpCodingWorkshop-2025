using IdentityServer4.Models;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configuri IdentityServer in memoria per semplicità
builder.Services.AddIdentityServer()
    .AddInMemoryClients(new List<Client>
    {
        new Client
        {
            ClientId = "GSD.IdentityService",
            AllowedGrantTypes = GrantTypes.Code,
            ClientSecrets = { new Secret("super_secret".Sha256()) },
            RedirectUris = { "https://localhost:5002/callback" },
            PostLogoutRedirectUris = { "https://localhost:5002/logout" },
            AllowedScopes = { "openid", "profile", "email", "api" }
        }
    })
    .AddInMemoryIdentityResources(new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResources.Email()
    })
    .AddInMemoryApiScopes(new List<ApiScope>
    {
        new ApiScope("api", "API Access")
    });

var app = builder.Build();
app.UseIdentityServer();
app.Run();