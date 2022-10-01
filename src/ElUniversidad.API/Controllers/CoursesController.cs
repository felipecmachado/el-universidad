using ElUniversidad.Application.Courses.Commands;
using ElUniversidad.Application.Courses.Queries;
using ElUniversidad.Application.Courses.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElUniversidad.API.Controllers
{
    [ApiController]
    [Route("api/courses")]
    [Produces("application/json")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetCoursesAsync")]
        [ProducesResponseType(typeof(CoursesResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCoursesAsync()
        {
            var response = await _mediator.Send(new GetCoursesQuery()).ConfigureAwait(false);

            if (!response.Courses?.Any() ?? true)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetCourseAsync")]
        [ProducesResponseType(typeof(CourseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCourseAsync([FromRoute] GetCourseQuery command)
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

        [HttpPost(Name = "AddNewCourseAsync")]
        [ProducesResponseType(typeof(CourseResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddNewCourseAsync(AddNewCourseCommand command)
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

            return Created(nameof(GetCourseAsync), response);
        }

        [HttpPut(Name = "UpdateCourseAsync")]
        [ProducesResponseType(typeof(CourseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCourseAsync(UpdateExistingCourseCommand command)
        {
            var response = await _mediator.Send(command).ConfigureAwait(false);

            return Ok(response);
        }
    }
}
