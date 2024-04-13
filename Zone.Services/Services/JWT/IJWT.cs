using Zone.Data.Data.DTOs;

namespace Zone.Services.Services.JWT;

public interface IJWT
{
    public string CreateToken(JWTRequestDTO userjwtreq);
}