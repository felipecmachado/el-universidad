using ElUniversidad.Application.Students.Results;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Application.Students.Commands
{
    public record AddNewStudentCommand(string FirstName, string LastName, DateOnly BirthDate) : ICommand<StudentResult>;
}
