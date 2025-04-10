using WeatherApp.DTOs.Forecast;

namespace WeatherApp.Repos.ForecastRepo
{
    public interface IForecastRepo
    {
        List<ForecastResponseDto> GetForecastsByCityId(int cityId);
        void AddForecast(ForecastRequestDto forecastDto);
        void DeleteForecast(int id);
    }
}
