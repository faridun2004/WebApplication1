using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.UseCases.Cities.Query;

namespace WebApplication1.UseCases.Regions.Query
{
    public class GetRegionsQueryHandler: IRequestHandler<GetRegionsQuery, List<RegionDto>>
    {
        private readonly CityDbContext _context;
        public GetRegionsQueryHandler(CityDbContext context)
        {
            _context = context;
        }
        public async Task<List<RegionDto>> Handle(GetRegionsQuery query, CancellationToken cancellationToken)
        {
            var regions =await _context.Regions
                .Include(region=>region.Country)
                .ToListAsync(cancellationToken);
            return regions.Select(city => new RegionDto
            {
                Id = city.Id,
                Name = city.Name,
                Description = city.Description,
                CountryName = city.Country?.Name ?? "Unknown"
            }).ToList();
        }     

    }
}
