namespace WebApplication1.Models
{
    public class City: BaseEntity
    {
        public Guid RegionId { get; set; }
        public Region? Region { get; set; }
    }
}
