namespace Zone.Data.DTOs.Requests;

public record LoginRequestDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }
};