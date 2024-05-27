namespace Zone.API.Middleware;

public class CookieMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public CookieMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeCookie(HttpContext httpContext)
    {
        if (httpContext.Request.Cookies.ContainsKey("ZoneClientCookie"))
        {
            //read cookie
        }

        await _requestDelegate(httpContext);
    }
        
}