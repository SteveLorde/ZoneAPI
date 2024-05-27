namespace Zone.Services.Services.Cookie;

public interface ICookieService
{
    public void CreateCookie(string userId,string token);
    public string GetCookie(string cookieName);
    public void RemoveCookie(string cookieName);
}