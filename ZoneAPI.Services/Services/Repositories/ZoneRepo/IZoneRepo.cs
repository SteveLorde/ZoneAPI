using Zone.Data.Data.DTOs;
using Zone.Data.Data.DTOs.Requests;

namespace Zone.Services.Services.Repositories.ZoneRepo;

public interface IZoneRepo
{
    public Task<List<Data.Data.Models.Zone>> GetZones();
    public Task<Data.Data.Models.Zone> GetZone(Guid zoneId);
    public Task<bool> AddZone(Data.Data.Models.Zone newZoneDto);
    public Task<bool> UpdateZone(Data.Data.Models.Zone updatedZone);
    public Task<bool> RemoveZone(Data.Data.Models.Zone zoneToRemove);

}