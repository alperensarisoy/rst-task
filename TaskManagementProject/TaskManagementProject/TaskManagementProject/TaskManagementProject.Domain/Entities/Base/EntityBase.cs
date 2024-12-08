using TaskManagementProject.Domain.Interfaces;

namespace TaskManagementProject.Domain.Entities.Base
{
    public class EntityBase : IEntity
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
