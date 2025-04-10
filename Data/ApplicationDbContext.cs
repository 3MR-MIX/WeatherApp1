using Microsoft.EntityFrameworkCore;
using WeatherApp.Entity;

namespace WeatherApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<Forecast> Forecasts { get; set; }
    }
}
