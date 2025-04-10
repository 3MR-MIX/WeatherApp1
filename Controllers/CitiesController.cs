using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.DTOs.City;
using WeatherApp.Repos.CityRepo;

namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepo _cityRepo;

        public CitiesController(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }


        [HttpGet]
        public ActionResult<List<CityResponseDto>> GetCities()
        {
            var cities = _cityRepo.GetAllCities();
        
            return Ok(cities);
        }

        [HttpGet("city")]
        public ActionResult<CityResponseDto> GetCity(int id)
        {
            var city = _cityRepo.GetCityById(id);
            if (city == null)
            {
                return NotFound($"City with ID {id} not found.");
            }
            return Ok(city);
        }

        [HttpPost]
        public ActionResult AddCity([FromQuery] CityRequestDto cityRequestDto)
        {
            if (cityRequestDto == null)
            {
                return BadRequest("Invalid data.");
            }

            _cityRepo.AddCity(cityRequestDto);

            return Created();
        }
    }
}







