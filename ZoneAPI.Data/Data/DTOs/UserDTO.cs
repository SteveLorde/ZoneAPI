namespace Zone.Data.Data.DTOs;

public record UserDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public List<Models.ZoneLobby> Zones { get; set; }
    public DateTime JoinedOn { get; set; } = DateTime.Today;
};