using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITBoostUp.Presentation.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
         
            Console.WriteLine(context.Exception);
            context.Result = new RedirectToActionResult("Index", "Error", null);
           
        }
    }
}
