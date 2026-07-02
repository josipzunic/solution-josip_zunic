using AcademyTask.Domain.Common.Model;
using AcademyTask.Domain.Entities.User;
using AcademyTask.Domain.Interfaces;
using AcademyTask.Domain.Interfaces.Common;
using AcademyTask.Domain.Validation;
using AcademyTask.Domain.Validation.ValidationItems;

namespace AcademyTask.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    
    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<User>> RegisterAsync(string username, string password, string email)
    {
        var userByEmail = await _userRepository.FindByEmailAsync(email);
        var userByUsername = await _userRepository.FindByUsernameAsync(username);
        var validationResult = new ValidationResult();
        
        List<char> specialSymbols = 
        [
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
            '-', '_', '+', '=', '{', '}', '[', ']', '|', '\\',
            ':', ';', '"', '\'', '<', '>', ',', '.', '?', '/'
        ];
        
        List<char> digits = 
        [
            '0','1','2','3','4','5','6','7','8','9'
        ];
        
        if(userByUsername != null)
            validationResult.AddValidationItems(ValidationItems.User.UsernameUnique);
        if(userByEmail != null)
            validationResult.AddValidationItems(ValidationItems.User.EmailUnique);
        if(password.Length < User.MinPasswordLength)
            validationResult.AddValidationItems(ValidationItems.User.MinPasswordLength);
        else if(password.Length > User.MaxPasswordLength)
            validationResult.AddValidationItems(ValidationItems.User.MaxPasswordLength);
        if(!password.Any(s => specialSymbols.Contains(s)))
            validationResult.AddValidationItems(ValidationItems.User.PasswordSpecialCharacter);
        if(password.Any(s => digits.Contains(s)))
            validationResult.AddValidationItems(ValidationItems.User.PasswordDigit);
        

        if (validationResult.HasErrors)
            return new Result<User>(null, validationResult);

        var hashedPassword = _passwordHasher.Hash(password);
        
        var result = User.Create(username, hashedPassword, email);

        if (result.ValidationResult.HasErrors)
            return result;
        
        await _userRepository.AddAsync(result.Value!);
        await _userRepository.SaveAsync();

        return result;
    }

    public async Task<Result<User>> LoginAsync(string username, string password)
    {
        var user = await _userRepository.FindByUsernameAsync(username);
        var validationResult = new ValidationResult();
        
        if(user == null)
            validationResult.AddValidationItems(ValidationItems.User.InvalidCredentials);

        if (validationResult.HasErrors)
            return new Result<User>(null, validationResult);

        var validLogin = _passwordHasher.Verify(password, user!.PasswordHash);
        
        if(!validLogin)
            validationResult.AddValidationItems(ValidationItems.User.InvalidCredentials);
        
        if (validationResult.HasErrors)
            return new Result<User>(null, validationResult);
        
        return new Result<User>(user, validationResult);
    }
}