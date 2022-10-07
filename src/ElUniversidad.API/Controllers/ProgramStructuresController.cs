using ElUniversidad.Application.Courses.Results;
using ElUniversidad.Application.Programs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElUniversidad.API.Controllers
{
    [ApiController]
    [Route("api/program-structures")]
    [Produces("application/json")]
    public class ProgramStructuresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgramStructuresController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetProgramStructuresAsync")]
        [ProducesResponseType(typeof(CoursesResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProgramStructuresAsync()
        {
            var response = await _mediator.Send(new GetProgramStructuresQuery()).ConfigureAwait(false);

            if (!response.ProgramStructures?.Any() ?? true)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetProgramStructureAsync")]
        [ProducesResponseType(typeof(CourseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProgramStructureAsync([FromRoute] GetProgramStructureQuery command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command).ConfigureAwait(false);

            if (response is null)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}