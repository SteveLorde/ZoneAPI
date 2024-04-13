using Microsoft.AspNetCore.Mvc;

namespace Zone.API.Controllers;

public class AuthenticationController : Controller
{
    [HttpPost("Login")]
    [Produces("application/json")]
    public async Task<string?> Login(LoginRequestDTO loginrequest)
    {
        return await _auth.Login(loginrequest);
    }
}