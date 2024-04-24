namespace Zone.Data.Models;

public class Note
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ZoneId { get; set; }
    public ZoneLobby ZoneLobby { get; set; }
    public string Content { get; set; }
}