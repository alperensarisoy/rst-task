using AutoMapper;

namespace TaskManagementProject.Infrastructure.AutoMapper
{
    public class TaskManagementProjectMapper : ITaskManagementProjectMapper
    {
        private readonly IMapper _mapper;

        public TaskManagementProjectMapper()
        {
            _mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
        }

        // Tek parametreli Map metodu (zaten vardı)
        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        // Üç parametreli Map metodu (zaten vardı)
        public object Map(object source, Type sourceType, Type destinationType)
        {
            return _mapper.Map(source, sourceType, destinationType);
        }

        // Yeni eklenen iki parametreli Map metodu
        public TEntity Map<TSource, TEntity>(TSource source, TEntity destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
