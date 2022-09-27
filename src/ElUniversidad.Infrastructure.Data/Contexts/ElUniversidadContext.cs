using Microsoft.EntityFrameworkCore;

namespace ElUniversidad.Infrastructure.Data.Contexts
{
    public class ElUniversidadContext : DbContext
    {
        public ElUniversidadContext(DbContextOptions<ElUniversidadContext> options)
           : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ElUniversidadContext).Assembly);
        }
    }
}
