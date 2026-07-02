using AcademyTask.Domain.Interfaces;
using AcademyTask.Infrastructure.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AcademyTask.Infrastructure.Persistence.Repositories.User;

public class UserRepository : Repository<Domain.Entities.User.User, int>, IUserRepository
{
    public UserRepository(DbContext context) : base(context) {}
    
    public async Task<Domain.Entities.User.User?> FindByEmailAsync(string email)
    {
        return await DbSet.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<Domain.Entities.User.User?> FindByUsernameAsync(string username)
    {
        return await DbSet.FirstOrDefaultAsync(user => user.Username == username);
    }
}