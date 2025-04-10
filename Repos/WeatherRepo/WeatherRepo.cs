using WeatherApp.Data;      
using WeatherApp.DTOs.Weather;

namespace WeatherApp.Repos.WeatherRepo
{
    public class WeatherRepo:IWeatherRepo
    {
        private readonly ApplicationDbContext _context;

        public WeatherRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddWeather(WeatherRequestDto weatherDto)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == weatherDto.CityId);
            if (city == null)
            {
                throw new Exception($"City with ID {weatherDto.CityId} not found.");
            }

            var weather = new Entity.Weather
            {
                Temperature = weatherDto.Temperature,
                Humidity = weatherDto.Humidity,
                WindSpeed = weatherDto.WindSpeed,
                Condition = weatherDto.Condition,
                CityId = weatherDto.CityId 
            };

            _context.Weathers.Add(weather);
            _context.SaveChanges();
        


        }

        public WeatherResponseDto GetWeatherByCityId(int cityId)
        {
            var weather = _context.Weathers
                .Where(w => w.CityId == cityId)
                .Select(w => new WeatherResponseDto
                {
                    Id = w.Id,
                    Temperature = w.Temperature,
                    Humidity = w.Humidity,
                    WindSpeed = w.WindSpeed,
                    Condition = w.Condition
                })
                .FirstOrDefault();

            return weather;
        }

        public void UpdateWeather(int id, WeatherRequestDto weatherDto)
        {
            var weather = _context.Weathers.FirstOrDefault(w => w.Id == id);
            var city = _context.Cities.FirstOrDefault(c => c.Id == weatherDto.CityId);
            if (city == null) {
                throw new Exception($"{id}");
            }
            if (weather == null)
            {
                throw new Exception($" ID {id} not found.");
            }

            weather.Temperature = weatherDto.Temperature;
            weather.Humidity = weatherDto.Humidity;
            weather.WindSpeed = weatherDto.WindSpeed;
            weather.Condition = weatherDto.Condition;
            

            _context.Weathers.Update(weather);
            _context.SaveChanges();
        }
    }
}
