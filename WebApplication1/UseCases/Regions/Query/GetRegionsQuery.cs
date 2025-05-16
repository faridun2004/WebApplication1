using MediatR;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.UseCases.Regions.Query
{
    public record GetRegionsQuery(): IRequest<List<RegionDto>>;
   
}
