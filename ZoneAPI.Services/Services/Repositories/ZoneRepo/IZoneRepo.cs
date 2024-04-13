using Zone.Data.Data.DTOs;
using Zone.Data.Data.DTOs.Requests;
using Zone.Data.Data.DTOs.Responses;

namespace Zone.Services.Services.Repositories.ZoneRepo;

public interface IZoneRepo
{
    public Task<List<ZoneResponseDTO>> GetZones();
    public Task<ZoneResponseDTO> GetZone(Guid zoneId);
    public Task<bool> AddZone(Data.Data.Models.Zone newZoneDto);
    public Task<bool> UpdateZone(Data.Data.Models.Zone updatedZone);
    public Task<bool> RemoveZone(Data.Data.Models.Zone zoneToRemove);

}