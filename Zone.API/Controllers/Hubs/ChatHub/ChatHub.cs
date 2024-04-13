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
    
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("connect", "SignalR Backend saying Hello :)");
        await base.OnConnectedAsync();
    }
    
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
    }
    
    public async Task SendMessage(MessageDTO newMessageDto)
    {
        await Clients.Group(newMessageDto.ZoneId.ToString()).SendAsync("ReceiveMessage", newMessageDto);
    } 

    public async Task JoinZone(string zoneId)
    {
        var zone = await _zoneService.GetZone(Guid.Parse(zoneId));
        await Groups.AddToGroupAsync(Context.ConnectionId, zone.Id.ToString());
        await Clients.Group(zone.Id.ToString()).SendAsync("JoinedLobby", true);
    }
    
    
    
    
}