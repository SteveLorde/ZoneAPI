using Zone.Data.Data;
using Zone.Services.Services.Authentication;
using Zone.Services.Services.AutoMapping;
using Zone.Services.Services.JWT;
using Zone.Services.Services.PasswordHash;

namespace Zone.API;

public static class ServicesRegister
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<DataContext>();
        serviceCollection.AddScoped<IJWT, JWT>();
        serviceCollection.AddScoped<IAuthentication,Authentication>();
        serviceCollection.AddScoped<IPasswordHash,PasswordHash>();
        serviceCollection.AddAutoMapper(typeof(AutoMappingProfile));
        
    }
}