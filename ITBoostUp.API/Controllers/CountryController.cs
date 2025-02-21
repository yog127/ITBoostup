using ITBoostUp.API.Mapping;
using ITBoostUp.API.Response;
using ITBoostUp.BusinessLayer.IRepository;
using ITBoostUp.BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITBoostUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet("list")]
        public IActionResult CountryList()
        {
            var countryData = _countryRepository.List();
            if (countryData == null)
            {
                return BadRequest("Not Available List");
            }
            return Ok(countryData);
        }
        [HttpPost("create")]
        public IActionResult Create(Country country)
        {
            var result = _countryRepository.Create(country);
            if (result == -1)
            {
                return Ok(result);
            }
            return BadRequest("Country Not Created");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _countryRepository.GetElementById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Id Not Found");
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(Country country)
        {
            var result = _countryRepository.Update(country);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Not Updated");
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromBody] int id)
        {
            if (id == -1)
            {
                _countryRepository.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest("Not Found");
            }
        }
        [HttpGet("dropdownitem")]
        public IActionResult Dropdownlist()
        {
            var countries = _countryRepository.List();
            var dropdownlist = countries.Select(country =>
            {
                var response = new CountryResponse();
                response.MapCountryDropDown(country);
                return response;
            }).ToList();
            return Ok(dropdownlist);   
        }

    }
}
