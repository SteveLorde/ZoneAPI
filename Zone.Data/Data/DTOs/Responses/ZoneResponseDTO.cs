using Zone.Data.Data.Models;

namespace Zone.Data.Data.DTOs;

public record ZoneResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<Note> Notes { get; set; }
    public Guid UserId { get; set; }
    public User UserOwner { get; set; }
    public List<User> Users { get; set; }
};