using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PoliceService.Application.Functions.PoliceUnits.Queries.GetPoliceUnitsList;
using System.Reflection;

namespace PoliceService.Application.Extensions
{
    public static class ApplicationCoreExtensions
    {
        public static IServiceCollection AddPoliceServiceApplicationCore(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetPoliceUnitsListQueryHandler).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandler<,>));

            return services;
        }
    }
}
