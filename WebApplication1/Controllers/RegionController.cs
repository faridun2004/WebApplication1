using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.UseCases.Cities.Create;
using WebApplication1.UseCases.Cities.Query;
using WebApplication1.UseCases.Regions.Create;
using WebApplication1.UseCases.Regions.Query;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController: ControllerBase
    {
        private readonly IMediator _mediator;
        public RegionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetRegions()
        {
            var regions = await _mediator.Send( new GetRegionsQuery());
            return Ok(regions);
        }
        [HttpPost("CreateRegion")]
        public async Task<IActionResult> CreateRegion([FromBody] CreateRegionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
