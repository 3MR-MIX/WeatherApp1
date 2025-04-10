using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Repos.City;
using WeatherApp.Repos.CityRepo;
using WeatherApp.Repos.Forecast;
using WeatherApp.Repos.ForecastRepo;
using WeatherApp.Repos.WeatherRepo;

namespace WeatherApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(option => 
            option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));


            builder.Services.AddScoped<ICityRepo, CityRepo>();
            builder.Services.AddScoped<IWeatherRepo,WeatherRepo>();
            builder.Services.AddScoped<IForecastRepo, ForecastRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }   
    }
}
