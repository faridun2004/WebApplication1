using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.UseCases.Cities.Query
{
    public class GetAllCitiesCommandHandler : IRequestHandler<GetAllCitiesQuery, List<CityDto>>
    {
        private readonly CityDbContext _context;
        public GetAllCitiesCommandHandler(CityDbContext context)
        {
            _context = context;
        }
        public async Task<List<CityDto>> Handle(GetAllCitiesQuery query, CancellationToken cancellationToken)
        {
            var cities = await _context.Cities
                .Include(city => city.Region)
                .ToListAsync(cancellationToken);

            return cities.Select(city => new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                Description = city.Description,
                RegionName = city.Region?.Name ?? "Unknown", 
            }).ToList();
        }
    }
}
