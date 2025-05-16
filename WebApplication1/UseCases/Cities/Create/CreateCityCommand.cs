using MediatR;

namespace WebApplication1.UseCases.Cities.Create
{
    public record CreateCityCommand(
        string Name,
        string Description,
        Guid RegionId
        ) : IRequest<Guid>;
}
