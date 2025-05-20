using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.UseCases.Cities.Create;
using WebApplication1.UseCases.Cities.Query;
using WebApplication1.UseCases.Countries.Create;
using WebApplication1.UseCases.Countries.Query;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController: ControllerBase
    {
         private readonly IMediator _mediator;
         public CountryController(IMediator mediator)
         {
              _mediator = mediator;
         }
         [HttpGet]
         public async Task<IActionResult> GetCountries()
         {
              var countries = await _mediator.Send(new GetCountriesQuery());
              return Ok(countries);
         }
         [HttpPost("CreateCountry")]
         public async Task<IActionResult> CreateCountry([FromBody] CreateCountryCommand command)
         {
              var result = await _mediator.Send(command);
              return Ok(result);
         }
    }
}
