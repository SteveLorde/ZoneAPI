using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Zone.Data.DTOs;
using Zone.Data.DTOs.Requests;
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
        await Clients.All.SendAsync("connected", "SignalR Backend saying Hello :)");
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


    public async Task<Guid> CreateZone(NewZoneRequestDTO newZoneRequest)
    {
        //1-check if zone exists
       // bool checkZoneExists = await _zoneService.CheckZoneExists(newZoneRequest);
        //2-create zone in database
        Guid createdZoneId = await _zoneService.CreateZone(newZoneRequest);
        if (createdZoneId != Guid.Empty)
        {
            return createdZoneId;
        }
    }

    public async Task JoinZone(string zoneId, string userId)
    {
        Guid userGuid = Guid.Parse(userId);
        Guid zoneGuid = Guid.Parse(zoneId);
        //get zone
        var zone = await _zoneService.GetZone(zoneGuid);
        if (zone.Id == Guid.Parse(zoneId))
        {
            //add user to zone in database
            await _zoneService.AddUserToZone(userGuid, zoneGuid);
            await Groups.AddToGroupAsync(Context.ConnectionId, zone.Id.ToString());
            await Clients.Group(zone.Id.ToString()).SendAsync("JoinedZone", $"User {Context.ConnectionId} joined Zone {zone.Id.ToString()}");
        }
        else
        {
            return;
        }
    }
    
    
    
    
}