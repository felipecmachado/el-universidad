using ElUniversidad.Application.Programs.Queries;
using ElUniversidad.Application.Programs.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElUniversidad.API.Controllers
{
    [ApiController]
    [Route("api/offers")]
    [Produces("application/json")]
    public class OffersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OffersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetOffersAsync")]
        [ProducesResponseType(typeof(OffersResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOffersAsync()
        {
            var response = await _mediator.Send(new GetOffersQuery()).ConfigureAwait(false);

            if (!response.Offers?.Any() ?? true)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetOfferAsync")]
        [ProducesResponseType(typeof(OfferResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOfferAsync([FromRoute] GetOfferQuery command)
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