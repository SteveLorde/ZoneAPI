namespace Zone.API.Controllers.Hubs.ChatHub;

public interface IChatHub
{
    public Task SendMessage();
    public Task JoinZone();
    public Task LeaveZone();
    
}