using System.ComponentModel.DataAnnotations;

namespace WeatherApp.DTOs.City
{
    public class CityRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
