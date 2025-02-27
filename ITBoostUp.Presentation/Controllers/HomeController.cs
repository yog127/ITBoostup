
using ITBoostUp.BusinessLayer.Model;
using ITBoostUp.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITBoostUp.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Index()
        {
            //int a = 1;
            //int b = 0;
            //int c = a / b;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ServiceFilter(typeof(ResultFilter))]
        public IActionResult Test()
        {
            List<Company> list = new List<Company>();

            list.Add(new Company { Id = 1, Name = "TCS", Address = "Pune" });
            return Json(list);
        }
        public IActionResult Authorization()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

    }
}
