using Microsoft.AspNetCore.Mvc;

namespace ITBoostUp.Presentation.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
