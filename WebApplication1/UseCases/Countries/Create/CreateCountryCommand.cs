using MediatR;

namespace WebApplication1.UseCases.Countries.Create
{
    public record CreateCountryCommand(
        string Name,
        string Description   
        ): IRequest<Guid>;
   
}
