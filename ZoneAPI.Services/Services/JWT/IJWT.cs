using Zone.Services.Services.JWT.DTO;

namespace Zone.Services.Services.JWT;

public interface IJWT
{
    public string CreateToken(JWTRequestDTO userjwtreq);
}