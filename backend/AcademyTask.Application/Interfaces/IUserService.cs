using AcademyTask.Domain.Common.Model;
using AcademyTask.Domain.Entities.User;

namespace AcademyTask.Application.Interfaces;

public interface IUserService
{
    Task<Result<User>> RegisterAsync(string username, string password, string email);
    Task<Result<string>> LoginAsync(string username, string password);
}