using ElUniversidad.Application.Courses.Results;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Application.Courses.Commands
{
    public record UpdateExistingCourseCommand(Guid Id, string Title, string Description, int Credits, float MinimumGrade) : ICommand<CourseResult>;
}
