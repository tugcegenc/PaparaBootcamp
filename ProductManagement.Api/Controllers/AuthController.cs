using Microsoft.AspNetCore.Mvc;
using ProductManagement.Api.Auth;
using ProductManagement.Api.Models;

namespace ProductManagement.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {
        var authenticatedUser = FakeAuthService.Authenticate(user.Username, user.Password);
        if (authenticatedUser == null)
            return Unauthorized(new { message = "Invalid username or password" });

        return Ok(new { message = "Login successful", userId = authenticatedUser.Id });
    }
}