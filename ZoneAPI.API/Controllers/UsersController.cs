using Microsoft.AspNetCore.Mvc;
using Zone.Data.DTOs.Responses;
using Zone.Data.Models;
using Zone.Services.Services.Repositories.UserRepo;

namespace Zone.API.Controllers;

[Route("users")]
public class UsersController : BaseController
{
    private readonly IUserRepo _userRepo;

    public UsersController(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }
    
    [HttpGet("getusers")]
    public async Task<List<UserResponseDTO>> GetUsers()
    {
        return await _userRepo.GetUsers();
    }
    
    [HttpGet("getuser/{userId}")]
    public async Task<UserResponseDTO> GetUser(string userId)
    {
        return await _userRepo.GetUser(Guid.Parse(userId));
    }
    
    
}