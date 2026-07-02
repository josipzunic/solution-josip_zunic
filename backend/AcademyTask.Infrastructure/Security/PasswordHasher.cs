using AcademyTask.Domain.Entities.User;
using AcademyTask.Domain.Interfaces.Common;
using Microsoft.AspNetCore.Identity;

namespace AcademyTask.Infrastructure.Security;

public class IdentityPasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<User> _hasher = new();

    public string Hash(string password)
    {
        return _hasher.HashPassword(null!, password);
    }

    public bool Verify(string password, string hash)
    {
        var result = _hasher.VerifyHashedPassword(null!, hash, password)
                     == PasswordVerificationResult.Success;

        return result;
    }
}