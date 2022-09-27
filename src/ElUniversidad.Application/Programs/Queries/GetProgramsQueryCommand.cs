using ElUniversidad.Application.Programs.Results;
using ElUniversidad.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElUniversidad.Application.Programs.Queries
{
    public class GetProgramsQueryCommand : IQuery<ProgramsResult>
    {
        public GetProgramsQueryCommand() { }
    }
}
