using AcademyTask.Domain.Entities.User;

namespace AcademyTask.Domain.Interfaces.Common;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}