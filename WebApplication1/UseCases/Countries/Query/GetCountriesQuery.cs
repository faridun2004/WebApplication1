using MediatR;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.UseCases.Countries.Query
{
    public record GetCountriesQuery(): IRequest<List<CountryDto>>;
   
}
