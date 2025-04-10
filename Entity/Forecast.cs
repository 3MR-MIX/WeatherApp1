namespace WeatherApp.Entity
{
    public class Forecast
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; } 
        public float Temperature { get; set; } 
        public string? Condition { get; set; }

        public int CityId { get; set; }
        public City? City { get; set; }
    }
}
