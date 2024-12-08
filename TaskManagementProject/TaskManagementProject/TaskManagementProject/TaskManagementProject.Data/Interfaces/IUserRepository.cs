using System.Linq.Expressions;
using TaskManagementProject.Domain.Entities;
using TaskManagementProject.Domain.Interfaces;

namespace TaskManagementProject.Data.Interfaces
{
    public interface IUserRepository : IGenericRepository<t_User>
    {
        public  Task<t_User> GetByAsync(Expression<Func<t_User, bool>> filter);
    }
}
