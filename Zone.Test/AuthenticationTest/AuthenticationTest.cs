using Xunit.Abstractions;
using Xunit.Sdk;

namespace Zone.Test.AuthenticationTest;

public class AuthenticationTest
{
    private HttpClient _httpClient = new HttpClient();
    private ITestOutputHelper _outputHelper = new TestOutputHelper();


    [Theory]
    [InlineData]
    public async void LoginTest()
    {
        
    }
    
    [Theory]
    [InlineData]
    public async void RegisterTest()
    {
        
    }
    
    
}