using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Zone.Services.Services.Cookie;

sealed class CookieService : ICookieService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void CreateCookie(string userId,string token)
    {
        var options = new CookieOptions
        {
            Expires = new DateTimeOffset(DateTime.Parse("2")),
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict
        };
        string cookieName = "ZoneAppCookie";
        var cookieValues = new 
        {
            userId = userId,
            token = token,
        };
        _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, JsonSerializer.Serialize(cookieValues), options);
    }

    public string GetCookie(string cookieName)
    {
        return _httpContextAccessor.HttpContext.Request.Cookies[cookieName];
    }

    public void RemoveCookie(string cookieName)
    {
        _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookieName);
    }
}