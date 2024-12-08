using TaskManagementProject.Domain.Entities;
using TaskManagementProject.Domain.Interfaces;

namespace TaskManagementProject.Data.Interfaces
{
    public  interface ITaskRepository : IGenericRepository<t_Task>
    {
    }
}
