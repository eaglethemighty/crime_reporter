using Microsoft.Extensions.DependencyInjection;
using PoliceService.Application.Contracts.Persistence;
using PoliceService.Domain.Entities;
using PoliceService.Persistence.Repositories;

namespace PoliceService.Persistence.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddPoliceServicePersistence(this IServiceCollection services)
        {
            services.AddScoped<IAsyncRepository<PoliceUnit>, PoliceUnitRepository>();
            services.AddSingleton<PoliceUnitDatabaseSettings>();

            return services;
        }
    }
}
