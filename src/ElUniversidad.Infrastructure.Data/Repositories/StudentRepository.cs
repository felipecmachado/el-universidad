using ElUniversidad.Domain.Students;
using ElUniversidad.Infrastructure.Data.Contexts;
using ElUniversidad.Infrastructure.Data.Repositories.Interfaces;
using EntityFrameworkCore.Repository;

namespace ElUniversidad.Infrastructure.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ElUniversidadContext dbContext)
            : base(dbContext) { }

        public async Task<Student> GetExistingStudentAsync(Guid id, CancellationToken cancellationToken)
        {
            var query = SingleResultQuery()
                        .AndFilter(x => x.Id == id);

            var student = await SingleOrDefaultAsync(query, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            return student;
        }
    }
}