using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AnagraficaPazienti.Infrastructure.Persistence;

public static class IdentityConfiguration
{
    public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AnagraficaPazientiContext>(options =>
            options.UseInMemoryDatabase("AnagraficaPazientiDb"));

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AnagraficaPazientiContext>()
            .AddDefaultTokenProviders();

        var key = Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });
    }
}