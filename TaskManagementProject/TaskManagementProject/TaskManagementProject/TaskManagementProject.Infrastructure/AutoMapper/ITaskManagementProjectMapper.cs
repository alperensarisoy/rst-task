namespace TaskManagementProject.Infrastructure.AutoMapper
{
    public interface ITaskManagementProjectMapper
    {
        TDestination Map<TDestination>(object source);
        object Map(object source, Type sourceType, Type destinationType);

        TEntity Map<TSource, TEntity>(TSource source, TEntity destination);
    }
}
