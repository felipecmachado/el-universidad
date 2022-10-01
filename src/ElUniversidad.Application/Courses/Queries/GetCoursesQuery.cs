using ElUniversidad.Application.Courses.Results;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Application.Courses.Queries
{
    public record GetCoursesQuery : IQuery<CoursesResult>;
}
