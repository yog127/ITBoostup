using ITBoostUp.BusinessLayer.IRepository;
using ITBoostUp.BusinessLayer.Model;
using ITBoostUp.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ITBoostUp.Presentation.Controllers
{
    public class CountryController : Controller
    {
        ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        //[ServiceFilter(typeof(ActionFilter))]
        public IActionResult Country(int id = 0)
        {
            int a = 1;
            int b = 0;
            int c = a / b;
            var countries = _countryRepository.List();

            if(id == 1){
                countries = countries.Where(x => x.IsActive).ToList();
            }
            if (id == 2)
            {
                countries = countries.Where(x => !(x.IsActive)).ToList();
            }
            return View(countries);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Country country)
        {
            _countryRepository.Create(country);
            return RedirectToAction("Country");
        }
        public IActionResult Delete(int id)
        {
            _countryRepository.Delete(id);
            return RedirectToAction("Country");          
        }
        public IActionResult GetById(int id)
        {
            var country= _countryRepository.GetElementById(id);
            return View(country);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var country = _countryRepository.GetElementById(id);
            return View(country);
        }
        [HttpPost]
        public IActionResult Update(Country country)
        {
            _countryRepository.Update(country);
            return RedirectToAction("Country");
        }

    }
}
