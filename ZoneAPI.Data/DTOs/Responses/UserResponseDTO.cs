namespace Zone.Data.DTOs.Responses;

public record UserResponseDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string JoinedOn { get; set; }
    public List<ZoneResponseDTO> JoinedZones { get; set; }
};