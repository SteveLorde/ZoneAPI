namespace Zone.Data.Data.DTOs;

public record Message
{
    public Guid ZoneId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public DateTime SentOn { get; set; } = DateTime.Now;
};