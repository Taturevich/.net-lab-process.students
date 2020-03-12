using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Dto;
using WebApi.Services.Venues;
using Microsoft.AspNetCore.Http;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VenuesController : ControllerBase
    {
        private readonly IVenueService _venueService;

        public VenuesController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var result = await _venueService.GetById(id);
            if (result.Status == VenueOperationStatus.DoesNotExists)
            {
                return NotFound();
            }

            return Ok(result.Result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] VenueModel model)
        {
            var result = await _venueService.Create(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Result }, result.Result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] VenueModel model)
        {
            var resultStatus = await _venueService.Update(id, model);
            if (resultStatus == VenueOperationStatus.DoesNotExists)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            var resultStatus = await _venueService.Delete(id);
            if (resultStatus == VenueOperationStatus.DoesNotExists)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}