using Zone.Data.DTOs;
using Zone.Data.DTOs.Responses;
using Zone.Data.Models;
using Zone.Services.Services.Authentication.DTO;

namespace Zone.Services.Services.Repositories.UserRepo;

public interface IUserRepo
{
    public Task<List<UserResponseDTO>> GetUsers();
    public Task<UserResponseDTO> GetUser(Guid userId);
    public Task<User> GetUserDirectly(Guid userId);
    public Task<bool> CheckUserExists(string userName);
    public Task<UserToLoginDataDTO> GetHashedpassword(string userName);
    public Task<bool> AddUser(UserDTO newUserDTO, string hashedPassword);
    public Task CreateUsersFolders();
    public Task RemoveUser(string userId);
}