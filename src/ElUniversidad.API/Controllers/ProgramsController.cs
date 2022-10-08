using ElUniversidad.Application.Programs.Commands;
using ElUniversidad.Application.Programs.Queries;
using ElUniversidad.Application.Programs.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElUniversidad.API.Controllers
{
    [ApiController]
    [Route("api/programs")]
    [Produces("application/json")]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProgramsAsync()
        {
            var response = await _mediator.Send(new GetProgramsQuery()).ConfigureAwait(false);

            if (!response.Programs?.Any() ?? true)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetProgramAsync")]
        [ProducesResponseType(typeof(ProgramResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProgramAsync([FromRoute] GetProgramQuery command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command).ConfigureAwait(false);

            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost(Name = "AddNewProgramAsync")]
        [ProducesResponseType(typeof(ProgramResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddNewProgramAsync(AddNewProgramCommand command)
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

            return Created(nameof(GetProgramAsync), response);
        }

        [HttpPut(Name = "UpdateProgramAsync")]
        [ProducesResponseType(typeof(ProgramResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProgramAsync(UpdateExistingProgramCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command).ConfigureAwait(false);

            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
