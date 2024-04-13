using Microsoft.AspNetCore.Mvc;
using Zone.Data.Data.DTOs;
using Zone.Services.Services.Zone;

namespace Zone.API.Controllers;

[ApiController]
[Route("Zone")]
public class ZoneController : Controller
{
    private readonly IZoneService _zoneService;

    public ZoneController(IZoneService zoneService)
    {
        _zoneService = zoneService;
    }
    
    [HttpGet("getzones")]
    public async Task<List<ZoneResponseDTO>> GetZones()
    {
        return await _zoneService.GetZones();
    }
    
    [HttpGet("getzone/{zoneid}")]
    public async Task<ZoneResponseDTO> GetZone(string zoneid)
    {
        return await _zoneService.GetZone(Guid.Parse(zoneid));
    }
    
    [HttpPost("createzone")]
    public async Task<bool> CreateZone(NewZoneRequestDTO newZoneRequest)
    {
        return await _zoneService.CreateZone(newZoneRequest);
    }
    
    
    
    
}