using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Parameter
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult GetList()
        {
            List<Country> countries = countryRepository.GetList();
            return Ok(countries);
        }
    }
}