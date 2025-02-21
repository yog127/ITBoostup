using ITBoostUp.API.DTOs;
using ITBoostUp.API.Mapping;
using ITBoostUp.BusinessLayer.IRepository;
using ITBoostUp.BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITBoostUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet("list")]
        public IActionResult CompanyList()
        {
            var companyData = _companyRepository.List();
            if (companyData != null)
            {
                return Ok(companyData);
            }
            return BadRequest("Company Not Found !!!!");
        }
        [HttpPost("create")]
        public IActionResult Create(Company company)
        {
           var result = _companyRepository.Create(company);
            if (result == -1) 
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Not Created");
            }   
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Company Not Found");
            }
            var result = _companyRepository.GetElementById(id);
            return Ok(result);
        }
        [HttpPut("update/{id}")]

        public IActionResult UpdateCompany(Company company)
        {
            var result = _companyRepository.Update(company);
            if(result== -1)
            {
                return Ok("Record Update Successfully");
            }
            else
            {
                return BadRequest("Not Upadted");
            }                
        }
        //[HttpPut("updateCompany/{id}")]
        //public IActionResult UpdateCompany([FromRoute] int id,[FromBody] UpdateCompanyDto updateCompanyDto)
        //{
        //    Company company = _companyRepository.GetElementById(id);
        //    if(company != null || company.Id != 0)
        //    {
        //        company.MapCompanyDtoWithCompany(updateCompanyDto);
        //        var result = _companyRepository.Update(company);
        //        return Ok(result);
        //    }
        //    return BadRequest("Company Not Upadate");
        //}

        [HttpDelete("deleteCompany/{id}")]
        public IActionResult DeleteCompany([FromRoute] int id)
        {
            if(id == 0)
            {
                return BadRequest("Company Not Found");
            }
            _companyRepository.Delete(id);
            return Ok("Company Deleted");
        }
    }
}
