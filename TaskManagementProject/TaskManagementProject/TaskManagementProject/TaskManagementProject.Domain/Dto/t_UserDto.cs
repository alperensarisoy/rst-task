using TaskManagementProject.Domain.Dto.Base;

namespace TaskManagementProject.Domain.Dto
{
    public class t_UserDto : DtoBase
    {

        public string Name { get; set; }    
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
