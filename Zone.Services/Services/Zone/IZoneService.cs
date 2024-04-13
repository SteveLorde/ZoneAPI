namespace Zone.Services.Services.Zone;

public interface IZoneService
{
    public Task GetZones();
    public Task CreateZone();
    public Task AddUserToZone(Guid userId, Guid zoneId);
    public Task RemoveUserFromZone(Guid userId, Guid zoneId);
    public Task DeleteZone(Guid zoneId);
}