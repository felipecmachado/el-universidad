using ElUniversidad.Domain.Programs;
using EntityFrameworkCore.Repository.Interfaces;

namespace ElUniversidad.Infrastructure.Data.Repositories.Interfaces
{
    public interface IProgramRepository : IRepository
    {
        Task<Program> GetExistingProgramAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
