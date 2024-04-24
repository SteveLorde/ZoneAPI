using System.ComponentModel.DataAnnotations;

namespace Zone.Data.Models;

public class UsersInZones
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid ZoneLobbyId { get; set; } 
    public ZoneLobby ZoneLobby { get; set; }
}