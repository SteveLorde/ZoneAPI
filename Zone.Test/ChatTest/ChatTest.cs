using Xunit.Abstractions;
using Microsoft.AspNetCore.SignalR.Client;
using Xunit.Sdk;
using static Zone.Test.Variables;

namespace Zone.Test.ChatTest;

public class ChatTest
{
    private HttpClient _httpClient = new HttpClient();
    private ITestOutputHelper _outputHelper = new TestOutputHelper();
    private HubConnectionBuilder _hubConnectionBuilder = new HubConnectionBuilder();
    private string connectionURL = testURL;
    
    [Fact]
    public async void ConnectTest()
    {
        HubConnection hubConnection = _hubConnectionBuilder.WithUrl(connectionURL).Build();
        await hubConnection.StartAsync();
        hubConnection.On<string>("connect", message =>
        {
            _outputHelper.WriteLine(message);
        });
    }
    
    [Fact]
    public async void JoinLobbyTest()
    {
        
    }
    
    [Fact]
    public async void SendMessageTest()
    {
        
    }
    
    
}