using Microsoft.AspNetCore.Mvc.Filters;

namespace ITBoostUp.Presentation.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action Executing Called");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action Executed Called");
        }
    }
}
