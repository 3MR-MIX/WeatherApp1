using System.ComponentModel.DataAnnotations;
using WeatherApp.DTOs.City;

namespace WeatherApp.DTOs.Weather
{
    public class WeatherRequestDto
    {
        [Required]
        public float Temperature { get; set; }

        [Required]
        public int Humidity { get; set; }

        [Required]
        public float WindSpeed { get; set; }

        [Required]
        public string Condition { get; set; }
        [Required]
        public int CityId { get; set; }


    }
}
