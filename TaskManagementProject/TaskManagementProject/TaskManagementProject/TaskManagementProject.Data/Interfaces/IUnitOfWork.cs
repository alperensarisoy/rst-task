namespace TaskManagementProject.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitChangesAsync();

        IUserRepository UserRepository { get; }

        ITaskRepository TaskRepository { get; }
    }
}
