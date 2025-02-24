using ITBoostUp.BusinessLayer.IRepository;
using ITBoostUp.BusinessLayer.Model;
using ITBoostUp.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ITBoostUp.Presentation.Controllers
{
    //[ServiceFilter(typeof(ActionFilter))]
    
    public class CompanyController : Controller
    {
        ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        [ServiceFilter(typeof(ExceptionFilter))]
        public IActionResult Company()
        {
            
                int a = 1;
                int b = 0;
                int c = a / b;
           
            var companies = _companyRepository.List();
            return View(companies);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            _companyRepository.Create(company);
            return RedirectToAction("Company");
        }
        public IActionResult GetById(int id)
        {
            var company = _companyRepository.GetElementById(id);
            return View(company);
        }
        public IActionResult Delete(int id)
        {
            _companyRepository.Delete(id);
            return RedirectToAction("Company");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var company = _companyRepository.GetElementById(id);
            return View(company);
        }
        [HttpPost]
        public IActionResult Update(Company company)
        {
            _companyRepository.Update(company);
            return RedirectToAction("Company");
        }
    }
}
