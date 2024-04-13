using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Zone.Data.Data.DTOs;
using Zone.Services.Services.Zone;

namespace Zone.API.Controllers.Hubs.ChatHub;

[Authorize]
public class ChatHub : Hub
{
    private readonly IZoneService _zoneService;

    public ChatHub(IZoneService zoneService)
    {
        _zoneService = zoneService;
    }
    
    public async Task SendMessage(MessageDTO newMessageDto)
    {
        await Clients.Group(newMessageDto.ZoneId.ToString()).SendAsync("ReceiveMessage", newMessageDto);
    } 

    public async Task JoinZone(string zoneId)
    {
        var zone = await _zoneService.GetZone(Guid.Parse(zoneId));
        await Groups.AddToGroupAsync(Context.ConnectionId, zone.Id.ToString());
    }
    
    
}