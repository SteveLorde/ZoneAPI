namespace Zone.Data.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserName { get; set; }
    public string HashedPassword { get; set; }
    public List<ZoneLobby> CreatedZones { get; set; }
    public DateTime JoinedOn { get; set; } = DateTime.Today;
    public List<ZoneLobby> JoinedZones { get; set; } = new List<ZoneLobby>();
}