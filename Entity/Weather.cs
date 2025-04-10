using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Entity
{
    public class Weather
    {
        public int Id { get; set; } 
        public int CityId { get; set; }
        [Required]
        public float Temperature { get; set; }
        [Required]
        public int Humidity { get; set; } 
        [Required]
        public float WindSpeed { get; set; }
        [Required]
        public string? Condition { get; set; }
        public City? City { get; set; }
    }
}
