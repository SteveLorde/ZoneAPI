using Microsoft.EntityFrameworkCore;
using Zone.Data.Data;

namespace Zone.Services.Services.Repositories.ZoneRepo;

public class ZoneRepo : IZoneRepo
{
    private readonly DataContext _db;

    public ZoneRepo(DataContext db)
    {
        _db = db;
    }
    
    public async Task<List<Data.Data.Models.Zone>> GetZones()
    {
        return await _db.Zones.ToListAsync();
    }

    public async Task<Data.Data.Models.Zone> GetZone(Guid zoneId)
    {
        return await _db.Zones.FirstAsync(zone => zone.Id == zoneId);
    }

    public async Task<bool> AddZone(Data.Data.Models.Zone newZone)
    { 
        await _db.Zones.AddAsync(newZone);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateZone(Data.Data.Models.Zone updatedZone)
    {
        _db.Update(updatedZone);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveZone(Data.Data.Models.Zone zoneToRemove)
    {
        _db.Zones.Remove(zoneToRemove);
        await _db.SaveChangesAsync();
        return true;
    }
}