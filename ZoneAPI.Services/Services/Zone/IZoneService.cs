using Zone.Data.DTOs.Requests;
using Zone.Data.DTOs.Responses;

namespace Zone.Services.Services.Zone;

public interface IZoneService
{
    public Task<List<ZoneResponseDTO>> GetZones();
    //public Task<bool> CheckZoneExists(NewZoneRequestDTO newZoneRequest);
    public Task<ZoneResponseDTO> GetZone(Guid zoneId);
    public Task<Guid> CreateZone(NewZoneRequestDTO newZoneRequest);
    public Task<bool> AddUserToZone(Guid userId, Guid zoneId);
    public Task<bool> RemoveUserFromZone(Guid userId, Guid zoneId);
    public Task<bool> DeleteZone(Guid zoneId);
    public Task<bool> CheckZoneExists(Guid zoneId);
}