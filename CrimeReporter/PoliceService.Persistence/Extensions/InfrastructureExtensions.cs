using Microsoft.Extensions.DependencyInjection;
using PoliceService.Application.Contracts.Persistence;
using PoliceService.Persistence.Repositories;

namespace PoliceService.Persistence.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddPoliceServicePersistence(this IServiceCollection services)
        {
            services.AddScoped<IPoliceUnitRepository, PoliceUnitRepository>();
            services.AddSingleton<PoliceUnitDatabaseSettings>();

            return services;
        }
    }
}
