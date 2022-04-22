using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PoliceService.Application.Behaviours;
using PoliceService.Application.Functions.PoliceUnits.Queries.GetPoliceUnitsList;
using PoliceService.Application.HttpClients;
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
            services.AddHttpClient<IHttpCrimeClient, CrimeHttpClient>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandler<,>));

            return services;
        }
    }
}
