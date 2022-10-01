using ElUniversidad.Domain.Courses;
using EntityFrameworkCore.Repository.Interfaces;

namespace ElUniversidad.Infrastructure.Data.Repositories.Interfaces
{
    public interface ICourseRepository : IRepository
    {
        Task<Course> GetExistingCourseAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
