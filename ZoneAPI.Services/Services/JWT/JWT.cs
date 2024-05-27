using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Zone.Services.Services.JWT.DTO;

namespace Zone.Services.Services.JWT;

sealed class JWT : IJWT
{
    private IConfiguration _config;

    private string? jwtseckey;
    private string? audienceClientURL;
    private string baseUrl;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public JWT(IConfiguration config, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _config = config;
        jwtseckey = _config["secretkey"];
        baseUrl = "";
        audienceClientURL = _config["audienceURL"];
    }

    public string CreateToken(JWTRequestDTO userjwtreq)
    {
        baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}";
        List<Claim> claims = new List<Claim>
        {
            new Claim("userid", userjwtreq.Id.ToString()),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtseckey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var tokendata = new JwtSecurityToken(
            claims: claims,
            issuer: baseUrl,
            audience: audienceClientURL,
            expires: DateTime.Now.AddDays(2),
            signingCredentials: cred
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(tokendata);
        return jwt;
    }
}