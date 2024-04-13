namespace Zone.Data.Data.DTOs;

public record AuthRequestDTO()
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
};