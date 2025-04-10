using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.DTOs.Forecast;
using WeatherApp.Repos.CityRepo;
using WeatherApp.Repos.ForecastRepo;

namespace WeatherApp.Repos.Forecast
{
    public class ForecastRepo : IForecastRepo
    {
        private readonly ICityRepo _repo;

        private readonly ApplicationDbContext _context;
        public ForecastRepo(ApplicationDbContext context, ICityRepo repo)
        {
            _context = context;
        }

        public List<ForecastResponseDto> GetForecastsByCityId(int cityId)
        {
            var forecasts = _context.Forecasts
                .Where(f => f.CityId == cityId)
                .Select(f => new ForecastResponseDto
                {
                    Id = f.Id,
                    CityId = f.CityId,
                    Date = f.Date,
                    Temperature = f.Temperature,
                    Condition = f.Condition
                })
                .ToList();

            return forecasts;
        }

        public void AddForecast(ForecastRequestDto forecastDto)
        {
            var forecast = new Entity.Forecast
            {
                CityId = forecastDto.CityId,
                Date = forecastDto.Date,
                Temperature = forecastDto.Temperature,
                Condition = forecastDto.Condition
            };

            _context.Forecasts.Add(forecast);
            _context.SaveChanges();
        }

        public void DeleteForecast(int id)
        {
            var forecast = _context.Forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast != null)
            {
                _context.Remove(forecast);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Forecast with ID {id} not found.");
            }
        }
    }
}

