namespace Zone.Data.Models;

public class ZoneLobby
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = "";
    public string HashedPassword { get; set; } = "";
    public List<Note> Notes { get; set; }
    public Guid UserOwnerId { get; set; }
    public User UserOwner { get; set; }
    public List<User> JoinedUsers { get; set; }
}