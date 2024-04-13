using AutoMapper;
using Zone.Data.Data.DTOs.Requests;
using Zone.Data.Data.DTOs.Responses;
using Zone.Data.Data.Models;
using Zone.Services.Services.Repositories.UserRepo;
using Zone.Services.Services.Repositories.ZoneRepo;

namespace Zone.Services.Services.Zone;

public class ZoneService : IZoneService
{
    private readonly IZoneRepo _zoneRepo;
    private readonly IMapper _mapper;
    private readonly IUserRepo _userRepo;

    public ZoneService(IZoneRepo zoneRepo,IUserRepo userRepo,IMapper mapper)
    {
        _zoneRepo = zoneRepo;
        _mapper = mapper;
        _userRepo = userRepo;
    }
    
    public async Task<List<ZoneResponseDTO>> GetZones()
    {
        return await _zoneRepo.GetZones();
    }

    public async Task<ZoneResponseDTO> GetZone(Guid zoneId)
    {
        return await _zoneRepo.GetZone(zoneId);
    }

    public async Task<bool> CreateZone(NewZoneRequestDTO newZoneRequest)
    {
        Data.Data.Models.ZoneLobby newZoneLobby = _mapper.Map<Data.Data.Models.ZoneLobby>(newZoneRequest);
        return await _zoneRepo.AddZone(newZoneLobby);
    }

    public async Task<bool> AddUserToZone(Guid userId, Guid zoneId)
    {
        //get user and get zone
        var user = await _userRepo.GetUser(userId);
        var zone = await _zoneRepo.GetZoneDirectly(zoneId);
        
        //add user
        zone.Users.Add(user);
        
        //update zone
        return await _zoneRepo.UpdateZone(zone);
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