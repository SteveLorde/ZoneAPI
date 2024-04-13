namespace Zone.Data.Data.Models;

public class Note
{
    public Guid Id { get; set; }
    public Guid ZoneId { get; set; }
    public Zone Zone { get; set; }
    public string Content { get; set; }
}