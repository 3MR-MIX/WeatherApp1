using System.ComponentModel.DataAnnotations;

namespace WeatherApp.DTOs.Forecast
{
    public class ForecastForCityDto
    {
        public DateTime Date { get; set; }

        public float Temperature { get; set; }

        public string Condition { get; set; }
    }
}
