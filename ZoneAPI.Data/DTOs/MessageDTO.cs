namespace Zone.Data.DTOs;

public record MessageDTO
{
    public Guid ZoneId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public DateTime SentOn { get; set; } = DateTime.Now;
};