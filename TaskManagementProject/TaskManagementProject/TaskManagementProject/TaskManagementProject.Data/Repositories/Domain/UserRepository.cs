using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagementProject.Data.Context;
using TaskManagementProject.Data.Generics;
using TaskManagementProject.Data.Interfaces;
using TaskManagementProject.Domain.Entities;

namespace TaskManagementProject.Data.Repositories.Domain
{
    public class UserRepository : GenericRepository<t_User>, IUserRepository
    {

        private readonly TaskManagementProjectContext
            _context;
        public UserRepository(TaskManagementProjectContext context) : base(context)
        {
            _context = context; 
        }


        public async Task<t_User> GetByAsync(Expression<Func<t_User, bool>> filter)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(filter);

          
            return entity;
        }
    }
}
