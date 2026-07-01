using AcademyTask.Domain.Entities.User;
using AcademyTask.Domain.Interfaces.Common;

namespace AcademyTask.Domain.Interfaces;

public interface IUserRepository : IRepository<User, int> {}
