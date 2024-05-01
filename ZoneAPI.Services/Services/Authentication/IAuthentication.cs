using Zone.Data.DTOs.Requests;

namespace Zone.Services.Services.Authentication;

public interface IAuthentication
{
    public Task<string> Login(LoginRequestDTO loginReq);
    public Task<bool> Register(RegisterRequestDTO registerReq);
}