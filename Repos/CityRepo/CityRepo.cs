using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Entity;
using WeatherApp.DTOs.City;
using WeatherApp.DTOs.Forecast;
using WeatherApp.DTOs.Weather;
using WeatherApp.Repos.CityRepo;

namespace WeatherApp.Repos.City
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _context;

        public CityRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CityResponseDto> GetAllCities()
        {
            var cities = _context.Cities
                .Include(c => c.weather)
                .Include(c => c.Forecasts)
                .ToList();

            var cityDtos = cities.Select(city => new CityResponseDto
            {
                Name = city.Name,
                Country = city.Country,
                WeatherDto = new WeatherRequestDto
                {
                    CityId = city.Id,
                    WindSpeed = city.weather.WindSpeed,
                    Temperature = city.weather.Temperature,
                    Humidity = city.weather.Humidity,
                    Condition = city.weather.Condition
                },
                ForecastsDto = city.Forecasts.Select(forecast => new ForecastForCityDto
                {
                    Date = forecast.Date,
                    Temperature = forecast.Temperature,
                    Condition = forecast.Condition
                }).ToList()
            }).ToList();

            if (cityDtos != null) {
                return cityDtos;
            }

            return null;
        }

        public CityResponseDto GetCityById(int id)
        {
            var city = _context.Cities
                .Include(c => c.weather)
                .Include(c => c.Forecasts)
                .FirstOrDefault(c => c.Id == id);

            var cityDto = new CityResponseDto
            {
                Name = city.Name,
                Country = city.Country,
                WeatherDto = new WeatherRequestDto
                {
                    Humidity = city.weather.Humidity,
                    WindSpeed = city.weather.WindSpeed,
                    Condition = city.weather.Condition
                },
                ForecastsDto = city.Forecasts.Select(forecast => new ForecastForCityDto
                {
                    Date = forecast.Date,
                    Temperature = forecast.Temperature,
                }).ToList()
            };

            return cityDto;
        }

        public void AddCity(CityRequestDto cityRequestDto)
        {
            var city = new Entity.City
            {
                Name = cityRequestDto.Name,
                Country = cityRequestDto.Country
            };

            _context.Cities.Add(city);
            _context.SaveChanges();
        }
    }
}

