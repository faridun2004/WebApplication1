using MediatR;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.UseCases.Cities.Query
{
    public class GetCitiesByCountryIdQuery : IRequest<List<CityDto>>
    {
        public Guid CountryId { get; set; }
    }
}
