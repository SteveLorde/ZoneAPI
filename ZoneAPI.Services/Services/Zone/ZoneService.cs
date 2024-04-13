using Zone.Data.Data.DTOs.Requests;
using Zone.Data.Data.DTOs.Responses;
using Zone.Services.Services.Repositories.ZoneRepo;

namespace Zone.Services.Services.Zone;

public class ZoneService : IZoneService
{
    private readonly IZoneRepo _zoneRepo;

    public ZoneService(IZoneRepo zoneRepo)
    {
        _zoneRepo = zoneRepo;
    }
    
    public async Task<List<ZoneResponseDTO>> GetZones()
    {
        return await _zoneRepo.GetZones();
    }

    public async Task<ZoneResponseDTO> GetZone(Guid zoneId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateZone(NewZoneRequestDTO newZoneRequest)
    {
        throw new NotImplementedException();
    }

    public async Task AddUserToZone(Guid userId, Guid zoneId)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveUserFromZone(Guid userId, Guid zoneId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteZone(Guid zoneId)
    {
        throw new NotImplementedException();
    }
}