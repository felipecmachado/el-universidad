using ElUniversidad.Application.Students.Commands;
using ElUniversidad.Application.Students.Queries;
using ElUniversidad.Application.Students.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElUniversidad.API.Controllers
{
    [ApiController]
    [Route("api/students")]
    [Produces("application/json")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetStudentsAsync")]
        [ProducesResponseType(typeof(StudentsResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentsAsync()
        {
            var response = await _mediator.Send(new GetStudentsQuery()).ConfigureAwait(false);

            if (!response.Students?.Any() ?? true)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetStudentAsync")]
        [ProducesResponseType(typeof(StudentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentAsync([FromRoute] GetStudentQuery command)
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

        [HttpPost(Name = "AddNewStudentAsync")]
        [ProducesResponseType(typeof(StudentResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddNewStudentAsync(AddNewStudentCommand command)
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

            return Created(nameof(GetStudentAsync), response);
        }

        [HttpPut(Name = "UpdateStudentAsync")]
        [ProducesResponseType(typeof(StudentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStudentAsync(UpdateExistingStudentCommand command)
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
