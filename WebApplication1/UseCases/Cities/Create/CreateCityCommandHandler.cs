using MediatR;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.UseCases.Cities.Create
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Guid>
    {
        private readonly CityDbContext _context;
        public CreateCityCommandHandler(CityDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateCityCommand command, CancellationToken cancellationToken)
        {
            var region = await _context.Countries.FindAsync(command.RegionId, cancellationToken);
            if (region == null)
            {
                throw new InvalidOperationException($"Region with Id {command.RegionId} not found.");
            }
            var citys = new City
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
                RegionId = command.RegionId,
            };
            _context.Cities.Add(citys);
            await _context.SaveChangesAsync(cancellationToken);
            return citys.Id;
        }
    }
}
