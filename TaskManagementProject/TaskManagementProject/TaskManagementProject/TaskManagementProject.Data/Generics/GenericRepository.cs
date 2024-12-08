using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagementProject.Data.Context;
using TaskManagementProject.Domain.Interfaces;


namespace TaskManagementProject.Data.Generics
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {

        private readonly TaskManagementProjectContext _context;

        internal DbSet<TEntity> _dbSet;

        public GenericRepository(TaskManagementProjectContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if(entity == null)
            {
                throw new KeyNotFoundException("Entity Not Found");
            }
            _context.Entry(entity).State = EntityState.Deleted;
            _context.Remove(entity);
            return true;
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter != null ? _dbSet.Where(filter).AsQueryable() : _dbSet.AsQueryable();
        }

        public  async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(a=> a.Id == id) ?? default;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var oldEntity = await _dbSet.FirstOrDefaultAsync(a => a.Id == entity.Id);

            if (oldEntity is null)
            {
                throw new KeyNotFoundException("Entity Not Found");
            }

            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            return oldEntity;
        }
    }
}
