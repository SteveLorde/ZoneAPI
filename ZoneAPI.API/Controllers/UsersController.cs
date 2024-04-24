using Microsoft.AspNetCore.Mvc;
using Zone.Data.Models;
using Zone.Services.Services.Repositories.UserRepo;

namespace Zone.API.Controllers;

[ApiController]
[Route("users")]
public class UsersController
{
    private readonly IUserRepo _userRepo;

    public UsersController(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }
    
    [HttpGet("getusers")]
    public async Task<List<User>> GetUsers()
    {
        return await _userRepo.GetUsers();
    }
    
    [HttpGet("getuser/{userId}")]
    public async Task<User> GetUser(string userId)
    {
        return await _userRepo.GetUser(Guid.Parse(userId));
    }
    
    
}