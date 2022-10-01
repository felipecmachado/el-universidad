using ElUniversidad.Application.Students.Results;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Application.Students.Commands
{
    public record UpdateExistingStudentCommand(Guid Id) : ICommand<StudentResult>;
}
