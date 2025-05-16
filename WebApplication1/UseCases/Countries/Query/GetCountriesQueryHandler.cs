using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.UseCases.Countries.Query
{
    public class GetCountriesQueryHandler: IRequestHandler<GetCountriesQuery, List<CountryDto>>
    {
        private readonly CityDbContext _context;
        public GetCountriesQueryHandler(CityDbContext context)
        {
            _context = context;
        }
        public async Task<List<CountryDto>> Handle(GetCountriesQuery query, CancellationToken cancellationToken)
        {
            var countries=await _context.Countries.ToListAsync(cancellationToken);
            return countries.Select(country => new CountryDto
            {
              Id = country.Id,
              Name = country.Name,
              Description = country.Description
            }).ToList();
        }
    }
}
