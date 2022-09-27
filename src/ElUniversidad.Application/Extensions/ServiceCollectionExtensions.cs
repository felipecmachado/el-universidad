using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ElUniversidad.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services;
        }

        public static IServiceCollection AddCQRSConfiguration(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);

            return services;
        }

        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (assemblies?.Any() ?? false)
            {
                var assembliesInternal = assemblies.Distinct();

                services.AddAutoMapper((provider, mapperConfiguration) => mapperConfiguration.AddMaps(assembliesInternal), assembliesInternal);
            }

            return services;
        }
    }
}