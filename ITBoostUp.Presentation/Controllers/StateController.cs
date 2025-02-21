using ITBoostUp.BusinessLayer.IRepository;
using ITBoostUp.BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ITBoostUp.Presentation.Controllers
{
    public class StateController : Controller
    {
        IStateRepository _stateRepository;
        ICountryRepository _countryRepository;
        public StateController(IStateRepository stateRepository, ICountryRepository countryRepository)
        {
            _stateRepository  = stateRepository;
            _countryRepository = countryRepository;
        }

        public IActionResult State(int id = 0)
        {
            var statesList = _stateRepository.List();

            if (id == 1)
            {
                statesList = statesList.Where(x => x.IsActive).ToList();
            }
            if (id == 2)
            {
                statesList = statesList.Where(x => !(x.IsActive)).ToList();
            }
            ViewData["Countries"] = _countryRepository.List();
            return View(statesList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(State state)
        {
            _stateRepository.Create(state);
            return RedirectToAction("State");
        }
        public IActionResult GetById(int id) 
        {
            var state = _stateRepository.GetElementById(id);
            return View(state);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var state = _stateRepository.GetElementById(id);
            return View(state);
        }
        [HttpPost]
        public IActionResult Update(State state)
        {
            _stateRepository.Update(state);
            return RedirectToAction("State");
        }
        public IActionResult Delete(int id)
        {
            _stateRepository.Delete(id);
            return RedirectToAction("State");
        }
        public IActionResult CountryOption()
        {
            return View();
        }

    }
}
