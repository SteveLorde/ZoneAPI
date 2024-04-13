using Xunit.Abstractions;
using Microsoft.AspNetCore.SignalR.Client;
using Xunit.Sdk;
using static Zone.Test.Variables;

namespace Zone.Test.ChatTest;

public class ChatTest
{
    private HttpClient _httpClient = new HttpClient();
    private ITestOutputHelper _outputHelper = new TestOutputHelper();
    private static string _connectionUrl = testURL;
    private static HubConnectionBuilder _hubConnectionBuilder = new HubConnectionBuilder();
    private HubConnection _hubConnection = _hubConnectionBuilder.WithUrl(_connectionUrl).Build();

    
    [Fact]
    public async void ConnectTest()
    {
        await _hubConnection.StartAsync();
        _hubConnection.On<string>("connect", message =>
        {
            _outputHelper.WriteLine(message);
        });
    }
    
    [Fact]
    public async void JoinLobbyTest()
    {
        await _hubConnection.InvokeAsync("JoinZone", "12344");
        _hubConnection.On<string>("JoinedZone", message => _outputHelper.WriteLine(message));
    }
    
    [Fact]
    public async void SendMessageTest()
    {
        await _hubConnection.InvokeAsync("SendMessage", "testing");
        _hubConnection.On<string>("ReceivedMessage", message => _outputHelper.WriteLine(message));
    }
    
    
}