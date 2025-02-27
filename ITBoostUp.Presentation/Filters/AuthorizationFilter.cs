using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITBoostUp.Presentation.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.Result == null)
            {
                context.Result = new RedirectToActionResult("Authorization", "Home", null);
            }
        }
    }
}
