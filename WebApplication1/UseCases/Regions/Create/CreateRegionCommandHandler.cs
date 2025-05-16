using MediatR;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.UseCases.Regions.Create
{
    public class CreateRegionCommandHandler: IRequestHandler<CreateRegionCommand, Guid>
    {
        private readonly CityDbContext _context;
        public CreateRegionCommandHandler(CityDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateRegionCommand command, CancellationToken cancellationToken)
        {
            var country = await _context.Countries.FindAsync(  command.CountryId , cancellationToken);
            if (country == null)
            {
                throw new InvalidOperationException($"Country with Id {command.CountryId} not found.");
            }

            var region = new Region
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Desctiption,
                CountryId = command.CountryId,
            };
            _context.Regions.Add(region);
            await _context.SaveChangesAsync(cancellationToken);
            return region.Id;
        }
    }
}
