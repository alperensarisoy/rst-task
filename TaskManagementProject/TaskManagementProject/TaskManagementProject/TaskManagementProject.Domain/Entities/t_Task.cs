using System.ComponentModel.DataAnnotations;
using TaskManagementProject.Domain.Entities.Base;

namespace TaskManagementProject.Domain.Entities
{
    public class t_Task : EntityBase
    {
        [Required]
        public string Title { get; set; }   

        public string? Description { get; set; } 

    }
}
