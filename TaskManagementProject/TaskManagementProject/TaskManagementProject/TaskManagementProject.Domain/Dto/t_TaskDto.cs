using TaskManagementProject.Domain.Dto.Base;

namespace TaskManagementProject.Domain.Dto
{
    public class t_TaskDto : DtoBase
    {
        public string Title { get; set; }

        public string? Description { get; set; }
    }
}
