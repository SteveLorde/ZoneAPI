using Microsoft.Extensions.DependencyInjection;
using Zone.Data.Data;
using Zone.Services.Services.Authentication;
using Zone.Services.Services.AutoMapping;
using Zone.Services.Services.JWT;
using Zone.Services.Services.PasswordHash;
using Zone.Services.Services.Repositories.UserRepo;
using Zone.Services.Services.Zone;

namespace Zone.Services.Services;

public static class ServicesRegister
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<DataContext>();
        serviceCollection.AddScoped<IJWT, JWT.JWT>();
        serviceCollection.AddScoped<IAuthentication, Authentication.Authentication>();
        serviceCollection.AddScoped<IPasswordHash,PasswordHash.PasswordHash>();
        serviceCollection.AddScoped<IZoneService, >();
        serviceCollection.AddScoped<IUserRepo, UserRepo>();
        serviceCollection.AddAutoMapper(typeof(AutoMappingProfile));
        
    }
}