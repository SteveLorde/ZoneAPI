using Microsoft.AspNetCore.Mvc;
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
    
    
}