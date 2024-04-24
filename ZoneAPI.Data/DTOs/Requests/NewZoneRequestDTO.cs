namespace Zone.Data.DTOs.Requests;

public record NewZoneRequestDTO
{
    public string Title { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Today;
};