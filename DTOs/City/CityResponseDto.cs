using System.ComponentModel.DataAnnotations;
using WeatherApp.DTOs.Forecast;
using WeatherApp.DTOs.Weather;

namespace WeatherApp.DTOs.City
{
    public class CityResponseDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        public WeatherRequestDto? WeatherDto { get; set; }
        public List<ForecastForCityDto> ?ForecastsDto { get; set; }
    }
}
