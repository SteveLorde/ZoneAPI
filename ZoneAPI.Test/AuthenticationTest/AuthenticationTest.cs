using System.Net.Http.Json;
using System.Text;
using Xunit.Abstractions;
using Xunit.Sdk;
using Zone.Data.DTOs.Requests;
using static Zone.Test.Variables;

namespace Zone.Test.AuthenticationTest;

public class AuthenticationTest
{
    private HttpClient _httpClient = new HttpClient();
    private string _connectionURL = testURL;
    private ITestOutputHelper _outputHelper = new TestOutputHelper();


    [Fact]
    public async void LoginTest()
    {
        string loginUrl = $"{_connectionURL}/authentication/login";
        AuthRequestDTO newRequest = new AuthRequestDTO() {UserName = "testuser", Password = "1234"};
        HttpContent content = new StringContent(newRequest.ToString(), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(loginUrl, content);
        _outputHelper.WriteLine(response.Content.ToString());
    }
    
    [Fact]
    public async void RegisterTest()
    {
        string registerURL = $"{_connectionURL}/authentication/register";
        AuthRequestDTO newRequest = new AuthRequestDTO() {UserName = "testuser", Password = "1234", Email = "test@gmail.com"};
        HttpContent content = new StringContent(newRequest.ToString(), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(registerURL, content);
        _outputHelper.WriteLine(response.Content.ToString());
    }
    
    
}