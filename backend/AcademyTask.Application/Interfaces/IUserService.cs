using AcademyTask.Domain.Common.Model;
using AcademyTask.Domain.Entities.User;

namespace AcademyTask.Application.Interfaces;

public interface IUserService
{
    Task<Result<User>> RegisterAsync(string username, string password, string email);
    Task<Result<User>> LoginAsync(string username, string password);
}