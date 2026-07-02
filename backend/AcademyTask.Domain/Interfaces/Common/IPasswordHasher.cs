namespace AcademyTask.Domain.Interfaces.Common;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string hash);
}