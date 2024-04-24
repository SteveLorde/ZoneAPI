using Zone.Data.Models;

namespace Zone.Data.DTOs.Responses;

public record ZoneResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<Note> Notes { get; set; }
    public Guid UserId { get; set; }
    public User UserOwner { get; set; }
    public List<User> Users { get; set; }
};