using CommunityHub.Domain.Entities;
using CommunityHub.Domain.Interfaces;
using CommunityHub.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CommunityHub.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Registra repository e altri servizi
            services.AddScoped<IRepository<Webinar>, WebinarRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Booking>, BookingRepository>();

            return services;
        }
    }
}
