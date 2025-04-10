using WeatherApp.DTOs.Weather;

namespace WeatherApp.Repos.WeatherRepo
{
    public interface IWeatherRepo
    {
        WeatherResponseDto GetWeatherByCityId(int cityId);
        void AddWeather(WeatherRequestDto weatherDto);
        void UpdateWeather(int id, WeatherRequestDto weatherDto);
    }
}
