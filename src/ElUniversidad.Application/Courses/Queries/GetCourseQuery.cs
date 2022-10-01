using ElUniversidad.Application.Courses.Results;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Application.Courses.Queries
{
    public record GetCourseQuery(Guid Id) : IQuery<CourseResult>;
}
