using ElUniversidad.Application.Programs.Results;
using ElUniversidad.Application.Students.Results;
using ElUniversidad.Domain.SeedWork;
using ElUniversidad.Domain.Students;

namespace ElUniversidad.Application.Students.Queries
{
    public record GetStudentQuery(Guid Id) : IQuery<StudentResult>;
}
