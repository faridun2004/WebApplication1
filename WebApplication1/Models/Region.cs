namespace WebApplication1.Models
{
    public class Region: BaseEntity
    {
        public Guid CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
