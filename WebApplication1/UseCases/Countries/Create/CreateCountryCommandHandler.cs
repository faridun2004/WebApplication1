using MediatR;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.UseCases.Countries.Create
{
    public class CreateCountryCommandHandler: IRequestHandler<CreateCountryCommand,Guid>
    {
        private readonly CityDbContext _context;
        public CreateCountryCommandHandler(CityDbContext context) 
        {
            _context = context; 
        }
        public async Task<Guid> Handle(CreateCountryCommand command, CancellationToken cancellationToken) 
        {
            var country = new Country
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,

            };
            _context.Countries.Add(country);    
            await _context.SaveChangesAsync(cancellationToken);
            return country.Id;
        }
    }
}
