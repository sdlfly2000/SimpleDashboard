namespace Infra.Database.SQLServer.UserStory.Mappers
{
    public interface IMapper<in TEntity, out TAspect>
        where TAspect : class
        where TEntity : class
    {
        TAspect Map(TEntity aspect);
    }
}
