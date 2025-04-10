using WeatherApp.DTOs.City;

namespace WeatherApp.Repos.CityRepo
{
    public interface ICityRepo
    {
        public List<CityResponseDto> GetAllCities();
        public CityResponseDto GetCityById(int id);
        public void AddCity(CityRequestDto cityRequestDto);


    }
}
