using MediatR;
using WebApplication1.Models;

namespace WebApplication1.UseCases.Regions.Create
{
    public record CreateRegionCommand(
        string Name,
        string Desctiption,
        Guid CountryId
        ) :IRequest<Guid>;
    
}
