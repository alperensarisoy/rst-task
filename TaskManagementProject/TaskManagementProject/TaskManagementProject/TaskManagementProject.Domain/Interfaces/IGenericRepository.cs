using System.Linq.Expressions;

namespace TaskManagementProject.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> GetByIdAsync(long id);

        Task<bool> DeleteByIdAsync(long id);
        
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
