using Zone.Data.DTOs.Requests;

namespace Zone.Services.Services.Authentication;

public interface IAuthentication
{
    public Task<string> Login(AuthRequestDTO loginReq);
    public Task<bool> Register(AuthRequestDTO registerReq);
}