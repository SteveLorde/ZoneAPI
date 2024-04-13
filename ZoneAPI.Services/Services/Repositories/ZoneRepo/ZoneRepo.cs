﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Zone.Data.Data;
using Zone.Data.Data.DTOs.Responses;
using Zone.Data.Data.Models;

namespace Zone.Services.Services.Repositories.ZoneRepo;

public class ZoneRepo : IZoneRepo
{
    private readonly DataContext _db;
    private readonly IMapper _mapper;

    public ZoneRepo(DataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<List<ZoneResponseDTO>> GetZones()
    {
        return await _db.Zones.ProjectTo<ZoneResponseDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<ZoneResponseDTO> GetZone(Guid zoneId)
    {
        return await _db.Zones.ProjectTo<ZoneResponseDTO>(_mapper.ConfigurationProvider).FirstAsync(zone => zone.Id == zoneId);
    }

    public async Task<ZoneLobby> GetZoneDirectly(Guid zoneId)
    {
        return await _db.Zones.FirstAsync(zone => zone.Id == zoneId);
    }

    public async Task<bool> AddZone(Data.Data.Models.ZoneLobby newZoneLobby)
    { 
        await _db.Zones.AddAsync(newZoneLobby);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateZone(Data.Data.Models.ZoneLobby updatedZoneLobby)
    {
        _db.Update(updatedZoneLobby);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveZone(Data.Data.Models.ZoneLobby zoneLobbyToRemove)
    {
        _db.Zones.Remove(zoneLobbyToRemove);
        await _db.SaveChangesAsync();
        return true;
    }
}