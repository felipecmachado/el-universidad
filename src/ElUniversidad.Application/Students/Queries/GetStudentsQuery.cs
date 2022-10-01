using ElUniversidad.Application.Students.Results;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Application.Students.Queries
{
    public record GetStudentsQuery : IQuery<StudentsResult>;
}
