using Microsoft.EntityFrameworkCore;
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

    public async Task SeedData()
    {
        if (!_db.Users.Any() && !_db.Zones.Any() && !_db.UsersInZones.Any())
        {
            List<User> usersToSeed =
            [
                new User { Id = Guid.Parse("2e3ff341-ef97-459b-8d19-7e02f2b05f1a"), UserName = "testuser", HashedPassword = _passwordHashService.CreateHashedPassword("1234"), JoinedOn = DateTime.Today.ToString() }
            ];
            List<ZoneLobby> zonesToSeed =
            [
                new ZoneLobby {Id = Guid.Parse("789af297-0a66-4b7f-9be1-3d5a451aec53"), UserOwnerId = Guid.Parse("2e3ff341-ef97-459b-8d19-7e02f2b05f1a"), Title = "Test Zone"}
            ];
            List<UsersInZones> usersInZones =
            [
                new UsersInZones {ZoneLobbyId = Guid.Parse("789af297-0a66-4b7f-9be1-3d5a451aec53"), UserId = Guid.Parse("2e3ff341-ef97-459b-8d19-7e02f2b05f1a")}
            ];
            
            await _db.Users.AddRangeAsync(usersToSeed);
            await _db.Zones.AddRangeAsync(zonesToSeed);
            await _db.UsersInZones.AddRangeAsync(usersInZones);
            await _db.SaveChangesAsync();
        }
    }
    
}