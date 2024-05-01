using Microsoft.AspNetCore.Mvc;
using Zone.Data.DTOs.Requests;
using Zone.Services.Services.Authentication;

namespace Zone.API.Controllers;

[Route("authentication")]
public class AuthenticationController : BaseController
{
    private readonly IAuthentication _authService;

    public AuthenticationController(IAuthentication authService)
    {
        _authService = authService;
    }
    
    [HttpPost("login")]
    [Produces("application/json")]
    public async Task<string> Login(LoginRequestDTO loginRequest)
    {
        return await _authService.Login(loginRequest);
    }
    
    [HttpPost("register")]
    public async Task<bool> Register(RegisterRequestDTO registerRequest)
    {
        return await _authService.Register(registerRequest);
    }
    
    
    
    
}