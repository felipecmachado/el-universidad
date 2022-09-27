using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ElUniversidad.Infrastructure.Data.Contexts;
using ElUniversidad.Domain.Programs;

namespace ElUniversidad.Infrastructure.Data.Seeders
{
    public static class ElUniversidadInitializer
    {
        public static void ElUniversidadInitializeAndSeed(this IServiceCollection services)
        {
            var serviceScopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();

            using var serviceScope = serviceScopeFactory.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ElUniversidadContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
 
            // Initial data
            SeedData(serviceScope);
        }

        private static void SeedData(IServiceScope serviceScope)
        {
            var unitOfWork = serviceScope.ServiceProvider.GetService<IUnitOfWork>();
            var repository = unitOfWork?.Repository<Program>();

            if (repository is not null)
            {
                var programs = ProgramsSeeder.SeedPrograms();

                repository.AddRange(programs);
                unitOfWork.SaveChanges();
            }
        }
    }
}
