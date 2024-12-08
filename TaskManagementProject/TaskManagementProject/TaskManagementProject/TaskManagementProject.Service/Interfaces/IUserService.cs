using TaskManagementProject.Domain.Entities;
using TaskManagementProject.Service.Interfaces.Base;

namespace TaskManagementProject.Service.Interfaces
{
    public interface IUserService<TDto, TEntity>: IServiceBase<TDto,TEntity>   
    {
        Task<t_User> ValidateUserAsync(string username, string password);
        string GenerateJwtToken(t_User user);
    }
}
