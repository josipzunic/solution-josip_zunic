namespace AcademyTask.Domain.Interfaces.Common;

public interface IRepository<TEntity, in TId> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TId id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task SaveAsync();
}