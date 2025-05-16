using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.UseCases.Cities.Query
{
    public class GetCitiesByCountryIdQueryHandler : IRequestHandler<GetCitiesByCountryIdQuery, List<CityDto>>
    {
        private readonly CityDbContext _context;

        public GetCitiesByCountryIdQueryHandler(CityDbContext context)
        {
            _context = context;
        }

        public async Task<List<CityDto>> Handle(GetCitiesByCountryIdQuery request, CancellationToken cancellationToken)
        {     
            return await _context.Cities
                .Where(c => c.Region != null && c.Region.CountryId == request.CountryId)
                .Select(c => new CityDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    RegionName=c.Region.Name

                })
                .ToListAsync(cancellationToken);
        }
    }
}
