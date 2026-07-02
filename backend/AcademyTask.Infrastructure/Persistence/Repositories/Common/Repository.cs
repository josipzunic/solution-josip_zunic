using AcademyTask.Domain.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace AcademyTask.Infrastructure.Persistence.Repositories.Common;

public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class 
{
    protected readonly DbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(DbContext context)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();
    }
    
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TEntity entity)
    {
        DbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task SaveAsync()
    {
        await Context.SaveChangesAsync();
    }
}