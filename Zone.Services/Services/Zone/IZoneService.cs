using Zone.Data.Data.DTOs;
using Zone.Data.Data.DTOs.Requests;
using Zone.Data.Data.DTOs.Responses;

namespace Zone.Services.Services.Zone;

public interface IZoneService
{
    public Task<List<ZoneResponseDTO>> GetZones();
    public Task<ZoneResponseDTO> GetZone(Guid zoneId);
    public Task<bool> CreateZone(NewZoneRequestDTO newZoneRequest);
    public Task AddUserToZone(Guid userId, Guid zoneId);
    public Task RemoveUserFromZone(Guid userId, Guid zoneId);
    public Task DeleteZone(Guid zoneId);
}