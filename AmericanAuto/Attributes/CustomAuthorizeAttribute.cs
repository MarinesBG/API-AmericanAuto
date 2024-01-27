using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AmericanAuto.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check if the Authorization header is present
            var hasAuthHeader = context.HttpContext.Request.Headers.ContainsKey("Authorization");
            if (!hasAuthHeader)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Check if the user is authenticated
            var isAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                // At this stage, it means the JWT token validation failed
                context.Result = new UnauthorizedResult();
                return;
            }

            // Perform additional custom authorization checks here if needed

            // If the code execution gets this far without setting context.Result,
            // then the user passed all authentication and authorization checks
        }
    }
}