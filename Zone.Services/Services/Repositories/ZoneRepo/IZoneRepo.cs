using Zone.Data.Data.DTOs;

namespace Zone.Services.Services.Repositories.ZoneRepo;

public interface IZoneRepo
{
    public Task GetZones();
    public Task GetZone(Guid zoneId);
    public Task AddZone(NewZoneRequestDTO newZoneDto);
    public Task UpdateZone();
    public Task RemoveZone(Guid zoneId);

}