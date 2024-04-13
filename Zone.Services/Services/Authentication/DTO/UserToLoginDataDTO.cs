namespace Zone.Services.Services.Authentication.DTO;

public record UserToLoginDataDTO
{
    public Guid Id { get; set; }
    public string HashedPassword { get; set; }
};