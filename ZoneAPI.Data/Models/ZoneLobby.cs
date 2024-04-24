namespace Zone.Data.Models;

public class ZoneLobby
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = "";
    public List<Note> Notes { get; set; } = new List<Note>();
    public Guid UserOwnerId { get; set; }
    public User UserOwner { get; set; } = new User();
    public List<User> JoinedUsers { get; set; } = new List<User>();
}