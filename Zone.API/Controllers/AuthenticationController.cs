using Microsoft.AspNetCore.Mvc;
using Zone.Data.Data.DTOs;
using Zone.Services.Services.Authentication;

namespace Zone.API.Controllers;

[ApiController]
[Route("authentication")]
public class AuthenticationController : Controller
{
    private readonly IAuthentication _authService;

    public AuthenticationController(IAuthentication authService)
    {
        _authService = authService;
    }
    
    [HttpPost("login")]
    [Produces("application/json")]
    public async Task<string> Login(AuthRequestDTO loginRequest)
    {
        return await _authService.Login(loginRequest);
    }
    
    [HttpPost("register")]
    [Produces("application/json")]
    public async Task<bool> Register(AuthRequestDTO registerRequest)
    {
        return await _authService.Register(registerRequest);
    }
    
    
    
    
}