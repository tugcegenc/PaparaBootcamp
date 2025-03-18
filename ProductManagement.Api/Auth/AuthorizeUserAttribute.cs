using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductManagement.Api.Auth;

namespace ProductManagement.Api.Auth;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class AuthorizeUserAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var username = context.HttpContext.Request.Headers["Username"].FirstOrDefault();
        var password = context.HttpContext.Request.Headers["Password"].FirstOrDefault();

        if (username == null || password == null || FakeAuthService.Authenticate(username, password) == null)
        {
            context.Result = new UnauthorizedObjectResult(new { message = "Unauthorized: Invalid credentials" });
        }
    }
}