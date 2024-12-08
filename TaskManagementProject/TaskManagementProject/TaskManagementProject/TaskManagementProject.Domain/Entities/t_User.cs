using System.ComponentModel.DataAnnotations;
using TaskManagementProject.Domain.Entities.Base;

namespace TaskManagementProject.Domain.Entities
{
    public class t_User : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
