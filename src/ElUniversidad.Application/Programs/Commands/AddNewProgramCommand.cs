using ElUniversidad.Application.Programs.Results;
using ElUniversidad.Domain.Programs.Enums;
using ElUniversidad.Domain.SeedWork;

namespace ElUniversidad.Application.Programs.Commands
{
    public record AddNewProgramCommand(string Code, string Title, string Description, DegreeType Degree): ICommand<ProgramResult>;
}
