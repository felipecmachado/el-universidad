using ElUniversidad.Domain.Programs;
using ElUniversidad.Infrastructure.Data.Contexts;
using ElUniversidad.Infrastructure.Data.Repositories.Interfaces;
using EntityFrameworkCore.Repository;

namespace ElUniversidad.Infrastructure.Data.Repositories
{
    public class ProgramRepository : Repository<Program>, IProgramRepository
    {
        public ProgramRepository(ElUniversidadContext dbContext)
            : base(dbContext) { }

        public async Task<Program> GetExistingProgramAsync(Guid id, CancellationToken cancellationToken)
        {
            var query = SingleResultQuery()
                        .AndFilter(x => x.Id == id);

            var program = await SingleOrDefaultAsync(query, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            return program;
        }
    }
}
