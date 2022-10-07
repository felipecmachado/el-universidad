using ElUniversidad.Domain.Courses;
using ElUniversidad.Domain.Programs;
using ElUniversidad.Infrastructure.Data.Contexts;
using ElUniversidad.Infrastructure.Data.Repositories.Interfaces;
using EntityFrameworkCore.Repository;

namespace ElUniversidad.Infrastructure.Data.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ElUniversidadContext dbContext)
            : base(dbContext) { }

        public async Task<Course> GetExistingCourseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = SingleResultQuery()
                        .AndFilter(x => x.Id == id);

            var course = await SingleOrDefaultAsync(query, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            return course;
        }
    }
}
