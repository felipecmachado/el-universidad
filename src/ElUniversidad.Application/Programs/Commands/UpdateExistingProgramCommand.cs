using ElUniversidad.Application.Programs.Results;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Application.Programs.Commands
{
    public record UpdateExistingProgramCommand(Guid Id, string Title, string Description) : ICommand<ProgramResult>;
}
