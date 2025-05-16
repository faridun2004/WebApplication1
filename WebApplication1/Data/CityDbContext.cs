using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions<CityDbContext> options)
             : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Regions)
                .WithOne(r => r.Country)
                .HasForeignKey(r => r.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.Cities)
                .WithOne(c => c.Region)
                .HasForeignKey(c => c.RegionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
