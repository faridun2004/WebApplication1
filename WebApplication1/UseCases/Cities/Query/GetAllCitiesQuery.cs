using MediatR;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.UseCases.Cities.Query
{
    public record GetAllCitiesQuery() : IRequest<List<CityDto>>;
}
