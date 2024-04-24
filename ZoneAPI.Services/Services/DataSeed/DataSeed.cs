using Zone.Data;
using Zone.Data.Models;
using Zone.Services.Services.PasswordHash;

namespace Zone.Services.Services.DataSeed;

public class DataSeed : IDataSeed
{
    private readonly DataContext _db;
    private readonly IPasswordHash _passwordHashService;

    public DataSeed(DataContext db, IPasswordHash passwordHashService)
    {
        _db = db;
        _passwordHashService = passwordHashService;
    }

    public async void SeedData()
    {
        List<User> usersToSeed =
        [
            new User { Id = Guid.Parse("2e3ff341-ef97-459b-8d19-7e02f2b05f1a"), UserName = "testuser", CreatedZones = [], JoinedZones = [], HashedPassword = "", JoinedOn = DateTime.Parse("") }
        ];

        await _db.Users.AddRangeAsync(usersToSeed);
        List<ZoneLobby> zonesToSeed =
        [
            new ZoneLobby {Id = Guid.Parse("789af297-0a66-4b7f-9be1-3d5a451aec53"), JoinedUsers = [], UserOwner = {}, UserOwnerId = Guid.Parse("2e3ff341-ef97-459b-8d19-7e02f2b05f1a"), Title = "Test Zone", Notes = []}
        ];

        List<UsersInZones> usersInZones =
        [
            new UsersInZones {}
        ];

        await _db.UsersInZones.AddRangeAsync(usersInZones);
        await _db.Zones.AddRangeAsync(zonesToSeed);
        await _db.SaveChangesAsync();
    }
    
}