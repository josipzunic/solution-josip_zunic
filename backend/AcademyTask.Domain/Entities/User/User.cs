using System.Net.Mail;
using AcademyTask.Domain.Common.Model;
using AcademyTask.Domain.Validation;
using AcademyTask.Domain.Validation.ValidationItems;

namespace AcademyTask.Domain.Entities.User;

public class User
{
    public const int MinUsernameLength = 3;
    public const int MaxUsernameLength = 100;
    public const int MinPasswordLength = 6;
    public const int MaxPasswordLength = 100;
    
    public int Id { get; private set; }
    public string Username { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public ICollection<LikedProduct.LikedProduct> LikedProducts { get; private set; } = [];

    private User() {}
    public static Result<User> Create(string username, string passwordHash, string email)
    {
        ValidationResult validationResult = new ValidationResult();

        if (username.Length < MinUsernameLength || string.IsNullOrWhiteSpace(username))
            validationResult.AddValidationItems(ValidationItems.User.MinUsernameLength);
        else if (username.Length > MaxUsernameLength)
            validationResult.AddValidationItems(ValidationItems.User.MaxUsernameLength);
        if (string.IsNullOrWhiteSpace(email))
            validationResult.AddValidationItems(ValidationItems.User.EmailRequired);
        else if(!IsValidEmail(email))
            validationResult.AddValidationItems(ValidationItems.User.InvalidEmailFormat);
        if (string.IsNullOrWhiteSpace(passwordHash))
            validationResult.AddValidationItems((ValidationItems.User.PasswordHashEmpty));
        

        if (validationResult.HasErrors)
            return new Result<User>(null, validationResult);

        var user = new User()
        {
            Username = username,
            Email = email,
            UpdatedAt = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow
        };
        user.SetPassword(passwordHash);
        
        return new Result<User>(user, validationResult);
    } 
    private void SetPassword(string passwordHash)
    {
        PasswordHash = passwordHash;
    }
    
    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}