using AutoMapper;
using Zone.Data.DTOs.Requests;
using Zone.Data.DTOs.Responses;
using Zone.Data.Models;
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
    
    /*
    public async Task<bool> CheckZoneExists(NewZoneRequestDTO newZoneRequest)
    {
        return await _zoneRepo.
    }
    */

    public async Task<ZoneResponseDTO> GetZone(Guid zoneId)
    {
        return await _zoneRepo.GetZone(zoneId);
    }

    public async Task<Guid> CreateZone(NewZoneRequestDTO newZoneRequest)
    {
        ZoneLobby newZoneLobby = _mapper.Map<ZoneLobby>(newZoneRequest);
        bool checkAdd = await _zoneRepo.AddZone(newZoneLobby);
        if (checkAdd)
        {
            return newZoneLobby.Id;
        }
        else
        {
            return Guid.Empty;
        }
    }

    public async Task<bool> AddUserToZone(Guid userId, Guid zoneId)
    {
        //get user and get zone
        var user = await _userRepo.GetUser(userId);
        var zone = await _zoneRepo.GetZoneDirectly(zoneId);
        
        //add user
        //zone.JoinedUsers.Add(user);
        
        //update zone
        return await _zoneRepo.UpdateZone(zone);
    }

    public async Task<bool> RemoveUserFromZone(Guid userId, Guid zoneId)
    {
        User user = await _userRepo.GetUserDirectly(userId);
        ZoneLobby zoneLobby = await _zoneRepo.GetZoneDirectly(zoneId);
        zoneLobby.JoinedUsers.Remove(user);
        return await _zoneRepo.UpdateZone(zoneLobby);
    }

    public async Task<bool> DeleteZone(Guid zoneId)
    {
        ZoneLobby zoneLobby = await _zoneRepo.GetZoneDirectly(zoneId);
        return await _zoneRepo.RemoveZone(zoneLobby);
    }

    public async Task<bool> CheckZoneExists(Guid zoneId)
    {
        return await _zoneRepo.CheckZoneExists(zoneId);
    }
}