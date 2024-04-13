
using Zone.Data.Data.DTOs.Responses;

namespace Zone.Services.Services.Repositories.ZoneRepo;

public interface IZoneRepo
{
    public Task<List<ZoneResponseDTO>> GetZones();
    public Task<ZoneResponseDTO> GetZone(Guid zoneId);
    public Task<Data.Data.Models.ZoneLobby> GetZoneDirectly(Guid zoneId);
    public Task<bool> AddZone(Data.Data.Models.ZoneLobby newZoneLobbyDto);
    public Task<bool> UpdateZone(Data.Data.Models.ZoneLobby updatedZoneLobby);
    public Task<bool> RemoveZone(Data.Data.Models.ZoneLobby zoneLobbyToRemove);

}