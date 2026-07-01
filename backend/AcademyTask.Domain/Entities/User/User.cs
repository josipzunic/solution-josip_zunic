namespace AcademyTask.Domain.Entities.User;

public class User
{
    public const int MinUsernameLength = 3;
    public const int MaxUsernameLength = 100;
    public const int MinPasswordLength = 6;
    public const int MaxPasswordLength = 100;
    
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public void SetPassword(string passwordHash) => PasswordHash = passwordHash;
}