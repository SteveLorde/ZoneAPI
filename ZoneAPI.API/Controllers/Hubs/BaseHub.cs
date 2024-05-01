using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

namespace Zone.API.Controllers.Hubs;

[Authorize]
[EnableCors]
public class BaseHub : Hub
{
    
}