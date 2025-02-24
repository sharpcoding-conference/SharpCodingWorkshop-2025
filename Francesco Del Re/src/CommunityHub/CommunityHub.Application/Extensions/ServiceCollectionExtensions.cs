using CommunityHub.Application.Interfaces;
using CommunityHub.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CommunityHub.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra i servizi associati alle entità
            services.AddScoped<IWebinarService, WebinarService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookingService, BookingService>();

            return services;
        }
    }
}
