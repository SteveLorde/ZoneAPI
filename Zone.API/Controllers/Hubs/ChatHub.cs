using Microsoft.AspNetCore.SignalR;
using Zone.Data.Data.DTOs;

namespace Zone.API.Controllers.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(MessageDTO newMessageDto) => await Clients.All.SendAsync("ReceiveMessage", newMessageDto);
}