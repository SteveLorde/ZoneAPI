using Zone.Data.Models;

namespace Zone.Data.DTOs.Responses;

public record ZoneResponseDTO
{
    public Guid Id { get; set; } 
    public string Title { get; set; } 
    public List<NoteResponseDTO> Notes { get; set; }
    public Guid UserOwnerId { get; set; }
    public UserResponseDTO UserOwner { get; set; }
    public List<UserResponseDTO> JoinedUsers { get; set; }
};