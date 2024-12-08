using TaskManagementProject.Data.Context;
using TaskManagementProject.Data.Interfaces;

namespace TaskManagementProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TaskManagementProjectContext _context;


        public IUserRepository UserRepository { get; private set; }


        public ITaskRepository TaskRepository {  get; private set; }

        public UnitOfWork(TaskManagementProjectContext context, IUserRepository userRepository, ITaskRepository taskRepository)
        {
            _context = context;

            this.UserRepository = userRepository;

            this.TaskRepository = taskRepository;

        }

        // CommitChangesAsync - Yapılan işlemleri dbye basar
        public async Task<int> CommitChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Dispose - contexti yok eder
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    try
                    {
                        _context.Dispose();
                    }
                    catch
                    { }
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
