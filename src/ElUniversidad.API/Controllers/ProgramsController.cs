using ElUniversidad.Application.Programs.Queries;
using ElUniversidad.Application.Programs.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElUniversidad.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/programs")]
    public class ProgramsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgramsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetProgramsAsync")]
        [ProducesResponseType(typeof(ProgramsResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProgramsAsync()
        {
            var response = await _mediator.Send(new GetProgramsQueryCommand()).ConfigureAwait(false);

            if (!response.Programs?.Any() ?? true)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}
