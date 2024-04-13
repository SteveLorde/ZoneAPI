
using Zone.Data.Data.DTOs.Responses;
using Zone.Data.Data.Models;

namespace Zone.Services.Services.Repositories.ZoneRepo;

public interface IZoneRepo
{
    public Task<List<ZoneResponseDTO>> GetZones();
    public Task<ZoneResponseDTO> GetZone(Guid zoneId);
    public Task<Data.Data.Models.ZoneLobby> GetZoneDirectly(Guid zoneId);
    public Task<bool> AddZone(ZoneLobby newZoneLobby);
    public Task<bool> UpdateZone(ZoneLobby updatedZoneLobby);
    public Task<bool> RemoveZone(ZoneLobby zoneLobbyToRemove);

}