using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Zone.Data.DTOs;
using Zone.Data.DTOs.Requests;
using Zone.Services.Services.Zone;

namespace Zone.API.Controllers.Hubs.ChatHub;

public class ChatHub : BaseHub
{
    private readonly IZoneService _zoneService;

    public ChatHub(IZoneService zoneService)
    {
        _zoneService = zoneService;
    }
    
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.SendAsync("connected", "SignalR Backend saying Hello :)");
    }
    
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
    }
    
    public async Task SendMessage(MessageDTO newMessageDto)
    {
        await Clients.Group(newMessageDto.ZoneId.ToString()).SendAsync("ReceiveMessage", newMessageDto);
    }

    public async Task CheckZoneExists(string zoneId)
    {
        bool checkZoneExists = await _zoneService.CheckZoneExists(Guid.Parse(zoneId));
        await Clients.Caller.SendAsync("CheckZoneExists", checkZoneExists);
    }
    
    public async Task CreateZone(NewZoneRequestDTO newZoneRequest)
    {
        Guid createdZoneId = await _zoneService.CreateZone(newZoneRequest);
        await Clients.Caller.SendAsync("ZoneCreated", createdZoneId);
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