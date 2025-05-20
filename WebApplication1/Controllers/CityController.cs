using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.UseCases.Cities.Create;
using WebApplication1.UseCases.Cities.Query;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _mediator.Send(new GetAllCitiesQuery());
            return Ok(cities);
        }
        [HttpPost("CreateCity")]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("by-country/{countryId:guid}")]
        public async Task<ActionResult<List<City>>> GetCitiesByCountryId(Guid countryId, CancellationToken cancellationToken)
        {
            var query = new GetCitiesByCountryIdQuery { CountryId = countryId };
            var cities = await _mediator.Send(query, cancellationToken);
            return Ok(cities);
        }

    }
}
