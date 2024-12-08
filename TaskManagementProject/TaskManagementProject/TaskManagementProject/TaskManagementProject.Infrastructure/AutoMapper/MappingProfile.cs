using AutoMapper;
using TaskManagementProject.Domain.AutoMapper;

namespace TaskManagementProject.Infrastructure.AutoMapper
{
    public class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());

            });

            return config;
        }
    }
}
