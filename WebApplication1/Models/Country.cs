namespace WebApplication1.Models
{
    public class Country : BaseEntity
    {
        public ICollection<Region> Regions { get; set; } = new List<Region>();
    }
}
