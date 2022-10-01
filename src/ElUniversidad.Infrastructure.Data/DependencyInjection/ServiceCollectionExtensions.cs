using EntityFrameworkCore.UnitOfWork.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ElUniversidad.Infrastructure.Data.Contexts;
using EntityFrameworkCore.Repository.Extensions;
using ElUniversidad.Infrastructure.Data.Repositories;
using ElUniversidad.Infrastructure.Data.Repositories.Interfaces;

namespace ElUniversidad.Infrastructure.Data.Modules
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddDataInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var connectionString = configuration.GetConnectionString("ElUniversidad"); 

            services.AddDbContext<ElUniversidadContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                options.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
            });

            services.AddScoped<DbContext, ElUniversidadContext>();

            services.AddUnitOfWork();
            services.AddUnitOfWork<ElUniversidadContext>();

            RegistryCustomRepositories(services);

            return services;
        }

        private static void RegistryCustomRepositories(IServiceCollection services)
        {
            services.AddCustomRepository<IProgramRepository, ProgramRepository>();
        }
    }
}