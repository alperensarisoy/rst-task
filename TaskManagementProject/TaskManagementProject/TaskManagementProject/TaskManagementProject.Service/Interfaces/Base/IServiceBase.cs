using TaskManagementProject.Domain.Interfaces;

namespace TaskManagementProject.Service.Interfaces.Base
{
    public interface IServiceBase<TDto, TEntity>
    {
        Task<ICollection<TDto>> GetAllAsync(Func<IEntity, bool> filter = null);

        Task<TDto> GetByIdAsync(int id);

        Task<TDto> AddAsync(TDto dto);

        Task<TDto> UpdateAsync(TDto dto);

        Task<bool> DeleteByAsync(TDto dto);

    }
}
