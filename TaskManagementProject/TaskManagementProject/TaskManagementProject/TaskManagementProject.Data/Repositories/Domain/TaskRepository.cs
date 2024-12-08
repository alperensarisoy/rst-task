using TaskManagementProject.Data.Context;
using TaskManagementProject.Data.Generics;
using TaskManagementProject.Data.Interfaces;
using TaskManagementProject.Domain.Entities;

namespace TaskManagementProject.Data.Repositories.Domain
{
    public class TaskRepository : GenericRepository<t_Task>, ITaskRepository
    {

        private readonly TaskManagementProjectContext _context;
        public TaskRepository(TaskManagementProjectContext context) : base(context)
        {
            _context = context; 
        }
    }
}
