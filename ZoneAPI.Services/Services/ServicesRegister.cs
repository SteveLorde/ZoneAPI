using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zone.Data;
using Zone.Services.Services.Authentication;
using Zone.Services.Services.AutoMapping;
using Zone.Services.Services.DataSeed;
using Zone.Services.Services.JWT;
using Zone.Services.Services.PasswordHash;
using Zone.Services.Services.Repositories.NotesRepo;
using Zone.Services.Services.Repositories.UserRepo;
using Zone.Services.Services.Repositories.ZoneRepo;
using Zone.Services.Services.Zone;

namespace Zone.Services.Services;

public static class ServicesRegister
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<DataContext>();
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddScoped<IJWT, JWT.JWT>();
        serviceCollection.AddScoped<IAuthentication, Authentication.Authentication>();
        serviceCollection.AddScoped<IPasswordHash,PasswordHash.PasswordHash>();
        serviceCollection.AddScoped<IZoneService, ZoneService >();
        serviceCollection.AddScoped<IUserRepo, UserRepo>();
        serviceCollection.AddScoped<INotesRepo, NotesRepo>();
        serviceCollection.AddScoped<IZoneRepo, ZoneRepo>();
        serviceCollection.AddScoped<IDataSeed, DataSeed.DataSeed>();
        serviceCollection.AddAutoMapper(typeof(AutoMappingProfile));
    }

    public static void RunServices(this IServiceCollection serviceCollection)
    {
        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        serviceProvider.GetService<DataContext>()?.Database.Migrate();
        serviceProvider.GetService<IDataSeed>()?.SeedData();
    }
}