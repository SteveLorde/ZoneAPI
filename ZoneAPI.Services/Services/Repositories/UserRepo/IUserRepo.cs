using Zone.Data.Data.DTOs;
using Zone.Data.Data.Models;
using Zone.Services.Services.Authentication.DTO;

namespace Zone.Services.Services.Repositories.UserRepo;

public interface IUserRepo
{
    public Task<List<User>> GetUsers();
    public Task<User> GetUser(string userId);
    public Task<bool> CheckUserExists(string userName);
    public Task<UserToLoginDataDTO> GetHashedpassword(string userName);
    public Task<bool> AddUser(UserDTO newUserDTO, string hashedPassword);
    public Task RemoveUser(string userId);
}