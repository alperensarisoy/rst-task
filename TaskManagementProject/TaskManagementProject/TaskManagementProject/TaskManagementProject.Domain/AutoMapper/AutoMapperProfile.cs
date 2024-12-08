using AutoMapper;
using TaskManagementProject.Domain.Dto;
using TaskManagementProject.Domain.Entities;

namespace TaskManagementProject.Domain.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
         
            CreateMap<t_User, t_UserDto>().ReverseMap();
            CreateMap<t_Task, t_TaskDto>().ReverseMap();
           

        }
    }
}
