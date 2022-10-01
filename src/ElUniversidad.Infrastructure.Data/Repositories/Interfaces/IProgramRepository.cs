using ElUniversidad.Domain.Students;
using EntityFrameworkCore.Repository.Interfaces;

namespace ElUniversidad.Infrastructure.Data.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository
    {
        Task<Student> GetExistingStudentAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
