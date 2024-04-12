namespace Zone.Data.Data.Models;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string HashedPassword { get; set; }
    public List<Zone> Zones { get; set; }
}