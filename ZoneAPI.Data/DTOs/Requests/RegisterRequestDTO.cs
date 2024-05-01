namespace Zone.Data.DTOs.Requests;

public record RegisterRequestDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
};