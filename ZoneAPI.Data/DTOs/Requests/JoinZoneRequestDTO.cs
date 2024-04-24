namespace Zone.Data.DTOs.Requests;

public record JoinZoneRequestDTO
{
    public Guid userId { get; set; }
    public Guid zoneId { get; set; }
}